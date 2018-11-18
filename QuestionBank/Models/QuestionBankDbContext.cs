namespace QuestionBank.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuestionBankDbContext : DbContext
    {
        public QuestionBankDbContext()
            : base("name=QuestionBankDbContext")
        {
        }

        public virtual DbSet<Cevaplar> Cevaplar { get; set; }
        public virtual DbSet<Ders> Ders { get; set; }
        public virtual DbSet<Konu> Konu { get; set; }
        public virtual DbSet<KonuSoruDonemi> KonuSoruDonemi { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<KullaniciDers> KullaniciDers { get; set; }
        public virtual DbSet<Sinav> Sinav { get; set; }
        public virtual DbSet<SinavSorulari> SinavSorulari { get; set; }
        public virtual DbSet<Soru> Soru { get; set; }
        public virtual DbSet<SoruDonemi> SoruDonemi { get; set; }
        public virtual DbSet<SoruTipi> SoruTipi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ders>()
                .HasMany(e => e.Konu)
                .WithRequired(e => e.Ders)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ders>()
                .HasMany(e => e.KullaniciDers)
                .WithRequired(e => e.Ders)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Konu>()
                .HasMany(e => e.KonuSoruDonemi)
                .WithRequired(e => e.Konu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.KullaniciDers)
                .WithRequired(e => e.Kullanici)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sinav>()
                .HasMany(e => e.SinavSorulari)
                .WithRequired(e => e.Sinav)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Soru>()
                .HasMany(e => e.Cevaplar)
                .WithRequired(e => e.Soru)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Soru>()
                .HasMany(e => e.SinavSorulari)
                .WithRequired(e => e.Soru)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SoruDonemi>()
                .HasMany(e => e.KonuSoruDonemi)
                .WithRequired(e => e.SoruDonemi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SoruDonemi>()
                .HasMany(e => e.Soru)
                .WithRequired(e => e.SoruDonemi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SoruTipi>()
                .HasMany(e => e.Soru)
                .WithRequired(e => e.SoruTipi)
                .WillCascadeOnDelete(false);
        }
    }
}
