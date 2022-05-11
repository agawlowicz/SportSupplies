using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using SportsSupplies.Models;

namespace SportsSupplies
{
    public class OrderRepository
    {
        private readonly IDbConnection _conn;

        public OrderRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public void DeleteProduct(Product product)
        {
            _conn.Execute("DELETE FROM orderProducts WHERE ProductID = @id;",
                new { id = product.ProductID });
        }

        public IEnumerable<Order> GetAllProducts()
        {
            return _conn.Query<Order>("SELECT * FROM orderProducts;");
        }

        //public double GetTotal()
        //{
        //    return _conn.Query<Order>("SELECT SUM(Price) FROM orderProducts WHERE OrderID = @id;", new {id = Order.);
        //}

        public void InsertProducts(Order order)
        {
            foreach(var product in order.Products)
            {
                _conn.Execute("INSERT INTO orderProducts (productID, productName, price, orderID) " +
                    "VALUES (@pID, @pName, @price, @orderID);",
                    new { pID = product.ProductID, pName = product.Name, price = product.Price, orderID = order.OrderID });
            }
        }

        public void SubmitOrder(Order order)
        {
            _conn.Execute("INSERT INTO order (orderID, subtotal, total) VALUES (@oID, @subtotal, @total);",
                new { oID = order.OrderID, subtotal = order.Subtotal, total = order.Total });
            
        }
    }
}
