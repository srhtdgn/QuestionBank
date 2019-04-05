using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionBank.Models.ViewModel
{
    public class QuestionAddJsonModel
    {
        public int TopicID { get; set; }
        public string TopicName { get; set; }
        public List<PeriodJson> Period = new List<PeriodJson>();



        public class PeriodJson
        {
            public int PeriodID { get; set; }
            public string PeriodName { get; set; }
        }
    }
}