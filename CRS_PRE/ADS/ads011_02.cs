using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads011 - Definición de Claves                         */
    /*      Opción: Crear Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 04-12-2023         */
    /**********************************************************************/
    public partial class ads011_02 : Form
    {     
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias
        ads001 o_ads001 = new ads001();
        ads011 o_ads011 = new ads011();        
        DataTable Tabla = new DataTable();

        public ads011_02()
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
            tb_ide_cla.Text = string.Empty;
            tb_nom_cla.Text = string.Empty;
            tb_obs_cla.Text = string.Empty;
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan()
        {
            // Establece el Focus en el Módulo 
            tb_ide_mod.Text = "0";
            lb_nom_mod.Text = "...";
            cb_cla_req.SelectedIndex = 0;
            tb_ide_mod.Focus();
        }

        // Obtiene el Ultimo ID. Correspondiente
        private void Fi_ult_ide() {
            tb_ide_cla.Text = string.Empty;
            // Verifica si el ID. Módulo es Numerico
            if (cl_glo_bal.IsNumeric(tb_ide_mod.Text)) {
                // Obtiene el Ultimo ID. Clave
                Tabla = new DataTable();
                Tabla = o_ads011.Fe_obt_ide(int.Parse(tb_ide_mod.Text));
                if (Tabla.Rows.Count > 0)
                    tb_ide_cla.Text = Tabla.Rows[0]["va_ide_cla"].ToString();

                tb_nom_cla.Focus();
            }                                   
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
                // Obtiene el ID. Clave
                Fi_ult_ide();
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

            // Valida que el campo ID. Clave NO este vacio
            if (tb_ide_cla.Text.Trim() == ""){
                tb_ide_cla.Focus();
                return "DEBE proporcionar el ID. Clave";
            }

            // Valida que el campo ID. Clave sea un valor válido
            if (!cl_glo_bal.IsNumeric(tb_ide_cla.Text.Trim())){
                tb_ide_mod.Focus();
                return "El ID. Clave NO es valido";
            }

            // Valida que el campo Nombre de la Global NO este vacio
            if (tb_nom_cla.Text.Trim() == ""){
                tb_nom_cla.Focus();
                return "DEBE proporcionar el Nombre de la Clave";
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

            // Verifica SI existe otro registro con el mismo ID. Clave
            Tabla = new DataTable();
            Tabla = o_ads011.Fe_con_cla(int.Parse(tb_ide_mod.Text), int.Parse(tb_ide_cla.Text));
            if (Tabla.Rows.Count > 0){
                tb_ide_cla.Focus();
                return "Ya existe otra Clave con los mismo ID. Clave";
            }

            // Verifica SI existe otro registro con el mismo Nombre de Clave
            Tabla = new DataTable();
            Tabla = o_ads011.Fe_con_nom(int.Parse(tb_ide_mod.Text), tb_nom_cla.Text.Trim());
            if (Tabla.Rows.Count > 0){
                tb_nom_cla.Focus();
                return "Ya existe otra Global con el mismo Nombre en el mismo Módulo";
            }

            // Quita caracteres especiales de SQL-Trans
            tb_ide_cla.Text = tb_ide_cla.Text.Replace("'", "");
            tb_nom_cla.Text = tb_nom_cla.Text.Replace("'", "");            
            tb_obs_cla.Text = tb_obs_cla.Text.Replace("'", "");

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
                    o_ads011.Fe_nue_reg(int.Parse(tb_ide_mod.Text), int.Parse(tb_ide_cla.Text), tb_nom_cla.Text, tb_obs_cla.Text, cb_cla_req.SelectedText.Substring(0, 1));
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(tb_ide_mod.Text, tb_ide_cla.Text);
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
