using Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Data
{
    public class Area
    {
        SqlConnection conn;

        private static SqlConnection GetConnection() {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-1T6I08B";
            builder.UserID = @"DESKTOP-1T6I08B\agust";
            //builder.Password = "<your_password>";
            builder.InitialCatalog = "academia";
            builder.TrustServerCertificate = true;
            builder.IntegratedSecurity = true;

            return new SqlConnection(builder.ConnectionString);
        }
        public async static Task<Entities.Area> Create(Entities.Area newArea)
        {
            
            SqlConnection connection = Data.Area.GetConnection();
            try
            {
                using (connection)
                {

                    connection.Open();

                    var sql = "insert into especialidades(desc_especialidad) values (@name);";
                    
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", newArea.Name);
                        command.ExecuteNonQuery();
                        return newArea;
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            } 

        }
        public async static Task<Entities.Area> FindOne(int id) {
            SqlConnection connection = Data.Area.GetConnection();

            Entities.Area area = null;
            try
            {
                using (connection)
                {
                    connection.Open();
                    var sql = "SELECT * FROM especialidades WHERE id_especialidad = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                           
                                area = new Entities.Area(reader["desc_especialidad"].ToString(),
                                    Int32.Parse(reader["id_especialidad"].ToString())
                                    );

                            }
                                return area;
                        }

                    }
                }

            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public async static Task<List<Entities.Area>> FindAll()
        {
            SqlConnection connection = Data.Area.GetConnection();


            try
            {
                using (connection)
                {
                    connection.Open();
                    var sql = "SELECT * FROM especialidades";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<Entities.Area> areas = new List<Entities.Area>();
                            while (reader.Read())
                            {
                                areas.Add(new Entities.Area(reader["desc_especialidad"].ToString(), Int32.Parse((reader["id_especialidad"].ToString()))));

                            }
                            return areas;
                        }

                    }
                }

            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public async static Task<int> Update(Entities.Area updatedArea) {
           
            SqlConnection connection = Data.Area.GetConnection();

            try
            {
                using (connection)
                {

                    connection.Open();

                    var sql = "UPDATE especialidades SET desc_especialidad = @name WHERE id_especialidad = @id;";


                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", updatedArea.Name);
                        command.Parameters.AddWithValue("@id", updatedArea.IdArea);

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
            SqlConnection connection = Data.Area.GetConnection();
            try
            {
                using (connection)
                {
                    connection.Open();
                    var sql = "DELETE FROM especialidades WHERE id_especialidad = @id;";
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
