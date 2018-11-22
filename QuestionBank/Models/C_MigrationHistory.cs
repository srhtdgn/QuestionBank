namespace QuestionBank.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("_MigrationHistory")]
    public partial class C_MigrationHistory
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(150)]
        public string MigrationID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(300)]
        public string ContextKey { get; set; }

        [Required]
        public byte[] Model { get; set; }

        [Required]
        [StringLength(32)]
        public string ProductVersiyon { get; set; }
    }
}
