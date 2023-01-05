using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaimaProje2.Models
{
    public class SatisJoin
    {
        public int SatisNo { get; set; }

        public string UrunAdi { get; set; }

        public int Adet { get; set; }

        public string MusteriAdi { get; set; }

        public string AdSoyad { get; set; }

        public DateTime SatisTarihi { get; set; }

    }
}