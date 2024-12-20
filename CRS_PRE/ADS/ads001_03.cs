﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads001 - Módulo del Sistema                           */
    /*      Opción: Edita Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 20-04-2023         */
    /**********************************************************************/
    public partial class ads001_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads001 o_ads001 = new ads001();
        ads019 o_ads019 = new ads019();
        DataTable Tabla = new DataTable();

        public ads001_03()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_ide_mod.Text = frm_dat.Rows[0]["va_ide_mod"].ToString();
            tb_abr_mod.Text = frm_dat.Rows[0]["va_abr_mod"].ToString();
            tb_nom_mod.Text = frm_dat.Rows[0]["va_nom_mod"].ToString();            
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";

            tb_abr_mod.Focus();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_mod.Text = string.Empty;
            tb_nom_mod.Text = string.Empty;
            tb_abr_mod.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
            tb_abr_mod.Focus();
        }

        // Valida los datos proporcionados
        private string Fi_val_dat()
        {
            // Valida que el campo código NO este vacio
            if (tb_ide_mod.Text.Trim() == "") {
                tb_ide_mod.Focus();
                return "DEBE proporcionar el Código del Módulo";
            }

            // Valida que el campo código NO este vacio
            if (!cl_glo_bal.IsNumeric(tb_ide_mod.Text.Trim())) { 
                tb_ide_mod.Focus();
                return "El Código del Módulo NO es válido";
            }

            // Valida que el campo Abreviación NO este vacio
            if (tb_abr_mod.Text.Trim() == ""){
                tb_abr_mod.Focus();
                return "DEBE proporcionar la abreviatura del Módulo";
            }

            // Valida que el campo Nombre NO este vacio
            if (tb_nom_mod.Text.Trim() == ""){
                tb_nom_mod.Focus();
                return "DEBE proporcionar el Nombre del Módulo";
            }

            // Valida que el registro este en el sistema
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(int.Parse(tb_ide_mod.Text));
            if (Tabla.Rows.Count == 0) {
                tb_ide_mod.Focus();
                return "El Módulo NO se encuentra registrado";
            }

            // Valida que el modulo no esta deshabilitado
            if (tb_est_ado.Text.Trim() == "Deshabilitado") { 
                tb_ide_mod.Focus();
                return "El Módulo se encuentra Deshabilitado";
            }

            // Verifica SI existe otro registro con la misma abreviación
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_abr(tb_abr_mod.Text.Trim(), int.Parse(tb_ide_mod.Text));
            if (Tabla.Rows.Count > 0){
                tb_abr_mod.Focus();
                return "YA existe otra Módulo con la misma Abreviación";
            }

            // Verifica SI existe otro registro con el mismo nombre
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_nom(tb_nom_mod.Text.Trim(), int.Parse(tb_ide_mod.Text));
            if (Tabla.Rows.Count > 0){
                tb_nom_mod.Focus();
                return "YA existe otra Módulo con el mismo Nombre";
            }

            // Quita caracteres especiales de SQL-Trans
            tb_abr_mod.Text = tb_abr_mod.Text.Replace("'", "");
            tb_nom_mod.Text = tb_nom_mod.Text.Replace("'", "");

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
                    o_ads001.Fe_edi_tar(int.Parse(tb_ide_mod.Text.Trim()), tb_nom_mod.Text.Trim(), tb_abr_mod.Text.Trim());
                    // Graba Bitacora de Operaciones
                    o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "E", "Módulo: " + tb_abr_mod.Text.Trim() + " - " + tb_nom_mod.Text.Trim(), SystemInformation.ComputerName);
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_mod.Text.Trim()));
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
