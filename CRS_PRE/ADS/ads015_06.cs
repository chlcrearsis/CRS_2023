using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads015 - Regional                                     */
    /*      Opción: Elimina Registro                                      */
    /*       Autor: JEJR - Crearsis             Fecha: 18-12-2023         */
    /**********************************************************************/
    public partial class ads015_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads015 o_ads015 = new ads015();
        ads002 o_ads002 = new ads002();
        DataTable Tabla = new DataTable();

        public ads015_06()
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
            else
                tb_est_ado.Text = "Deshabilitado";
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_reg.Text = string.Empty;
            tb_nom_cor.Text = string.Empty;
            tb_nom_reg.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo código NO este vacio
            if (tb_ide_reg.Text.Trim() == "")
                return "DEBE proporcionar el Codigo de la Regional";

            // Valida que el campo código NO este vacio
            if (!cl_glo_bal.IsNumeric(tb_ide_reg.Text.Trim()))
                return "El Código de la Regional NO tiene formato valido";

            // Valida que el registro este en el sistema
            Tabla = new DataTable();
            Tabla = o_ads015.Fe_con_reg(int.Parse(tb_ide_reg.Text));
            if (Tabla.Rows.Count == 0)
                return "La Regional NO se encuentra registrado";

            // Verifica SI el estado se encuentra Habilitado
            if (tb_est_ado.Text == "Habilitado")
                return "La Regional se encuentra Habilitado";

            // Valida que NO este registrado ninguna aplicacion que apunte al Módulo
            /*Tabla = new DataTable();
            Tabla = o_ads002.Fe_con_mod(int.Parse(tb_ide_reg.Text));
            if (Tabla.Rows.Count > 0)
                return "Hay " + Tabla.Rows.Count + " aplicaciones relacionadas con el Módulo " + tb_nom_cor.Text;*/

            return "OK";
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;

            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "OK")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Está seguro de eliminar el registro?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Elimina el registro
                    o_ads015.Fe_eli_min(int.Parse(tb_ide_reg.Text));
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_reg.Text));
                    // Despliega Mensaje
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Cierra Formulario
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
