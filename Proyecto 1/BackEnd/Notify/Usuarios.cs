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

        public int id;
        public string usuario;
        public string password;
        public string nombre;
        public string correo;
        public int id_admin;
        //public int id_grupo;
        Conexion c = new Conexion();

        // ------------------- constructores --------------------------------------
        public Usuario()
        {

        }
        public Usuario(string usuario)
        {
            this.usuario = usuario;
        }
        public Usuario(int id, string usuario)
        {
            this.id = id;
            this.usuario = usuario;
        }
        public Usuario(int id, string usuario, string password, string nombre, string correo)
        {
            this.id = id;
            this.usuario = usuario;
            this.password = password;
            this.nombre = nombre;
            this.correo = correo;
        }
        public Usuario(string usuario, string password, string nombre, string correo)
        {
            this.usuario = usuario;
            this.password = password;
            this.nombre = nombre;
            this.correo = correo;
        }


        //------------------------------- operaciones exclusivas de un usuario admin ----------------------------------------------------------------
        public DataTable mostrar_usuarios()
        {
            DataTable dataTable = new DataTable();

            try
            {
                c.OpenConnection();

                string query = "select * from usuario";
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
                //Console.WriteLine(ex);
            }
            finally
            {
                c.CloseConnection();
            }

            return dataTable;
        }
        public bool crear_admin(Usuario u)
        {
            MySqlTransaction tran = null;
            try
            {
                c.OpenConnection();

                tran = c.GetConnection().BeginTransaction();

                MySqlConnection connection = c.GetConnection();
                string query = "INSERT INTO administrador (nombre, usuario, password_ad, correo) " +
                              "VALUES (@nombre, @user, SHA2(@pass, 256), @correo)";

                MySqlCommand cmd = new MySqlCommand(query, c.GetConnection());

                cmd.Parameters.AddWithValue("@user", u.usuario);
                cmd.Parameters.AddWithValue("@pass", u.password);
                cmd.Parameters.AddWithValue("@nombre", u.nombre);
                cmd.Parameters.AddWithValue("@correo", u.correo);

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
        public bool crear_usuario(Usuario u)
        {
            MySqlTransaction tran = null;
            try
            {
                c.OpenConnection();

                tran = c.GetConnection().BeginTransaction();

                MySqlConnection connection = c.GetConnection();
                string query = "INSERT INTO usuario (usuario, password, nombre, correo, id_admin) " +
                               "VALUES (@user, SHA2(@pass, 256), @nombre, @correo, @id_admin)";

                MySqlCommand cmd = new MySqlCommand(query, c.GetConnection());

                cmd.Parameters.AddWithValue("@user", u.usuario);
                cmd.Parameters.AddWithValue("@pass", u.password);
                cmd.Parameters.AddWithValue("@nombre", u.nombre);
                cmd.Parameters.AddWithValue("@correo", u.correo);
                cmd.Parameters.AddWithValue("@id_admin", u.id_admin = 1);

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
        public bool eliminar_usuario(Usuario u)
        {
            MySqlTransaction tran = null;
            bool res = true;
            string query = "DELETE FROM usuario WHERE id_usario = @id";


            try
            {
                c.OpenConnection();
                tran = c.GetConnection().BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand(query, c.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", u.id);
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
        public bool actualizar_usuario(Usuario u)
        {
            MySqlTransaction tran = null;
            bool res = true;
            string query = "UPDATE usuario SET usuario = @user, password = SHA2(@pass, 256), " +
                                       "nombre = @nombre, correo = @correo WHERE id_usario = @id";

            try
            {
                c.OpenConnection();
                tran = c.GetConnection().BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand(query, c.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@user", u.usuario);
                    cmd.Parameters.AddWithValue("@pass", u.password);
                    cmd.Parameters.AddWithValue("@nombre", u.nombre);
                    cmd.Parameters.AddWithValue("@correo", u.correo);
                    cmd.Parameters.AddWithValue("@id", u.id);

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

        // --------------------------adicional --------------------------------------------
        public bool crear_seccion()
        {
            return false;
        }

        public bool eliminar_seccion()
        {
            return false;
        }

        public bool actualizar_seccion()
        {
            return false;
        }

        public bool silenciar_notificacion()
        {

            return false;
        }

        public bool activar_notificacion()
        {

            return false;
        }

        public bool silenciar_seccion()
        {
            return false;
        }

        public bool activar_seccion()
        {
            return false;
        }

        public bool silenciar_grupo()
        {
            return false;
        }

        public bool activar_grupo()
        {
            return false;
        }

    }
}
