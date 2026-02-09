using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.CartQueries;
using MyAcademyCQRS.CQRSPattern.Results.CartResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CartHandlers
{
    public class GetCartByUserQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<
        GetCartByUserQuery, GetCartByUserQueryResult>
    {
        public async Task<GetCartByUserQueryResult> Handle(GetCartByUserQuery request, CancellationToken cancellationToken)
        {
            var cart = await context.Carts.Include(c => c.OrderItems).ThenInclude(oi => oi.Product).Where(c => c.AppUserId == request.Id).FirstOrDefaultAsync();
            return mapper.Map<GetCartByUserQueryResult>(cart);
        }
    }
}
