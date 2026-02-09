using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Observers.OrderCreated
{
    public interface IOrderCreatedObserver
    {
        Task OnOrderCreatedAsync(Order order);
    }
}
