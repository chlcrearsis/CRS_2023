using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads014 - Clave Usuario p/Global                       */
    /*      Opción: Cambia Clave Usuario                                  */
    /*       Autor: JEJR - Crearsis             Fecha: 23-01-2024         */
    /**********************************************************************/
    public partial class ads014_02b : Form
    {     
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias
        ads011 o_ads011 = new ads011();
        ads014 o_ads014 = new ads014();
        ads019 o_ads019 = new ads019();
        DataTable Tabla = new DataTable();
        // Variables
        public string vp_ide_usr = ""; // ID. Usuario
        public int vp_ide_mod = 0;     // ID. Módulo
        public int vp_ide_cla = 0;     // ID. Clave

        public ads014_02b()
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
            tb_nue_cla.Text = "password";
            tb_rep_cla.Text = "password";
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
        }        

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo nueva clave no este vacio
            if (tb_nue_cla.Text.Trim() == "" || tb_nue_cla.Text.Trim() == "password"){
                tb_nue_cla.Focus();
                return "DEBE proporcionar la nueva clave";
            }

            // Valida que el campo repetir clave no este vacio
            if (tb_rep_cla.Text.Trim() == "" || tb_rep_cla.Text.Trim() == "password"){
                tb_rep_cla.Focus();
                return "DEBE repetir la clave nueva";
            }

            // Valida que la nueva clave sea la misma que repetir contraseña
            if (tb_nue_cla.Text.Trim() != tb_rep_cla.Text.Trim()){
                tb_rep_cla.Focus();
                return "La Clave NO es la misma que la proporcionada";
            }

            // Valida que la contraseña sea MAYOR o IGUAL 3 digitos
            if (tb_nue_cla.Text.Length < 3){
                tb_nue_cla.Focus();
                return "La Clave DEBE ser MAYOR o IGUAL a 3 digitos";
            }

            // Valida que exista la clave proporcioando en la BD
            Tabla = new DataTable();
            Tabla = o_ads011.Fe_con_cla(vp_ide_mod, vp_ide_cla);
            if (Tabla.Rows.Count == 0)
                return "La Clave (" + vp_ide_mod + "-" + vp_ide_cla + ") NO está definido en el sistema";

            // Quita caracteres especiales de SQL-Trans
            tb_nue_cla.Text = tb_nue_cla.Text.Replace("'", "");
            tb_rep_cla.Text = tb_rep_cla.Text.Replace("'", "");

            return "OK";
        }

        // Evento Enter: Nueva Clave
        private void tb_nue_cla_Enter(object sender, EventArgs e)
        {
            if (tb_nue_cla.Text == "password")
                tb_nue_cla.Clear();
        }

        // Evento Enter: Repetir Clave
        private void tb_rep_cla_Enter(object sender, EventArgs e)
        {
            if (tb_rep_cla.Text == "password")
                tb_rep_cla.Clear();
        }

        // Evento Validated: Nueva Clave
        private void tb_nue_cla_Validated(object sender, EventArgs e)
        {
            if (tb_nue_cla.Text.Trim() == "")
                tb_nue_cla.Text = "password";
        }

        // Evento Validated: Repetir Clave
        private void tb_rep_cla_Validated(object sender, EventArgs e)
        {
            if (tb_rep_cla.Text.Trim() == "")
                tb_rep_cla.Text = "password";
        }       


        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "OK")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }

                // Verifica si se va a suprimir o actualizar
                DialogResult msg_res = MessageBox.Show("Esta seguro de modificar la clave?", Text, MessageBoxButtons.OKCancel);

                if (msg_res == DialogResult.OK)
                {
                    // Graba registro
                    o_ads014.Fe_eli_min(vp_ide_usr, vp_ide_mod, vp_ide_cla);
                    // Graba registro
                    o_ads014.Fe_nue_reg(vp_ide_usr, vp_ide_mod, vp_ide_cla, tb_nue_cla.Text);
                    // Graba Bitacora de Operaciones
                    o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "E", vp_ide_usr + " Clave: " + tb_ide_cla.Text.Trim() + " " + tb_nom_cla.Text.Trim(), SystemInformation.ComputerName);
                    // Despliega Mensaje
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK);
                    // Inicializa Campos
                    Fi_lim_pia();
                    // Retorna Resultado
                    DialogResult = DialogResult.OK;
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
            DialogResult = DialogResult.Cancel;
        }        
    }
}
