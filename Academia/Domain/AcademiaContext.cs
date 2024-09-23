using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    internal class AcademiaContext : DbContext
    {
        internal DbSet<Course> Courses { get; set; }
        internal DbSet<Subject> Subjects { get; set; }
        internal DbSet<Correlative> Correlatives { get; set; }
        internal DbSet<User> Users { get; set; }
        internal DbSet<Area> Areas { get; set; }
        internal DbSet<Curriculum> Curriculums { get; set; }
        internal DbSet<UserCourse> UserCourses { get; set; }
        internal DbSet<Commission> Commissions { get; set; }


        private readonly string _connectionString = "";

        internal AcademiaContext()
        {

            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //builder.DataSource = "DESKTOP-1T6I08B";
            //builder.UserID = @"DESKTOP-1T6I08B\agust";
            //builder.TrustServerCertificate = true;
            //builder.IntegratedSecurity = true;
            //builder.InitialCatalog = "net-tpi";
            //_connectionString = builder.ConnectionString;
            _connectionString = @"Data Source=ELISITO\SQLEXPRESS;Initial Catalog=academia;Integrated Security=True;TrustServerCertificate=True;";

            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curriculum>()
                .HasOne(c => c.Area)
                .WithMany(a => a.Curriculums)
                .HasForeignKey(c => c.AreaId);

            modelBuilder.Entity<Subject>()
                .HasOne(s => s.Curriculum)
                .WithMany(c => c.Subjects)
                .HasForeignKey(s => s.IdCurriculum);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Subject)
                .WithMany(s => s.Courses)
                .HasForeignKey(c => c.IdSubject);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserCourses)
                .WithOne(uc => uc.User)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.UserCourses)
                .WithOne(uc => uc.Course)
                .HasForeignKey(uc => uc.CourseId);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.CorrelativesChildren)
                .WithOne(c => c.Subject)
                .HasForeignKey(c => c.SubjectId);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.CorrelativesParents)
                .WithOne(c => c.CorrelativeSubject)
                .HasForeignKey(c => c.CorrelativeId);

            modelBuilder.Entity<Commission>()
                .HasMany(c => c.Courses)
                .WithOne(c => c.Commission)
                .HasForeignKey(c => c.IdCommission);

            //modelBuilder.Entity<Commission>()
            //    .HasOne(c => c.Curriculum)
            //    .WithMany(a => a.Commissions)
            //    .HasForeignKey(a => a.Curriculum);
        }

    }
}
