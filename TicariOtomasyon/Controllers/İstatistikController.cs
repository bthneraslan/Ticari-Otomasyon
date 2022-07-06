using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        Context db = new Context();
        public ActionResult Index()
        {
            var deger1 = db.Carilers.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = db.Urunlers.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = db.Personels.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = db.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = db.Urunlers.Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;

            var deger6 = (from i in db.Urunlers select i.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;

            var deger7 = db.Urunlers.Count(x => x.Stok <= 20).ToString();
            ViewBag.d7 = deger7;

            var deger8 = (from i in db.Urunlers orderby i.SatisFiyat descending select i.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;

            var deger9 = (from i in db.Urunlers orderby i.SatisFiyat ascending select i.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;

            var deger10 = db.Urunlers.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;

            var deger11 = db.Urunlers.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d11 = deger11;

            var deger12 = db.Urunlers.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;

            var deger13 = db.Urunlers.Where(u => u.UrunID == (db.SatisHarekets.GroupBy(x => x.UrunID)
            .OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = db.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;

            var deger15 = db.SatisHarekets.Count(x => x.Tarih == DateTime.Today).ToString();
            ViewBag.d15 = deger15;


            if (Convert.ToInt32(deger15) != 0)

            {

                var deger16 = db.SatisHarekets.Where(x => x.Tarih == DateTime.Today).Sum(y => y.ToplamTutar).ToString();

                ViewBag.d16 = deger16;

            }

            else { ViewBag.d16 = deger15; }
            return View();
        }

        public ActionResult KolayTablolar()
        {
            var sorgu = from x in db.Carilers
                        group x by x.CariSehir into g
                        select new sinifgrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }

        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in db.Personels
                         group x by x.Departman.DepartmanAd into g
                         select new sinifgrup2
                         {
                             departman = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial2()
        {
            var sorgu3 = db.Carilers.ToList();
            return PartialView(sorgu3);
        }

        public PartialViewResult Partial3()
        {
            var sorgu4 = db.Urunlers.ToList();
            return PartialView(sorgu4);
        }

        public PartialViewResult Partial4()
        {
            var sorgu4 = from x in db.Urunlers
                         group x by x.Marka into g
                         select new sinifgrup3
                         {
                             marka = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(sorgu4.ToList());
        }
    }
}