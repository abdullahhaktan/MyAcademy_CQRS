using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.PromotionQueries;
using MyAcademyCQRS.CQRSPattern.Results.PromotionResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers
{
    public class GetPromotionByIdQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<GetPromotionByIdQueryResult> Handle(GetPromotionByIdQuery getPromotionByIdQuery)
        {
            var promotion = await context.Promotions.FindAsync(getPromotionByIdQuery.Id);
            return mapper.Map<GetPromotionByIdQueryResult>(promotion);
        }
    }
}
