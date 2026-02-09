using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCQRS.CQRSPattern.Commands.OrderCommands;
using MyAcademyCQRS.CQRSPattern.Commands.OrderItemCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.OrderItemHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.UserHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.OrderItemQueries;
using MyAcademyCQRS.CQRSPattern.Queries.OrderQueries;
using MyAcademyCQRS.CQRSPattern.Queries.UserQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly GetOrdersQueryHandler _getOrdersQueryHandler;
        private readonly GetOrderByIdQueryHandler _getOrderByIdQueryHandler;
        private readonly UpdateOrderCommandHandler _updateOrderCommandHandler;
        private readonly RemoveOrderCommandHandler _removeOrderCommandHandler;
        private readonly GetUsersQueryHandler _getUsersQueryHandler;
        private readonly GetProductsQueryHandler _getProductsQueryHandler;
        private readonly IMediator _mediator;
        public OrderController(
            GetOrdersQueryHandler getOrdersQueryHandler,
            GetOrderByIdQueryHandler getOrderByIdQueryHandler,
            GetOrderItemByIdQueryHandler getOrderItemByIdQueryHandler,
            CreateOrderCommandHandler createOrderCommandHandler,
            UpdateOrderCommandHandler updateOrderCommandHandler,
            RemoveOrderCommandHandler removeOrderCommandHandler,
            GetUsersQueryHandler getUsersQueryHandler,
            GetProductsQueryHandler getProductsQueryHandler,
            IMediator mediator)
        {
            _getOrdersQueryHandler = getOrdersQueryHandler;
            _getOrderByIdQueryHandler = getOrderByIdQueryHandler;
            _getProductsQueryHandler = getProductsQueryHandler;
            _updateOrderCommandHandler = updateOrderCommandHandler;
            _removeOrderCommandHandler = removeOrderCommandHandler;
            _getUsersQueryHandler = getUsersQueryHandler;
            _mediator = mediator;
        }

        private async Task<List<SelectListItem>> GetUsersAsync()
        {
            var users = await _mediator.Send(new GetUsersQuery());

            List<SelectListItem> userList = (from user in users
                                             select new SelectListItem
                                             {
                                                 Text = user.FirstName + " " + user.LastName,
                                                 Value = user.Id.ToString()
                                             }).ToList();

            return userList;
        }

        private async Task GetProductsAsync()
        {
            var products = await _getProductsQueryHandler.Handle();

            List<SelectListItem> productList = (from product in products
                                                select new SelectListItem
                                                {
                                                    Text = product.Title,
                                                    Value = product.Id.ToString()
                                                }).ToList();

            ViewBag.products = productList;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getOrdersQueryHandler.Handle();
            return View(values);
        }

        public async Task<IActionResult> UpdateOrder(int id)
        {
            await GetUsersAsync(); // Henüz Kullanılmadı
            await GetProductsAsync();
            var value = await _getOrderByIdQueryHandler.Handle(new GetOrderByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand command)
        {
            await _updateOrderCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _removeOrderCommandHandler.Handle(new RemoveOrderCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetail(int id)
        {
            var order = await _getOrderByIdQueryHandler
                .Handle(new GetOrderByIdQuery(id));

            var result = new
            {
                id = order.Id,
                orderItems = order.OrderItems.Select(x => new
                {
                    productTitle = x.Product.Title,
                    quantity = x.Quantity,
                    unitPrice = x.UnitPrice
                })
            };

            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOrderItem(int id)
        {
            await GetUsersAsync(); // Henüz Kullanılmadı
            await GetProductsAsync();
            var orderItem = await _mediator.Send(new GetOrderItemByIdQuery(id));
            return View(orderItem);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrderItem(UpdateOrderItemCommand updateOrderItemCommand)
        {
            await _mediator.Send(updateOrderItemCommand);
            return RedirectToAction("UpdateOrderItem", updateOrderItemCommand.Id);
        }

    }
}
