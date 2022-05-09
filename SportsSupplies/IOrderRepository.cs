using System;
using System.Collections.Generic;
using SportsSupplies.Models;

namespace SportsSupplies
{
    public interface IOrderRepository
    {
        //public double GetTotal();
        public IEnumerable<Order> GetAllProducts();
        public void InsertProducts(Order order);
        //public void DeleteProduct(int id);
        public void DeleteProduct(Product product);
        public void SubmitOrder(Order order);

    }
}
