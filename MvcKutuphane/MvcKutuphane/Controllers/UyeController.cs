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
    public class UyeController : Controller
    {
        KutuphaneEntities db = new KutuphaneEntities();
        // GET: Uye
        public ActionResult Index(string p, int sayfa = 1)
        {
            var uye = from k in db.TBLUyeler select k;
            if (!string.IsNullOrEmpty(p))
            {
                uye = uye.Where(x => x.AD.Contains(p));
            }
            //var uye = db.TBLUyeler.ToList();
            //var uye = db.TBLUyeler.ToList().ToPagedList(sayfa, 10);
            return View(uye.ToList().ToPagedList(sayfa, 10));
        }

        [HttpPost]
        public ActionResult UyeEkle(TBLUyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TBLUyeler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLUyeler.Find(id);
            db.TBLUyeler.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBLUyeler.Find(id);
            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(TBLUyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeGetir");
            }
            var uye = db.TBLUyeler.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAIL = p.MAIL;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.SİFRE = p.SİFRE;
            uye.FOTOGRAF = uye.FOTOGRAF;
            uye.TELEFON = p.TELEFON;
            uye.OKUL = p.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeKitapGecmis(int id)
        {
            var kitapgecmis = db.TBLHareket.Where(x => x.UYE == id).ToList();
            return View(kitapgecmis);
        }

        public ActionResult UyeDetay(int id)
        {
            var uyedetay = db.TBLUyeler.Find(id);
            return View("UyeDetay", uyedetay);
        }
    }
}