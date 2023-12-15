using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads011 - Definición de Clave                          */
    /*      Opción: Consulta Registro                                     */
    /*       Autor: JEJR - Crearsis             Fecha: 05-12-2023         */
    /**********************************************************************/
    public partial class ads011_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        public ads011_05()
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
            tb_ide_cla.Text = frm_dat.Rows[0]["va_ide_cla"].ToString().Trim();
            tb_nom_cla.Text = frm_dat.Rows[0]["va_nom_cla"].ToString().Trim();
            tb_obs_cla.Text = frm_dat.Rows[0]["va_obs_cla"].ToString().Trim();
            switch (frm_dat.Rows[0]["va_cla_req"].ToString()){
                case "S":
                    tb_cla_req.Text = "Si";
                    break;
                case "N":
                    tb_cla_req.Text = "No";
                    break;
            }
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_mod.Text = string.Empty;
            lb_nom_mod.Text = string.Empty;
            tb_ide_cla.Text = string.Empty;
            tb_nom_cla.Text = string.Empty;
            tb_cla_req.Text = string.Empty;
            tb_obs_cla.Text = string.Empty;
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
