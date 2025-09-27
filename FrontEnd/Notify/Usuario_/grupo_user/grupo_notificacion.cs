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

namespace Proyecto_1.FrontEnd.Notify.Usuario_.Grupo_User
{
    public partial class grupo_notificacion : MaterialForm
    {
        Usuario u;
        GrupoJson grupoJson;
        Notificacion n = new Notificacion();
        public grupo_notificacion(Usuario u, GrupoJson grupoJson)
        {
            InitializeComponent();
            Text = grupoJson.NOMBRE;
            lbl_bienvenue.Text = "Hola " + u.usuario;
            this.u = u;
            this.grupoJson = grupoJson;
        }

        private void grupo_notificacion_Load(object sender, EventArgs e)
        {
            dgv_not.DataSource = n.mostrar_not_grupo(grupoJson);
        }

        private void btn_back_Click_1(object sender, EventArgs e)
        {
            GrupNot sn = new GrupNot(u);
            sn.Show();
            this.Hide();
        }
    }
}
