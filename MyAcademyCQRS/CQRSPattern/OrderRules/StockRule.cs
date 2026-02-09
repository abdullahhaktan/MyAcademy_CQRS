using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.OrderRules
{
    public class StockRule : OrderRuleHandler
    {
        public override Task HandleAsync(Cart cart)
        {
            foreach (var item in cart.OrderItems)
            {
                if (item.Product.Stock < item.Quantity)
                {
                    throw new Exception(
                        $"Stock not enough for product: {item.Product.Title}"
                    );
                }
            }

            // stoklar uygunsa sıradaki rule'a geç
            return _next?.HandleAsync(cart) ?? Task.CompletedTask;
        }
    }
}
