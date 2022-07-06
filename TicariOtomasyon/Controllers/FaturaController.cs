using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context db = new Context();
        public ActionResult Index()
        {
            var fatura = db.Faturalars.ToList();
            return View(fatura);
        }
        
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            db.Faturalars.Add(f);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var fat = db.Faturalars.Find(id);
            return View("FaturaGetir", fat);
        }

        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fatura = db.Faturalars.Find(f.FaturaID);
            fatura.FaturSeriNo = f.FaturSeriNo;
            fatura.FaturSıraNo = f.FaturSıraNo;
            fatura.Tarih = f.Tarih;
            fatura.Saat = f.Saat;
            fatura.VergiDairesi = f.VergiDairesi;
            fatura.TeslimAlan = f.TeslimAlan;
            fatura.TeslimEden = f.TeslimEden;
            fatura.Toplam = f.Toplam;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturDetay(int id)
        {
            var dpt = db.FaturaKalems.Where(x => x.FaturaID == id).ToList();
            return View(dpt);
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {

            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            db.FaturaKalems.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Dinamik()
        {
            Class3 cs = new Class3();
            cs.deger2 = db.FaturaKalems.ToList();
            cs.deger1 = db.Faturalars.ToList();
            return View(cs);
        }
        
        public ActionResult Dinamik2()
        {
            Class3 cs = new Class3();
            cs.deger1 = db.Faturalars.ToList();
            cs.deger2 = db.FaturaKalems.ToList();
            return View(cs);
        }

       
    }
}