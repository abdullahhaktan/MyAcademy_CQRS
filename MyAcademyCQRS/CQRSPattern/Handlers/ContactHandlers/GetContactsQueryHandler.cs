using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.ContactQueries;
using MyAcademyCQRS.CQRSPattern.Results.ContactResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ContactHandlers
{
    public class GetContactsQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetContactsQuery, List<GetContactsQueryResult>>
    {
        public async Task<List<GetContactsQueryResult>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await context.Contacts.ToListAsync();
            return mapper.Map<List<GetContactsQueryResult>>(contacts);
        }
    }
}
