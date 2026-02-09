using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.OrderCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    public class UpdateOrderCommandHandler(AppDbContext context, IMapper mapper)
    {
        public async Task Handle(UpdateOrderCommand updateOrderCommand)
        {
            var order = mapper.Map<Order>(updateOrderCommand);
            context.Orders.Update(order);
            await context.SaveChangesAsync();
        }
    }
}
