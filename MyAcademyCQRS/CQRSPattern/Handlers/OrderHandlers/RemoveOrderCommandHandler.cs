using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.OrderCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    public class RemoveOrderCommandHandler(AppDbContext context)
    {
        public async Task Handle(RemoveOrderCommand removeOrderCommand)
        {
            var order = await context.Orders.FindAsync(removeOrderCommand.Id);
            context.Orders.Remove(order);
            await context.SaveChangesAsync();
        }
    }
}
