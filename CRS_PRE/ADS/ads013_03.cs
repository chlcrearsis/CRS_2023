using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads013 - Globales                                     */
    /*      Opción: Edita Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 30-11-2023         */
    /**********************************************************************/
    public partial class ads013_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads001 o_ads001 = new ads001();
        ads013 o_ads013 = new ads013();
        ads019 o_ads019 = new ads019();
        DataTable Tabla = new DataTable();

        public ads013_03()
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
            switch (frm_dat.Rows[0]["va_tip_glo"].ToString()) {
                case "0":
                    cb_tip_glo.SelectedIndex = 0;
                    tb_glo_ent.Text = frm_dat.Rows[0]["va_glo_ent"].ToString().Trim();
                    break;
                case "1":
                    cb_tip_glo.SelectedIndex = 1;
                    tb_glo_dec.Text = frm_dat.Rows[0]["va_glo_dec"].ToString().Trim();
                    break; 
                case "2":
                    cb_tip_glo.SelectedIndex = 2;
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
            tb_glo_ent.Text = string.Empty;
            tb_glo_dec.Text = string.Empty;
            tb_glo_car.Text = string.Empty;
            tb_nom_glo.Focus();
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo ID. Módulo NO este vacio
            if (tb_ide_mod.Text.Trim() == "" ||
                tb_ide_mod.Text.Trim() == "0")            
                return "DEBE proporcionar el ID. Módulo";            

            // Valida que el campo código sea un valor válido
            if (!cl_glo_bal.IsNumeric(tb_ide_mod.Text.Trim()))            
                return "El ID. Módulo NO es valido";            

            // Valida que el campo ID. Global NO este vacio
            if (tb_ide_glo.Text.Trim() == "")            
                return "DEBE proporcionar el ID. Global";            

            // Valida que el campo código sea un valor válido
            if (!cl_glo_bal.IsNumeric(tb_ide_glo.Text.Trim()))            
                return "El ID. Global NO es valido";            

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
            if (cb_tip_glo.Text == "Caracter"){
                if (tb_glo_car.Text.Trim() == ""){
                    tb_glo_car.Focus();
                    return "DEBE proporcionar el valor de la Global en el campo Caracter";
                }
            }

            // Verifica SI el Módulo se encuentra registrado
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(int.Parse(tb_ide_mod.Text));
            if (Tabla.Rows.Count == 0)
                return "El Módulo seleccionado NO se encuentra registrado";            

            // Verifica SI el Módulo se encuentra habilitado
            if (Tabla.Rows[0]["va_est_ado"].ToString() == "N")
                return "El Módulo seleccionado se encuentra Deshabilitado";            

            // Verifica SI la Global se encuentra registrado
            Tabla = new DataTable();
            Tabla = o_ads013.Fe_con_glo(int.Parse(tb_ide_mod.Text), int.Parse(tb_ide_glo.Text));
            if (Tabla.Rows.Count == 0)
                return "La Global (" + tb_ide_mod.Text + "-" + tb_ide_glo.Text + ") NO se encuentra registrado";            

            // Verifica SI existe otro registro con el mismo Nombre de Aplicación
            Tabla = new DataTable();
            Tabla = o_ads013.Fe_con_nom(int.Parse(tb_ide_mod.Text), tb_nom_glo.Text.Trim(), int.Parse(tb_ide_glo.Text));
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
            switch (cb_tip_glo.SelectedIndex)
            {
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
            DialogResult msg_res;

            try
            {
                // Obtiene Datos de Pantalla
                string glo_ent = tb_glo_ent.Text == "" ? "0" : tb_glo_ent.Text;
                string glo_dec = tb_glo_dec.Text == "" ? "0.00" : tb_glo_dec.Text;
                string glo_car = tb_glo_car.Text == "" ? "" : tb_glo_car.Text;

                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "OK")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Edita Registro
                    o_ads013.Fe_edi_tar(int.Parse(tb_ide_mod.Text.Trim()), int.Parse(tb_ide_glo.Text.Trim()), tb_nom_glo.Text.Trim(), cb_tip_glo.SelectedIndex, int.Parse(glo_ent), decimal.Parse(glo_dec), glo_car);
                    // Graba Bitacora de Operaciones
                    o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "E", "Global: (" + tb_ide_mod.Text.Trim() + "-" + tb_ide_glo.Text.Trim() + ") " + tb_nom_glo.Text.Trim(), SystemInformation.ComputerName);
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(tb_ide_mod.Text.Trim(), tb_ide_glo.Text.Trim());
                    // Despliega Mensaje
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK);
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
