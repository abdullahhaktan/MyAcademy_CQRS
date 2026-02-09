using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents.UiComponents
{
    public class UiSidebarAndSocialMediaComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
