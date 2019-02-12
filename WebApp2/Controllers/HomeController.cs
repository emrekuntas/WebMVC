using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Home
        public ActionResult Index()
        {
            var cat = from u in db.Categories select u;
            if (cat!=null)
            {
                ViewBag.Category = cat;
            }
            return View();
        }
        public ActionResult FormTest(string UrunAdi, string Fiyat, string kategori) {

            Products p = new Products();
            p.ProductName = UrunAdi;
            p.UnitPrice = Convert.ToDecimal(Fiyat);
            p.CategoryID = Convert.ToInt32(kategori);

            db.Products.Add(p);
            db.SaveChanges();
            var pro = from pp in db.Products select pp;

            return View(pro.ToList());
        }
    }
}