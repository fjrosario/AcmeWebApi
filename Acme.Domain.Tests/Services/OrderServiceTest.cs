using Acme.Data.Models;
using Acme.Data.Repositories;
using Acme.Domain.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Domain.Tests.Services
{
    [TestClass]
    public class OrderServiceTest : BaseTestService
    {
        IOrderRepository _repo;

        public OrderServiceTest()
        {
            _repo = new OrderRepository<MockDataContext>(TestDbContextFactory);
        }

        public Order GetNewOrder()
        {
            return new Order
            {
                Status = Data.Types.OrderStatusType.Unknown,
                DueBy = DateTime.Now.AddDays(1),                
                Title = "Order Title"
            };
        }

        [TestMethod]
        public void AddOrder()
        {
            var newOrder = GetNewOrder();
            _repo.AddOrder(newOrder);
            var foundOrder = _repo.GetOrder(newOrder.Id);
            Assert.IsNotNull(foundOrder);
        }

        [TestMethod]
        public void DeleteOrder() 
        {
            var newOrder = GetNewOrder();
            _repo.AddOrder(newOrder);
            int oldId = newOrder.Id;
            var foundOrder = _repo.GetOrder(oldId);
            Assert.IsNotNull(foundOrder);
            _repo.DeleteOrder(foundOrder);
            var orders = _repo.GetOrders();
            Assert.IsNotNull(orders);
            Assert.IsFalse(orders.Any());
        }

        [TestMethod]
        public void UpdateOrder()
        {
            const string newTitle = "New Title";
            var newOrder = GetNewOrder();
            _repo.AddOrder(newOrder);
            string oldTitle = newOrder.Title;
            newOrder.Title = newTitle;
            _repo.UpdateOrder(newOrder);
            var foundOrder = _repo.GetOrder(newOrder.Id);
            Assert.IsNotNull(foundOrder);
            Assert.AreEqual(foundOrder.Title, newTitle);
        }

        [TestMethod]
        public void GetOrder()
        {
            var newOrder = GetNewOrder();
            _repo.AddOrder(newOrder);
            int oldId = newOrder.Id;
            var foundOrder = _repo.GetOrder(oldId);
            Assert.IsNotNull(foundOrder);
        }

        [TestMethod]
        public void GetOrders()
        {

            var order1 = GetNewOrder();
            order1.Title = "Title 1";
            _repo.AddOrder(order1);
            var order2 = GetNewOrder();
            order2.Title = "Title 2";
            _repo.AddOrder(order2);

            var orders = _repo.GetOrders();
            Assert.IsTrue(orders.Any());
            Assert.AreEqual(orders.Count(), 2);


            var orderIds = orders.Select(a => a.Id).ToArray();
            orders = _repo.GetOrders(orderIds).ToArray();
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Any());
            Assert.AreEqual(orderIds.Length, orders.Count());

            orders = _repo.GetOrders(Constants.BadIds);
            Assert.IsNotNull(orders);
            Assert.IsFalse(orders.Any());
        }

    }
}
