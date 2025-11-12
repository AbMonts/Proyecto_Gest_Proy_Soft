using MaterialSkin;
using MaterialSkin.Controls;
using Not.Backend;
using Proyecto_1.FrontEnd.Notify.MENU_USUARIO.Seccion_User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_1.FrontEnd.Notify.Usuario_.Seccion_User
{
    public partial class seccion_notificacion : MaterialForm
    {
        Usuario u;
        SeccionJson seccionJson;
        string ruta;
        public seccion_notificacion(Usuario u, SeccionJson seccionJson)
        {
            InitializeComponent();
            MaterialSkinManager skinManager = MaterialSkinManager.Instance;
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
                Primary.DeepPurple500,
                Primary.DeepPurple700,
                Primary.DeepPurple200,
                Accent.Purple200,
                TextShade.WHITE
            );
            Text = seccionJson.NOMBRE;
            lbl_bienvenue.Text = "Hola " + u.UsuarioNombre;
            this.u = u;
            this.seccionJson = seccionJson;
            this.ruta = @"C:\Users\nopes\OneDrive\Escritorio\notify v4w diseño listo\notifaicuatrow\notifaicuatrow\Proyecto 1\JSON_\NotificacionesUsuario\" + u.UsuarioNombre + ".json";
        }

        private void seccion_notificacion_Load(object sender, EventArgs e)
        {
            dgv_not_impor.DataSource = JsonHelper.CargarNotificacionesJsonFiltro(ruta, seccionJson.FILTRO);

            dgv_not_impor.Columns["ID"].Visible = false;
            dgv_not_impor.Columns["ESTADO"].Visible = false;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            SecNot sn = new SecNot(u);
            sn.Show();
            this.Hide();
        }
    }
}
