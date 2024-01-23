using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads003 - Definición de Documento                      */
    /* Descripción: Buscar Registro de acuerdo al Módulo                  */
    /*       Autor: JEJR - Crearsis             Fecha: 19-08-2022         */
    /**********************************************************************/
    public partial class ads003_01b : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public dynamic frm_MDI;
        // Instancia
        ads001 o_ads001 = new ads001();
        ads003 o_ads003 = new ads003();
        DataTable Tabla = new DataTable();
        // Variables
        public int vp_ide_mod = 0;
        public string vp_ide_doc = "";

        public ads003_01b()
        {
            InitializeComponent();
        }        

        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }

        /// <summary>
        /// Inicializa Formulario
        /// </summary>
        private void fi_ini_frm()
        {
            // Obtiene el nombre del módulo a buscar
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(vp_ide_mod);
            if (Tabla.Rows.Count > 0)
                Text = "Documentos por Módulos : " + Tabla.Rows[0]["va_nom_mod"];
            else
                Text = "Documentos por Módulos : No Identificado";

            fi_bus_car(vp_ide_mod);
        }

        /// <summary>
        /// Función: Filtra Datos de acuerdo el criterio
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        private void fi_bus_car(int ide_mod)
        {
            // Limpia Grilla
            dg_res_ult.Rows.Clear();
           
            // Obtiene datos de la busqueda
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_con_mod(ide_mod, "H");
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_doc"].Value = Tabla.Rows[i]["va_ide_doc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_doc"].Value = Tabla.Rows[i]["va_nom_doc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_des_doc"].Value = Tabla.Rows[i]["va_des_doc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_mod"].Value = Tabla.Rows[i]["va_nom_mod"].ToString();
                }
                vp_ide_doc = Tabla.Rows[0]["va_ide_doc"].ToString();
            }else if (gb_ctr_btn.Enabled == true){
                bt_ace_pta.Enabled = false;
            }
        }

        /// <summary>
        /// Función: Obtiene fila actual seleccionada
        /// </summary>
        private void fi_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                if (dg_res_ult.SelectedRows[0].Cells[0].Value == null) {                 
                    vp_ide_doc = string.Empty;
                } else { 
                    vp_ide_doc = dg_res_ult.SelectedRows[0].Cells["va_ide_doc"].Value.ToString();                    
                }
            }
        }        

        // Evento KeyDown: Preciona Teclado
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
                            if (dg_res_ult.SelectedRows[0].Index != 0)
                            {
                                // Establece el foco en el Datagrid
                                dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index - 1];
                                // Llama a función que actualiza datos en Pantalla
                                fi_fil_act();
                            }
                            break;
                        case Keys.Down:   // Flecha Abajo
                            if (dg_res_ult.SelectedRows[0].Index != dg_res_ult.Rows.Count - 1)
                            {
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
                        case Keys.Escape: // Tecla Esc
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
