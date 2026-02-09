using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.UserHandlers;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController(GetLastFourOrdersQueryHandler getLastFourOrdersQueryHandler, GetTotalProductCountByCategoryHandler getTotalProductCountByCategoryHandler, GetTotalOrderCountHandler getTotalOrderCount, GetTotalOrderPriceQueryHandler getTotalOrderPriceQueryHandler, GetTotalPriceChangeHandler getTotalPriceChangeHandler, GetTotalPriceLastMonthChangeHandler getTotalPriceLastMonthChangeHandler, GetTotalLastMonthOrderPriceQueryHandler getTotalLastMonthOrderPriceQueryHandler,
      GetTotalUserCountQueryHandler getTotalUserCountQueryHandler, GetTotalUserChangeHandler getTotalUserChangeHandler, GetTotalOrderCountChangeHandler getTotalOrderCountChangeHandler, GetOrdersQueryHandler getOrdersQueryHandler) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var totalPrice = await getTotalOrderPriceQueryHandler.Handle();
            ViewBag.TotalPrice = totalPrice;

            var totalPriceChange = await getTotalPriceChangeHandler.Handle();
            ViewBag.TotalPriceChange = totalPriceChange;

            var totalPriceLastMonth = await getTotalLastMonthOrderPriceQueryHandler.Handle();
            ViewBag.TotalPriceLastMonth = totalPriceLastMonth;

            var totalPriceLastMonthChange = await getTotalPriceLastMonthChangeHandler.Handle();
            ViewBag.TotalPriceLastMonthChange = totalPriceLastMonthChange;

            var totalUserCount = await getTotalUserCountQueryHandler.Handle();
            ViewBag.TotalUserCount = totalUserCount;

            var totalUserChange = await getTotalUserChangeHandler.Handle();
            ViewBag.TotalUserChange = totalUserChange;

            var totalOrderCount = await getTotalOrderCount.Handle();
            ViewBag.TotalOrderCount = totalOrderCount;

            var totalOrderCountChange = await getTotalOrderCountChangeHandler.Handle();
            ViewBag.TotalOrderCountChange = totalOrderCountChange;

            var getTotalProductCountByCategory = await getTotalProductCountByCategoryHandler.Handle();

            List<string> categories = new();
            List<int> productCountByCategory = new();

            foreach (var item in getTotalProductCountByCategory)
            {
                categories.Add(item.Value);
                productCountByCategory.Add(int.Parse(item.Text));
            }

            ViewBag.Categories = categories;
            ViewBag.ProductCounts = productCountByCategory;

            var lastFourOrders = await getLastFourOrdersQueryHandler.Handle();

            return View(lastFourOrders);
        }
    }
}
