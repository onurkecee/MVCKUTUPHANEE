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
    public class PersonelController : Controller
    {
        KutuphaneEntities db = new KutuphaneEntities();
        // GET: Personel
        public ActionResult Index()
        {
            var personel = db.TBLPersonel.ToList();
            return View(personel);
        }

        [HttpPost]
        public ActionResult PersonelEkle(TBLPersonel p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.TBLPersonel.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        public ActionResult PersonelSil(int id)
        {
            var personel = db.TBLPersonel.Find(id);
            db.TBLPersonel.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var personel = db.TBLPersonel.Find(id);
            return View("PersonelGetir", personel);
        }

        public ActionResult PersonelGuncelle(TBLPersonel p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelGetir");
            }
            var pers = db.TBLPersonel.Find(p.ID);
            pers.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelDetay(int id)
        {
            var personel = db.TBLPersonel.Find(id);
            return View("PersonelDetay", personel);
        }
    }
}