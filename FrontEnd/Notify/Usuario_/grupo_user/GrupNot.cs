using MaterialSkin.Controls;
using Not.Backend;
using Proyecto_1.FrontEnd.Notify.MENU_USUARIO;
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

namespace Proyecto_1.FrontEnd.Notify.Usuario_.Grupo_User
{
    public partial class GrupNot : MaterialForm
    {
        Usuario u;
        GrupoJson grupoJson = new GrupoJson();
        string rutaArchivoJson;
        public GrupNot(Usuario u)
        {
            this.u = u;
            InitializeComponent();
            menu_lbl.Text = "Aquí están tus grupos " + u.usuario;
            rutaArchivoJson = @"C:\Users\nopes\OneDrive\Escritorio\Notify\main\Proyecto 1\JSON_\GruposUsuario\" + u.usuario + ".json";
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            MENU_USER m = new MENU_USER(u);
            m.Show();
            this.Hide();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            grupo_mod sm = new grupo_mod(1, u);
            sm.Show();
            this.Hide();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            grupo_mod gm = new grupo_mod(2, u, grupoJson);
            gm.Show();
            this.Hide();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (JsonHelper.eliminarGrupoJson(grupoJson, rutaArchivoJson))
            {
                MessageBox.Show("Grupo eliminado correctamente");
                GrupNot_Load(null, null);
            }
            else
            {
                MessageBox.Show("No se ha podido borrar este grupo...");
            }
        }

        private void dgv_grup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgv_grup.Rows.Count)
                {
                    DataGridViewRow selectedRow = dgv_grup.Rows[e.RowIndex];

                    this.grupoJson.NOMBRE = selectedRow.Cells[0].Value.ToString();
                    this.grupoJson.DESCRIPCIÓN = selectedRow.Cells[1].Value.ToString();

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

        private void btn_back_Click_1(object sender, EventArgs e)
        {
            MENU_USER mu = new MENU_USER(u);
            mu.Show();
            this.Hide();
        }

        private void GrupNot_Load(object sender, EventArgs e)
        {
            dgv_grup.DataSource = JsonHelper.cargarSeccionJson(rutaArchivoJson);
            dgv_grup.Columns["FILTRO"].Visible = false;
        }

        private void btn_entrar_Click_1(object sender, EventArgs e)
        {
            grupo_notificacion gn = new grupo_notificacion(u, grupoJson);
            gn.Show();
            this.Hide();
        }
    }
}
