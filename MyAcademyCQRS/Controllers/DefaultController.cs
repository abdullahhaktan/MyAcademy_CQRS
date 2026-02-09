using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.OrderItemHandlers;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Controllers
{
    [AllowAnonymous]
    public class DefaultController(UserManager<AppUser> userManager, GetOrderItemsCountQueryHandler getOrderItemsCountQueryHandler) : Controller
    {
        private async Task GetOrderItemCountAsync()
        {
            if (User.Identity.Name != null)
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var orderItemsCount = await getOrderItemsCountQueryHandler.Handle(user.Id);
                ViewBag.orderItemsCount = orderItemsCount;
            }
        }

        public async Task<IActionResult> Index()
        {
            await GetOrderItemCountAsync();
            return View();
        }

    }
}
