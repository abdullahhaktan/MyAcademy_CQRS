using MyAcademyCQRS.CQRSPattern.Results.CartResults;
using MyAcademyCQRS.CQRSPattern.Results.OrderResults;
using MyAcademyCQRS.CQRSPattern.Results.ProductResults;

namespace MyAcademyCQRS.CQRSPattern.Results.OrderItemResults;

public class GetOrderItemsQueryResult
{
    public int Id { get; set; }

    public GetOrdersQueryResult getOrdersQueryResult { get; set; }
    public int? OrderId { get; set; }

    public GetProductsQueryResult getProductsQueryResult { get; set; }
    public int ProductId { get; set; }

    public GetCartsQueryResult getCartsQueryResult { get; set; }
    public int? CartId { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}