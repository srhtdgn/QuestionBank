namespace QuestionBank.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cevaplar")]
    public partial class Cevaplar
    {
        public int ID { get; set; }

        public int SoruID { get; set; }

        [Required]
        public string Cevap { get; set; }

        public bool DogruMu { get; set; }

        public virtual Soru Soru { get; set; }
    }
}
