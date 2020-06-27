using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        KutuphaneEntities db = new KutuphaneEntities();
        // GET: Duyuru
        public ActionResult Index()
        {
            var duyurular = db.TBLDuyurular.ToList();
            return View(duyurular);
        }

        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DuyuruEkle(TBLDuyurular p)
        {
            db.TBLDuyurular.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.TBLDuyurular.Find(id);
            db.TBLDuyurular.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruDetay(TBLDuyurular p)
        {
            var duyuru = db.TBLDuyurular.Find(p.ID);
            return View("DuyuruDetay", duyuru);
        }

        public ActionResult DuyuruGuncelle(TBLDuyurular p)
        {
            var duyuru = db.TBLDuyurular.Find(p.ID);
            duyuru.KATEGORI = p.KATEGORI;
            duyuru.ICERIK = p.ICERIK;
            duyuru.TARIH = p.TARIH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}