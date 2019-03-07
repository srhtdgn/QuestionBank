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
    [SelectedTab("Topic")]
    public class TopicController : BaseController
    {
        // GET: Topic
        public ActionResult Index()
        {
            PostUserLessons();
            return View();


        }

        [HttpPost]
        public ActionResult Index(int LessonID)
        {
            if (LessonID == 0)
            {
                PostUserLessons();
                ViewBag.lsttopic = null;             
            }
            else
            {
                PostUserLessons();
                QuestionBankDbContext Db = new QuestionBankDbContext();
            
                ViewBag.lsttopic = Db.Topic.Where(x => x.LessonID == LessonID).ToList();             
            }
            return View();
        }
        private void PostUserLessons()
        {
            QuestionBankDbContext Db = new QuestionBankDbContext();

            User user = Db.User.SingleOrDefault(x => x.UserName.Equals(User.Identity.Name));

            ViewBag.UserLessons = Db.UserLesson.Where(x => x.UserID.Equals(user.ID)).ToList();

        }
    }
}