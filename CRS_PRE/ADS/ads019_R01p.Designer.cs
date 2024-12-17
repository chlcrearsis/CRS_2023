namespace CRS_PRE
{
    partial class ads019_R01p
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_nom_mod = new System.Windows.Forms.Label();
            this.lb_ide_mod = new System.Windows.Forms.Label();
            this.tb_ide_mod = new System.Windows.Forms.TextBox();
            this.bt_bus_mod = new System.Windows.Forms.Button();
            this.cb_tip_ope = new System.Windows.Forms.ComboBox();
            this.lb_tip_ope = new System.Windows.Forms.Label();
            this.tb_fch_fin = new System.Windows.Forms.MaskedTextBox();
            this.lb_fch_fin = new System.Windows.Forms.Label();
            this.tb_fch_ini = new System.Windows.Forms.MaskedTextBox();
            this.lb_fch_ini = new System.Windows.Forms.Label();
            this.lb_apl_fin = new System.Windows.Forms.Label();
            this.tb_apl_fin = new System.Windows.Forms.TextBox();
            this.lb_apl_ini = new System.Windows.Forms.Label();
            this.tb_apl_ini = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_nom_mod);
            this.groupBox1.Controls.Add(this.lb_ide_mod);
            this.groupBox1.Controls.Add(this.tb_ide_mod);
            this.groupBox1.Controls.Add(this.bt_bus_mod);
            this.groupBox1.Controls.Add(this.cb_tip_ope);
            this.groupBox1.Controls.Add(this.lb_tip_ope);
            this.groupBox1.Controls.Add(this.tb_fch_fin);
            this.groupBox1.Controls.Add(this.lb_fch_fin);
            this.groupBox1.Controls.Add(this.tb_fch_ini);
            this.groupBox1.Controls.Add(this.lb_fch_ini);
            this.groupBox1.Controls.Add(this.lb_apl_fin);
            this.groupBox1.Controls.Add(this.tb_apl_fin);
            this.groupBox1.Controls.Add(this.lb_apl_ini);
            this.groupBox1.Controls.Add(this.tb_apl_ini);
            this.groupBox1.Location = new System.Drawing.Point(3, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 193);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lb_nom_mod
            // 
            this.lb_nom_mod.AutoSize = true;
            this.lb_nom_mod.Location = new System.Drawing.Point(158, 25);
            this.lb_nom_mod.Name = "lb_nom_mod";
            this.lb_nom_mod.Size = new System.Drawing.Size(16, 13);
            this.lb_nom_mod.TabIndex = 3;
            this.lb_nom_mod.Text = "...";
            // 
            // lb_ide_mod
            // 
            this.lb_ide_mod.AutoSize = true;
            this.lb_ide_mod.Location = new System.Drawing.Point(70, 24);
            this.lb_ide_mod.Name = "lb_ide_mod";
            this.lb_ide_mod.Size = new System.Drawing.Size(42, 13);
            this.lb_ide_mod.TabIndex = 0;
            this.lb_ide_mod.Text = "Módulo";
            // 
            // tb_ide_mod
            // 
            this.tb_ide_mod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_mod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_ide_mod.Location = new System.Drawing.Point(114, 21);
            this.tb_ide_mod.MaxLength = 2;
            this.tb_ide_mod.Name = "tb_ide_mod";
            this.tb_ide_mod.Size = new System.Drawing.Size(30, 20);
            this.tb_ide_mod.TabIndex = 1;
            this.tb_ide_mod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ide_mod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_ide_mod_KeyDown);
            this.tb_ide_mod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ide_mod_KeyPress);
            this.tb_ide_mod.Validated += new System.EventHandler(this.tb_ide_mod_Validated);
            // 
            // bt_bus_mod
            // 
            this.bt_bus_mod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_mod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_mod.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_mod.Location = new System.Drawing.Point(143, 20);
            this.bt_bus_mod.Name = "bt_bus_mod";
            this.bt_bus_mod.Size = new System.Drawing.Size(16, 22);
            this.bt_bus_mod.TabIndex = 2;
            this.bt_bus_mod.TabStop = false;
            this.bt_bus_mod.Text = "|";
            this.bt_bus_mod.UseVisualStyleBackColor = false;
            this.bt_bus_mod.Click += new System.EventHandler(this.bt_bus_mod_Click);
            // 
            // cb_tip_ope
            // 
            this.cb_tip_ope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tip_ope.FormattingEnabled = true;
            this.cb_tip_ope.Location = new System.Drawing.Point(114, 156);
            this.cb_tip_ope.Name = "cb_tip_ope";
            this.cb_tip_ope.Size = new System.Drawing.Size(114, 21);
            this.cb_tip_ope.TabIndex = 13;
            // 
            // lb_tip_ope
            // 
            this.lb_tip_ope.AutoSize = true;
            this.lb_tip_ope.Location = new System.Drawing.Point(17, 159);
            this.lb_tip_ope.Name = "lb_tip_ope";
            this.lb_tip_ope.Size = new System.Drawing.Size(95, 13);
            this.lb_tip_ope.TabIndex = 12;
            this.lb_tip_ope.Text = "Tipo de Operación";
            // 
            // tb_fch_fin
            // 
            this.tb_fch_fin.Location = new System.Drawing.Point(114, 128);
            this.tb_fch_fin.Mask = "00/00/0000";
            this.tb_fch_fin.Name = "tb_fch_fin";
            this.tb_fch_fin.Size = new System.Drawing.Size(96, 20);
            this.tb_fch_fin.TabIndex = 11;
            this.tb_fch_fin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_fch_fin.ValidatingType = typeof(System.DateTime);
            // 
            // lb_fch_fin
            // 
            this.lb_fch_fin.AutoSize = true;
            this.lb_fch_fin.Location = new System.Drawing.Point(50, 132);
            this.lb_fch_fin.Name = "lb_fch_fin";
            this.lb_fch_fin.Size = new System.Drawing.Size(62, 13);
            this.lb_fch_fin.TabIndex = 10;
            this.lb_fch_fin.Text = "Fecha Final";
            // 
            // tb_fch_ini
            // 
            this.tb_fch_ini.Location = new System.Drawing.Point(114, 101);
            this.tb_fch_ini.Mask = "00/00/0000";
            this.tb_fch_ini.Name = "tb_fch_ini";
            this.tb_fch_ini.Size = new System.Drawing.Size(96, 20);
            this.tb_fch_ini.TabIndex = 9;
            this.tb_fch_ini.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_fch_ini.ValidatingType = typeof(System.DateTime);
            // 
            // lb_fch_ini
            // 
            this.lb_fch_ini.AutoSize = true;
            this.lb_fch_ini.Location = new System.Drawing.Point(45, 105);
            this.lb_fch_ini.Name = "lb_fch_ini";
            this.lb_fch_ini.Size = new System.Drawing.Size(67, 13);
            this.lb_fch_ini.TabIndex = 8;
            this.lb_fch_ini.Text = "Fecha Inicial";
            // 
            // lb_apl_fin
            // 
            this.lb_apl_fin.AutoSize = true;
            this.lb_apl_fin.Location = new System.Drawing.Point(31, 78);
            this.lb_apl_fin.Name = "lb_apl_fin";
            this.lb_apl_fin.Size = new System.Drawing.Size(81, 13);
            this.lb_apl_fin.TabIndex = 6;
            this.lb_apl_fin.Text = "Aplicación Final";
            // 
            // tb_apl_fin
            // 
            this.tb_apl_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_apl_fin.Location = new System.Drawing.Point(114, 74);
            this.tb_apl_fin.MaxLength = 3;
            this.tb_apl_fin.Name = "tb_apl_fin";
            this.tb_apl_fin.Size = new System.Drawing.Size(98, 20);
            this.tb_apl_fin.TabIndex = 7;
            this.tb_apl_fin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_apl_ini
            // 
            this.lb_apl_ini.AutoSize = true;
            this.lb_apl_ini.Location = new System.Drawing.Point(26, 51);
            this.lb_apl_ini.Name = "lb_apl_ini";
            this.lb_apl_ini.Size = new System.Drawing.Size(86, 13);
            this.lb_apl_ini.TabIndex = 4;
            this.lb_apl_ini.Text = "Aplicación Inicial";
            // 
            // tb_apl_ini
            // 
            this.tb_apl_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_apl_ini.Location = new System.Drawing.Point(114, 47);
            this.tb_apl_ini.MaxLength = 3;
            this.tb_apl_ini.Name = "tb_apl_ini";
            this.tb_apl_ini.Size = new System.Drawing.Size(98, 20);
            this.tb_apl_ini.TabIndex = 5;
            this.tb_apl_ini.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 184);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(351, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(132, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(210, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // ads019_R01p
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(357, 226);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads019_R01p";
            this.Tag = "Bitácora de Operaciónes p/Rango de Fecha";
            this.Text = "Bitácora de Operaciónes p/Rango de Fecha";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Label lb_apl_fin;
        private System.Windows.Forms.TextBox tb_apl_fin;
        private System.Windows.Forms.Label lb_apl_ini;
        private System.Windows.Forms.TextBox tb_apl_ini;
        private System.Windows.Forms.MaskedTextBox tb_fch_fin;
        private System.Windows.Forms.Label lb_fch_fin;
        private System.Windows.Forms.MaskedTextBox tb_fch_ini;
        private System.Windows.Forms.Label lb_fch_ini;
        private System.Windows.Forms.Label lb_tip_ope;
        private System.Windows.Forms.ComboBox cb_tip_ope;
        private System.Windows.Forms.Label lb_nom_mod;
        private System.Windows.Forms.Label lb_ide_mod;
        private System.Windows.Forms.TextBox tb_ide_mod;
        private System.Windows.Forms.Button bt_bus_mod;
    }
}