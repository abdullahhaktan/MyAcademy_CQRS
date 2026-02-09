using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents.UiComponents
{
    public class UiHeadComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
