﻿namespace CRS_PRE
{
    partial class ads007_03d
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
            this.tb_nom_usr = new System.Windows.Forms.TextBox();
            this.lb_nom_usr = new System.Windows.Forms.Label();
            this.lb_ide_usr = new System.Windows.Forms.Label();
            this.tb_ide_usr = new System.Windows.Forms.TextBox();
            this.lb_tit_ulo = new System.Windows.Forms.Label();
            this.lb_sub_tit = new System.Windows.Forms.Label();
            this.lb_est_ado = new System.Windows.Forms.Label();
            this.gb_tip_usr = new System.Windows.Forms.GroupBox();
            this.cb_tip_usr = new System.Windows.Forms.ComboBox();
            this.lb_nue_tip = new System.Windows.Forms.Label();
            this.tb_tip_usr = new System.Windows.Forms.TextBox();
            this.lb_act_tip = new System.Windows.Forms.Label();
            this.tb_est_ado = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.tb_nom_tus = new System.Windows.Forms.TextBox();
            this.lb_nom_tus = new System.Windows.Forms.Label();
            this.lb_car_usr = new System.Windows.Forms.Label();
            this.tb_car_usr = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.gb_tip_usr.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_nom_tus);
            this.groupBox1.Controls.Add(this.lb_nom_tus);
            this.groupBox1.Controls.Add(this.lb_car_usr);
            this.groupBox1.Controls.Add(this.tb_car_usr);
            this.groupBox1.Controls.Add(this.tb_nom_usr);
            this.groupBox1.Controls.Add(this.lb_nom_usr);
            this.groupBox1.Controls.Add(this.lb_ide_usr);
            this.groupBox1.Controls.Add(this.tb_ide_usr);
            this.groupBox1.Controls.Add(this.lb_tit_ulo);
            this.groupBox1.Controls.Add(this.lb_sub_tit);
            this.groupBox1.Controls.Add(this.lb_est_ado);
            this.groupBox1.Controls.Add(this.gb_tip_usr);
            this.groupBox1.Controls.Add(this.tb_est_ado);
            this.groupBox1.Location = new System.Drawing.Point(2, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tb_nom_usr
            // 
            this.tb_nom_usr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_usr.Location = new System.Drawing.Point(54, 182);
            this.tb_nom_usr.MaxLength = 30;
            this.tb_nom_usr.Name = "tb_nom_usr";
            this.tb_nom_usr.ReadOnly = true;
            this.tb_nom_usr.Size = new System.Drawing.Size(280, 20);
            this.tb_nom_usr.TabIndex = 8;
            // 
            // lb_nom_usr
            // 
            this.lb_nom_usr.AutoSize = true;
            this.lb_nom_usr.Location = new System.Drawing.Point(8, 186);
            this.lb_nom_usr.Name = "lb_nom_usr";
            this.lb_nom_usr.Size = new System.Drawing.Size(44, 13);
            this.lb_nom_usr.TabIndex = 7;
            this.lb_nom_usr.Text = "Nombre";
            // 
            // lb_ide_usr
            // 
            this.lb_ide_usr.AutoSize = true;
            this.lb_ide_usr.Location = new System.Drawing.Point(12, 161);
            this.lb_ide_usr.Name = "lb_ide_usr";
            this.lb_ide_usr.Size = new System.Drawing.Size(40, 13);
            this.lb_ide_usr.TabIndex = 3;
            this.lb_ide_usr.Text = "Codigo";
            // 
            // tb_ide_usr
            // 
            this.tb_ide_usr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_usr.Location = new System.Drawing.Point(54, 157);
            this.tb_ide_usr.MaxLength = 15;
            this.tb_ide_usr.Name = "tb_ide_usr";
            this.tb_ide_usr.ReadOnly = true;
            this.tb_ide_usr.Size = new System.Drawing.Size(92, 20);
            this.tb_ide_usr.TabIndex = 4;
            // 
            // lb_tit_ulo
            // 
            this.lb_tit_ulo.AutoSize = true;
            this.lb_tit_ulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tit_ulo.Location = new System.Drawing.Point(53, 16);
            this.lb_tit_ulo.Name = "lb_tit_ulo";
            this.lb_tit_ulo.Size = new System.Drawing.Size(232, 15);
            this.lb_tit_ulo.TabIndex = 0;
            this.lb_tit_ulo.Text = "Cambia Tipo de Usuario al Usuario";
            // 
            // lb_sub_tit
            // 
            this.lb_sub_tit.AutoSize = true;
            this.lb_sub_tit.Location = new System.Drawing.Point(16, 38);
            this.lb_sub_tit.Name = "lb_sub_tit";
            this.lb_sub_tit.Size = new System.Drawing.Size(321, 39);
            this.lb_sub_tit.TabIndex = 1;
            this.lb_sub_tit.Text = "Esta opción actualizará los permisos autorizados del Usuario,\r\nsegún los que teng" +
    "a autorizados el Tipo de Usuario seleccionado. \r\n¿Desea continuar?";
            this.lb_sub_tit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_est_ado
            // 
            this.lb_est_ado.AutoSize = true;
            this.lb_est_ado.Location = new System.Drawing.Point(193, 161);
            this.lb_est_ado.Name = "lb_est_ado";
            this.lb_est_ado.Size = new System.Drawing.Size(40, 13);
            this.lb_est_ado.TabIndex = 5;
            this.lb_est_ado.Text = "Estado";
            // 
            // gb_tip_usr
            // 
            this.gb_tip_usr.Controls.Add(this.cb_tip_usr);
            this.gb_tip_usr.Controls.Add(this.lb_nue_tip);
            this.gb_tip_usr.Controls.Add(this.tb_tip_usr);
            this.gb_tip_usr.Controls.Add(this.lb_act_tip);
            this.gb_tip_usr.Location = new System.Drawing.Point(6, 78);
            this.gb_tip_usr.Name = "gb_tip_usr";
            this.gb_tip_usr.Size = new System.Drawing.Size(331, 73);
            this.gb_tip_usr.TabIndex = 2;
            this.gb_tip_usr.TabStop = false;
            // 
            // cb_tip_usr
            // 
            this.cb_tip_usr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tip_usr.FormattingEnabled = true;
            this.cb_tip_usr.Location = new System.Drawing.Point(148, 39);
            this.cb_tip_usr.Name = "cb_tip_usr";
            this.cb_tip_usr.Size = new System.Drawing.Size(148, 21);
            this.cb_tip_usr.TabIndex = 3;
            // 
            // lb_nue_tip
            // 
            this.lb_nue_tip.AutoSize = true;
            this.lb_nue_tip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nue_tip.Location = new System.Drawing.Point(26, 42);
            this.lb_nue_tip.Name = "lb_nue_tip";
            this.lb_nue_tip.Size = new System.Drawing.Size(120, 13);
            this.lb_nue_tip.TabIndex = 2;
            this.lb_nue_tip.Text = "Nuevo Tipo de Usuario:";
            // 
            // tb_tip_usr
            // 
            this.tb_tip_usr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_tip_usr.Location = new System.Drawing.Point(147, 15);
            this.tb_tip_usr.MaxLength = 15;
            this.tb_tip_usr.Name = "tb_tip_usr";
            this.tb_tip_usr.ReadOnly = true;
            this.tb_tip_usr.Size = new System.Drawing.Size(149, 20);
            this.tb_tip_usr.TabIndex = 1;
            this.tb_tip_usr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_act_tip
            // 
            this.lb_act_tip.AutoSize = true;
            this.lb_act_tip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_act_tip.Location = new System.Drawing.Point(27, 18);
            this.lb_act_tip.Name = "lb_act_tip";
            this.lb_act_tip.Size = new System.Drawing.Size(118, 13);
            this.lb_act_tip.TabIndex = 0;
            this.lb_act_tip.Text = "Actual Tipo de Usuario:";
            // 
            // tb_est_ado
            // 
            this.tb_est_ado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_est_ado.Location = new System.Drawing.Point(234, 157);
            this.tb_est_ado.MaxLength = 15;
            this.tb_est_ado.Name = "tb_est_ado";
            this.tb_est_ado.ReadOnly = true;
            this.tb_est_ado.Size = new System.Drawing.Size(100, 20);
            this.tb_est_ado.TabIndex = 6;
            this.tb_est_ado.TabStop = false;
            this.tb_est_ado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 230);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(343, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(182, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(261, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // tb_nom_tus
            // 
            this.tb_nom_tus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_tus.Location = new System.Drawing.Point(239, 208);
            this.tb_nom_tus.MaxLength = 15;
            this.tb_nom_tus.Name = "tb_nom_tus";
            this.tb_nom_tus.ReadOnly = true;
            this.tb_nom_tus.Size = new System.Drawing.Size(95, 20);
            this.tb_nom_tus.TabIndex = 12;
            this.tb_nom_tus.TabStop = false;
            this.tb_nom_tus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_nom_tus
            // 
            this.lb_nom_tus.AutoSize = true;
            this.lb_nom_tus.Location = new System.Drawing.Point(155, 211);
            this.lb_nom_tus.Name = "lb_nom_tus";
            this.lb_nom_tus.Size = new System.Drawing.Size(82, 13);
            this.lb_nom_tus.TabIndex = 11;
            this.lb_nom_tus.Text = "Tipo de Usuario";
            // 
            // lb_car_usr
            // 
            this.lb_car_usr.AutoSize = true;
            this.lb_car_usr.Location = new System.Drawing.Point(17, 211);
            this.lb_car_usr.Name = "lb_car_usr";
            this.lb_car_usr.Size = new System.Drawing.Size(35, 13);
            this.lb_car_usr.TabIndex = 9;
            this.lb_car_usr.Text = "Cargo";
            // 
            // tb_car_usr
            // 
            this.tb_car_usr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_car_usr.Location = new System.Drawing.Point(54, 207);
            this.tb_car_usr.MaxLength = 15;
            this.tb_car_usr.Name = "tb_car_usr";
            this.tb_car_usr.ReadOnly = true;
            this.tb_car_usr.Size = new System.Drawing.Size(94, 20);
            this.tb_car_usr.TabIndex = 10;
            // 
            // ads007_03d
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(347, 271);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads007_03d";
            this.Tag = "Cambia Tipo de Usuario";
            this.Text = "Cambia Tipo de Usuario";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_tip_usr.ResumeLayout(false);
            this.gb_tip_usr.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_est_ado;
        private System.Windows.Forms.Label lb_est_ado;
        private System.Windows.Forms.TextBox tb_tip_usr;
        private System.Windows.Forms.Label lb_act_tip;
        private System.Windows.Forms.GroupBox gb_tip_usr;
        private System.Windows.Forms.ComboBox cb_tip_usr;
        private System.Windows.Forms.Label lb_nue_tip;
        private System.Windows.Forms.Label lb_tit_ulo;
        private System.Windows.Forms.Label lb_sub_tit;
        private System.Windows.Forms.TextBox tb_nom_usr;
        private System.Windows.Forms.Label lb_nom_usr;
        private System.Windows.Forms.Label lb_ide_usr;
        private System.Windows.Forms.TextBox tb_ide_usr;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.TextBox tb_nom_tus;
        private System.Windows.Forms.Label lb_nom_tus;
        private System.Windows.Forms.Label lb_car_usr;
        private System.Windows.Forms.TextBox tb_car_usr;
    }
}