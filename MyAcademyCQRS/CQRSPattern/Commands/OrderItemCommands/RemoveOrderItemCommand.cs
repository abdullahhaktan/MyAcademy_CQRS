using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.OrderItemCommands;

public record RemoveOrderItemCommand(int Id) : IRequest;