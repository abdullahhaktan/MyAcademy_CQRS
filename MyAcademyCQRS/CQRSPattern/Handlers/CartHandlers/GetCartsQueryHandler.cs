using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.CartQueries;
using MyAcademyCQRS.CQRSPattern.Results.CartResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CartHandlers
{
    public class GetCartsQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCartsQuery, List<GetCartsQueryResult>>
    {
        public async Task<List<GetCartsQueryResult>> Handle(GetCartsQuery request, CancellationToken cancellationToken)
        {
            var carts = await context.Carts.Include(c => c.OrderItems).ThenInclude(oi => oi.Product).ToListAsync();
            return mapper.Map<List<GetCartsQueryResult>>(carts);
        }
    }
}
