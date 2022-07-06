using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
using PagedList;
using PagedList.Mvc;
namespace TicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        Context db = new Context();
        // GET: Kategori

        public ActionResult Index(int sayfa=1)
        {
            var kategori = db.Kategoris.ToList().ToPagedList(sayfa, 3);
            return View(kategori);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            db.Kategoris.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = db.Kategoris.Find(id);
            db.Kategoris.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori2 = db.Kategoris.Find(id);
            return View("KategoriGetir", kategori2);
        }

        public ActionResult KategoriGuncelle(Kategori k)
        {
            var kategori3 = db.Kategoris.Find(k.KategoriID);
            kategori3.KategoriAd = k.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}