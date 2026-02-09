using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.CartResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.CartQueries;

public record GetCartsQuery : IRequest<List<GetCartsQueryResult>>;