﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;
using static CRS_NEG.ads007;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads004 - Talonario                                    */
    /*      Opción: Habilita/Deshabilita Registro                         */
    /*       Autor: JEJR - Crearsis             Fecha: 31-08-2022         */
    /**********************************************************************/
    public partial class ads004_04 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads003 o_ads003 = new ads003();
        ads004 o_ads004 = new ads004();
        ads019 o_ads019 = new ads019();
        DataTable Tabla = new DataTable();

        public ads004_04()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_ide_doc.Text = frm_dat.Rows[0]["va_ide_doc"].ToString();
            lb_nom_doc.Text = frm_dat.Rows[0]["va_nom_doc"].ToString();
            tb_nro_tal.Text = frm_dat.Rows[0]["va_nro_tal"].ToString();
            tb_nom_tal.Text = frm_dat.Rows[0]["va_nom_tal"].ToString();            
            tb_for_mat.Text = frm_dat.Rows[0]["va_for_mat"].ToString();
            tb_nro_cop.Text = frm_dat.Rows[0]["va_nro_cop"].ToString();
            tb_nro_aut.Text = frm_dat.Rows[0]["va_nro_aut"].ToString();
            tb_fir_ma1.Text = frm_dat.Rows[0]["va_fir_ma1"].ToString();
            tb_fir_ma2.Text = frm_dat.Rows[0]["va_fir_ma2"].ToString();
            tb_fir_ma3.Text = frm_dat.Rows[0]["va_fir_ma3"].ToString();
            tb_fir_ma4.Text = frm_dat.Rows[0]["va_fir_ma4"].ToString(); 
            tb_obs_uno.Text = frm_dat.Rows[0]["va_obs_uno"].ToString();
            tb_obs_dos.Text = frm_dat.Rows[0]["va_obs_dos"].ToString();
            switch (frm_dat.Rows[0]["va_tip_tal"].ToString()){
                case "0": tb_tip_tal.Text = "Manual"; break;
                case "1": tb_tip_tal.Text = "Automático"; break;
            }            
            switch (frm_dat.Rows[0]["va_for_log"].ToString()){
                case "0": tb_for_log.Text = "Razon social de la empresa"; break;
                case "1": tb_for_log.Text = "Logo 1"; break;
                case "2": tb_for_log.Text = "Logo 2"; break;
                case "3": tb_for_log.Text = "Logo 3"; break;
            }
            switch (frm_dat.Rows[0]["va_est_ado"].ToString()){
                case "H": tb_est_ado.Text = "Habilitado"; break;
                case "N": tb_est_ado.Text = "Deshabilitado"; break;
            }
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_doc.Text = string.Empty;
            lb_nom_doc.Text = string.Empty;
            tb_nro_tal.Text = string.Empty;
            tb_nom_tal.Text = string.Empty;
            tb_for_mat.Text = string.Empty;
            tb_nro_cop.Text = string.Empty;
            tb_nro_aut.Text = string.Empty;
            tb_fir_ma1.Text = string.Empty;
            tb_fir_ma2.Text = string.Empty;
            tb_fir_ma3.Text = string.Empty;
            tb_fir_ma4.Text = string.Empty;
            tb_tip_tal.Text = string.Empty;
            tb_for_log.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
            tb_obs_uno.Text = string.Empty;
            tb_obs_dos.Text = string.Empty;
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo ID. Documento NO este vacio
            if (tb_ide_doc.Text.Trim() == ""){
                tb_ide_doc.Focus();
                return "DEBE proporcionar el ID. Documento";
            }

            // Verifica SI el Módulo se encuentra registrado
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_con_doc(tb_ide_doc.Text);
            if (Tabla.Rows.Count == 0){
                tb_ide_doc.Focus();
                return "El Documento seleccionado NO se encuentra registrado";
            }            

            // Valida que el campo Nro. Talonario
            if (tb_nro_tal.Text.Trim() == ""){
                tb_nro_tal.Focus();
                return "DEBE proporcionar el Nro. Talonario";
            }

            // Valida que el campo código sea un valor válido
            if (!cl_glo_bal.IsNumeric(tb_nro_tal.Text.Trim())){
                tb_nro_tal.Focus();
                return "El Nro. Talonario NO es valido";
            }            

            // Verifica SI el Talonario se encuentra registrado
            Tabla = new DataTable();
            Tabla = o_ads004.Fe_con_tal(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text));
            if (Tabla.Rows.Count == 0){
                tb_nro_tal.Focus();
                return "El Talonario que desea modificar NO se encuentra registrado " + tb_ide_doc.Text + " : " + tb_nro_tal.Text;
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

                if (tb_est_ado.Text == "Habilitado")
                    msg_res = MessageBox.Show("Esta seguro de Deshabilitar el Talonario?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                else
                    msg_res = MessageBox.Show("Esta seguro de Habilitar el Talonario?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (msg_res == DialogResult.OK){
                    if (tb_est_ado.Text == "Habilitado") { 
                        // Deshabilita Registro
                        o_ads004.Fe_hab_des(tb_ide_doc.Text.Trim(), int.Parse(tb_nro_tal.Text.Trim()), "N");
                        // Graba Bitacora de Operaciones
                        o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "D", "Talonario: " + tb_ide_doc.Text.Trim() + " - " + tb_nro_tal.Text.Trim() + " - " + tb_nom_tal.Text.Trim(), SystemInformation.ComputerName);
                    }else {
                        // Habilita Registro
                        o_ads004.Fe_hab_des(tb_ide_doc.Text.Trim(), int.Parse(tb_nro_tal.Text.Trim()), "H");
                        // Graba Bitacora de Operaciones
                        o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "H", "Talonario: " + tb_ide_doc.Text.Trim() + " - " + tb_nro_tal.Text.Trim() + " - " + tb_nom_tal.Text.Trim(), SystemInformation.ComputerName);
                    }
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(tb_ide_doc.Text.Trim(), int.Parse(tb_nro_tal.Text.Trim()));
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
