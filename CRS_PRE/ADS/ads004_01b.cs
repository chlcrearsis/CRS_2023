using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads004 - Talonario                                    */
    /* Descripción: Buscar Talonarios Autorizados al Usuario p/Documento  */
    /*       Autor: JEJR - Crearsis             Fecha: 31-08-2022         */
    /**********************************************************************/
    public partial class ads004_01b : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        public dynamic frm_MDI;
        // Instancia
        ads003 o_ads003 = new ads003();
        ads004 o_ads004 = new ads004();
        DataTable Tabla = new DataTable();
        // Variables        
        public string vp_ide_doc;        
        public string vp_nom_doc;
        public string vp_nom_tal;
        public string vp_ide_mod;
        public string vp_nro_tal;

        public ads004_01b()
        {
            InitializeComponent();
        }
        
        private void frm_Load(object sender, EventArgs e)
        {
            vp_ide_doc = frm_dat.Rows[0]["va_ide_doc"].ToString();
            vp_nom_doc = frm_dat.Rows[0]["va_nom_doc"].ToString();    
            fi_ini_frm();
        }

        /// <summary>
        /// Inicializa Formulario
        /// </summary>
        private void fi_ini_frm()
        {
            // Obtiene el ID. Módulo que pertenece el ID. Documento
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_con_doc(vp_ide_doc);
            if (Tabla.Rows.Count > 0){
                vp_ide_mod = Tabla.Rows[0]["va_ide_mod"].ToString();
                vp_nom_doc = Tabla.Rows[0]["va_nom_doc"].ToString();
            }else {
                vp_ide_mod = string.Empty;
                vp_nom_doc = string.Empty;
            }

            // Despliega el Titulo de la Venta
            Text = "Documento " + vp_ide_doc.ToUpper() + " : " + vp_nom_doc.ToUpper();            
            fi_bus_car();
        }


        /// <summary>
        /// Función: Filtra Datos de acuerdo el criterio
        /// </summary>
        private void fi_bus_car()
        {
            // Limpia Grilla
            dg_res_ult.Rows.Clear();
            // Obtiene datos de la busqueda
            Tabla = new DataTable();
            Tabla = o_ads004.Fe_tal_usr(Program.gl_ide_usr, vp_ide_doc, "H");
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_doc"].Value = Tabla.Rows[i]["va_ide_doc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_doc"].Value = Tabla.Rows[i]["va_nom_doc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nro_tal"].Value = Tabla.Rows[i]["va_nro_tal"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_tal"].Value = Tabla.Rows[i]["va_nom_tal"].ToString();
                    if (Tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                }
                vp_ide_doc = Tabla.Rows[0]["va_ide_doc"].ToString();
                vp_nom_doc = Tabla.Rows[0]["va_nom_doc"].ToString();
                vp_nom_tal = Tabla.Rows[0]["va_nom_tal"].ToString();
                vp_nro_tal = Tabla.Rows[0]["va_nro_tal"].ToString();
            }else if (gb_ctr_btn.Enabled == true){
                bt_ace_pta.Enabled = false;
            }
        }

        /// <summary>
        /// Función: Selecciona la fila en el Datagrid del registro modificado
        /// </summary>
        public void fi_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                if (dg_res_ult.SelectedRows[0].Cells[0].Value == null){
                    vp_ide_doc = string.Empty;
                    vp_nro_tal = string.Empty;
                    vp_nom_tal = string.Empty;
                }else{
                    vp_ide_doc = dg_res_ult.SelectedRows[0].Cells["va_ide_doc"].Value.ToString();
                    vp_nro_tal = dg_res_ult.SelectedRows[0].Cells["va_nro_tal"].Value.ToString();
                    vp_nom_tal = dg_res_ult.SelectedRows[0].Cells["va_nom_tal"].Value.ToString();
                }
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

        // Evento Enter: DataGridView
        private void dg_res_ult_Enter(object sender, EventArgs e)
        {
            if (bt_ace_pta.Enabled == true && dg_res_ult.Rows.Count > 0){
                DialogResult = DialogResult.OK;
                cl_glo_frm.Cerrar(this);
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
