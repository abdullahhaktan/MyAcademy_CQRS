using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.OrderItemQueries;
using MyAcademyCQRS.CQRSPattern.Results.OrderItemResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderItemHandlers
{
    public class GetOrderItemsQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetOrderItemsQuery, List<GetOrderItemsQueryResult>>
    {
        public async Task<List<GetOrderItemsQueryResult>> Handle(GetOrderItemsQuery request, CancellationToken cancellationToken)
        {
            var orderItems = await context.OrderItems.AsNoTracking().ToListAsync();
            return mapper.Map<List<GetOrderItemsQueryResult>>(orderItems);
        }
    }
}
