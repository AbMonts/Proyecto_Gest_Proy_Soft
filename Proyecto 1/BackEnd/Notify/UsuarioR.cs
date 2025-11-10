using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1.BackEnd.Notify
{
    public class UsuarioR
    {
        // Propiedades del usuario
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int? IdAdmin { get; set; } // puede ser null

        private readonly Conexion conexion = new Conexion();

        // -------------------- Constructores --------------------
        public UsuarioR() { }

        public UsuarioR(string usuario)
        {
            NombreUsuario = usuario;
        }

        public UsuarioR(int id, string usuario, string password, string nombre, string correo)
        {
            Id = id;
            NombreUsuario = usuario;
            Password = password;
            Nombre = nombre;
            Correo = correo;
        }

        // -------------------- Métodos CRUD --------------------

        // Mostrar todos los usuarios
        public DataTable MostrarUsuarios()
        {
            const string query = "SELECT id_usario, usuario, nombre, correo, id_admin FROM usuario";
            DataTable dataTable = new DataTable();

            try
            {
                conexion.OpenConnection();
                using (var command = new MySqlCommand(query, conexion.GetConnection()))
                using (var adapter = new MySqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar usuarios: {ex.Message}");
            }
            finally
            {
                conexion.CloseConnection();
            }

            return dataTable;
        }

        // Crear un usuario normal
        //-- en el backend solo se usa sha
        public bool CrearUsuario(UsuarioR usuario)
        {
            const string query = @"
                INSERT INTO usuario (usuario, password, nombre, correo, id_admin)
                VALUES (@user, SHA2(@pass, 256), @nombre, @correo, @id_admin)";

            return EjecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@user", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@pass", usuario.Password);
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@id_admin", usuario.IdAdmin);
            });
        }

        // Eliminar usuario por ID
        public bool EliminarUsuario(int id)
        {
            const string query = "DELETE FROM usuario WHERE id_usario = @id";
            return EjecutarComando(query, cmd => cmd.Parameters.AddWithValue("@id", id));
        }

        // Actualizar datos de usuario
        public bool ActualizarUsuario(UsuarioR usuario)
        {
            const string query = @"
                UPDATE usuario 
                SET usuario = @user, password = SHA2(@pass, 256), 
                    nombre = @nombre, correo = @correo, id_admin = @id_admin
                WHERE id_usario = @id";

            return EjecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@user", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@pass", usuario.Password);
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@id_admin", usuario.IdAdmin);
                cmd.Parameters.AddWithValue("@id", usuario.Id);
            });
        }

        // -------------------- Método auxiliar reutilizable --------------------

        private bool EjecutarComando(string query, Action<MySqlCommand> parameterSetter)
        {
            try
            {
                conexion.OpenConnection();
                using (var transaction = conexion.GetConnection().BeginTransaction())
                using (var command = new MySqlCommand(query, conexion.GetConnection(), transaction))
                {
                    parameterSetter(command);
                    int filas = command.ExecuteNonQuery();
                    transaction.Commit();
                    return filas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar comando SQL: {ex.Message}");
                return false;
            }
            finally
            {
                conexion.CloseConnection();
            }
        }
    }
}
