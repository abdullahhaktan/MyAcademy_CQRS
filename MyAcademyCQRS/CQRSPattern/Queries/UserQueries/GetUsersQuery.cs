using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.UserResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.UserQueries;

public record GetUsersQuery : IRequest<List<GetUsersQueryResult>>;