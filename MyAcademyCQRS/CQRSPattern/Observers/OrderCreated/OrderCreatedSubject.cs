using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Observers.OrderCreated
{
    public class OrderCreatedSubject
    {
        private readonly List<IOrderCreatedObserver> _observers = new();

        public async Task Register(IOrderCreatedObserver observer)
        {
            _observers.Add(observer);
        }

        public async Task NotifyAsync(Order order)
        {
            foreach (var observer in _observers)
            {
                await observer.OnOrderCreatedAsync(order);
            }
        }

    }
}
