using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.OrderItemCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderItemHandlers
{
    public class RemoveOrderItemCommandHandler(AppDbContext context) : IRequestHandler<RemoveOrderItemCommand>
    {
        public async Task Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await context.OrderItems.FindAsync(request.Id);
            context.OrderItems.Remove(orderItem);
            await context.SaveChangesAsync();
        }
    }
}
