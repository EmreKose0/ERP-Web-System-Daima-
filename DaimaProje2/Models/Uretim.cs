using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaimaProje2.Models
{
    public class Uretim
    {
        public int UretimNo { get; set; }

        public int UrunNo { get; set; }

        public int Adet { get; set; }

        public int KullaniciNo { get; set; }

        public DateTime UretimTarihi { get; set; }
    }
}