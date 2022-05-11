using System;
using System.Collections.Generic;
using SportsSupplies.Models;

namespace SportsSupplies
{
    public class MockProductRepository : IProductRepository
    {
        private static Dictionary<int, Product> _products = new Dictionary<int, Product>();

        public MockProductRepository()
        {
            _products.Add(1234, new Product(1234, "Soccerball", 19.99));
            _products.Add(456, new Product(456, "Basketball", 16.99));
            _products.Add(6789, new Product(6789, "Volleyball", 15.99));
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products.Values;
        }

        public Product Find(int productID)
        {
            return _products[productID];
        }
    }
}
