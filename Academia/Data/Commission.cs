using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Entities;

namespace Data
{
    public class Commission
    {
        SqlConnection conn;
        private static SqlConnection GetConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-L1E8H85\\SQLEXPRESS";
            builder.UserID = @"eugen";
            //builder.Password = "<your_password>";
            builder.InitialCatalog = "academia";
            builder.TrustServerCertificate = true;
            builder.IntegratedSecurity = true;

            return new SqlConnection(builder.ConnectionString);
        }

        public async static Task<Entities.Commission> Create(Entities.Commission newCommission)
        {

            SqlConnection connection = Data.Commission.GetConnection();
            try
            {
                using (connection)
                {

                    connection.Open();

                    var sql = "insert into comisiones(desc_comision, anio_especialidad) values (@description, @year);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@description", newCommission.Description);
                        command.Parameters.AddWithValue("@year", newCommission.Year);
                        command.ExecuteNonQuery();
                        return newCommission;
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async static Task<Entities.Commission> FindOne(int id)
        {
            SqlConnection connection = Data.Commission.GetConnection();

            Entities.Commission commission = null;
            try
            {
                using (connection)
                {
                    connection.Open();
                    var sql = "SELECT * FROM comisiones WHERE id_comision = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                commission = new Entities.Commission(reader["desc_comision"].ToString(), Int32.Parse((reader["anio_especialidad"].ToString())), Int32.Parse(reader["id_comision"].ToString()));

                            }
                            return commission;
                        }

                    }
                }

            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public async static Task<List<Entities.Commission>> FindAll()
        {
            SqlConnection connection = Data.Commission.GetConnection();


            try
            {
                using (connection)
                {
                    connection.Open();
                    var sql = "SELECT * FROM comisiones";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<Entities.Commission> commission = new List<Entities.Commission>();
                            while (reader.Read())
                            {
                                commission.Add(new Entities.Commission(reader["desc_comision"].ToString(), Int32.Parse((reader["anio_especialidad"].ToString())), Int32.Parse((reader["id_comision"].ToString()))));

                            }
                            return commission;
                        }

                    }
                }

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async static Task<int> Update(Entities.Commission updatedCommission)
        {

            SqlConnection connection = Data.Commission.GetConnection();

            try
            {
                using (connection)
                {

                    connection.Open();

                    var sql = "UPDATE comisiones SET desc_comisiones = @description, anio_especialidad = @year WHERE id_comision = @id;";


                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@description", updatedCommission.Description);
                        command.Parameters.AddWithValue("@year", updatedCommission.Year);
                        command.Parameters.AddWithValue("@id", updatedCommission.IdCommission);

                        return command.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async static Task<int> Delete(int id)
        {
            SqlConnection connection = Data.Commission.GetConnection();
            try
            {
                using (connection)
                {
                    connection.Open();
                    var sql = "DELETE FROM comisiones WHERE id_comision = @id;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        return command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }

}
