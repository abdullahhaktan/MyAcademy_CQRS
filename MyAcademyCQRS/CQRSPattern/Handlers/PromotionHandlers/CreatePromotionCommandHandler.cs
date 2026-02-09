using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers
{
    public class CreatePromotionCommandHandler(AppDbContext context, IMapper mapper)
    {
        public async Task Handle(CreatePromotionCommand createPromotionCommand)
        {
            var promotion = mapper.Map<Promotion>(createPromotionCommand);
            await context.AddAsync(promotion);
            await context.SaveChangesAsync();
        }
    }
}
