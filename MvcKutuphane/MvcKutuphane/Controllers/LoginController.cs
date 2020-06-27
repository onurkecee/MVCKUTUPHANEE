using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    public class LoginController : Controller
    {
        KutuphaneEntities db = new KutuphaneEntities();
        // GET: Login

        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(TBLUyeler p)
        {
            var bilgiler = db.TBLUyeler.FirstOrDefault(x => x.MAIL == p.MAIL && x.SİFRE == p.SİFRE);
            if (bilgiler !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["MAIL"] = bilgiler.MAIL.ToString();
                //TempData["ID"] = bilgiler.ID.ToString();
                //TempData["AD"] = bilgiler.AD.ToString();
                //TempData["SOYAD"] = bilgiler.SOYAD.ToString();
                //TempData["KULLANICIADI"] = bilgiler.KULLANICIADI.ToString();
                //TempData["SIFRE"] = bilgiler.SİFRE.ToString();
                //TempData["TELEFON"] = bilgiler.TELEFON.ToString();
                //TempData["OGRENIMDURUMU"] = bilgiler.OKUL.ToString();
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
            
        }
    }
}