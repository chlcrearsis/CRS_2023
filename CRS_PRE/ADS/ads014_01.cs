using System;
using System.Data;
using System.Drawing;
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
            // Inicializa Datos
            tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_usr"].ToString().Trim();
            lb_nom_usr.Text = frm_dat.Rows[0]["va_nom_usr"].ToString().Trim();
            // Desplega Claves Autorizadas
            Fe_des_cla();
        }

        /// <summary>
        /// Desplega Claves Autorizadas
        /// </summary>
        private void Fe_des_cla() {
            try
            {
                dg_res_ult.Rows.Clear();
                // Obtiene y Desplega Lista de Claves Autorizadas p/Usuario
                Tabla = new DataTable();
                Tabla = o_ads014.Fe_lis_cla(tb_ide_usr.Text);
                if (Tabla.Rows.Count > 0)
                {
                    for (int i = 0; i < Tabla.Rows.Count; i++)
                    {
                        dg_res_ult.Rows.Add();
                        dg_res_ult.Rows[i].Cells["va_ide_mod"].Value = Tabla.Rows[i]["va_ide_mod"].ToString().Trim();
                        dg_res_ult.Rows[i].Cells["va_ide_cla"].Value = Tabla.Rows[i]["va_ide_cla"].ToString().Trim();
                        dg_res_ult.Rows[i].Cells["va_mod_cla"].Value = "(" + Tabla.Rows[i]["va_ide_mod"].ToString().Trim() + " - " +
                                                                             Tabla.Rows[i]["va_ide_cla"].ToString().Trim() + ")";
                        dg_res_ult.Rows[i].Cells["va_nom_cla"].Value = Tabla.Rows[i]["va_nom_cla"].ToString().Trim();
                        dg_res_ult.Rows[i].Cells["va_per_mis"].Value = "...";
                        if (Tabla.Rows[i]["va_ban_cla"].ToString() == "S")
                            dg_res_ult.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                        else
                            dg_res_ult.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                    dg_res_ult.ClearSelection();
                }else if (gb_ctr_btn.Enabled == true){
                    bt_ace_pta.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        /// <summary>
        /// Funcion : Actualiza la ventana despues de realizar alguna operación
        /// </summary>
        public void Fe_act_frm()
        {
            // Desplega las Claves Autorizadas
            Fe_des_cla();
        }        

        // Evento CellContentClick: DataGridView
        private void dg_res_ult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                ads014_02 frm = new ads014_02
                {
                    vp_ide_usr = tb_ide_usr.Text,
                    vp_ide_mod = int.Parse(dg_res_ult.SelectedRows[0].Cells["va_ide_mod"].Value.ToString()),
                    vp_ide_cla = int.Parse(dg_res_ult.SelectedRows[0].Cells["va_ide_cla"].Value.ToString())
                };
                cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
            }

            dg_res_ult.ClearSelection();
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            if (bt_ace_pta.Enabled == true && dg_res_ult.Rows.Count > 0)
            {
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
