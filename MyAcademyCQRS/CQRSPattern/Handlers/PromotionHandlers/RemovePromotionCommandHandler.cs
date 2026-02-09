using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers
{
    public class RemovePromotionCommandHandler(AppDbContext context)
    {
        public async Task Handle(RemovePromotionCommand removePromotionCommand)
        {
            var promotion = await context.Promotions.FindAsync(removePromotionCommand.Id);
            context.Promotions.Remove(promotion);
            await context.SaveChangesAsync();
        }
    }
}
