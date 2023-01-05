using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DaimaProje2.Models
{
    public class KullaniciModel
    {
        public int KullaniciNo { get; set; }
        
        public string AdSoyad { get; set; }
        
        public string Email { get; set; }
        
        //public string KullaniciAdi { get; set; }
        
        public string Sifre { get; set; }
        
        public string Rol { get; set; }
    }
}