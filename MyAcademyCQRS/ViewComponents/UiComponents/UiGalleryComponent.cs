using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers;

namespace MyAcademyCQRS.ViewComponents.UiComponents
{
    public class UiGalleryComponent(GetCategoriesQueryHandler getCategoriesQueryHandler) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await getCategoriesQueryHandler.Handle();
            return View(categories);
        }
    }
}
