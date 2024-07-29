using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Subject
    {
        SqlConnection connection;

        private static SqlConnection GetConnection()
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

        public async static Task<Entities.Subject> Create(Entities.Subject newSubject)
        {

            SqlConnection connection = Data.Subject.GetConnection();
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

                        var sqlInsertSubject = "INSERT INTO materias(desc_materia, hs_semanales, hs_totales, id_plan) values(@description, @hs_semanales,@hs_totales, @id_plan) ;";
                        using (SqlCommand cmd = new SqlCommand(sqlInsertSubject, connection)) {
                            cmd.Parameters.AddWithValue("@description", newSubject.Description);
                            cmd.Parameters.AddWithValue("@id_plan", newSubject.IdPlan);
                            cmd.Parameters.AddWithValue("@hs_semanales", newSubject.WeekHours);
                            cmd.Parameters.AddWithValue("@hs_totales", newSubject.TotalHours);
                        cmd.ExecuteNonQuery();
                            //se podria retornar el objeto con todas las props!!
                            return newSubject;
                        }


                    //}
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async static Task<List<Entities.Subject>> FindAll() {
            SqlConnection connection = Data.Subject.GetConnection();


            try
            {
                using (connection)
                {
                    connection.Open();
                    var sql = "SELECT * FROM materias";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<Entities.Subject> subjects = new List<Entities.Subject>();
                            while (reader.Read())
                            {
                                var plan = await Data.Curriculum.FindOne((int)reader["id_plan"]);
                                subjects.Add(new Entities.Subject((int)reader["id_materia"], reader["desc_materia"].ToString(), plan, (int)reader["hs_semanales"], (int)reader["hs_totales"])   
                                    
                                    )  ;

                            }
                            return subjects;
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
    
        public async static Task<Entities.Subject> FindOne(int id) {
            SqlConnection connection = Data.Subject.GetConnection();

            Entities.Subject subject = null;
            try
            {
                using (connection)
                {
                    connection.Open();
                    var sql = "SELECT * FROM materias WHERE id_materia = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var plan = await Data.Curriculum.FindOne((int)reader["id_plan"]);

                               
                                subject = (new Entities.Subject((int)reader["id_materia"], reader["desc_materia"].ToString(), plan, (int)reader["hs_semanales"], (int)reader["hs_totales"])

                                    );

                            }
                                return subject;
                        }

                    }
                }

            }
            catch (Exception e)
            {

                throw e;
            }

        }


        public async static Task<int> Update(Entities.Subject updatedCurr)
        {

            SqlConnection conn = Data.Subject.GetConnection();

            try
            {
                using (conn)
                {

                    conn.Open();

                    var sql = "UPDATE materias SET desc_materia = @desc_materia, id_plan=@id_plan, hs_semanales=@hs_semanales, hs_totales=@hs_totales WHERE id_materia = @id;";


                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@id", updatedCurr.Id);
                        command.Parameters.AddWithValue("@desc_materia", updatedCurr.Description);
                        command.Parameters.AddWithValue("@id_plan", updatedCurr.Curriculum.Id);
                        command.Parameters.AddWithValue("@hs_totales", updatedCurr.TotalHours);
                        command.Parameters.AddWithValue("@hs_semanales", updatedCurr.WeekHours);


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
            SqlConnection connection = Data.Subject.GetConnection();
            try
            {
                using (connection)
                {
                    connection.Open();
                    var sql = "DELETE FROM materias WHERE id_materia = @id;";
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
