using DaimaProje2.Models;
using Dapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaimaProje2.Controllers
{
    public class UretimController : Controller
    {
        // GET: Uretim
        //public ActionResult Index(int sayfa=1)
        //{
        //    var result = DP.ReturnList<UretimJoin>("UretimListele").ToPagedList(sayfa,5);
        //    return View(result);
        //}

        public ActionResult Index()
        {
            var result = DP.ReturnList<UretimJoin>("UretimListele");
            return View(result);
        }

        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            List<Uretim> li = new List<Uretim>();
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UretimNo", id);
                return View(DP.ReturnList<Uretim>("UretimGetir", param).FirstOrDefault<Uretim>());
            }


        }
        [HttpPost]
        public ActionResult EY(Uretim uretim)
        {
            //View olustururken edit olanı seciyoruz.
            DynamicParameters param = new DynamicParameters();
            param.Add("@UretimNo", uretim.UretimNo);
            param.Add("@UrunNo", uretim.UrunNo);
            param.Add("@Adet", uretim.Adet);
            param.Add("@KullaniciNo", uretim.KullaniciNo);
            param.Add("@UretimTarihi", uretim.UretimTarihi);


            DP.ExecuteWReturn("UretimEY", param);
            return RedirectToAction("Index");

        }


        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UretimNo", id);
            DP.ExecuteWReturn("UretimSil", param);
            return RedirectToAction("Index");
        }

        //public JsonResult ExcelExport()
        //{
        //    try
        //    {
        //        DynamicParameters param = new DynamicParameters();
        //        var liste = DP.ReturnList<UretimJoin>("Uretimlistele", param).ToList();
        //        Excel.Application application = new Excel.Application();
        //        Excel.Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value);
        //        Excel.Worksheet worksheet = workbook.ActiveSheet;

        //        worksheet.Cells[1, 1] = "Ürün No";
        //        worksheet.Cells[1, 2] = "Ürün Adı";
        //        worksheet.Cells[1, 3] = "Adet";
        //        worksheet.Cells[1, 4] = "Ad Soyad";
        //        worksheet.Cells[1, 5] = "Üretim Tarihi";
        //        int row = 2;

        //        foreach (var item in liste)
        //        {
        //            worksheet.Cells[row, 1] = item.UretimNo;
        //            worksheet.Cells[row, 2] = item.UrunAdi;
        //            worksheet.Cells[row, 3] = item.Adet;
        //            worksheet.Cells[row, 4] = item.AdSoyad;
        //            worksheet.Cells[row, 5] = item.UretimTarihi.ToString();

        //            worksheet.Cells[row, 1].ColumnWidth = 15;
        //            worksheet.Cells[row, 2].ColumnWidth = 15;
        //            worksheet.Cells[row, 3].ColumnWidth = 15;
        //            worksheet.Cells[row, 4].ColumnWidth = 15;
        //            worksheet.Cells[row, 5].ColumnWidth = 20;


        //            row++;

        //        }
        //        var heading = worksheet.get_Range("A1", "E1");
        //        heading.Font.Bold = true;
        //        heading.Font.Size = 13;
        //        heading.Font.Color = System.Drawing.Color.Red;


        //        workbook.SaveAs("D:\\Yeni klasör\\uretim.xlsx");
        //        workbook.Close();
        //        application.Quit();
        //        ViewBag.mesaj = "İşlem Başarılı";
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.mesaj = ex.Message;




        //    }
        //    return Json(ViewBag.mesaj, JsonRequestBehavior.AllowGet);
        //}
    }
}