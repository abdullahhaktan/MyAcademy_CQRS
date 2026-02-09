using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents.UiComponents
{
    public class UiPreloadComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
