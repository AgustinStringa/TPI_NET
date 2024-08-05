using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Util
    {
        public static SqlConnection GetConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"ELISITO\SQLEXPRESS";
            builder.UserID = @"Elisito\elias";
            //builder.Password = "<your_password>";
            builder.InitialCatalog = "academia";
            builder.TrustServerCertificate = true;
            builder.IntegratedSecurity = true;

            return new SqlConnection(builder.ConnectionString);
        }
    }
}
