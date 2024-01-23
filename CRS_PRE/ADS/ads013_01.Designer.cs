namespace CRS_PRE
{
    partial class ads013_01
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_frm_hja = new System.Windows.Forms.MenuStrip();
            this.mn_nue_reg = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_nue_glo = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_reg_glo = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_edi_tar = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_mod_ifi = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_eli_min = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_con_sul = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_rep_ort = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_lis_glo = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_cer_rar = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_ide_glo = new System.Windows.Forms.TextBox();
            this.lb_lin_sep = new System.Windows.Forms.Label();
            this.lb_nom_glo = new System.Windows.Forms.Label();
            this.bt_bus_car = new System.Windows.Forms.Button();
            this.cb_prm_bus = new System.Windows.Forms.ComboBox();
            this.tb_tex_bus = new System.Windows.Forms.TextBox();
            this.lb_ide_glo = new System.Windows.Forms.Label();
            this.tb_ide_mod = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.va_ide_mod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_mod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_ide_glo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_glo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_tip_glo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_glo_ent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_glo_dec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_glo_car = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.lb_nom_mod = new System.Windows.Forms.Label();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bt_cam_mod = new System.Windows.Forms.Button();
            this.m_frm_hja.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
            this.gb_ctr_btn.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.mn_nue_reg.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_nue_glo,
            this.mn_reg_glo});
            this.mn_nue_reg.Name = "mn_nue_reg";
            this.mn_nue_reg.Size = new System.Drawing.Size(43, 20);
            this.mn_nue_reg.Text = "&Crea";
            // 
            // mn_nue_glo
            // 
            this.mn_nue_glo.Name = "mn_nue_glo";
            this.mn_nue_glo.Size = new System.Drawing.Size(225, 22);
            this.mn_nue_glo.Text = "&Nueva Global";
            this.mn_nue_glo.Click += new System.EventHandler(this.mn_nue_glo_Click);
            // 
            // mn_reg_glo
            // 
            this.mn_reg_glo.Name = "mn_reg_glo";
            this.mn_reg_glo.Size = new System.Drawing.Size(225, 22);
            this.mn_reg_glo.Text = "Registra &Globales p/Defectos";
            this.mn_reg_glo.Click += new System.EventHandler(this.mn_reg_glo_Click);
            // 
            // mn_edi_tar
            // 
            this.mn_edi_tar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_mod_ifi,
            this.mn_eli_min});
            this.mn_edi_tar.Name = "mn_edi_tar";
            this.mn_edi_tar.Size = new System.Drawing.Size(45, 20);
            this.mn_edi_tar.Text = "&Edita";
            // 
            // mn_mod_ifi
            // 
            this.mn_mod_ifi.Name = "mn_mod_ifi";
            this.mn_mod_ifi.Size = new System.Drawing.Size(121, 22);
            this.mn_mod_ifi.Text = "&Modifica";
            this.mn_mod_ifi.Click += new System.EventHandler(this.mn_mod_ifi_Click);
            // 
            // mn_eli_min
            // 
            this.mn_eli_min.Name = "mn_eli_min";
            this.mn_eli_min.Size = new System.Drawing.Size(121, 22);
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
            this.mn_lis_glo});
            this.mn_rep_ort.Name = "mn_rep_ort";
            this.mn_rep_ort.Size = new System.Drawing.Size(60, 20);
            this.mn_rep_ort.Text = "&Reporte";
            // 
            // mn_lis_glo
            // 
            this.mn_lis_glo.Name = "mn_lis_glo";
            this.mn_lis_glo.ShortcutKeyDisplayString = "(ads013_01)";
            this.mn_lis_glo.Size = new System.Drawing.Size(287, 22);
            this.mn_lis_glo.Text = "&Lista Definición de Globales";
            this.mn_lis_glo.Click += new System.EventHandler(this.mn_lis_glo_Click);
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
            this.groupBox1.Controls.Add(this.tb_ide_glo);
            this.groupBox1.Controls.Add(this.lb_lin_sep);
            this.groupBox1.Controls.Add(this.lb_nom_glo);
            this.groupBox1.Controls.Add(this.bt_bus_car);
            this.groupBox1.Controls.Add(this.cb_prm_bus);
            this.groupBox1.Controls.Add(this.tb_tex_bus);
            this.groupBox1.Controls.Add(this.lb_ide_glo);
            this.groupBox1.Controls.Add(this.tb_ide_mod);
            this.groupBox1.Location = new System.Drawing.Point(2, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tb_ide_glo
            // 
            this.tb_ide_glo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_glo.Location = new System.Drawing.Point(77, 10);
            this.tb_ide_glo.MaxLength = 3;
            this.tb_ide_glo.Name = "tb_ide_glo";
            this.tb_ide_glo.Size = new System.Drawing.Size(30, 20);
            this.tb_ide_glo.TabIndex = 8;
            this.tb_ide_glo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ide_glo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ide_glo_KeyPress);
            this.tb_ide_glo.Validated += new System.EventHandler(this.tb_ide_glo_Validated);
            // 
            // lb_lin_sep
            // 
            this.lb_lin_sep.AutoSize = true;
            this.lb_lin_sep.Location = new System.Drawing.Point(68, 13);
            this.lb_lin_sep.Name = "lb_lin_sep";
            this.lb_lin_sep.Size = new System.Drawing.Size(10, 13);
            this.lb_lin_sep.TabIndex = 7;
            this.lb_lin_sep.Text = "-";
            // 
            // lb_nom_glo
            // 
            this.lb_nom_glo.AutoSize = true;
            this.lb_nom_glo.Location = new System.Drawing.Point(109, 13);
            this.lb_nom_glo.Name = "lb_nom_glo";
            this.lb_nom_glo.Size = new System.Drawing.Size(16, 13);
            this.lb_nom_glo.TabIndex = 2;
            this.lb_nom_glo.Text = "...";
            // 
            // bt_bus_car
            // 
            this.bt_bus_car.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_car.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_car.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_car.Location = new System.Drawing.Point(528, 34);
            this.bt_bus_car.Name = "bt_bus_car";
            this.bt_bus_car.Size = new System.Drawing.Size(75, 23);
            this.bt_bus_car.TabIndex = 6;
            this.bt_bus_car.Text = "&Buscar";
            this.bt_bus_car.UseVisualStyleBackColor = false;
            this.bt_bus_car.Click += new System.EventHandler(this.bt_bus_car_Click);
            // 
            // cb_prm_bus
            // 
            this.cb_prm_bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_prm_bus.FormattingEnabled = true;
            this.cb_prm_bus.Items.AddRange(new object[] {
            "ID. Global",
            "Nombre"});
            this.cb_prm_bus.Location = new System.Drawing.Point(430, 35);
            this.cb_prm_bus.Name = "cb_prm_bus";
            this.cb_prm_bus.Size = new System.Drawing.Size(95, 21);
            this.cb_prm_bus.TabIndex = 4;
            // 
            // tb_tex_bus
            // 
            this.tb_tex_bus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_tex_bus.Location = new System.Drawing.Point(9, 36);
            this.tb_tex_bus.Name = "tb_tex_bus";
            this.tb_tex_bus.Size = new System.Drawing.Size(417, 20);
            this.tb_tex_bus.TabIndex = 3;
            this.tb_tex_bus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_pre_tec_KeyDown);
            // 
            // lb_ide_glo
            // 
            this.lb_ide_glo.AutoSize = true;
            this.lb_ide_glo.Location = new System.Drawing.Point(9, 13);
            this.lb_ide_glo.Name = "lb_ide_glo";
            this.lb_ide_glo.Size = new System.Drawing.Size(37, 13);
            this.lb_ide_glo.TabIndex = 0;
            this.lb_ide_glo.Text = "Global";
            // 
            // tb_ide_mod
            // 
            this.tb_ide_mod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_mod.Location = new System.Drawing.Point(48, 10);
            this.tb_ide_mod.MaxLength = 3;
            this.tb_ide_mod.Name = "tb_ide_mod";
            this.tb_ide_mod.Size = new System.Drawing.Size(20, 20);
            this.tb_ide_mod.TabIndex = 1;
            this.tb_ide_mod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ide_mod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_pre_tec_KeyDown);
            this.tb_ide_mod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ide_mod_KeyPress);
            this.tb_ide_mod.Validated += new System.EventHandler(this.tb_ide_mod_Validated);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_frm_hja);
            this.groupBox2.Controls.Add(this.dg_res_ult);
            this.groupBox2.Location = new System.Drawing.Point(2, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(621, 224);
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_res_ult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dg_res_ult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_res_ult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.va_ide_mod,
            this.va_nom_mod,
            this.va_ide_glo,
            this.va_nom_glo,
            this.va_tip_glo,
            this.va_glo_ent,
            this.va_glo_dec,
            this.va_glo_car});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle12;
            this.dg_res_ult.Location = new System.Drawing.Point(6, 7);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(609, 212);
            this.dg_res_ult.TabIndex = 0;
            this.dg_res_ult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellClick);
            this.dg_res_ult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellDoubleClick);
            this.dg_res_ult.SelectionChanged += new System.EventHandler(this.dg_res_ult_SelectionChanged);
            this.dg_res_ult.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dg_res_ult_PreviewKeyDown);
            // 
            // va_ide_mod
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.va_ide_mod.DefaultCellStyle = dataGridViewCellStyle10;
            this.va_ide_mod.HeaderText = "ID.";
            this.va_ide_mod.Name = "va_ide_mod";
            this.va_ide_mod.ReadOnly = true;
            this.va_ide_mod.Width = 30;
            // 
            // va_nom_mod
            // 
            this.va_nom_mod.HeaderText = "Módulo";
            this.va_nom_mod.Name = "va_nom_mod";
            this.va_nom_mod.ReadOnly = true;
            this.va_nom_mod.Width = 140;
            // 
            // va_ide_glo
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.va_ide_glo.DefaultCellStyle = dataGridViewCellStyle11;
            this.va_ide_glo.HeaderText = "ID.";
            this.va_ide_glo.Name = "va_ide_glo";
            this.va_ide_glo.ReadOnly = true;
            this.va_ide_glo.Width = 30;
            // 
            // va_nom_glo
            // 
            this.va_nom_glo.HeaderText = "Global";
            this.va_nom_glo.Name = "va_nom_glo";
            this.va_nom_glo.ReadOnly = true;
            this.va_nom_glo.Width = 200;
            // 
            // va_tip_glo
            // 
            this.va_tip_glo.HeaderText = "Tipo";
            this.va_tip_glo.Name = "va_tip_glo";
            this.va_tip_glo.ReadOnly = true;
            this.va_tip_glo.Width = 55;
            // 
            // va_glo_ent
            // 
            this.va_glo_ent.HeaderText = "Entero";
            this.va_glo_ent.Name = "va_glo_ent";
            this.va_glo_ent.ReadOnly = true;
            this.va_glo_ent.Width = 60;
            // 
            // va_glo_dec
            // 
            this.va_glo_dec.HeaderText = "Decimal";
            this.va_glo_dec.Name = "va_glo_dec";
            this.va_glo_dec.ReadOnly = true;
            this.va_glo_dec.Width = 90;
            // 
            // va_glo_car
            // 
            this.va_glo_car.HeaderText = "Caracter";
            this.va_glo_car.Name = "va_glo_car";
            this.va_glo_car.ReadOnly = true;
            this.va_glo_car.Width = 170;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.lb_nom_mod);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(117, 277);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(506, 40);
            this.gb_ctr_btn.TabIndex = 3;
            this.gb_ctr_btn.TabStop = false;
            // 
            // lb_nom_mod
            // 
            this.lb_nom_mod.AutoSize = true;
            this.lb_nom_mod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nom_mod.Location = new System.Drawing.Point(6, 16);
            this.lb_nom_mod.Name = "lb_nom_mod";
            this.lb_nom_mod.Size = new System.Drawing.Size(19, 13);
            this.lb_nom_mod.TabIndex = 0;
            this.lb_nom_mod.Text = "...";
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(349, 9);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 25);
            this.bt_ace_pta.TabIndex = 1;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            this.bt_ace_pta.Click += new System.EventHandler(this.bt_ace_pta_Click);
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(427, 9);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 2;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bt_cam_mod);
            this.groupBox3.Location = new System.Drawing.Point(2, 277);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(113, 40);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // bt_cam_mod
            // 
            this.bt_cam_mod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_cam_mod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_cam_mod.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_cam_mod.Location = new System.Drawing.Point(6, 10);
            this.bt_cam_mod.Name = "bt_cam_mod";
            this.bt_cam_mod.Size = new System.Drawing.Size(101, 23);
            this.bt_cam_mod.TabIndex = 0;
            this.bt_cam_mod.Text = "&Cambiar Módulo";
            this.bt_cam_mod.UseVisualStyleBackColor = false;
            this.bt_cam_mod.Click += new System.EventHandler(this.bt_cam_mod_Click);
            // 
            // ads013_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 318);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.m_frm_hja;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads013_01";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Busca Globales";
            this.Text = "Busca Globales";
            this.Load += new System.EventHandler(this.frm_Load);
            this.m_frm_hja.ResumeLayout(false);
            this.m_frm_hja.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).EndInit();
            this.gb_ctr_btn.ResumeLayout(false);
            this.gb_ctr_btn.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_bus_car;
        private System.Windows.Forms.ComboBox cb_prm_bus;
        private System.Windows.Forms.TextBox tb_tex_bus;
        private System.Windows.Forms.Label lb_ide_glo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_res_ult;
        public System.Windows.Forms.MenuStrip m_frm_hja;
        private System.Windows.Forms.ToolStripMenuItem mn_nue_reg;
        private System.Windows.Forms.ToolStripMenuItem mn_edi_tar;
        private System.Windows.Forms.ToolStripMenuItem mn_rep_ort;
        private System.Windows.Forms.ToolStripMenuItem mn_cer_rar;
        private System.Windows.Forms.ToolStripMenuItem mn_mod_ifi;
        private System.Windows.Forms.ToolStripMenuItem mn_eli_min;
        private System.Windows.Forms.ToolStripMenuItem mn_lis_glo;
        private System.Windows.Forms.ToolStripMenuItem mn_con_sul;
        public System.Windows.Forms.TextBox tb_ide_mod;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        public System.Windows.Forms.Label lb_nom_glo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bt_cam_mod;
        private System.Windows.Forms.Label lb_nom_mod;
        private System.Windows.Forms.ToolStripMenuItem mn_nue_glo;
        private System.Windows.Forms.ToolStripMenuItem mn_reg_glo;
        public System.Windows.Forms.TextBox tb_ide_glo;
        public System.Windows.Forms.Label lb_lin_sep;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ide_mod;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_mod;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ide_glo;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_glo;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_tip_glo;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_glo_ent;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_glo_dec;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_glo_car;
    }
}