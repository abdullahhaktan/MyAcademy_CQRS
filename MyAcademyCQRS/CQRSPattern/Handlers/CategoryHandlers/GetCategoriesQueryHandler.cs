using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Results.CategoryResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers
{
    public class GetCategoriesQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<List<GetCategoriesQueryResult>> Handle()
        {
            var categories = await context.Categories.ToListAsync();
            return mapper.Map<List<GetCategoriesQueryResult>>(categories);
        }
    }
}
