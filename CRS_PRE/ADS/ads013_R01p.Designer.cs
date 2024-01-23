namespace CRS_PRE
{
    partial class ads013_R01p
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
            this.gb_ord_por = new System.Windows.Forms.GroupBox();
            this.rb_ord_nom = new System.Windows.Forms.RadioButton();
            this.rb_ord_cod = new System.Windows.Forms.RadioButton();
            this.lb_nmo_fin = new System.Windows.Forms.Label();
            this.lb_nmo_ini = new System.Windows.Forms.Label();
            this.lb_mod_fin = new System.Windows.Forms.Label();
            this.tb_mod_fin = new System.Windows.Forms.TextBox();
            this.bt_mod_fin = new System.Windows.Forms.Button();
            this.lb_mod_ini = new System.Windows.Forms.Label();
            this.tb_mod_ini = new System.Windows.Forms.TextBox();
            this.bt_mod_ini = new System.Windows.Forms.Button();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ord_por.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gb_ord_por);
            this.groupBox1.Controls.Add(this.lb_nmo_fin);
            this.groupBox1.Controls.Add(this.lb_nmo_ini);
            this.groupBox1.Controls.Add(this.lb_mod_fin);
            this.groupBox1.Controls.Add(this.tb_mod_fin);
            this.groupBox1.Controls.Add(this.bt_mod_fin);
            this.groupBox1.Controls.Add(this.lb_mod_ini);
            this.groupBox1.Controls.Add(this.tb_mod_ini);
            this.groupBox1.Controls.Add(this.bt_mod_ini);
            this.groupBox1.Location = new System.Drawing.Point(3, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // gb_ord_por
            // 
            this.gb_ord_por.Controls.Add(this.rb_ord_nom);
            this.gb_ord_por.Controls.Add(this.rb_ord_cod);
            this.gb_ord_por.Location = new System.Drawing.Point(9, 71);
            this.gb_ord_por.Name = "gb_ord_por";
            this.gb_ord_por.Size = new System.Drawing.Size(284, 41);
            this.gb_ord_por.TabIndex = 8;
            this.gb_ord_por.TabStop = false;
            this.gb_ord_por.Text = "Ordenado por";
            // 
            // rb_ord_nom
            // 
            this.rb_ord_nom.AutoSize = true;
            this.rb_ord_nom.Location = new System.Drawing.Point(152, 15);
            this.rb_ord_nom.Name = "rb_ord_nom";
            this.rb_ord_nom.Size = new System.Drawing.Size(62, 17);
            this.rb_ord_nom.TabIndex = 1;
            this.rb_ord_nom.TabStop = true;
            this.rb_ord_nom.Text = "Nombre";
            this.rb_ord_nom.UseVisualStyleBackColor = true;
            // 
            // rb_ord_cod
            // 
            this.rb_ord_cod.AutoSize = true;
            this.rb_ord_cod.Location = new System.Drawing.Point(55, 15);
            this.rb_ord_cod.Name = "rb_ord_cod";
            this.rb_ord_cod.Size = new System.Drawing.Size(58, 17);
            this.rb_ord_cod.TabIndex = 0;
            this.rb_ord_cod.TabStop = true;
            this.rb_ord_cod.Text = "Código";
            this.rb_ord_cod.UseVisualStyleBackColor = true;
            // 
            // lb_nmo_fin
            // 
            this.lb_nmo_fin.AutoSize = true;
            this.lb_nmo_fin.Location = new System.Drawing.Point(137, 49);
            this.lb_nmo_fin.Name = "lb_nmo_fin";
            this.lb_nmo_fin.Size = new System.Drawing.Size(19, 13);
            this.lb_nmo_fin.TabIndex = 7;
            this.lb_nmo_fin.Text = "....";
            // 
            // lb_nmo_ini
            // 
            this.lb_nmo_ini.AutoSize = true;
            this.lb_nmo_ini.Location = new System.Drawing.Point(137, 23);
            this.lb_nmo_ini.Name = "lb_nmo_ini";
            this.lb_nmo_ini.Size = new System.Drawing.Size(19, 13);
            this.lb_nmo_ini.TabIndex = 3;
            this.lb_nmo_ini.Text = "....";
            // 
            // lb_mod_fin
            // 
            this.lb_mod_fin.AutoSize = true;
            this.lb_mod_fin.Location = new System.Drawing.Point(15, 49);
            this.lb_mod_fin.Name = "lb_mod_fin";
            this.lb_mod_fin.Size = new System.Drawing.Size(67, 13);
            this.lb_mod_fin.TabIndex = 4;
            this.lb_mod_fin.Text = "Módulo Final";
            // 
            // tb_mod_fin
            // 
            this.tb_mod_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_mod_fin.Location = new System.Drawing.Point(84, 45);
            this.tb_mod_fin.MaxLength = 3;
            this.tb_mod_fin.Name = "tb_mod_fin";
            this.tb_mod_fin.Size = new System.Drawing.Size(37, 20);
            this.tb_mod_fin.TabIndex = 5;
            this.tb_mod_fin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_mod_fin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_tip_fin_KeyDown);
            this.tb_mod_fin.Leave += new System.EventHandler(this.tb_mod_fin_Leave);
            // 
            // bt_mod_fin
            // 
            this.bt_mod_fin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_mod_fin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_mod_fin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_mod_fin.Location = new System.Drawing.Point(120, 44);
            this.bt_mod_fin.Name = "bt_mod_fin";
            this.bt_mod_fin.Size = new System.Drawing.Size(16, 22);
            this.bt_mod_fin.TabIndex = 6;
            this.bt_mod_fin.TabStop = false;
            this.bt_mod_fin.Text = "|";
            this.bt_mod_fin.UseVisualStyleBackColor = false;
            this.bt_mod_fin.Click += new System.EventHandler(this.bt_mod_fin_Click);
            // 
            // lb_mod_ini
            // 
            this.lb_mod_ini.AutoSize = true;
            this.lb_mod_ini.Location = new System.Drawing.Point(10, 23);
            this.lb_mod_ini.Name = "lb_mod_ini";
            this.lb_mod_ini.Size = new System.Drawing.Size(72, 13);
            this.lb_mod_ini.TabIndex = 0;
            this.lb_mod_ini.Text = "Módulo Inicial";
            // 
            // tb_mod_ini
            // 
            this.tb_mod_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_mod_ini.Location = new System.Drawing.Point(84, 19);
            this.tb_mod_ini.MaxLength = 3;
            this.tb_mod_ini.Name = "tb_mod_ini";
            this.tb_mod_ini.Size = new System.Drawing.Size(37, 20);
            this.tb_mod_ini.TabIndex = 1;
            this.tb_mod_ini.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_mod_ini.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_tip_ini_KeyDown);
            this.tb_mod_ini.Leave += new System.EventHandler(this.tb_mod_ini_Leave);
            // 
            // bt_mod_ini
            // 
            this.bt_mod_ini.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_mod_ini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_mod_ini.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_mod_ini.Location = new System.Drawing.Point(120, 18);
            this.bt_mod_ini.Name = "bt_mod_ini";
            this.bt_mod_ini.Size = new System.Drawing.Size(16, 22);
            this.bt_mod_ini.TabIndex = 2;
            this.bt_mod_ini.TabStop = false;
            this.bt_mod_ini.Text = "|";
            this.bt_mod_ini.UseVisualStyleBackColor = false;
            this.bt_mod_ini.Click += new System.EventHandler(this.bt_mod_ini_Click);
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 108);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(303, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(144, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(223, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // ads013_R01p
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 149);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads013_R01p";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Definiciones de Globales";
            this.Text = "Definiciones de Globales";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ord_por.ResumeLayout(false);
            this.gb_ord_por.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Label lb_mod_fin;
        private System.Windows.Forms.TextBox tb_mod_fin;
        private System.Windows.Forms.Button bt_mod_fin;
        private System.Windows.Forms.Label lb_mod_ini;
        private System.Windows.Forms.TextBox tb_mod_ini;
        private System.Windows.Forms.Button bt_mod_ini;
        private System.Windows.Forms.Label lb_nmo_fin;
        private System.Windows.Forms.Label lb_nmo_ini;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.GroupBox gb_ord_por;
        private System.Windows.Forms.RadioButton rb_ord_nom;
        private System.Windows.Forms.RadioButton rb_ord_cod;
    }
}