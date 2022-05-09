using System;
using System.Collections.Generic;
using System.Data;
using SportsSupplies.Models;

namespace SportsSupplies
{
    public interface IProductRepository
    {
        // Get all products to display
        public IEnumerable<Product> GetAllProducts();

        // View one product at a time
        public Product GetProduct(int id);

    }
}
