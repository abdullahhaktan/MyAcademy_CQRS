using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Queries.CustomerQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerLogController(IMediator mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var CustomerLogs = await mediator.Send(new GetCustomerLogsQuery());
            return View(CustomerLogs);
        }
    }
}
