using System;
using MySql.Data.MySqlClient;
using Not.Backend;

namespace Proyecto_1.BackEnd
{
    public class LoginService
    {
        private string connectionString = "server=localhost; user id = root; password =root; database=ing; port=3306;";

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

        public string Rol(string usuario, string password)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // 1️⃣ Verificar si es administrador
                string queryAdmin = @"SELECT COUNT(*) FROM administrador 
                                      WHERE usuario=@usuario AND password_ad=SHA2(@password, 256)";
                using (var cmdAdmin = new MySqlCommand(queryAdmin, conn))
                {
                    cmdAdmin.Parameters.AddWithValue("@usuario", usuario);
                    cmdAdmin.Parameters.AddWithValue("@password", password);

                    int esAdmin = Convert.ToInt32(cmdAdmin.ExecuteScalar());
                    if (esAdmin > 0)
                        return "Admin";
                }

                // 2️⃣ Verificar si es usuario normal
                string queryUser = @"SELECT COUNT(*) FROM usuario 
                                     WHERE usuario=@usuario AND password=SHA2(@password, 256)";
                using (var cmdUser = new MySqlCommand(queryUser, conn))
                {
                    cmdUser.Parameters.AddWithValue("@usuario", usuario);
                    cmdUser.Parameters.AddWithValue("@password", password);

                    int esUsuario = Convert.ToInt32(cmdUser.ExecuteScalar());
                    if (esUsuario > 0)
                        return "Usuario";
                }

                return "Desconocido";
            }
        }
    }
}

