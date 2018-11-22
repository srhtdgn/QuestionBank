namespace QuestionBank.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            Answers = new HashSet<Answers>();
            ExamQuestions = new HashSet<ExamQuestions>();
        }

        public int ID { get; set; }

        [Column("Question")]
        [Required]
        public string Question1 { get; set; }

        public int QuestionTypeID { get; set; }

        public int QuestionPeriodID { get; set; }

        public int TopicID { get; set; }

        [StringLength(50)]
        public string Photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answers> Answers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamQuestions> ExamQuestions { get; set; }

        public virtual QuestionPeriod QuestionPeriod { get; set; }

        public virtual QuestionType QuestionType { get; set; }
    }
}
