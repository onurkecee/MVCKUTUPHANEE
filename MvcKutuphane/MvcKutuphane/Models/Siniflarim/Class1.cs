using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Models.Siniflarim
{
    public class Class1
    {
        public IEnumerable<TBLKitap> KITAPLARIM { get; set; }
        public IEnumerable<TBLHakkimizda> HAKKIMIZDA { get; set; }
    }
}