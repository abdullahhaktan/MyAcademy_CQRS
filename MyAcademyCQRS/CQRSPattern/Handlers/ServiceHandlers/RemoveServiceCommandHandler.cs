using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ServiceCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ServiceHandlers
{
    public class RemoveServiceCommandHandler(AppDbContext context) : IRequestHandler<RemoveServiceCommand>
    {
        public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await context.Services.FindAsync(request.Id);
            context.Services.Remove(service);
            await context.SaveChangesAsync();
        }
    }
}
