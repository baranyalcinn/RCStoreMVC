
using RCStoreMVC.Entity;
using RCStoreMVC.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace RCStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context = new DataContext();


        // GET: Home
        public List<ProductModel> GetHomePageProducts()
        {
            return _context.Products
                .Where(i => i.IsHome)
                .Select(i => new ProductModel
                {
                    Id = i.Id,
                    Fiyat = i.Fiyat,
                    Marka = i.Marka,
                    CategoryId = i.CategoryId,
                    Image = i.Image
                })
                .AsNoTracking()
                .ToList();
        }

        public ActionResult Index()
        {
            var urunler = GetHomePageProducts();
            return View(urunler);
        }


        public ActionResult Privacy()
        {
            var links = _context.Links
                   .OrderBy(i => i.Id)
                   .Select(i => new LinksModel()
                   {
                       Id = i.Id,
                       Url = i.Url
                   })
                   .AsEnumerable();

            return View(links);
        }
        public ActionResult Details(int id)
        {
            return View(_context.Products.FirstOrDefault(i => i.Id == id));
        }

        public IQueryable<ProductModel> GetProductQuery(int? id)
        {
            var urunlerQuery = _context.Products
                .AsNoTracking()
                .Where(i => !id.HasValue || i.CategoryId == id)
                .Select(i => new ProductModel
                {
                    Id = i.Id,
                    Fiyat = i.Fiyat,
                    Marka = i.Marka,
                    CategoryId = i.CategoryId,
                    Image = i.Image
                });

            return urunlerQuery;
        }

        public ActionResult List(int? id)
        {
            // Eğer id değeri null ise, tüm ürünleri getirecek bir sorgu yapısı oluştur
            var urunlerQuery = id.HasValue ? GetProductQuery(id.Value) : GetProductQuery(null);

            // Veritabanına giderek sorguyu çalıştır ve verileri çek
            var urunler = urunlerQuery.AsNoTracking()
                .ToList();

            return View(urunler);
        }



        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
        }
    }
}