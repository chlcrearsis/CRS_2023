﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads008 - Permiso Usuario de Grupo de Usuario          */
    /* Descripción: Permiso sobre Aplicación                              */
    /*       Autor: JEJR - Crearsis             Fecha: 31-08-2023         */
    /**********************************************************************/
    public partial class ads008_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        ads008 o_ads008 = new ads008();
        DataTable Tabla = new DataTable();
        bool vp_chk_reg = true;

        public ads008_06()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Inicializa Datos
            tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_usr"].ToString().Trim();
            lb_nom_usr.Text = frm_dat.Rows[0]["va_nom_usr"].ToString().Trim();

            // Desplega Grupo de Persona
            Fi_des_gdp();
        }

        /// <summary>
        /// Desplega Lista de Grupo de Persona con y sin permisos
        /// </summary>
        private void Fi_des_gdp()
        {
            bool per_mis = true;
            dg_res_ult.Rows.Clear();
            // Obtiene y Desplega Lista de Grupo de Persona
            Tabla = new DataTable();
            Tabla = o_ads008.Fe_usr_gdp(tb_ide_usr.Text.Trim());
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_cod_gru"].Value = Tabla.Rows[i]["va_cod_gru"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_nom_gru"].Value = Tabla.Rows[i]["va_nom_gru"].ToString().Trim();
                    if (Tabla.Rows[i]["va_per_mis"].ToString() == "S")                    
                        dg_res_ult.Rows[i].Cells["va_per_mis"].Value = true;                    
                    else{
                        per_mis = false;
                        dg_res_ult.Rows[i].Cells["va_per_mis"].Value = false;
                    }
                }
            }else{
                bt_ace_pta.Enabled = false;
            }

            ch_che_tod.Focus();
            ch_che_tod.Checked = per_mis;
        }

        // Verifica si todos los registros estan Checkeado
        private void Fi_ver_chk()
        {
            vp_chk_reg = true;
            for (int i = 0; i < dg_res_ult.Rows.Count; i++){
                bool chk = (bool)dg_res_ult.Rows[i].Cells["va_per_mis"].Value;
                if (chk == false){
                    vp_chk_reg = false;
                    break;
                }
            }

            if (ch_che_tod.Checked != vp_chk_reg)
                ch_che_tod.Checked = vp_chk_reg;
            else
                vp_chk_reg = true;
        }

        // Evento CheckedChanged: Todos los permisos
        private void ch_che_tod_CheckedChanged(object sender, EventArgs e)
        {
            if (vp_chk_reg){
                for (int i = 0; i < dg_res_ult.RowCount; i++)
                    dg_res_ult.Rows[i].Cells["va_per_mis"].Value = ch_che_tod.Checked;
            }else
                vp_chk_reg = true;
        }

        // Evento CellContentClick: DataGridView
        private void dg_res_ult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value == null)
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = false;

                bool chk = (bool)dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value;

                if (chk == false)
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = true;
                else
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = false;

                Fi_ver_chk();
            }
        }

        // Evento PreviewKeyDown: DataGridView
        private void dg_res_ult_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space){
                if (dg_res_ult.SelectedRows[0].Cells["va_per_mis"].Value == null)
                    dg_res_ult.SelectedRows[0].Cells["va_per_mis"].Value = false;

                bool chk = (bool)dg_res_ult.SelectedRows[0].Cells["va_per_mis"].Value;

                if (chk == false)
                    dg_res_ult.SelectedRows[0].Cells["va_per_mis"].Value = true;
                else
                    dg_res_ult.SelectedRows[0].Cells["va_per_mis"].Value = false;

                Fi_ver_chk();
            }
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult msg_res;

                msg_res = MessageBox.Show("Está seguro de editar la informacion?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Elimina los permisos que tiene el Usuario
                    o_ads008.Fe_eli_min(tb_ide_usr.Text.Trim(), "adp001");
                    // Asigna los permisos que el usuario ha seleccionado
                    for (int i = 0; i < dg_res_ult.RowCount; i++)
                    {
                        bool chk_val = (bool)dg_res_ult.Rows[i].Cells["va_per_mis"].Value;
                        string cod_gru = dg_res_ult.Rows[i].Cells["va_cod_gru"].Value.ToString();

                        if (chk_val == true)
                            o_ads008.Fe_nue_reg(tb_ide_usr.Text.Trim(), "adp001", cod_gru);
                    }
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }    
    }
}
