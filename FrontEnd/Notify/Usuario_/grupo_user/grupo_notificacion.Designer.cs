namespace Proyecto_1.FrontEnd.Notify.Usuario_.Grupo_User
{
    partial class grupo_notificacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.main_panel = new System.Windows.Forms.Panel();
            this.lbl_bienvenue = new MaterialSkin.Controls.MaterialLabel();
            this.grid_panel = new System.Windows.Forms.Panel();
            this.dgv_not = new System.Windows.Forms.DataGridView();
            this.menu_panel = new System.Windows.Forms.Panel();
            this.btn_back = new MaterialSkin.Controls.MaterialRaisedButton();
            this.main_panel.SuspendLayout();
            this.grid_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_not)).BeginInit();
            this.menu_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_panel
            // 
            this.main_panel.BackColor = System.Drawing.Color.PowderBlue;
            this.main_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.main_panel.Controls.Add(this.lbl_bienvenue);
            this.main_panel.Controls.Add(this.grid_panel);
            this.main_panel.Controls.Add(this.menu_panel);
            this.main_panel.Location = new System.Drawing.Point(-2, 63);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(1107, 416);
            this.main_panel.TabIndex = 4;
            // 
            // lbl_bienvenue
            // 
            this.lbl_bienvenue.AutoSize = true;
            this.lbl_bienvenue.Depth = 0;
            this.lbl_bienvenue.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_bienvenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_bienvenue.Location = new System.Drawing.Point(147, 4);
            this.lbl_bienvenue.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_bienvenue.Name = "lbl_bienvenue";
            this.lbl_bienvenue.Size = new System.Drawing.Size(25, 24);
            this.lbl_bienvenue.TabIndex = 1;
            this.lbl_bienvenue.Text = "---";
            // 
            // grid_panel
            // 
            this.grid_panel.BackColor = System.Drawing.Color.LightSlateGray;
            this.grid_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_panel.Controls.Add(this.dgv_not);
            this.grid_panel.Location = new System.Drawing.Point(151, 50);
            this.grid_panel.Name = "grid_panel";
            this.grid_panel.Size = new System.Drawing.Size(935, 330);
            this.grid_panel.TabIndex = 1;
            // 
            // dgv_not
            // 
            this.dgv_not.AllowUserToAddRows = false;
            this.dgv_not.AllowUserToDeleteRows = false;
            this.dgv_not.AllowUserToResizeColumns = false;
            this.dgv_not.AllowUserToResizeRows = false;
            this.dgv_not.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_not.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgv_not.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.dgv_not.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_not.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_not.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_not.Location = new System.Drawing.Point(40, 38);
            this.dgv_not.Name = "dgv_not";
            this.dgv_not.ReadOnly = true;
            this.dgv_not.RowHeadersVisible = false;
            this.dgv_not.RowHeadersWidth = 51;
            this.dgv_not.RowTemplate.Height = 24;
            this.dgv_not.Size = new System.Drawing.Size(857, 269);
            this.dgv_not.TabIndex = 6;
            // 
            // menu_panel
            // 
            this.menu_panel.BackColor = System.Drawing.Color.LightSlateGray;
            this.menu_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.menu_panel.Controls.Add(this.btn_back);
            this.menu_panel.Location = new System.Drawing.Point(0, -2);
            this.menu_panel.Name = "menu_panel";
            this.menu_panel.Size = new System.Drawing.Size(141, 417);
            this.menu_panel.TabIndex = 0;
            // 
            // btn_back
            // 
            this.btn_back.AutoSize = true;
            this.btn_back.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_back.Depth = 0;
            this.btn_back.Icon = null;
            this.btn_back.Location = new System.Drawing.Point(3, 344);
            this.btn_back.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_back.Name = "btn_back";
            this.btn_back.Primary = true;
            this.btn_back.Size = new System.Drawing.Size(107, 36);
            this.btn_back.TabIndex = 0;
            this.btn_back.Text = "Regresar";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click_1);
            // 
            // grupo_notificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 475);
            this.Controls.Add(this.main_panel);
            this.Name = "grupo_notificacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "grupo_notificacion";
            this.Load += new System.EventHandler(this.grupo_notificacion_Load);
            this.main_panel.ResumeLayout(false);
            this.main_panel.PerformLayout();
            this.grid_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_not)).EndInit();
            this.menu_panel.ResumeLayout(false);
            this.menu_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel main_panel;
        private MaterialSkin.Controls.MaterialLabel lbl_bienvenue;
        private System.Windows.Forms.Panel grid_panel;
        private System.Windows.Forms.DataGridView dgv_not;
        private System.Windows.Forms.Panel menu_panel;
        private MaterialSkin.Controls.MaterialRaisedButton btn_back;
    }
}