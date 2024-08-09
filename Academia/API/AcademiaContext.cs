using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class AcademiaContext : DbContext
    {
        public DbSet<Area> Areas { get; set; } = null!;
        public DbSet<Curriculum> Curriculums { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        private string _connectionString = "";
        public AcademiaContext()
        {
            _connectionString = "Data Source=DESKTOP-1T6I08B;Initial Catalog=academia;Integrated Security=True;TrustServerCertificate=True;\r\n";
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
