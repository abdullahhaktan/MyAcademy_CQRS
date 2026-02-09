using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Queries.AdminLogQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLogController(IMediator mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var AdminLogs = await mediator.Send(new GetAdminLogsQuery());
            return View(AdminLogs);
        }
    }
}
