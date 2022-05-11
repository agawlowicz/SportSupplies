using System;
using System.Collections.Generic;

namespace SportsSupplies.Models
{
    public class Order
    {
        public Order()
        {
            Products = new List<Product>();
            OrderID = Guid.NewGuid();
        }

        public List<Product> Products { get; set; }
        public Guid OrderID { get; set; }
        public double Subtotal { get; set; }
        public double Total { get; set; }
        public Receipt Receipt { get; set; }

        public void Add(Product product)
        {
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

        public void GenerateReceipt()
        {
            Receipt = new Receipt(Products, OrderID);
        }

        //remove product from Products and call subtotal method
        public void Remove(Product product)
        {
            foreach (var p in Products)
            {
                if(product.ProductID == p.ProductID)
                {
                    Products.Remove(product);

                    Subtotal -= product.Price;

                    break;
                }
            }
        }

        public void SubmitOrder()
        {
            GenerateReceipt();
            CalculateTotal();
        }
    }
}
