using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads025 - Validación Clave Usuario                     */
    /*      Opción: Registra Validación Clave Usuario                     */
    /*       Autor: JEJR - Crearsis             Fecha: 13-01-2024         */
    /**********************************************************************/
    public partial class ads025_01 : Form
    {     
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias
        ads007 o_ads007 = new ads007();
        ads011 o_ads011 = new ads011();
        ads014 o_ads014 = new ads014();
        ads025 o_ads025 = new ads025();        
        DataTable Tabla = new DataTable();
        // Variables        
        public int vp_ide_mod = 0;     // ID. Módulo
        public int vp_ide_cla = 0;     // ID. Clave

        public ads025_01()
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
            tb_ide_cla.Text = string.Empty;
            tb_nom_cla.Text = string.Empty;            
            tb_ide_usr.Text = string.Empty;            
            tb_pas_usr.Text = "password";
            tb_cla_usr.Text = "password";
            tb_obs_reg.Text = string.Empty;
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
            tb_ide_usr.Focus();
        }        

        // Valida los datos proporcionados
        protected string Fi_val_dat(int opc_ver = 0)
        {
            // Valida que exista la clave proporcioando en la BD
            Tabla = new DataTable();
            Tabla = o_ads011.Fe_con_cla(vp_ide_mod, vp_ide_cla);
            if (Tabla.Rows.Count == 0)
                return "La Clave (" + vp_ide_mod + "-" + vp_ide_cla + ") NO está definido en el sistema";

            // Valida que el campo usuario no este vacio
            if (tb_ide_usr.Text.Trim() == ""){
                tb_ide_usr.Focus();
                return "DEBE proporcionar el ID. Usuario";
            }

            // Valida que el Usuario este creado y habilitado
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_con_ide(tb_ide_usr.Text.Trim());
            if (Tabla.Rows.Count == 0){
                tb_ide_usr.Focus();
                return "El ID. Usuario NO está definido en el sistema";
            }
            if (Tabla.Rows[0]["va_est_ado"].ToString().CompareTo("H") != 0){
                tb_ide_usr.Focus();
                return "El Usuario NO está Habilitado en el sistema";
            }
            if (opc_ver == 1){
                if (Tabla.Rows[0]["va_ide_tus"].ToString().CompareTo("1") != 0){
                    tb_ide_usr.Focus();
                    return "El Usuario NO está Habilitado para esta opción";
                }
            }

            // Valida que el campo contraseña no este vacio
            if (tb_pas_usr.Text.Trim() == "" || tb_pas_usr.Text.Trim() == "password"){
                tb_pas_usr.Focus();
                return "DEBE proporcionar la Contraseña";
            }

            // Valida que la contraseña este bien
            string res_cnx = o_ads007.Fe_ing_sis(tb_ide_usr.Text.Trim(), tb_pas_usr.Text.Trim());
            if (res_cnx.CompareTo("OK") != 0) {
                tb_pas_usr.Focus();
                return "La Contraseña proporcionada es incorrecta";
            }
            
            if (opc_ver == 0){
                // Valida que el campo clave no este vacio
                if (tb_cla_usr.Text.Trim() == "" || tb_cla_usr.Text.Trim() == "password"){
                    tb_cla_usr.Focus();
                    return "DEBE proporcionar la Clave";
                }

                // Valida que este definida y correcta la clave para el usuario
                Tabla = new DataTable();
                Tabla = o_ads014.Fe_obt_cla(tb_ide_usr.Text.Trim(), vp_ide_mod, vp_ide_cla);
                if (Tabla.Rows.Count == 0){
                    tb_cla_usr.Focus();
                    return "El Usuario NO tiene definido la Clave " + tb_ide_cla.Text + ". Verifique e intente nuevamente";
                }

                if (Tabla.Rows[0]["va_cla_usr"].ToString().CompareTo(tb_cla_usr.Text.Trim()) != 0){
                    tb_cla_usr.Focus();
                    return "La Clave proporcionado es incorrecta";
                }

                // Valida que el campo observación no este vacio
                if (tb_obs_reg.Text.Trim() == ""){
                    tb_obs_reg.Focus();
                    return "DEBE proporcionar la Observación";
                }
            }            

            // Quita caracteres especiales de SQL-Trans
            tb_ide_usr.Text = tb_ide_usr.Text.Replace("'", "");
            tb_pas_usr.Text = tb_pas_usr.Text.Replace("'", "");
            tb_cla_usr.Text = tb_cla_usr.Text.Replace("'", "");
            tb_obs_reg.Text = tb_obs_reg.Text.Replace("'", "");

            return "OK";
        }        

        // Evento KeyDown: ID. Usuario
        private void tb_ide_usr_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                ads007_01c frm = new ads007_01c{
                    vp_ide_mod = vp_ide_mod,
                    vp_ide_cla = vp_ide_cla
                };
                cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

                if (frm.DialogResult == DialogResult.OK)
                    tb_ide_usr.Text = frm.vp_ide_usr;                
            }
        }

        // Evento Enter: Contraseña
        private void tb_pas_usr_Enter(object sender, EventArgs e)
        {
            if (tb_pas_usr.Text == "password")
                tb_pas_usr.Clear();
        }

        // Evento Enter: Clave
        private void tb_cla_usr_Enter(object sender, EventArgs e)
        {
            if (tb_cla_usr.Text == "password")
                tb_cla_usr.Clear();
        }

        // Evento Validated: Contraseña
        private void tb_pas_usr_Validated(object sender, EventArgs e)
        {
            if (tb_pas_usr.Text.Trim() == "")
                tb_pas_usr.Text = "password";
        }

        // Evento Validated: Clave
        private void tb_cla_usr_Validated(object sender, EventArgs e)
        {
            if (tb_cla_usr.Text.Trim() == "")
                tb_cla_usr.Text = "password";
        }

        // Evento Click: Button Buscar Usuario
        private void bt_bus_usr_Click(object sender, EventArgs e)
        {
            ads007_01c frm = new ads007_01c
            {
                vp_ide_mod = vp_ide_mod,
                vp_ide_cla = vp_ide_cla
            };
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
                tb_ide_usr.Text = frm.vp_ide_usr;
        }

        // Evento Click: Button Cambiar Clave
        private void bt_cam_cla_Click(object sender, EventArgs e)
        {
            try
            {                
                // funcion para validar datos
                string msg_val = Fi_val_dat(1);
                if (msg_val != "OK")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }

                ads014_02b frm = new ads014_02b
                {
                    vp_ide_usr = tb_ide_usr.Text,
                    vp_ide_mod = vp_ide_mod,
                    vp_ide_cla = vp_ide_cla
                };
                cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

                if (frm.DialogResult == DialogResult.OK)
                   tb_cla_usr.Text = string.Empty;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "OK"){
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                // Graba registro
                o_ads025.Fe_nue_reg(tb_ide_usr.Text.Trim(), cl_glo_bal.glo_ide_usr, vp_ide_mod, vp_ide_cla, SystemInformation.ComputerName, tb_obs_reg.Text);
                // Retorna Resultado
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }        
    }
}
