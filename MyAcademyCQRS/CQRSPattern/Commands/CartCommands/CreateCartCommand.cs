using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.CartCommands;

public record CreateCartCommand(int AppUserId, bool IsDeleted, DateTime CreatedDate) : IRequest;