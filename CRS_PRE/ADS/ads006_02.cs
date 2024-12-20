﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads006 - Tipo de Usuario                              */
    /*      Opción: Crear Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 06-04-2023         */
    /**********************************************************************/
    public partial class ads006_02 : Form
    {        
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias 
        ads006 o_ads006 = new ads006();
        ads019 o_ads019 = new ads019();
        DataTable Tabla = new DataTable();

        public ads006_02()
        {
            InitializeComponent();
        }     

        private void frm_Load(object sender, EventArgs e)
        {           
            tb_ide_tus.Focus();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_tus.Text = "0";
            tb_nom_tus.Text = string.Empty;
            tb_des_tus.Text = string.Empty;
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan()
        {
            Tabla = new DataTable();
            Tabla = o_ads006.Fe_obt_ide();
            if (Tabla.Rows.Count > 0)
                tb_ide_tus.Text = Tabla.Rows[0]["va_ide_tus"].ToString();
           
            tb_nom_tus.Focus();
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo código NO este vacio
            if (tb_ide_tus.Text.Trim() == ""){
                tb_ide_tus.Focus();
                return "DEBE proporcionar el Código del Tipo de Usuario";
            }

            // Valida que el campo código sea un valor válido
            if (!cl_glo_bal.IsNumeric(tb_ide_tus.Text.Trim())){
                tb_ide_tus.Focus();
                return "El Código del Tipo de Usuario NO es valido";
            }

            // Valida que el campo Abreviado del Módulo NO este vacio
            if (tb_nom_tus.Text.Trim() == ""){
                tb_nom_tus.Focus();
                return "DEBE proporcionar el Nombre del Tipo de Usuario";
            }            

            // Verifica SI existe otro registro con el mismo Código
            Tabla = new DataTable();
            Tabla = o_ads006.Fe_con_tus(int.Parse(tb_ide_tus.Text));
            if (Tabla.Rows.Count > 0){
                tb_ide_tus.Focus();
                return "Ya existe otro Tipo de Usuario con el mismo Código";
            }
         
            // Verifica SI existe otro registro con el mismo nombre
            Tabla = new DataTable();
            Tabla = o_ads006.Fe_con_nom(tb_nom_tus.Text);
            if (Tabla.Rows.Count > 0){
                tb_nom_tus.Focus();
                return "Ya existe otro Tipo de Usuario con la mismo Nombre";
            }

            // Quita caracteres especiales de SQL-Trans
            tb_ide_tus.Text = tb_ide_tus.Text.Replace("'", "");
            tb_nom_tus.Text = tb_nom_tus.Text.Replace("'", "");
            tb_des_tus.Text = tb_des_tus.Text.Replace("'", "");

            return "OK";
        }

        // Evento KeyPress : ID. Tipo de Usuario
        private void tb_ide_tus_KeyPress(object sender, KeyPressEventArgs e)
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
                    // Graba Registro
                    o_ads006.Fe_nue_reg(int.Parse(tb_ide_tus.Text.Trim()), tb_nom_tus.Text.Trim(), tb_des_tus.Text.Trim());
                    // Graba Bitacora de Operaciones
                    o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "N", "Tipo de Usuario: " + tb_ide_tus.Text.Trim() + " - " + tb_nom_tus.Text.Trim(), SystemInformation.ComputerName);
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_tus.Text.Trim()));
                    // Despliega Mensaje
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK);
                    // Limpia Campos
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
