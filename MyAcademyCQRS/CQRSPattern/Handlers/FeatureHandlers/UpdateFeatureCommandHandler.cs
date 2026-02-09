using AutoMapper;
using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.FeatureCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<UpdateFeatureCommand>
    {
        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = mapper.Map<Feature>(request);
            context.Features.Update(feature);
            await context.SaveChangesAsync();
        }
    }
}
