using AutoMapper;
using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.OrderItemCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderItemHandlers
{
    public class CreateOrderItemCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<CreateOrderItemCommand>
    {
        public async Task Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = mapper.Map<OrderItem>(request);
            await context.OrderItems.AddAsync(orderItem);
            await context.SaveChangesAsync();
        }
    }
}
