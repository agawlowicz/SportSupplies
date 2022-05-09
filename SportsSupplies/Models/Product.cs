using System;
namespace SportsSupplies.Models
{
    //Product Model
    public class Product
    {
        public Product()
        {
        }

        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public string Image { get; set; }
    }
}
