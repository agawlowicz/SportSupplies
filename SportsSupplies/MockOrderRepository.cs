using System;
using System.Collections.Generic;
using SportsSupplies.Models;

namespace SportsSupplies
{
    public class MockOrderRepository : IOrderRepository
    {
        private static readonly Dictionary<Guid, Order> _orders = new Dictionary<Guid, Order>();

        public MockOrderRepository()
        {
        }

        public void CreateOrder(Order order)
        {
            _orders.Add(order.OrderID, order);

        }

        public Order Find(Guid orderID)
        {
            return _orders[orderID];
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orders.Values;
        }

        // To match dictionary with current order
        public void UpdateOrder(Order order)
        {
            _orders[order.OrderID] = order;
        }
    }
}
