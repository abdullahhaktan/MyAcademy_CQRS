namespace MyAcademyCQRS.CQRSPattern.Results.OrderItemResults;

public record GetOrderItemByIdQueryResult(int Id, int? OrderId, int? ProductId, int Quantity, decimal UnitPrice);