namespace QuestionBank.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Answers
    {
        public int ID { get; set; }

        public int QuestionID { get; set; }

        [Required]
        public string Answer { get; set; }

        public bool IsItTrue { get; set; }

        public virtual Question Question { get; set; }
    }
}
