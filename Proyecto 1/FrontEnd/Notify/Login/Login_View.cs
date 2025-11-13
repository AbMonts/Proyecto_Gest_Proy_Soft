using MaterialSkin;
using MaterialSkin.Controls;
using Not.Backend;
using Proyecto_1.BackEnd;
using Proyecto_1.FrontEnd.Notify.MainMenu;
using Proyecto_1.FrontEnd.Notify.MENU_USUARIO;
using Proyecto_1.FrontEnd.Registro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_1.FrontEnd.Login
{
    public partial class Login_View : MaterialForm
    {
        private Button btn_Login;
        private TextBox txtPassword;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Button btn_registro;
        private TextBox txtUsuario;
        private LoginService ls = new LoginService();

        public Login_View()
        {
            InitializeComponent();
            MaterialSkinManager skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this); // 'this' es el MaterialForm

            // Cambia el tema
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; // o DARK

            // Cambia los colores primarios y de acento
            skinManager.ColorScheme = new ColorScheme(
                Primary.DeepPurple500,     // Color primario (base)
                Primary.DeepPurple700,     // Color primario oscuro
                Primary.DeepPurple200,     // Color primario claro
                Accent.Purple200,          // Color de acento
                TextShade.WHITE            // Texto (blanco para buen contraste)
            );
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\FrontEnd\images\icons8-microsoft-authenticator-250.png"));
            pictureBox1.ImageLocation = projectPath;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            // Llamar al backend para autenticación
            var loginService = new Proyecto_1.BackEnd.LoginService();
            bool autenticado = loginService.AutenticarUsuario(usuario, password);

            if (autenticado)
                MessageBox.Show("Bienvenido al sistema");
            else
                MessageBox.Show("Usuario o contraseña incorrectos");
        }

        private void InitializeComponent()
        {
            this.btn_Login = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_registro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(283, 329);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(182, 50);
            this.btn_Login.TabIndex = 0;
            this.btn_Login.Text = "Iniciar Sesión";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(255, 239);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(247, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(255, 287);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(247, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(318, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btn_registro
            // 
            this.btn_registro.Location = new System.Drawing.Point(283, 410);
            this.btn_registro.Name = "btn_registro";
            this.btn_registro.Size = new System.Drawing.Size(182, 50);
            this.btn_registro.TabIndex = 6;
            this.btn_registro.Text = "Registrarse!";
            this.btn_registro.UseVisualStyleBackColor = true;
            this.btn_registro.Click += new System.EventHandler(this.btn_registro_Click);
            // 
            // Login_View
            // 
            this.ClientSize = new System.Drawing.Size(798, 476);
            this.Controls.Add(this.btn_registro);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.btn_Login);
            this.Name = "Login_View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_registro_Click(object sender, EventArgs e)
        {
            Registro_View rv = new Registro_View();
            rv.Show();
            this.Hide();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string s = validar();

            if (s == "Válido")
            {
                if(ls.AutenticarUsuario(txtUsuario.Text, txtPassword.Text))
                {
                    if (ls.Rol(txtUsuario.Text, txtPassword.Text) == "Admin")
                    {
                        Menu_Admin ma = new Menu_Admin(1);
                        ma.Show();
                    }
                    else
                    {
                        MENU_USER mu = new MENU_USER(new Usuario(txtUsuario.Text));
                        mu.Show();
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario inválido.");
                }
            }
            else
            {
                MessageBox.Show(s);
            }
        }

        // validar

        private string validar()
        {
            return "Válido";
        }

        private void Login_View_Load(object sender, EventArgs e)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\FrontEnd\images\icons8-microsoft-authenticator-250.png"));
            pictureBox1.ImageLocation = projectPath;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
