using System;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads023 - Tasa de Cambio Bs/Ufv                        */
    /*      Opción: Registra Tasa de Cambio Bs/Ufv p/Rango de Fecha       */
    /*       Autor: JEJR - Crearsis             Fecha: 09-01-2024         */
    /**********************************************************************/
    public partial class ads023_02 : Form
    {     
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias
        ads023 o_ads023 = new ads023();
        DataTable Tabla = new DataTable();
        General general = new General();        

        public ads023_02()
        {
            InitializeComponent();
        }
     
        private void frm_Load(object sender, EventArgs e)
        {
            // Inicializa Campos
            Fi_lim_pia();                      
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_fec_ini.Text = string.Empty;
            tb_fec_fin.Text = string.Empty;
            tb_tas_cam.Text = "0.0000";
            tb_fec_ini.Focus();
        }      

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo Fecha Inicial NO este vacio
            if (tb_fec_ini.Text.Trim() == "  /  /" || 
                tb_fec_ini.Text.Trim() == "00/00/0000"){
                tb_fec_ini.Focus();
                return "DEBE proporcionar la Fecha Inicial";
            }

            // Valida que el campo Fecha Final NO este vacio
            if (tb_fec_fin.Text.Trim() == "  /  /" ||
                tb_fec_fin.Text.Trim() == "00/00/0000"){
                tb_fec_fin.Focus();
                return "DEBE proporcionar la Fecha Final";
            }

            // Valida que la Fecha Inicial sea una fecha válida
            if (!cl_glo_bal.IsDateTime(tb_fec_ini.Text.Trim())){
                tb_fec_ini.Focus();
                return "La Fecha Inicial proporcionada NO es valido";
            }

            // Valida que la Fecha Final sea una fecha válida
            if (!cl_glo_bal.IsDateTime(tb_fec_fin.Text.Trim())){
                tb_fec_fin.Focus();
                return "La Fecha Final proporcionada NO es valido";
            }

            // Valida que la Fecha Inicial sea MAYOR a la Fecha Final
            if (DateTime.Parse(tb_fec_ini.Text) > DateTime.Parse(tb_fec_fin.Text)){
                tb_fec_fin.Focus();
                return "La Fecha Final DEBE ser MAYOR a la Fecha Inicial";
            }

            // Valida que el campo T.C NO este vacio
            if (tb_tas_cam.Text.Trim() == ""){
                tb_tas_cam.Focus();
                return "DEBE proporcionar el valor de la T.C";
            }

            // Valida que el campo T.C sea un valor valido
            if (!cl_glo_bal.IsDecimal(tb_tas_cam.Text.Trim())){
                tb_tas_cam.Focus();
                return "DEBE proporcionar un valor de la T.C válido";
            }

            // Valida que el campo Monto sea un Monto MAYOR a cero
            if (double.Parse(tb_tas_cam.Text.Trim()) <= 0.00){
                tb_tas_cam.Focus();
                return "El Monto de la T.C DEBE ser MAYOR a cero";
            }            

            // Quita caracteres especiales de SQL-Trans
            tb_fec_ini.Text = tb_fec_ini.Text.Replace("'", "");
            tb_fec_fin.Text = tb_fec_fin.Text.Replace("'", "");
            tb_tas_cam.Text = tb_tas_cam.Text.Replace("'", "");            

            return "OK";
        }

        // Evento Enter: Tasa de Cambio
        private void tb_tas_cam_Enter(object sender, EventArgs e)
        {
            if (tb_tas_cam.Text == "0.0000")
                tb_tas_cam.Clear();
        }

        // Evento Validated: Tasa de Cambio
        private void tb_tas_cam_Validated(object sender, EventArgs e)
        {
            if (tb_tas_cam.Text.Trim() == "")
                tb_tas_cam.Text = "0.0000";
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult msg_res;

                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "OK")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", Text, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {
                    // Graba registro
                    o_ads023.Fe_nue_reg(tb_fec_ini.Text, tb_fec_fin.Text, double.Parse(tb_tas_cam.Text));
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm();
                    // Despliega Mensaje
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK);
                    // Inicializa Campos
                    Fi_lim_pia();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }               
    }
}
