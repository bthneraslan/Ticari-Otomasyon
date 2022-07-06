using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        Context db = new Context();
        // GET: CariPanel
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var deger = db.Mesajlars.Where(x => x.Alıcı == mail).ToList();
            ViewBag.m = mail;
            var mailid = db.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            ViewBag.mid = mailid;

            var toplamalinan = db.SatisHarekets.Count(x => x.CariID == mailid).ToString();
            ViewBag.tplm = toplamalinan;

            if (Convert.ToInt32(toplamalinan) != 0)
            {
                var toplamsatis = db.SatisHarekets.Where(x => x.CariID == mailid).Sum(y => y.ToplamTutar);
                ViewBag.tplmfiyat = toplamsatis;
            }
            else { ViewBag.tplmfiyat = toplamalinan; }

            if (Convert.ToInt32(toplamalinan) != 0)
            {
                var adet = db.SatisHarekets.Where(x => x.CariID == mailid).Sum(y => y.Adet);
                ViewBag.adet1 = adet;
            }

            else { ViewBag.adet1 = toplamalinan; }

            var adsoyad = db.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.ads = adsoyad;

            var mailw = db.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariMail).FirstOrDefault();
            ViewBag.ma = mailw;

            var seh = db.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariSehir).FirstOrDefault();
            ViewBag.sehir = seh;
            return View(deger);
        }

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = db.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var deger = db.SatisHarekets.Where(x => x.CariID == id).ToList();
            return View(deger);
        }

        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = db.Mesajlars.Where(x => x.Alıcı == mail).OrderByDescending(x => x.MesajID).ToList();

            var gelenmesaj = db.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.gelenmsj = gelenmesaj;
            var gidenmesaj = db.Mesajlars.Count(x => x.Gonderen == mail).ToString();
            ViewBag.gidenmsj = gidenmesaj;
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = db.Mesajlars.Where(x => x.Gonderen == mail).OrderByDescending(x => x.MesajID).ToList();
            var gelenmesaj = db.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.gelenmsj = gelenmesaj;
            var gidenmesaj = db.Mesajlars.Count(x => x.Gonderen == mail).ToString();
            ViewBag.gidenmsj = gidenmesaj;
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var mail = (string)Session["CariMail"];
            var degerler = db.Mesajlars.Where(x => x.MesajID == id).ToList();
            var mesajlar = db.Mesajlars.Where(x => x.Gonderen == mail).ToList();
            var gelenmesaj = db.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.gelenmsj = gelenmesaj;
            var gidenmesaj = db.Mesajlars.Count(x => x.Gonderen == mail).ToString();
            ViewBag.gidenmsj = gidenmesaj;
            return View(degerler);
        }

        public ActionResult MesajDetay2(int id)
        {
            var mail = (string)Session["CariMail"];
            var degerler = db.Mesajlars.Where(x => x.MesajID == id).ToList();
            var mesajlar = db.Mesajlars.Where(x => x.Gonderen == mail).ToList();
            var gelenmesaj = db.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.gelenmsj = gelenmesaj;
            var gidenmesaj = db.Mesajlars.Count(x => x.Gonderen == mail).ToString();
            ViewBag.gidenmsj = gidenmesaj;
            return View(degerler);
        }


        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var gelenmesaj = db.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.gelenmsj = gelenmesaj;
            var gidenmesaj = db.Mesajlars.Count(x => x.Gonderen == mail).ToString();
            ViewBag.gidenmsj = gidenmesaj;

            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderen = mail;
            db.Mesajlars.Add(m);
            db.SaveChanges();
            return View();
        }


        public ActionResult KargoTakip(string p)
        {
            var kargolar = from i in db.KargoDetays select i;
            kargolar = kargolar.Where(x => x.TakipKodu.Contains(p));

            return View(kargolar.ToList());
        }

        public ActionResult KargoTakip2(string id)
        {
            var dpt = db.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(dpt);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CariMail"];
            var id = db.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            var caribul = db.Carilers.Find(id);
            return PartialView("Partial1",caribul);
        }

        public ActionResult CariGuncelle(Cariler k)
        {
            var cari = db.Carilers.Find(k.CariID);
            cari.CariAd = k.CariAd;
            cari.CariSehir = k.CariSehir;
            cari.CariSoyad = k.CariSoyad;
            cari.CariMail = k.CariMail;
            cari.CariSifre = k.CariSifre;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult Partial2()
        {
            var veriler = db.Mesajlars.Where(x => x.Gonderen == "admin").ToList();
            return PartialView(veriler);
        }
    }
}