namespace QuestionBank.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       
        public Kullanici()
        {
            KullaniciDers = new HashSet<KullaniciDers>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string KullaniciAdi { get; set; }

        
        [StringLength(50)]
        public string Adi { get; set; }

       
        [StringLength(50)]
        public string Soyadi { get; set; }

        [Required]
        [StringLength(50)]
        public string Sifre { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Mail { get; set; }


        public string foto;
        [StringLength(50)]
        public string Foto
        {
            get
            {
                if (string.IsNullOrWhiteSpace(foto))
                {
                    return "no_image.png";
                }
                return foto;
            }
            set { foto = value; }
        }


        public bool YoneticiMi { get; set; }

       
        public virtual ICollection<KullaniciDers> KullaniciDers { get; set; }

  

        [NotMapped]
        public string YeniSifre { get; set; }

        [NotMapped]
        [Compare("YeniSifre")]
        public string YeniSifreTekrar { get; set; }
    }
}
