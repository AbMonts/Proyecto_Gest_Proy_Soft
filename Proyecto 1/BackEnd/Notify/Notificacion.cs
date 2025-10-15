using MySql.Data.MySqlClient;
using Proyecto_1.BackEnd;
using System.Collections.Generic;
using System.Data;
using System;

namespace Not.Backend
{
    public class Notificacion
    {
        // Atributos de la notificación
        public int id;
        public string tipo;
        public string remitente;
        public string receptor;
        public string descripcion;
        public string fecha;
        public bool prioridad;

        // Instancia de conexión a la base de datos
        Conexion c = new Conexion();

        // Constructor vacío
        public Notificacion() { }

        // Constructor con parámetros
        public Notificacion(int id, string remitente, string receptor, string desc, string tipo)
        {
            this.id = id;
            this.remitente = remitente;
            this.receptor = receptor;
            this.descripcion = desc;
            this.tipo = tipo;
        }

        // Devuelve todas las notificaciones
        public DataTable mostrar_not()
        {
            DataTable dataTable = new DataTable();
            try
            {
                c.OpenConnection();
                string query = "select * from notificacion";
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

        // Devuelve notificaciones de un usuario específico
        public DataTable mostrar_not_usuario(Usuario u)
        {
            DataTable dataTable = new DataTable();
            try
            {
                c.OpenConnection();
                string username = u.usuario;
                string query = "select idn as ID, tipo as TIPO, remitente as REMITENTE, descripcion as DESCRIPCIÓN, fecha as FECHA from notificacion where receptor = " + '"' + username + '"' + " order by fecha desc";
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

        // Devuelve notificaciones de un grupo específico
        public DataTable mostrar_not_grupo(GrupoJson g)
        {
            DataTable dataTable = new DataTable();
            try
            {
                c.OpenConnection();
                string name = g.NOMBRE;
                string query = "select n.idn as ID, n.tipo as TIPO, n.remitente as REMITENTE, n.descripcion as DESCRIPCIÓN, n.fecha as FECHA from notificacion n join grupo g on n.receptor = g.nombre where g.nombre  = " + '"' + name + '"' + " order by fecha desc";
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

        // Convierte un DataTable con datos de notificaciones a una lista de objetos NotificacionJson
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

        // Muestra solo notificaciones importantes (tipo = 'Importante')
        public DataTable mostrar_not_importantes()
        {
            DataTable dataTable = new DataTable();
            try
            {
                c.OpenConnection();
                string query = "select remitente as REMITENTE, descripcion as DESCRIPCIÓN, fecha as FECHA from notificacion where tipo = 'Importante' order by fecha desc";
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

        // Crea una nueva notificación en la base de datos
        public bool crear_notificacion(Notificacion n)
        {
            // Hacemos uso de transacciones y rollback para mantener la conscistencia en la base de datos
            MySqlTransaction tran = null;
            try
            {
                c.OpenConnection();
                tran = c.GetConnection().BeginTransaction();

                // Creamos la query que se enviará a MySQL
                string query = "insert into notificacion (tipo, remitente, receptor, descripcion) values (@tipo, @rem, @rec, @desc)";
                MySqlCommand cmd = new MySqlCommand(query, c.GetConnection());

                // Parámetros de seguridad para evitar SQL Injection
                cmd.Parameters.AddWithValue("@tipo", n.tipo);
                cmd.Parameters.AddWithValue("@rem", n.remitente);
                cmd.Parameters.AddWithValue("@rec", n.receptor);
                cmd.Parameters.AddWithValue("@desc", n.descripcion);

                // Ejecutamos la query y hacemos un commit para guardar los cambios en la base de datos
                cmd.ExecuteNonQuery();
                tran.Commit();

                return true;
            }
            catch (Exception ex)
            {
                // Rollback en caso de cualquier error
                if (tran != null) tran.Rollback();
                return false;
            }
            finally
            {
                c.CloseConnection();
            }
        }

        // Elimina una notificación por su ID
        public bool eliminar_notificacion(Notificacion n)
        {
            MySqlTransaction tran = null;
            bool res = true;
            string query = "delete from notificacion where idn = @id";

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

        // Actualiza los datos de una notificación existente
        public bool actualizar_notificacion(Notificacion n)
        {
            MySqlTransaction tran = null;
            bool res = true;
            string query = "update notificacion set tipo = @tipo, remitente = @rem, receptor = @rec, descripcion = @desc where idn = @id";

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
    }
}
