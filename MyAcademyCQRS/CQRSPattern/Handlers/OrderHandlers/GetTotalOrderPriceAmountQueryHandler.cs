using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    public class GetTotalOrderPriceAmountQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<int> Handle(int Id)
        {
            int totalPrice = (int)await context.OrderItems.Where(oi => oi.Order.UserId == Id).SumAsync(oi => oi.UnitPrice);
            return totalPrice;
        }
    }
}
