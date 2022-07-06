using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Controllers
{
    [Authorize(Roles = "AA")]
    public class DepartmanController : Controller
    {
        
        Context db = new Context();
        // GET: Departman
        public ActionResult Index()
        {
            var departman = db.Departmans.Where(x=>x.Durum==true).ToList();
            return View(departman);
        }
        
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            db.Departmans.Add(d);
            d.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var departman = db.Departmans.Find(id);
            departman.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var departman = db.Departmans.Find(id);
            return View("DepartmanGetir", departman);
        }

        public ActionResult DepartmanGuncelle(Departman d)
        {
            var dep = db.Departmans.Find(d.DepartmanID);
            dep.DepartmanAd = d.DepartmanAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var dpt = db.Personels.Where(x => x.DepartmanID == id).ToList();
            var depart = db.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.dgr = depart;
            return View(dpt);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var deger = db.SatisHarekets.Where(x => x.PersonelID == id).ToList();
            var ad = db.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dgr2 = ad;
            return View(deger);
        }

        public ActionResult PersonelListesi(int id)
        {
            var cari4 = db.SatisHarekets.Where(x => x.PersonelID == id).ToList();
            return View(cari4);
        }
    }
}