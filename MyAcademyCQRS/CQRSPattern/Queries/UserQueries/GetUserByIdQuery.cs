using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.UserResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.UserQueries;

public record GetUserByIdQuery(int Id) : IRequest<GetUserByIdQueryResult>;