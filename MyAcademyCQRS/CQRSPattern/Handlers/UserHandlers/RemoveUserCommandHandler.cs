using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.UserCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.UserHandlers
{
    public class RemoveUserCommandHandler(AppDbContext context) : IRequestHandler<RemoveUserCommand>
    {
        public async Task Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FindAsync(request.Id);
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }
}
