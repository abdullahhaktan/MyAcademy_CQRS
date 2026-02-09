using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.ContactCommands;

public record RemoveContactCommand(int Id) : IRequest;