using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.BannerCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler(AppDbContext context, IMapper mapper)
    {
        public async Task Handle(CreateBannerCommand command)
        {
            var banner = mapper.Map<Banner>(command);
            await context.AddAsync(banner);
            await context.SaveChangesAsync();
        }
    }
}