using System;
using System.Collections.Generic;
using System.Data;
using SportsSupplies.Models;
using Dapper;

namespace SportsSupplies
{
    public class ProductRepository
    {
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE ProductID = @id", new { id = id });
        }

        //public void AddProductToOrder()


        //enter order information into database, update order information in database
    }
}
