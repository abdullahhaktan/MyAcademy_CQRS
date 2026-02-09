using AutoMapper;
using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ServiceCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<CreateServiceCommand>
    {
        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = mapper.Map<Service>(request);
            await context.Services.AddAsync(service);
            await context.SaveChangesAsync();
        }
    }
}
