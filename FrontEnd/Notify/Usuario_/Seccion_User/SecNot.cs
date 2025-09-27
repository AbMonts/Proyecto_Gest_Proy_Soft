using MaterialSkin.Controls;
using Not.Backend;
using Proyecto_1.FrontEnd.Notify.Usuario_.Seccion_User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_1.FrontEnd.Notify.MENU_USUARIO.Seccion_User
{
    public partial class SecNot : MaterialForm
    {
        Usuario u;
        SeccionJson seccionJson = new SeccionJson();
        string rutaArchivoJson;
        public SecNot(Usuario u)
        {
            this.u = u;
            InitializeComponent();
            menu_lbl.Text = "Aquí están tus secciones " + u.usuario;
            rutaArchivoJson = @"C:\Users\nopes\OneDrive\Escritorio\Notify\main\Proyecto 1\JSON_\SeccionesUsuario\" + u.usuario + ".json";
        }

        private void SecNot_Load(object sender, EventArgs e)
        {
            dgv_sec.DataSource = JsonHelper.cargarSeccionJson(rutaArchivoJson);
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            MENU_USER m = new MENU_USER(u);
            m.Show();
            this.Hide();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            seccion_mod sm = new seccion_mod(1, u);
            sm.Show();
            this.Hide();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            seccion_mod sm = new seccion_mod(2, u, seccionJson);
            sm.Show();
            this.Hide();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (JsonHelper.eliminarSeccionJson(seccionJson, rutaArchivoJson))
            {
                MessageBox.Show("Sección eliminada correctamente");
                SecNot_Load(null, null);
            }
            else
            {
                MessageBox.Show("No se ha podido borrar esta sección...");
            }
        }

        private void dgv_sec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgv_sec.Rows.Count)
                {
                    DataGridViewRow selectedRow = dgv_sec.Rows[e.RowIndex];

                    this.seccionJson.NOMBRE = selectedRow.Cells[0].Value.ToString();
                    this.seccionJson.DESCRIPCIÓN = selectedRow.Cells[1].Value.ToString();
                    this.seccionJson.FILTRO = selectedRow.Cells[2].Value.ToString();

                    btn_delete.Enabled = true;
                    btn_update.Enabled = true;
                    btn_entrar.Enabled = true;
                }
                else
                {
                    btn_delete.Enabled = false;
                    btn_update.Enabled = false;
                    btn_entrar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            seccion_notificacion sn = new seccion_notificacion(u, seccionJson);
            sn.Show();
            this.Hide();
        }
    }
}
