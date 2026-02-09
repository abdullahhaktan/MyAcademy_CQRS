using AutoMapper;
using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.OrderItemCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderItemHandlers
{
    public class UpdateOrderItemOrderIdPropertyCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<UpdateOrderItemOrderIdCommand>
    {
        public async Task Handle(UpdateOrderItemOrderIdCommand request, CancellationToken cancellationToken)
        {
            var existingOrderItem = await context.OrderItems.FindAsync(request.Id);

            if (existingOrderItem != null)
            {
                mapper.Map(request, existingOrderItem);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
