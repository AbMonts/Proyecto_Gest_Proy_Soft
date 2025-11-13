using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Crypto;
using Proyecto_1.BackEnd;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Not.Backend
{
    public class Usuario
    {
        // ------------------- Propiedades -------------------
        public int Id { get; set; }
        public string UsuarioNombre { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int IdAdmin { get; set; }

        private readonly Conexion _conexion = new Conexion();

        // ------------------- Constructores -------------------
        public Usuario() { }

        public Usuario(string usuario) => UsuarioNombre = usuario;

        public Usuario(int id, string usuario)
        {
            Id = id;
            UsuarioNombre = usuario;
        }

        public Usuario(int id, string usuario, string password, string nombre, string correo)
        {
            Id = id;
            UsuarioNombre = usuario;
            Password = password;
            Nombre = nombre;
            Correo = correo;
        }

        public Usuario(string usuario, string password, string nombre, string correo)
        {
            UsuarioNombre = usuario;
            Password = password;
            Nombre = nombre;
            Correo = correo;
        }

        // ------------------- Métodos de administración -------------------

        public DataTable MostrarUsuarios()
        {
            var dataTable = new DataTable();
            const string query = "SELECT * FROM usuario";

            try
            {
                _conexion.OpenConnection();
                using (var command = new MySqlCommand(query, _conexion.GetConnection()))
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
                _conexion.CloseConnection();
            }

            return dataTable;
        }

        public bool CrearAdmin(Usuario u)
        {
            const string query = @"INSERT INTO administrador (nombre, usuario, password_ad, correo)
                                   VALUES (@nombre, @user, SHA2(@pass, 256), @correo)";
            return EjecutarOperacion(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@user", u.UsuarioNombre);
                cmd.Parameters.AddWithValue("@pass", u.Password);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@correo", u.Correo);
            });
        }

        public bool CrearUsuario(Usuario u)
        {
            const string query = @"INSERT INTO usuario (usuario, password, nombre, correo, id_admin)
                                   VALUES (@user, SHA2(@pass, 256), @nombre, @correo, @id_admin)";
            return EjecutarOperacion(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@user", u.UsuarioNombre);
                cmd.Parameters.AddWithValue("@pass", u.Password);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@correo", u.Correo);
                cmd.Parameters.AddWithValue("@id_admin", u.IdAdmin == 0 ? 1 : u.IdAdmin);
            });
        }

        public bool EliminarUsuario(int id)
        {
            const string query = "DELETE FROM usuario WHERE id_usuario = @id";
            return EjecutarOperacion(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@id", id);
            });
        }

        public bool ActualizarUsuario(Usuario u)
        {
            const string query = @"UPDATE usuario 
                                   SET usuario = @user, password = SHA2(@pass, 256), nombre = @nombre, correo = @correo
                                   WHERE id_usuario = @id";
            return EjecutarOperacion(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@user", u.UsuarioNombre);
                cmd.Parameters.AddWithValue("@pass", u.Password);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@correo", u.Correo);
                cmd.Parameters.AddWithValue("@id", u.Id);
            });
        }

        // ------------------- Método genérico de ejecución -------------------
        private bool EjecutarOperacion(string query, Action<MySqlCommand> configurarParametros)
        {
            MySqlTransaction tran = null;
            bool exito = false;

            try
            {
                _conexion.OpenConnection();
                var connection = _conexion.GetConnection();
                tran = connection.BeginTransaction();

                using (var cmd = new MySqlCommand(query, connection, tran))
                {
                    configurarParametros(cmd);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                    exito = true;
                }
            }
            catch (Exception ex)
            {
                tran?.Rollback();
                Console.WriteLine($"Error en operación SQL: {ex.Message}");
            }
            finally
            {
                _conexion.CloseConnection();
            }

            return exito;
        }

        // ------------------- Métodos adicionales (placeholders) -------------------
        public bool CrearSeccion() => false;
        public bool EliminarSeccion() => false;
        public bool ActualizarSeccion() => false;
        public bool SilenciarNotificacion() => false;
        public bool ActivarNotificacion() => false;
        public bool SilenciarSeccion() => false;
        public bool ActivarSeccion() => false;
        public bool SilenciarGrupo() => false;
        public bool ActivarGrupo() => false;
    }
}
