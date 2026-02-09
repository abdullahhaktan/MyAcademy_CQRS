using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    public class GetOrderByUserIdQueryHandler(AppDbContext context)
    {
        public async Task<int> Handle(int id)
        {
            var order = await context.Orders.Include(o => o.User).Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.UserId == id);
            return order.Id;
        }
    }
}