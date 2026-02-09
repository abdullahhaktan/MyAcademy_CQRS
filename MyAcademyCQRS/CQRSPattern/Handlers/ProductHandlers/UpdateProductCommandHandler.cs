using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler(AppDbContext context, IMapper mapper)
    {
        public async Task Handle(UpdateProductCommand updateProductCommand)
        {
            var product = mapper.Map<Product>(updateProductCommand);
            context.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
