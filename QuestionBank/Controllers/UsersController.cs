using Newtonsoft.Json;
using QuestionBank.Infrastructure;
using QuestionBank.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestionBank.Controllers
{
    [Authorize(Roles = "Admin")]
    [SelectedTab("Users")]
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            using (QuestionBankDbContext Db = new QuestionBankDbContext())
            {
                return View(Db.User.ToList());
            }

        }
        public ActionResult Add()
        {
            using (QuestionBankDbContext Db = new QuestionBankDbContext())
            {
                ViewBag.Lessons = Db.Lesson.ToList();
            }

            return View();

        }
        [HttpPost]
        public ActionResult Add(User model, int[] lessonsIDs)
        {

            if (ModelState.IsValid)
            {
                using (QuestionBankDbContext Db = new QuestionBankDbContext())
                {

                    if (Db.User.ToList().SingleOrDefault(x => x.Mail.Equals(model.Mail)) == null)
                    {
                        if (Db.User.ToList().SingleOrDefault(x => x.UserName.Equals(model.Mail)) == null)
                        {

                            Db.Entry(model).State = System.Data.Entity.EntityState.Added;

                            foreach (int item in lessonsIDs)
                            {
                                UserLesson UserLes = new UserLesson { LessonID = item, UserID = model.ID };
                                Db.Entry(UserLes).State = System.Data.Entity.EntityState.Added;
                            }

                            Db.SaveChanges();
                            ViewBag.Message = $"<div class='alert alert-success'><strong>Başarılı!</strong> Kullanıcı Başarıyla Eklendi... </div>";
                            ModelState.Clear();
                        }

                        else
                        {
                            ViewBag.Message = $"<div class='alert alert-danger'><strong>Hata!</strong> Bu kullanıcı adı veya Mail Kullanılıyor zaten kullanılıyor... </div>";
                        }
                    }
                    else
                    {
                        ViewBag.Message = $"<div class='alert alert-danger'><strong>Hata!</strong> Bu mail zaten kullanılıyor... </div>";
                    }
                }
                using (QuestionBankDbContext Db = new QuestionBankDbContext())
                {
                    ViewBag.Lessons = Db.Lesson.ToList();
                }
            }
            return View();

        }

        public ActionResult Edit(int ID)
        {
            QuestionBankDbContext Db = new QuestionBankDbContext();
            User user = Db.User.SingleOrDefault(x => x.ID.Equals(ID));

            ViewBag.UserLessons = user.UserLesson.Select(x => x.LessonID).ToList<int>();
            ViewBag.Lessons = Db.Lesson.ToList();
            if (user != null)
            {
                return View(user);
            }

            return RedirectToAction("Users");
        }
        [HttpPost]
        public ActionResult Edit(User model, int[] lessonsIDs)
        {
            ModelState.Remove("Name");
            ModelState.Remove("SurName");
            ModelState.Remove("Password");
          

            if (ModelState.IsValid && lessonsIDs != null)
            {
                using (QuestionBankDbContext Db = new QuestionBankDbContext())
                {
                    List<User> lst = Db.User.ToList();

                    if (lst.SingleOrDefault(x => x.Mail.Equals(model.Mail) && x.ID != model.ID) == null)
                    {
                        if (lst.SingleOrDefault(x => x.UserName.Equals(model.UserName) && x.ID != model.ID) == null)
                        {
                            User user = lst.SingleOrDefault(x => x.ID.Equals(model.ID));
                            user.UserName = model.UserName;
                            //user.Name = model.Name;
                            //user.SurName = model.SurName;
                            //user.Password = model.Password;
                            user.Mail = model.Mail;
                            user.IsItAdmin = model.IsItAdmin;

                         
                            
                                foreach (int item in lessonsIDs)
                                {
                                    UserLesson userLesson = Db.UserLesson.SingleOrDefault(x => x.LessonID.Equals(item) && x.UserID.Equals(model.ID));
                                    if (userLesson == null)
                                    {
                                        Db.UserLesson.Add(new UserLesson() { LessonID = item, UserID = model.ID });
                                    }
                                }

                            
                           
                            List<UserLesson> silinecekler = Db.UserLesson.Where(x => x.UserID.Equals(model.ID) && !lessonsIDs.Contains(x.LessonID)).ToList();

                            Db.UserLesson.RemoveRange(silinecekler);
                           
                            Db.SaveChanges();
                            ViewBag.Message = $"<div class='alert alert-success'><strong>Başarılı!</strong> Kullanıcı Başarıyla Güncellendi... </div>";
                            ModelState.Clear();
                        }
                        else
                        {
                            ViewBag.Message = $"<div class='alert alert-danger'><strong>Hata!</strong> Bu kullanıcı adı zaten kullanılıyor... </div>";
                        }
                    }
                    else
                    {
                        ViewBag.Message = $"<div class='alert alert-danger'><strong>Hata!</strong> Bu mail zaten kullanılıyor... </div>";
                    }
                }

            }
            else
            {
                ViewBag.Message = $"<div class='alert alert-danger'><strong>Hata!</strong> Kullanıcının en az bir dersi olmalı... </div>";
            }
            using (QuestionBankDbContext Db = new QuestionBankDbContext())
            {

                ViewBag.Lessons = Db.Lesson.ToList();
                ViewBag.UserLessons = Db.UserLesson.Select(x => x.LessonID).ToList<int>();
            }
            //ViewBag.message = $"<div class='alert alert-danger'><strong>Başarısız!</strong> Kullanıcının en az bir dersi olmalı... </div>";
            return View(model);

        }
        [HttpPost]
        public string Delete(int ID)
        {
            string message = string.Empty;
            using (QuestionBankDbContext Db = new QuestionBankDbContext())
            {
                User user = Db.User.SingleOrDefault(x => x.ID.Equals(ID) && !x.UserName.Equals(User.Identity.Name));


                if (user != null)
                {

                    IEnumerable<UserLesson> userles = Db.UserLesson.RemoveRange(Db.UserLesson.Where(x => x.LessonID == ID));
                    Db.User.Remove(user);
                    Db.SaveChanges();
                    message = JsonConvert.SerializeObject(new { durum = "OK", mesaj = "Kullanıcı Silindi" });
                }
                else
                {
                    message = JsonConvert.SerializeObject(new { durum = "No", mesaj = "Kullanıcı Silinemedi" });
                }
            }
            return message;
        }
    }
}




