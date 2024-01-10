namespace CRS_PRE
{
    partial class ads023_09
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_car_dat = new System.Windows.Forms.Button();
            this.bt_bus_arc = new System.Windows.Forms.Button();
            this.tb_dir_arc = new System.Windows.Forms.TextBox();
            this.lb_arc_exc = new System.Windows.Forms.Label();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.va_nro_reg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_fec_tas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_tas_cam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_obs_reg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.pn_tot_reg = new System.Windows.Forms.Panel();
            this.lb_tot_reg = new System.Windows.Forms.Label();
            this.lb_sin_err = new System.Windows.Forms.Label();
            this.lb_con_err = new System.Windows.Forms.Label();
            this.tb_tot_reg = new System.Windows.Forms.Label();
            this.tb_sin_err = new System.Windows.Forms.Label();
            this.tb_con_err = new System.Windows.Forms.Label();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
            this.gb_ctr_btn.SuspendLayout();
            this.pn_tot_reg.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_car_dat);
            this.groupBox1.Controls.Add(this.bt_bus_arc);
            this.groupBox1.Controls.Add(this.tb_dir_arc);
            this.groupBox1.Controls.Add(this.lb_arc_exc);
            this.groupBox1.Controls.Add(this.dg_res_ult);
            this.groupBox1.Location = new System.Drawing.Point(3, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 264);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // bt_car_dat
            // 
            this.bt_car_dat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_car_dat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_car_dat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_car_dat.Location = new System.Drawing.Point(426, 25);
            this.bt_car_dat.Name = "bt_car_dat";
            this.bt_car_dat.Size = new System.Drawing.Size(75, 23);
            this.bt_car_dat.TabIndex = 9;
            this.bt_car_dat.Text = "&Cargar";
            this.bt_car_dat.UseVisualStyleBackColor = false;
            this.bt_car_dat.Click += new System.EventHandler(this.bt_car_dat_Click);
            // 
            // bt_bus_arc
            // 
            this.bt_bus_arc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_arc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_arc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_arc.Location = new System.Drawing.Point(346, 25);
            this.bt_bus_arc.Name = "bt_bus_arc";
            this.bt_bus_arc.Size = new System.Drawing.Size(75, 23);
            this.bt_bus_arc.TabIndex = 7;
            this.bt_bus_arc.Text = "&Buscar";
            this.bt_bus_arc.UseVisualStyleBackColor = false;
            this.bt_bus_arc.Click += new System.EventHandler(this.bt_bus_arc_Click);
            // 
            // tb_dir_arc
            // 
            this.tb_dir_arc.Location = new System.Drawing.Point(5, 27);
            this.tb_dir_arc.Name = "tb_dir_arc";
            this.tb_dir_arc.Size = new System.Drawing.Size(336, 20);
            this.tb_dir_arc.TabIndex = 4;
            // 
            // lb_arc_exc
            // 
            this.lb_arc_exc.AutoSize = true;
            this.lb_arc_exc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_arc_exc.Location = new System.Drawing.Point(3, 11);
            this.lb_arc_exc.Name = "lb_arc_exc";
            this.lb_arc_exc.Size = new System.Drawing.Size(89, 13);
            this.lb_arc_exc.TabIndex = 0;
            this.lb_arc_exc.Text = "Archivo Excel:";
            // 
            // dg_res_ult
            // 
            this.dg_res_ult.AllowUserToAddRows = false;
            this.dg_res_ult.AllowUserToDeleteRows = false;
            this.dg_res_ult.AllowUserToResizeRows = false;
            this.dg_res_ult.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_res_ult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_res_ult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dg_res_ult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_res_ult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.va_nro_reg,
            this.va_fec_tas,
            this.va_tas_cam,
            this.va_obs_reg});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle10;
            this.dg_res_ult.Location = new System.Drawing.Point(5, 52);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(501, 206);
            this.dg_res_ult.TabIndex = 8;
            // 
            // va_nro_reg
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.va_nro_reg.DefaultCellStyle = dataGridViewCellStyle7;
            this.va_nro_reg.HeaderText = "N°";
            this.va_nro_reg.Name = "va_nro_reg";
            this.va_nro_reg.ReadOnly = true;
            this.va_nro_reg.Width = 30;
            // 
            // va_fec_tas
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.va_fec_tas.DefaultCellStyle = dataGridViewCellStyle8;
            this.va_fec_tas.HeaderText = "Fecha Columna (A)";
            this.va_fec_tas.Name = "va_fec_tas";
            this.va_fec_tas.ReadOnly = true;
            this.va_fec_tas.Width = 98;
            // 
            // va_tas_cam
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.va_tas_cam.DefaultCellStyle = dataGridViewCellStyle9;
            this.va_tas_cam.HeaderText = "Tasa de Cambio Columna (B)";
            this.va_tas_cam.Name = "va_tas_cam";
            this.va_tas_cam.ReadOnly = true;
            this.va_tas_cam.Width = 120;
            // 
            // va_obs_reg
            // 
            this.va_obs_reg.HeaderText = "Observación";
            this.va_obs_reg.Name = "va_obs_reg";
            this.va_obs_reg.ReadOnly = true;
            this.va_obs_reg.Width = 230;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.pn_tot_reg);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 255);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(511, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // pn_tot_reg
            // 
            this.pn_tot_reg.Controls.Add(this.lb_tot_reg);
            this.pn_tot_reg.Controls.Add(this.lb_sin_err);
            this.pn_tot_reg.Controls.Add(this.lb_con_err);
            this.pn_tot_reg.Controls.Add(this.tb_tot_reg);
            this.pn_tot_reg.Controls.Add(this.tb_sin_err);
            this.pn_tot_reg.Controls.Add(this.tb_con_err);
            this.pn_tot_reg.Location = new System.Drawing.Point(5, 12);
            this.pn_tot_reg.Name = "pn_tot_reg";
            this.pn_tot_reg.Size = new System.Drawing.Size(326, 21);
            this.pn_tot_reg.TabIndex = 2;
            // 
            // lb_tot_reg
            // 
            this.lb_tot_reg.AutoSize = true;
            this.lb_tot_reg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tot_reg.Location = new System.Drawing.Point(214, 4);
            this.lb_tot_reg.Name = "lb_tot_reg";
            this.lb_tot_reg.Size = new System.Drawing.Size(44, 13);
            this.lb_tot_reg.TabIndex = 6;
            this.lb_tot_reg.Text = "Total :";
            // 
            // lb_sin_err
            // 
            this.lb_sin_err.AutoSize = true;
            this.lb_sin_err.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sin_err.Location = new System.Drawing.Point(110, 4);
            this.lb_sin_err.Name = "lb_sin_err";
            this.lb_sin_err.Size = new System.Drawing.Size(64, 13);
            this.lb_sin_err.TabIndex = 4;
            this.lb_sin_err.Text = "Sin Error :";
            // 
            // lb_con_err
            // 
            this.lb_con_err.AutoSize = true;
            this.lb_con_err.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_con_err.Location = new System.Drawing.Point(3, 4);
            this.lb_con_err.Name = "lb_con_err";
            this.lb_con_err.Size = new System.Drawing.Size(68, 13);
            this.lb_con_err.TabIndex = 2;
            this.lb_con_err.Text = "Con Error :";
            // 
            // tb_tot_reg
            // 
            this.tb_tot_reg.AutoSize = true;
            this.tb_tot_reg.Location = new System.Drawing.Point(256, 4);
            this.tb_tot_reg.Name = "tb_tot_reg";
            this.tb_tot_reg.Size = new System.Drawing.Size(34, 13);
            this.tb_tot_reg.TabIndex = 7;
            this.tb_tot_reg.Text = "3,500";
            // 
            // tb_sin_err
            // 
            this.tb_sin_err.AutoSize = true;
            this.tb_sin_err.Location = new System.Drawing.Point(172, 4);
            this.tb_sin_err.Name = "tb_sin_err";
            this.tb_sin_err.Size = new System.Drawing.Size(34, 13);
            this.tb_sin_err.TabIndex = 5;
            this.tb_sin_err.Text = "3,500";
            this.tb_sin_err.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_con_err
            // 
            this.tb_con_err.AutoSize = true;
            this.tb_con_err.Location = new System.Drawing.Point(70, 4);
            this.tb_con_err.Name = "tb_con_err";
            this.tb_con_err.Size = new System.Drawing.Size(34, 13);
            this.tb_con_err.TabIndex = 3;
            this.tb_con_err.Text = "3,500";
            this.tb_con_err.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(351, 10);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 25);
            this.bt_ace_pta.TabIndex = 0;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            this.bt_ace_pta.Click += new System.EventHandler(this.bt_ace_pta_Click);
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(430, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // ads023_09
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 297);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads023_09";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Importa Tasa de Cambio Bs/Ufv desde Excel";
            this.Text = "Importa Tasa de Cambio Bs/Ufv desde Excel";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).EndInit();
            this.gb_ctr_btn.ResumeLayout(false);
            this.pn_tot_reg.ResumeLayout(false);
            this.pn_tot_reg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Label lb_arc_exc;
        private System.Windows.Forms.TextBox tb_dir_arc;
        private System.Windows.Forms.Button bt_bus_arc;
        private System.Windows.Forms.DataGridView dg_res_ult;
        private System.Windows.Forms.Button bt_car_dat;
        private System.Windows.Forms.Label tb_tot_reg;
        private System.Windows.Forms.Label tb_sin_err;
        private System.Windows.Forms.Label lb_tot_reg;
        private System.Windows.Forms.Label lb_sin_err;
        private System.Windows.Forms.Label tb_con_err;
        private System.Windows.Forms.Label lb_con_err;
        private System.Windows.Forms.Panel pn_tot_reg;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nro_reg;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_fec_tas;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_tas_cam;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_obs_reg;
    }
}