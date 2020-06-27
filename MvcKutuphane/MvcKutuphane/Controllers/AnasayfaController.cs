using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class AnasayfaController : Controller
    {
        KutuphaneEntities db = new KutuphaneEntities();
        // GET: Anasayfa
        public ActionResult Index()
        {
            var UyeSayisi = db.TBLUyeler.Count();
            var KitapSayisi = db.TBLKitap.Count();
            var EmanetKitapSayisi = db.TBLKitap.Where(x => x.DURUM == false).Count();
            var PersonelSayisi = db.TBLPersonel.Count();

            ViewBag.uyesayisi = UyeSayisi;
            ViewBag.kitapsayisi = KitapSayisi;
            ViewBag.emanetkitapsayisi = EmanetKitapSayisi;
            ViewBag.personelsayisi = PersonelSayisi;
            return View();
        }



    }
}