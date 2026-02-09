using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    public class GetTotalPriceLastMonthChangeHandler(AppDbContext context)
    {
        public async Task<int> Handle()
        {
            var oneMonthAgo = DateTime.UtcNow.AddDays(-30);

            var oneMonthAgoTotalPrice = await context.Orders.Where(o => o.CreatedDate <= oneMonthAgo).SumAsync(o => o.TotalPrice);
            oneMonthAgoTotalPrice = oneMonthAgoTotalPrice <= 0 ? 1 : oneMonthAgoTotalPrice;

            var oneMonthAgoTenDaysAgo = DateTime.UtcNow.AddDays(-40);

            var tenDaysAgoTotalPrice = await context.Orders.Where(o => o.CreatedDate >= oneMonthAgoTenDaysAgo).SumAsync(o => o.TotalPrice);
            tenDaysAgoTotalPrice = tenDaysAgoTotalPrice <= 0 ? 1 : tenDaysAgoTotalPrice;

            var changePercentage = (oneMonthAgoTotalPrice - tenDaysAgoTotalPrice) * 100 / tenDaysAgoTotalPrice;

            return (int)changePercentage;
        }
    }
}
