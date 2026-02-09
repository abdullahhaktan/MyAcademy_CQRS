using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    public class GetTotalLastMonthOrderPriceQueryHandler(AppDbContext context)
    {
        public async Task<int> Handle()
        {
            var oneMonthAgo = DateTime.UtcNow.AddDays(-30);
            var orders = await context.Orders.Where(o => o.CreatedDate >= oneMonthAgo).SumAsync(o => o.TotalPrice);
            return (int)orders;
        }
    }
}
