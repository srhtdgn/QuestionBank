using Newtonsoft.Json;
using QuestionBank.Infrastructure;
using QuestionBank.Models;
using QuestionBank.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static QuestionBank.Models.ViewModel.QuestionAddJsonModel;

namespace QuestionBank.Controllers
{
    public class QuestionController : BaseController
    {
        // GET: Question

        [SelectedTab("Questions")]
        public ActionResult Index()
        {

            QuestionBankDbContext Db = new QuestionBankDbContext();
            List<Question> questions = Db.Question.ToList();
            User user = Db.User.SingleOrDefault(x => x.UserName.Equals(User.Identity.Name));
            int[] userLessons = Db.UserLesson.Where(x => x.UserID.Equals(user.ID)).Select(x => x.LessonID).ToArray();
            questions = questions.Where(x => userLessons.Contains(x.Topic.LessonID)).ToList();
            return View(questions);
        }
        public ActionResult Add()
        {
            QuestionBankDbContext Db = new QuestionBankDbContext();
            List<Lesson> lst = Db.Lesson.ToList();

            int[] userLessons = Db.UserLesson.Where(x => x.User.UserName.Equals(User.Identity.Name)).Select(x => x.LessonID).ToArray();

            lst = Db.Lesson.Where(x => userLessons.Contains(x.ID)).ToList();

            return View(lst);
        }

        [HttpPost]
        public string GetLessonsTopic(int ID)
        {
            QuestionBankDbContext db = new QuestionBankDbContext();
            List<Topic> lst = db.Topic.Where(x => x.LessonID.Equals(ID)).ToList();

            List<QuestionAddJsonModel> jsonLst = new List<QuestionAddJsonModel>();

            foreach (var lesson in lst)
            {
                QuestionAddJsonModel model = new QuestionAddJsonModel();
                model.TopicID = lesson.ID;
                model.TopicName = lesson.TopicName;
                foreach (var item in lesson.TopicQuestionPeriod)
                {
                    PeriodJson periodJson = new PeriodJson();
                    periodJson.PeriodID = item.QuestionPeriod.ID;
                    periodJson.PeriodName = item.QuestionPeriod.QuestionPeriodName;
                    model.Period.Add(periodJson);
                }
                jsonLst.Add(model);

            }
            return JsonConvert.SerializeObject(jsonLst);

        }


        [HttpPost]
        public string Delete(int ID)
        {
            string message = string.Empty;
            using (QuestionBankDbContext Db = new QuestionBankDbContext())
            {
                List<Answers> lst = Db.Answers.Where(x => x.QuestionID.Equals(ID)).ToList();
                Db.Answers.RemoveRange(lst);

                Question question = Db.Question.SingleOrDefault(x => x.ID.Equals(ID));
                if (question != null)
                {
                    Db.Question.Remove(question);
                    Db.SaveChanges();
                    message = JsonConvert.SerializeObject(new { durum = "OK", mesaj = "Soru Silindi" });
                }
                else
                {
                    message = JsonConvert.SerializeObject(new { durum = "No", mesaj = "Soru Silinemedi" });
                }
            }
            return message;
        }

        [HttpPost]
        public string AddQuestion(QuestionAddViewModel model)
        {
            Question question = new Question
            {
                Question1 = model.Question,
                QuestionTypeID = model.QuestionTypeID,
                QuestionPeriodID = model.PeriodID,
                TopicID = model.TopicID
            };
            QuestionBankDbContext Db = new QuestionBankDbContext();
            Db.Question.Add(question);
            Db.SaveChanges();
            List<Answers> lst = new List<Answers>();
            foreach (var item in model.Answers)
            {
                Answers answers = new Answers
                {
                    QuestionID = question.ID,
                    Answer = item.AnswerContent,
                    IsItTrue = item.Val
                };
                lst.Add(answers);
            }
            Db.Answers.AddRange(lst);
            Db.SaveChanges();

            return JsonConvert.SerializeObject(new { durum = "OK", mesaj = "Soru başarıyla eklendi" });
        }
        public ActionResult Edit(int ID)
        {

            var model = new QuestionEditViewModel(ID);

            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(Question question, string txtdogrucevap, string[] txtyanliscevap)
        {

           
                QuestionBankDbContext Db = new QuestionBankDbContext();
                Question soru = Db.Question.SingleOrDefault(x => x.ID.Equals(question.ID));

                soru.TopicID = question.TopicID;
                soru.QuestionTypeID = question.QuestionTypeID;
                soru.Question1 = question.Question1;

                List<Answers> Silinecekler = Db.Answers.Where(x => x.QuestionID.Equals(question.ID)).ToList();
                Db.Answers.RemoveRange(Silinecekler);
                Db.Answers.Add(new Answers() { Answer = txtdogrucevap, QuestionID = question.ID, IsItTrue = true });
                if (txtyanliscevap != null)
                {
                    foreach (var item in txtyanliscevap)
                    {

                        Db.Answers.Add(new Answers() { Answer = item.ToString(), QuestionID = question.ID });

                    }
                }


                Db.SaveChanges();
                var model = new QuestionEditViewModel(soru.ID);
       
                ViewBag.Message = $"<div class='alert alert-success'><strong> Soru Başarıyla güncellendi...</strong> </div>";
                return View(model);

        }

    }
}
