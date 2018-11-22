namespace QuestionBank.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TopicQuestionPeriod")]
    public partial class TopicQuestionPeriod
    {
        public int ID { get; set; }

        public int TopicID { get; set; }

        public int QuestionPeriodID { get; set; }

        public virtual QuestionPeriod QuestionPeriod { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
