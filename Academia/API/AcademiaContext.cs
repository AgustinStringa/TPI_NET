using ApplicationCore.Model;
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
        public DbSet<Student> Users { get; set; } = null!;
        public DbSet<Commission> Commissions { get; set; } = null!;
        public DbSet<StudentCourse> StudentCourses { get; set; } = null!;

        private string _connectionString = "";
        public AcademiaContext()
        {
            var configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();
            _connectionString = configuration.GetConnectionString("AcademiaDevConnectionString");         
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			optionsBuilder
	            .LogTo(Console.WriteLine, LogLevel.Debug)
	            .EnableDetailedErrors()
	            .EnableSensitiveDataLogging();
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
