using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;
using MyAcademyCQRS.CQRSPattern.UnitOfWorks;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler(AppDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        public async Task Handle(CreateProductCommand createProductCommand)
        {
            var product = mapper.Map<Product>(createProductCommand);
            await context.AddAsync(product);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
