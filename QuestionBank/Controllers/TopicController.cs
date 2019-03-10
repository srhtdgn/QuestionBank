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


        private void PostQuestionPeriod()
        {
            QuestionBankDbContext Db = new QuestionBankDbContext();
            ViewBag.QuestionPeriod = Db.QuestionPeriod.ToList();
        }


        public ActionResult Add()
        {
            PostUserLessons();
            PostQuestionPeriod();
            return View();
        }


        [HttpPost]
        public ActionResult Add(Topic model, int[] periods)
        {
            QuestionBankDbContext db = new QuestionBankDbContext();
            if (ModelState.IsValid)
            {
                db.Topic.Add(model);
                db.SaveChanges();

                List<TopicQuestionPeriod> lst = new List<TopicQuestionPeriod>();
                foreach (int item in periods)
                {
                    TopicQuestionPeriod konuSoruDonemi = new TopicQuestionPeriod
                    {
                        TopicID = model.ID,
                        QuestionPeriodID = item
                    };
                    lst.Add(konuSoruDonemi);
                }
                db.TopicQuestionPeriod.AddRange(lst);
                db.SaveChanges();
                ViewBag.Message = $"<div class='alert alert-success'><strong>Başarılı!</strong> Konu Başarıyla Eklendi... </div>";
                ModelState.Clear();
            }

            PostQuestionPeriod();
           PostUserLessons();

            return View(model);
        }
    }
}