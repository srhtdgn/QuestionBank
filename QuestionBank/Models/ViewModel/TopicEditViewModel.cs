using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionBank.Models.ViewModel
{
    public class TopicEditViewModel
    {
        QuestionBankDbContext Db = new QuestionBankDbContext();
        public TopicEditViewModel(int ID)
        {
            topic = Db.Topic.Find(ID);
        }
        public Topic topic { get; set; }
    }
}