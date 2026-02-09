using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers
{
    public class UpdatePromotionCommandHandler(AppDbContext context, IMapper mapper)
    {
        public async Task Handle(UpdatePromotionCommand updatePromotionCommand)
        {
            var promotion = mapper.Map<Promotion>(updatePromotionCommand);
            context.Update(promotion);
            await context.SaveChangesAsync();
        }
    }
}
