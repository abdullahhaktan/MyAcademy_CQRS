using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.ContactResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.ContactQueries;

public record GetContactByIdQuery(int Id) : IRequest<GetContactByIdQueryResult>;