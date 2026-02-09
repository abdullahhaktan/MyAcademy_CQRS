using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.ProductQueries;
using MyAcademyCQRS.CQRSPattern.StorageServices;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(GetProductsQueryHandler getProductsQueryHandler,
                                   CreateProductCommandHandler createProductCommandHandler,
                                   GetCategoriesQueryHandler getCategoriesQueryHandler,
                                   UpdateProductCommandHandler updateProductCommandHandler,
                                   RemoveProductCommandHandler removeProductCommandHandler,
                                   GetProductByIdQueryHandler getProductByIdQueryHandler,
                                    IFileStorageService _fileStorageService

        ) : Controller
    {
        public async Task GetCategoriesAsync()
        {
            var categories = await getCategoriesQueryHandler.Handle();
            ViewBag.categories = (from x in categories
                                  select new SelectListItem
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
        }

        public async Task<IActionResult> Index()
        {
            var products = await getProductsQueryHandler.Handle();
            return View(products);
        }

        public async Task<IActionResult> CreateProduct()
        {
            await GetCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command,
           IFormFile ImageFile,
           IFormFile ImageFile1,
           IFormFile ImageFile2,
           IFormFile ImageFile3)
        {
            if (ImageFile != null)
                command = command with { ImageUrl = await _fileStorageService.UploadFileAsync(ImageFile, "products") };

            if (ImageFile1 != null)
                command = command with { ImageUrl1 = await _fileStorageService.UploadFileAsync(ImageFile1, "products") };

            if (ImageFile2 != null)
                command = command with { ImageUrl2 = await _fileStorageService.UploadFileAsync(ImageFile2, "products") };

            if (ImageFile3 != null)
                command = command with { ImageUrl3 = await _fileStorageService.UploadFileAsync(ImageFile3, "products") };

            await createProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateProduct(int id)
        {
            await GetCategoriesAsync();
            var product = await getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(
            UpdateProductCommand command,
            IFormFile ImageFile,
            IFormFile ImageFile1,
            IFormFile ImageFile2,
            IFormFile ImageFile3)
        {
            // Her fotoğraf varsa buluta yükle ve URL’i command’a set et
            if (ImageFile != null)
                command = command with { ImageUrl = await _fileStorageService.UploadFileAsync(ImageFile, "products") };

            if (ImageFile1 != null)
                command = command with { ImageUrl1 = await _fileStorageService.UploadFileAsync(ImageFile1, "products") };

            if (ImageFile2 != null)
                command = command with { ImageUrl2 = await _fileStorageService.UploadFileAsync(ImageFile2, "products") };

            if (ImageFile3 != null)
                command = command with { ImageUrl3 = await _fileStorageService.UploadFileAsync(ImageFile3, "products") };

            await updateProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteProduct(int id)
        {
            await removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }
    }
}
