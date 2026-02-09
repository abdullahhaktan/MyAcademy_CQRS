using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Observers.OrderCreated
{
    public class OnOrderCreatedLogObserver : IOrderCreatedObserver
    {
        public Task OnOrderCreatedAsync(Order order)
        {
            Console.WriteLine($"[LOG] Order created: {order.Id}");
            return Task.CompletedTask;
        }

    }
}
