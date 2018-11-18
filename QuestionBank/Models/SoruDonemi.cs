namespace QuestionBank.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SoruDonemi")]
    public partial class SoruDonemi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SoruDonemi()
        {
            KonuSoruDonemi = new HashSet<KonuSoruDonemi>();
            Soru = new HashSet<Soru>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(9)]
        public string SoruDonemiAdı { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KonuSoruDonemi> KonuSoruDonemi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Soru> Soru { get; set; }
    }
}
