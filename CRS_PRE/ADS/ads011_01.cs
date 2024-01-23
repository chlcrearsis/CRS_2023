using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads011 - Definición de Claves                         */
    /* Descripción: Buscar Registro                                       */
    /*       Autor: JEJR - Crearsis             Fecha: 04-12-2023         */
    /**********************************************************************/
    public partial class ads011_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;
        // Instancia
        ads001 o_ads001 = new ads001();
        ads011 o_ads011 = new ads011();
        DataTable Tabla = new DataTable();
        // Variables
        public int vp_ide_mod = 0;  // TODOS LOS MÓDULOS

        public ads011_01()
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
            tb_ide_mod.Text = "0";
            tb_ide_cla.Text = "0";
            lb_nom_cla.Text = "...";
            lb_nom_mod.Text = "TODOS";
            // Obtiene el nombre del Módulo
            if (vp_ide_mod != 0){
                Tabla = new DataTable();
                Tabla = o_ads001.Fe_con_mod(vp_ide_mod);
                if (Tabla.Rows.Count > 0)
                    lb_nom_mod.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
            }
            // Inicializa los paramatros de busqueda
            cb_prm_bus.SelectedIndex = 0;
            fi_bus_car("", cb_prm_bus.SelectedIndex, vp_ide_mod);
        }

        /// <summary>
        /// Función: Filtra Datos de acuerdo el criterio
        /// </summary>
        /// <param name="tex_bus">Texto a buscar</param>
        /// <param name="prm_bus">Parametro a buscar</param>
        /// <param name="ide_mod">ID. Módulo</param>
        private void fi_bus_car(string tex_bus = "", int prm_bus = 0, int ide_mod = 0)
        {
            // Limpia Grilla
            dg_res_ult.Rows.Clear();            

            // Obtiene datos de la busqueda
            Tabla = new DataTable();
            Tabla = o_ads011.Fe_bus_car(tex_bus, prm_bus, ide_mod);
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_mod"].Value = Tabla.Rows[i]["va_ide_mod"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_nom_mod"].Value = Tabla.Rows[i]["va_nom_mod"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_ide_cla"].Value = Tabla.Rows[i]["va_ide_cla"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_nom_cla"].Value = Tabla.Rows[i]["va_nom_cla"].ToString().Trim();
                    /* Castea el Tipo de Caracter */
                    if (Tabla.Rows[i]["va_cla_req"].ToString() == "S")
                        dg_res_ult.Rows[i].Cells["va_cla_req"].Value = "Si";
                    else
                        dg_res_ult.Rows[i].Cells["va_cla_req"].Value = "No";           
                }
                tb_ide_mod.Text = Tabla.Rows[0]["va_ide_mod"].ToString().Trim();
                tb_ide_cla.Text = Tabla.Rows[0]["va_ide_cla"].ToString().Trim();
                lb_nom_cla.Text = Tabla.Rows[0]["va_nom_cla"].ToString().Trim();
            }else if (gb_ctr_btn.Enabled == true){
                bt_ace_pta.Enabled = false;
            }
            tb_tex_bus.Focus();
        }

        /// <summary>
        /// Función: Obtiene fila actual seleccionada
        /// </summary>
        private void fi_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                if (dg_res_ult.SelectedRows[0].Cells[0].Value == null){
                    tb_ide_mod.Text = string.Empty;
                    tb_ide_cla.Text = string.Empty;
                    lb_nom_cla.Text = string.Empty;
                }else{
                    tb_ide_mod.Text = dg_res_ult.SelectedRows[0].Cells["va_ide_mod"].Value.ToString();
                    tb_ide_cla.Text = dg_res_ult.SelectedRows[0].Cells["va_ide_cla"].Value.ToString();
                    lb_nom_cla.Text = dg_res_ult.SelectedRows[0].Cells["va_nom_cla"].Value.ToString();
                }
            }
        }

        /// <summary>
        /// Función: Consulta registro seleccionado
        /// </summary>
        private void fi_con_sel()
        {
            // Verifica que los datos en pantallas sean correctos
            if (tb_ide_mod.Text.Trim() == "")
            {
                lb_nom_cla.Text = "NO existe";
                return;
            }
            if (tb_ide_cla.Text.Trim() == "")
            {
                lb_nom_cla.Text = "NO existe";
                return;
            }

            // Valida que el campo código sea un valor válido
            if (!cl_glo_bal.IsNumeric(tb_ide_mod.Text.Trim()))
            {
                lb_nom_cla.Text = "NO existe";
                return;
            }
            if (!cl_glo_bal.IsNumeric(tb_ide_cla.Text.Trim()))
            {
                lb_nom_cla.Text = "NO existe";
                return;
            }

            // Verifica si la Global está registrado en el sistema
            Tabla = new DataTable();
            Tabla = o_ads011.Fe_con_cla(int.Parse(tb_ide_mod.Text), int.Parse(tb_ide_cla.Text));
            if (Tabla.Rows.Count == 0)
            {
                lb_nom_cla.Text = "NO existe";
                return;
            }

            lb_nom_cla.Text = Tabla.Rows[0]["va_nom_cla"].ToString();
        }

        /// <summary>
        /// Función: Selecciona la fila en el Datagrid del registro modificado
        /// </summary>
        private void fi_sel_fil(string ide_mod, string ide_cla)
        {
            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, vp_ide_mod);

            if (ide_mod != null && ide_cla != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells["va_ide_mod"].Value.ToString() == ide_mod &&
                            dg_res_ult.Rows[i].Cells["va_ide_cla"].Value.ToString() == ide_cla)
                        {
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
        private bool fi_ver_dat(int ide_mod, int ide_glo)
        {
            string res_fun;
            if (ide_mod == 0 && ide_glo == 0)
            {
                res_fun = "La Global que desea editar, no se encuentra registrado";
                MessageBox.Show(res_fun, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_ide_mod.Focus();
                return false;
            }

            // Obtiene datos del registro seleccionado
            tab_dat = new DataTable();
            tab_dat = o_ads011.Fe_con_cla(ide_mod, ide_glo);
            if (tab_dat.Rows.Count == 0)
            {
                res_fun = "La Global que desea editar, no se encuentra registrada";
                MessageBox.Show(res_fun, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_ide_mod.Focus();
                return false;
            }

            return true;
        }        

        /// <summary>
        /// Función: Actualiza la ventana despues de realizar alguna operación
        /// </summary>
        public void Fe_act_frm(string ide_mod, string ide_cla)
        {
            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, vp_ide_mod);

            if (ide_mod != null && ide_cla != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells["va_ide_mod"].Value.ToString() == ide_mod &&
                            dg_res_ult.Rows[i].Cells["va_ide_cla"].Value.ToString() == ide_cla)
                        {
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex = i;
                            return;
                        }
                    }
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
                            if (bt_ace_pta.Enabled == true && dg_res_ult.Rows.Count > 0)
                            {
                                DialogResult = DialogResult.OK;
                                cl_glo_frm.Cerrar(this);
                            }
                            break;
                        case Keys.Escape: // Tecla Esc
                            if (bt_ace_pta.Enabled == true)
                            {
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

        // Evento KeyPress: ID. Módulo
        private void tb_ide_mod_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyPress: ID. Clave
        private void tb_ide_cla_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento Validated: ID. Módulo
        private void tb_ide_mod_Validated(object sender, EventArgs e)
        {
            fi_con_sel();
            if (lb_nom_cla.Text != "NO Existe")            
                fi_sel_fil(tb_ide_mod.Text, tb_ide_cla.Text);            
        }

        // Evento Validated: ID. Clave
        private void tb_ide_cla_Validated(object sender, EventArgs e)
        {
            fi_con_sel();
            if (lb_nom_cla.Text != "NO Existe")
                fi_sel_fil(tb_ide_mod.Text, tb_ide_cla.Text);
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
            if (bt_ace_pta.Enabled == true && dg_res_ult.Rows.Count > 0)
            {
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

        // Evento Click: Buscar Datos
        private void bt_bus_car_Click(object sender, EventArgs e)
        {
            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, vp_ide_mod);
        }

        // Evento Click: Nueva Clave
        private void mn_nue_cla_Click(object sender, EventArgs e)
        {
            ads011_02 frm = new ads011_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        // Evento Click: Registra Clave p/Defecto
        private void mn_reg_cla_Click(object sender, EventArgs e)
        {
            ads011_02b frm = new ads011_02b();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        // Evento Click: Modifica Registro
        private void mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para modificar
            if (fi_ver_dat(int.Parse(tb_ide_mod.Text), int.Parse(tb_ide_cla.Text)) == false)
                return;

            ads011_03 frm = new ads011_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Consulta Registro
        private void mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(int.Parse(tb_ide_mod.Text), int.Parse(tb_ide_cla.Text)) == false)
                return;

            ads011_05 frm = new ads011_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Elimina Registro
        private void mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para eliminar
            if (fi_ver_dat(int.Parse(tb_ide_mod.Text), int.Parse(tb_ide_cla.Text)) == false)
                return;

            ads011_06 frm = new ads011_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Lista Definición de Claves
        private void mn_lis_cla_Click(object sender, EventArgs e)
        {
            ads011_R01p frm = new ads011_R01p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        // Evento Click: Cerrar Pantalla
        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        // Evento Click: Cambia Módulo
        private void bt_cam_mod_Click(object sender, EventArgs e)
        {
            ads001_01 frm = new ads001_01();
            frm.AccessibleName = "1";
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                vp_ide_mod = int.Parse(frm.tb_ide_mod.Text);

                /* Desplega el nombre del modulo seleccionado */
                if (vp_ide_mod > 0){
                    Tabla = new DataTable();
                    Tabla = o_ads001.Fe_con_mod(vp_ide_mod);
                    if (Tabla.Rows.Count > 0)
                        lb_nom_mod.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
                }else                
                    lb_nom_mod.Text = "TODOS";                

                fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, vp_ide_mod);
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
