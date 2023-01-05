using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using DaimaProje2.Models;
using System.Web.Security;


namespace DaimaProje2.Controllers
{
    [Authorize]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        
        // GET: Account
       
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Login(KullaniciModel p)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Email", p.Email);
            param.Add("@Sifre", p.Sifre);
            //DP.ExecuteWReturn("KullaniciGiris", param);
            var sonuc = DP.ReturnList<KullaniciModel>("KullaniciGiris", param).FirstOrDefault<KullaniciModel>();
            if (sonuc != null)
            {
                FormsAuthentication.SetAuthCookie(sonuc.Email, false);
                Session["Email"] = sonuc.Email.ToString();
                Session["AdSoyad"] = sonuc.AdSoyad.ToString();
                Session["Sifre"] = sonuc.Sifre.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["messages"] = "Kullanıcı Adı veya Şifre Hatalı";
                return View();
            }
        }

        
        public ActionResult SifreDegis()
        {
            
            return View();
        }
        
        [HttpPost]
        public ActionResult SifreDegis(string sifre, string eskiSifre)
        {
            if (eskiSifre == sifre)
            {
                TempData["messages2"] = "Eski Şifre Yeni Şifre ile Aynı Olamaz...";
                return View();

            }
            else if (eskiSifre == Session["Sifre"].ToString())
            {
                TempData["messages3"] = "Şifreniz Başarılı Bir Şekilde Değiştirildi, Lütfen Tekrar Giriş Yapınız...";
                DynamicParameters param = new DynamicParameters();
                param.Add("@Email", Session["Email"]);
                param.Add("@Sifre", sifre);
                DP.ExecuteWReturn("SifreDegis", param);
                
                return RedirectToAction("LogOut", "Account");
            }
            else
            {
                TempData["messages2"] = "Eski Şifre Hatalı";
                return View();
            } 
        }
        
        
        


    }
}