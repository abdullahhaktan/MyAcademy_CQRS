using AutoMapper;
using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.FeatureCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<CreateFeatureCommand>
    {
        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = mapper.Map<Feature>(request);
            await context.Features.AddAsync(feature);
            await context.SaveChangesAsync();
        }
    }
}
