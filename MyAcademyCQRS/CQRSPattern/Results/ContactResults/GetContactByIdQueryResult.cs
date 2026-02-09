using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Results.ContactResults;

public record GetContactByIdQueryResult(int Id, string FullName, string Email, string Phone, string Subject, string Message) : IRequest;