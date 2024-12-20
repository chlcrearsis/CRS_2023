﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads003 - Definición de Documento                      */
    /*      Opción: Edita Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 22-08-2022         */
    /**********************************************************************/
    public partial class ads003_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads001 o_ads001 = new ads001();
        ads003 o_ads003 = new ads003();
        ads019 o_ads019 = new ads019();
        DataTable Tabla = new DataTable();

        public ads003_03()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_ide_mod.Text = frm_dat.Rows[0]["va_ide_mod"].ToString();
            tb_nom_mod.Text = frm_dat.Rows[0]["va_nom_mod"].ToString();
            tb_ide_doc.Text = frm_dat.Rows[0]["va_ide_doc"].ToString();
            tb_nom_doc.Text = frm_dat.Rows[0]["va_nom_doc"].ToString();
            tb_des_doc.Text = frm_dat.Rows[0]["va_des_doc"].ToString();            
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_mod.Text = string.Empty;
            tb_nom_mod.Text = string.Empty;
            tb_ide_doc.Text = string.Empty;
            tb_nom_doc.Text = string.Empty;
            tb_des_doc.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
            tb_nom_doc.Focus();
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo código NO este vacio
            if (tb_ide_mod.Text.Trim() == "")
                return "DEBE proporcionar el Código del Módulo";

            // Valida que el campo código NO este vacio
            if (!cl_glo_bal.IsNumeric(tb_ide_mod.Text.Trim()))
                return "El Código del Módulo NO es válido";

            // Verifica SI el Módulo se encuentra registrado
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(int.Parse(tb_ide_mod.Text));
            if (Tabla.Rows.Count == 0)
                return "El Módulo NO se encuentra registrado";

            // Verifica SI el documento se encuentra registrado
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_con_doc(int.Parse(tb_ide_mod.Text), tb_ide_doc.Text);
            if (Tabla.Rows.Count == 0)
                return "El Documento NO se encuentra registrado";

            // Verifica SI la Aplicacion se encuentra habilitada
            if (tb_est_ado.Text.Trim() == "Deshabilitado")
                return "El Documento se encuentra deshabilitada";

            // Verifica SI existe otro registro con el mismo Nombre de Documento
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_con_nom(tb_nom_doc.Text, tb_ide_doc.Text);
            if (Tabla.Rows.Count > 0)
                return "Ya existe otro Documento con el mismo Nombre";

            // Quita caracteres especiales de SQL-Trans
            tb_ide_doc.Text = tb_ide_doc.Text.ToString().Replace("'", "");
            tb_nom_doc.Text = tb_nom_doc.Text.ToString().Replace("'", "");
            tb_des_doc.Text = tb_des_doc.Text.ToString().Replace("'", "");

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
                    o_ads003.Fe_edi_tar(int.Parse(tb_ide_mod.Text), tb_ide_doc.Text.Trim(), tb_nom_doc.Text.Trim(), tb_des_doc.Text.Trim());
                    // Graba Bitacora de Operaciones
                    o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "E", "Documento: " + tb_ide_doc.Text.Trim() + " - " + tb_nom_doc.Text.Trim(), SystemInformation.ComputerName);
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(tb_ide_doc.Text.Trim());
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
