﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads007 - Usuario                                      */
    /* Descripción: Buscar Registro                                       */
    /*       Autor: JEJR - Crearsis             Fecha: 26-07-2023         */
    /**********************************************************************/
    public partial class ads007_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;
        // Instancia
        adp002 o_adp002 = new adp002();
        ads006 o_ads006 = new ads006();
        ads007 o_ads007 = new ads007();
        DataTable Tabla = new DataTable();
        // Variables
        string est_bus = "H";
        public int vp_ide_tus = 0;  // TODOS LOS TIPOS DE USUARIO

        public ads007_01()
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
            tb_ide_usr.Text = "";
            lb_nom_usr.Text = "...";
            lb_nom_tus.Text = "TODOS";
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;
            // Obtiene el nombre del Tipo de Usuario
            if (vp_ide_tus != 0){
                Tabla = new DataTable();
                Tabla = o_ads006.Fe_con_tus(vp_ide_tus);
                if (Tabla.Rows.Count > 0)
                    lb_nom_tus.Text = Tabla.Rows[0]["va_nom_tus"].ToString();
            }
            // Busca registro de acuerdo al filtro
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;
            fi_bus_car("", cb_prm_bus.SelectedIndex);
        }

        /// <summary>
        /// Función: Filtra Datos de acuerdo el criterio
        /// </summary>
        /// <param name="tex_bus">Texto a buscar</param>
        /// <param name="cri_bus">Criterio de Busqueda (0=ID. Usuario; 1=Nombre Usuario; 2=Cargo)</param>
        /// <param name="est_bus">Estado a buscar</param>
        private void fi_bus_car(string tex_bus = "", int cri_bus = 0, string est_bus = "T")
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
            Tabla = o_ads007.Fe_bus_usu(tex_bus, cri_bus, est_bus, vp_ide_tus);            
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_usr"].Value = Tabla.Rows[i]["va_ide_usr"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_usr"].Value = Tabla.Rows[i]["va_nom_usr"].ToString();
                    dg_res_ult.Rows[i].Cells["va_car_usr"].Value = Tabla.Rows[i]["va_car_usr"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_tus"].Value = Tabla.Rows[i]["va_nom_tus"].ToString();
                    if (Tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                }
                tb_ide_usr.Text = Tabla.Rows[0]["va_ide_usr"].ToString();
                lb_nom_usr.Text = Tabla.Rows[0]["va_nom_usr"].ToString();
            }else if (gb_ctr_btn.Enabled == true){
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
                if (dg_res_ult.SelectedRows[0].Cells[0].Value == null){
                    tb_ide_usr.Text = string.Empty;
                    lb_nom_usr.Text = string.Empty;
                }else{
                    tb_ide_usr.Text = dg_res_ult.SelectedRows[0].Cells["va_ide_usr"].Value.ToString();
                    lb_nom_usr.Text = dg_res_ult.SelectedRows[0].Cells["va_nom_usr"].Value.ToString();
                }
            }
        }

        /// <summary>
        /// Función: Consulta registro seleccionado
        /// </summary>
        private void fi_con_sel()
        {
            // Verifica que los datos en pantallas sean correctos
            if (tb_ide_usr.Text.Trim() == "")
            {
                lb_nom_usr.Text = "NO Existe";
                return;
            }

            // Verifica si el usuario está registrado en el sistema
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_con_ide(tb_ide_usr.Text.Trim());
            if (Tabla.Rows.Count == 0)
            {
                lb_nom_usr.Text = "NO existe";
                return;
            }

            lb_nom_usr.Text = Tabla.Rows[0]["va_nom_usr"].ToString().Trim();
        }

        /// <summary>
        /// Función: Selecciona la fila en el Datagrid del registro modificado
        /// </summary>
        private void fi_sel_fil(string ide_usr)
        {
            // Obtiene el estado de la búsqueda
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);

            if (ide_usr != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells["va_ide_usr"].Value.ToString().ToUpper() == ide_usr.ToUpper())
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
        public bool fi_ver_dat(string ide_usr)
        {
            string res_fun;
            if (ide_usr.Trim() == ""){
                res_fun = "El Usuario que desea editar, no se encuentra registrado";
                MessageBox.Show(res_fun, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_ide_usr.Focus();
                return false;
            }

            // Obtiene datos del registro seleccionado
            tab_dat = new DataTable();
            tab_dat = o_ads007.Fe_con_ide(ide_usr);
            if (tab_dat.Rows.Count == 0){
                res_fun = "El Usuario que desea editar, no se encuentra registrada";
                MessageBox.Show(res_fun, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_ide_usr.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Función: Actualiza la ventana despues de realizar alguna operación
        /// </summary>
        public void Fe_act_frm(string ide_usr)
        {
            fi_bus_car();

            if (ide_usr != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells["va_ide_usr"].Value.ToString().ToUpper() == ide_usr.ToUpper())
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

        // Evento Validated: ID. Usuario
        private void tb_ide_usr_Validated(object sender, EventArgs e)
        {
            fi_con_sel();
            if (lb_nom_usr.Text != "NO Existe")            
                fi_sel_fil(tb_ide_usr.Text);            
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

        // Evento Click: Buscar Datos
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

        // Evento Click: Nuevo Usuario
        private void mn_nue_reg_Click(object sender, EventArgs e)
        {
            ads007_02 frm = new ads007_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        // Evento Click: Modifica Usuario
        private void mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads007_03 frm = new ads007_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Habilita/Deshabilita Usuario
        private void mn_hab_des_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para habilitar/deshabilitar
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads007_04 frm = new ads007_04();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Elimina Usuario
        private void mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para eliminar
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads007_06 frm = new ads007_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Inicializa Contraseña
        private void mn_ini_con_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para el permiso
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            // Abre Validación Usuario Clave
            ads025_01 o_frm = new ads025_01{
                vp_ide_mod = 1,  // Administracion
                vp_ide_cla = 2   // Inicializa Contraseña Usuario
            };
            cl_glo_frm.abrir(this, o_frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (o_frm.DialogResult == DialogResult.OK)
            {
                if (o_frm.DialogResult == DialogResult.OK)
                {
                    ads007_03c frm = new ads007_03c();
                    cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
                }
            }            
        }

        // Evento Click: Reinicia Permisos
        private void mn_rei_per_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para el permiso
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads007_03e frm = new ads007_03e();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Cambia Permiso s/Tipo de Usuario
        private void mn_cam_tus_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para el permiso
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads007_03d frm = new ads007_03d();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Módifica PIN
        private void mn_mod_pin_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para el permiso
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads007_03f frm = new ads007_03f();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Inicializa PIN
        private void mn_ini_pin_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para el permiso
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads007_03g frm = new ads007_03g();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Consulta Registro
        private void mn_con_reg_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads007_05 frm = new ads007_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Consulta Permiso Usuario
        private void mn_per_usr_Click(object sender, EventArgs e)
        {
            string res_fun;
            string per_ide;

            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            // Obtiene datos del Usuario seleccionado
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_con_ide(tb_ide_usr.Text.Trim());
            if (Tabla.Rows.Count > 0)
                per_ide = Tabla.Rows[0]["va_ide_per"].ToString();
            else
                per_ide = "0";            

            // Valida que el codigo de persona sea Numerico
            if (!cl_glo_bal.IsNumeric(per_ide))
            {
                res_fun = "El Código de Persona asociada al Usuario no es Númerico";
                MessageBox.Show(res_fun, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Valida que el codigo de persona sea DISTINTO a cero
            if (per_ide.CompareTo("0") == 0)
            {
                res_fun = "El Usuario NO tiene un código de Persona asociada";
                MessageBox.Show(res_fun, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtiene datos de la Persona
            Tabla = new DataTable();
            Tabla = o_adp002.Fe_con_per(int.Parse(per_ide));
            if (Tabla.Rows.Count == 0)
            {
                res_fun = "La Persona que desea editar, NO se encuentra registrado";
                MessageBox.Show(res_fun, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llama a la venta Consulta Persona
            adp002_05 frm = new adp002_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si, Tabla);
        }

        // Evento Click: Consulta Autorizaciones del Usuario
        private void mn_con_aut_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para informe
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads007_R03p frm = new ads007_R03p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }                                           

        // Evento Click: Permiso Grupo de Persona
        private void mn_per_gdp_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para el permiso
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads008_06 frm = new ads008_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Permiso Vendedor
        private void mn_per_ven_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para el permiso
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads008_07 frm = new ads008_07();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Permiso Cobrador
        private void mn_per_cob_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para el permiso
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads008_08 frm = new ads008_08();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Permiso Grupo de Bodega
        private void mn_per_gdb_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para el permiso
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads008_09 frm = new ads008_09();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Permiso Bodega
        private void mn_per_bod_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para el permiso
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads008_05 frm = new ads008_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Permiso Lista de Precio
        private void mn_per_lis_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para el permiso
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads008_04 frm = new ads008_04();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Permiso Plantilla de Venta
        private void mn_per_plv_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para el permiso
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads008_03 frm = new ads008_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Permiso Talonario
        private void mn_per_tal_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para el permiso
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads008_02 frm = new ads008_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Permiso Aplicacion
        private void mn_per_apl_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para el permiso
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads008_01 frm = new ads008_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Claves Autorizadas
        private void mn_cla_aut_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para el permiso
            if (fi_ver_dat(tb_ide_usr.Text) == false)
                return;

            ads014_01 frm = new ads014_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        // Evento Click: Lista de Usuario
        private void mn_lis_usr_Click(object sender, EventArgs e)
        {
            ads007_R01p frm = new ads007_R01p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        // Evento Click: Lista Usuario p/Tipo de Usuario
        private void mn_lis_tus_Click(object sender, EventArgs e)
        {
            ads007_R02p frm = new ads007_R02p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        // Evento Click: Autorizaciones p/Rango de Usuario
        private void mn_lis_apu_Click(object sender, EventArgs e)
        {
            ads007_R04p frm = new ads007_R04p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        // Evento Click: Aplicaciones Autorizada p/Rango de Usuario
        private void mn_lis_aau_Click(object sender, EventArgs e)
        {
            ads007_R05p frm = new ads007_R05p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        // Evento Click: Talonarios Autorizada p/Rango de Usuario
        private void mn_lis_tau_Click(object sender, EventArgs e)
        {
            ads007_R06p frm = new ads007_R06p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        // Evento Click: Tipo de Usuario
        private void mn_tip_usu_Click(object sender, EventArgs e)
        {
            ads006_01 frm = new ads006_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.ocul);
        }

        // Evento Click: Cerrar Pantalla
        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        // Evento Click: Cambia Tipo de Usuario
        private void bt_tip_usr_Click(object sender, EventArgs e)
        {
            ads006_01 frm = new ads006_01();
            frm.AccessibleName = "1";
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                vp_ide_tus = int.Parse(frm.tb_ide_tus.Text);

                /* Desplega el nombre del modulo seleccionado */
                Tabla = new DataTable();
                Tabla = o_ads006.Fe_con_tus(vp_ide_tus);
                if (Tabla.Rows.Count > 0)
                    lb_nom_tus.Text = Tabla.Rows[0]["va_nom_tus"].ToString();
                else
                    lb_nom_tus.Text = "TODOS";

                /* Realiza el filtro de registro de acuerpo al modulo */
                if (cb_est_bus.SelectedIndex == 0)
                    est_bus = "T";
                if (cb_est_bus.SelectedIndex == 1)
                    est_bus = "H";
                if (cb_est_bus.SelectedIndex == 2)
                    est_bus = "N";

                fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);
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
