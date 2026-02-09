using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.OrderRules
{
    public class CartNotEmptyRule : OrderRuleHandler
    {
        public override Task HandleAsync(Cart cart)
        {
            if (cart == null || cart.OrderItems == null || !cart.OrderItems.Any())
            {
                throw new Exception("Cart is empty");
            }

            return _next?.HandleAsync(cart) ?? Task.CompletedTask;
        }
    }
}
