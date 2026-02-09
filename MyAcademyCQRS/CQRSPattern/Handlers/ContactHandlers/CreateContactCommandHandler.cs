using AutoMapper;
using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ContactCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<CreateContactCommand>
    {
        public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = mapper.Map<Contact>(request);
            await context.Contacts.AddAsync(contact);
            await context.SaveChangesAsync();
        }
    }
}
