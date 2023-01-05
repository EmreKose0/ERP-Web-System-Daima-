using DaimaProje2.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaimaProje2.Controllers
{
    public class BarkodController : Controller
    {
        // GET: Barkod
        public ActionResult Index()
        {
            var result = DP.ReturnList<BarkodJoin>("BarkodListele");
            return View(result);
        }

        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            List<BarkodModel> li = new List<BarkodModel>();
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@SatisNo", id);
                return View(DP.ReturnList<BarkodModel>("BarkodGetir", param).FirstOrDefault<BarkodModel>());
            }


        }
        [HttpPost]
        public ActionResult EY(BarkodModel barkod)
        {
            //View olustururken edit olanı seciyoruz.
            DynamicParameters param = new DynamicParameters();
            param.Add("@SatisNo", barkod.SatisNo);
            
            param.Add("@SeriNumarasi", barkod.SeriNumarasi);


            DP.ExecuteWReturn("BarkodEdit", param);
            return RedirectToAction("Index");

        }


        //public ActionResult Delete(int id = 0)
        //{
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@SatisNo", id);
        //    DP.ExecuteWReturn("SatisSil", param);
        //    return RedirectToAction("Index");
        //}
    }
}