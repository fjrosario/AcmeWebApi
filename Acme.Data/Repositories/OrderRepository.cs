using Acme.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Data.Repositories
{
    public class OrderRepository<T> : BaseRepository<T>, IOrderRepository where T : AcmeDataContext
    {
        public OrderRepository(IDbContextFactory<T> dbContextFactory) : base(dbContextFactory)
        {

        }


        public Order? GetOrder(int orderId)
        {
            return Context.Orders.FirstOrDefault(o => o.Id == orderId);
        }

        public void AddOrder(Order order)
        {
            Context.Orders.Add(order);
            Context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            Context.Orders.Update(order);
            Context.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            Context.Orders.Remove(order);
            Context.SaveChanges();
        }

        public IEnumerable<Order> GetOrders()
        {
            return Context.Orders.ToList();
        }

        public IEnumerable<Order> GetOrders(IList<int> orderIds)
        {
            orderIds = orderIds ?? Array.Empty<int>();
            if (!orderIds.Any())
            {
                return Array.Empty<Order>();
            }
            return Context.Orders.Where(o => orderIds.Contains(o.Id)).ToList();
        }
    }
}
