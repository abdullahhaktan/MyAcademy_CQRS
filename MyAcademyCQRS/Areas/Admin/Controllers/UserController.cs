using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.UserCommands;
using MyAcademyCQRS.CQRSPattern.Queries.UserQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController(IMediator mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var Users = await mediator.Send(new GetUsersQuery());
            return View(Users);
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            await mediator.Send(new RemoveUserCommand(id));
            return RedirectToAction("Index");
        }
    }
}
