using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.OrderItemCommands;

public record UpdateOrderItemCommand(int Id, int? OrderId, int? CartId, int? ProductId, int Quantity, decimal UnitPrice) : IRequest;