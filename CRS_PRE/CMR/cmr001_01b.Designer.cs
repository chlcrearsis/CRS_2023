﻿namespace CRS_PRE
{
    partial class cmr001_01b
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_bus_car = new System.Windows.Forms.Button();
            this.cb_est_bus = new System.Windows.Forms.ComboBox();
            this.cb_prm_bus = new System.Windows.Forms.ComboBox();
            this.tb_tex_bus = new System.Windows.Forms.TextBox();
            this.lb_des_bus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_sel_bus = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.va_cod_lis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_lis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_fec_ini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_fec_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_mon_lis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_est_ado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_bus_car);
            this.groupBox1.Controls.Add(this.cb_est_bus);
            this.groupBox1.Controls.Add(this.cb_prm_bus);
            this.groupBox1.Controls.Add(this.tb_tex_bus);
            this.groupBox1.Controls.Add(this.lb_des_bus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_sel_bus);
            this.groupBox1.Location = new System.Drawing.Point(2, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 59);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // bt_bus_car
            // 
            this.bt_bus_car.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_car.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_car.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_car.Location = new System.Drawing.Point(461, 32);
            this.bt_bus_car.Name = "bt_bus_car";
            this.bt_bus_car.Size = new System.Drawing.Size(75, 23);
            this.bt_bus_car.TabIndex = 30;
            this.bt_bus_car.Text = "&Buscar";
            this.bt_bus_car.UseVisualStyleBackColor = false;
            this.bt_bus_car.Click += new System.EventHandler(this.Bt_bus_car_Click);
            // 
            // cb_est_bus
            // 
            this.cb_est_bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_est_bus.FormattingEnabled = true;
            this.cb_est_bus.Items.AddRange(new object[] {
            "Todos",
            "Habilitado",
            "Deshabilitado"});
            this.cb_est_bus.Location = new System.Drawing.Point(346, 33);
            this.cb_est_bus.Name = "cb_est_bus";
            this.cb_est_bus.Size = new System.Drawing.Size(114, 21);
            this.cb_est_bus.TabIndex = 25;
            // 
            // cb_prm_bus
            // 
            this.cb_prm_bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_prm_bus.FormattingEnabled = true;
            this.cb_prm_bus.Items.AddRange(new object[] {
            "Codigo",
            "Nombre"});
            this.cb_prm_bus.Location = new System.Drawing.Point(245, 33);
            this.cb_prm_bus.Name = "cb_prm_bus";
            this.cb_prm_bus.Size = new System.Drawing.Size(95, 21);
            this.cb_prm_bus.TabIndex = 20;
            // 
            // tb_tex_bus
            // 
            this.tb_tex_bus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_tex_bus.Location = new System.Drawing.Point(9, 34);
            this.tb_tex_bus.Name = "tb_tex_bus";
            this.tb_tex_bus.Size = new System.Drawing.Size(230, 20);
            this.tb_tex_bus.TabIndex = 15;
            this.tb_tex_bus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_sub_baj_fil_KeyDown);
            // 
            // lb_des_bus
            // 
            this.lb_des_bus.Location = new System.Drawing.Point(91, 13);
            this.lb_des_bus.Name = "lb_des_bus";
            this.lb_des_bus.Size = new System.Drawing.Size(210, 13);
            this.lb_des_bus.TabIndex = 2;
            this.lb_des_bus.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista";
            // 
            // tb_sel_bus
            // 
            this.tb_sel_bus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_sel_bus.Location = new System.Drawing.Point(43, 10);
            this.tb_sel_bus.MaxLength = 3;
            this.tb_sel_bus.Name = "tb_sel_bus";
            this.tb_sel_bus.Size = new System.Drawing.Size(42, 20);
            this.tb_sel_bus.TabIndex = 10;
            this.tb_sel_bus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_sub_baj_fil_KeyDown);
            this.tb_sel_bus.Validated += new System.EventHandler(this.Tb_sel_bus_Validated);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dg_res_ult);
            this.groupBox2.Location = new System.Drawing.Point(2, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(542, 199);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // dg_res_ult
            // 
            this.dg_res_ult.AllowUserToAddRows = false;
            this.dg_res_ult.AllowUserToDeleteRows = false;
            this.dg_res_ult.AllowUserToResizeRows = false;
            this.dg_res_ult.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_res_ult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_res_ult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_res_ult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_res_ult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.va_cod_lis,
            this.va_nom_lis,
            this.va_fec_ini,
            this.va_fec_fin,
            this.va_mon_lis,
            this.va_est_ado});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_res_ult.Location = new System.Drawing.Point(6, 7);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(530, 187);
            this.dg_res_ult.TabIndex = 35;
            this.dg_res_ult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellClick);
            this.dg_res_ult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellDoubleClick);
            this.dg_res_ult.SelectionChanged += new System.EventHandler(this.dg_res_ult_SelectionChanged);
            // 
            // va_cod_lis
            // 
            this.va_cod_lis.HeaderText = "Codigo";
            this.va_cod_lis.Name = "va_cod_lis";
            this.va_cod_lis.ReadOnly = true;
            this.va_cod_lis.Width = 50;
            // 
            // va_nom_lis
            // 
            this.va_nom_lis.HeaderText = "Lista";
            this.va_nom_lis.Name = "va_nom_lis";
            this.va_nom_lis.ReadOnly = true;
            this.va_nom_lis.Width = 180;
            // 
            // va_fec_ini
            // 
            this.va_fec_ini.HeaderText = "Vigencia";
            this.va_fec_ini.Name = "va_fec_ini";
            this.va_fec_ini.ReadOnly = true;
            this.va_fec_ini.Width = 70;
            // 
            // va_fec_fin
            // 
            this.va_fec_fin.HeaderText = "Caducidad";
            this.va_fec_fin.Name = "va_fec_fin";
            this.va_fec_fin.ReadOnly = true;
            this.va_fec_fin.Width = 70;
            // 
            // va_mon_lis
            // 
            this.va_mon_lis.HeaderText = "Moneda";
            this.va_mon_lis.Name = "va_mon_lis";
            this.va_mon_lis.ReadOnly = true;
            this.va_mon_lis.Width = 60;
            // 
            // va_est_ado
            // 
            this.va_est_ado.HeaderText = "Estado";
            this.va_est_ado.Name = "va_est_ado";
            this.va_est_ado.ReadOnly = true;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 241);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(542, 34);
            this.gb_ctr_btn.TabIndex = 8;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(461, 7);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 23);
            this.bt_can_cel.TabIndex = 45;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.Bt_can_cel_Click);
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(380, 7);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 23);
            this.bt_ace_pta.TabIndex = 40;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            this.bt_ace_pta.Click += new System.EventHandler(this.Bt_ace_pta_Click);
            // 
            // cmr001_01b
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(546, 275);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cmr001_01b";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Busca Documento";
            this.Text = "Busca Lista de Precio (Permitidas)";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).EndInit();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_bus_car;
        private System.Windows.Forms.ComboBox cb_est_bus;
        private System.Windows.Forms.ComboBox cb_prm_bus;
        private System.Windows.Forms.TextBox tb_tex_bus;
        private System.Windows.Forms.Label lb_des_bus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_res_ult;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Button bt_ace_pta;
        public System.Windows.Forms.TextBox tb_sel_bus;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_cod_lis;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_lis;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_fec_ini;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_fec_fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_mon_lis;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_est_ado;
    }
}