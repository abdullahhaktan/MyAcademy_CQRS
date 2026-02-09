using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.OrderItemCommands;

public record CreateOrderItemCommand(int? OrderId, int? CartId, int? ProductId, int Quantity, decimal UnitPrice) : IRequest;