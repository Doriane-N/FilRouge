using FilRouge.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DataAccessLayer.Context
{
    public class FilRougeContext : DbContext
    {

        public FilRougeContext() : base("FilRougeContext")
        {

        }

        internal DbSet<Answer> Answers { get; set; }
        internal DbSet<AnswerPercentLevel> AnswerPercentLevels { get; set; }
        internal DbSet<Candidate> Candidates { get; set; }
        internal DbSet<DifficultyLevel> DifficultyLevels { get; set; }
        internal DbSet<Question> Questions { get; set; }
        internal DbSet<Quizz> Quizzs { get; set; }
        internal DbSet<RecruitmentAgent> RecruitmentAgents { get; set; }
        internal DbSet<Report> Reports { get; set; }
        internal DbSet<User> Users { get; set; }

        //Disable Delete on cascade for Difficulty Level
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quizz>()
                .HasOptional(q => q.DifficultyLevel)
                .WithOptionalDependent()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Candidate>()
                .HasOptional(c => c.DifficultyLevel)
                .WithOptionalDependent()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Question>()
                .HasOptional(q => q.DifficultyLevel)
                .WithOptionalDependent()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<AnswerPercentLevel>()
                .HasOptional(a => a.DifficultyLevel)
                .WithOptionalDependent()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RecruitmentAgent>()
                .HasOptional(r => r.User)
                .WithOptionalDependent()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Candidate>()
                .HasOptional(c => c.User)
                .WithOptionalDependent()
                .WillCascadeOnDelete(false);
        }

    }
}
