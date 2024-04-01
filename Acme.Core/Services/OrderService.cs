using Acme.Data.Models;
using Acme.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Domain.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            ArgumentNullException.ThrowIfNull(orderRepository, nameof(orderRepository));
            _orderRepository = orderRepository;
        }
        public void AddOrder(Order order)
        {
            // Add order to database
            _orderRepository.AddOrder(order);
        }

        public void UpdateOrder(Order order)
        {
            // Update order in database
            _orderRepository.UpdateOrder(order);
        }

        public void DeleteOrder(Order order)
        {
            // Delete order from database
            _orderRepository.DeleteOrder(order);
        }

        public Order? GetOrder(int id)
        {
            // Get order from database
            return _orderRepository.GetOrder(id);
        }

        public IEnumerable<Order> GetOrders()
        {
            // Get all orders from database
            return _orderRepository.GetOrders();
        }

        public IEnumerable<Order> GetOrders(IList<int> orderIds)
        {
            // Get all orders from database by ids
            return _orderRepository.GetOrders(orderIds);
        }
    }
}
