using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.AdminLogResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.AdminLogQueries;

public record GetAdminLogsQuery : IRequest<List<GetAdminLogsQueryResult>>;