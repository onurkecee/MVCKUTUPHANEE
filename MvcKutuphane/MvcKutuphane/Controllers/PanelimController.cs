using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    public class PanelimController : Controller
    {
        // GET: Panelim
        KutuphaneEntities db = new KutuphaneEntities();

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["MAIL"];
            var degerler = db.TBLUyeler.FirstOrDefault(x => x.MAIL == uyemail);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult Index2(TBLUyeler p)
        {
            var kullanici = (string)Session["MAIL"];
            var uye = db.TBLUyeler.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SİFRE = p.SİFRE;
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.TELEFON = p.TELEFON;
            uye.OKUL = p.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["MAIL"];
            var id = db.TBLUyeler.Where(x => x.MAIL == kullanici.ToString()).Select(y => y.ID).FirstOrDefault();
            var degerler = db.TBLHareket.Where(x => x.UYE == id).ToList();
            return View(degerler);
        }

        public ActionResult Duyurular()
        {
            var duyuru = db.TBLDuyurular.ToList();
            return View(duyuru);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }


    }
}