using Google.Protobuf.WellKnownTypes;
using Not.Backend;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_1.FrontEnd.Notify.MENU_USUARIO.Notificacion_User;
using MaterialSkin.Controls;
using Proyecto_1.BackEnd;
using Proyecto_1.FrontEnd.Notify.MENU_USUARIO.Seccion_User;
using Proyecto_1.FrontEnd.Notify.Usuario_.Grupo_User;
using MaterialSkin;
using Proyecto_1.FrontEnd.Login;
using Not.Backend.Not.Backend;

namespace Proyecto_1.FrontEnd.Notify.MENU_USUARIO
{
    public partial class MENU_USER : MaterialForm
    {
        
        Notificacion n = new Notificacion();
        Usuario u = new Usuario();

        public MENU_USER(Not.Backend.Usuario u)
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
            this.u = u;
            lbl_bienvenue.Text = "Bienvenido: " + u.Nombre + " " + "'"  + u.UsuarioNombre + "'";
        }

        private void MENU_USER_Load(object sender, EventArgs e)
        {
            try
            {
                dgv_not_impor.DataSource = n.MostrarNotificacionesImportantes();
            }
            catch
            {
                MessageBox.Show("No se pudo cargar la tabla...");
            }
        }

        private void btn_notificacion_Click(object sender, EventArgs e)
        {
            UserNot un = new UserNot(u);
            un.Show();
            this.Hide();
        }

        private void btn_secciones_Click(object sender, EventArgs e)
        {
            SecNot sn = new SecNot(u);
            sn.Show();
            this.Hide();    
        }

        private void btn_grupos_Click(object sender, EventArgs e)
        {
            GrupNot gn = new GrupNot(u);
            gn.Show();
            this.Hide();
        }

        private void menu_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Login_View lv = new Login_View();
            lv.Show();
            this.Hide();
        }
    }
}
