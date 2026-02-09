using AutoMapper;
using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ServiceCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<UpdateServiceCommand>
    {
        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = mapper.Map<Service>(request);
            context.Services.Update(service);
            await context.SaveChangesAsync();
        }
    }
}
