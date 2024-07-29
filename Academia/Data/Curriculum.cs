using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Curriculum
    {


        public async static Task<Entities.Curriculum> Create(Entities.Curriculum newCurriculum)
        {


            SqlConnection connection = Data.Util.GetConnection();
            try
            {
                using (connection)
                {

                    connection.Open();


                    //var sqlSelectArea = "SELECT * FROM especialidades WHERE especialidad_id = (@id);";

                    //using (SqlCommand command = new SqlCommand(sqlSelectArea, connection))
                    //{
                    //    command.Parameters.AddWithValue("@id", newCurriculum.IdArea);
                    //    command.ExecuteNonQuery();

                        var sqlInsertCurriculum = "INSERT INTO planes(desc_plan, id_especialidad, anio, resolucion) values(@description, @id_area,@anio, @resolucion) ;";
                        using (SqlCommand cmd = new SqlCommand(sqlInsertCurriculum, connection)) {
                            cmd.Parameters.AddWithValue("@description", newCurriculum.Description);
                            cmd.Parameters.AddWithValue("@id_area", newCurriculum.IdArea);
                            cmd.Parameters.AddWithValue("@anio", newCurriculum.Year);
                            cmd.Parameters.AddWithValue("@resolucion", newCurriculum.Resolution);
                        cmd.ExecuteNonQuery();
                            //se podria retornar el objeto con todas las props!!
                            return newCurriculum;
                        }


                    //}
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async static Task<List<Entities.Curriculum>> FindAll() {

            SqlConnection connection = Data.Util.GetConnection();



            try
            {
                using (connection)
                {
                    connection.Open();
                    var sql = "SELECT * FROM planes";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<Entities.Curriculum> curriculums = new List<Entities.Curriculum>();
                            while (reader.Read())
                            {
                                var area = await Data.Area.FindOne((int)reader["id_especialidad"]);
                                curriculums.Add(new Entities.Curriculum((int)reader["id_plan"], reader["desc_plan"].ToString(),area, (int)reader["anio"], reader["resolucion"].ToString())   
                                    
                                    )  ;

                            }
                            return curriculums;
                        }

                    }
                }

            }
            catch (Exception e)
            {
                throw e;
                return null;
            }
        }
    
        public async static Task<Entities.Curriculum> FindOne(int id) {

            SqlConnection connection = Data.Util.GetConnection();


            Entities.Curriculum curriculum = null;
            try
            {
                using (connection)
                {
                    connection.Open();
                    var sql = "SELECT * FROM planes WHERE id_plan = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var area = await Data.Area.FindOne((int)reader["id_especialidad"]);

                               
                                curriculum = (new Entities.Curriculum((int)reader["id_plan"], reader["desc_plan"].ToString(), area, (int)reader["anio"], reader["resolucion"].ToString())

                                    );

                            }
                                return curriculum;
                        }

                    }
                }

            }
            catch (Exception e)
            {

                throw e;
            }

        }


        public async static Task<int> Update(Entities.Curriculum updatedCurr)
        {


            SqlConnection conn = Data.Util.GetConnection();


            try
            {
                using (conn)
                {

                    conn.Open();

                    var sql = "UPDATE planes SET desc_plan = @description, id_especialidad=@id_area, anio=@year, resolucion=@resolution WHERE id_plan = @id;";


                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@id", updatedCurr.Id);
                        command.Parameters.AddWithValue("@description", updatedCurr.Description);
                        command.Parameters.AddWithValue("@id_area", updatedCurr.Area.IdArea);
                        command.Parameters.AddWithValue("@year", updatedCurr.Year);
                        command.Parameters.AddWithValue("@resolution", updatedCurr.Resolution);


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
                    var sql = "DELETE FROM planes WHERE id_plan = @id;";
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
