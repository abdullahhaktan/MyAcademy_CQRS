using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler(AppDbContext context)
    {
        public async Task Handle(RemoveProductCommand removeProductCommand)
        {
            var product = await context.Products.FindAsync(removeProductCommand.Id);
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}
