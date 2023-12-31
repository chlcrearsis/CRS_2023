﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE.INV
{
    public partial class inv099_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;

        string est_bus = "T";

        //Form frm_mdi;
        public inv099_01()
        {
            InitializeComponent();
        }

        // instancia
        ads003 o_ads003 = new ads003();
        

        ads001 o_ads001 = new ads001();

        inv003 o_inv003 = new inv003();
        inv004 o_inv004 = new inv004();

        // Variables
        DataTable tabla = new DataTable();

        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }

        #region  [Funciones Internas]
        private void fi_ini_frm()
        {
            tb_sel_ecc.Text = "";
            lb_pro_sel.Text = "";
            tb_cod_fam_bus.Text = "000000";
           
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;

            fi_bus_car("", cb_prm_bus.SelectedIndex, est_bus);
        }

        public enum parametro
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
        private void fi_bus_car(string ar_tex_bus = "", int ar_prm_bus = 0, string ar_est_bus = "T", string ar_cod_fam = "000000")
        {
            //Limpia Grilla
            dg_res_ult.Rows.Clear();

            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            tabla = o_inv004.Fe_bus_car(ar_tex_bus, ar_prm_bus, est_bus, ar_cod_fam);

            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();

                    dg_res_ult.Rows[i].Cells["va_cod_pro"].Value = tabla.Rows[i]["va_cod_pro"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_pro"].Value = tabla.Rows[i]["va_nom_pro"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_mar"].Value = tabla.Rows[i]["va_nom_mar"].ToString();
                    dg_res_ult.Rows[i].Cells["va_cod_umd"].Value = tabla.Rows[i]["va_cod_umd"].ToString();
                    dg_res_ult.Rows[i].Cells["va_und_cmp"].Value = tabla.Rows[i]["va_und_cmp"].ToString();
                    dg_res_ult.Rows[i].Cells["va_und_vta"].Value = tabla.Rows[i]["va_und_vta"].ToString();


                    // FORMATEA EL CODIGO PARA MOSTRAR EN EL DATAGRID
                    int value;
                    value = int.Parse(tabla.Rows[i]["va_cod_fam"].ToString())  ;
                    dg_res_ult.Rows[i].Cells["va_cod_fam"].Value =  value.ToString("##-##-##");

                    dg_res_ult.Rows[i].Cells["va_nom_fam"].Value = tabla.Rows[i]["va_nom_fam"].ToString();

                    if (tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                }
                tb_sel_ecc.Text = tabla.Rows[0]["va_cod_pro"].ToString();
                lb_pro_sel.Text = tabla.Rows[0]["va_nom_pro"].ToString();
            }

        }
        private void fi_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            if (tb_sel_ecc.Text.Trim() == "" )
            {
                lb_pro_sel.Text = "";
                return;
            }

            tabla = o_inv004.Fe_con_pro(tb_sel_ecc.Text);
            if (tabla.Rows.Count == 0)
            {
                lb_fam_bus.Text = "** NO existe";
                return;
            }

            //lb_des_bus.Text = Convert.ToString(tabla.Rows[0]["va_nom_fam"].ToString());
            lb_pro_sel.Text = tabla.Rows[0]["va_nom_pro"].ToString().Trim();
        }
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que El Producto Modificó
        /// </summary>
        private void fi_sel_fil(string cod_pro)
        {
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus,tb_cod_fam_bus.Text);
            //int val_cod;

            //val_cod = int.Parse(cod_pro);
            //cod_pro = val_cod.ToString("##-##-##");
            if (cod_pro != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells["va_cod_pro"].Value.ToString().ToUpper() == cod_pro.ToUpper())
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
                    tb_sel_ecc.Text = "";
                    lb_pro_sel.Text = "";
                }
                else
                {
                    tb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells["va_cod_pro"].Value.ToString().Trim();
                    lb_pro_sel.Text = dg_res_ult.SelectedRows[0].Cells["va_nom_pro"].Value.ToString().Trim();
                }

            }
        }

        /// <summary>
        /// Método para verificar concurrencia de datos para editar
        /// </summary>
        public bool fi_ver_edi(string sel_ecc)
        {
            string res_fun = "";
            tab_dat = o_inv004.Fe_con_pro(sel_ecc);
            if (tab_dat.Rows.Count == 0)
            {
                res_fun = "El Producto que desea editar, no se encuentra registrado";
            }

            if (tab_dat.Rows[0]["va_est_ado"].ToString()=="N")
            {
                res_fun = "El Producto que desea editar, se encuentra Deshabilitado";
            }

            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "Edita Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_fam_bus.Focus();
                return false;
            }

            return true;
        }
        public bool fi_ver_hds(string sel_ecc)
        {
          
            tab_dat = o_inv004.Fe_con_pro(sel_ecc);
            if (tab_dat.Rows.Count == 0)
            {
                MessageBox.Show("El Producto ya no se encuentra registrado en la base de datos.", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_fam_bus.Focus();
                return false;
            }

            return true;
        }
        public bool fi_ver_con(string sel_ecc)
        {
            tab_dat = o_inv004.Fe_con_pro(sel_ecc);
            if (tab_dat.Rows.Count == 0)
            {
                MessageBox.Show("El Producto ya no se encuentra registrado en la base de datos.", "Consulta Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_fam_bus.Focus();
                return false;
            }

            return true;
        }



        #endregion

        private void Tb_sel_bus_Validated(object sender, EventArgs e)
        {
            fi_con_sel();
            if (lb_pro_sel.Text != "")
            {
                fi_sel_fil(tb_sel_ecc.Text);
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

        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            cl_glo_frm.Cerrar(this);
        }


        private void Bt_bus_car_Click(object sender, EventArgs e)
        {
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus, tb_cod_fam_bus.Text);

        }


        /// <summary>
        /// Funcion Externa que actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(string cod_pro)
        {
         if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);

            if (cod_pro != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_pro.ToUpper())
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
            inv004_02 frm = new inv004_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        private void Mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_edi(tb_sel_ecc.Text) == false)
                return;

            inv004_03b frm = new inv004_03b();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
       
        private void Mn_hab_des_Click(object sender, EventArgs e)
        {
           
        }
        private void Mn_con_pro_Click(object sender, EventArgs e)
        {
            // Verifica para consultar
            if (fi_ver_con(tb_sel_ecc.Text) == false)
                return;

            inv004_05 frm = new inv004_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void Mn_con_exi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para habilitar/deshabilitar
            if (fi_ver_con(tb_sel_ecc.Text) == false)
                return;

            inv099_05 frm = new inv099_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void Mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_con(tb_sel_ecc.Text) == false)
                return;

            //inv003_06 frm = new inv003_06();
            //cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        private void Mn_cer_rar_Click_1(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

      
        private void Mn_list_fam_Click(object sender, EventArgs e)
        {
            inv099_R02p frm = new inv099_R02p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            cl_glo_frm.Cerrar(this);
        }

        private void bt_bus_fam_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_fam();
        }
        private void Tb_cod_fam_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Documento
                Fi_abr_bus_fam();
            }
        }

        void Fi_abr_bus_fam()
        {
            inv003_01 frm = new inv003_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_fam_bus.Text = frm.tb_sel_bus.Text;
                Fi_obt_fam();
            }
        }
        /// <summary>
        /// Obtiene ide y nombre Familia para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_fam()
        {
            // Obtiene ide y nombre 
            tabla = o_ads003.Fe_con_doc(tb_cod_fam_bus.Text);
            if (tabla.Rows.Count == 0)
            {
                lb_fam_bus.Text = "";
            }
            else
            {
                tb_cod_fam_bus.Text = tabla.Rows[0]["va_cod_fam"].ToString();
                lb_fam_bus.Text = tabla.Rows[0]["va_nom_fam"].ToString();
            }
        }

        private void tb_cod_fam_bus_Validated(object sender, EventArgs e)
        {
            Fi_obt_fam();
        }

        private void mn_kar_pro_Click(object sender, EventArgs e)
        {

            if (fi_ver_con(tb_sel_ecc.Text)==true)
            {
                inv099_R01p frm = new inv099_R01p();
                cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
            }
        }
    }
}
