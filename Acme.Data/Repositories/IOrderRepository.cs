using Acme.Data.Models;

namespace Acme.Data.Repositories
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        void DeleteOrder(Order order);
        Order? GetOrder(int orderId);
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrders(IList<int> orderIds);
        void UpdateOrder(Order order);
    }
}