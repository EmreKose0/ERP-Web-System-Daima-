using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaimaProje2.Models
{
    public class SatisModel
    {
        public int SatisNo { get; set; }

        public int UrunNo { get; set; }

        public int Adet { get; set; }

        public DateTime SatisTarihi { get; set; }
        public int MusteriNo { get; set; }
        public int KullaniciNo { get; set; }

        
    }
}