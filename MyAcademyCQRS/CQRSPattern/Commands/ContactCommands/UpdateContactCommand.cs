using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.ContactCommands;

public record UpdateContactCommand(int Id, string FullName, string Email, string Phone, string Subject, string Message) : IRequest;