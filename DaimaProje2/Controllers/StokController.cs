using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using DaimaProje2.Models;

namespace DaimaProje2.Controllers
{
    public class StokController : Controller
    {
        // GET: Stok
        public ActionResult Index()
        {
            return View(DP.ReturnList<StokUrunAd>("StokListele"));
        }

        public PartialViewResult StokCount()
        {
            if (User.Identity.IsAuthenticated)
            {       //Kullanıcı gırıs yaptıgında
                //var count = db.Urun.Where(x => x.Stok < 50).Count();
                
                var count = DP.ReturnList<StokUrunAd>("StokKritik").Count();
                ViewBag.count = count;
                var azalan = DP.ReturnList<StokUrunAd>("StokKritikYaklasan").Count();
                ViewBag.azalan = azalan;
                
            }
            return PartialView();
        }
    }
}