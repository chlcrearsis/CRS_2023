﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;


namespace CRS_PRE
{
    public partial class cmr003_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;
        //Form frm_mdi;
        public cmr003_01()
        {
            InitializeComponent();
        }

        // instancia
        cmr003 o_cmr003 = new cmr003();

        // Variables
        DataTable tabla = new DataTable();
        DataTable tab_cmr003 = new DataTable();


        private void ads007_01_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }

        #region  [Funciones Internas]
        private void fi_ini_frm()
        {
            tb_sel_bus.Text = "";
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;
          
            fi_bus_car("", parametro.codigo, "T");  
        }

        protected enum parametro
        {
            codigo = 1, nombre = 2
        }
        protected enum estado
        {
            Todos = 0, Habilitado = 1, Deshabilitado = 2
        }

        /// <summary>
        /// Funcion interna buscar
        /// </summary>
        /// <param name="ar_tex_bus">Texto a buscar</param>
        /// <param name="ar_prm_bus">Parametro a buscar</param>
        /// <param name="ar_est_bus">Estado a buscar</param>
        private void fi_bus_car(string ar_tex_bus = "", parametro ar_prm_bus = 0, string ar_est_bus = "T")
        {
            //Limpia Grilla
            dg_res_ult.Rows.Clear();

            tabla = o_cmr003.Fe_bus_car(ar_tex_bus, (int)ar_prm_bus, ar_est_bus);
            
            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_suc"].Value = tabla.Rows[i]["va_ide_suc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_suc"].Value = tabla.Rows[i]["va_nom_suc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_ciu_suc"].Value = tabla.Rows[i]["va_ciu_suc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_dir_suc"].Value = tabla.Rows[i]["va_dir_suc"].ToString();
                    
                    if (tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                }
                tb_sel_bus.Text = tabla.Rows[0]["va_ide_suc"].ToString();
                lb_des_bus.Text = tabla.Rows[0]["va_nom_suc"].ToString();
            }

        }
        private void fi_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            if (tb_sel_bus.Text.Trim() == "")
            {
                lb_des_bus.Text = "** NO existe";
                return;
            }

            tabla = o_cmr003.Fe_con_suc(tb_sel_bus.Text);
            if (tabla.Rows.Count == 0)
            {
                lb_des_bus.Text = "** NO existe";
                return;
            }

            lb_des_bus.Text = Convert.ToString(tabla.Rows[0]["va_nom_suc"].ToString());
        }
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Sucursal Modificó
        /// </summary>
        private void fi_sel_fil(string cod_usr)
        {
            parametro prm_bus = new parametro();
            string est_bus = "";

            if (cb_prm_bus.SelectedIndex == 0)
                prm_bus = parametro.codigo;
            if (cb_prm_bus.SelectedIndex == 1)
                prm_bus = parametro.nombre;

            if (cb_est_bus.SelectedIndex == 0)
                est_bus ="T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus ="N";

            fi_bus_car(tb_tex_bus.Text, prm_bus, est_bus);

            if (cod_usr != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_usr.ToUpper())
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

        private void fi_sub_baj_fil_KeyDown(object sender, KeyEventArgs e)
        {
            if (dg_res_ult.Rows.Count != 0)
            {
                try
                {
                    //al presionar tecla para ABAJO
                    if (e.KeyData == Keys.Down)
                    {
                        dg_res_ult.Show();

                        if (dg_res_ult.SelectedRows[0].Index != dg_res_ult.Rows.Count - 1)
                        {
                            //Establece el foco en el Datagrid
                            dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index + 1];

                            //Llama a función que actualiza datos en Textbox de Selección
                            fi_fil_act();

                        }
                    }
                    //al presionar tecla para ARRIBA
                    else if (e.KeyData == Keys.Up)
                    {
                        dg_res_ult.Show();

                        if (dg_res_ult.SelectedRows[0].Index != 0)
                        {
                            //Establece el foco en el Datagrid
                            dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index - 1];

                            //Llama a función que actualiza datos en Textbox de Selección
                            fi_fil_act();

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
        /// Método para obtener fila actual seleccionada
        /// </summary>
        public void fi_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                if (dg_res_ult.SelectedRows[0].Cells[0].Value == null)
                {
                    tb_sel_bus.Text = "";
                    lb_des_bus.Text = "";
                }
                else
                {
                    tb_sel_bus.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();
                    lb_des_bus.Text = dg_res_ult.SelectedRows[0].Cells[1].Value.ToString();
                }

            }
        }

        /// <summary>
        /// Método para verificar concurrencia de datos para editar
        /// </summary>
        public bool fi_ver_edi(string sel_ecc)
        {
            string res_fun = "" ;
            if(!cl_glo_bal.IsNumeric(tb_sel_bus.Text.Trim()))
            {
                res_fun = "Debe proporcionar el ID. para la sucursal";
            }
            // Obtiene datos seleccionado
            tab_dat = o_cmr003.Fe_con_suc(sel_ecc);
            
            if(tab_dat.Rows.Count== 0)
            {
                res_fun = "La sucursal no se encuentra registrada.";
            }
            if(tab_dat.Rows[0]["va_est_ado"].ToString()== "N")
                res_fun = "La sucursal se encuentra Deshabilitada.";


            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "Edita Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_bus.Focus();
                return false;
            }

            
            return true;
        }
        public bool fi_ver_hds(string sel_ecc)
        {
            string res_fun = "";
            if (!cl_glo_bal.IsNumeric(tb_sel_bus.Text.Trim()))
            {
                res_fun = "Debe proporcionar el ID. para la sucursal";
            }
            // Obtiene datos seleccionado
            tab_dat = o_cmr003.Fe_con_suc(sel_ecc);

            if (tab_dat.Rows.Count == 0)
            {
                res_fun = "La sucursal no se encuentra registrada.";
            }
           

            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "Edita Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_bus.Focus();
                return false;
            }

            return true;
        }
        public bool fi_ver_con(string sel_ecc)
        {
            string res_fun = "";
            if (!cl_glo_bal.IsNumeric(tb_sel_bus.Text.Trim()))
            {
                res_fun = "Debe proporcionar el ID. para la sucursal";
            }
            // Obtiene datos seleccionado
            tab_dat = o_cmr003.Fe_con_suc(sel_ecc);

            if (tab_dat.Rows.Count == 0)
            {
                res_fun = "La sucursal no se encuentra registrada.";
            }


            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "Edita Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_bus.Focus();
                return false;
            }

            return true;
        }



        #endregion

        private void Tb_sel_bus_Validated(object sender, EventArgs e)
        {
            fi_con_sel();
            if (lb_des_bus.Text != "** NO existe")
            {
                fi_sel_fil(tb_sel_bus.Text);
            }
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fi_fil_act();
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fi_fil_act();
        }

        private void Bt_bus_car_Click(object sender, EventArgs e)
        {
            parametro prm_bus = new parametro();
            string est_bus = "";

            if (cb_prm_bus.SelectedIndex == 0)
                prm_bus = parametro.codigo;
            if (cb_prm_bus.SelectedIndex == 1)
                prm_bus = parametro.nombre;

            if (cb_est_bus.SelectedIndex == 0)
                est_bus ="T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, prm_bus, est_bus);

        }



        /// <summary>
        /// Funcion Externa que actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(string cod_usr)
        {
            parametro prm_bus = new parametro();
            string est_bus = "";

            if (cb_prm_bus.SelectedIndex == 0)
                prm_bus = parametro.codigo;
            if (cb_prm_bus.SelectedIndex == 1)
                prm_bus = parametro.nombre;

            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, prm_bus, est_bus);


            if (cod_usr != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_usr.ToUpper())
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




        private void Mn_cre_ar_Click(object sender, EventArgs e)
        {
            if (fi_ver_edi(tb_sel_bus.Text) == false)
                return;

            cmr003_02 frm = new cmr003_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        private void Mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_edi(tb_sel_bus.Text) == false)
                return;

            cmr003_03 frm = new cmr003_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
       
        private void Mn_hab_des_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para habilitar/deshabilitar
            if (fi_ver_hds(tb_sel_bus.Text) == false)
                return;

            cmr003_04 frm = new cmr003_04();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void Mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_con(tb_sel_bus.Text) == false)
                return;

            cmr003_05 frm = new cmr003_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void Mn_cer_rar_Click_1(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Mn_list_usr_Click(object sender, EventArgs e)
        {
            ads007_R01p frm = new ads007_R01p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
   
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            cl_glo_frm.Cerrar(this);
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            if (gb_ctr_btn.Enabled == true)
            {
                this.DialogResult = DialogResult.OK;
                cl_glo_frm.Cerrar(this);
            }
        }

        private void dg_res_ult_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gb_ctr_btn.Enabled == true)
            {
                this.DialogResult = DialogResult.OK;
                cl_glo_frm.Cerrar(this);
            }
        }
    }
}
