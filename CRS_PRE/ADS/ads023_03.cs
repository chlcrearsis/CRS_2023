﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads023 - Tasa de Cambio Bs/Ufv                        */
    /*      Opción: Modifica Tasa de Cambio Bs/Ufv                        */
    /*       Autor: JEJR - Crearsis             Fecha: 09-01-2024         */
    /**********************************************************************/
    public partial class ads023_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads023 o_ads023 = new ads023();
        ads019 o_ads019 = new ads019();
        DataTable Tabla = new DataTable();
        // Variable
        private string va_tip_ope;    // Tipo de Operación (N=Nuevo; E=Edita)

        public ads023_03()
        {
            InitializeComponent();
        }
     
        private void frm_Load(object sender, EventArgs e)
        {
            // Inicializa Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_fec_tas.Text = frm_dat.Rows[0]["va_fec_tas"].ToString();
            tb_tas_cam.Text = frm_dat.Rows[0]["va_tas_cam"].ToString();
            tb_tas_cam.Focus();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_fec_tas.Text = string.Empty;
            tb_tas_cam.Text = string.Empty;
            tb_fec_tas.Enabled = false;
        }       

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo Fecha NO este vacio
            if (tb_fec_tas.Text.Trim() == "  /  /" || 
                tb_fec_tas.Text.Trim() == "00/00/0000"){
                tb_fec_tas.Focus();
                return "DEBE proporcionar la fecha de T.C";
            }

            // Valida que la Fecha sea una fecha válida
            if (!cl_glo_bal.IsDateTime(tb_fec_tas.Text.Trim())){
                tb_fec_tas.Focus();
                return "La Fecha proporcionada NO es valido";
            }

            // Valida que el campo Monto NO este vacio
            if (tb_tas_cam.Text.Trim() == ""){
                tb_tas_cam.Focus();
                return "DEBE proporcionar el valor de la T.C";
            }

            // Valida que el campo Monto sea un valor valido
            if (!cl_glo_bal.IsDecimal(tb_tas_cam.Text.Trim())){
                tb_tas_cam.Focus();
                return "DEBE proporcionar un valor de la T.C válido";
            }

            // Valida que el campo Monto sea un Monto MAYOR a cero
            if (double.Parse(tb_tas_cam.Text.Trim()) <= 0.00){
                tb_tas_cam.Focus();
                return "El Monto de la T.C DEBE ser MAYOR a cero";
            }

            // Verifica si ya se encuentra definida la T.C.
            Tabla = new DataTable();
            Tabla = o_ads023.Fe_con_tas(tb_fec_tas.Text);
            if (Tabla.Rows.Count == 0)
                va_tip_ope = "N";
            else
                va_tip_ope = "E";

            // Quita caracteres especiales de SQL-Trans
            tb_fec_tas.Text = tb_fec_tas.Text.Replace("'", "");
            tb_tas_cam.Text = tb_tas_cam.Text.Replace("'", "");            

            return "OK";
        }

        // Evento Enter: Tasa de Cambio
        private void tb_tas_cam_Enter(object sender, EventArgs e)
        {
            if (tb_tas_cam.Text == "0.0000")
                tb_tas_cam.Clear();
        }

        // Evento Validated: Tasa de Cambio
        private void tb_tas_cam_Validated(object sender, EventArgs e)
        {
            if (tb_tas_cam.Text.Trim() == "")
                tb_tas_cam.Text = "0.0000";
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
                    if (va_tip_ope.CompareTo("N") == 0) { 
                        // Graba Registro
                        o_ads023.Fe_nue_reg(tb_fec_tas.Text.Trim(), double.Parse(tb_tas_cam.Text.Trim()));
                        // Graba Bitacora de Operaciones
                        o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "N", "T.C.: " + tb_fec_tas.Text.Trim() + " - " + tb_tas_cam.Text.Trim(), SystemInformation.ComputerName);
                    }else { 
                        // Edita Registro
                        o_ads023.Fe_edi_tar(tb_fec_tas.Text.Trim(), double.Parse(tb_tas_cam.Text.Trim()));
                        // Graba Bitacora de Operaciones
                        o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "E", "T.C.: " + tb_fec_tas.Text.Trim() + " - " + tb_tas_cam.Text.Trim(), SystemInformation.ComputerName);
                    }
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm();
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
