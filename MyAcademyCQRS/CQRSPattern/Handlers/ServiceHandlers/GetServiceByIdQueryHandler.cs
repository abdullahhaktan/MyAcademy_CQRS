using AutoMapper;
using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.ServiceQueries;
using MyAcademyCQRS.CQRSPattern.Results.ServiceResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var service = await context.Services.FindAsync(request.Id);
            return mapper.Map<GetServiceByIdQueryResult>(service);
        }
    }
}
