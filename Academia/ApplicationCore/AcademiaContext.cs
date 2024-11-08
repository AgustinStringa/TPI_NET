using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Model;
using ApplicationCore.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ApplicationCore
{
	internal class AcademiaContext : DbContext
	{
		internal DbSet<Course> Courses { get; set; }
		internal DbSet<Subject> Subjects { get; set; }
		internal DbSet<Correlative> Correlatives { get; set; }
		internal DbSet<User> Users { get; set; }
		internal DbSet<Student> Students { get; set; }
		internal DbSet<Teacher> Teachers { get; set; }
		internal DbSet<Administrative> Administratives { get; set; }
		internal DbSet<Area> Areas { get; set; }
		internal DbSet<Curriculum> Curriculums { get; set; }
		internal DbSet<StudentCourse> UserCourses { get; set; }
		internal DbSet<Commission> Commissions { get; set; }


		private readonly string _connectionString = "";

		internal AcademiaContext()
		{
			var directory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent + "\\ApplicationCore\\";
			var configuration = new ConfigurationBuilder()
							.SetBasePath(directory)
							.AddJsonFile("appsettings.json")
							.Build();
			_connectionString = configuration.GetConnectionString("db-dev-database-first");
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
			modelBuilder.Entity<Student>().ToTable("estudiantes");
			modelBuilder.Entity<Teacher>().ToTable("docentes");
			modelBuilder.Entity<Teacher>().Property(t => t.TeacherId).Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore); //needed in order to update identity column (TeacherId)
			modelBuilder.Entity<Administrative>().ToTable("administrativos");

			modelBuilder.Entity<AcademicStatusItem>().HasNoKey();

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

			modelBuilder.Entity<Student>()
				.HasMany(u => u.StudentCourses)
				.WithOne(uc => uc.Student)
				.HasForeignKey(uc => uc.UserId);

			modelBuilder.Entity<Course>()
				.HasMany(c => c.StudentCourses)
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



			modelBuilder.Entity<Teacher>()
				.HasMany(u => u.TeacherCourses)
				.WithMany(c => c.Teachers)
				.UsingEntity<Dictionary<string, object>>(
					"docentes_cursos",
					j => j.HasOne<Course>().WithMany().HasForeignKey("id_curso"),
					j => j.HasOne<Teacher>().WithMany().HasForeignKey("id_docente")
				);

			//modelBuilder.Entity<Student>()
			//	.HasOne(u => u.)
			//	.WithMany(a => a.Curriculums)
			//	.HasForeignKey(c => c.AreaId);


			//modelBuilder.Entity<Commission>()
			//    .HasOne(c => c.Curriculum)
			//    .WithMany(a => a.Commissions)
			//    .HasForeignKey(a => a.Curriculum);
		}

	}
}
