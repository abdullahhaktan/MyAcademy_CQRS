using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.CartCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CartHandlers
{
    public class RemoveCartCommandHandler(AppDbContext context) : IRequestHandler<RemoveCartCommand>
    {
        public async Task Handle(RemoveCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await context.Carts.FindAsync(request.Id);
            cart.IsDeleted = true;
            await context.SaveChangesAsync();
        }
    }
}
