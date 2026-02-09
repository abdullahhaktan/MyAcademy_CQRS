using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.ContactResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.ContactQueries;

public record GetContactsQuery : IRequest<List<GetContactsQueryResult>>;