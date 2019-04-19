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
            List<UserLesson> ders;
            QuestionBankDbContext db = new QuestionBankDbContext();
            ders = db.UserLesson.Where(x => x.User.UserName.Equals(User.Identity.Name)).ToList();
            return View(ders);

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
                if (db.Topic.SingleOrDefault(x=>x.TopicName.Equals(model.TopicName))==null)
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
                else
                {
                    ViewBag.Message = $"<div class='alert alert-danger'><strong>Hata! </strong>{model.TopicName}  konusu zaten mevcuttur... </div>";
                }

            }

            PostQuestionPeriod();
            PostUserLessons();

            return View(model);
        }

        public ActionResult LessonTopicsList(int LessonID)
        {
            QuestionBankDbContext Db = new QuestionBankDbContext();
            List<Topic> lsttopics = Db.Topic.ToList();
            if (LessonID == 0)
            {

                lsttopics = null;
                return PartialView(lsttopics);
            }
            else
            {


                lsttopics = Db.Topic.Where(x => x.LessonID == LessonID).ToList();
                return PartialView(lsttopics);
            }

        }

        [HttpPost]
        public string Delete(int ID)
        {
            string message = string.Empty;
            using (QuestionBankDbContext Db = new QuestionBankDbContext())
            {
                Topic topic = Db.Topic.SingleOrDefault(x => x.ID.Equals(ID));
                if (topic != null)
                {
                    List<TopicQuestionPeriod> periods = Db.TopicQuestionPeriod.RemoveRange(Db.TopicQuestionPeriod.Where(x=>x.TopicID.Equals(ID))).ToList();

                    Db.TopicQuestionPeriod.RemoveRange(periods);
                    Db.Topic.Remove(topic);
                    Db.SaveChanges();
                    message = JsonConvert.SerializeObject(new { durum = "OK", mesaj = "Konu Silindi" });
                }
                else
                {
                    message = JsonConvert.SerializeObject(new { durum = "No", mesaj = "Konu Silinemedi" });
                }
            }
            return message;
        }
    }
}