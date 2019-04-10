namespace QuestionBank.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            UserLesson = new HashSet<UserLesson>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string SurName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Mail { get; set; }


        private string photo;
        [StringLength(50)]
        public string Photo
        {
            get
            {
                if (string.IsNullOrWhiteSpace(photo))
                {
                    return "no_image.png";
                }
                return photo;
            }
            set { photo = value; }
        }

        public bool IsItAdmin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserLesson> UserLesson { get; set; }
        [NotMapped]
        public string NewPassword { get; set; }


        [NotMapped]
        [Compare("NewPassword")]
        public string NewPasswordAgain { get; set; }
        public static object Identity { get; internal set; }
    }
}
