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
            builder.DataSource = "DESKTOP-1T6I08B";
            builder.UserID = @"DESKTOP-1T6I08B\agust";
            //builder.Password = "<your_password>";
            builder.InitialCatalog = "academia";
            builder.TrustServerCertificate = true;
            builder.IntegratedSecurity = true;

            return new SqlConnection(builder.ConnectionString);
        }
    }
}
