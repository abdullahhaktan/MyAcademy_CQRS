using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Observers.OrderCreated
{
    public class OnOrderCreatedMailObserver : IOrderCreatedObserver
    {
        public Task OnOrderCreatedAsync(Order order)
        {
            Console.WriteLine($"[MAIL] Mail sent for order {order.Id}");
            return Task.CompletedTask;
        }
    }
}
