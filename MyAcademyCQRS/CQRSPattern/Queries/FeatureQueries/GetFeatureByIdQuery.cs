using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.FeatureResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.FeatureQueries;

public record GetFeatureByIdQuery(int Id) : IRequest<GetFeatureByIdQueryResult>;