namespace QuestionBank.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KonuSoruDonemi")]
    public partial class KonuSoruDonemi
    {
        public int ID { get; set; }

        public int KonuID { get; set; }

        public int SoruDonemiID { get; set; }

        public virtual Konu Konu { get; set; }

        public virtual SoruDonemi SoruDonemi { get; set; }
    }
}
