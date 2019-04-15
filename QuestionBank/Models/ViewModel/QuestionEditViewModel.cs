using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestionBank.Models.ViewModel
{
    public class QuestionEditViewModel
    {
       
            QuestionBankDbContext Db = new QuestionBankDbContext();

            public QuestionEditViewModel (int ID)
            {


                question = Db.Question.Find(ID);
                Topics = question.Topic.Lesson.Topic;
                Types = Db.QuestionType.ToList();
            }

            public IEnumerable<Lesson> Lessons { get; set; }
            public IEnumerable<Topic> Topics { get; set; }
            public IEnumerable<QuestionType> Types { get; set; }

 
            public Question question { get; set; }




        
    }
}