using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionBank.Models.ViewModel
{
    public class ExamListAndAddViewModel
    {
       
        public List<UserLesson> dersler { get; set; }
        public List<QuestionPeriod> donemler { get; set; }
    }
}