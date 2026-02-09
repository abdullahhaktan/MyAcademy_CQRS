using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.CustomerQueries;
using MyAcademyCQRS.CQRSPattern.Results.CustomerLogResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CustomerLogHandlers
{
    public class GetCustomerLogsQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCustomerLogsQuery, List<GetCustomerLogsQueryResult>>
    {
        public async Task<List<GetCustomerLogsQueryResult>> Handle(GetCustomerLogsQuery request, CancellationToken cancellationToken)
        {
            var customerLogs = await context.CustomerLogs.AsNoTracking().ToListAsync();
            return mapper.Map<List<GetCustomerLogsQueryResult>>(customerLogs);
        }
    }
}
