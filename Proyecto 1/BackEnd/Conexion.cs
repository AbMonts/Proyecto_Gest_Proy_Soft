using MySql.Data.MySqlClient;
using System;

namespace Proyecto_1.BackEnd
{
    public class Conexion
    {
        private MySqlConnection connection;
        private readonly string connectionString;

        // Constructor que inicializa la conexión con la base de datos
        public Conexion()
        {
            // Parámetros usados para entrar a la base de datos de MySQL
            connectionString = "server=localhost; user id = root; password =P3rR012.;database=ing; port=3306;";
            // Creación de una conexión con los parámetros anteriores
            connection = new MySqlConnection(connectionString);
        }

        // Abre la conexión si está cerrada
        public void OpenConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                // Manejo silencioso del error
            }
        }

        // Cierra la conexión si está abierta
        public void CloseConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    // connection.Dispose(); // Opción descartada porque da errores al eliminar
                }
            }
            catch (Exception ex)
            {
                // Manejo silencioso del error
            }
        }

        // Devuelve el objeto de conexión actual
        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
