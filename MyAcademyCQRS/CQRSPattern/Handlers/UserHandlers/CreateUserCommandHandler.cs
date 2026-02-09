using AutoMapper;
using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.UserCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.UserHandlers
{
    public class CreateUserCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<CreateUserCommand>
    {
        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<AppUser>(request);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }
}
