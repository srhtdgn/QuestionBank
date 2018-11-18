namespace QuestionBank.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Soru")]
    public partial class Soru
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Soru()
        {
            Cevaplar = new HashSet<Cevaplar>();
            SinavSorulari = new HashSet<SinavSorulari>();
        }

        public int ID { get; set; }

        [Required]
        public string Sorular { get; set; }

        public int SoruTipiID { get; set; }

        public int SoruDonemiID { get; set; }

        public int KonuID { get; set; }

        [StringLength(50)]
        public string Foto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cevaplar> Cevaplar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SinavSorulari> SinavSorulari { get; set; }

        public virtual SoruDonemi SoruDonemi { get; set; }

        public virtual SoruTipi SoruTipi { get; set; }
    }
}
