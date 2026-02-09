using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    public class GetTotalOrderCountChangeHandler(AppDbContext context)
    {
        public async Task<int> Handle()
        {
            var todayTotalOrderCount = await context.Orders.CountAsync();
            todayTotalOrderCount = todayTotalOrderCount <= 0 ? 1 : todayTotalOrderCount;

            var tenDaysAgo = DateTime.UtcNow.AddDays(-10);

            var tenDaysAgoOrderCount = await context.Orders.Where(o => o.CreatedDate <= tenDaysAgo).CountAsync();
            tenDaysAgoOrderCount = tenDaysAgoOrderCount <= 0 ? 1 : tenDaysAgoOrderCount;

            var changePercentage = (todayTotalOrderCount - tenDaysAgoOrderCount) * 100 / tenDaysAgoOrderCount;

            return changePercentage;
        }
    }
}
