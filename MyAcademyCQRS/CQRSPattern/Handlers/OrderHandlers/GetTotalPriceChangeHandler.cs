using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    public class GetTotalPriceChangeHandler(AppDbContext context)
    {
        public async Task<int> Handle()
        {
            var todayTotalPrice = await context.Orders.SumAsync(o => o.TotalPrice);
            todayTotalPrice = todayTotalPrice <= 0 ? 1 : todayTotalPrice;

            var tenDaysAgo = DateTime.UtcNow.AddDays(-10);

            var tenDaysAgoTotalPrice = await context.Orders.Where(o => o.CreatedDate <= tenDaysAgo).SumAsync(o => o.TotalPrice);
            tenDaysAgoTotalPrice = tenDaysAgoTotalPrice <= 0 ? 1 : tenDaysAgoTotalPrice;

            var changePercentage = (todayTotalPrice - tenDaysAgoTotalPrice) * 100 / tenDaysAgoTotalPrice;

            return (int)changePercentage;
        }
    }
}
