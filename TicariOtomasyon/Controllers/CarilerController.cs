using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Controllers
{
    public class CarilerController : Controller
    {
        // GET: Cariler
        Context db = new Context();
        public ActionResult Index()
        {
            var cari = db.Carilers.Where(x => x.Durum == true).ToList();
            return View(cari);
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cariler c)
        {
            db.Carilers.Add(c);
            c.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult CariSil(int id)
        {
            var cariler = db.Carilers.Find(id);
            cariler.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SilinenCariler()
        {
            var cariler = db.Carilers.Where(x => x.Durum == false).ToList();
            return View(cariler);
        }

        public ActionResult GeriEkle(int id)
        {
            var cariler2 = db.Carilers.Find(id);
            cariler2.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cari = db.Carilers.Find(id);
            return View("CariGetir", cari);
        }

        public ActionResult CariGuncelle(Cariler c2)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = db.Carilers.Find(c2.CariID);
            cari.CariAd = c2.CariAd;
            cari.CariSoyad = c2.CariSoyad;
            cari.CariMail = c2.CariMail;
            cari.CariSehir = c2.CariSehir;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSatis(int id)
        {
            var cari = db.SatisHarekets.Where(x => x.CariID == id).ToList();
            var cari2 = db.Carilers.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.dgr3 = cari2;
            return View(cari);
        }

        public ActionResult CariListesi(int id)
        {
            var cari3 = db.SatisHarekets.Where(x => x.CariID == id).ToList();
            return View(cari3);
        }
    }
}