using QuestionBank.Models;
using QuestionBank.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QuestionBank.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanici model, string ReturnUrl)
        {
            ModelState.Remove("KullaniciAdi");
            if (ModelState.IsValid)
            {
                using (QuestionBankDbContext db = new QuestionBankDbContext())
                {
                    Kullanici kul = db.Kullanici.SingleOrDefault(x => x.Mail == model.Mail && x.Sifre == model.Sifre);
                    if (kul != null)
                    {
                        FormsAuthentication.SetAuthCookie(kul.KullaniciAdi, true);

                        if (!string.IsNullOrWhiteSpace(ReturnUrl))
                            return Redirect(ReturnUrl);
                        return RedirectToRoute("Home");
                    }
                }
                ViewBag.Message = "<div class='alert alert-danger display'><button class='close' data-close='alert'></button><span> Böyle bir kullanıcı yoktur... </span></div>";
            }

            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("Login");
        }
    }
}