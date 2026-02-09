using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Results.ProductResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
{
    public class GetProductsQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<List<GetProductsQueryResult>> Handle()
        {
            var products = await context.Products.Include(p => p.Category).ToListAsync();
            return mapper.Map<List<GetProductsQueryResult>>(products);
        }
    }
}
