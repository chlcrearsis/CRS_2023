using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads015 - Regional                                     */
    /* Descripción: Buscar Regional                                       */
    /*       Autor: JEJR - Crearsis             Fecha: 16-12-2023         */
    /**********************************************************************/
    public partial class ads015_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;
        // Instancia
        ads015 o_ads015 = new ads015();
        DataTable Tabla = new DataTable();
        // Variables
        string est_bus = "H";   // Estado (H=Habilitado; N=Deshabilitado)

        public ads015_01()
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
            tb_ide_reg.Text = "";
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;
            fi_bus_car("", cb_prm_bus.SelectedIndex, est_bus);
        }

        /// <summary>
        /// Metodo : Filtra Datos de acuerdo el criterio
        /// </summary>
        /// <param name="tex_bus">Texto a buscar</param>
        /// <param name="prm_bus">Parametro a buscar</param>
        /// <param name="est_bus">Estado a buscar</param>
        private void fi_bus_car(string tex_bus = "", int prm_bus = 0, string est_bus = "T")
        {
            // Limpia Grilla
            dg_res_ult.Rows.Clear();
            // Obtiene el estado de la busqueda
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            // Obtiene datos de la busqueda
            Tabla = new DataTable();
            Tabla = o_ads015.Fe_bus_car(tex_bus, prm_bus, est_bus);
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_reg"].Value = Tabla.Rows[i]["va_ide_reg"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_reg"].Value = Tabla.Rows[i]["va_nom_reg"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_cor"].Value = Tabla.Rows[i]["va_nom_cor"].ToString();
                    if (Tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                }
                tb_ide_reg.Text = Tabla.Rows[0]["va_ide_reg"].ToString();
                lb_nom_reg.Text = Tabla.Rows[0]["va_nom_reg"].ToString();
            }
            tb_tex_bus.Focus();
        }

        /// <summary>
        /// Método : Obtiene fila actual seleccionada
        /// </summary>
        public void fi_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                if (dg_res_ult.SelectedRows[0].Cells[0].Value == null){
                    tb_ide_reg.Text = string.Empty;
                    lb_nom_reg.Text = string.Empty;
                }else{
                    tb_ide_reg.Text = dg_res_ult.SelectedRows[0].Cells["va_ide_reg"].Value.ToString();
                    lb_nom_reg.Text = dg_res_ult.SelectedRows[0].Cells["va_nom_reg"].Value.ToString();
                }
            }
        }

        /// <summary>
        /// Función: Consulta registro seleccionado
        /// </summary>
        private void fi_con_sel()
        {
            // Verifica que los datos en pantallas sean correctos
            if (tb_ide_reg.Text.Trim() == ""){
                lb_nom_reg.Text = "NO Existe";
                return;
            }
            // Verifica si la regional está registrado en el sistema
            Tabla = new DataTable();
            Tabla = o_ads015.Fe_con_reg(int.Parse(tb_ide_reg.Text));
            if (Tabla.Rows.Count == 0){
                lb_nom_reg.Text = "NO Existe";
                return;
            }
            lb_nom_reg.Text = Tabla.Rows[0]["va_nom_reg"].ToString();
        }

        /// <summary>
        /// Función: Selecciona la fila en el Datagrid del registro que se modifico
        /// </summary>
        private void fi_sel_fil(string ide_reg)
        {
            // Obtiene el estado de la búsqueda
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);

            if (ide_reg != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells["va_ide_reg"].Value.ToString().ToUpper() == ide_reg.ToString().ToUpper()){
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex = i;
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// Función: Verificar concurrencia de datos para editar
        /// </summary>
        public bool fi_ver_dat(string ide_reg)
        {
            string res_fun;
            if (ide_reg.Trim() == "")
            {
                res_fun = "La Regional que desea editar, NO se encuentra registrado";
                MessageBox.Show(res_fun, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_ide_reg.Focus();
                return false;
            }

            // Obtiene datos del registro seleccionado
            tab_dat = new DataTable();
            tab_dat = o_ads015.Fe_con_reg(int.Parse(ide_reg));
            if (Tabla.Rows.Count == 0)
            {
                res_fun = "La Regional que desea editar, NO se encuentra registrado";
                MessageBox.Show(res_fun, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_ide_reg.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Funcion : Actualiza la ventana despues de realizar alguna operación
        /// </summary>
        public void Fe_act_frm(int ide_reg)
        {
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);

            if (ide_reg.ToString() != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells["va_ide_reg"].Value.ToString() == ide_reg.ToString())
                        {
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex = i;
                            return;
                        }
                    }
                    tb_tex_bus.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
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
                    switch (e.KeyData) {
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

        // Evento Validated: ID. Regional                      
        private void tb_ide_reg_Validated(object sender, EventArgs e)
        {
            fi_con_sel();
            if (lb_nom_reg.Text != "NO Existe")
                fi_sel_fil(tb_ide_reg.Text);            
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

        // Evento Click: Button Buscar
        private void bt_bus_car_Click(object sender, EventArgs e)
        {
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);
        }

        // Evento Click: Nuevo Registro
        private void mn_nue_reg_Click(object sender, EventArgs e)
        {
            ads015_02 frm = new ads015_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        // Evento Click: Modifica Registro
        private void mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para modificar
            if (fi_ver_dat(tb_ide_reg.Text) == false)
                return;

            ads015_03 frm = new ads015_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Habilita/Deshabilita
        private void mn_hab_des_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para habilitar/deshabilitar
            if (fi_ver_dat(tb_ide_reg.Text) == false)
                return;

            ads015_04 frm = new ads015_04();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Consulta Registro
        private void mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(tb_ide_reg.Text) == false)
                return;

            ads015_05 frm = new ads015_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Elimina Registro
        private void mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para eliminar
            if (fi_ver_dat(tb_ide_reg.Text) == false)
                return;

            ads015_06 frm = new ads015_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Lista Regionales
        private void mn_lis_reg_Click(object sender, EventArgs e)
        {
            ads015_R01p frm = new ads015_R01p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        // Evento Click: Salir
        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            cl_glo_frm.Cerrar(this);
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            cl_glo_frm.Cerrar(this);
        }
    }
}
