using System;
using System.Collections.Generic;
using SportsSupplies.Models;

namespace SportsSupplies
{
    public interface IOrderRepository
    {
        //public double GetTotal();
        //public void InsertProducts(Order order);
        public IEnumerable<Order> GetAllOrders();
        //public void DeleteProduct(Product product);
        public void UpdateOrder(Order order);
        public Order Find(Guid orderID);
        public void CreateOrder(Order order);

    }
}
