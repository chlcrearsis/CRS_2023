using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads023 - Tasa de Cambio Bs/Ufv                        */
    /* Descripción: Muestra Calendario de la Tasa de Cambio               */
    /*       Autor: JEJR - Crearsis             Fecha: 09-01-2024         */
    /**********************************************************************/
    public partial class ads023_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;
        // Instancia
        General o_geneal = new General();
        ads023 o_ads023 = new ads023();
        DataTable Tabla = new DataTable();
        // Variables
        private int vp_tip_frm = 0;
        private int vp_ban_aux = 0;

        public ads023_01()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            /* Inicializa Formulario */
            Fe_ini_frm();            
            vp_ban_aux = 1;
        }

        
        /// <summary>
        /// -> Metodo que inicializa el formulario
        /// </summary>
        private void Fe_ini_frm()
        {
            /* Obtiene el mes y el año actual del servidor */
            cb_mes_tdc.SelectedIndex = o_geneal.Fe_fec_act().Month - 1;            
            tb_año_tdc.Minimum = o_geneal.Fe_fec_act().Year - 5;
            tb_año_tdc.Maximum = o_geneal.Fe_fec_act().Year + 5;
            tb_año_tdc.Value = o_geneal.Fe_fec_act().Year;
            /* Actualiza Formulario */
            Fe_act_frm();
            /* Establece el Tipo de Formulario */
            vp_tip_frm = 0;            
        }

        /// <summary>
        /// Metodo Weekday
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startOfWeek"></param>
        /// <returns></returns>
        public static int Weekday(DateTime dt, DayOfWeek startOfWeek)
        {
            return (dt.DayOfWeek - startOfWeek + 7) % 7;
        }

        /// <summary>
        /// -> Metodo buscar
        /// </summary>
        public void Fe_act_frm()
        {
            try
            {
                /* Mes a Buscar */
                string mes_bus = (cb_mes_tdc.SelectedIndex + 1).ToString();
                /* Año a Buscar */
                int año_bus = Convert.ToInt32(tb_año_tdc.Value);
                /* Fecha Inicial */
                DateTime fec_ini;
                /* Fecha Final */
                DateTime fec_fin;
                /* Numero de dias del mes */
                int nro_dms = 0;
                /* Nombre del dia */
                int str_dia = 0;
                /* Limpia el Control del Calendario */
                fl_cal_tdc.Controls.Clear();
                /* Concatena le fecha a buscar */
                fec_ini = Convert.ToDateTime("01/" + mes_bus.ToString() + "/" + año_bus.ToString());
                fec_fin = fec_ini;
                fec_fin = fec_ini.AddMonths(1);
                fec_fin = fec_fin.AddDays(-1);

                nro_dms = (fec_fin - fec_ini).Days;
                nro_dms = nro_dms + 1;


                switch (fec_ini.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        str_dia = 1;
                        break;
                    case DayOfWeek.Monday:
                        str_dia = 2;
                        break;
                    case DayOfWeek.Tuesday:
                        str_dia = 3;
                        break;
                    case DayOfWeek.Wednesday:
                        str_dia = 4;
                        break;
                    case DayOfWeek.Thursday:
                        str_dia = 5;
                        break;
                    case DayOfWeek.Friday:
                        str_dia = 6;
                        break;
                    case DayOfWeek.Saturday:
                        str_dia = 7;
                        break;
                }

                //--** Bucle para dias iniciales deshabilitados 
                for (int j = 0; j <= str_dia - 2; j++)
                {
                    Button bot_val = new Button();
                    Padding val_pad = new Padding();
                    val_pad.All = 0;
                    var _with1 = bot_val;
                    _with1.Size = new Size(72, 70);
                    _with1.Margin = val_pad;
                    _with1.TabIndex = 0;
                    _with1.Text = "T.C" + (char)13 + "0.0000" + (char)13 + (char)13 + "---------";
                    _with1.Name = j.ToString();
                    _with1.AccessibleName = "0.0000";
                    _with1.FlatStyle = FlatStyle.Popup;
                    _with1.Enabled = false;
                    if (j == 0)                    
                        _with1.BackColor = Color.Wheat;
                    
                    fl_cal_tdc.Controls.Add(bot_val);
                }

                /* Obtiene T.C de todo el mes */
                Tabla = new DataTable();
                Tabla = o_ads023.Fe_bus_car(int.Parse(mes_bus), año_bus);
                for (int i = 1; i <= nro_dms; i++)
                {
                    Button bot_val = new Button();
                    DateTime fec_aux;
                    Padding val_pad = new Padding();
                    val_pad.All = 0;
                    fec_aux = Convert.ToDateTime(i + "/" + mes_bus + "/" + año_bus).Date;
                    int ban_dat = 0;
                    for (int j = 0; j <= Tabla.Rows.Count - 1; j++)
                    {
                        if (Convert.ToDateTime(Tabla.Rows[j]["va_fec_tas"].ToString()) == fec_aux)
                        {
                            var _with2 = bot_val;
                            _with2.Size = new Size(72, 70);
                            _with2.Margin = val_pad;
                            _with2.TabIndex = i;
                            _with2.Text = "T.C" + (char)13 +
                              Tabla.Rows[j]["va_tas_cam"].ToString().Trim() + (char)13 + (char)13 +
                              Convert.ToDateTime(Tabla.Rows[j]["va_fec_tas"]).ToShortDateString();
                            _with2.Name = fec_aux.ToString();
                            _with2.AccessibleName = Tabla.Rows[j]["va_tas_cam"].ToString().Trim();
                            _with2.BackColor = Color.Azure;
                            _with2.ForeColor = Color.DarkBlue;
                            _with2.Cursor = Cursors.Hand;

                            /* Los dias domingos son mintados casi rojos */                           
                            if (fec_aux.DayOfWeek == DayOfWeek.Sunday)                           
                                _with2.BackColor = Color.Wheat;
                            
                            decimal valor = Convert.ToDecimal(Tabla.Rows[j]["va_tas_cam"].ToString());
                            if (valor == 0)                            
                                _with2.FlatStyle = FlatStyle.System;
                            
                            bot_val.Click += fi_but_tdc;
                            ban_dat = 1;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }

                    if (ban_dat == 0){
                        var _with3 = bot_val;
                        _with3.Size = new Size(72, 70);
                        _with3.Margin = val_pad;
                        _with3.TabIndex = i;
                        _with3.Text = "T.C" + (char)13 + "0.0000" + (char)13 + (char)13 + fec_aux.ToShortDateString();
                        _with3.Name = fec_aux.ToString();
                        _with3.AccessibleName = "0.0000";
                        _with3.Cursor = Cursors.Hand;

                        /* Los dias domingos son mintados casi rojos */
                        if (fec_aux.DayOfWeek == DayOfWeek.Sunday)                        
                            _with3.BackColor = Color.Wheat;                       
                        else                        
                            _with3.FlatStyle = FlatStyle.System;
                        
                        bot_val.Click += fi_but_tdc;
                    }
                    
                    fl_cal_tdc.Controls.Add(bot_val);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// Metodo activado con el click en el boton de la fecha T.C.
        /// </summary>
        public void fi_but_tdc(object sender, EventArgs e)
        {            
            Button bot_fec = (Button) sender;
            DateTime fec_tcd = Convert.ToDateTime(bot_fec.Name);
            string tas_cam = Convert.ToString(bot_fec.AccessibleName);

            /* Obtiene una Tabla con datos iniciados */
            Tabla = new DataTable();
            Tabla.Columns.Add("va_fec_tas");
            Tabla.Columns.Add("va_tas_cam");
            Tabla.Rows.Add();
            Tabla.Rows[0]["va_fec_tas"] = fec_tcd.ToShortDateString();
            Tabla.Rows[0]["va_tas_cam"] = tas_cam;

            /* Si es abierta desde el ABM abre la ventana Modifica T.C */
            if (vp_tip_frm == 0){
                ads023_03 frm = new ads023_03();
                cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);                
            }
        }                                

        private void cb_mes_año_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vp_ban_aux == 1)
                Fe_act_frm();
        }

        private void tb_val_año_ValueChanged(object sender, EventArgs e)
        {
            if (vp_ban_aux == 1)
                Fe_act_frm();            
        }        
        
        /* Evento Click: Registra p/Rango Fecha */
        private void mn_reg_fch_Click(object sender, EventArgs e)
        {
            ads023_02 frm = new ads023_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
        /* Evento Click: Modifica */
        private void mn_mod_ifi_Click(object sender, EventArgs e)
        {
            ads023_02 frm = new ads023_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        /* Evento Click: Exporta */
        private void mn_exp_tdc_Click(object sender, EventArgs e)
        {
            ads023_08 frm = new ads023_08();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
        /* Evento Click: Importa */
        private void mn_imp_tdc_Click(object sender, EventArgs e)
        {
            ads023_09 frm = new ads023_09();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
        /* Evento Click: Informe */
        private void mn_lis_tdc_Click(object sender, EventArgs e)
        {
            ads023_R01p frm = new ads023_R01p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
        /* Evento Click: Cerrar */
        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        /* Evento Click: Button Aceptar */
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        /* Evento Click: Button Cancelar */
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }        
    }
}
