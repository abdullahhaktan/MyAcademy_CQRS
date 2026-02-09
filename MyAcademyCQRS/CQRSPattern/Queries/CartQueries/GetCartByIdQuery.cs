using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.CartResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.CartQueries;

public record GetCartByIdQuery(int Id) : IRequest<GetCartByIdQueryResult>;