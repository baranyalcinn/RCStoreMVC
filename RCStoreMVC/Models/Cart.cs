using RCStoreMVC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCStoreMVC.Models
{
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();
        public List<CartLine> CartLines
        {
            get { return _cartLines; }
        }

        public void AddProduct(Product product, int quantity)
        {
            var line = _cartLines.FirstOrDefault(i => i.Product.Id == product.Id);
            if (line == null)
            {
                _cartLines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void DeleteProduct(Product product, int delQuantity)
        {
            var itemToRemove = _cartLines.Where(i => i.Product.Id == product.Id).FirstOrDefault();

            if (itemToRemove != null)
            {
                // Kullanıcı tarafından istenen miktarı öğeden çıkarın
                itemToRemove.Quantity -= delQuantity;

                // Silme işlemini gerçekleştirmek için kontrol yapın
                if (itemToRemove.Quantity <= 0)
                {
                    _cartLines.Remove(itemToRemove);
                }
            }
        }

        public double TotalPrice()
        {
            return _cartLines.Sum(i => i.Product.Fiyat * i.Quantity);
        }

        public void ClearAll()
        {
            _cartLines.Clear();
        }
    }
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}