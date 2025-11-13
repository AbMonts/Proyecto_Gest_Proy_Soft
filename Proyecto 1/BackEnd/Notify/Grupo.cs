using MySql.Data.MySqlClient;
using Proyecto_1.BackEnd;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Not.Backend
{
    public class Grupo
    {
        public int Id { get; set; }
        public int NumeroUsuarios { get; set; }
        public int IdAdmin { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        private readonly Conexion _conexion = new Conexion();

        // ------------------ Constructores ------------------
        public Grupo() { }

        public Grupo(int id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        // ---------------- Métodos de grupo ------------------------

        public string VerUsuarios()
        {
            // Puedes implementar lógica real aquí más adelante
            return null;
        }

        public DataTable MostrarGrupos()
        {
            DataTable dataTable = new DataTable();

            const string query = "SELECT * FROM grupo";

            try
            {
                _conexion.OpenConnection();
                using (MySqlCommand command = new MySqlCommand(query, _conexion.GetConnection()))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar grupos: {ex.Message}");
            }
            finally
            {
                _conexion.CloseConnection();
            }

            return dataTable;
        }

        public bool CrearGrupo(Grupo grupo)
        {
            const string query = @"INSERT INTO grupo (nombre, descripcion, numero_usuarios, id_admin)
                                   VALUES (@nombre, @descripcion, @num_usuarios, @id_admin)";

            return EjecutarTransaccion(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@nombre", grupo.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", grupo.Descripcion);
                cmd.Parameters.AddWithValue("@num_usuarios", grupo.NumeroUsuarios);
                cmd.Parameters.AddWithValue("@id_admin", grupo.IdAdmin);
            });
        }

        public bool EliminarGrupo(Grupo grupo)
        {
            const string query = "DELETE FROM grupo WHERE id_grupo = @id_grupo";

            return EjecutarTransaccion(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@id_grupo", grupo.Id);
            });
        }

        public bool ActualizarGrupo(Grupo grupo)
        {
            const string query = @"UPDATE grupo
                                   SET nombre = @nombre,
                                       descripcion = @descripcion,
                                       numero_usuarios = @num_usuarios,
                                       id_admin = @id_admin
                                   WHERE id = @id";

            return EjecutarTransaccion(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@nombre", grupo.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", grupo.Descripcion);
                cmd.Parameters.AddWithValue("@num_usuarios", grupo.NumeroUsuarios);
                cmd.Parameters.AddWithValue("@id_admin", grupo.IdAdmin);
                cmd.Parameters.AddWithValue("@id", grupo.Id);
            });
        }

        // ---------------- Método privado reutilizable ------------------------
        private bool EjecutarTransaccion(string query, Action<MySqlCommand> configurarComando)
        {
            MySqlTransaction tran = null;

            try
            {
                _conexion.OpenConnection();
                var conn = _conexion.GetConnection();
                tran = conn.BeginTransaction();

                using (MySqlCommand cmd = new MySqlCommand(query, conn, tran))
                {
                    configurarComando(cmd);
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    tran.Commit();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                tran?.Rollback();
                Console.WriteLine($"Error en transacción: {ex.Message}");
                return false;
            }
            finally
            {
                _conexion.CloseConnection();
            }
        }
    }
}
