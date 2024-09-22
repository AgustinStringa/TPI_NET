using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace API
{
    public class AcademiaContext : DbContext
    {
        public DbSet<Area> Areas { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Curriculum> Curriculums { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
<<<<<<< HEAD
        public DbSet<Commission> Commissions { get; set; } = null!;
=======
        public DbSet<UserCourse> UserCourses { get; set; } = null!;
>>>>>>> d6204c7f98f08b2ef5d0ebde6794592f57b801e0

        private string _connectionString = "";
        public AcademiaContext()
        {
<<<<<<< HEAD
            _connectionString = "Data Source=DESKTOP-L1E8H85\\SQLEXPRESS;Initial Catalog=academia;Integrated Security=True;TrustServerCertificate=True\r\n";
=======

            var configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();
            _connectionString = configuration.GetConnectionString("AcademiaDevConnectionString");         
>>>>>>> d6204c7f98f08b2ef5d0ebde6794592f57b801e0
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>()
                .HasMany(s => s.CorrelativesChildren)
                .WithOne(c => c.Subject)
                .HasForeignKey(c => c.SubjectId);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.CorrelativesParents)
                .WithOne(c => c.CorrelativeSubject)
                .HasForeignKey(c => c.CorrelativeId);
        }
    }
}
