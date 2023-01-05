using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaimaProje2.Models
{
    public class StokUrunAd
    {
        public int StokNo { get; set; }
        public int UrunNo { get; set; }
        public string UrunAdi { get; set; }
        public decimal Miktar { get; set; }
    }
}