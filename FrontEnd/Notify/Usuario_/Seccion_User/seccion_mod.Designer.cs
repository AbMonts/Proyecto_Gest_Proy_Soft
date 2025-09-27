namespace Proyecto_1.FrontEnd.Notify.Usuario_.Seccion_User
{
    partial class seccion_mod
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_guardar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_back = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_filtro = new MaterialSkin.Controls.MaterialLabel();
            this.txb_filtro = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txb_nombre = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txb_desc = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lbl_desc = new MaterialSkin.Controls.MaterialLabel();
            this.lbl_nombre = new MaterialSkin.Controls.MaterialLabel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-1, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 308);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.btn_guardar);
            this.panel4.Controls.Add(this.btn_back);
            this.panel4.Location = new System.Drawing.Point(49, 216);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(492, 68);
            this.panel4.TabIndex = 3;
            // 
            // btn_guardar
            // 
            this.btn_guardar.AutoSize = true;
            this.btn_guardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_guardar.Depth = 0;
            this.btn_guardar.Icon = null;
            this.btn_guardar.Location = new System.Drawing.Point(364, 13);
            this.btn_guardar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Primary = true;
            this.btn_guardar.Size = new System.Drawing.Size(100, 36);
            this.btn_guardar.TabIndex = 5;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_back
            // 
            this.btn_back.AutoSize = true;
            this.btn_back.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_back.Depth = 0;
            this.btn_back.Icon = null;
            this.btn_back.Location = new System.Drawing.Point(17, 13);
            this.btn_back.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_back.Name = "btn_back";
            this.btn_back.Primary = true;
            this.btn_back.Size = new System.Drawing.Size(107, 36);
            this.btn_back.TabIndex = 4;
            this.btn_back.Text = "Regresar";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lbl_filtro);
            this.panel2.Controls.Add(this.txb_filtro);
            this.panel2.Controls.Add(this.txb_nombre);
            this.panel2.Controls.Add(this.txb_desc);
            this.panel2.Controls.Add(this.lbl_desc);
            this.panel2.Controls.Add(this.lbl_nombre);
            this.panel2.Location = new System.Drawing.Point(28, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(523, 154);
            this.panel2.TabIndex = 1;
            // 
            // lbl_filtro
            // 
            this.lbl_filtro.AutoSize = true;
            this.lbl_filtro.Depth = 0;
            this.lbl_filtro.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_filtro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_filtro.Location = new System.Drawing.Point(15, 99);
            this.lbl_filtro.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_filtro.Name = "lbl_filtro";
            this.lbl_filtro.Size = new System.Drawing.Size(54, 24);
            this.lbl_filtro.TabIndex = 5;
            this.lbl_filtro.Text = "Filtro";
            // 
            // txb_filtro
            // 
            this.txb_filtro.Depth = 0;
            this.txb_filtro.Hint = "";
            this.txb_filtro.Location = new System.Drawing.Point(195, 95);
            this.txb_filtro.MaxLength = 120;
            this.txb_filtro.MouseState = MaterialSkin.MouseState.HOVER;
            this.txb_filtro.Name = "txb_filtro";
            this.txb_filtro.PasswordChar = '\0';
            this.txb_filtro.SelectedText = "";
            this.txb_filtro.SelectionLength = 0;
            this.txb_filtro.SelectionStart = 0;
            this.txb_filtro.Size = new System.Drawing.Size(299, 28);
            this.txb_filtro.TabIndex = 4;
            this.txb_filtro.TabStop = false;
            this.txb_filtro.UseSystemPasswordChar = false;
            // 
            // txb_nombre
            // 
            this.txb_nombre.Depth = 0;
            this.txb_nombre.Hint = "";
            this.txb_nombre.Location = new System.Drawing.Point(195, 27);
            this.txb_nombre.MaxLength = 60;
            this.txb_nombre.MouseState = MaterialSkin.MouseState.HOVER;
            this.txb_nombre.Name = "txb_nombre";
            this.txb_nombre.PasswordChar = '\0';
            this.txb_nombre.SelectedText = "";
            this.txb_nombre.SelectionLength = 0;
            this.txb_nombre.SelectionStart = 0;
            this.txb_nombre.Size = new System.Drawing.Size(299, 28);
            this.txb_nombre.TabIndex = 2;
            this.txb_nombre.TabStop = false;
            this.txb_nombre.UseSystemPasswordChar = false;
            // 
            // txb_desc
            // 
            this.txb_desc.Depth = 0;
            this.txb_desc.Hint = "";
            this.txb_desc.Location = new System.Drawing.Point(195, 61);
            this.txb_desc.MaxLength = 60;
            this.txb_desc.MouseState = MaterialSkin.MouseState.HOVER;
            this.txb_desc.Name = "txb_desc";
            this.txb_desc.PasswordChar = '\0';
            this.txb_desc.SelectedText = "";
            this.txb_desc.SelectionLength = 0;
            this.txb_desc.SelectionStart = 0;
            this.txb_desc.Size = new System.Drawing.Size(299, 28);
            this.txb_desc.TabIndex = 3;
            this.txb_desc.TabStop = false;
            this.txb_desc.UseSystemPasswordChar = false;
            // 
            // lbl_desc
            // 
            this.lbl_desc.AutoSize = true;
            this.lbl_desc.Depth = 0;
            this.lbl_desc.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_desc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_desc.Location = new System.Drawing.Point(15, 66);
            this.lbl_desc.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_desc.Name = "lbl_desc";
            this.lbl_desc.Size = new System.Drawing.Size(110, 24);
            this.lbl_desc.TabIndex = 1;
            this.lbl_desc.Text = "Descripción";
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.Depth = 0;
            this.lbl_nombre.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_nombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_nombre.Location = new System.Drawing.Point(15, 31);
            this.lbl_nombre.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(79, 24);
            this.lbl_nombre.TabIndex = 0;
            this.lbl_nombre.Text = "Nombre";
            // 
            // seccion_mod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 360);
            this.Controls.Add(this.panel1);
            this.Name = "seccion_mod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sección";
            this.Load += new System.EventHandler(this.seccion_mod_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private MaterialSkin.Controls.MaterialRaisedButton btn_guardar;
        private MaterialSkin.Controls.MaterialRaisedButton btn_back;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialLabel lbl_filtro;
        private MaterialSkin.Controls.MaterialSingleLineTextField txb_filtro;
        private MaterialSkin.Controls.MaterialSingleLineTextField txb_nombre;
        private MaterialSkin.Controls.MaterialSingleLineTextField txb_desc;
        private MaterialSkin.Controls.MaterialLabel lbl_desc;
        private MaterialSkin.Controls.MaterialLabel lbl_nombre;
    }
}