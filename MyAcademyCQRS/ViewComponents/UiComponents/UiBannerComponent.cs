using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.BannerHandlers;

namespace MyAcademyCQRS.ViewComponents.UiComponents
{
    public class UiBannerComponent(GetBannersQueryHandler getBannersQueryHandler) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var banners = await getBannersQueryHandler.Handle();
            return View(banners);
        }
    }
}
