using AutoMapper;
using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.UserCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.UserHandlers
{
    public class UpdateUserCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<UpdateUserCommand>
    {
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<AppUser>(request);
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }
    }
}
