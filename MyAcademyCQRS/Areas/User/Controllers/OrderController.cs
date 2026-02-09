using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.OrderItemHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.OrderQueries;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Areas.User.Controllers
{
    [Area("User")]
    public class OrderController(GetOrderItemsCountQueryHandler getOrderItemsCountQueryHandler, GetOrdersByUserIdQueryHandler getOrdersByUserIdQueryHandler, GetOrderItemByIdQueryHandler getOrderItemByIdQueryHandler, UserManager<AppUser> userManager) : Controller
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

            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var orders = await getOrdersByUserIdQueryHandler.Handle(new GetOrdersByUserIdQuery(user.Id));
            return View(orders);
        }
    }
}
