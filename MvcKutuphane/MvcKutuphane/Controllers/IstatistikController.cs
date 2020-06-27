using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        KutuphaneEntities db = new KutuphaneEntities();
        public ActionResult Index()
        {
            var UyeSayisi = db.TBLUyeler.Count();
            var KitapSayisi = db.TBLKitap.Count();
            var EmanetKitapSayisi = db.TBLKitap.Where(x => x.DURUM == false).Count();
            var ToplamTutar = db.TBLCezalar.Sum(x => x.PARA);

            ViewBag.uyesayisi = UyeSayisi;
            ViewBag.kitapsayisi = KitapSayisi;
            ViewBag.emanetkitapsayisi = EmanetKitapSayisi;
            ViewBag.toplamtutar = ToplamTutar;
            return View();
        }

        public ActionResult Hava()
        {
            return View();
        }

        public ActionResult HavaKart()
        {
            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength < 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Galeri");
        }
    }
}