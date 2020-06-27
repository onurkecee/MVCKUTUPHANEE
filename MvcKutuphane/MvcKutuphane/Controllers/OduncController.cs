using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {
        KutuphaneEntities db = new KutuphaneEntities();
        // GET: Odunc
        public ActionResult Index()
        {
            var odunc = db.TBLHareket.Where(x => x.ISLEMDURUM == false).ToList();
            return View(odunc);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> uyeler = (from x in db.TBLUyeler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD + " " + x.SOYAD,
                                               Value = x.ID.ToString()
                                           }).ToList();

            List<SelectListItem> kitaplar = (from x in db.TBLKitap.Where(x => x.DURUM == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.AD,
                                                 Value = x.ID.ToString()
                                             }).ToList();

            List<SelectListItem> personeller = (from x in db.TBLPersonel.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PERSONEL,
                                                    Value = x.ID.ToString()
                                                }).ToList();

            ViewBag.uye = uyeler;
            ViewBag.kitap = kitaplar;
            ViewBag.personel = personeller;
            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(TBLHareket p)
        {
            var uye = db.TBLUyeler.Where(x => x.ID == p.TBLUyeler.ID).FirstOrDefault();
            var kitap = db.TBLKitap.Where(y => y.ID == p.TBLKitap.ID).FirstOrDefault();
            var personel = db.TBLPersonel.Where(z => z.ID == p.TBLPersonel.ID).FirstOrDefault();

            p.TBLUyeler = uye;
            p.TBLKitap = kitap;
            p.TBLPersonel = personel;

            db.TBLHareket.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Odunciade(TBLHareket p)
        {
            var iade = db.TBLHareket.Find(p.ID);

            DateTime d1 = DateTime.Parse(iade.İADETARİH.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            TimeSpan fark = d2 - d1;
            ViewBag.dgr = fark.TotalDays;

            return View("Odunciade", iade);
        }

        public ActionResult OduncGuncelle(TBLHareket p)
        {
            var hareket = db.TBLHareket.Find(p.ID);
            hareket.UYEGETIRTARIH = p.UYEGETIRTARIH;
            hareket.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}