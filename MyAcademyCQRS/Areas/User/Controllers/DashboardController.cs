using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.OrderItemHandlers;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Areas.User.Controllers
{
    [Area("User")]
    public class DashboardController(GetTotalOrderPriceAmountQueryHandler getTotalOrderPriceAmountQueryHandler, GetLastOrdersByUserQueryHandler getLastOrdersByUserQueryHandler, GetTotalActiveOrderCountHandler getTotalActiveOrderCountHandler, GetTotalActiveOrderItemCountHandler getTotalActiveOrderItemCountHandler, UserManager<AppUser> userManager, GetOrderItemsCountQueryHandler getOrderItemsCountQueryHandler) : Controller
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
            ViewBag.fullName = user.FirstName + " " + user.LastName;

            var totalActiveOrderCount = await getTotalActiveOrderCountHandler.Handle(user.Id);
            ViewBag.totalActiveOrderCount = totalActiveOrderCount;

            var totalActiveOrderItemCount = await getTotalActiveOrderItemCountHandler.Handle(user.Id);
            ViewBag.totalActiveOrderItemCount = totalActiveOrderItemCount;

            var totalPriceAmount = await getTotalOrderPriceAmountQueryHandler.Handle(user.Id);
            ViewBag.totalPriceAmount = totalPriceAmount;

            var lastOrders = await getLastOrdersByUserQueryHandler.Handle(user.Id);

            return View(lastOrders);
        }
    }
}
