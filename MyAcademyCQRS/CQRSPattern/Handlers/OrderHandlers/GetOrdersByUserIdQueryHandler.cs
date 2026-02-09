using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.OrderQueries;
using MyAcademyCQRS.CQRSPattern.Results.OrderResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    public class GetOrdersByUserIdQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<List<GetOrdersByUserIdQueryResult>> Handle(GetOrdersByUserIdQuery getOrderByUserIdQuery)
        {
            var order = await context.Orders.Include(o => o.User).Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == getOrderByUserIdQuery.Id).ToListAsync();
            return mapper.Map<List<GetOrdersByUserIdQueryResult>>(order);
        }
    }
}
