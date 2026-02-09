using AutoMapper;
using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.CartCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CartHandlers
{
    public class CreateCartCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<CreateCartCommand>
    {
        public async Task Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = mapper.Map<Cart>(request);
            await context.Carts.AddAsync(cart);
            await context.SaveChangesAsync();
        }
    }
}