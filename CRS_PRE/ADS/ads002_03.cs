﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads002 - Aplicaciones del Sistema                     */
    /*      Opción: Edita Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 20-04-2023         */
    /**********************************************************************/
    public partial class ads002_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads001 o_ads001 = new ads001();
        ads002 o_ads002 = new ads002();
        ads019 o_ads019 = new ads019();
        DataTable Tabla = new DataTable();

        public ads002_03()
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

            tb_nom_apl.Focus();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_mod.Text = string.Empty;
            lb_nom_mod.Text = string.Empty;
            tb_ide_apl.Text = string.Empty;
            tb_nom_apl.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
            tb_nom_apl.Focus();
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo código NO este vacio
            if (tb_ide_mod.Text.Trim() == "") {
                tb_ide_mod.Focus();
                return "DEBE proporcionar el Código del Módulo";
            }

            // Valida que el campo código NO este vacio
            if (!cl_glo_bal.IsNumeric(tb_ide_mod.Text.Trim())){
                tb_ide_mod.Focus();
                return "El Código del Módulo NO es válido";
            }

            // Verifica SI el Módulo se encuentra registrado
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(int.Parse(tb_ide_mod.Text));
            if (Tabla.Rows.Count == 0) {
                tb_ide_mod.Focus();
                return "El Módulo NO se encuentra registrado";
            }

            // Verifica SI la Aplicacion se encuentra registrado
            Tabla = new DataTable();
            Tabla = o_ads002.Fe_con_apl(int.Parse(tb_ide_mod.Text), tb_ide_apl.Text);
            if (Tabla.Rows.Count == 0){
                tb_ide_apl.Focus();
                return "La Aplicación NO se encuentra registrado";
            }

            // Verifica SI la Aplicacion se encuentra habilitada
            if (tb_est_ado.Text.Trim() == "Deshabilitado")            
                return "La Aplicación se encuentra deshabilitada";

            // Verifica SI existe otro registro con el mismo Nombre de Aplicación
            Tabla = new DataTable();
            Tabla = o_ads002.Fe_con_nom(tb_nom_apl.Text, tb_ide_apl.Text);
            if (Tabla.Rows.Count > 0){
                tb_ide_apl.Focus();
                return "Ya existe otra Aplicación con los mismo Nombre de Aplicación";
            }

            // Verifica SI la aplicación a editar es reservado por el sistema
            if ((tb_ide_apl.Text.ToString().CompareTo("ads200") == 0) ||
                (tb_ide_apl.Text.ToString().CompareTo("inv200") == 0) ||
                (tb_ide_apl.Text.ToString().CompareTo("cmr200") == 0) ||
                (tb_ide_apl.Text.ToString().CompareTo("res200") == 0) ||
                (tb_ide_apl.Text.ToString().CompareTo("tes200") == 0))
                return "No se puede modificar esta Aplicación, es reservado para el sistema";

            // Quita caracteres especiales de SQL-Trans
            tb_ide_apl.Text = tb_ide_apl.Text.Replace("'", "");
            tb_nom_apl.Text = tb_nom_apl.Text.Replace("'", "");

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
                    o_ads002.Fe_edi_tar(int.Parse(tb_ide_mod.Text.Trim()), tb_ide_apl.Text.Trim(), tb_nom_apl.Text.Trim());
                    // Graba Bitacora de Operaciones
                    o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "E", "Aplicación: " + tb_ide_apl.Text.Trim() + " - " + tb_nom_apl.Text.Trim(), SystemInformation.ComputerName);
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
