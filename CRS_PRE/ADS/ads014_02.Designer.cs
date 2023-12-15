namespace CRS_PRE
{
    partial class ads014_02
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
            this.rb_sup_aut = new System.Windows.Forms.CheckBox();
            this.tb_ide_cla = new System.Windows.Forms.Label();
            this.tb_nom_cla = new System.Windows.Forms.Label();
            this.lb_rep_con = new System.Windows.Forms.Label();
            this.tb_rep_con = new System.Windows.Forms.TextBox();
            this.lb_nue_con = new System.Windows.Forms.Label();
            this.tb_nue_con = new System.Windows.Forms.TextBox();
            this.lb_con_act = new System.Windows.Forms.Label();
            this.tb_con_act = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_sup_aut);
            this.groupBox1.Controls.Add(this.tb_ide_cla);
            this.groupBox1.Controls.Add(this.tb_nom_cla);
            this.groupBox1.Controls.Add(this.lb_rep_con);
            this.groupBox1.Controls.Add(this.tb_rep_con);
            this.groupBox1.Controls.Add(this.lb_nue_con);
            this.groupBox1.Controls.Add(this.tb_nue_con);
            this.groupBox1.Controls.Add(this.lb_con_act);
            this.groupBox1.Controls.Add(this.tb_con_act);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rb_sup_aut
            // 
            this.rb_sup_aut.AutoSize = true;
            this.rb_sup_aut.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_sup_aut.Location = new System.Drawing.Point(10, 135);
            this.rb_sup_aut.Name = "rb_sup_aut";
            this.rb_sup_aut.Size = new System.Drawing.Size(125, 17);
            this.rb_sup_aut.TabIndex = 8;
            this.rb_sup_aut.Text = "Suprime Autorización";
            this.rb_sup_aut.UseVisualStyleBackColor = true;
            this.rb_sup_aut.CheckedChanged += new System.EventHandler(this.rb_sup_aut_CheckedChanged);
            // 
            // tb_ide_cla
            // 
            this.tb_ide_cla.AutoSize = true;
            this.tb_ide_cla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_ide_cla.Location = new System.Drawing.Point(118, 31);
            this.tb_ide_cla.MaximumSize = new System.Drawing.Size(50, 15);
            this.tb_ide_cla.MinimumSize = new System.Drawing.Size(50, 15);
            this.tb_ide_cla.Name = "tb_ide_cla";
            this.tb_ide_cla.Size = new System.Drawing.Size(50, 15);
            this.tb_ide_cla.TabIndex = 1;
            this.tb_ide_cla.Text = "(1-1)";
            this.tb_ide_cla.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_nom_cla
            // 
            this.tb_nom_cla.AutoSize = true;
            this.tb_nom_cla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nom_cla.Location = new System.Drawing.Point(7, 13);
            this.tb_nom_cla.MaximumSize = new System.Drawing.Size(280, 15);
            this.tb_nom_cla.MinimumSize = new System.Drawing.Size(280, 15);
            this.tb_nom_cla.Name = "tb_nom_cla";
            this.tb_nom_cla.Size = new System.Drawing.Size(280, 15);
            this.tb_nom_cla.TabIndex = 0;
            this.tb_nom_cla.Text = "Modifica Parametros Estructurales";
            this.tb_nom_cla.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_rep_con
            // 
            this.lb_rep_con.AutoSize = true;
            this.lb_rep_con.Location = new System.Drawing.Point(21, 111);
            this.lb_rep_con.Name = "lb_rep_con";
            this.lb_rep_con.Size = new System.Drawing.Size(98, 13);
            this.lb_rep_con.TabIndex = 6;
            this.lb_rep_con.Text = "Repetir Contraseña";
            // 
            // tb_rep_con
            // 
            this.tb_rep_con.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_rep_con.Location = new System.Drawing.Point(121, 108);
            this.tb_rep_con.MaxLength = 15;
            this.tb_rep_con.Name = "tb_rep_con";
            this.tb_rep_con.Size = new System.Drawing.Size(125, 20);
            this.tb_rep_con.TabIndex = 7;
            this.tb_rep_con.UseSystemPasswordChar = true;
            this.tb_rep_con.Enter += new System.EventHandler(this.tb_rep_con_Enter);
            this.tb_rep_con.Validated += new System.EventHandler(this.tb_rep_con_Validated);
            // 
            // lb_nue_con
            // 
            this.lb_nue_con.AutoSize = true;
            this.lb_nue_con.Location = new System.Drawing.Point(24, 83);
            this.lb_nue_con.Name = "lb_nue_con";
            this.lb_nue_con.Size = new System.Drawing.Size(96, 13);
            this.lb_nue_con.TabIndex = 4;
            this.lb_nue_con.Text = "Nueva Contraseña";
            // 
            // tb_nue_con
            // 
            this.tb_nue_con.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nue_con.Location = new System.Drawing.Point(121, 80);
            this.tb_nue_con.MaxLength = 15;
            this.tb_nue_con.Name = "tb_nue_con";
            this.tb_nue_con.Size = new System.Drawing.Size(125, 20);
            this.tb_nue_con.TabIndex = 5;
            this.tb_nue_con.UseSystemPasswordChar = true;
            this.tb_nue_con.Enter += new System.EventHandler(this.tb_nue_con_Enter);
            this.tb_nue_con.Validated += new System.EventHandler(this.tb_nue_con_Validated);
            // 
            // lb_con_act
            // 
            this.lb_con_act.AutoSize = true;
            this.lb_con_act.Location = new System.Drawing.Point(25, 56);
            this.lb_con_act.Name = "lb_con_act";
            this.lb_con_act.Size = new System.Drawing.Size(94, 13);
            this.lb_con_act.TabIndex = 2;
            this.lb_con_act.Text = "Contraseña Actual";
            // 
            // tb_con_act
            // 
            this.tb_con_act.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_con_act.Location = new System.Drawing.Point(121, 53);
            this.tb_con_act.MaxLength = 15;
            this.tb_con_act.Name = "tb_con_act";
            this.tb_con_act.Size = new System.Drawing.Size(125, 20);
            this.tb_con_act.TabIndex = 3;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 151);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(295, 43);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(134, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(213, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // ads014_02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 197);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads014_02";
            this.Tag = "Actualiza Clave Usuario";
            this.Text = "Actualiza Clave Usuario";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_con_act;
        private System.Windows.Forms.TextBox tb_con_act;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Label lb_nue_con;
        private System.Windows.Forms.TextBox tb_nue_con;
        private System.Windows.Forms.Label lb_rep_con;
        private System.Windows.Forms.TextBox tb_rep_con;
        private System.Windows.Forms.Label tb_ide_cla;
        private System.Windows.Forms.Label tb_nom_cla;
        private System.Windows.Forms.CheckBox rb_sup_aut;
    }
}