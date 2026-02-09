using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.FeatureCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler(AppDbContext context) : IRequestHandler<RemoveFeatureCommand>
    {
        public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = await context.Features.FindAsync(request.Id);
            context.Features.Remove(feature);
            await context.SaveChangesAsync();
        }
    }
}
