using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.BlogCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BlogHandlers
{
    public class RemoveBlogCommandHandler(AppDbContext context) : IRequestHandler<RemoveBlogCommand>
    {
        public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await context.Blogs.FindAsync(request.Id);
            context.Blogs.Remove(blog);
            await context.SaveChangesAsync();
        }
    }
}
