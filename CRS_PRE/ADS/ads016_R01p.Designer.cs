﻿namespace CRS_PRE
{
    partial class ads016_R01p
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
            this.tb_ges_tio = new System.Windows.Forms.TextBox();
            this.lb_est_ado = new System.Windows.Forms.Label();
            this.gb_ord_por = new System.Windows.Forms.GroupBox();
            this.rb_ord_nom = new System.Windows.Forms.RadioButton();
            this.rb_ord_per = new System.Windows.Forms.RadioButton();
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
            this.groupBox1.Controls.Add(this.tb_ges_tio);
            this.groupBox1.Controls.Add(this.lb_est_ado);
            this.groupBox1.Controls.Add(this.gb_ord_por);
            this.groupBox1.Location = new System.Drawing.Point(3, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tb_ges_tio
            // 
            this.tb_ges_tio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ges_tio.Location = new System.Drawing.Point(120, 25);
            this.tb_ges_tio.MaxLength = 4;
            this.tb_ges_tio.Multiline = true;
            this.tb_ges_tio.Name = "tb_ges_tio";
            this.tb_ges_tio.Size = new System.Drawing.Size(50, 18);
            this.tb_ges_tio.TabIndex = 21;
            this.tb_ges_tio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_est_ado
            // 
            this.lb_est_ado.AutoSize = true;
            this.lb_est_ado.Location = new System.Drawing.Point(75, 27);
            this.lb_est_ado.Name = "lb_est_ado";
            this.lb_est_ado.Size = new System.Drawing.Size(43, 13);
            this.lb_est_ado.TabIndex = 8;
            this.lb_est_ado.Text = "Gestión";
            // 
            // gb_ord_por
            // 
            this.gb_ord_por.Controls.Add(this.rb_ord_nom);
            this.gb_ord_por.Controls.Add(this.rb_ord_per);
            this.gb_ord_por.Location = new System.Drawing.Point(11, 54);
            this.gb_ord_por.Name = "gb_ord_por";
            this.gb_ord_por.Size = new System.Drawing.Size(243, 41);
            this.gb_ord_por.TabIndex = 10;
            this.gb_ord_por.TabStop = false;
            this.gb_ord_por.Text = "Ordenado por";
            // 
            // rb_ord_nom
            // 
            this.rb_ord_nom.AutoSize = true;
            this.rb_ord_nom.Location = new System.Drawing.Point(127, 15);
            this.rb_ord_nom.Name = "rb_ord_nom";
            this.rb_ord_nom.Size = new System.Drawing.Size(62, 17);
            this.rb_ord_nom.TabIndex = 1;
            this.rb_ord_nom.TabStop = true;
            this.rb_ord_nom.Text = "Nombre";
            this.rb_ord_nom.UseVisualStyleBackColor = true;
            // 
            // rb_ord_per
            // 
            this.rb_ord_per.AutoSize = true;
            this.rb_ord_per.Location = new System.Drawing.Point(50, 15);
            this.rb_ord_per.Name = "rb_ord_per";
            this.rb_ord_per.Size = new System.Drawing.Size(61, 17);
            this.rb_ord_per.TabIndex = 0;
            this.rb_ord_per.TabStop = true;
            this.rb_ord_per.Text = "Periodo";
            this.rb_ord_per.UseVisualStyleBackColor = true;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 91);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(267, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(101, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(180, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // ads016_R01p
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(272, 132);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads016_R01p";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Informe Gestión Periodo";
            this.Text = "Informe Gestión Periodo";
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
        private System.Windows.Forms.RadioButton rb_ord_nom;
        private System.Windows.Forms.RadioButton rb_ord_per;
        private System.Windows.Forms.GroupBox gb_ord_por;
        private System.Windows.Forms.Label lb_est_ado;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.TextBox tb_ges_tio;
    }
}