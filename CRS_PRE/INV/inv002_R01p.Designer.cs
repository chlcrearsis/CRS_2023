﻿namespace CRS_PRE.INV
{
    partial class inv002_R01p
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
            this.cb_est_ado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_nom_gr2 = new System.Windows.Forms.TextBox();
            this.tb_nom_gr1 = new System.Windows.Forms.TextBox();
            this.tb_ide_gr2 = new System.Windows.Forms.TextBox();
            this.bt_bus_gr2 = new System.Windows.Forms.Button();
            this.tb_ide_gr1 = new System.Windows.Forms.TextBox();
            this.bt_bus_gr1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_est_ado);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_nom_gr2);
            this.groupBox1.Controls.Add(this.tb_nom_gr1);
            this.groupBox1.Controls.Add(this.tb_ide_gr2);
            this.groupBox1.Controls.Add(this.bt_bus_gr2);
            this.groupBox1.Controls.Add(this.tb_ide_gr1);
            this.groupBox1.Controls.Add(this.bt_bus_gr1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 121);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cb_est_ado
            // 
            this.cb_est_ado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_est_ado.FormattingEnabled = true;
            this.cb_est_ado.Items.AddRange(new object[] {
            "Todos",
            "Habilitados",
            "Deshabilitados"});
            this.cb_est_ado.Location = new System.Drawing.Point(90, 85);
            this.cb_est_ado.Name = "cb_est_ado";
            this.cb_est_ado.Size = new System.Drawing.Size(116, 21);
            this.cb_est_ado.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Estado";
            // 
            // tb_nom_gr2
            // 
            this.tb_nom_gr2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_gr2.Location = new System.Drawing.Point(135, 58);
            this.tb_nom_gr2.MaxLength = 30;
            this.tb_nom_gr2.Name = "tb_nom_gr2";
            this.tb_nom_gr2.Size = new System.Drawing.Size(239, 20);
            this.tb_nom_gr2.TabIndex = 33;
            this.tb_nom_gr2.TabStop = false;
            // 
            // tb_nom_gr1
            // 
            this.tb_nom_gr1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_gr1.Location = new System.Drawing.Point(135, 34);
            this.tb_nom_gr1.MaxLength = 30;
            this.tb_nom_gr1.Name = "tb_nom_gr1";
            this.tb_nom_gr1.Size = new System.Drawing.Size(239, 20);
            this.tb_nom_gr1.TabIndex = 33;
            this.tb_nom_gr1.TabStop = false;
            // 
            // tb_ide_gr2
            // 
            this.tb_ide_gr2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_gr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_ide_gr2.Location = new System.Drawing.Point(90, 58);
            this.tb_ide_gr2.MaxLength = 3;
            this.tb_ide_gr2.Name = "tb_ide_gr2";
            this.tb_ide_gr2.Size = new System.Drawing.Size(29, 20);
            this.tb_ide_gr2.TabIndex = 20;
            this.tb_ide_gr2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_ide_gr2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_ide_gr2_KeyDown);
            this.tb_ide_gr2.Validated += new System.EventHandler(this.tb_ide_gr2_Validated);
            // 
            // bt_bus_gr2
            // 
            this.bt_bus_gr2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_gr2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_gr2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_gr2.Location = new System.Drawing.Point(118, 57);
            this.bt_bus_gr2.Name = "bt_bus_gr2";
            this.bt_bus_gr2.Size = new System.Drawing.Size(16, 22);
            this.bt_bus_gr2.TabIndex = 32;
            this.bt_bus_gr2.TabStop = false;
            this.bt_bus_gr2.Text = "|";
            this.bt_bus_gr2.UseVisualStyleBackColor = false;
            this.bt_bus_gr2.Click += new System.EventHandler(this.bt_bus_gr2_Click);
            // 
            // tb_ide_gr1
            // 
            this.tb_ide_gr1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_gr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_ide_gr1.Location = new System.Drawing.Point(90, 34);
            this.tb_ide_gr1.MaxLength = 3;
            this.tb_ide_gr1.Name = "tb_ide_gr1";
            this.tb_ide_gr1.Size = new System.Drawing.Size(29, 20);
            this.tb_ide_gr1.TabIndex = 10;
            this.tb_ide_gr1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_ide_gr1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_ide_gr1_KeyDown);
            this.tb_ide_gr1.Validated += new System.EventHandler(this.tb_ide_gr1_Validated);
            // 
            // bt_bus_gr1
            // 
            this.bt_bus_gr1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_gr1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_gr1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_gr1.Location = new System.Drawing.Point(118, 33);
            this.bt_bus_gr1.Name = "bt_bus_gr1";
            this.bt_bus_gr1.Size = new System.Drawing.Size(16, 22);
            this.bt_bus_gr1.TabIndex = 32;
            this.bt_bus_gr1.TabStop = false;
            this.bt_bus_gr1.Text = "|";
            this.bt_bus_gr1.UseVisualStyleBackColor = false;
            this.bt_bus_gr1.Click += new System.EventHandler(this.bt_bus_gr1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Grupo Final";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Grupo Inicial";
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 112);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(380, 35);
            this.gb_ctr_btn.TabIndex = 2;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(294, 9);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 23);
            this.bt_can_cel.TabIndex = 20;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.Bt_can_cel_Click);
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(213, 9);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 23);
            this.bt_ace_pta.TabIndex = 10;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            this.bt_ace_pta.Click += new System.EventHandler(this.Bt_ace_pta_Click);
            // 
            // inv002_R01p
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(385, 149);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "inv002_R01p";
            this.Text = "Listado bodegas";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Button bt_ace_pta;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_bus_gr2;
        private System.Windows.Forms.Button bt_bus_gr1;
        private System.Windows.Forms.ComboBox cb_est_ado;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tb_nom_gr2;
        public System.Windows.Forms.TextBox tb_nom_gr1;
        public System.Windows.Forms.TextBox tb_ide_gr2;
        public System.Windows.Forms.TextBox tb_ide_gr1;
    }
}