namespace Proyecto_1.FrontEnd.Notify.Usuario_.Grupo_User
{
    partial class GrupNot
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.main_panel = new System.Windows.Forms.Panel();
            this.menu_lbl = new MaterialSkin.Controls.MaterialLabel();
            this.btn_panel = new System.Windows.Forms.Panel();
            this.btn_entrar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_delete = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_update = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_add = new MaterialSkin.Controls.MaterialRaisedButton();
            this.grid_panel = new System.Windows.Forms.Panel();
            this.dgv_grup = new System.Windows.Forms.DataGridView();
            this.menu_panel = new System.Windows.Forms.Panel();
            this.btn_back = new MaterialSkin.Controls.MaterialRaisedButton();
            this.main_panel.SuspendLayout();
            this.btn_panel.SuspendLayout();
            this.grid_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_grup)).BeginInit();
            this.menu_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_panel
            // 
            this.main_panel.BackColor = System.Drawing.Color.PowderBlue;
            this.main_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.main_panel.Controls.Add(this.menu_lbl);
            this.main_panel.Controls.Add(this.btn_panel);
            this.main_panel.Controls.Add(this.grid_panel);
            this.main_panel.Controls.Add(this.menu_panel);
            this.main_panel.Location = new System.Drawing.Point(0, 64);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(977, 438);
            this.main_panel.TabIndex = 2;
            // 
            // menu_lbl
            // 
            this.menu_lbl.AutoSize = true;
            this.menu_lbl.Depth = 0;
            this.menu_lbl.Font = new System.Drawing.Font("Roboto", 11F);
            this.menu_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menu_lbl.Location = new System.Drawing.Point(193, 30);
            this.menu_lbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.menu_lbl.Name = "menu_lbl";
            this.menu_lbl.Size = new System.Drawing.Size(25, 24);
            this.menu_lbl.TabIndex = 1;
            this.menu_lbl.Text = "---";
            // 
            // btn_panel
            // 
            this.btn_panel.BackColor = System.Drawing.Color.LightSlateGray;
            this.btn_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btn_panel.Controls.Add(this.btn_entrar);
            this.btn_panel.Controls.Add(this.btn_delete);
            this.btn_panel.Controls.Add(this.btn_update);
            this.btn_panel.Controls.Add(this.btn_add);
            this.btn_panel.Location = new System.Drawing.Point(186, 315);
            this.btn_panel.Name = "btn_panel";
            this.btn_panel.Size = new System.Drawing.Size(725, 86);
            this.btn_panel.TabIndex = 2;
            // 
            // btn_entrar
            // 
            this.btn_entrar.AutoSize = true;
            this.btn_entrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_entrar.Depth = 0;
            this.btn_entrar.Enabled = false;
            this.btn_entrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_entrar.Icon = null;
            this.btn_entrar.Location = new System.Drawing.Point(593, 27);
            this.btn_entrar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_entrar.Name = "btn_entrar";
            this.btn_entrar.Primary = true;
            this.btn_entrar.Size = new System.Drawing.Size(87, 36);
            this.btn_entrar.TabIndex = 3;
            this.btn_entrar.Text = "Entrar";
            this.btn_entrar.UseVisualStyleBackColor = true;
            this.btn_entrar.Click += new System.EventHandler(this.btn_entrar_Click_1);
            // 
            // btn_delete
            // 
            this.btn_delete.AutoSize = true;
            this.btn_delete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_delete.Depth = 0;
            this.btn_delete.Enabled = false;
            this.btn_delete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_delete.Icon = null;
            this.btn_delete.Location = new System.Drawing.Point(344, 26);
            this.btn_delete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Primary = true;
            this.btn_delete.Size = new System.Drawing.Size(100, 36);
            this.btn_delete.TabIndex = 2;
            this.btn_delete.Text = "Eliminar";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_update
            // 
            this.btn_update.AutoSize = true;
            this.btn_update.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_update.Depth = 0;
            this.btn_update.Enabled = false;
            this.btn_update.Icon = null;
            this.btn_update.Location = new System.Drawing.Point(179, 27);
            this.btn_update.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_update.Name = "btn_update";
            this.btn_update.Primary = true;
            this.btn_update.Size = new System.Drawing.Size(124, 36);
            this.btn_update.TabIndex = 1;
            this.btn_update.Text = "Actualizar";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_add
            // 
            this.btn_add.AutoSize = true;
            this.btn_add.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_add.Depth = 0;
            this.btn_add.Icon = null;
            this.btn_add.Location = new System.Drawing.Point(40, 26);
            this.btn_add.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_add.Name = "btn_add";
            this.btn_add.Primary = true;
            this.btn_add.Size = new System.Drawing.Size(84, 36);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "Añadir";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // grid_panel
            // 
            this.grid_panel.BackColor = System.Drawing.Color.LightSlateGray;
            this.grid_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_panel.Controls.Add(this.dgv_grup);
            this.grid_panel.Location = new System.Drawing.Point(197, 71);
            this.grid_panel.Name = "grid_panel";
            this.grid_panel.Size = new System.Drawing.Size(704, 198);
            this.grid_panel.TabIndex = 1;
            // 
            // dgv_grup
            // 
            this.dgv_grup.AllowUserToAddRows = false;
            this.dgv_grup.AllowUserToDeleteRows = false;
            this.dgv_grup.AllowUserToResizeColumns = false;
            this.dgv_grup.AllowUserToResizeRows = false;
            this.dgv_grup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_grup.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgv_grup.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.dgv_grup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_grup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_grup.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_grup.Location = new System.Drawing.Point(40, 23);
            this.dgv_grup.Name = "dgv_grup";
            this.dgv_grup.ReadOnly = true;
            this.dgv_grup.RowHeadersVisible = false;
            this.dgv_grup.RowHeadersWidth = 51;
            this.dgv_grup.RowTemplate.Height = 24;
            this.dgv_grup.Size = new System.Drawing.Size(614, 142);
            this.dgv_grup.TabIndex = 6;
            this.dgv_grup.CellClick += this.dgv_grup_CellClick;
            // 
            // menu_panel
            // 
            this.menu_panel.BackColor = System.Drawing.Color.LightSlateGray;
            this.menu_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.menu_panel.Controls.Add(this.btn_back);
            this.menu_panel.Location = new System.Drawing.Point(0, -2);
            this.menu_panel.Name = "menu_panel";
            this.menu_panel.Size = new System.Drawing.Size(129, 417);
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
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // GrupNot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 475);
            this.Controls.Add(this.main_panel);
            this.Name = "GrupNot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupos";
            this.Load += new System.EventHandler(this.GrupNot_Load);
            this.main_panel.ResumeLayout(false);
            this.main_panel.PerformLayout();
            this.btn_panel.ResumeLayout(false);
            this.btn_panel.PerformLayout();
            this.grid_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_grup)).EndInit();
            this.menu_panel.ResumeLayout(false);
            this.menu_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel main_panel;
        private MaterialSkin.Controls.MaterialLabel menu_lbl;
        private System.Windows.Forms.Panel btn_panel;
        private MaterialSkin.Controls.MaterialRaisedButton btn_entrar;
        private MaterialSkin.Controls.MaterialRaisedButton btn_delete;
        private MaterialSkin.Controls.MaterialRaisedButton btn_update;
        private MaterialSkin.Controls.MaterialRaisedButton btn_add;
        private System.Windows.Forms.Panel grid_panel;
        private System.Windows.Forms.DataGridView dgv_grup;
        private System.Windows.Forms.Panel menu_panel;
        private MaterialSkin.Controls.MaterialRaisedButton btn_back;
    }
}