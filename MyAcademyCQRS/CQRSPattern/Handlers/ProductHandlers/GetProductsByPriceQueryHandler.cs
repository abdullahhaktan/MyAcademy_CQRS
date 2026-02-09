using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Results.ProductResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
{
    public class GetProductsByPriceQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<List<GetProductsQueryResult>> Handle(int minPrice, int maxPrice)
        {
            var products = await context.Products.Where(p => p.Price <= maxPrice && p.Price >= minPrice).ToListAsync();

            return mapper.Map<List<GetProductsQueryResult>>(products);
        }
    }
}
