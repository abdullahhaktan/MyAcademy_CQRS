using AutoMapper;
using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.BlogCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<UpdateBlogCommand>
    {
        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = mapper.Map<Blog>(request);
            context.Blogs.Update(blog);
            await context.SaveChangesAsync();
        }
    }
}
