using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents.UiComponents
{
    public class UiScriptComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
