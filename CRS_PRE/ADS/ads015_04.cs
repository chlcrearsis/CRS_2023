﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads015 - Regional                                     */
    /*      Opción: Habilita/Deshabilita Registro                         */
    /*       Autor: JEJR - Crearsis             Fecha: 18-12-2023         */
    /**********************************************************************/
    public partial class ads015_04 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads002 o_ads002 = new ads002();
        ads015 o_ads015 = new ads015();
        ads019 o_ads019 = new ads019();
        DataTable Tabla = new DataTable();

        public ads015_04()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_ide_reg.Text = frm_dat.Rows[0]["va_ide_reg"].ToString();
            tb_nom_reg.Text = frm_dat.Rows[0]["va_nom_reg"].ToString();
            tb_nom_cor.Text = frm_dat.Rows[0]["va_nom_cor"].ToString();
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";            
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_reg.Text = string.Empty;
            tb_nom_reg.Text = string.Empty;
            tb_nom_cor.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
        }

        // Valida los datos proporcionado por pantalla
        protected string Fi_val_dat()
        {
            // Valida que el campo código NO este vacio
            if (tb_ide_reg.Text.Trim() == "")
                return "DEBE proporcionar el Código de la Regional";            

            // Valida que el campo código NO este vacio
            if (!cl_glo_bal.IsNumeric(tb_ide_reg.Text.Trim()))
                return "El Código de la Regional NO es válido";            

            // Valida que el registro este en el sistema
            Tabla = new DataTable();
            Tabla = o_ads015.Fe_con_reg(int.Parse(tb_ide_reg.Text));
            if (Tabla.Rows.Count == 0)
                return "La Regional NO se encuentra registrado";            

            // Si el registro se va a deshabilitar, verifica que no exista ninguna aplicacion Habilitada
            /*if (tb_est_ado.Text == "Habilitado") {
                Tabla = new DataTable();
                Tabla = o_ads002.Fe_con_mod(int.Parse(tb_ide_reg.Text), "H");
                if (Tabla.Rows.Count > 0)
                    return "Existe " + Tabla.Rows.Count + " aplicaciones habilitadas, que depende de " + tb_nom_mod.Text;                
            }*/
           
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

                if (tb_est_ado.Text == "Habilitado")
                    msg_res = MessageBox.Show("Está seguro de Deshabilitar el registro?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                else
                    msg_res = MessageBox.Show("Está seguro de Habilitar el registro?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (msg_res == DialogResult.OK)
                {
                    if (tb_est_ado.Text == "Habilitado"){
                        // Deshabilita Registro
                        o_ads015.Fe_hab_des(int.Parse(tb_ide_reg.Text.Trim()), "D");
                        // Graba Bitacora de Operaciones
                        o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "E", "Regional: " + tb_ide_reg.Text.Trim() + " - " + tb_nom_reg.Text.Trim(), SystemInformation.ComputerName);
                    }else{
                        // Habilita Registro
                        o_ads015.Fe_hab_des(int.Parse(tb_ide_reg.Text.Trim()), "H");
                        // Graba Bitacora de Operaciones
                        o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "H", "Regional: " + tb_ide_reg.Text.Trim() + " - " + tb_nom_reg.Text.Trim(), SystemInformation.ComputerName);
                    }
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_reg.Text));
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
