﻿using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp003 - Tipo de Atributos                            */
    /*      Opción: Buscar Registro                                       */
    /*       Autor: JEJR - Crearsis             Fecha: 30-08-2021         */
    /**********************************************************************/
    public partial class adp003_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable Tabla;
        public dynamic frm_MDI;
        // Instancia        
        adp003 o_adp003 = new adp003();
        DataTable tabla = new DataTable();
        // Variables        
        string est_bus = "H";

        public adp003_01()
        {
            InitializeComponent();
        }        

        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }
        private void fi_ini_frm()
        {
            tb_ide_tip.Text = "";           
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 1;
            fi_bus_car("", cb_prm_bus.SelectedIndex, est_bus);
        }     

        /// <summary>
        /// Funcion interna buscar
        /// </summary>
        /// <param name="tex_bus">Texto a buscar</param>
        /// <param name="prm_bus">Parámetros a buscar</param>
        /// <param name="est_bus">Estado a buscar</param>
        private void fi_bus_car(string tex_bus = "", int prm_bus = 0, string est_bus = "T")
        {
            //Limpia Grilla
            dg_res_ult.Rows.Clear();

            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            tabla = o_adp003.Fe_bus_car(tex_bus, prm_bus, est_bus);

            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_tip"].Value = tabla.Rows[i]["va_ide_tip"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_tip"].Value = tabla.Rows[i]["va_nom_tip"].ToString();
                    
                    if (tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                }
                tb_ide_tip.Text = tabla.Rows[0]["va_ide_tip"].ToString();
                lb_nom_tip.Text = tabla.Rows[0]["va_nom_tip"].ToString();
            }

        }

        /// <summary>
        /// Consulta Registro Seleccionado
        /// </summary>
        private void fi_con_sel()
        {
            // Verifica que los datos en pantallas sean correctos
            if (tb_ide_tip.Text.Trim() == ""){
                lb_nom_tip.Text = "NO existe";
                return;
            }

            tabla = o_adp003.Fe_con_tip(int.Parse(tb_ide_tip.Text));
            if (tabla.Rows.Count == 0){
                lb_nom_tip.Text = "NO existe";
                return;
            }

            lb_nom_tip.Text = Convert.ToString(tabla.Rows[0]["va_nom_tip"].ToString());
        }

        /// <summary>
        /// Función : Selecciona la fila en el Datagrid
        /// </summary>
        private void fi_sel_fil(string ide_tip)
        {
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            Tabla = new DataTable();
            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);

            if (ide_tip != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == ide_tip.ToUpper())
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

        /// <summary>
        /// Método para obtener fila actual seleccionada
        /// </summary>
        public void fi_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                if (dg_res_ult.SelectedRows[0].Cells[0].Value == null){
                    tb_ide_tip.Text = "";
                    lb_nom_tip.Text = "";
                }else{
                    tb_ide_tip.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString().Trim();
                    lb_nom_tip.Text = dg_res_ult.SelectedRows[0].Cells[1].Value.ToString().Trim();
                }
            }
        }

        /// <summary>
        /// Método para verificar concurrencia de datos
        /// </summary>
        public bool fi_ver_dat(string sel_ecc)
        {
            string res_fun;
            if (sel_ecc.Trim() == ""){
                res_fun = "El Tipo de Atributo que desea editar, no se encuentra registrado";
                MessageBox.Show(res_fun, "Edita Tipo de Atributo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_ide_tip.Focus();
                return false;
            }

            Tabla = new DataTable();
            Tabla = o_adp003.Fe_con_tip(int.Parse(sel_ecc));
            if (tabla.Rows.Count == 0)
            {
                res_fun = "El Tipo de Atributo que desea editar, no se encuentra registrado";
                MessageBox.Show(res_fun, "Edita Tipo de Atributo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_ide_tip.Focus();
                return false;
            }

            return true;
        }

        private void tb_ide_tip_Validated(object sender, EventArgs e){
            fi_con_sel();
            if (lb_nom_tip.Text != "NO existe")
            {
                fi_sel_fil(tb_ide_tip.Text);
            }
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e){
            fi_fil_act();
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fi_fil_act();
        }

        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bt_ace_pta.Enabled == true && dg_res_ult.Rows.Count > 0) { 
                this.DialogResult = DialogResult.OK;
                cl_glo_frm.Cerrar(this);
            }
        }

    private void dg_res_ult_Enter(object sender, EventArgs e)
    {
        if (bt_ace_pta.Enabled == true && dg_res_ult.Rows.Count > 0) { 
            this.DialogResult = DialogResult.OK;
                cl_glo_frm.Cerrar(this);
            }
        }

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


        /// <summary>
        /// Funcion Externa : Actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(int ide_gru)
        {
         if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);

            if (ide_gru.ToString() != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString() == ide_gru.ToString())
                        {
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex = i;
                            return;
                        }
                    }
                }catch (Exception ex){
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void mn_nue_reg_Click(object sender, EventArgs e)
        {
            adp003_02 frm = new adp003_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
        private void mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_dat(tb_ide_tip.Text) == false)
                return;

            adp003_03 frm = new adp003_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }       
        private void mn_hab_des_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para habilitar/deshabilitar
            if (fi_ver_dat(tb_ide_tip.Text) == false)
                return;

            adp003_04 frm = new adp003_04();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(tb_ide_tip.Text) == false)
                return;

            adp003_05 frm = new adp003_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(tb_ide_tip.Text) == false)
                return;

            adp003_06 frm = new adp003_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void mn_rep_tip_Click(object sender, EventArgs e)
        {
            adp003_R01p frm = new adp003_R01p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            cl_glo_frm.Cerrar(this);
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            cl_glo_frm.Cerrar(this);
        }
    }
}
