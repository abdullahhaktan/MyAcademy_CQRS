using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers;

namespace MyAcademyCQRS.ViewComponents.UiComponents
{
    public class UiPromotionComponent(GetPromotionsQueryHandler getPromotionsQueryHandler) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var promotions = await getPromotionsQueryHandler.Handle();
            return View(promotions);
        }
    }
}
