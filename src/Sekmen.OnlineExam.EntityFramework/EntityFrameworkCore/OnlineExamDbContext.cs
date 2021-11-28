using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sekmen.OnlineExam.Authorization.Roles;
using Sekmen.OnlineExam.Authorization.Users;
using Sekmen.OnlineExam.Exams;
using Sekmen.OnlineExam.MultiTenancy;

namespace Sekmen.OnlineExam.EntityFrameworkCore
{
    public class OnlineExamDbContext : AbpZeroDbContext<Tenant, Role, User, OnlineExamDbContext>
    {
        public OnlineExamDbContext(DbContextOptions<OnlineExamDbContext> options) : base(options)
        {
        }

        /* Define a DbSet for each entity of the application */
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Exam>(b =>
            {
                b.ToTable(OnlineExamConsts.DbTablePrefix + "Exams");
                b.Property(m => m.Name).IsRequired();
                b.Property(m => m.Description).IsRequired();
            });
            modelBuilder.Entity<Question>(b =>
            {
                b.ToTable(OnlineExamConsts.DbTablePrefix + "ExamQuestions");
                b.Property(m => m.Name).IsRequired();
            });
            modelBuilder.Entity<Answer>(b =>
            {
                b.ToTable(OnlineExamConsts.DbTablePrefix + "ExamQuestionAnswers");
                b.Property(m => m.Name).IsRequired();
            });
        }
    }
}
