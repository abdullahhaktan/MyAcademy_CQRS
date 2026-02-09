using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.BlogCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BlogHandlers
{
    public class CreateBlogCommandHandler(AppDbContext context, IMapper mapper)
    {
        public async Task Handle(CreateBlogCommand createBlogCommand)
        {
            var blog = mapper.Map<Blog>(createBlogCommand);
            await context.AddAsync(blog);
            await context.SaveChangesAsync();
        }
    }
}
