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
    public class YazarController : Controller
    {
        // GET: Yazar
        KutuphaneEntities db = new KutuphaneEntities();
        public ActionResult Index(string p, int sayfa = 1)
        {
            var yazar = from y in db.TBLYazar select y;
            if (!string.IsNullOrEmpty(p))
            {
                yazar = yazar.Where(x => x.AD.Contains(p));
            }
            //var degerler = db.TBLYazar.ToList();
            return View(yazar.ToList().ToPagedList(sayfa, 10));
        }

        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }

        public ActionResult YazarEkle(TBLYazar p)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TBLYazar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarSil(int id)
        {
            var yazar = db.TBLYazar.Find(id);
            db.TBLYazar.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarGetir(int id)
        {
            var yazar = db.TBLYazar.Find(id);
            return View("YazarGetir", yazar);
        }

        public ActionResult YazarGuncelle(TBLYazar p)
        {
            var yazar = db.TBLYazar.Find(p.ID);
            yazar.AD = p.AD;
            yazar.SOYAD = p.SOYAD;
            yazar.BIYOGRAFI = p.BIYOGRAFI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarDetay(int id)
        {
            var yazar = db.TBLYazar.Find(id);
            return View("YazarDetay", yazar);
            //var yazarkitap = db.TBLKitap.Where(x => x.YAZAR == id).ToList();
            //var yazarad = db.TBLYazar.Where(x => x.ID == id).Select(y => y.AD + "" + y.SOYAD).FirstOrDefault();
            //ViewBag.y1 = yazarad;
            //return View(yazarkitap);
        }
    }
}