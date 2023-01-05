using DaimaProje2.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaimaProje2.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        public ActionResult Index()
        {
            var result = DP.ReturnList<SatisJoin>("SatisListele");
            return View(result);
        }

        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            List<SatisModel> li = new List<SatisModel>();
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@SatisNo", id);
                return View(DP.ReturnList<SatisModel>("SatisGetir", param).FirstOrDefault<SatisModel>());
            }


        }
        [HttpPost]
        public ActionResult EY(SatisModel satis)
        {
            //View olustururken edit olanı seciyoruz.
            DynamicParameters param = new DynamicParameters();
            param.Add("@SatisNo", satis.SatisNo);
            param.Add("@UrunNo", satis.UrunNo);
            param.Add("@Adet", satis.Adet);
            param.Add("@SatisTarihi", satis.SatisTarihi);
            param.Add("@MusteriNo", satis.MusteriNo);
            param.Add("@KullaniciNo", satis.KullaniciNo);


            DP.ExecuteWReturn("SatisEY", param);
            return RedirectToAction("Index");

        }


        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@SatisNo", id);
            DP.ExecuteWReturn("SatisSil", param);       
            return RedirectToAction("Index");
        }
    }
}