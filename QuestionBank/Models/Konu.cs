namespace QuestionBank.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Konu")]
    public partial class Konu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Konu()
        {
            KonuSoruDonemi = new HashSet<KonuSoruDonemi>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string KonuAdi { get; set; }

        public int DersID { get; set; }

        public virtual Ders Ders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KonuSoruDonemi> KonuSoruDonemi { get; set; }
    }
}
