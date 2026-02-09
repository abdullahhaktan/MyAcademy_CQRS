using AutoMapper;
using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.OrderItemQueries;
using MyAcademyCQRS.CQRSPattern.Results.OrderItemResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderItemHandlers
{
    public class GetOrderItemByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetOrderItemByIdQuery, GetOrderItemByIdQueryResult>
    {
        public async Task<GetOrderItemByIdQueryResult> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
        {
            var orderItem = await context.OrderItems.FindAsync(request.Id);
            return mapper.Map<GetOrderItemByIdQueryResult>(orderItem);
        }
    }
}
