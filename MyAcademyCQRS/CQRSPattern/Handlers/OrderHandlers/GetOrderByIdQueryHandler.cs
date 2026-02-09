using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.OrderQueries;
using MyAcademyCQRS.CQRSPattern.Results.OrderResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    public class GetOrderByIdQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery getOrderByIdQuery)
        {
            var order = await context.Orders.Include(o => o.User).Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == getOrderByIdQuery.Id);
            return mapper.Map<GetOrderByIdQueryResult>(order);
        }
    }
}
