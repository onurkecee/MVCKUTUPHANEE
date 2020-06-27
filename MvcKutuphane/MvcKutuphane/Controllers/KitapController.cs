using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        KutuphaneEntities db = new KutuphaneEntities();
        // GET: Kitap
        public ActionResult Index(string p, int sayfa = 1)
        {
            var kitaplar = from k in db.TBLKitap select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(x => x.AD.Contains(p));
            }
            //var kitaplar = db.TBLKitap.ToList();  
            return View(kitaplar.ToList().ToPagedList(sayfa, 10));
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {


            List<SelectListItem> deger1 = (from i in db.TBLKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from y in db.TBLYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.AD + " " + y.SOYAD,
                                               Value = y.ID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(TBLKitap p)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> deger1 = (from i in db.TBLKategori.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.AD,
                                                   Value = i.ID.ToString()
                                               }).ToList();

                List<SelectListItem> deger2 = (from y in db.TBLYazar.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = y.AD + " " + y.SOYAD,
                                                   Value = y.ID.ToString()
                                               }).ToList();

                ViewBag.dgr1 = deger1;
                ViewBag.dgr2 = deger2;
                return View("KitapEkle");
            }
            var kategori = db.TBLKategori.Where(x => x.ID == p.TBLKategori.ID).FirstOrDefault();
            var yazar = db.TBLYazar.Where(y => y.ID == p.TBLYazar.ID).FirstOrDefault();

            p.TBLKategori = kategori;
            p.TBLYazar = yazar;

            db.TBLKitap.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id)
        {
            var kitap = db.TBLKitap.Find(id);
            db.TBLKitap.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var kitap = db.TBLKitap.Find(id);

            List<SelectListItem> deger1 = (from i in db.TBLKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from y in db.TBLYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.AD + " " + y.SOYAD,
                                               Value = y.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View("KitapGetir", kitap);
        }

        public ActionResult KitapGuncelle(TBLKitap p)
        {
            var kitap = db.TBLKitap.Find(p.ID);
            kitap.AD = p.AD;
            kitap.BASIMYIL = p.BASIMYIL;
            kitap.SAYFA = p.SAYFA;
            kitap.YAYINEVİ = p.YAYINEVİ;
            kitap.DURUM = p.DURUM;

            var kategori = db.TBLKategori.Where(x => x.ID == p.TBLKategori.ID).FirstOrDefault();
            var yazar = db.TBLYazar.Where(x => x.ID == p.TBLYazar.ID).FirstOrDefault();

            kitap.KATEGORİ = kategori.ID;
            kitap.YAZAR = yazar.ID;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult KitapDetay(int id)
        {
            var detay = db.TBLKitap.Find(id);
            return View("KitapDetay", detay);
        }
    }
}