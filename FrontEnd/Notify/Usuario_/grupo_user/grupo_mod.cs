using MaterialSkin.Controls;
using Not.Backend;
using System;
using System.Windows.Forms;

namespace Proyecto_1.FrontEnd.Notify.Usuario_.Grupo_User
{
    public partial class grupo_mod : MaterialForm
    {
        private Usuario u;
        private int opcion;
        private GrupoJson grupoJson = new GrupoJson();
        private GrupoJson aux;

        private string rutaArchivoJson;

        // insertar
        public grupo_mod(int opcion, Usuario u)
        {
            InitializeComponent();
            this.u = u;
            this.opcion = opcion;
            Text = "Quieres unirte a un nuevo grupo " + u.usuario + "!";

            rutaArchivoJson = @"C:\Users\nopes\OneDrive\Escritorio\Notify\main\Proyecto 1\JSON_\GruposUsuario\" + u.usuario + ".json";
        }

        // actualizar
        public grupo_mod(int opcion, Usuario u, GrupoJson grupoJson)
        {
            InitializeComponent();
            this.u = u;
            this.aux = grupoJson;
            this.opcion = opcion;
            Text = "Actualiza el grupo " + u.usuario;
            txb_nombre.Text = grupoJson.NOMBRE;
            txb_desc.Text = grupoJson.DESCRIPCIÓN;

            rutaArchivoJson = @"C:\Users\nopes\OneDrive\Escritorio\Notify\main\Proyecto 1\JSON_\GruposUsuario\" + u.usuario + ".json";
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            GrupNot gn = new GrupNot(u);
            gn.Show();
            this.Hide();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                string s = validar();
                if (s == "Válido")
                {
                    this.grupoJson.NOMBRE = txb_nombre.Text.ToString();
                    this.grupoJson.DESCRIPCIÓN = txb_desc.Text.ToString();

                    if (opcion == 1)
                    {
                        if (JsonHelper.GuardarGrupoJson(grupoJson, rutaArchivoJson))
                        {
                            MessageBox.Show("Grupo creado exitosamente.");
                            GrupNot gn = new GrupNot(u);
                            gn.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido crear el grupo...");
                        }
                    }
                    else
                    {
                        if (JsonHelper.actualizarGrupoJson(aux, grupoJson, rutaArchivoJson))
                        {
                            MessageBox.Show("Grupo actualizado exitosamente.");
                            GrupNot gn = new GrupNot(u);
                            gn.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido actualizar el grupo...");
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
            if (txb_nombre.Text.Length == 0 && txb_desc.Text.Length == 0) return "Debe llenar todos los campos.";
            if (txb_nombre.Text.Length == 0) return "Debe llenar el campo 'Nombre'.";
            if (txb_desc.Text.Length == 0) return "Debe llenar el campo 'Descripción'.";

            return "Válido";
        }
    }
}
