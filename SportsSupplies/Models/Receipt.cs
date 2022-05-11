using System;
using System.Collections.Generic;

namespace SportsSupplies.Models
{
    public class Receipt
    {
        public Receipt(List<Product> products, Guid orderID)
        {
            Products = new List<Product>();
            foreach (Product product in products)
            {
                Products.Add(product);
            }

            OrderID = orderID;
        }

        public List<Product> Products { get; set; }
        public Guid OrderID { get; set; }
    }
}
