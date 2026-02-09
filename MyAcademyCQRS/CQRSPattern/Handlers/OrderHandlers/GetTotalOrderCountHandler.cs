using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    public class GetTotalOrderCountHandler(AppDbContext context)
    {
        public async Task<int> Handle()
        {
            var count = await context.Orders.CountAsync();
            return count;
        }
    }
}
