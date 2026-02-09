using AutoMapper;
using MediatR;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.UserQueries;
using MyAcademyCQRS.CQRSPattern.Results.UserResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.UserHandlers
{
    public class GetUserByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FindAsync(request.Id);
            return mapper.Map<GetUserByIdQueryResult>(user);
        }
    }
}