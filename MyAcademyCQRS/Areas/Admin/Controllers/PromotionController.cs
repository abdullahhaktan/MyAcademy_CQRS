using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers;
using MyAcademyCQRS.CQRSPattern.LogServices.AdminLogServices;
using MyAcademyCQRS.CQRSPattern.Queries.PromotionQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PromotionController(GetPromotionsQueryHandler getPromotionsQueryHandler, GetPromotionByIdQueryHandler getPromotionByIdQueryHandler, CreatePromotionCommandHandler createPromotionCommandHandler, UpdatePromotionCommandHandler updatePromotionCommandHandler, RemovePromotionCommandHandler removePromotionCommandHandler, IAdminLogService adminLogService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await getPromotionsQueryHandler.Handle();
            return View(values);
        }

        public async Task<IActionResult> CreatePromotion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromotion(CreatePromotionCommand command)
        {
            await createPromotionCommandHandler.Handle(command);

            await adminLogService.WriteLog(
                "Kampanya",
                "Kampanya Eklendi",
                $"Başlık: {command.Title} | Fiyat: {command.Price} ₺");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdatePromotion(int id)
        {
            var value = await getPromotionByIdQueryHandler.Handle(new GetPromotionByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePromotion(UpdatePromotionCommand command)
        {
            await updatePromotionCommandHandler.Handle(command);

            await adminLogService.WriteLog(
                "Kampanya",
                "Kampanya Güncellendi",
                $"Kampanya Id: {command.Id} | Yeni Başlık: {command.Title}");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePromotion(int id)
        {
            await removePromotionCommandHandler.Handle(new RemovePromotionCommand(id));

            await adminLogService.WriteLog(
                "Kampanya",
                "Kampanya Silindi",
                $"Silinen Kampanya Id: {id}"
            );

            return RedirectToAction("Index");
        }
    }
}
