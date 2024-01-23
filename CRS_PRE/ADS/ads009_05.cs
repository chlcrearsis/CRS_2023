﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;
using CRS_PRE.INV;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads008 - Permiso Tipo Usuario Bodega                  */
    /* Descripción: Permiso sobre Aplicación                              */
    /*       Autor: JEJR - Crearsis             Fecha: 31-08-2023         */
    /**********************************************************************/
    public partial class ads009_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        // Instancias
        ads009 o_ads009 = new ads009();
        inv001 o_inv001 = new inv001();
        bool vp_chk_reg = true;

        // Variables
        DataTable Tabla = new DataTable();
        public int vp_ide_gru = 0;  // TODOS LOS GRUPOS DE BODEGA 

        public ads009_05()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {            
            // Despliega Información
            tb_ide_tus.Text = frm_dat.Rows[0]["va_ide_tus"].ToString();
            lb_nom_tus.Text = frm_dat.Rows[0]["va_nom_tus"].ToString();
            lb_nom_gru.Text = "TODOS";
            // Obtiene el nombre del Módulo
            if (vp_ide_gru != 0){
                Tabla = new DataTable();
                Tabla = o_inv001.Fe_con_gru(vp_ide_gru);
                if (Tabla.Rows.Count > 0)
                    lb_nom_gru.Text = Tabla.Rows[0]["va_nom_gru"].ToString();
            }
            // Despliega Lista de Bodega
            Fi_des_bod();
        }

        /// <summary>
        /// Desplega Lista de Bodegas con y sin permisos
        /// </summary>
        private void Fi_des_bod() {
            bool per_mis = true;
            dg_res_ult.Rows.Clear();
            // Obtiene Lista de Bodegas
            Tabla = new DataTable();
            Tabla = o_ads009.Fe_tus_bod(int.Parse(tb_ide_tus.Text.Trim()), vp_ide_gru);
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_cod_bod"].Value = Tabla.Rows[i]["va_cod_bod"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_nom_bod"].Value = Tabla.Rows[i]["va_nom_bod"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_ide_gru"].Value = Tabla.Rows[i]["va_ide_gru"].ToString().Trim();
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

        /// <summary>
        /// Valida los datos Proporcionado
        /// </summary>
        /// <returns></returns>
        protected string Fi_val_dat()
        {
            // Asigna los permisos que el usuario ha seleccionado
            for (int i = 0; i < dg_res_ult.RowCount; i++)
            {
                // Obtiene el ID. Grupo Bodega
                string ide_gru = dg_res_ult.Rows[i].Cells["va_ide_gru"].Value.ToString();
                string nom_gru = dg_res_ult.Rows[i].Cells["va_nom_gru"].Value.ToString();
                  bool chk_val = (bool) dg_res_ult.Rows[i].Cells["va_per_mis"].Value;
                // Verifica si tiene permiso sobre el Grupo Bodega
                bool res_per = o_ads009.Fe_aut_tus(int.Parse(tb_ide_tus.Text.Trim()), "inv001", ide_gru);
                if (!res_per && chk_val)
                {
                    return "El Tipo de Usuario NO tiene permiso sobre el Grupo Bodega (" + ide_gru + " - " + nom_gru + ")";
                }
            }

            return "OK";
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
            if (e.ColumnIndex == 4)
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

        // Evento Click: Cambia Módulo
        private void bt_cam_gru_Click(object sender, EventArgs e)
        {
            inv001_01 frm = new inv001_01();
            frm.AccessibleName = "1";
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                vp_ide_gru = int.Parse(frm.tb_sel_bus.Text);

                /* Desplega el nombre del modulo seleccionado */
                Tabla = new DataTable();
                Tabla = o_inv001.Fe_con_gru(vp_ide_gru);
                if (Tabla.Rows.Count > 0)
                    lb_nom_gru.Text = Tabla.Rows[0]["va_nom_gru"].ToString();
                else
                    lb_nom_gru.Text = "TODOS";

                // Despliega Lista de Bodega
                Fi_des_bod();
            }
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;
            try
            {                
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "OK"){
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }

                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Elimina los permisos que tiene el Usuario
                    o_ads009.Fe_eli_min(int.Parse(tb_ide_tus.Text.Trim()), "inv002");
                    // Asigna los permisos que el usuario ha seleccionado
                    for (int i = 0; i < dg_res_ult.RowCount; i++)
                    {
                        bool chk_val = (bool)dg_res_ult.Rows[i].Cells["va_per_mis"].Value;
                        string cod_bod = dg_res_ult.Rows[i].Cells["va_cod_bod"].Value.ToString().Trim();

                        if (chk_val == true)
                            o_ads009.Fe_nue_reg(int.Parse(tb_ide_tus.Text.Trim()), "inv002", cod_bod);
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
