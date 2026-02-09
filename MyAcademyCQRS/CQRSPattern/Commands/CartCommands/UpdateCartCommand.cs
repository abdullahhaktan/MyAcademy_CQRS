using MediatR;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Commands.CartCommands;

public record UpdateCartCommand(AppUser AppUser, int AppUserId, DateTime CreatedDate, bool IsDeleted) : IRequest;