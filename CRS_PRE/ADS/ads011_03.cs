using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads011 - Definición de Claves                         */
    /*      Opción: Edita Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 05-12-2023         */
    /**********************************************************************/
    public partial class ads011_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads001 o_ads001 = new ads001();
        ads011 o_ads011 = new ads011();
        ads019 o_ads019 = new ads019();
        DataTable Tabla = new DataTable();

        public ads011_03()
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
            tb_ide_cla.Text = frm_dat.Rows[0]["va_ide_cla"].ToString().Trim();
            tb_nom_cla.Text = frm_dat.Rows[0]["va_nom_cla"].ToString().Trim();
            tb_obs_cla.Text = frm_dat.Rows[0]["va_obs_cla"].ToString().Trim();
            switch (frm_dat.Rows[0]["va_cla_req"].ToString()) {
                case "S":
                    cb_cla_req.SelectedIndex = 0;
                    break;
                case "N":
                    cb_cla_req.SelectedIndex = 1;
                    break;
            }
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_mod.Text = string.Empty;
            lb_nom_mod.Text = string.Empty;
            tb_ide_cla.Text = string.Empty;
            tb_nom_cla.Text = string.Empty;
            tb_obs_cla.Text = string.Empty;
            tb_nom_cla.Focus();
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

            // Valida que el campo ID. Clave NO este vacio
            if (tb_ide_cla.Text.Trim() == "")            
                return "DEBE proporcionar el ID. Clave";            

            // Valida que el campo ID. Clave sea un valor válido
            if (!cl_glo_bal.IsNumeric(tb_ide_cla.Text.Trim()))            
                return "El ID. Clave NO es valido";            

            // Valida que el campo Nombre de la Clave NO este vacio
            if (tb_nom_cla.Text.Trim() == ""){
                tb_nom_cla.Focus();
                return "DEBE proporcionar el Nombre de la Clave";
            }           

            // Verifica SI el Módulo se encuentra registrado
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(int.Parse(tb_ide_mod.Text));
            if (Tabla.Rows.Count == 0)
                return "El Módulo seleccionado NO se encuentra registrado";            

            // Verifica SI el Módulo se encuentra habilitado
            if (Tabla.Rows[0]["va_est_ado"].ToString() == "N")
                return "El Módulo seleccionado se encuentra Deshabilitado";            

            // Verifica SI la Clave se encuentra registrado
            Tabla = new DataTable();
            Tabla = o_ads011.Fe_con_cla(int.Parse(tb_ide_mod.Text), int.Parse(tb_ide_cla.Text));
            if (Tabla.Rows.Count == 0)
                return "La Clave (" + tb_ide_mod.Text + "-" + tb_ide_cla.Text + ") NO se encuentra registrado";            

            // Verifica SI existe otro registro con el mismo Nombre de Clave
            Tabla = new DataTable();
            Tabla = o_ads011.Fe_con_nom(int.Parse(tb_ide_mod.Text), tb_nom_cla.Text.Trim(), int.Parse(tb_ide_cla.Text));
            if (Tabla.Rows.Count > 0){
                tb_nom_cla.Focus();
                return "Ya existe otra Clave con el mismo Nombre en el mismo Módulo";
            }

            // Quita caracteres especiales de SQL-Trans
            tb_ide_mod.Text = tb_ide_mod.Text.Replace("'", "");
            tb_ide_cla.Text = tb_ide_cla.Text.Replace("'", "");
            tb_nom_cla.Text = tb_nom_cla.Text.Replace("'", "");
            tb_obs_cla.Text = tb_obs_cla.Text.Replace("'", "");

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
                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Edita Registro
                    o_ads011.Fe_edi_tar(int.Parse(tb_ide_mod.Text.Trim()), int.Parse(tb_ide_cla.Text.Trim()), tb_nom_cla.Text.Trim(), tb_obs_cla.Text.Trim(), cb_cla_req.Text.Substring(0, 1));
                    // Graba Bitacora de Operaciones
                    o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "E", "Clave: (" + tb_ide_mod.Text.Trim() + "-" + tb_ide_cla.Text.Trim() + ") " + tb_nom_cla.Text.Trim(), SystemInformation.ComputerName);
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(tb_ide_mod.Text.Trim(), tb_ide_cla.Text.Trim());
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
