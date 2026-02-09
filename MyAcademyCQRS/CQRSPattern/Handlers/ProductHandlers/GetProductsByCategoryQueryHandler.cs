using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.ProductQueries;
using MyAcademyCQRS.CQRSPattern.Results.ProductResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
{
    public class GetProductsByCategoryQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<List<GetProductsQueryResult>> Handle(GetProductByCategoryQuery getProductByCategoryQuery)
        {
            var products = await context.Products.Include(p => p.Category).Where(p => p.CategoryId == getProductByCategoryQuery.Id).ToListAsync();
            return mapper.Map<List<GetProductsQueryResult>>(products);
        }
    }
}
