using System;
using MySql.Data.MySqlClient;
using Not.Backend;

namespace Proyecto_1.BackEnd
{
    public class LoginService
    {
        private string connectionString = "server=localhost; user id = root; password =P3rR012.;database=ing; port=3306;";

        public bool AutenticarUsuario(string usuario, string password)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Usuario WHERE usuario=@usuario AND password= sha2(@password, 256)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@password", password);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public string rol(string usuario, string pass)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT rol FROM Usuario WHERE usuario=@usuario AND password= sha2(@password, 256)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@password", pass);

                    var result = cmd.ExecuteScalar();
                    return result.ToString();
                }
            }
        }
    }
}

