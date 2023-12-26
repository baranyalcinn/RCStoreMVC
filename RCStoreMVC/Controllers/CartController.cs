using RCStoreMVC.Entity;
using RCStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RCStoreMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext db = new DataContext();
        private static readonly Random random = new Random(); // Random nesnesini bir defa oluştur


        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);

            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);

            if (product != null)
            {
                var cart = GetCart();
                cart.DeleteProduct(product, 1);
            }

            return RedirectToAction("Index");
        }
        public ActionResult ClearCart()
        {
            var cart = GetCart();
            cart.ClearAll(); // Sepeti temizleme metodu

            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails shippingDetails)
        {
            var cart = GetCart();

            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("notExistProductInCart", "Sepetinizde Herhangi Bir Ürün Bulunmamaktadır.");
                return View(shippingDetails);
            }

            if (!ModelState.IsValid)
            {
                return View(shippingDetails);
            }

            SaveOrder(cart, shippingDetails);
            cart.ClearAll();
            return View("Completed");
        }

       

        private void SaveOrder(Cart cart, ShippingDetails shippingDetails)
        {
            var orderNumber = "P" + random.Next(100000, 999999).ToString(); // Random nesnesini tekrar kullan

            var order = new Order
            {
                OrderNumber = orderNumber,
                Total = cart.TotalPrice(),
                OrderDate = DateTime.Now,
                OrderState = EnumOrderState.Bekleniyor,
                UserName = shippingDetails.UserName,
                AdresBasligi = shippingDetails.AdresBasligi,
                Adres = shippingDetails.Adres,
                Sehir = shippingDetails.Sehir,
                Semt = shippingDetails.Semt,
                Mahalle = shippingDetails.Mahalle,
                OrderLines = cart.CartLines.Select(pr => new OrderLine
                {
                    Quantity = pr.Quantity,
                    Total = pr.Quantity * pr.Product.Fiyat,
                    ProductId = pr.Product.Id
                }).ToList()
            };

            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}