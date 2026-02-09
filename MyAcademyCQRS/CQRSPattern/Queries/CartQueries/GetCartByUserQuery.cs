using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.CartResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.CartQueries;

public record GetCartByUserQuery(int Id) : IRequest<GetCartByUserQueryResult>;