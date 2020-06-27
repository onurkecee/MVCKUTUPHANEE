using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using System.Xml;

namespace MvcKutuphane.Controllers
{
    public class DovizController : Controller
    {
        KutuphaneEntities db = new KutuphaneEntities();
        // GET: Anasayfa
        public ActionResult Index()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
            var Tarih_Date_Nodes = xml.SelectSingleNode("//Tarih_Date");
            var CurrencyNodes = Tarih_Date_Nodes.SelectNodes("//Currency");
            int CurrencyLength = CurrencyNodes.Count;

            List<_Doviz> dovizler = new List<_Doviz>();
            for (int i = 0; i < CurrencyLength; i++)
            {
                var cn = CurrencyNodes[i];
                dovizler.Add(new _Doviz
                {
                    Kod = cn.Attributes["Kod"].Value,
                    CrossOrder = cn.Attributes["CrossOrder"].Value,
                    CurrencyCode = cn.Attributes["CurrencyCode"].Value,
                    Unit = cn.ChildNodes[0].InnerXml,
                    Isim = cn.ChildNodes[1].InnerXml,
                    CurrencyName = cn.ChildNodes[2].InnerXml,
                    ForexBuying = cn.ChildNodes[3].InnerXml,
                    ForexSelling = cn.ChildNodes[4].InnerXml,
                    BanknoteBuying = cn.ChildNodes[5].InnerXml,
                    BanknoteSelling = cn.ChildNodes[6].InnerXml,
                    CrossRateOther = cn.ChildNodes[8].InnerXml,
                    CrossRateUSD = cn.ChildNodes[7].InnerXml,
                });
            }
            ViewData["dovizler"] = dovizler;
            return View();
        }

        public class _Doviz
        {
            public string CrossOrder { get; set; }
            public string Kod { get; set; }
            public string CurrencyCode { get; set; }
            public string Unit { get; set; }
            public string Isim { get; set; }
            public string CurrencyName { get; set; }
            public string ForexBuying { get; set; }
            public string ForexSelling { get; set; }
            public string BanknoteBuying { get; set; }
            public string BanknoteSelling { get; set; }
            public string CrossRateUSD { get; set; }
            public string CrossRateOther { get; set; }
        }

    }
}