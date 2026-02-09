using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.AdminLogQueries;
using MyAcademyCQRS.CQRSPattern.Results.AdminLogResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.AdminLogHandlers
{
    public class GetAdminLogsQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAdminLogsQuery, List<GetAdminLogsQueryResult>>
    {
        public async Task<List<GetAdminLogsQueryResult>> Handle(GetAdminLogsQuery request, CancellationToken cancellationToken)
        {
            var adminLogs = await context.AdminLogs.AsNoTracking().ToListAsync();
            return mapper.Map<List<GetAdminLogsQueryResult>>(adminLogs);
        }
    }
}
