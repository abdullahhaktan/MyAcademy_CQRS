using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.ServiceQueries;
using MyAcademyCQRS.CQRSPattern.Results.ServiceResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ServiceHandlers
{
    public class GetServicesQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetServicesQuery, List<GetServicesQueryResult>>
    {
        public async Task<List<GetServicesQueryResult>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await context.Services.ToListAsync();
            return mapper.Map<List<GetServicesQueryResult>>(services);
        }
    }
}
