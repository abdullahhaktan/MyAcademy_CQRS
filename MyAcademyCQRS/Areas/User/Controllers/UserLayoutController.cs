using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.OrderItemHandlers;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Areas.User.Controllers
{
    [Area("User")]
    public class UserLayoutController(GetOrderItemsCountQueryHandler getOrderItemsCountQueryHandler, UserManager<AppUser> userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
