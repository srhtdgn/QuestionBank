namespace QuestionBank.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Topic")]
    public partial class Topic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Topic()
        {
            TopicQuestionPeriod = new HashSet<TopicQuestionPeriod>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TopicName { get; set; }

        public int LessonID { get; set; }

        public virtual Lesson Lesson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TopicQuestionPeriod> TopicQuestionPeriod { get; set; }
    }
}
