using Acme.Data.Models;

namespace Acme.Domain.Services
{
    public interface IOrderService
    {
        void AddOrder(Order order);
        void DeleteOrder(Order order);
        Order? GetOrder(int id);
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrders(IList<int> orderIds);
        void UpdateOrder(Order order);
    }
}