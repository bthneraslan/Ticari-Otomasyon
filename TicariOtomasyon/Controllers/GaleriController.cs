using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        Context db = new Context();
        public ActionResult Index()
        {
            var deger = db.Urunlers.ToList();
            return View(deger);
        }
    }
}