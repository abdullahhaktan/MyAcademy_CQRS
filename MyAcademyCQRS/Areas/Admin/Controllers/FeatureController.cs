using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.FeatureCommands;
using MyAcademyCQRS.CQRSPattern.Queries.FeatureQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController(IMediator mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var features = await mediator.Send(new GetFeaturesQuery());
            return View(features);
        }

        public async Task<IActionResult> CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
        {
            await mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateFeature(int id)
        {
            var feature = await mediator.Send(new GetFeatureByIdQuery(id));
            return View(feature);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
        {
            await mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteFeature(int id)
        {
            await mediator.Send(new RemoveFeatureCommand(id));
            return RedirectToAction("Index");
        }
    }
}
