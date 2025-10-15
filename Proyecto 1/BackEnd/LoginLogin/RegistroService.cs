using System;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;

namespace Proyecto_1.BackEnd
{
    public class RegistroService
    {
        private string connectionString = "server=localhost; user id = root; password =P3rR012.;database=ing; port=3306;";

        public bool RegistrarUsuario(string usuario, string password, string nombre, string correo)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Usuarios (usuario, password, nombre, correo) VALUES (@usuario, @password, @nombre, @correo)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@correo", correo);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }
}
