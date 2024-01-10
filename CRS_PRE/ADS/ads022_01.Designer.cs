
namespace CRS_PRE
{
    partial class ads022_01
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.m_frm_hja = new System.Windows.Forms.MenuStrip();
            this.mn_nue_reg = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_reg_fch = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_edi_tar = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_mod_ifi = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_otr_tar = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_exp_tdc = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_imp_tdc = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_rep_ort = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_lis_tdc = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_cer_rar = new System.Windows.Forms.ToolStripMenuItem();
            this.cb_mes_tdc = new System.Windows.Forms.ComboBox();
            this.lb_mes_tdc = new System.Windows.Forms.Label();
            this.lb_año_tdc = new System.Windows.Forms.Label();
            this.tb_año_tdc = new System.Windows.Forms.NumericUpDown();
            this.gb_dia_sem = new System.Windows.Forms.GroupBox();
            this.lb_dia_sab = new System.Windows.Forms.Label();
            this.lb_dia_vie = new System.Windows.Forms.Label();
            this.lb_dia_jue = new System.Windows.Forms.Label();
            this.lb_dia_mie = new System.Windows.Forms.Label();
            this.lb_dia_mar = new System.Windows.Forms.Label();
            this.lb_dia_lun = new System.Windows.Forms.Label();
            this.lb_dia_dom = new System.Windows.Forms.Label();
            this.fl_cal_end = new System.Windows.Forms.FlowLayoutPanel();
            this.fl_cal_tdc = new System.Windows.Forms.FlowLayoutPanel();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.m_frm_hja.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_año_tdc)).BeginInit();
            this.gb_dia_sem.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.m_frm_hja);
            this.GroupBox1.Controls.Add(this.cb_mes_tdc);
            this.GroupBox1.Controls.Add(this.lb_mes_tdc);
            this.GroupBox1.Controls.Add(this.lb_año_tdc);
            this.GroupBox1.Controls.Add(this.tb_año_tdc);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(3, -4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(512, 38);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // m_frm_hja
            // 
            this.m_frm_hja.Dock = System.Windows.Forms.DockStyle.None;
            this.m_frm_hja.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_nue_reg,
            this.mn_edi_tar,
            this.mn_otr_tar,
            this.mn_rep_ort,
            this.mn_cer_rar});
            this.m_frm_hja.Location = new System.Drawing.Point(122, 7);
            this.m_frm_hja.Name = "m_frm_hja";
            this.m_frm_hja.Size = new System.Drawing.Size(294, 24);
            this.m_frm_hja.TabIndex = 77;
            this.m_frm_hja.Visible = false;
            // 
            // mn_nue_reg
            // 
            this.mn_nue_reg.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_reg_fch});
            this.mn_nue_reg.Name = "mn_nue_reg";
            this.mn_nue_reg.Size = new System.Drawing.Size(53, 20);
            this.mn_nue_reg.Text = "Nueva";
            // 
            // mn_reg_fch
            // 
            this.mn_reg_fch.Name = "mn_reg_fch";
            this.mn_reg_fch.Size = new System.Drawing.Size(224, 22);
            this.mn_reg_fch.Text = "Registra por Rango de Fecha";
            this.mn_reg_fch.Click += new System.EventHandler(this.mn_reg_fch_Click);
            // 
            // mn_edi_tar
            // 
            this.mn_edi_tar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_mod_ifi});
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
            // mn_otr_tar
            // 
            this.mn_otr_tar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_exp_tdc,
            this.mn_imp_tdc});
            this.mn_otr_tar.Name = "mn_otr_tar";
            this.mn_otr_tar.Size = new System.Drawing.Size(82, 20);
            this.mn_otr_tar.Text = "&Otras Tareas";
            // 
            // mn_exp_tdc
            // 
            this.mn_exp_tdc.Name = "mn_exp_tdc";
            this.mn_exp_tdc.Size = new System.Drawing.Size(189, 22);
            this.mn_exp_tdc.Text = "Exporta T.C. Bs. p/US.";
            this.mn_exp_tdc.Click += new System.EventHandler(this.mn_exp_tdc_Click);
            // 
            // mn_imp_tdc
            // 
            this.mn_imp_tdc.Name = "mn_imp_tdc";
            this.mn_imp_tdc.Size = new System.Drawing.Size(189, 22);
            this.mn_imp_tdc.Text = "Importa T.C. Bs. p/US.";
            this.mn_imp_tdc.Click += new System.EventHandler(this.mn_imp_tdc_Click);
            // 
            // mn_rep_ort
            // 
            this.mn_rep_ort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_lis_tdc});
            this.mn_rep_ort.Name = "mn_rep_ort";
            this.mn_rep_ort.Size = new System.Drawing.Size(60, 20);
            this.mn_rep_ort.Text = "&Reporte";
            // 
            // mn_lis_tdc
            // 
            this.mn_lis_tdc.Name = "mn_lis_tdc";
            this.mn_lis_tdc.ShortcutKeyDisplayString = "(ads022_01)";
            this.mn_lis_tdc.Size = new System.Drawing.Size(268, 22);
            this.mn_lis_tdc.Text = "&Lista de Tasa de Cambio";
            this.mn_lis_tdc.Click += new System.EventHandler(this.mn_lis_tdc_Click);
            // 
            // mn_cer_rar
            // 
            this.mn_cer_rar.Name = "mn_cer_rar";
            this.mn_cer_rar.Size = new System.Drawing.Size(46, 20);
            this.mn_cer_rar.Text = "&Atras";
            this.mn_cer_rar.Click += new System.EventHandler(this.mn_cer_rar_Click);
            // 
            // cb_mes_tdc
            // 
            this.cb_mes_tdc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mes_tdc.FormattingEnabled = true;
            this.cb_mes_tdc.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cb_mes_tdc.Location = new System.Drawing.Point(94, 11);
            this.cb_mes_tdc.Name = "cb_mes_tdc";
            this.cb_mes_tdc.Size = new System.Drawing.Size(122, 21);
            this.cb_mes_tdc.TabIndex = 1;
            this.cb_mes_tdc.SelectedIndexChanged += new System.EventHandler(this.cb_mes_año_SelectedIndexChanged);
            // 
            // lb_mes_tdc
            // 
            this.lb_mes_tdc.AutoSize = true;
            this.lb_mes_tdc.Location = new System.Drawing.Point(65, 15);
            this.lb_mes_tdc.Name = "lb_mes_tdc";
            this.lb_mes_tdc.Size = new System.Drawing.Size(27, 13);
            this.lb_mes_tdc.TabIndex = 0;
            this.lb_mes_tdc.Text = "Mes";
            // 
            // lb_año_tdc
            // 
            this.lb_año_tdc.AutoSize = true;
            this.lb_año_tdc.Location = new System.Drawing.Point(327, 15);
            this.lb_año_tdc.Name = "lb_año_tdc";
            this.lb_año_tdc.Size = new System.Drawing.Size(26, 13);
            this.lb_año_tdc.TabIndex = 2;
            this.lb_año_tdc.Text = "Año";
            // 
            // tb_año_tdc
            // 
            this.tb_año_tdc.Location = new System.Drawing.Point(355, 12);
            this.tb_año_tdc.Name = "tb_año_tdc";
            this.tb_año_tdc.Size = new System.Drawing.Size(69, 20);
            this.tb_año_tdc.TabIndex = 3;
            this.tb_año_tdc.ValueChanged += new System.EventHandler(this.tb_val_año_ValueChanged);
            // 
            // gb_dia_sem
            // 
            this.gb_dia_sem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.gb_dia_sem.Controls.Add(this.lb_dia_sab);
            this.gb_dia_sem.Controls.Add(this.lb_dia_vie);
            this.gb_dia_sem.Controls.Add(this.lb_dia_jue);
            this.gb_dia_sem.Controls.Add(this.lb_dia_mie);
            this.gb_dia_sem.Controls.Add(this.lb_dia_mar);
            this.gb_dia_sem.Controls.Add(this.lb_dia_lun);
            this.gb_dia_sem.Controls.Add(this.lb_dia_dom);
            this.gb_dia_sem.Controls.Add(this.fl_cal_end);
            this.gb_dia_sem.Location = new System.Drawing.Point(3, 29);
            this.gb_dia_sem.Name = "gb_dia_sem";
            this.gb_dia_sem.Size = new System.Drawing.Size(512, 29);
            this.gb_dia_sem.TabIndex = 1;
            this.gb_dia_sem.TabStop = false;
            // 
            // lb_dia_sab
            // 
            this.lb_dia_sab.AutoSize = true;
            this.lb_dia_sab.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_dia_sab.Location = new System.Drawing.Point(443, 10);
            this.lb_dia_sab.Name = "lb_dia_sab";
            this.lb_dia_sab.Size = new System.Drawing.Size(44, 13);
            this.lb_dia_sab.TabIndex = 6;
            this.lb_dia_sab.Text = "Sabado";
            // 
            // lb_dia_vie
            // 
            this.lb_dia_vie.AutoSize = true;
            this.lb_dia_vie.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_dia_vie.Location = new System.Drawing.Point(370, 10);
            this.lb_dia_vie.Name = "lb_dia_vie";
            this.lb_dia_vie.Size = new System.Drawing.Size(42, 13);
            this.lb_dia_vie.TabIndex = 5;
            this.lb_dia_vie.Text = "Viernes";
            // 
            // lb_dia_jue
            // 
            this.lb_dia_jue.AutoSize = true;
            this.lb_dia_jue.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_dia_jue.Location = new System.Drawing.Point(306, 10);
            this.lb_dia_jue.Name = "lb_dia_jue";
            this.lb_dia_jue.Size = new System.Drawing.Size(41, 13);
            this.lb_dia_jue.TabIndex = 4;
            this.lb_dia_jue.Text = "Jueves";
            // 
            // lb_dia_mie
            // 
            this.lb_dia_mie.AutoSize = true;
            this.lb_dia_mie.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_dia_mie.Location = new System.Drawing.Point(226, 10);
            this.lb_dia_mie.Name = "lb_dia_mie";
            this.lb_dia_mie.Size = new System.Drawing.Size(52, 13);
            this.lb_dia_mie.TabIndex = 3;
            this.lb_dia_mie.Text = "Miercoles";
            // 
            // lb_dia_mar
            // 
            this.lb_dia_mar.AutoSize = true;
            this.lb_dia_mar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_dia_mar.Location = new System.Drawing.Point(160, 10);
            this.lb_dia_mar.Name = "lb_dia_mar";
            this.lb_dia_mar.Size = new System.Drawing.Size(39, 13);
            this.lb_dia_mar.TabIndex = 2;
            this.lb_dia_mar.Text = "Martes";
            // 
            // lb_dia_lun
            // 
            this.lb_dia_lun.AutoSize = true;
            this.lb_dia_lun.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_dia_lun.Location = new System.Drawing.Point(91, 10);
            this.lb_dia_lun.Name = "lb_dia_lun";
            this.lb_dia_lun.Size = new System.Drawing.Size(36, 13);
            this.lb_dia_lun.TabIndex = 1;
            this.lb_dia_lun.Text = "Lunes";
            // 
            // lb_dia_dom
            // 
            this.lb_dia_dom.AutoSize = true;
            this.lb_dia_dom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lb_dia_dom.Location = new System.Drawing.Point(15, 10);
            this.lb_dia_dom.Name = "lb_dia_dom";
            this.lb_dia_dom.Size = new System.Drawing.Size(49, 13);
            this.lb_dia_dom.TabIndex = 0;
            this.lb_dia_dom.Text = "Domingo";
            // 
            // fl_cal_end
            // 
            this.fl_cal_end.Location = new System.Drawing.Point(3, 39);
            this.fl_cal_end.Margin = new System.Windows.Forms.Padding(0);
            this.fl_cal_end.Name = "fl_cal_end";
            this.fl_cal_end.Size = new System.Drawing.Size(506, 422);
            this.fl_cal_end.TabIndex = 7;
            // 
            // fl_cal_tdc
            // 
            this.fl_cal_tdc.Location = new System.Drawing.Point(3, 60);
            this.fl_cal_tdc.Name = "fl_cal_tdc";
            this.fl_cal_tdc.Size = new System.Drawing.Size(512, 424);
            this.fl_cal_tdc.TabIndex = 2;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 480);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(513, 40);
            this.gb_ctr_btn.TabIndex = 3;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(355, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(433, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // ads022_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 522);
            this.ControlBox = false;
            this.Controls.Add(this.fl_cal_tdc);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.gb_dia_sem);
            this.Controls.Add(this.gb_ctr_btn);
            this.Name = "ads022_01";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Tag = "Tasa de Cambio Bs/Us";
            this.Text = "Tasa de Cambio Bs/Us";
            this.Load += new System.EventHandler(this.frm_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.m_frm_hja.ResumeLayout(false);
            this.m_frm_hja.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_año_tdc)).EndInit();
            this.gb_dia_sem.ResumeLayout(false);
            this.gb_dia_sem.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.NumericUpDown tb_año_tdc;
        internal System.Windows.Forms.GroupBox gb_dia_sem;
        internal System.Windows.Forms.FlowLayoutPanel fl_cal_end;
        private System.Windows.Forms.FlowLayoutPanel fl_cal_tdc;
        private System.Windows.Forms.Label lb_mes_tdc;
        private System.Windows.Forms.Label lb_año_tdc;
        private System.Windows.Forms.Label lb_dia_sab;
        private System.Windows.Forms.Label lb_dia_vie;
        private System.Windows.Forms.Label lb_dia_jue;
        private System.Windows.Forms.Label lb_dia_mie;
        private System.Windows.Forms.Label lb_dia_mar;
        private System.Windows.Forms.Label lb_dia_lun;
        private System.Windows.Forms.Label lb_dia_dom;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.ComboBox cb_mes_tdc;
        public System.Windows.Forms.MenuStrip m_frm_hja;
        private System.Windows.Forms.ToolStripMenuItem mn_nue_reg;
        private System.Windows.Forms.ToolStripMenuItem mn_edi_tar;
        private System.Windows.Forms.ToolStripMenuItem mn_mod_ifi;
        private System.Windows.Forms.ToolStripMenuItem mn_otr_tar;
        private System.Windows.Forms.ToolStripMenuItem mn_rep_ort;
        private System.Windows.Forms.ToolStripMenuItem mn_lis_tdc;
        private System.Windows.Forms.ToolStripMenuItem mn_cer_rar;
        private System.Windows.Forms.ToolStripMenuItem mn_reg_fch;
        private System.Windows.Forms.ToolStripMenuItem mn_exp_tdc;
        private System.Windows.Forms.ToolStripMenuItem mn_imp_tdc;
    }
}