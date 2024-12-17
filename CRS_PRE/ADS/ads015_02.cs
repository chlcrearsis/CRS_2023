using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads015 - Regional                                     */
    /*      Opción: Crear Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 16-12-2023         */
    /**********************************************************************/
    public partial class ads015_02 : Form
    {        
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias 
        ads015 o_ads015 = new ads015();
        ads019 o_ads019 = new ads019();
        DataTable Tabla = new DataTable();

        public ads015_02()
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
            tb_ide_reg.Text = string.Empty;
            tb_nom_reg.Text = string.Empty;
            tb_nom_cor.Text = string.Empty;            
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan()
        {
            // Obtiene el ID. Correspondiente
            Tabla = new DataTable();
            Tabla = o_ads015.Fe_obt_ide();
            if (Tabla.Rows.Count > 0){
                tb_ide_reg.Text = Tabla.Rows[0]["va_ide_reg"].ToString();
            }else{
                tb_ide_reg.Text = "0";
            }
            // Establece el focus
            tb_nom_cor.Focus();
        }

        // Valida los datos proporcionados
        private string Fi_val_dat()
        {
            // Valida que el campo código NO este vacio
            if (tb_ide_reg.Text.Trim() == ""){
                tb_ide_reg.Focus();
                return "DEBE proporcionar el Código de la Regional";
            }

            // Valida que el campo código sea un valor válido
            if (!cl_glo_bal.IsNumeric(tb_ide_reg.Text.Trim())){
                tb_ide_reg.Focus();
                return "El Código de la Regional NO es valido";
            }

            // Valida que el campo Nombre de la Regional NO este vacio
            if (tb_nom_reg.Text.Trim() == ""){
                tb_nom_reg.Focus();
                return "DEBE proporcionar el Nombre de la Regional";
            }

            // Valida que el campo Nombre Corto NO este vacio
            if (tb_nom_cor.Text.Trim() == ""){
                tb_nom_cor.Focus();
                return "DEBE proporcionar el Nombre Corto de la Regional";
            }            

            // Verifica SI existe otro registro con el mismo Código
            Tabla = new DataTable();
            Tabla = o_ads015.Fe_con_reg(int.Parse(tb_ide_reg.Text));
            if (Tabla.Rows.Count > 0){
                tb_ide_reg.Focus();
                return "Ya existe otra Regional con el mismo Código";
            }

            // Verifica SI existe otro registro con la misma nombre
            Tabla = new DataTable();
            Tabla = o_ads015.Fe_con_nom(tb_nom_reg.Text);
            if (Tabla.Rows.Count > 0){
                tb_nom_cor.Focus();
                return "Ya existe otra Regional con la mismo Nombre";
            }

            // Verifica SI existe otro registro con el mismo nombre corto
            Tabla = new DataTable();
            Tabla = o_ads015.Fe_con_cor(tb_nom_reg.Text);
            if (Tabla.Rows.Count > 0){
                tb_nom_reg.Focus();
                return "Ya existe otra Regional con la misma Nombre Corto";
            }

            // Quita caracteres especiales de SQL-Trans
            tb_nom_reg.Text = tb_nom_reg.Text.Replace("'", "");
            tb_nom_cor.Text = tb_nom_cor.Text.Replace("'", "");            

            return "OK";
        }        

        // Evento KeyPress : ID. Regional
        private void tb_ide_reg_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
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
                    // Graba Registro
                    o_ads015.Fe_nue_reg(int.Parse(tb_ide_reg.Text.Trim()), tb_nom_reg.Text.Trim(), tb_nom_cor.Text.Trim());
                    // Graba Bitacora de Operaciones
                    o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "N", "Regional: " + tb_ide_reg.Text.Trim() + " - " + tb_nom_reg.Text.Trim(), SystemInformation.ComputerName);
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_reg.Text.Trim()));
                    // Despliega Mensaje
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK);
                    // Limpia Campos
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
