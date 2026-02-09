using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Results.PromotionResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers
{
    public class GetPromotionsQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<List<GetPromotionsQueryResult>> Handle()
        {
            var promotions = await context.Promotions.ToListAsync();
            return mapper.Map<List<GetPromotionsQueryResult>>(promotions);
        }
    }
}
