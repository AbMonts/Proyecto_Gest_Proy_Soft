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

        public int id;
        public int numero_usuarios;
        public int id_admin;
        public string nombre;
        public string descripcion;
        Conexion c = new Conexion();
        public Grupo()
        {

        }

        public Grupo(int id, string nombre, string descripcion)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        public string ver_usuarios()
        {
            return null;
        }

        public DataTable mostrar_grupos()
        {
            DataTable dataTable = new DataTable();

            try
            {
                c.OpenConnection();

                string query = "SELECT * FROM grupo";
                using (MySqlCommand command = new MySqlCommand(query, c.GetConnection()))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                c.CloseConnection();
            }

            return dataTable;
        }

        public bool crear_grupo(Grupo g)
        {
            MySqlTransaction tran = null;
            try
            {
                c.OpenConnection();

                tran = c.GetConnection().BeginTransaction();

                MySqlConnection connection = c.GetConnection();
                string query = @"INSERT INTO grupo (nombre, descripcion, numero_usuarios, id_admin)
                 VALUES (@nombre, @descripcion, @num_usuarios, @id_admin)";

                MySqlCommand cmd = new MySqlCommand(query, c.GetConnection());

                cmd.Parameters.AddWithValue("@nombre", g.nombre);
                cmd.Parameters.AddWithValue("@descripcion", g.descripcion);
                cmd.Parameters.AddWithValue("@num_usuarios", g.numero_usuarios);
                cmd.Parameters.AddWithValue("@id_admin", g.id_admin);


                cmd.ExecuteNonQuery();
                tran.Commit();

                return true;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                c.CloseConnection();
            }
        }

        public bool eliminar_grupo(Grupo g)
        {
            MySqlTransaction tran = null;
            bool res = true;
            string query = "DELETE FROM grupo WHERE id = @id";

            try
            {
                c.OpenConnection();
                tran = c.GetConnection().BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand(query, c.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", g.id);
                    int filas = cmd.ExecuteNonQuery();
                    res = filas > 0;
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                //MessageBox.Show(ex.Message);
                res = false;
            }
            finally
            {
                c.CloseConnection();
            }

            return res;
        }

        public bool actualizar_grupo(Grupo g)
        {
            MySqlTransaction tran = null;
            bool res = true;
            string query = @"UPDATE grupo
                 SET nombre = @nombre,
                     descripcion = @descripcion,
                     numero_usuarios = @num_usuarios,
                     id_admin = @id_admin
                 WHERE id = @id";

            try
            {
                c.OpenConnection();
                tran = c.GetConnection().BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand(query, c.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@nombre", g.nombre);
                    cmd.Parameters.AddWithValue("@descripcion", g.descripcion);
                    cmd.Parameters.AddWithValue("@num_usuarios", g.numero_usuarios);
                    cmd.Parameters.AddWithValue("@id_admin", g.id_admin);
                    cmd.Parameters.AddWithValue("@id", g.id);


                    int filas = cmd.ExecuteNonQuery();
                    res = filas > 0;
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                //MessageBox.Show(ex.Message);
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
