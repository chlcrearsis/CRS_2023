using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads013 - Definicion de Claves                         */
    /*      Opción: Crear Registros Automaticos                           */
    /*       Autor: JEJR - Crearsis             Fecha: 05-12-2023         */
    /**********************************************************************/
    public partial class ads011_02b : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias
        ads011 o_ads011 = new ads011();        
        DataTable Tabla = new DataTable();

        public ads011_02b()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
          

        }             

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Verifica Si existe registros
            Tabla = new DataTable();
            Tabla = o_ads011.Fe_bus_car("", 0, 0);
            if (Tabla.Rows.Count > 0)
                return "NO se puede usar esta operación, ya que existe claves registradas";

            return "OK";
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
                    // Registrar 
                    o_ads011.Fe_reg_cla();
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK);
                    frm_pad.fi_ini_frm();
                    cl_glo_frm.Cerrar(this);
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
