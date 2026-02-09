using AutoMapper;
using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.FeatureQueries;
using MyAcademyCQRS.CQRSPattern.Results.FeatureResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var feature = await context.Features.FindAsync(request.Id);
            return mapper.Map<GetFeatureByIdQueryResult>(feature);
        }
    }
}