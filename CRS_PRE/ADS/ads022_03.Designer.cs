﻿namespace CRS_PRE
{
    partial class ads022_03
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
            this.tb_fec_tas = new System.Windows.Forms.MaskedTextBox();
            this.lb_tas_cam = new System.Windows.Forms.Label();
            this.lb_fec_tas = new System.Windows.Forms.Label();
            this.tb_tas_cam = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_fec_tas);
            this.groupBox1.Controls.Add(this.lb_tas_cam);
            this.groupBox1.Controls.Add(this.lb_fec_tas);
            this.groupBox1.Controls.Add(this.tb_tas_cam);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tb_fec_tas
            // 
            this.tb_fec_tas.Location = new System.Drawing.Point(75, 24);
            this.tb_fec_tas.Mask = "00/00/0000";
            this.tb_fec_tas.Name = "tb_fec_tas";
            this.tb_fec_tas.Size = new System.Drawing.Size(88, 20);
            this.tb_fec_tas.TabIndex = 1;
            this.tb_fec_tas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_fec_tas.ValidatingType = typeof(System.DateTime);
            // 
            // lb_tas_cam
            // 
            this.lb_tas_cam.AutoSize = true;
            this.lb_tas_cam.Location = new System.Drawing.Point(46, 53);
            this.lb_tas_cam.Name = "lb_tas_cam";
            this.lb_tas_cam.Size = new System.Drawing.Size(27, 13);
            this.lb_tas_cam.TabIndex = 2;
            this.lb_tas_cam.Text = "T.C.";
            // 
            // lb_fec_tas
            // 
            this.lb_fec_tas.AutoSize = true;
            this.lb_fec_tas.Location = new System.Drawing.Point(36, 28);
            this.lb_fec_tas.Name = "lb_fec_tas";
            this.lb_fec_tas.Size = new System.Drawing.Size(37, 13);
            this.lb_fec_tas.TabIndex = 0;
            this.lb_fec_tas.Text = "Fecha";
            // 
            // tb_tas_cam
            // 
            this.tb_tas_cam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_tas_cam.Location = new System.Drawing.Point(75, 50);
            this.tb_tas_cam.MaxLength = 7;
            this.tb_tas_cam.Name = "tb_tas_cam";
            this.tb_tas_cam.Size = new System.Drawing.Size(88, 20);
            this.tb_tas_cam.TabIndex = 3;
            this.tb_tas_cam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_tas_cam.Enter += new System.EventHandler(this.tb_tas_cam_Enter);
            this.tb_tas_cam.Validated += new System.EventHandler(this.tb_tas_cam_Validated);
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 81);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(208, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(53, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(132, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // ads022_03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 123);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads022_03";
            this.Tag = "Edita Tasa de Cambio Bs/Us";
            this.Text = "Edita Tasa de Cambio Bs/Us";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_tas_cam;
        private System.Windows.Forms.Label lb_fec_tas;
        private System.Windows.Forms.TextBox tb_tas_cam;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.MaskedTextBox tb_fec_tas;
    }
}