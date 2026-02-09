using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.CustomerLogResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.CustomerQueries;

public record GetCustomerLogsQuery : IRequest<List<GetCustomerLogsQueryResult>>;
