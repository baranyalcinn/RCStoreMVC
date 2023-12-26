using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RCStoreMVC.Entity
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(maximumLength:20, ErrorMessage ="En fazla 20 karakter.")]

        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}