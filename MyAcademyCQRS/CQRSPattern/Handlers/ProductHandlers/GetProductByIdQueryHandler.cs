using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.ProductQueries;
using MyAcademyCQRS.CQRSPattern.Results.ProductResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery getProductByIdQuery)
        {
            var product = await context.Products.FindAsync(getProductByIdQuery.Id);
            return mapper.Map<GetProductByIdQueryResult>(product);
        }
    }
}
