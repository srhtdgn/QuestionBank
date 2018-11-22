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

        public virtual DbSet<C_MigrationHistory> C_MigrationHistory { get; set; }
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<ExamQuestions> ExamQuestions { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionPeriod> QuestionPeriod { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<TopicQuestionPeriod> TopicQuestionPeriod { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserLesson> UserLesson { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>()
                .HasMany(e => e.ExamQuestions)
                .WithRequired(e => e.Exam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lesson>()
                .HasMany(e => e.Topic)
                .WithRequired(e => e.Lesson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lesson>()
                .HasMany(e => e.UserLesson)
                .WithRequired(e => e.Lesson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.ExamQuestions)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestionPeriod>()
                .HasMany(e => e.Question)
                .WithRequired(e => e.QuestionPeriod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestionPeriod>()
                .HasMany(e => e.TopicQuestionPeriod)
                .WithRequired(e => e.QuestionPeriod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestionType>()
                .HasMany(e => e.Question)
                .WithRequired(e => e.QuestionType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Topic>()
                .HasMany(e => e.TopicQuestionPeriod)
                .WithRequired(e => e.Topic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserLesson)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
