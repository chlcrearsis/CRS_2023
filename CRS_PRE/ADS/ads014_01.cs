using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads014 - Clave Usuario p/Global                       */
    /* Descripción: Permiso sobre Aplicación                              */
    /*       Autor: JEJR - Crearsis             Fecha: 20-10-2023         */
    /**********************************************************************/
    public partial class ads014_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        // Instancias
        ads014 o_ads014 = new ads014();
        DataTable Tabla = new DataTable();        

        public ads014_01()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            bool per_mis = true;
            // Inicializa Datos
            tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_usr"].ToString().Trim();
            lb_nom_usr.Text = frm_dat.Rows[0]["va_nom_usr"].ToString().Trim();            

            // Obtiene y Desplega Lista de Aplicaciones
            Tabla = new DataTable();
            Tabla = o_ads014.Fe_cla_usr(tb_ide_usr.Text);
            for (int i = 0; i < Tabla.Rows.Count ; i++)
            {
                dg_res_ult.Rows.Add();
                dg_res_ult.Rows[i].Cells["va_nem_mod"].Value = Tabla.Rows[i]["va_nem_mod"].ToString().Trim();
                dg_res_ult.Rows[i].Cells["va_ide_mod"].Value = Tabla.Rows[i]["va_ide_mod"].ToString().Trim();
                dg_res_ult.Rows[i].Cells["va_ide_glo"].Value = Tabla.Rows[i]["va_ide_glo"].ToString().Trim();
                dg_res_ult.Rows[i].Cells["va_des_glo"].Value = Tabla.Rows[i]["va_des_glo"].ToString().Trim();
                
                if (Tabla.Rows[i]["va_ban_cla"].ToString() == "S") { 
                   //
                } else {
                   //
                }
            }
        }        

        // Evento CellContentClick: Lista de Resultado
        private void dg_res_ult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value == null)
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = false;

                bool chk = (bool)dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value;

                if (chk == false)
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = true;
                else
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = false;

                //Fi_ver_chk();
            }            
        }

        // Evento CheckedChanged: Todos los permisos
        private void ch_che_tod_CheckedChanged(object sender, EventArgs e)
        {
            //if (vp_chk_reg){
            //    for (int i = 0; i < dg_res_ult.RowCount; i++) { 
            //        dg_res_ult.Rows[i].Cells["va_per_mis"].Value = ch_che_tod.Checked;
            //    }
            //}else {
            //    vp_chk_reg = true;
            //}
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult msg_res;

                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Elimina los permisos que tiene el Usuario
                    //o_ads008.Fe_eli_min(tb_ide_usr.Text.Trim(), "ads002");
                    // Asigna los permisos que el usuario ha seleccionado
                    for (int i = 0; i < dg_res_ult.RowCount; i++)
                    {
                        bool chk_val = (bool)dg_res_ult.Rows[i].Cells["va_per_mis"].Value;
                        string ide_apl = dg_res_ult.Rows[i].Cells["va_ide_apl"].Value.ToString();

                        if (chk_val == true) {
                            //o_ads008.Fe_nue_reg(tb_ide_usr.Text.Trim(), "ads002", ide_apl);
                        }
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
