using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.FeatureResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.FeatureQueries;

public record GetFeaturesQuery : IRequest<List<GetFeaturesQueryResult>>;