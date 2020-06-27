using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.Siniflarim;

namespace MvcKutuphane.Controllers
{
    public class VitrinController : Controller
    {
        KutuphaneEntities db = new KutuphaneEntities();
        // GET: Vitrin

        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.KITAPLARIM = db.TBLKitap.ToList();
            cs.HAKKIMIZDA = db.TBLHakkimizda.ToList();
            // var degerler = db.TBLKitap.ToList();
            return View(cs);
        }

        [HttpPost]
        public ActionResult Index(TBLIletisim p)
        {
            db.TBLIletisim.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}