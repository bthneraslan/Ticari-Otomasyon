using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context db = new Context();
        public ActionResult Index(string p)
        {
            var kargolar = from i in db.KargoDetays select i;
            if (!string.IsNullOrEmpty(p))
            {
                kargolar = kargolar.Where(x => x.TakipKodu.Contains(p));
            }
            return View(kargolar.ToList());
        }

        [HttpGet]
        public ActionResult KargoEkle()
        {
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karakterler.Length);
            k2 = rnd.Next(0, karakterler.Length);
            k3 = rnd.Next(0, karakterler.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipkodu = kod;
            return View();
        }

        [HttpPost]
        public ActionResult KargoEkle(KargoDetay d)
        {
            db.KargoDetays.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KargoTakip(string id)
        {
            var dpt = db.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(dpt);
        }
    }
}