using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    public class GetTotalOrderPriceQueryHandler(AppDbContext context)
    {
        public async Task<int> Handle()
        {
            var orders = await context.Orders.SumAsync(o => o.TotalPrice);
            return (int)orders;
        }
    }
}
