﻿namespace CRS_PRE
{
    partial class adp004_01
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_frm_hja = new System.Windows.Forms.MenuStrip();
            this.mn_nue_reg = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_edi_tar = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_mod_ifi = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_hab_des = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_eli_min = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_con_sul = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_rep_ort = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_list_atr = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_cer_rar = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_ide_atr = new System.Windows.Forms.Label();
            this.bt_bus_tip = new System.Windows.Forms.Button();
            this.lb_nom_tip = new System.Windows.Forms.Label();
            this.bt_bus_car = new System.Windows.Forms.Button();
            this.cb_est_bus = new System.Windows.Forms.ComboBox();
            this.cb_prm_bus = new System.Windows.Forms.ComboBox();
            this.tb_tex_bus = new System.Windows.Forms.TextBox();
            this.lb_ide_tip = new System.Windows.Forms.Label();
            this.tb_ide_tip = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.va_ide_atr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_atr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_est_ado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.m_frm_hja.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_frm_hja
            // 
            this.m_frm_hja.Dock = System.Windows.Forms.DockStyle.None;
            this.m_frm_hja.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_nue_reg,
            this.mn_edi_tar,
            this.mn_con_sul,
            this.mn_rep_ort,
            this.mn_cer_rar});
            this.m_frm_hja.Location = new System.Drawing.Point(141, 49);
            this.m_frm_hja.Name = "m_frm_hja";
            this.m_frm_hja.Size = new System.Drawing.Size(268, 24);
            this.m_frm_hja.TabIndex = 5;
            this.m_frm_hja.Visible = false;
            // 
            // mn_nue_reg
            // 
            this.mn_nue_reg.Name = "mn_nue_reg";
            this.mn_nue_reg.Size = new System.Drawing.Size(43, 20);
            this.mn_nue_reg.Text = "&Crea";
            this.mn_nue_reg.Click += new System.EventHandler(this.mn_nue_reg_Click);
            // 
            // mn_edi_tar
            // 
            this.mn_edi_tar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_mod_ifi,
            this.mn_hab_des,
            this.mn_eli_min});
            this.mn_edi_tar.Name = "mn_edi_tar";
            this.mn_edi_tar.Size = new System.Drawing.Size(45, 20);
            this.mn_edi_tar.Text = "&Edita";
            // 
            // mn_mod_ifi
            // 
            this.mn_mod_ifi.Name = "mn_mod_ifi";
            this.mn_mod_ifi.Size = new System.Drawing.Size(178, 22);
            this.mn_mod_ifi.Text = "&Modifica";
            this.mn_mod_ifi.Click += new System.EventHandler(this.mn_mod_ifi_Click);
            // 
            // mn_hab_des
            // 
            this.mn_hab_des.Name = "mn_hab_des";
            this.mn_hab_des.Size = new System.Drawing.Size(178, 22);
            this.mn_hab_des.Text = "&Habilita/Deshabilita";
            this.mn_hab_des.Click += new System.EventHandler(this.mn_hab_des_Click);
            // 
            // mn_eli_min
            // 
            this.mn_eli_min.Name = "mn_eli_min";
            this.mn_eli_min.Size = new System.Drawing.Size(178, 22);
            this.mn_eli_min.Text = "E&limina";
            this.mn_eli_min.Click += new System.EventHandler(this.mn_eli_min_Click);
            // 
            // mn_con_sul
            // 
            this.mn_con_sul.Name = "mn_con_sul";
            this.mn_con_sul.Size = new System.Drawing.Size(66, 20);
            this.mn_con_sul.Text = "&Consulta";
            this.mn_con_sul.Click += new System.EventHandler(this.mn_con_sul_Click);
            // 
            // mn_rep_ort
            // 
            this.mn_rep_ort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_list_atr});
            this.mn_rep_ort.Name = "mn_rep_ort";
            this.mn_rep_ort.Size = new System.Drawing.Size(60, 20);
            this.mn_rep_ort.Text = "&Reporte";
            // 
            // mn_list_atr
            // 
            this.mn_list_atr.Name = "mn_list_atr";
            this.mn_list_atr.ShortcutKeyDisplayString = "R01";
            this.mn_list_atr.Size = new System.Drawing.Size(249, 22);
            this.mn_list_atr.Tag = "";
            this.mn_list_atr.Text = "&Lista Definición de Atributos";
            this.mn_list_atr.Click += new System.EventHandler(this.mn_lis_atr_Click);
            // 
            // mn_cer_rar
            // 
            this.mn_cer_rar.Name = "mn_cer_rar";
            this.mn_cer_rar.Size = new System.Drawing.Size(46, 20);
            this.mn_cer_rar.Text = "&Atras";
            this.mn_cer_rar.Click += new System.EventHandler(this.mn_cer_rar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_ide_atr);
            this.groupBox1.Controls.Add(this.bt_bus_tip);
            this.groupBox1.Controls.Add(this.lb_nom_tip);
            this.groupBox1.Controls.Add(this.bt_bus_car);
            this.groupBox1.Controls.Add(this.cb_est_bus);
            this.groupBox1.Controls.Add(this.cb_prm_bus);
            this.groupBox1.Controls.Add(this.tb_tex_bus);
            this.groupBox1.Controls.Add(this.lb_ide_tip);
            this.groupBox1.Controls.Add(this.tb_ide_tip);
            this.groupBox1.Location = new System.Drawing.Point(2, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tb_ide_atr
            // 
            this.tb_ide_atr.AutoSize = true;
            this.tb_ide_atr.Location = new System.Drawing.Point(516, 13);
            this.tb_ide_atr.Name = "tb_ide_atr";
            this.tb_ide_atr.Size = new System.Drawing.Size(16, 13);
            this.tb_ide_atr.TabIndex = 4;
            this.tb_ide_atr.Text = "...";
            this.tb_ide_atr.Visible = false;
            // 
            // bt_bus_tip
            // 
            this.bt_bus_tip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_tip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_tip.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_tip.Location = new System.Drawing.Point(120, 9);
            this.bt_bus_tip.Name = "bt_bus_tip";
            this.bt_bus_tip.Size = new System.Drawing.Size(16, 22);
            this.bt_bus_tip.TabIndex = 2;
            this.bt_bus_tip.TabStop = false;
            this.bt_bus_tip.Text = "|";
            this.bt_bus_tip.UseVisualStyleBackColor = false;
            this.bt_bus_tip.Click += new System.EventHandler(this.bt_bus_tip_Click);
            // 
            // lb_nom_tip
            // 
            this.lb_nom_tip.AutoSize = true;
            this.lb_nom_tip.Location = new System.Drawing.Point(138, 14);
            this.lb_nom_tip.Name = "lb_nom_tip";
            this.lb_nom_tip.Size = new System.Drawing.Size(16, 13);
            this.lb_nom_tip.TabIndex = 3;
            this.lb_nom_tip.Text = "...";
            // 
            // bt_bus_car
            // 
            this.bt_bus_car.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_car.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_car.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_car.Location = new System.Drawing.Point(461, 32);
            this.bt_bus_car.Name = "bt_bus_car";
            this.bt_bus_car.Size = new System.Drawing.Size(75, 23);
            this.bt_bus_car.TabIndex = 8;
            this.bt_bus_car.Text = "&Buscar";
            this.bt_bus_car.UseVisualStyleBackColor = false;
            this.bt_bus_car.Click += new System.EventHandler(this.bt_bus_car_Click);
            // 
            // cb_est_bus
            // 
            this.cb_est_bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_est_bus.FormattingEnabled = true;
            this.cb_est_bus.Items.AddRange(new object[] {
            "Todos",
            "Habilitado",
            "Deshabilitado"});
            this.cb_est_bus.Location = new System.Drawing.Point(344, 33);
            this.cb_est_bus.Name = "cb_est_bus";
            this.cb_est_bus.Size = new System.Drawing.Size(114, 21);
            this.cb_est_bus.TabIndex = 7;
            // 
            // cb_prm_bus
            // 
            this.cb_prm_bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_prm_bus.FormattingEnabled = true;
            this.cb_prm_bus.Items.AddRange(new object[] {
            "Codigo",
            "Nombre"});
            this.cb_prm_bus.Location = new System.Drawing.Point(246, 33);
            this.cb_prm_bus.Name = "cb_prm_bus";
            this.cb_prm_bus.Size = new System.Drawing.Size(95, 21);
            this.cb_prm_bus.TabIndex = 6;
            // 
            // tb_tex_bus
            // 
            this.tb_tex_bus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_tex_bus.Location = new System.Drawing.Point(6, 34);
            this.tb_tex_bus.Name = "tb_tex_bus";
            this.tb_tex_bus.Size = new System.Drawing.Size(236, 20);
            this.tb_tex_bus.TabIndex = 5;
            this.tb_tex_bus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_pre_tec_KeyDown);
            // 
            // lb_ide_tip
            // 
            this.lb_ide_tip.AutoSize = true;
            this.lb_ide_tip.Location = new System.Drawing.Point(9, 13);
            this.lb_ide_tip.Name = "lb_ide_tip";
            this.lb_ide_tip.Size = new System.Drawing.Size(67, 13);
            this.lb_ide_tip.TabIndex = 0;
            this.lb_ide_tip.Text = "Tipo Atributo";
            // 
            // tb_ide_tip
            // 
            this.tb_ide_tip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_tip.Location = new System.Drawing.Point(78, 10);
            this.tb_ide_tip.MaxLength = 3;
            this.tb_ide_tip.Name = "tb_ide_tip";
            this.tb_ide_tip.Size = new System.Drawing.Size(42, 20);
            this.tb_ide_tip.TabIndex = 1;
            this.tb_ide_tip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_ide_tip.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_ide_tip_KeyDown);
            this.tb_ide_tip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ide_tip_KeyPress);
            this.tb_ide_tip.Validated += new System.EventHandler(this.tb_ide_tip_Validated);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_frm_hja);
            this.groupBox2.Controls.Add(this.dg_res_ult);
            this.groupBox2.Location = new System.Drawing.Point(2, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(542, 199);
            this.groupBox2.TabIndex = 1;
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
            this.va_ide_atr,
            this.va_nom_atr,
            this.va_est_ado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_res_ult.Location = new System.Drawing.Point(6, 7);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(529, 187);
            this.dg_res_ult.TabIndex = 0;
            this.dg_res_ult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellClick);
            this.dg_res_ult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellDoubleClick);
            this.dg_res_ult.SelectionChanged += new System.EventHandler(this.dg_res_ult_SelectionChanged);
            this.dg_res_ult.Enter += new System.EventHandler(this.dg_res_ult_Enter);
            // 
            // va_ide_atr
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.va_ide_atr.DefaultCellStyle = dataGridViewCellStyle2;
            this.va_ide_atr.HeaderText = "Código";
            this.va_ide_atr.Name = "va_ide_atr";
            this.va_ide_atr.ReadOnly = true;
            this.va_ide_atr.Width = 60;
            // 
            // va_nom_atr
            // 
            this.va_nom_atr.HeaderText = "Nombre";
            this.va_nom_atr.Name = "va_nom_atr";
            this.va_nom_atr.ReadOnly = true;
            this.va_nom_atr.Width = 345;
            // 
            // va_est_ado
            // 
            this.va_est_ado.HeaderText = "Estado";
            this.va_est_ado.Name = "va_est_ado";
            this.va_est_ado.ReadOnly = true;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 241);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(542, 40);
            this.gb_ctr_btn.TabIndex = 2;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(382, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(461, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // adp004_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 282);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.m_frm_hja;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adp004_01";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Busca Definición de Atributos";
            this.Text = "Busca Definición de Atributos";
            this.Load += new System.EventHandler(this.frm_Load);
            this.m_frm_hja.ResumeLayout(false);
            this.m_frm_hja.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Label lb_ide_tip;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_res_ult;
        public System.Windows.Forms.MenuStrip m_frm_hja;
        private System.Windows.Forms.ToolStripMenuItem mn_nue_reg;
        private System.Windows.Forms.ToolStripMenuItem mn_edi_tar;
        private System.Windows.Forms.ToolStripMenuItem mn_rep_ort;
        private System.Windows.Forms.ToolStripMenuItem mn_cer_rar;
        private System.Windows.Forms.ToolStripMenuItem mn_mod_ifi;
        private System.Windows.Forms.ToolStripMenuItem mn_hab_des;
        private System.Windows.Forms.ToolStripMenuItem mn_eli_min;
        private System.Windows.Forms.ToolStripMenuItem mn_list_atr;
        private System.Windows.Forms.ToolStripMenuItem mn_con_sul;
        public System.Windows.Forms.TextBox tb_ide_tip;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Label lb_nom_tip;
        private System.Windows.Forms.Button bt_bus_tip;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ide_atr;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_atr;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_est_ado;
        public System.Windows.Forms.Label tb_ide_atr;
    }
}