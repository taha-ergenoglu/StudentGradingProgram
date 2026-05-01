using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingProgram.Model
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamScore> ExamScores{ get; set; }
        public DbSet<ExamTableColumnsHeading> ExamTableColumnsHeadings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Programın çalıştığı dizinde (bin/Debug veya uygulamanın kurulu olduğu yer)
            // 'StudentGradingProgram.db' adında bir dosya oluşturur.
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StudentGradingProgram.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
