using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads015 - Regional                                     */
    /*      Opción: Consulta Registro                                     */
    /*       Autor: JEJR - Crearsis             Fecha: 18-12-2023         */
    /**********************************************************************/
    public partial class ads015_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        public ads015_05()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_ide_reg.Text = frm_dat.Rows[0]["va_ide_reg"].ToString();
            tb_nom_reg.Text = frm_dat.Rows[0]["va_nom_reg"].ToString();
            tb_nom_cor.Text = frm_dat.Rows[0]["va_nom_cor"].ToString();           
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_reg.Text = string.Empty;
            tb_nom_reg.Text = string.Empty;
            tb_nom_cor.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
