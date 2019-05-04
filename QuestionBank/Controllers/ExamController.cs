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
        public ActionResult Add(string SinavAdi,int[] periods)
        {
            if (SinavAdi=="" || periods==null)
            {
                PostUserLessonAndPeriod();
                ViewBag.ErrorMessage = "Lütfen Sınav adı belirleyin veya soru seçiniz...s";
                return View("Add");
            }
            return View();
        }
        [HttpPost]
        public ActionResult LessonPeriodQuestions(int DersID, int DonemID)
        {
            if (DersID == 0 || DonemID == 0)
            {
                PostUserLessonAndPeriod();
                ViewBag.ErrorMessage ="Hata! Lütfen ders ve soru dönemini seçiniz ";
                return View("Add");
            }
            else
            {
                QuestionBankDbContext Db = new QuestionBankDbContext();
                
                    PostUserLessonAndPeriod();
                    List<Question> questions = Db.Question.Where(x => x.Topic.LessonID.Equals(DersID) && x.QuestionPeriodID.Equals(DonemID)).ToList();
                    return View("Add", questions);
                


            }

        }
        private void PostUserLessonAndPeriod()
        {
            QuestionBankDbContext db = new QuestionBankDbContext();
            ViewBag.UserLessons = db.UserLesson.Where(x => x.User.UserName.Equals(User.Identity.Name)).ToList();
            ViewBag.QuestionPeriod = db.QuestionPeriod.ToList();
        }
    }
}