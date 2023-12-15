using CRS_NEG;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads100 - Licencia Sistema                             */
    /*      Opción: Consulta Licencia                                     */
    /*       Autor: JEJR - Crearsis             Fecha: 04-12-2023         */
    /**********************************************************************/
    public partial class ads100_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancia
        ads100 o_ads100 = new ads100();
        DataTable Tabla = new DataTable();

        public ads100_05()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            Tabla = new DataTable();
            Tabla = o_ads100.Fe_obt_lic();
            if (Tabla.Rows.Count > 0)
            {
                tb_nom_srv.Text = Tabla.Rows[0]["va_nom_ser"].ToString().Trim();
                tb_nom_bda.Text = Tabla.Rows[0]["va_nom_bda"].ToString().Trim();
                tb_fch_exp.Text = Tabla.Rows[0]["va_fec_exp"].ToString().Trim();
                if (Tabla.Rows[0]["va_nro_usr"].ToString().Trim().CompareTo("0") == 0 ||
                    Tabla.Rows[0]["va_nro_usr"].ToString().Trim().CompareTo("1") == 0)
                    tb_nro_usr.Text = Tabla.Rows[0]["va_nro_usr"].ToString().Trim() + " Usuario";
                else
                    tb_nro_usr.Text = Tabla.Rows[0]["va_nro_usr"].ToString().Trim() + " Usuarios";

                // Despliega Módulos Licenciados
                if (Tabla.Rows[0]["va_mod_ads"].ToString().Trim().CompareTo("S") == 0)
                    tb_mod_ads.Text = "Aplicado";
                else
                    tb_mod_ads.Text = "NO Aplicado";
                if (Tabla.Rows[0]["va_mod_inv"].ToString().Trim().CompareTo("S") == 0)
                    tb_mod_inv.Text = "Aplicado";
                else
                    tb_mod_inv.Text = "NO Aplicado";
                if (Tabla.Rows[0]["va_mod_cmr"].ToString().Trim().CompareTo("S") == 0)
                    tb_mod_cmr.Text = "Aplicado";
                else
                    tb_mod_cmr.Text = "NO Aplicado";
                if (Tabla.Rows[0]["va_mod_ctb"].ToString().Trim().CompareTo("S") == 0)
                    tb_mod_ctb.Text = "Aplicado";
                else
                    tb_mod_ctb.Text = "NO Aplicado";
                if (Tabla.Rows[0]["va_mod_tes"].ToString().Trim().CompareTo("S") == 0)
                    tb_mod_tes.Text = "Aplicado";
                else
                    tb_mod_tes.Text = "NO Aplicado";
                if (Tabla.Rows[0]["va_mod_res"].ToString().Trim().CompareTo("S") == 0)
                    tb_mod_res.Text = "Aplicado";
                else
                    tb_mod_res.Text = "NO Aplicado";
            }            
            tb_nom_srv.Text = tb_nom_srv.Text.Substring(0, tb_nom_srv.Text.IndexOf("\\"));
            // Obtiene la fecha y hora actual
            DateTime fec_act = DateTime.Now;
            string fch_act = fec_act.ToString("g", CultureInfo.CreateSpecificCulture("es-ES"));
            tb_fch_act.Text = fch_act;
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_nom_srv.Text = string.Empty;
            tb_nom_bda.Text = string.Empty;
            tb_nro_usr.Text = string.Empty;
            tb_fch_exp.Text = string.Empty;
            tb_fch_act.Text = string.Empty;
            tb_mod_ads.Text = string.Empty;
            tb_mod_inv.Text = string.Empty;
            tb_mod_cmr.Text = string.Empty;
            tb_mod_ctb.Text = string.Empty;
            tb_mod_tes.Text = string.Empty;
            tb_mod_res.Text = string.Empty;
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
