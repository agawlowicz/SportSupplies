using System;
using System.Collections.Generic;

namespace SportsSupplies.Models
{
    public class Order
    {
        public List<Product> Products { get; set; }
        public Guid OrderID { get; set; }
        public double Subtotal { get; set; }
        public double Total { get; set; }

        //generate new ID number and add product to list of order products
        //Set property OrderID and update Products property then call subtotal method
        public void Add(Product product)
        {
            if (Products.Count == 0)
            {
                OrderID = Guid.NewGuid();
            }
            Products.Add(product);
            CalculateSubtotal();
        }

        //update subtotal after each addition to Products
        public void CalculateSubtotal()
        {
            double subtotal = 0;
            foreach (var product in Products)
            {
                subtotal += product.Price;
            }

            Subtotal = subtotal;
            
        }

        //remove product from Products and call subtotal method
        public void Remove(Product product)
        {
            Products.Remove(product);
            CalculateSubtotal();
        }

        //calculate total
        public void CalculateTotal()
        {
            double total = 0;
            foreach (var product in Products)
            {
                total += product.Price;
            }
            // 9 percent tax
            Total = total * 1.09;
        }

        //public void SubmitOrder()
        //{

        //}


        //public IEnumerable<Order> GenerateReciept()

        //generate reciept method
        //set var total = Subtotal
        //Total = total
        //public IEnumerable<Product>

        // submit method, add all products and calculate total

        //AddToCart method
        //in model class, add button
    }
}
