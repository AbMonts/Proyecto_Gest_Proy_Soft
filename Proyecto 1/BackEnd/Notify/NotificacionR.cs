using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1.BackEnd.Notify
{
    public class NotificacionR
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Remitente { get; set; }
        public string Receptor { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public bool Prioridad { get; set; }  // si lo manejas a nivel lógico
        public int? IdAdmin { get; set; }

        private readonly Conexion c = new Conexion();

        public NotificacionR() { }

        public NotificacionR(int id, string remitente, string receptor, string desc, string tipo)
        {
            Id = id;
            Remitente = remitente;
            Receptor = receptor;
            Descripcion = desc;
            Tipo = tipo;
        }

        // ---------------- MÉTODO GENÉRICO PARA CONSULTAS ----------------
        private DataTable EjecutarConsulta(string query, Dictionary<string, object> parametros = null)
        {
            DataTable dt = new DataTable();
            try
            {
                c.OpenConnection();
                using (var cmd = new MySqlCommand(query, c.GetConnection()))
                {
                    if (parametros != null)
                    {
                        foreach (var p in parametros)
                            cmd.Parameters.AddWithValue(p.Key, p.Value);
                    }

                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
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

        // ---------------- MÉTODOS DE CONSULTA ----------------

        public DataTable MostrarTodas()
        {
            return EjecutarConsulta("SELECT * FROM notificacion ORDER BY fecha DESC");
        }

        public DataTable MostrarPorUsuario(UsuarioR u)
        {
            string query = @"
                SELECT id_notificacion AS ID, tipo AS TIPO, remitente AS REMITENTE,
                       descripcion AS DESCRIPCION, fecha AS FECHA
                FROM notificacion
                WHERE receptor = @usuario
                ORDER BY fecha DESC";

            var parametros = new Dictionary<string, object> { { "@usuario", u.NombreUsuario } };
            return EjecutarConsulta(query, parametros);
        }

        public DataTable MostrarPorGrupo(GrupoJson g)
        {
            string query = @"
                SELECT n.id_notificacion AS ID, n.tipo AS TIPO, n.remitente AS REMITENTE,
                       n.descripcion AS DESCRIPCION, n.fecha AS FECHA
                FROM notificacion n
                JOIN grupo gr ON n.receptor = gr.nombre
                WHERE gr.nombre = @nombre
                ORDER BY n.fecha DESC";

            var parametros = new Dictionary<string, object> { { "@nombre", g.NOMBRE } };
            return EjecutarConsulta(query, parametros);
        }

        public DataTable MostrarImportantes()
        {
            string query = @"
                SELECT remitente AS REMITENTE, descripcion AS DESCRIPCION, fecha AS FECHA
                FROM notificacion
                WHERE tipo = 'Importante'
                ORDER BY fecha DESC";

            return EjecutarConsulta(query);
        }

        // ---------------- CONVERTIR DATATABLE A LISTA ----------------
        public List<NotificacionJson> ConvertirDataTableALista(DataTable dt)
        {
            var lista = new List<NotificacionJson>();

            foreach (DataRow row in dt.Rows)
            {
                var notificacion = new NotificacionJson
                {
                    ID = Convert.ToInt32(row["ID"]),
                    TIPO = row["TIPO"].ToString(),
                    REMITENTE = row["REMITENTE"].ToString(),
                    //DESCRIPCION = row["DESCRIPCION"].ToString(), // -- problema con atributos del json, asunto para arreglar despues
                    FECHA = row["FECHA"].ToString(),
                    ESTADO = true
                };
                lista.Add(notificacion);
            }

            return lista;
        }

        // ---------------- CRUD ----------------

        public bool Crear(NotificacionR n)
        {
            const string query = @"
                INSERT INTO notificacion (tipo, remitente, receptor, descripcion, id_admin)
                VALUES (@tipo, @rem, @rec, @desc, @idadmin)";

            var parametros = new Dictionary<string, object>
            {
                { "@tipo", n.Tipo },
                { "@rem", n.Remitente },
                { "@rec", n.Receptor },
                { "@desc", n.Descripcion },
                { "@idadmin", n.IdAdmin ?? (object)DBNull.Value }
            };

            return EjecutarTransaccion(query, parametros);
        }

        public bool Eliminar(int id)
        {
            const string query = "DELETE FROM notificacion WHERE id_notificacion = @id";
            var parametros = new Dictionary<string, object> { { "@id", id } };
            return EjecutarTransaccion(query, parametros);
        }

        public bool Actualizar(NotificacionR n)
        {
            const string query = @"
                UPDATE notificacion
                SET tipo = @tipo, remitente = @rem, receptor = @rec, 
                    descripcion = @desc, id_admin = @idadmin
                WHERE id_notificacion = @id";

            var parametros = new Dictionary<string, object>
            {
                { "@tipo", n.Tipo },
                { "@rem", n.Remitente },
                { "@rec", n.Receptor },
                { "@desc", n.Descripcion },
                { "@idadmin", n.IdAdmin ?? (object)DBNull.Value },
                { "@id", n.Id }
            };

            return EjecutarTransaccion(query, parametros);
        }

        // ---------------- AUXILIAR DE TRANSACCIONES ----------------
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
