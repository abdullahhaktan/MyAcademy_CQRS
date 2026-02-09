using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers;

namespace MyAcademyCQRS.ViewComponents.UiComponents
{
    public class UiProductComponent(GetProductsQueryHandler getProductsQueryHandler) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await getProductsQueryHandler.Handle();
            return View(products);
        }
    }
}
