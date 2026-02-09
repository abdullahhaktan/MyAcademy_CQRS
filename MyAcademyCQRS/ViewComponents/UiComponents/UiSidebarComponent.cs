using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents.UiComponents
{
    public class UiSidebarComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
