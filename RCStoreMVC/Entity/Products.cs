using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCStoreMVC.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public double Fiyat { get; set; }
        public bool IsHome { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}