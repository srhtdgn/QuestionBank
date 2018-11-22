using QuestionBank.Models;
using QuestionBank.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QuestionBank.Infrastructure;

namespace QuestionBank.Controllers
{
    [SelectedTab("Home")]
    public class AccountController :Controller
    {
        // GET: Account
        public ActionResult Login()

        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User model, string ReturnUrl)
        {
            ModelState.Remove("UserName");
            ModelState.Remove("Name");
            ModelState.Remove("SurName");

            if (ModelState.IsValid)
            {
                using (QuestionBankDbContext db = new QuestionBankDbContext())
                {
                    User user = db.User.SingleOrDefault(x => x.Mail == model.Mail && x.Password == model.Password);
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(user.UserName, true);

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
        [Authorize]
        public ActionResult ProfileDetail()
        {
            using (QuestionBankDbContext Db = new QuestionBankDbContext())
            {
                if (TempData["Message"]!=null)
                    ViewBag.Message = TempData["Message"].ToString();

                    return View(Db.User.SingleOrDefault(x=>x.UserName.Equals(User.Identity.Name)));              
            }
               
        }
        [Authorize]
        [HttpPost]
        public ActionResult ChangeMail(User model)
        {
            ModelState.Remove("UserName");
            ModelState.Remove("Password");
            ModelState.Remove("Name");
            ModelState.Remove("SurName");
            if (ModelState.IsValid)
            {
                using (QuestionBankDbContext Db = new QuestionBankDbContext())
                {
                    List<User> lst = Db.User.ToList();

                    User user = lst.SingleOrDefault(x => x.UserName.Equals(User.Identity.Name));
                    if (lst.SingleOrDefault(x => x.Mail.Equals(model.Mail) && x.ID != user.ID) == null)
                    {
                        user.Mail = model.Mail;
                        Db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        Db.SaveChanges();
                        TempData["Message"] = $"<div class='alert alert-success'><strong>Başarılı!</strong> Bilgileriniz Başarıyla Güncellendi... </div>";
                    }
                    else
                    {
                        TempData["Message"] = $"<div class='alert alert-danger'><strong>Hata!</strong> Mail adresi kullanılıyor... </div>";
                    }
                }
            }
            return Redirect("Profil#tab_1_4");

        }
        [Authorize]
        [HttpPost]
        public ActionResult ChangePhoto(HttpPostedFileBase image)
        {
            if (image != null)
            {
                using (QuestionBankDbContext Db = new QuestionBankDbContext())
                {
                    User user = Db.User.SingleOrDefault(x => x.UserName.Equals(User.Identity.Name));
                    user.Photo = FileUpload.FileName(image, FileUpload.UploadFolder.Profile);
                    Db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    Db.SaveChanges();
                    TempData["Message"] = $"<div class='alert alert-success'><strong>Başarılı!</strong> Profil Fotoğrafınız Başarıyla Güncellendi... </div>";
                }
            }
            return Redirect("Profil#tab_1_2");
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(User model)
        {
            ModelState.Remove("UserName");
            ModelState.Remove("Name");
            ModelState.Remove("SurName");
            ModelState.Remove("Mail");
            if (ModelState.IsValid)
            {
                using (QuestionBankDbContext Db = new QuestionBankDbContext())
                {
                    User user = Db.User.SingleOrDefault(x => x.UserName.Equals(User.Identity.Name));

                    if (user.Password.Equals(model.Password))
                    {
                        user.Password = model.NewPassword;
                        Db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        Db.SaveChanges();
                        TempData["Message"] = $"<div class='alert alert-success'><strong>Başarılı!</strong> Şifreniz Başarıyla Güncellendi... </div>";
                    }
                    else
                    {
                        TempData["Message"] = $"<div class='alert alert-danger'><strong>Hata!</strong> MEvcut Şifreniz yanlış... </div>";
                    }
                }
            }
            else
            {
                TempData["Message"] = $"<div class='alert alert-danger'><strong>Hata!</strong> Şifre Bilgilerinde hata oluştu... </div>";
            }
            return Redirect("Profil#tab_1_3");
        }
    }
}