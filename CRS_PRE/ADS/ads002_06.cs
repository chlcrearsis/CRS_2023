﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads001 - Aplicaciones del Sistema                     */
    /*      Opción: Elimina Registro                                      */
    /*       Autor: JEJR - Crearsis             Fecha: 19-08-2022         */
    /**********************************************************************/
    public partial class ads002_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads001 o_ads001 = new ads001();
        ads002 o_ads002 = new ads002();
        ads019 o_ads019 = new ads019();
        DataTable Tabla = new DataTable();

        public ads002_06()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_ide_mod.Text = frm_dat.Rows[0]["va_ide_mod"].ToString();
            lb_nom_mod.Text = frm_dat.Rows[0]["va_nom_mod"].ToString();
            tb_ide_apl.Text = frm_dat.Rows[0]["va_ide_apl"].ToString();
            tb_nom_apl.Text = frm_dat.Rows[0]["va_nom_apl"].ToString();
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_mod.Text = string.Empty;
            lb_nom_mod.Text = string.Empty;
            tb_ide_apl.Text = string.Empty;
            tb_nom_apl.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo código NO este vacio
            if (tb_ide_mod.Text.Trim() == "")
                return "DEBE proporcionar el Codigo del Módulo";            

            // Valida que el campo código NO este vacio
            if (!cl_glo_bal.IsNumeric(tb_ide_mod.Text.Trim()))
                return "El Código del Módulo NO tiene formato valido";

            // Valida que el Módulo este registrado en el sistema
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(int.Parse(tb_ide_mod.Text));
            if (Tabla.Rows.Count == 0)
                return "El Módulo NO se encuentra registrado";

            // Valida que la Aplicacion este registrado en el sistema
            Tabla = new DataTable();
            Tabla = o_ads002.Fe_con_apl(int.Parse(tb_ide_mod.Text), tb_ide_apl.Text);
            if (Tabla.Rows.Count == 0)
                return "La Aplicación NO se encuentra registrado";

            // Valida que la Aplicacion NO este habilitado
            if (tb_est_ado.Text == "Habilitado")             
                return "No se puede eliminar, la aplicación se encuentra Habilitada";

            // Valida que la Aplicacion NO sea una aplicacion requerida
            if ((tb_ide_apl.Text.CompareTo("ads200") == 0) ||
                (tb_ide_apl.Text.CompareTo("inv200") == 0) ||
                (tb_ide_apl.Text.CompareTo("cmr200") == 0) ||
                (tb_ide_apl.Text.CompareTo("res200") == 0) ||
                (tb_ide_apl.Text.CompareTo("tes200") == 0)) {
                    return "No se puede Eliminar esta Aplicación, es requerido para el sistema";
                
            }
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
                msg_res = MessageBox.Show("Está seguro de eliminar la Aplicación?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Elimina Registro
                    o_ads002.Fe_eli_min(int.Parse(tb_ide_mod.Text.Trim()), tb_ide_apl.Text.Trim());
                    // Graba Bitacora de Operaciones
                    o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "L", "Aplicación: " + tb_ide_apl.Text.Trim() + " - " + tb_nom_apl.Text.Trim(), SystemInformation.ComputerName);
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(tb_ide_apl.Text.Trim());
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
