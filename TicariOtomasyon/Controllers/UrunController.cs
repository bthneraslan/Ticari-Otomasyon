using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context db = new Context();
        // GET: Urun
        public ActionResult Index(string p)
        {
            var urunler = from i in db.Urunlers select i;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(x => x.UrunAd.Contains(p));
            }
            return View(urunler.ToList());
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> urunler = (from i in db.Kategoris.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.KategoriAd,
                                                Value = i.KategoriID.ToString()
                                            }).ToList();
            ViewBag.dgr = urunler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urunler u)
        {
           
            db.Urunlers.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urunler2 = db.Urunlers.Find(id);
            urunler2.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult SilinenUrunler()
        {
            var urunler = db.Urunlers.Where(x => x.Durum == false).ToList();
            return View(urunler);
        }

        public ActionResult GeriEkle(int id)
        {
            var urunler3 = db.Urunlers.Find(id);
            urunler3.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> urunler = (from i in db.Kategoris.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.KategoriAd,
                                                Value = i.KategoriID.ToString()
                                            }).ToList();
            ViewBag.dgr = urunler;
            var urun = db.Urunlers.Find(id);
            return View("UrunGetir", urun);


        }

        public ActionResult UrunGuncelle(Urunler k)
        {
            var urun1 = db.Urunlers.Find(k.UrunID);
            urun1.UrunAd = k.UrunAd;
            urun1.Marka = k.Marka;
            urun1.Stok = k.Stok;
            urun1.AlisFiyat = k.AlisFiyat;
            urun1.SatisFiyat = k.SatisFiyat;
            urun1.UrunGorsel = k.UrunGorsel;
            urun1.KategoriID = k.KategoriID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var urunler2 = db.Urunlers.ToList();
            return View(urunler2);
        }

        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> prs1 = (from i in db.Personels.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.PersonelAd + " " + i.PersonelSoyad,
                                               Value = i.PersonelID.ToString()
                                           }).ToList();

            ViewBag.prs1 = prs1;
            var deger1 = db.Urunlers.Find(id);
            ViewBag.dgr1 = deger1.UrunID;

            var deger2 = db.Urunlers.Find(id);
            ViewBag.dgr2 = deger2.SatisFiyat;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SatisHarekets.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index","Satis");
        }
    }
}