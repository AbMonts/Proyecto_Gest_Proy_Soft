using MaterialSkin;
using MaterialSkin.Controls;
using Not.Backend;
using Proyecto_1.FrontEnd.Login;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Proyecto_1.FrontEnd.Registro
{
    public partial class Registro_View : MaterialForm
    {
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private TextBox txb_pass;
        private TextBox txb_usuario;
        private Label Nombre;
        private TextBox txb_nombre;
        private Label label4;
        private TextBox txb_correo;
        private Button btn_back;
        private Button btnRegistrar;

        public Registro_View()
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
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string usuario = txb_usuario.Text;
            string password = txb_pass.Text;
            string nombre = txb_nombre.Text;
            string correo = txb_correo.Text;

            var registroService = new Proyecto_1.BackEnd.RegistroService();
            bool registrado = registroService.RegistrarUsuario(usuario, password, nombre, correo);

            if (registrado)
                MessageBox.Show("Usuario registrado exitosamente");
            else
                MessageBox.Show("Error al registrar usuario");
        }

        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_pass = new System.Windows.Forms.TextBox();
            this.txb_usuario = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Nombre = new System.Windows.Forms.Label();
            this.txb_nombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_correo = new System.Windows.Forms.TextBox();
            this.btn_back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Usuario";
            // 
            // txb_pass
            // 
            this.txb_pass.Location = new System.Drawing.Point(251, 258);
            this.txb_pass.Name = "txb_pass";
            this.txb_pass.Size = new System.Drawing.Size(247, 22);
            this.txb_pass.TabIndex = 8;
            // 
            // txb_usuario
            // 
            this.txb_usuario.Location = new System.Drawing.Point(251, 210);
            this.txb_usuario.Name = "txb_usuario";
            this.txb_usuario.Size = new System.Drawing.Size(247, 22);
            this.txb_usuario.TabIndex = 7;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(277, 414);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(182, 50);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(314, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Location = new System.Drawing.Point(248, 289);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(56, 16);
            this.Nombre.TabIndex = 13;
            this.Nombre.Text = "Nombre";
            // 
            // txb_nombre
            // 
            this.txb_nombre.Location = new System.Drawing.Point(251, 305);
            this.txb_nombre.Name = "txb_nombre";
            this.txb_nombre.Size = new System.Drawing.Size(247, 22);
            this.txb_nombre.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Correo";
            // 
            // txb_correo
            // 
            this.txb_correo.Location = new System.Drawing.Point(251, 347);
            this.txb_correo.Name = "txb_correo";
            this.txb_correo.Size = new System.Drawing.Size(247, 22);
            this.txb_correo.TabIndex = 14;
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(3, 429);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(127, 35);
            this.btn_back.TabIndex = 16;
            this.btn_back.Text = "Regresar";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // Registro_View
            // 
            this.ClientSize = new System.Drawing.Size(746, 476);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_correo);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.txb_nombre);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txb_pass);
            this.Controls.Add(this.txb_usuario);
            this.Controls.Add(this.btnRegistrar);
            this.Name = "Registro_View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro";
            this.Load += new System.EventHandler(this.Registro_View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Login_View lv = new Login_View();
            lv.Show();
            this.Hide();
        }

        private void Registro_View_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            if(validar() == "Válido")
            {
                Usuario usuario = new Usuario(txb_usuario.Text, txb_pass.Text, txb_nombre.Text, txb_correo.Text);
                if (usuario.crear_usuario(usuario))/// 
                {
                    MessageBox.Show("USUARIO creado exitosamente");
                    Login_View lv = new Login_View();
                    lv.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error al crear el usuario.");
                }
            }
            else
            {
                MessageBox.Show(validar());
            }
        }

        private string validar()
        {
            // Validaciones de llenado de datos
            if (txb_nombre.Text.Length == 0 && txb_usuario.Text.Length == 0 && txb_pass.Text.Length == 0 && txb_correo.Text.Length == 0) return "Debe llenar todos los campos.";
            
            if (txb_usuario.Text.Length == 0) return "Debe llenar el campo 'Usuario'";
            if (txb_pass.Text.Length == 0) return "Debe llenar el campo 'Contraseña'";
            if (txb_nombre.Text.Length == 0) return "Debe llenar el campo 'Nombre'";
            if (txb_correo.Text.Length == 0) return "Debe llenar el campo 'Correo'";

            // Validaciones de formato
            if (!Regex.Match(txb_nombre.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").Success) return "El nombre solo debe contener letras, espacios, tildes y ñ.";
            if (!Regex.Match(txb_pass.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$").Success) return "La contraseña debe tener al menos 8 caracteres, incluir mayúsculas, minúsculas, números y caracteres especiales.";
            if (!Regex.Match(txb_correo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$").Success) return "El correo no tiene un formato válido.";
            
            return "Válido";
        }
    }
}
