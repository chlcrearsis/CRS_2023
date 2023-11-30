using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads013 - Definición de Global                         */
    /*      Opción: Consulta Registro                                     */
    /*       Autor: JEJR - Crearsis             Fecha: 30-11-2023         */
    /**********************************************************************/
    public partial class ads013_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        public ads013_05()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_ide_mod.Text = frm_dat.Rows[0]["va_ide_mod"].ToString().Trim();
            lb_nom_mod.Text = frm_dat.Rows[0]["va_nom_mod"].ToString().Trim();
            tb_ide_glo.Text = frm_dat.Rows[0]["va_ide_glo"].ToString().Trim();
            tb_nom_glo.Text = frm_dat.Rows[0]["va_nom_glo"].ToString().Trim();
            switch (frm_dat.Rows[0]["va_tip_glo"].ToString())
            {
                case "0":
                    tb_tip_glo.Text = "Entero";
                    tb_glo_ent.Text = frm_dat.Rows[0]["va_glo_ent"].ToString().Trim();
                    break;
                case "1":
                    tb_tip_glo.Text = "Decimal";
                    tb_glo_dec.Text = frm_dat.Rows[0]["va_glo_dec"].ToString().Trim();
                    break;
                case "2":
                    tb_tip_glo.Text = "Caracter";
                    tb_glo_car.Text = frm_dat.Rows[0]["va_glo_car"].ToString().Trim();                    
                    break;
            }
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_mod.Text = string.Empty;
            lb_nom_mod.Text = string.Empty;
            tb_ide_glo.Text = string.Empty;
            tb_nom_glo.Text = string.Empty;
            tb_tip_glo.Text = string.Empty;
            tb_glo_ent.Text = string.Empty;
            tb_glo_dec.Text = string.Empty;
            tb_glo_car.Text = string.Empty;
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
