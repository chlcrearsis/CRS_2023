﻿namespace CRS_PRE
{
    partial class ctb007_01
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_frm_hja = new System.Windows.Forms.MenuStrip();
            this.mn_cre_ar = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_cer_rar = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_fec_fin = new System.Windows.Forms.DateTimePicker();
            this.tb_fec_ini = new System.Windows.Forms.DateTimePicker();
            this.bt_bus_car = new System.Windows.Forms.Button();
            this.cb_prm_bus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_tex_bus = new System.Windows.Forms.TextBox();
            this.tb_sel_ecc = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.va_nro_dos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_ide_suc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_suc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_tip_nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_fec_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_con_tad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.bt_ace_pta = new System.Windows.Forms.Button();
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
            this.mn_cre_ar,
            this.mn_cer_rar});
            this.m_frm_hja.Location = new System.Drawing.Point(141, 49);
            this.m_frm_hja.Name = "m_frm_hja";
            this.m_frm_hja.Size = new System.Drawing.Size(215, 24);
            this.m_frm_hja.TabIndex = 5;
            this.m_frm_hja.Visible = false;
            // 
            // mn_cre_ar
            // 
            this.mn_cre_ar.Name = "mn_cre_ar";
            this.mn_cre_ar.Size = new System.Drawing.Size(42, 20);
            this.mn_cre_ar.Text = "&Crea";
            this.mn_cre_ar.Click += new System.EventHandler(this.mn_cre_ar_Click);
            // 
            // mn_cer_rar
            // 
            this.mn_cer_rar.Name = "mn_cer_rar";
            this.mn_cer_rar.Size = new System.Drawing.Size(45, 20);
            this.mn_cer_rar.Text = "&Atras";
            this.mn_cer_rar.Click += new System.EventHandler(this.Mn_cer_rar_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_fec_fin);
            this.groupBox1.Controls.Add(this.tb_fec_ini);
            this.groupBox1.Controls.Add(this.bt_bus_car);
            this.groupBox1.Controls.Add(this.cb_prm_bus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_tex_bus);
            this.groupBox1.Controls.Add(this.tb_sel_ecc);
            this.groupBox1.Location = new System.Drawing.Point(2, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 85);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "Al";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Del";
            // 
            // tb_fec_fin
            // 
            this.tb_fec_fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tb_fec_fin.Location = new System.Drawing.Point(170, 35);
            this.tb_fec_fin.Name = "tb_fec_fin";
            this.tb_fec_fin.Size = new System.Drawing.Size(95, 20);
            this.tb_fec_fin.TabIndex = 13;
            // 
            // tb_fec_ini
            // 
            this.tb_fec_ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tb_fec_ini.Location = new System.Drawing.Point(37, 35);
            this.tb_fec_ini.Name = "tb_fec_ini";
            this.tb_fec_ini.Size = new System.Drawing.Size(95, 20);
            this.tb_fec_ini.TabIndex = 12;
            // 
            // bt_bus_car
            // 
            this.bt_bus_car.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_car.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_car.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_car.Location = new System.Drawing.Point(461, 55);
            this.bt_bus_car.Name = "bt_bus_car";
            this.bt_bus_car.Size = new System.Drawing.Size(75, 23);
            this.bt_bus_car.TabIndex = 30;
            this.bt_bus_car.Text = "&Buscar";
            this.bt_bus_car.UseVisualStyleBackColor = false;
            this.bt_bus_car.Click += new System.EventHandler(this.Bt_bus_car_Click);
            // 
            // cb_prm_bus
            // 
            this.cb_prm_bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_prm_bus.FormattingEnabled = true;
            this.cb_prm_bus.Items.AddRange(new object[] {
            "Nro. Autprización"});
            this.cb_prm_bus.Location = new System.Drawing.Point(329, 56);
            this.cb_prm_bus.Name = "cb_prm_bus";
            this.cb_prm_bus.Size = new System.Drawing.Size(127, 21);
            this.cb_prm_bus.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Dosificación";
            // 
            // tb_tex_bus
            // 
            this.tb_tex_bus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_tex_bus.Location = new System.Drawing.Point(9, 57);
            this.tb_tex_bus.Name = "tb_tex_bus";
            this.tb_tex_bus.Size = new System.Drawing.Size(314, 20);
            this.tb_tex_bus.TabIndex = 15;
            this.tb_tex_bus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_sub_baj_fil_KeyDown);
            // 
            // tb_sel_ecc
            // 
            this.tb_sel_ecc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_sel_ecc.Location = new System.Drawing.Point(87, 10);
            this.tb_sel_ecc.MaxLength = 3;
            this.tb_sel_ecc.Name = "tb_sel_ecc";
            this.tb_sel_ecc.Size = new System.Drawing.Size(178, 20);
            this.tb_sel_ecc.TabIndex = 10;
            this.tb_sel_ecc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_sub_baj_fil_KeyDown);
            this.tb_sel_ecc.Validated += new System.EventHandler(this.Tb_sel_bus_Validated);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_frm_hja);
            this.groupBox2.Controls.Add(this.dg_res_ult);
            this.groupBox2.Location = new System.Drawing.Point(2, 80);
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
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_res_ult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dg_res_ult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_res_ult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.va_nro_dos,
            this.va_ide_suc,
            this.va_nom_suc,
            this.va_tip_nom,
            this.va_fec_fin,
            this.va_con_tad});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle15;
            this.dg_res_ult.Location = new System.Drawing.Point(6, 7);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(530, 187);
            this.dg_res_ult.TabIndex = 35;
            this.dg_res_ult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellClick);
            this.dg_res_ult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellDoubleClick);
            this.dg_res_ult.SelectionChanged += new System.EventHandler(this.dg_res_ult_SelectionChanged);
            // 
            // va_nro_dos
            // 
            this.va_nro_dos.HeaderText = "Nro Autororización";
            this.va_nro_dos.Name = "va_nro_dos";
            this.va_nro_dos.Width = 130;
            // 
            // va_ide_suc
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.va_ide_suc.DefaultCellStyle = dataGridViewCellStyle12;
            this.va_ide_suc.HeaderText = "ID. Suc.";
            this.va_ide_suc.Name = "va_ide_suc";
            this.va_ide_suc.Width = 40;
            // 
            // va_nom_suc
            // 
            this.va_nom_suc.HeaderText = "Sucursal";
            this.va_nom_suc.Name = "va_nom_suc";
            this.va_nom_suc.Width = 130;
            // 
            // va_tip_nom
            // 
            this.va_tip_nom.HeaderText = "Tipo de Factura";
            this.va_tip_nom.Name = "va_tip_nom";
            this.va_tip_nom.Width = 75;
            // 
            // va_fec_fin
            // 
            dataGridViewCellStyle13.Format = "d";
            dataGridViewCellStyle13.NullValue = null;
            this.va_fec_fin.DefaultCellStyle = dataGridViewCellStyle13;
            this.va_fec_fin.HeaderText = "Fecha Venc.";
            this.va_fec_fin.Name = "va_fec_fin";
            this.va_fec_fin.Width = 85;
            // 
            // va_con_tad
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.va_con_tad.DefaultCellStyle = dataGridViewCellStyle14;
            this.va_con_tad.HeaderText = "Contador";
            this.va_con_tad.Name = "va_con_tad";
            this.va_con_tad.Width = 65;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 273);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(542, 34);
            this.gb_ctr_btn.TabIndex = 8;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(461, 7);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 23);
            this.bt_can_cel.TabIndex = 45;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
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
            this.bt_ace_pta.Click += new System.EventHandler(this.bt_ace_pta_Click);
            // 
            // ctb007_01
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(546, 312);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.m_frm_hja;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ctb007_01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Busca Dosificación";
            this.Text = "Busca Dosificación";
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
        private System.Windows.Forms.ComboBox cb_prm_bus;
        private System.Windows.Forms.TextBox tb_tex_bus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_res_ult;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Button bt_ace_pta;
        public System.Windows.Forms.MenuStrip m_frm_hja;
        private System.Windows.Forms.ToolStripMenuItem mn_cre_ar;
        private System.Windows.Forms.ToolStripMenuItem mn_cer_rar;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker tb_fec_fin;
        private System.Windows.Forms.DateTimePicker tb_fec_ini;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nro_dos;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ide_suc;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_suc;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_tip_nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_fec_fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_con_tad;
        public System.Windows.Forms.TextBox tb_sel_ecc;
    }
}