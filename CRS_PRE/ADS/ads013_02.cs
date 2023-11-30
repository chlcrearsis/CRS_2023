using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads013 - Globales                                     */
    /*      Opción: Crear Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 27-11-2023         */
    /**********************************************************************/
    public partial class ads013_02 : Form
    {     
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias
        ads001 o_ads001 = new ads001();
        ads013 o_ads013 = new ads013();        
        DataTable Tabla = new DataTable();

        public ads013_02()
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
            tb_ide_mod.Text = string.Empty;
            lb_nom_mod.Text = string.Empty;
            tb_ide_glo.Text = string.Empty;
            tb_nom_glo.Text = string.Empty;
            tb_glo_ent.Text = string.Empty;
            tb_glo_dec.Text = string.Empty;
            tb_glo_car.Text = string.Empty;
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan()
        {
            // Establece el Focus en el Módulo 
            tb_ide_mod.Text = "0";
            lb_nom_mod.Text = "...";            
            tb_glo_ent.Enabled = true;
            tb_glo_dec.Enabled = false;
            tb_glo_car.Enabled = false;
            cb_tip_glo.SelectedIndex = 0;
            tb_ide_mod.Focus();
        }

        // Funcion: Buscar Módulo
        private void Fi_bus_mod()
        {
            ads001_01 frm = new ads001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                tb_ide_mod.Text = frm.tb_ide_mod.Text;
                Fi_obt_mod();
            }
        }

        /// <summary>
        /// Obtiene datos del Módulo
        /// </summary>
        private void Fi_obt_mod()
        {
            // Obtiene y desplega datos del Módulo
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(int.Parse(tb_ide_mod.Text));
            if (Tabla.Rows.Count == 0){
                lb_nom_mod.Text = "...";
            }else{
                tb_ide_mod.Text = Tabla.Rows[0]["va_ide_mod"].ToString();
                lb_nom_mod.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
            }
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo ID. Módulo NO este vacio
            if (tb_ide_mod.Text.Trim() == "" ||
                tb_ide_mod.Text.Trim() == "0")
            {
                tb_ide_mod.Focus();
                return "DEBE proporcionar el ID. Módulo";
            }

            // Valida que el campo código sea un valor válido
            if (!cl_glo_bal.IsNumeric(tb_ide_mod.Text.Trim())){
                tb_ide_mod.Focus();
                return "El ID. Módulo NO es valido";
            }

            // Valida que el campo ID. Global NO este vacio
            if (tb_ide_glo.Text.Trim() == ""){
                tb_ide_glo.Focus();
                return "DEBE proporcionar el ID. Global";
            }

            // Valida que el campo código sea un valor válido
            if (!cl_glo_bal.IsNumeric(tb_ide_glo.Text.Trim())){
                tb_ide_mod.Focus();
                return "El ID. Global NO es valido";
            }

            // Valida que el campo Nombre de la Global NO este vacio
            if (tb_nom_glo.Text.Trim() == ""){
                tb_nom_glo.Focus();
                return "DEBE proporcionar el Nombre de la Global";
            }

            // Válida los campos de las Global Entero
            if (cb_tip_glo.Text == "Entero"){
                if (tb_glo_ent.Text.Trim() == ""){
                    tb_glo_ent.Focus();
                    return "DEBE proporcionar el valor de la Global en el campo Entero";
                }
                if (!cl_glo_bal.IsNumeric(tb_glo_ent.Text.Trim())){                    
                    tb_glo_ent.Focus();
                    return "El valor de la Global en el campo Entero NO es válido";
                }
            }

            // Válida los campos de las Global Decimal
            if (cb_tip_glo.Text == "Decimal"){
                if (tb_glo_dec.Text.Trim() == ""){
                    tb_glo_dec.Focus();
                    return "DEBE proporcionar el valor de la Global en el campo Decimal";
                }
                if (!cl_glo_bal.IsDecimal(tb_glo_dec.Text.Trim())){
                    tb_glo_dec.Focus();
                    return "El valor de la Global en el campo Decimal NO es válido";
                }
            }

            // Válida los campos de las Caracter
            if (cb_tip_glo.Text == "Caracter")
            {
                if (tb_glo_car.Text.Trim() == ""){
                    tb_glo_car.Focus();
                    return "DEBE proporcionar el valor de la Global en el campo Caracter";
                }                
            }

            // Verifica SI el Módulo se encuentra registrado
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(int.Parse(tb_ide_mod.Text));
            if (Tabla.Rows.Count == 0){
                tb_ide_mod.Focus();
                return "El Módulo seleccionado NO se encuentra registrado";
            }

            // Verifica SI el Módulo se encuentra habilitado
            if (Tabla.Rows[0]["va_est_ado"].ToString() == "N") {
                tb_ide_mod.Focus();
                return "El Módulo seleccionado se encuentra Deshabilitado";
            }            

            // Verifica SI existe otro registro con el mismo ID. Global
            Tabla = new DataTable();
            Tabla = o_ads013.Fe_con_glo(int.Parse(tb_ide_mod.Text), int.Parse(tb_ide_glo.Text));
            if (Tabla.Rows.Count > 0){
                tb_ide_glo.Focus();
                return "Ya existe otra Global con los mismo ID. Global";
            }

            // Verifica SI existe otro registro con el mismo Nombre de Aplicación
            Tabla = new DataTable();
            Tabla = o_ads013.Fe_con_nom(int.Parse(tb_ide_mod.Text), tb_nom_glo.Text.Trim());
            if (Tabla.Rows.Count > 0){
                tb_nom_glo.Focus();
                return "Ya existe otra Global con el mismo Nombre en el mismo Módulo";
            }

            // Quita caracteres especiales de SQL-Trans
            tb_ide_glo.Text = tb_ide_glo.Text.Replace("'", "");
            tb_nom_glo.Text = tb_nom_glo.Text.Replace("'", "");
            tb_glo_ent.Text = tb_glo_ent.Text.Replace("'", "");
            tb_glo_dec.Text = tb_glo_dec.Text.Replace("'", "");
            tb_glo_car.Text = tb_glo_car.Text.Replace("'", "");

            return "OK";
        }

        // Evento Validated : ID. Módulo
        private void tb_ide_mod_Validated(object sender, EventArgs e)
        {
            Fi_obt_mod();
        }

        // Evento KeyPress : ID. Módulo
        private void tb_ide_mod_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyDown : ID. Módulo
        private void Tb_ide_mod_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Módulo
                Fi_bus_mod();
            }
        }

        // Evento Click: Button Buscar Módulo
        private void bt_bus_mod_Click(object sender, EventArgs e)
        {
            // Abre la ventana Busca Modulo
            Fi_bus_mod();
        }

        // Evento KeyPress: ID. Global
        private void tb_ide_glo_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyPress: Global Entero
        private void tb_glo_ent_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);            
        }

        // Evento KeyPress: Global Decimal
        private void tb_glo_dec_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotDecimal(e, tb_glo_dec.Text);
        }

        // Evento SelectedValueChanged: Tipo de Global
        private void cb_tip_glo_SelectedValueChanged(object sender, EventArgs e)
        {
            // Limpia los campos
            tb_glo_car.Text = string.Empty;
            tb_glo_ent.Text = string.Empty;
            tb_glo_dec.Text = string.Empty;

            // Inabilita los controles
            tb_glo_ent.Enabled = false;
            tb_glo_dec.Enabled = false;
            tb_glo_car.Enabled = false;

            // Establece el control de edición
            switch (cb_tip_glo.SelectedIndex) {
                case 0: // Entero
                    tb_glo_ent.Enabled = true;
                    break;                    
                case 1: // Decimal
                    tb_glo_dec.Enabled = true;
                    break; 
                case 2: // Caracter
                    tb_glo_car.Enabled = true;
                    break;            
            }
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                string glo_ent = tb_glo_ent.Text == "" ? "0" : tb_glo_ent.Text;
                string glo_dec = tb_glo_dec.Text == "" ? "0.00" : tb_glo_dec.Text;
                string glo_car = tb_glo_car.Text == "" ? "" : tb_glo_car.Text;

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
                    o_ads013.Fe_nue_reg(int.Parse(tb_ide_mod.Text), int.Parse(tb_ide_glo.Text), tb_nom_glo.Text, cb_tip_glo.SelectedIndex, int.Parse(glo_ent), decimal.Parse(glo_dec), glo_car);
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(tb_ide_mod.Text, tb_ide_glo.Text);
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
