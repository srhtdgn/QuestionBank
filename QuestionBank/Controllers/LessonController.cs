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
    [Authorize(Roles ="Admin")]
    [SelectedTab("Lesson")]
    public class LessonController : Controller
    {
        // GET: Lesson
        public ActionResult Index()
        {
            using(QuestionBankDbContext Db=new QuestionBankDbContext())
            {
                return View(Db.Lesson.ToList());
            }
       
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Lesson model)
        {
            if (ModelState.IsValid)
            {
                using(QuestionBankDbContext db = new QuestionBankDbContext())
                {
                    if (db.Lesson.SingleOrDefault(x => x.LessonName.Equals(model.LessonName)) == null)
                    {
                        db.Entry(model).State = System.Data.Entity.EntityState.Added;
                        db.SaveChanges();
                        ViewBag.Message = $"<div class='alert alert-success'><strong>Başarılı! </strong>{ model.LessonName} Dersi Başarıyla Eklendi... </div>";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Message = $"<div class='alert alert-danger'><strong>Hata! </strong>{model.LessonName} Dersi zaten mevcuttur... </div>";
                    }
                }
            }
            return View(model);
        }
        public ActionResult Edit(int ID)
        {
            using (QuestionBankDbContext db = new QuestionBankDbContext())
            {
                Lesson ders = db.Lesson.SingleOrDefault(x => x.ID.Equals(ID));
                if (ders != null)
                {
                    return View(ders);
                }
            }
            return RedirectToRoute("Lessons");
        }
        [HttpPost]
        public ActionResult Edit(Lesson model)
        {
            if (ModelState.IsValid)
            {
                using (QuestionBankDbContext db = new QuestionBankDbContext())
                {
                    if (db.Lesson.SingleOrDefault(x => x.LessonName.Equals(model.LessonName) && x.ID != model.ID) == null)
                    {
                        db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        ViewBag.Message = $"<div class='alert alert-success'><strong>Başarılı! </strong>{model.LessonName} Dersi Başarıyla Güncellendi... </div>";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Message = $"<div class='alert alert-danger'><strong>Hata! </strong>{model.LessonName} dersi zaten mevcuttur... </div>";
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public string Delete(int ID)
        {
            string message = string.Empty;
            using (QuestionBankDbContext db = new QuestionBankDbContext())
            {
                Lesson ders = db.Lesson.SingleOrDefault(x => x.ID.Equals(ID));
                if (ders != null)
                {
                    db.Lesson.Remove(ders);
                    db.SaveChanges();
                    message = JsonConvert.SerializeObject(new { durum = "OK", mesaj = "Ders Silindi" });
                }
                else
                {
                    message = JsonConvert.SerializeObject(new { durum = "No", mesaj = "Ders Silinemedi" });
                }
            }
            return message;
        }
    }
}
