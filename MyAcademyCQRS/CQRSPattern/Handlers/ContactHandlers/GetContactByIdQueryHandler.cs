using AutoMapper;
using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.ContactQueries;
using MyAcademyCQRS.CQRSPattern.Results.ContactResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetContactByIdQuery, GetContactByIdQueryResult>
    {
        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await context.Contacts.FindAsync(request.Id);
            return mapper.Map<GetContactByIdQueryResult>(contact);
        }
    }
}
