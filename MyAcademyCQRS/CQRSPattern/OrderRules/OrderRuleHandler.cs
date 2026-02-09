using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.OrderRules
{
    public abstract class OrderRuleHandler
    {
        protected OrderRuleHandler _next;

        public void SetNext(OrderRuleHandler next)
        {
            _next = next;
        }

        public abstract Task HandleAsync(Cart cart);
    }
}
