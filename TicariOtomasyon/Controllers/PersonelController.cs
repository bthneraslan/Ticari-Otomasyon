using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context db = new Context();
        public ActionResult Index()
        {
            var pers = db.Personels.Where(x => x.Durum == true).ToList();
            return View(pers);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> pers = (from i in db.Departmans.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.DepartmanAd,
                                             Value = i.DepartmanID.ToString()
                                         }).ToList();
            ViewBag.prs1 = pers;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            db.Personels.Add(p);
            p.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var person = db.Personels.Find(id);
            person.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> pers = (from i in db.Departmans.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.DepartmanAd,
                                             Value = i.DepartmanID.ToString()
                                         }).ToList();
            ViewBag.prs = pers;
            var perso = db.Personels.Find(id);
            return View("PersonelGetir", perso);
        }

        public ActionResult PersonelGuncelle(Personel k)
        {
            var pers1 = db.Personels.Find(k.PersonelID);
            pers1.PersonelAd = k.PersonelAd;
            pers1.PersonelSoyad = k.PersonelSoyad;
            pers1.PersonelGorsel = k.PersonelGorsel;
            pers1.DepartmanID = k.DepartmanID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelListe()
        {
            var personel1 = db.Personels.ToList();
            return View(personel1);
        }
    }
}