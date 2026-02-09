using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.ServiceResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.ServiceQueries;

public record GetServicesQuery : IRequest<List<GetServicesQueryResult>>;