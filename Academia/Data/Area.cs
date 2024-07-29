using Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace Data
{
    public class Area
    {

        public async static Task<Entities.Area> Create(Entities.Area newArea)
        {
            
            SqlConnection connection = Data.Util.GetConnection();
            try
            {
                using (connection)
                {

                    connection.Open();

                    var sql = "insert into especialidades(desc_especialidad) values (@description);";
                    
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@description", newArea.Description);
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
            SqlConnection connection = Data.Util.GetConnection();

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

        public async static Task<Entities.Area> FindOne(string description) {
            SqlConnection connection = Data.Util.GetConnection();

            Entities.Area area = null;
            try
            {
                using (connection)
                {
                    connection.Open();
                    var sql = "SELECT * FROM especialidades WHERE desc_especialidad = @description";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@description", description);
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
            SqlConnection connection = Data.Util.GetConnection();


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
           
            SqlConnection connection = Data.Util.GetConnection();

            try
            {
                using (connection)
                {

                    connection.Open();

                    var sql = "UPDATE especialidades SET desc_especialidad = @description WHERE id_especialidad = @id;";


                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@description", updatedArea.Description);
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
            SqlConnection connection = Data.Util.GetConnection();
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

        public static async Task<List<Entities.Curriculum>> GetCurriculums(Entities.Area area)
        {

            SqlConnection connection = Data.Util.GetConnection();


            try
            {
                using (connection)
                {
                    connection.Open();
                    var sql = "SELECT planes.* from planes INNER JOIN especialidades ON planes.id_especialidad = especialidades.id_especialidad WHERE especialidades.id_especialidad = @idArea;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@idArea", area.IdArea);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<Entities.Curriculum> curr = new List<Entities.Curriculum>();
                            while (reader.Read())
                            {
                                curr.Add(new Entities.Curriculum(Int32.Parse(reader["id_plan"].ToString()), reader["desc_plan"].ToString(), null, Int32.Parse(reader["anio"].ToString()), reader["resolucion"].ToString()  ));

                            }
                            return curr;
                        }

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
