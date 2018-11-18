namespace QuestionBank.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinavSorulari")]
    public partial class SinavSorulari
    {
        public int ID { get; set; }

        public int SinavID { get; set; }

        public int SoruID { get; set; }

        public int Puan { get; set; }

        public virtual Sinav Sinav { get; set; }

        public virtual Soru Soru { get; set; }
    }
}
