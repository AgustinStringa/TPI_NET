using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public  class Administrative
    {

        public async static Task<Entities.Administrative> Create(Entities.Administrative newAdministrative)
        {

            SqlConnection connection = Data.Util.GetConnection();
            try
            {
                using (connection)
                {

                    connection.Open();

                    var sql = "INSERT INTO usuarios(nombre_usuario, clave, nombre, apellido, direccion, email, telefono, fecha_nacimiento, cuit) " +
                        "VALUES  (@nombre_usuario, @clave, @nombre, @apellido, @direccion, @email, @telefono, @fecha_nacimiento, @cuit);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@nombre_usuario", newAdministrative.Username);
                        command.Parameters.AddWithValue("@clave", newAdministrative.Password);
                        command.Parameters.AddWithValue("@nombre", newAdministrative.Name);
                        command.Parameters.AddWithValue("@apellido", newAdministrative.LastName);
                        command.Parameters.AddWithValue("@direccion", newAdministrative.Address);
                        command.Parameters.AddWithValue("@email", newAdministrative.Email);
                        command.Parameters.AddWithValue("@telefono", newAdministrative.PhoneNumber);
                        command.Parameters.AddWithValue("@fecha_nacimiento", newAdministrative.BirthDate);
                        command.Parameters.AddWithValue("@cuit", newAdministrative.Cuit);
                        command.ExecuteNonQuery();
                        return newAdministrative;
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public async static Task<Entities.Administrative> FindOne(int id)
        {
            SqlConnection connection = Data.Util.GetConnection();

            Entities.Administrative administrative = null;
            try
            {
                using (connection)
                {
                    connection.Open();
                    var sql = "SELECT * FROM usuarios WHERE id_usuario = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                administrative = new Entities.Administrative(
                                    reader["nombre_usuario"].ToString(),
                                    reader["clave"].ToString(),
                                    reader["email"].ToString(),
                                    reader["nombre"].ToString(),
                                    reader["apellido"].ToString(),
                                    reader["direccion"].ToString(),
                                    reader["telefono"].ToString(),
                                    DateTime.Parse(reader["fecha_nacimiento"].ToString()),
                                    reader["cuit"].ToString()
                                    );

                            }
                            return administrative;
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
