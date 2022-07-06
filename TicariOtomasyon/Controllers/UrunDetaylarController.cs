using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Controllers
{
    public class UrunDetaylarController : Controller
    {
        // GET: UrunDetaylar
        Context db = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.Urunlers.Where(x => x.UrunID == 1).ToList();
            cs.Deger2 = db.Detays.Where(y => y.DetayID == 1).ToList();
            return View(cs);
        }
    }
}