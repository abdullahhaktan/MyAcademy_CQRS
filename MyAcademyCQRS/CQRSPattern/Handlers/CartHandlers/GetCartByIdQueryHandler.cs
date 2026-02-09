using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.CartQueries;
using MyAcademyCQRS.CQRSPattern.Results.CartResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CartHandlers
{
    public class GetCartByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCartByIdQuery, GetCartByIdQueryResult>
    {
        public async Task<GetCartByIdQueryResult> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            var cart = await context.Carts.Include(c => c.OrderItems).ThenInclude(oi => oi.Product).Where(c => c.Id == request.Id).FirstOrDefaultAsync();
            return mapper.Map<GetCartByIdQueryResult>(cart);
        }
    }
}
