using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis

        Context db = new Context();
        public ActionResult Index()
        {
            var satis = db.SatisHarekets.ToList();
            return View(satis);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> satis1 = (from i in db.Carilers.Where(x=>x.Durum==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CariAd + " " + i.CariSoyad,
                                               Value = i.CariID.ToString()
                                           }).ToList();

            List<SelectListItem> satis2 = (from i in db.Personels.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.PersonelAd + " " + i.PersonelSoyad,
                                               Value = i.PersonelID.ToString()
                                           }).ToList();

            List<SelectListItem> satis3 = (from i in db.Urunlers.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.UrunAd,
                                               Value = i.UrunID.ToString()
                                           }).ToList();
            ViewBag.sts1 = satis1;
            ViewBag.sts2 = satis2;
            ViewBag.sts3 = satis3;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SatisHarekets.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> satis4 = (from i in db.Urunlers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.UrunAd,
                                               Value = i.UrunID.ToString()
                                           }).ToList();
            List<SelectListItem> satis5 = (from i in db.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CariAd+ " " + i.CariSoyad ,
                                               Value = i.CariID.ToString()
                                           }).ToList();
            List<SelectListItem> satis6 = (from i in db.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.PersonelAd + " " + i.PersonelSoyad,
                                               Value = i.PersonelID.ToString()
                                           }).ToList();
            ViewBag.sts4 = satis4;
            ViewBag.sts5 = satis5;
            ViewBag.sts6 = satis6;
            var satis = db.SatisHarekets.Find(id);
            return View("SatisGetir", satis);
        }

        public ActionResult SatisGuncelle(SatisHareket k)
        {
            var satis1 = db.SatisHarekets.Find(k.SatisID);
            satis1.Tarih = k.Tarih;
            satis1.Fiyat = k.Fiyat;
            satis1.ToplamTutar = k.ToplamTutar;
            satis1.CariID = k.CariID;
            satis1.PersonelID = k.PersonelID;
            satis1.UrunID = k.UrunID;
            satis1.Adet = k.Adet;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var deger = db.SatisHarekets.Where(x => x.SatisID == id).ToList();
            return View(deger);
        }
    }
}