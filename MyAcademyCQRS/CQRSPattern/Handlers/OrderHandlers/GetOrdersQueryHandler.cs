using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Results.OrderResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    public class GetOrdersQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<List<GetOrdersQueryResult>> Handle()
        {
            var orders = await context.Orders.Include(o => o.User).AsNoTracking().ToListAsync();
            return mapper.Map<List<GetOrdersQueryResult>>(orders);
        }
    }
}