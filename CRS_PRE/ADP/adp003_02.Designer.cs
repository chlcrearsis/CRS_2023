﻿namespace CRS_PRE
{
    partial class adp003_02
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
            this.tb_nom_atr = new System.Windows.Forms.TextBox();
            this.lb_ide_atr = new System.Windows.Forms.Label();
            this.tb_ide_atr = new System.Windows.Forms.TextBox();
            this.tb_nom_tip = new System.Windows.Forms.TextBox();
            this.lb_tip_atr = new System.Windows.Forms.Label();
            this.tb_ide_tip = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_nom_atr);
            this.groupBox1.Controls.Add(this.lb_ide_atr);
            this.groupBox1.Controls.Add(this.tb_ide_atr);
            this.groupBox1.Controls.Add(this.tb_nom_tip);
            this.groupBox1.Controls.Add(this.lb_tip_atr);
            this.groupBox1.Controls.Add(this.tb_ide_tip);
            this.groupBox1.Location = new System.Drawing.Point(4, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tb_nom_atr
            // 
            this.tb_nom_atr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_atr.Location = new System.Drawing.Point(148, 48);
            this.tb_nom_atr.MaxLength = 30;
            this.tb_nom_atr.Name = "tb_nom_atr";
            this.tb_nom_atr.Size = new System.Drawing.Size(203, 20);
            this.tb_nom_atr.TabIndex = 5;
            // 
            // lb_ide_atr
            // 
            this.lb_ide_atr.AutoSize = true;
            this.lb_ide_atr.Location = new System.Drawing.Point(9, 51);
            this.lb_ide_atr.Name = "lb_ide_atr";
            this.lb_ide_atr.Size = new System.Drawing.Size(95, 13);
            this.lb_ide_atr.TabIndex = 3;
            this.lb_ide_atr.Text = "Atributo p/Defecto";
            // 
            // tb_ide_atr
            // 
            this.tb_ide_atr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_atr.Location = new System.Drawing.Point(106, 48);
            this.tb_ide_atr.MaxLength = 3;
            this.tb_ide_atr.Name = "tb_ide_atr";
            this.tb_ide_atr.Size = new System.Drawing.Size(40, 20);
            this.tb_ide_atr.TabIndex = 4;
            this.tb_ide_atr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_ide_atr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ide_atr_KeyPress);
            // 
            // tb_nom_tip
            // 
            this.tb_nom_tip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_tip.Location = new System.Drawing.Point(148, 21);
            this.tb_nom_tip.MaxLength = 30;
            this.tb_nom_tip.Name = "tb_nom_tip";
            this.tb_nom_tip.Size = new System.Drawing.Size(203, 20);
            this.tb_nom_tip.TabIndex = 2;
            // 
            // lb_tip_atr
            // 
            this.lb_tip_atr.AutoSize = true;
            this.lb_tip_atr.Location = new System.Drawing.Point(22, 24);
            this.lb_tip_atr.Name = "lb_tip_atr";
            this.lb_tip_atr.Size = new System.Drawing.Size(82, 13);
            this.lb_tip_atr.TabIndex = 0;
            this.lb_tip_atr.Text = "Tipo de Atributo";
            // 
            // tb_ide_tip
            // 
            this.tb_ide_tip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_tip.Location = new System.Drawing.Point(106, 21);
            this.tb_ide_tip.MaxLength = 3;
            this.tb_ide_tip.Name = "tb_ide_tip";
            this.tb_ide_tip.Size = new System.Drawing.Size(40, 20);
            this.tb_ide_tip.TabIndex = 1;
            this.tb_ide_tip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_ide_tip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ide_tip_KeyPress);
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(4, 77);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(363, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(200, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(279, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // adp003_02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(370, 120);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adp003_02";
            this.Tag = "Crea documento";
            this.Text = "Crea Tipo de Atributo";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_ide_tip;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.TextBox tb_nom_tip;
        private System.Windows.Forms.Label lb_tip_atr;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.TextBox tb_nom_atr;
        private System.Windows.Forms.Label lb_ide_atr;
        private System.Windows.Forms.TextBox tb_ide_atr;
        private System.Windows.Forms.Button bt_ace_pta;
    }
}