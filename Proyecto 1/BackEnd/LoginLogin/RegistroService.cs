using System;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;

namespace Proyecto_1.BackEnd
{
    public class RegistroService
    {
        private string connectionString = "server=localhost; user id = root; password =root; database=ing; port=3306;";

        public bool RegistrarUsuario(string usuario, string password, string nombre, string correo, int id_admin = 1)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO usuario (usuario, password, nombre, correo, id_admin)
                             VALUES (@user, SHA2(@pass, 256), @nombre, @correo, @id_admin)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", usuario);
                        cmd.Parameters.AddWithValue("@pass", password);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@id_admin", DBNull.Value);

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
