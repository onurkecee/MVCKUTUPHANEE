using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class MesajlarController : Controller
    {
        KutuphaneEntities db = new KutuphaneEntities();
        // GET: Mesajlar
        public ActionResult Index()
        {
            var uyemail = (string)Session["MAIL"].ToString();
            var mesajlar = db.TBLMesajlar.Where(x => x.ALICI == uyemail.ToString()).ToList();
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var uyemail = (string)Session["MAIL"].ToString();
            var mesajlar = db.TBLMesajlar.Where(x => x.GÖNDEREN == uyemail.ToString()).ToList();
            return View(mesajlar);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(TBLMesajlar p)
        {
            var uyemail = (string)Session["MAIL"].ToString();
            p.GÖNDEREN = uyemail.ToString();
            p.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLMesajlar.Add(p);
            db.SaveChanges();
            return RedirectToAction("GidenMesajlar");
        }
    }
}