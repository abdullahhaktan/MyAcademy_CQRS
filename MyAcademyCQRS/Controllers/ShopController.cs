using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.OrderItemCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.CartHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.OrderItemHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers;
using MyAcademyCQRS.CQRSPattern.LogServices.CustomerLogServices;
using MyAcademyCQRS.CQRSPattern.Queries.CartQueries;
using MyAcademyCQRS.CQRSPattern.Queries.ProductQueries;
using MyAcademyCQRS.CQRSPattern.Results.ProductResults;
using MyAcademyCQRS.Entities;
using PagedList.Core;

namespace MyAcademyCQRS.Controllers
{
    [AllowAnonymous]
    public class ShopController(GetOrderItemsCountQueryHandler getOrderItemsCountQueryHandler, GetProductsQueryHandler getProductsQueryHandler, GetCategoriesQueryHandler getCategoriesQueryHandler, GetProductsByCategoryQueryHandler getProductsByCategoryQueryHandler, GetProductsByPriceQueryHandler getProductsByPriceQueryHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, CreateOrderCommandHandler createOrderCommandHandler, UserManager<AppUser> userManager, GetCartByUserQueryHandler getCartByUserQueryHandler, ICustomerLogService customerLogService, IMediator mediator) : Controller
    {
        private async Task GetOrderItemCountAsync()
        {
            if (User.Identity.Name != null)
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var orderItemsCount = await getOrderItemsCountQueryHandler.Handle(user.Id);
                ViewBag.orderItemsCount = orderItemsCount;
            }
        }
        public async Task<IActionResult> Index(int? id, int? minPrice, int? maxPrice, string sort, int page = 1, int pageSize = 9)
        {
            await GetOrderItemCountAsync();

            var categories = await getCategoriesQueryHandler.Handle();
            ViewBag.categories = categories;

            // 1. Veri Getirme Mantığı (Base List)
            var allProducts = await getProductsQueryHandler.Handle();
            List<GetProductsQueryResult> products = allProducts;

            // Kategori Filtresi
            if (id.HasValue)
            {
                products = await getProductsByCategoryQueryHandler.Handle(new GetProductByCategoryQuery(id.Value));
            }

            // Fiyat Filtresi (Kategori seçiliyse onun içinde, değilse genel listede filtreler)
            if (minPrice.HasValue && maxPrice.HasValue)
            {
                products = products.Where(x => x.Price >= minPrice.Value && x.Price <= maxPrice.Value).ToList();
            }

            // 2. Sıralama Mantığı
            products = sort switch
            {
                "1" => products.OrderBy(x => x.Price).ToList(),
                "2" => products.OrderByDescending(x => x.Price).ToList(),
                "3" => products.OrderBy(x => x.Title).ToList(),
                _ => products
            };

            var values = new PagedList<GetProductsQueryResult>(products.AsQueryable(), page, pageSize);

            // ViewBag Değerleri (Hata almamak için her zaman atanmalı)
            ViewBag.totalProducts = products.Count();
            ViewBag.totalPageProducts = values.Count();
            // Hata buradaydı: Filtreleme ne olursa olsun son eklenen 3 ürünü ana listeden alıyoruz
            ViewBag.lastAddedThreeProducts = allProducts.OrderByDescending(p => p.Id).Take(3).ToList();

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchField, int page = 1, int pageSize = 9)
        {
            await GetOrderItemCountAsync();

            var categories = await getCategoriesQueryHandler.Handle();
            ViewBag.categories = categories;

            var products = await getProductsQueryHandler.Handle();

            if (!string.IsNullOrEmpty(searchField))
            {
                products = products.Where(p => p.Title.Contains(searchField, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            var values = new PagedList<GetProductsQueryResult>(products.AsQueryable(), page, pageSize);

            ViewBag.totalProducts = products.Count();
            ViewBag.totalPageProducts = values.Count();
            ViewBag.lastAddedThreeProducts = products.OrderByDescending(p => p.Id).Take(3);

            return View(values);
        }

        public async Task<IActionResult> ShopDetail(int id)
        {
            await GetOrderItemCountAsync();

            var user = (User.Identity.Name) == null ? null : User.Identity.Name;
            if (user == null)
            {
                TempData["message"] = "login required";
                return RedirectToAction("Index");
            }

            var product = await getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            System.Diagnostics.Debug.WriteLine("Gelen ID Değeri: " + id);
            var relatedProducts = await getProductsByCategoryQueryHandler.Handle(new GetProductByCategoryQuery(product.Id));
            ViewBag.relatedProducts = relatedProducts;
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(int ProductId, int Quantity)
        {
            var productId = ProductId;
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var cart = await mediator.Send(new GetCartByUserQuery(user.Id));

            int? orderId = null;

            var product = await getProductByIdQueryHandler.Handle(new GetProductByIdQuery(productId));

            CreateOrderItemCommand createOrderItemCommand = new CreateOrderItemCommand(orderId, cart.Id, productId, Quantity, product.Price);

            await mediator.Send(createOrderItemCommand);

            TempData["message"] = "order received";

            await customerLogService.WriteLog(
                user.Email,
                "Sipariş Oluşturuldu",
                "127.0.0.1",
                "Sipariş İşlemi",
                $"Ürün Id: {productId} | Adet: {Quantity} | Birim Fiyat: {product.Price} ₺"
            );

            return RedirectToAction("ShopDetail", new { id = productId });
        }
    }
}
