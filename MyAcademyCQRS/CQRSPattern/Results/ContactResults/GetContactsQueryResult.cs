using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Results.ContactResults;

public record GetContactsQueryResult(int Id, string FullName, string Email, string Phone, string Subject, string Message) : IRequest;