using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    public class GetTotalActiveOrderItemCountHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<int> Handle(int Id)
        {
            var orderCount = await context.OrderItems.Where(o => o.Order.Status.ToLower() != "completed" && o.Order.UserId == Id).CountAsync();
            return orderCount;
        }
    }
}
