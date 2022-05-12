using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsSupplies.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsSupplies.Controllers
{
    [Route("{controller}")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository repo;
        private readonly IProductRepository repo2;

        public OrderController(IOrderRepository repo, IProductRepository repo2)
        {
            this.repo = repo;
            this.repo2 = repo2;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var order = new Order();
            repo.CreateOrder(order);

            return Redirect($"order/{order.OrderID}");

        }

        [Route("{OrderID}")]
        public IActionResult Index(Guid orderID)
        {
            var order = repo.Find(orderID);
            ViewBag.Products = repo2.GetAllProducts();

            return View(order);
        }

        [HttpPost]
        public IActionResult AddProduct(Order orderFromForm, int productID)
        {
            var order = repo.Find(orderFromForm.OrderID);
            var product = repo2.Find(productID);

            order.Add(product);
            repo.UpdateOrder(order);

            return Redirect($"order/{order.OrderID}");

        }

        [HttpPost]
        [Route("GenerateReceipt")]
        public IActionResult GenerateReceipt(Order orderFromForm)
        {
            var order = repo.Find(orderFromForm.OrderID);
            order.SubmitOrder();
            repo.UpdateOrder(order);

            return Redirect($"{order.OrderID}/receipt");

        }

        [Route("{OrderID}/Receipt")]
        public IActionResult Receipt(Guid orderID)
        {
            var order = repo.Find(orderID);

            return View(order);
        }

        [HttpPost]
        [Route("RemoveFromCart")]
        public IActionResult RemoveFromCart(Order orderFromForm, int productID)
        {
            var order = repo.Find(orderFromForm.OrderID);
            order.Remove(productID);
            repo.UpdateOrder(order);

            return Redirect($"{order.OrderID}");
        }
    }
}