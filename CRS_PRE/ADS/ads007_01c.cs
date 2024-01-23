using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads007 - Usuario                                      */
    /* Descripción: Selecciona Usuario para Validacion                    */
    /*       Autor: JEJR - Crearsis             Fecha: 15-01-2024         */
    /**********************************************************************/
    public partial class ads007_01c : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        public dynamic frm_MDI;
        // Instancia
        ads007 o_ads007 = new ads007();
        DataTable Tabla = new DataTable();
        // Variables        
        public int vp_ide_mod = 0;  // ID. Módulo
        public int vp_ide_cla = 0;  // ID. Clave
        public string vp_ide_usr = "";  // ID. Usuario

        public ads007_01c()
        {
            InitializeComponent();
        }
        
        private void frm_Load(object sender, EventArgs e)
        {
            // Desplega Lista
            fi_des_lis();
        }              

        /// <summary>
        /// Función: Desplega Lista de Usuario
        /// </summary>
        private void fi_des_lis()
        {
            // Limpia Grilla
            dg_res_ult.Rows.Clear();
            // Obtiene datos de la busqueda
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_usr_cla(vp_ide_mod, vp_ide_cla);
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_usr"].Value = Tabla.Rows[i]["va_ide_usr"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_usr"].Value = Tabla.Rows[i]["va_nom_usr"].ToString();
                    dg_res_ult.Rows[i].Cells["va_car_usr"].Value = Tabla.Rows[i]["va_car_usr"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_tus"].Value = Tabla.Rows[i]["va_nom_tus"].ToString();
                }
                vp_ide_usr = Tabla.Rows[0]["va_ide_usr"].ToString();
            }
            else if (gb_ctr_btn.Enabled == true){
                bt_ace_pta.Enabled = false;
            }
            tb_tex_bus.Focus();
        }

        /// <summary>
        /// Función: Obtiene fila actual seleccionada
        /// </summary>
        public void fi_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0){
                if (dg_res_ult.SelectedRows[0].Cells[0].Value == null)
                    vp_ide_usr = string.Empty;
                else
                    vp_ide_usr = dg_res_ult.SelectedRows[0].Cells["va_ide_usr"].Value.ToString();
            }
        }

        // Evento KeyDown: Preciona Tecla
        private void fi_pre_tec_KeyDown(object sender, KeyEventArgs e)
        {
            if (dg_res_ult.Rows.Count != 0)
            {
                try
                {
                    dg_res_ult.Show();
                    /* Verifica que tecla preciono */
                    switch (e.KeyData)
                    {
                        case Keys.Up:     // Flecha Arriba
                            if (dg_res_ult.SelectedRows[0].Index != 0){
                                // Establece el foco en el Datagrid
                                dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index - 1];
                                // Llama a función que actualiza datos en Pantalla
                                fi_fil_act();
                            }
                            break;
                        case Keys.Down:   // Flecha Abajo
                            if (dg_res_ult.SelectedRows[0].Index != dg_res_ult.Rows.Count - 1){
                                // Establece el foco en el Datagrid
                                dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index + 1];
                                // Llama a función que actualiza datos en Pantalla
                                fi_fil_act();
                            }
                            break;
                        case Keys.Enter:  // Tecla Enter
                            if (bt_ace_pta.Enabled == true && dg_res_ult.Rows.Count > 0){
                                DialogResult = DialogResult.OK;
                                cl_glo_frm.Cerrar(this);
                            }
                            break;
                        case Keys.Escape: // Tecla Escape
                            if (bt_ace_pta.Enabled == true){
                                DialogResult = DialogResult.Cancel;
                                cl_glo_frm.Cerrar(this);
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        // Evento SelectionChanged: DataGridView
        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fi_fil_act();
        }

        // Evento CellClick: DataGridView
        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fi_fil_act();
        }

        // Evento CellDoubleClick: DataGridView
        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bt_ace_pta.Enabled == true && dg_res_ult.Rows.Count > 0){
                DialogResult = DialogResult.OK;
                cl_glo_frm.Cerrar(this);
            }
        }

        // Evento PreviewKeyDown: DataGridView
        private void dg_res_ult_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter){
                if (bt_ace_pta.Enabled == true && dg_res_ult.Rows.Count > 0){
                    DialogResult = DialogResult.OK;
                    cl_glo_frm.Cerrar(this);
                    Dispose();
                }                
            }            
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            if (bt_ace_pta.Enabled == true && dg_res_ult.Rows.Count > 0){
                DialogResult = DialogResult.OK;
                cl_glo_frm.Cerrar(this);
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            cl_glo_frm.Cerrar(this);
        }               
    }
}
