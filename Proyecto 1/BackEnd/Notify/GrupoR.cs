using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1.BackEnd.Notify
{
    public class GrupoR
    {
        public int Id { get; set; }
        public int NumeroUsuarios { get; set; }
        public int? IdAdmin { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        private readonly Conexion c = new Conexion();

        public GrupoR() { }

        public GrupoR(int id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        // ---------------- CONSULTAS ----------------

        public DataTable MostrarGrupos()
        {
            const string query = @"
                SELECT id_grupo AS ID, nombre AS NOMBRE, descripcion AS DESCRIPCION,
                       numero_usuarios AS NUMERO_USUARIOS, id_admin AS ID_ADMIN
                FROM grupo
                ORDER BY nombre ASC";

            return EjecutarConsulta(query);
        }

        // ---------------- CRUD ----------------

        public bool Crear(GrupoR g)
        {
            const string query = @"
                INSERT INTO grupo (nombre, descripcion, id_admin)
                VALUES (@nombre, @descripcion, @id_admin)";

            var parametros = new Dictionary<string, object>
            {
                { "@nombre", g.Nombre },
                { "@descripcion", g.Descripcion },
                { "@id_admin", g.IdAdmin ?? (object)DBNull.Value }
            };

            return EjecutarTransaccion(query, parametros);
        }

        public bool Eliminar(int id)
        {
            const string query = "DELETE FROM grupo WHERE id_grupo = @id";
            var parametros = new Dictionary<string, object> { { "@id", id } };
            return EjecutarTransaccion(query, parametros);
        }

        public bool Actualizar(GrupoR g)
        {
            const string query = @"
                UPDATE grupo
                SET nombre = @nombre,
                    descripcion = @descripcion,
                    numero_usuarios = @num_usuarios,
                    id_admin = @id_admin
                WHERE id_grupo = @id";

            var parametros = new Dictionary<string, object>
            {
                { "@nombre", g.Nombre },
                { "@descripcion", g.Descripcion },
                { "@num_usuarios", g.NumeroUsuarios },
                { "@id_admin", g.IdAdmin ?? (object)DBNull.Value },
                { "@id", g.Id }
            };

            return EjecutarTransaccion(query, parametros);
        }

        // ---------------- AUXILIARES ----------------

        private DataTable EjecutarConsulta(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                c.OpenConnection();
                using (var cmd = new MySqlCommand(query, c.GetConnection()))
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error SQL] {ex.Message}");
            }
            finally
            {
                c.CloseConnection();
            }
            return dt;
        }

        private bool EjecutarTransaccion(string query, Dictionary<string, object> parametros)
        {
            using (var conn = c.GetConnection())
            {
                c.OpenConnection();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new MySqlCommand(query, conn, tran))
                        {
                            foreach (var p in parametros)
                                cmd.Parameters.AddWithValue(p.Key, p.Value);

                            cmd.ExecuteNonQuery();
                            tran.Commit();
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        Console.WriteLine($"[Error transacción] {ex.Message}");
                        return false;
                    }
                    finally
                    {
                        c.CloseConnection();
                    }
                }
            }
        }
    }
}
