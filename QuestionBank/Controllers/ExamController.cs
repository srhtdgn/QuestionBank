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
            QuestionBankDbContext db = new QuestionBankDbContext();

            ViewBag.UserLessons = db.UserLesson.Where(x => x.User.UserName.Equals(User.Identity.Name)).ToList();


            ViewBag.QuestionPeriod = db.QuestionPeriod.ToList();
            return View();
        }
    }
}