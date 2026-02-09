using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.ServiceCommands;
using MyAcademyCQRS.CQRSPattern.Queries.ServiceQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController(IMediator mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var services = await mediator.Send(new GetServicesQuery());
            return View(services);
        }

        public async Task<IActionResult> CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand createServiceCommand)
        {
            await mediator.Send(createServiceCommand);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateService(int id)
        {
            var service = await mediator.Send(new GetServiceByIdQuery(id));
            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand updateServiceCommand)
        {
            await mediator.Send(updateServiceCommand);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            await mediator.Send(new RemoveServiceCommand(id));
            return RedirectToAction("Index");
        }
    }
}
