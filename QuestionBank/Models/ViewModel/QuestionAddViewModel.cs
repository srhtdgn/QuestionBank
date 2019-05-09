using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionBank.Models.ViewModel
{
    public class QuestionAddViewModel
    {
        public int TopicID { get; set; }
        public int PeriodID { get; set; }
        public int QuestionTypeID { get; set; }
        public string Question { get; set; }
        public Answer[] Answers { get; set; }
        public HttpPostedFileBase image { get ; set; }

        public class Answer
        {
            public bool Val { get; set; }
            public string AnswerContent { get; set; }
        }
    }
}