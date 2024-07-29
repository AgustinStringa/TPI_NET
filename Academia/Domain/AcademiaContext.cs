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
        internal DbSet<User> Users { get; set; }

        private readonly string _connectionString = "";

        internal AcademiaContext() {

            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //builder.DataSource = "DESKTOP-1T6I08B";
            //builder.UserID = @"DESKTOP-1T6I08B\agust";
            //builder.TrustServerCertificate = true;
            //builder.IntegratedSecurity = true;
            //builder.InitialCatalog = "net-tpi";
            //_connectionString = builder.ConnectionString;
            _connectionString = "Data Source=DESKTOP-1T6I08B;Initial Catalog=academia;Integrated Security=True;TrustServerCertificate=True;\r\n";
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
