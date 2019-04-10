using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionBank.Models.ViewModel
{
    
    public class QuestionEditViewModel
    {
        QuestionBankDbContext Db = new QuestionBankDbContext();

        public QuestionEditViewModel(int ID)
        {
            
            
            question = Db.Question.Find(ID);
            Topics = question.Topic.Lesson.Topic;        
            Types = Db.QuestionType.ToList();
        }
        public IEnumerable<Lesson> Lessons { get; set; }
        public IEnumerable<Topic> Topics { get; set; }
        public IEnumerable<QuestionType> Types { get; set; }


        public Question question { get; set; }

  

        //public Answer[] Answers { get; set; }

        //public class Answer
        //{
        //    public bool Val { get; set; }
        //    public string AnswerContent { get; set; }
        //}


    }
}