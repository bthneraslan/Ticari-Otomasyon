using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context db = new Context();
        public ActionResult Index()
        {
            var urunler = db.Urunlers.Count().ToString();
            ViewBag.urn1 = urunler;

            var personel = db.Personels.Count().ToString();
            ViewBag.prs1 = personel;

            var cariler = db.Carilers.Count().ToString();
            ViewBag.cr1 = cariler;

            var ktg1 = db.Kategoris.Count().ToString();
            ViewBag.kt1 = ktg1;


            var yapilacaklar = db.Yapilacaks.ToList();
            return View(yapilacaklar);
        }
    }
}