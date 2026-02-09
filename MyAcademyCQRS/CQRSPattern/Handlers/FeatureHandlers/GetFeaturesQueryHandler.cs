using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.FeatureQueries;
using MyAcademyCQRS.CQRSPattern.Results.FeatureResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.FeatureHandlers
{
    public class GetFeaturesQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetFeaturesQuery, List<GetFeaturesQueryResult>>
    {
        public async Task<List<GetFeaturesQueryResult>> Handle(GetFeaturesQuery request, CancellationToken cancellationToken)
        {
            var features = await context.Features.AsNoTracking().ToListAsync();
            return mapper.Map<List<GetFeaturesQueryResult>>(features);
        }
    }
}