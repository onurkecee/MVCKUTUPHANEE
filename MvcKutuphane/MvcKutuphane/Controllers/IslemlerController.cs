using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class IslemlerController : Controller
    {
        KutuphaneEntities db = new KutuphaneEntities();
        // GET: Islemler
        public ActionResult Index()
        {
            var islemler = db.TBLHareket.Where(x => x.ISLEMDURUM == true).ToList();
            return View(islemler);
        }
    }
}