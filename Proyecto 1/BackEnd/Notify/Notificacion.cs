using MySql.Data.MySqlClient;
using Proyecto_1.BackEnd;
using System.Collections.Generic;
using System.Data;
using System;
using Mysqlx.Crud;
using Mysqlx.Cursor;


namespace Not.Backend
{

    using MySql.Data.MySqlClient;
    using Proyecto_1.BackEnd;
    using System;
    using System.Collections.Generic;
    using System.Data;

    namespace Not.Backend
    {
        public class Notificacion
        {
            // ---------------- Propiedades ----------------
            public int Id { get; set; }
            public string Tipo { get; set; }
            public string Remitente { get; set; }
            public string Receptor { get; set; }
            public string Descripcion { get; set; }
            public string Fecha { get; set; }
            public bool Prioridad { get; set; }

            private readonly Conexion _conexion = new Conexion();

            // ---------------- Constructores ----------------
            public Notificacion() { }

            public Notificacion(int id, string remitente, string receptor, string desc, string tipo)
            {
                Id = id;
                Remitente = remitente;
                Receptor = receptor;
                Descripcion = desc;
                Tipo = tipo;
            }

            // ---------------- Métodos de consulta ----------------

            public DataTable MostrarNotificaciones()
            {
                const string query = "SELECT * FROM notificacion";
                return EjecutarConsulta(query, null);
            }

            public DataTable MostrarNotificacionesUsuario(Usuario usuario)
            {
                const string query = @"SELECT id_notificacion AS ID, tipo AS TIPO, remitente AS REMITENTE,
                                          descripcion AS DESCRIPCIÓN, fecha AS FECHA
                                   FROM notificacion
                                   WHERE receptor = @usuario
                                   ORDER BY fecha DESC";

                return EjecutarConsulta(query, cmd =>
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario.UsuarioNombre);
                });
            }

            public DataTable MostrarNotificacionesGrupo(GrupoJson grupo)
            {
                const string query = @"SELECT n.id_notificacion AS ID, n.tipo AS TIPO, n.remitente AS REMITENTE,
                                          n.descripcion AS DESCRIPCIÓN, n.fecha AS FECHA
                                   FROM notificacion n
                                   JOIN grupo g ON n.receptor = g.nombre
                                   WHERE g.nombre = @nombre
                                   ORDER BY n.fecha DESC";

                return EjecutarConsulta(query, cmd =>
                {
                    cmd.Parameters.AddWithValue("@nombre", grupo.NOMBRE);
                });
            }

            public DataTable MostrarNotificacionesImportantes()
            {
                const string query = @"SELECT remitente AS REMITENTE, descripcion AS DESCRIPCIÓN, fecha AS FECHA
                                   FROM notificacion
                                   WHERE tipo = 'Importante'
                                   ORDER BY fecha DESC";

                return EjecutarConsulta(query, null);
            }

            // ---------------- Métodos CRUD ----------------

            public bool CrearNotificacion(Notificacion n)
            {
                const string query = @"INSERT INTO notificacion (tipo, remitente, receptor, descripcion, id_admin)
                                   VALUES (@tipo, @rem, @rec, @desc, @idadmin)";
                return EjecutarOperacion(query, cmd =>
                {
                    cmd.Parameters.AddWithValue("@tipo", n.Tipo);
                    cmd.Parameters.AddWithValue("@rem", n.Remitente);
                    cmd.Parameters.AddWithValue("@rec", n.Receptor);
                    cmd.Parameters.AddWithValue("@desc", n.Descripcion);
                    cmd.Parameters.AddWithValue("@idadmin", 1); // fijo, o podrías pasarlo como parámetro
                });
            }

            public bool EliminarNotificacion(int id)
            {
                const string query = "DELETE FROM notificacion WHERE id_notificacion = @id";
                return EjecutarOperacion(query, cmd =>
                {
                    cmd.Parameters.AddWithValue("@id", id);
                });
            }

            public bool ActualizarNotificacion(Notificacion n)
            {
                const string query = @"UPDATE notificacion
                                   SET tipo = @tipo, remitente = @rem, receptor = @rec, descripcion = @desc
                                   WHERE id_notificacion = @id";

                return EjecutarOperacion(query, cmd =>
                {
                    cmd.Parameters.AddWithValue("@tipo", n.Tipo);
                    cmd.Parameters.AddWithValue("@rem", n.Remitente);
                    cmd.Parameters.AddWithValue("@rec", n.Receptor);
                    cmd.Parameters.AddWithValue("@desc", n.Descripcion);
                    cmd.Parameters.AddWithValue("@id", n.Id);
                });
            }

            // ---------------- Método reutilizable para consultas ----------------

            private DataTable EjecutarConsulta(string query, Action<MySqlCommand> configurarParametros)
            {
                DataTable dataTable = new DataTable();

                try
                {
                    _conexion.OpenConnection();
                    using (MySqlCommand cmd = new MySqlCommand(query, _conexion.GetConnection()))
                    {
                        configurarParametros?.Invoke(cmd);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar consulta SQL: {ex.Message}");
                }
                finally
                {
                    _conexion.CloseConnection();
                }

                return dataTable;
            }

            // ---------------- Método reutilizable para operaciones CRUD ----------------

            private bool EjecutarOperacion(string query, Action<MySqlCommand> configurarParametros)
            {
                MySqlTransaction tran = null;
                bool exito = false;

                try
                {
                    _conexion.OpenConnection();
                    var connection = _conexion.GetConnection();
                    tran = connection.BeginTransaction();

                    using (MySqlCommand cmd = new MySqlCommand(query, connection, tran))
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

            // ---------------- Conversión de DataTable a Lista ----------------

            public List<NotificacionJson> ConvertirDataTableALista(DataTable dt)
            {
                var lista = new List<NotificacionJson>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new NotificacionJson
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        TIPO = row["TIPO"].ToString(),
                        REMITENTE = row["REMITENTE"].ToString(),
                        DESCRIPCIÓN = row["DESCRIPCIÓN"].ToString(),
                        FECHA = row["FECHA"].ToString(),
                        ESTADO = true
                    });
                }

                return lista;
            }
        }
    }

    /* public class Notificacion
     {
         public int id;
         public string tipo;
         public string remitente;
         public string receptor;
         public string descripcion;
         public string fecha;
         public bool prioridad;

         Conexion c = new Conexion();

         // ----------------------- constructores -------------------------------
         public Notificacion() { }
         public Notificacion(int id, string remitente, string receptor, string desc, string tipo)
         {
             this.id = id;
             this.remitente = remitente;
             this.receptor = receptor;
             this.descripcion = desc;
             this.tipo = tipo;
         }

         // ----------------------------- metodos -------------------------------------------
         public DataTable mostrar_not()
         {
             DataTable dataTable = new DataTable();
             try
             {
                 c.OpenConnection();
                 string query = "SELECT * FROM notificacion";

                 using (MySqlCommand command = new MySqlCommand(query, c.GetConnection()))
                 {
                     using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                     {
                         adapter.Fill(dataTable);
                     }
                 }
             }
             catch (Exception ex) { }
             finally { c.CloseConnection(); }

             return dataTable;
         }

         public DataTable mostrar_not_usuario(Usuario u)
         {
             DataTable dataTable = new DataTable();
             try
             {
                 c.OpenConnection();
                 string username = u.usuario;
                 string query = @"SELECT id_notificacion AS ID, tipo AS TIPO, remitente AS REMITENTE,
                         descripcion AS DESCRIPCIÓN, fecha AS FECHA
                  FROM notificacion
                  WHERE receptor = @usuario
                  ORDER BY fecha DESC";

                 using (MySqlCommand command = new MySqlCommand(query, c.GetConnection()))
                 {
                     using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                     {
                         command.Parameters.AddWithValue("@usuario", u.usuario);

                         adapter.Fill(dataTable);
                     }
                 }
             }
             catch (Exception ex) { }
             finally { c.CloseConnection(); }

             return dataTable;
         }
         public DataTable mostrar_not_grupo(GrupoJson g)
         {
             DataTable dataTable = new DataTable();
             try
             {
                 c.OpenConnection();
                 string name = g.NOMBRE;
                 string query = @"SELECT n.id_notificacion AS ID, n.tipo AS TIPO, n.remitente AS REMITENTE,
                         n.descripcion AS DESCRIPCIÓN, n.fecha AS FECHA
                  FROM notificacion n
                  JOIN grupo g ON n.receptor = g.nombre
                  WHERE g.nombre = @nombre
                  ORDER BY n.fecha DESC";

                 using (MySqlCommand command = new MySqlCommand(query, c.GetConnection()))
                 {
                     using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                     {
                         command.Parameters.AddWithValue("@nombre", g.NOMBRE);

                         adapter.Fill(dataTable);
                     }
                 }
             }
             catch (Exception ex) { }
             finally { c.CloseConnection(); }

             return dataTable;
         }
         public List<NotificacionJson> ConvertirDataTableALista(DataTable dt, Usuario u)
         {
             List<NotificacionJson> listaNotificaciones = new List<NotificacionJson>();

             foreach (DataRow row in dt.Rows)
             {
                 NotificacionJson notificacion = new NotificacionJson
                 {
                     ID = Convert.ToInt32(row["id"]),
                     TIPO = row["tipo"].ToString(),
                     REMITENTE = row["remitente"].ToString(),
                     DESCRIPCIÓN = row["descripción"].ToString(),
                     FECHA = row["fecha"].ToString(),
                     ESTADO = true // Asignación fija, quizás se pueda mejorar
                 };

                 listaNotificaciones.Add(notificacion);
             }

             return listaNotificaciones;
         }
         public DataTable mostrar_not_importantes()
         {
             DataTable dataTable = new DataTable();
             try
             {
                 c.OpenConnection();
                 string query = @"SELECT remitente AS REMITENTE, descripcion AS DESCRIPCIÓN, fecha AS FECHA
                  FROM notificacion
                  WHERE tipo = 'Importante'
                  ORDER BY fecha DESC";

                 using (MySqlCommand command = new MySqlCommand(query, c.GetConnection()))
                 {
                     using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                     {
                         adapter.Fill(dataTable);
                     }
                 }
             }
             catch (Exception ex) { }
             finally { c.CloseConnection(); }

             return dataTable;
         }
         public bool crear_notificacion(Notificacion n)
         {
             MySqlTransaction tran = null;
             try
             {
                 c.OpenConnection();
                 tran = c.GetConnection().BeginTransaction();

                 string query = @"INSERT INTO notificacion (tipo, remitente, receptor, descripcion, id_admin)
                  VALUES (@tipo, @rem, @rec, @desc, @idadmin)";
                 MySqlCommand cmd = new MySqlCommand(query, c.GetConnection());

                 cmd.Parameters.AddWithValue("@tipo", n.tipo);
                 cmd.Parameters.AddWithValue("@rem", n.remitente);
                 cmd.Parameters.AddWithValue("@rec", n.receptor);
                 cmd.Parameters.AddWithValue("@desc", n.descripcion);
                 //cmd.Parameters.AddWithValue("@idadmin", n.a); // 
                 cmd.ExecuteNonQuery();
                 tran.Commit();

                 return true;
             }
             catch (Exception ex)
             {
                 if (tran != null) tran.Rollback();
                 return false;
             }
             finally
             {
                 c.CloseConnection();
             }
         }
         public bool eliminar_notificacion(Notificacion n)
         {
             MySqlTransaction tran = null;
             bool res = true;
             string query = "DELETE FROM notificacion WHERE id_notificacion = @id";

             try
             {
                 c.OpenConnection();
                 tran = c.GetConnection().BeginTransaction();

                 using (MySqlCommand cmd = new MySqlCommand(query, c.GetConnection()))
                 {
                     cmd.Parameters.AddWithValue("@id", n.id);
                     int filas = cmd.ExecuteNonQuery();
                     res = filas > 0;
                 }

                 tran.Commit();
             }
             catch (Exception ex)
             {
                 if (tran != null) tran.Rollback();
                 res = false;
             }
             finally
             {
                 c.CloseConnection();
             }

             return res;
         }
         public bool actualizar_notificacion(Notificacion n)
         {
             MySqlTransaction tran = null;
             bool res = true;
             string query = @"UPDATE notificacion
                  SET tipo = @tipo, remitente = @rem, receptor = @rec, descripcion = @desc
                  WHERE id_notificacion = @id";

             try
             {
                 c.OpenConnection();
                 tran = c.GetConnection().BeginTransaction();

                 using (MySqlCommand cmd = new MySqlCommand(query, c.GetConnection()))
                 {
                     cmd.Parameters.AddWithValue("@tipo", n.tipo);
                     cmd.Parameters.AddWithValue("@rem", n.remitente);
                     cmd.Parameters.AddWithValue("@rec", n.receptor);
                     cmd.Parameters.AddWithValue("@desc", n.descripcion);
                     cmd.Parameters.AddWithValue("@id", n.id);

                     int filas = cmd.ExecuteNonQuery();
                     res = filas > 0;
                 }

                 tran.Commit();
             }
             catch (Exception ex)
             {
                 if (tran != null) tran.Rollback();
                 res = false;
             }
             finally
             {
                 c.CloseConnection();
             }

             return res;
         }
     }*/
}
