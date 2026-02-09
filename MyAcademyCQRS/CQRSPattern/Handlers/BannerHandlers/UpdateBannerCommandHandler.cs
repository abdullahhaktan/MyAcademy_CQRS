using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.BannerCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler(AppDbContext context, IMapper mapper)
    {
        public async Task Handle(UpdateBannerCommand command)
        {
            var banner = mapper.Map<Banner>(command);
            context.Update(banner);
            await context.SaveChangesAsync();
        }
    }
}
