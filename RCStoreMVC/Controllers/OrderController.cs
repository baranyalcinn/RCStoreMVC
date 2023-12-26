using RCStoreMVC.Entity;
using RCStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RCStoreMVC.Controllers
{
    [Authorize(Roles ="admin")]
    public class OrderController : Controller
    {
        private readonly DataContext db = new DataContext();
        private readonly List<Order> orders;

        
        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrderModel() 
            {
                Id= i.Id,
                OrderNumber= i.OrderNumber,
                OrderDate=i.OrderDate,
                OrderState=i.OrderState,
                Total=i.Total


            }).OrderByDescending(i => i.OrderDate);


            return View(orders);
        }
        public ActionResult ConfirmOrder(int orderId)
        {
            var order = db.Orders.FirstOrDefault(p => p.Id == orderId);
            if (order != null)
            {
                order.OrderState = EnumOrderState.Tamamlandı; // Onaylandı olarak işaretle
                db.SaveChanges();
                // Gerekli mesajları göster veya yönlendirme yap
            }
            // Hata durumları için işlemler eklenebilir
            return RedirectToAction("Index", "Order"); // Sipariş listesine geri dön
        }

        public ActionResult CancelOrder(int orderId)
        {
            var order = db.Orders.FirstOrDefault(p => p.Id == orderId);
            if (order != null)
            {
                order.OrderState = EnumOrderState.İptal; // İptal edildi olarak işaretle
                db.SaveChanges();
                // Gerekli mesajları göster veya yönlendirme yap
            }
            // Hata durumları için işlemler eklenebilir
            return RedirectToAction("Index", "Order"); // Sipariş listesine geri dön
        }

       
    }

}