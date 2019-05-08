using Newtonsoft.Json;
using QuestionBank.Infrastructure;
using QuestionBank.Models;
using QuestionBank.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestionBank.Controllers
{
    public class ExamController : BaseController
    {
        // GET: Exam
        [SelectedTab("Exams")]
        public ActionResult Index()
        {
            using (QuestionBankDbContext Db = new QuestionBankDbContext())
            {

                return View(Db.Exam.ToList());
            }
        }


        public ActionResult Add()
        {
            PostUserLessonAndPeriod();
            return View();
        }


        [HttpPost]
        public ActionResult Add(ExamPrepareViewModel model)
        {
            PostUserLessonAndPeriod();
            if (string.IsNullOrWhiteSpace(model.SinavAdi) || model.SeciliSorular == null)
            {

                ViewBag.ErrorMessage = "Lütfen Sınav adı belirleyin veya soru seçiniz...";
                return View();
            }
            else
            {

                Exam exam = new Exam()
                {
                    ExamName = model.SinavAdi


                };
                QuestionBankDbContext Db = new QuestionBankDbContext();
                Db.Exam.Add(exam);
                List<ExamQuestions> lstQuestions = new List<ExamQuestions>();
                foreach (var item in model.SeciliSorular)
                {
                    foreach (var puan in model.SoruPuani)
                    {
                        ExamQuestions examquestions = new ExamQuestions()
                        {
                            QuestionID = item,
                            ExamID = exam.ID,
                            Point = puan


                        };
                        lstQuestions.Add(examquestions);
                       
                    }
                    break;
                }
                Db.ExamQuestions.AddRange(lstQuestions);
                Db.SaveChanges();
                ViewBag.Message = exam.ExamName + " Sınavı başarıyla oluşturulmuştur...";
            }
            return View();
        }
        [HttpPost]
        public ActionResult OtoAdd(ExamPrepareViewModel model)
        {
            QuestionBankDbContext Db = new QuestionBankDbContext();
            PostUserLessonAndPeriod();
            ModelState.Remove("SeciliSorular");
            ModelState.Remove("SoruPuani");
            ModelState.Remove("questions");
            if (ModelState.IsValid)
            {
                List<Question> questions = new List<Question>();
                var sorular = Db.Question.ToList().Where(x => x.Topic.LessonID.Equals(model.DersID) && x.QuestionPeriodID.Equals(model.DonemID)).ToList();
                foreach (var item in sorular)
                {
                    int puan =0;
                    if (item.QuestionType.QuestionTypeName.Equals("Klasik"))
                    {
                        puan = model.KlasikSoruPuan;
                    }
                    else if (item.QuestionType.QuestionTypeName.Equals("Test"))
                    {
                        puan = model.TestSoruPuan;
                    }
                    else if (item.QuestionType.QuestionTypeName.Equals("Boşluk Doldurma"))
                    {
                        puan = model.BoslukSoruPuan;
                    }
                    item.Puan = puan;
                    questions.Add(item);

                }
                List<Question> SeciliAdetSoru = new List<Question>();
                SeciliAdetSoru.AddRange(sorular.Where(x => x.QuestionType.QuestionTypeName.Equals("Klasik")).OrderBy(x => Guid.NewGuid()).Take(model.KlasikSoruAdet));
                SeciliAdetSoru.AddRange(sorular.Where(x => x.QuestionType.QuestionTypeName.Equals("Test")).OrderBy(x => Guid.NewGuid()).Take(model.TestSoruAdet));
                SeciliAdetSoru.AddRange(sorular.Where(x => x.QuestionType.QuestionTypeName.Equals("Boşluk Doldurma")).OrderBy(x => Guid.NewGuid()).Take(model.BoslukSoruAdet));

                Exam exam = new Exam()
                {
                    ExamName = model.SinavAdi
                };
                Db.Exam.Add(exam);

                List<ExamQuestions> SecilmisEklenecekSorular = new List<ExamQuestions>();
                foreach (var item in SeciliAdetSoru)
                {
                    ExamQuestions examQuestions = new ExamQuestions()
                    {
                        QuestionID = item.ID,
                        ExamID = exam.ID,
                        Point = item.Puan
                    };
                    SecilmisEklenecekSorular.Add(examQuestions);
                }
                Db.ExamQuestions.AddRange(SecilmisEklenecekSorular);
                Db.SaveChanges();
                ViewBag.Message = exam.ExamName + " Sınavı başarıyla oluşturulmuştur...";
            }
            else
            {
                ViewBag.EMessage= $"<div class='alert alert-danger'><strong>Hata!</strong>  </div>";
            }
            return View("Add");
        }





        [HttpPost]
        public ActionResult LessonPeriodQuestions(ExamPrepareViewModel model)
        {

            if (model.DersID == 0 || model.DonemID == 0)
            {
                PostUserLessonAndPeriod();
                ViewBag.ErrorMessage = "Hata! Lütfen ders ve soru dönemini seçiniz ";
                return View("Add");
            }
            else
            {
                PostUserLessonAndPeriod();
                QuestionBankDbContext Db = new QuestionBankDbContext();
                List<ExamPrepareViewModel> lstquestions = new List<ExamPrepareViewModel>();
                foreach (var item in Db.Question.Where(x => x.Topic.LessonID.Equals(model.DersID) && x.QuestionPeriodID.Equals(model.DonemID)).ToList())
                {
                    ExamPrepareViewModel newquestions = new ExamPrepareViewModel();
                    newquestions.questions = item;
                    lstquestions.Add(newquestions);
                }

                return View("Add", lstquestions);



            }

        }


        private void PostUserLessonAndPeriod()
        {
            QuestionBankDbContext db = new QuestionBankDbContext();
            ViewBag.UserLessons = db.UserLesson.Where(x => x.User.UserName.Equals(User.Identity.Name)).ToList();
            ViewBag.QuestionPeriod = db.QuestionPeriod.ToList();
        }


        public ActionResult ExamShow(int ID)
        {
            QuestionBankDbContext Db = new QuestionBankDbContext();
            var model= Db.ExamQuestions.Where(x => x.ExamID.Equals(ID)).ToList();
            
            return View(Db.ExamQuestions.Where(x => x.ExamID.Equals(ID)).ToList()
);
        }

        public String Delete(int ID)
        {
            string message = string.Empty;
            using (QuestionBankDbContext Db = new QuestionBankDbContext())
            {
                Exam exam = Db.Exam.SingleOrDefault(x => x.ID.Equals(ID));
                if (exam != null)
                {
                    List<ExamQuestions> examquestions = Db.ExamQuestions.RemoveRange(Db.ExamQuestions.Where(x => x.ExamID.Equals(ID))).ToList();

                    Db.Exam.Remove(exam);

                    Db.SaveChanges();
                    message = JsonConvert.SerializeObject(new { durum = "OK", mesaj = "Sınav Silindi" });
                }
                else
                {
                    message = JsonConvert.SerializeObject(new { durum = "No", mesaj = "Sınav Silinemedi" });
                }
            }
            return message;
        }
       
    }
}