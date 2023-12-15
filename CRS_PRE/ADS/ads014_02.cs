using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads014 - Clave Usuario p/Global                       */
    /*      Opción: Actualiza Clave                                       */
    /*       Autor: JEJR - Crearsis             Fecha: 13-12-2023         */
    /**********************************************************************/
    public partial class ads014_02 : Form
    {     
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias
        ads011 o_ads011 = new ads011();
        ads014 o_ads014 = new ads014();        
        DataTable Tabla = new DataTable();
        // Variables
        public string vp_ide_usr = ""; // ID. Usuario
        public int vp_ide_mod = 0;     // ID. Módulo
        public int vp_ide_cla = 0;     // ID. Clave

        public ads014_02()
        {
            InitializeComponent();
        }
     
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();                                   
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_nom_cla.Text = string.Empty;
            tb_ide_cla.Text = string.Empty;
            tb_con_act.Text = string.Empty;
            tb_nue_con.Text = "password";
            tb_rep_con.Text = "password";
            rb_sup_aut.Checked = false;
            tb_con_act.Enabled = false;
            // Inicializa Campos
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan()
        {
            // Obtiene datos de la Global
            Tabla = new DataTable();
            Tabla = o_ads011.Fe_con_cla(vp_ide_mod, vp_ide_cla);
            if (Tabla.Rows.Count > 0) { 
                tb_nom_cla.Text = Tabla.Rows[0]["va_nom_cla"].ToString().Trim();
                tb_ide_cla.Text = "(" + Tabla.Rows[0]["va_ide_mod"].ToString().Trim() +
                                " - " + Tabla.Rows[0]["va_ide_cla"].ToString().Trim() + ")";
            }

            // Verifica si tiene una clave proporcioanda
            Tabla = new DataTable();
            Tabla = o_ads014.Fe_obt_cla(vp_ide_usr, vp_ide_mod, vp_ide_cla);
            if (Tabla.Rows.Count > 0){
                rb_sup_aut.Enabled = true;
                tb_con_act.Text = Tabla.Rows[0]["va_cla_usr"].ToString();
            }else {
                rb_sup_aut.Enabled = false;
            }
        }        

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo nueva contraseña no este vacio
            if (!rb_sup_aut.Checked){
                if (tb_nue_con.Text.Trim() == "" || tb_nue_con.Text.Trim() == "password"){
                    tb_nue_con.Focus();
                    return "DEBE proporcionar la nueva contraseña";
                }
            }

            // Valida que el campo repetir contraseña no este vacio
            if (!rb_sup_aut.Checked){
                if (tb_rep_con.Text.Trim() == "" || tb_rep_con.Text.Trim() == "password"){
                    tb_rep_con.Focus();
                    return "DEBE repetir la contraseña nueva";
                }
            }

            // Valida que la nueva contraseña sea la misma que repetir contraseña
            if (!rb_sup_aut.Checked){
                if (tb_nue_con.Text.Trim() != tb_rep_con.Text.Trim()){
                    tb_rep_con.Focus();
                    return "La Contraseña NO es la misma que la proporcionada";
                }
            }

            // Valida que la contraseña sea MAYOR o IGUAL 3 digitos
            if (!rb_sup_aut.Checked){
                if (tb_nue_con.Text.Length < 3){
                    tb_nue_con.Focus();
                    return "La Contraseña DEBE ser MAYOR o IGUAL a 3 digitos";
                }
            }

            // Valida que exista la clave proporcioando en la BD
            Tabla = new DataTable();
            Tabla = o_ads011.Fe_con_cla(vp_ide_mod, vp_ide_cla);
            if (Tabla.Rows.Count == 0)
                return "La Clave (" + vp_ide_mod + "-" + vp_ide_cla + ") NO está definido en el sistema";

            // Quita caracteres especiales de SQL-Trans
            tb_con_act.Text = tb_con_act.Text.Replace("'", "");
            tb_nue_con.Text = tb_nue_con.Text.Replace("'", "");
            tb_rep_con.Text = tb_rep_con.Text.Replace("'", "");

            return "OK";
        }

        // Evento Enter: Nueva Contraseña
        private void tb_nue_con_Enter(object sender, EventArgs e)
        {
            if (tb_nue_con.Text == "password")
                tb_nue_con.Clear();
        }

        // Evento Enter: Repetir Contraseña
        private void tb_rep_con_Enter(object sender, EventArgs e)
        {
            if (tb_rep_con.Text == "password")
                tb_rep_con.Clear();
        }

        // Evento Validated: Nueva Contraseña
        private void tb_nue_con_Validated(object sender, EventArgs e)
        {
            if (tb_nue_con.Text.Trim() == "")
                tb_nue_con.Text = "password";
        }

        // Evento Validated: Repetir Contraseña
        private void tb_rep_con_Validated(object sender, EventArgs e)
        {
            if (tb_rep_con.Text.Trim() == "")
                tb_rep_con.Text = "password";
        }

        // Evento CheckedChanged: Suprimir Autorizacion
        private void rb_sup_aut_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_sup_aut.Checked){
                tb_nue_con.Text = "password";
                tb_rep_con.Text = "password";
            }
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

                // Verifica si se va a suprimir o actualizar
                if (rb_sup_aut.Checked)                
                    msg_res = MessageBox.Show("Esta seguro de suprimir la autorización?", Text, MessageBoxButtons.OKCancel);
                else
                    msg_res = MessageBox.Show("Esta seguro de grabar la autorización?", Text, MessageBoxButtons.OKCancel);


                if (msg_res == DialogResult.OK)
                {
                    // Graba registro
                    if (rb_sup_aut.Checked == true){
                        o_ads014.Fe_eli_min(vp_ide_usr, vp_ide_mod, vp_ide_cla);
                    }else{
                        if (tb_con_act.Enabled == false)
                            o_ads014.Fe_nue_reg(vp_ide_usr, vp_ide_mod, vp_ide_cla, tb_nue_con.Text);
                        else
                            o_ads014.Fe_edi_tar(vp_ide_usr, vp_ide_mod, vp_ide_cla, tb_nue_con.Text);
                    }

                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm();
                    // Despliega Mensaje
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK);
                    // Inicializa Campos
                    Fi_lim_pia();
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
