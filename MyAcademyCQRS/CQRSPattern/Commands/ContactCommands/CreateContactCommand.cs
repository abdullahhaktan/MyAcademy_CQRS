using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.ContactCommands;

public record CreateContactCommand(string FullName, string Email, string Phone, string Subject, string Message) : IRequest;