using System;
namespace SportsSupplies.Models
{
    //Product Model
    public class Product
    {
        public Product(int productID, string name, double price)
        {
            ProductID = productID;
            Name = name;
            Price = price;
        }

        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
