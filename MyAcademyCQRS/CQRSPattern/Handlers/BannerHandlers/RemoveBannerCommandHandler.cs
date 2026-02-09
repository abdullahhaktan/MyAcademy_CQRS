using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.BannerCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BannerHandlers
{
    public class RemoveBannerCommandHandler(AppDbContext context)
    {
        public async Task Handle(RemoveBannerCommand command)
        {
            var banner = await context.Banners.FindAsync(command.Id);
            context.Banners.Remove(banner);
            await context.SaveChangesAsync();
        }
    }
}
