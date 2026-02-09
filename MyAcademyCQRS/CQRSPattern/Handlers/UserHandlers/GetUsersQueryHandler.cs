using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.UserQueries;
using MyAcademyCQRS.CQRSPattern.Results.UserResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.UserHandlers
{
    public class GetUsersQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetUsersQuery, List<GetUsersQueryResult>>
    {
        public async Task<List<GetUsersQueryResult>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await context.Users.ToListAsync();
            return mapper.Map<List<GetUsersQueryResult>>(users);
        }
    }
}
