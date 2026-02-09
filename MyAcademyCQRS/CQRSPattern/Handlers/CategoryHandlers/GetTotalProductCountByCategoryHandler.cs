using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers
{
    public class GetTotalProductCountByCategoryHandler(AppDbContext context)
    {
        public async Task<List<SelectListItem>> Handle()
        {
            var productsByCategories = await context.Products.GroupBy(c => c.Category.Name)
               .Select(p => new SelectListItem
               {
                   Text = p.Count().ToString(),
                   Value = p.Key
               })
               .ToListAsync();

            return productsByCategories;
        }
    }
}
