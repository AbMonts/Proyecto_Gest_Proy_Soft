using MaterialSkin;
using MaterialSkin.Controls;
using Not.Backend;
using Proyecto_1.FrontEnd.Notify.MENU_USUARIO.Seccion_User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_1.FrontEnd.Notify.Usuario_.Seccion_User
{
    public partial class seccion_mod : MaterialForm
    {
        private Usuario u;
        private int opcion;
        private SeccionJson seccionJson = new SeccionJson();
        private SeccionJson aux;

        private string rutaArchivoJson;

        // insertar
        public seccion_mod(int opcion, Usuario u)
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
            this.opcion = opcion;
            Text = "Crea una nueva sección " + u.usuario;

            //rutaArchivoJson = @"C:\Users\nopes\OneDrive\Escritorio\notify v4w diseño listo\notifaicuatrow\notifaicuatrow\Proyecto 1\JSON_\SeccionesUsuario\" + u.usuario + ".json";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\JSON_\SeccionesUsuario"));
            Directory.CreateDirectory(projectPath);
            rutaArchivoJson = Path.Combine(projectPath, u.usuario + ".json");
        }

        // actualizar
        public seccion_mod(int opcion, Usuario u, SeccionJson seccionJson)
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
            this.aux = seccionJson;
            this.opcion = opcion;
            Text = "Actualiza la sección " + u.usuario;
            txb_nombre.Text = seccionJson.NOMBRE;
            txb_desc.Text = seccionJson.DESCRIPCIÓN;
            txb_filtro.Text = seccionJson.FILTRO;

            //rutaArchivoJson = @"C:\Users\nopes\OneDrive\Escritorio\notify v4w diseño listo\notifaicuatrow\notifaicuatrow\Proyecto 1\JSON_\SeccionesUsuario\" + u.usuario + ".json";
            // Ruta dinamica
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\JSON_\SeccionesUsuario"));
            Directory.CreateDirectory(projectPath);
            rutaArchivoJson = Path.Combine(projectPath, u.usuario + ".json");
        }

        private void seccion_mod_Load(object sender, EventArgs e) 
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            SecNot sn = new SecNot(u);
            sn.Show();
            this.Hide();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                string s = validar();
                if (s == "Válido")
                {
                    this.seccionJson.NOMBRE = txb_nombre.Text.ToString();
                    this.seccionJson.DESCRIPCIÓN = txb_desc.Text.ToString();
                    this.seccionJson.FILTRO = txb_filtro.Text.ToString();

                    if (opcion == 1)
                    {
                        if (JsonHelper.GuardarSeccionJson(seccionJson, rutaArchivoJson))
                        {
                            MessageBox.Show("Sección creada exitosamente.");
                            SecNot sn = new SecNot(u);
                            sn.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido crear la sección...");
                        }
                    }
                    else
                    {
                        if (JsonHelper.actualizarSeccionJson(aux, seccionJson, rutaArchivoJson))
                        {
                            MessageBox.Show("Sección actualizada exitosamente.");
                            SecNot sn = new SecNot(u);
                            sn.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido actualizar la sección...");
                        }
                    }
                    

                    
                }
                else
                {
                    MessageBox.Show(s);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private string validar()
        {
            // Validaciones de llenado de datos
            if (txb_nombre.Text.Length == 0 && txb_desc.Text.Length == 0 && txb_filtro.Text.Length == 0) return "Debe llenar todos los campos.";
            if (txb_nombre.Text.Length == 0) return "Debe llenar el campo 'Nombre'.";
            if (txb_desc.Text.Length == 0) return "Debe llenar el campo 'Descripción'.";
            if (txb_filtro.Text.Length == 0) return "Debe llenar el campo 'Filtro'.";
            
            return "Válido";
        }
    }
}
