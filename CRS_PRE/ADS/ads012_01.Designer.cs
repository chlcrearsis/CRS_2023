namespace CRS_PRE
{
    partial class ads012_01
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
            this.tb_ide_frm = new System.Windows.Forms.TextBox();
            this.lb_nom_usr = new System.Windows.Forms.Label();
            this.lb_ide_usr = new System.Windows.Forms.Label();
            this.tb_ide_usr = new System.Windows.Forms.TextBox();
            this.lb_nom_frm = new System.Windows.Forms.Label();
            this.lb_ide_frm = new System.Windows.Forms.Label();
            this.ch_che_tod = new System.Windows.Forms.CheckBox();
            this.dg_res_ult = new System.Windows.Forms.TreeView();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_ide_frm);
            this.groupBox1.Controls.Add(this.lb_nom_usr);
            this.groupBox1.Controls.Add(this.lb_ide_usr);
            this.groupBox1.Controls.Add(this.tb_ide_usr);
            this.groupBox1.Controls.Add(this.lb_nom_frm);
            this.groupBox1.Controls.Add(this.lb_ide_frm);
            this.groupBox1.Controls.Add(this.ch_che_tod);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 65);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // tb_ide_frm
            // 
            this.tb_ide_frm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_frm.Location = new System.Drawing.Point(61, 37);
            this.tb_ide_frm.Name = "tb_ide_frm";
            this.tb_ide_frm.ReadOnly = true;
            this.tb_ide_frm.Size = new System.Drawing.Size(54, 20);
            this.tb_ide_frm.TabIndex = 58;
            this.tb_ide_frm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_nom_usr
            // 
            this.lb_nom_usr.AutoSize = true;
            this.lb_nom_usr.Location = new System.Drawing.Point(145, 17);
            this.lb_nom_usr.Name = "lb_nom_usr";
            this.lb_nom_usr.Size = new System.Drawing.Size(16, 13);
            this.lb_nom_usr.TabIndex = 57;
            this.lb_nom_usr.Text = "...";
            // 
            // lb_ide_usr
            // 
            this.lb_ide_usr.AutoSize = true;
            this.lb_ide_usr.Location = new System.Drawing.Point(16, 18);
            this.lb_ide_usr.Name = "lb_ide_usr";
            this.lb_ide_usr.Size = new System.Drawing.Size(43, 13);
            this.lb_ide_usr.TabIndex = 55;
            this.lb_ide_usr.Text = "Usuario";
            // 
            // tb_ide_usr
            // 
            this.tb_ide_usr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_usr.Location = new System.Drawing.Point(61, 14);
            this.tb_ide_usr.Name = "tb_ide_usr";
            this.tb_ide_usr.ReadOnly = true;
            this.tb_ide_usr.Size = new System.Drawing.Size(82, 20);
            this.tb_ide_usr.TabIndex = 56;
            this.tb_ide_usr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_nom_frm
            // 
            this.lb_nom_frm.AutoSize = true;
            this.lb_nom_frm.Location = new System.Drawing.Point(117, 41);
            this.lb_nom_frm.Name = "lb_nom_frm";
            this.lb_nom_frm.Size = new System.Drawing.Size(16, 13);
            this.lb_nom_frm.TabIndex = 54;
            this.lb_nom_frm.Text = "...";
            // 
            // lb_ide_frm
            // 
            this.lb_ide_frm.AutoSize = true;
            this.lb_ide_frm.Location = new System.Drawing.Point(4, 40);
            this.lb_ide_frm.Name = "lb_ide_frm";
            this.lb_ide_frm.Size = new System.Drawing.Size(55, 13);
            this.lb_ide_frm.TabIndex = 53;
            this.lb_ide_frm.Text = "Formulario";
            // 
            // ch_che_tod
            // 
            this.ch_che_tod.AutoSize = true;
            this.ch_che_tod.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ch_che_tod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_che_tod.Location = new System.Drawing.Point(326, 37);
            this.ch_che_tod.Name = "ch_che_tod";
            this.ch_che_tod.Size = new System.Drawing.Size(72, 17);
            this.ch_che_tod.TabIndex = 52;
            this.ch_che_tod.Text = "Todos ?";
            this.ch_che_tod.UseVisualStyleBackColor = true;
            this.ch_che_tod.CheckedChanged += new System.EventHandler(this.ch_che_tod_CheckedChanged);
            // 
            // dg_res_ult
            // 
            this.dg_res_ult.BackColor = System.Drawing.Color.White;
            this.dg_res_ult.CheckBoxes = true;
            this.dg_res_ult.ForeColor = System.Drawing.Color.Black;
            this.dg_res_ult.Location = new System.Drawing.Point(3, 64);
            this.dg_res_ult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.Size = new System.Drawing.Size(411, 248);
            this.dg_res_ult.TabIndex = 52;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 308);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(411, 40);
            this.gb_ctr_btn.TabIndex = 53;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(253, 10);
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
            this.bt_can_cel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(331, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            // 
            // ads012_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 349);
            this.ControlBox = false;
            this.Controls.Add(this.dg_res_ult);
            this.Controls.Add(this.gb_ctr_btn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads012_01";
            this.Tag = "Permiso Usuario Sobre el Menú";
            this.Text = "Permiso Usuario Sobre el Menú";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ch_che_tod;
        public System.Windows.Forms.TreeView dg_res_ult;
        private System.Windows.Forms.Label lb_nom_frm;
        private System.Windows.Forms.Label lb_ide_frm;
        public System.Windows.Forms.TextBox tb_ide_frm;
        public System.Windows.Forms.Label lb_nom_usr;
        private System.Windows.Forms.Label lb_ide_usr;
        public System.Windows.Forms.TextBox tb_ide_usr;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
    }
}