using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Results.OrderResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    public class GetLastOrdersByUserQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<List<GetOrdersQueryResult>> Handle(int id)
        {
            var orders = await context.Orders.Include(o => o.User).Where(o => o.UserId == id).AsNoTracking().Take(5).ToListAsync();
            return mapper.Map<List<GetOrdersQueryResult>>(orders);
        }
    }
}
