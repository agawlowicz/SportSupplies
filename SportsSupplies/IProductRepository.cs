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

        public Product Find(int productID);

    }
}
