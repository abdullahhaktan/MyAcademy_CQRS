using AutoMapper;
using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.OrderItemCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderItemHandlers
{
    public class UpdateOrderItemCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<UpdateOrderItemCommand>
    {
        public async Task Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await context.OrderItems.FindAsync(request.Id);

            if (request != null)
            {
                orderItem.CartId = request.CartId;
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
