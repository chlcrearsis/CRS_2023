﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;
using CRS_PRE.INV;

namespace CRS_PRE
{
    public partial class res004_03 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        cmr001 o_cmr001 = new cmr001();
        c_res004 o_res004 = new c_res004();

        inv002 o_inv002 = new inv002();
        cmr015 o_cmr015 = new cmr015();
        cmr014 o_cmr014 = new cmr014();
        adp002 o_adp002 = new adp002();

        ads004 o_ads004 = new ads004();


        DataTable tabla = new DataTable();
        DataTable tab_prm = new DataTable();
        int opc_doc = 0;


        public res004_03()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            Fi_ini_frm();
        }
        void Fi_ini_frm()
        {

            // *** INICIALIZA FORMULARIO CON DATOS *** \\\
            int val = 0;

            tb_cod_plv.Text = frm_dat.Rows[0]["va_cod_plv"].ToString();
            tb_cod_plv_2.Text = frm_dat.Rows[0]["va_cod_plv"].ToString();
            tb_nom_plv.Text = frm_dat.Rows[0]["va_nom_plv"].ToString();
            tb_nom_plv_2.Text = frm_dat.Rows[0]["va_nom_plv"].ToString();
            tb_des_plv.Text = frm_dat.Rows[0]["va_des_plv"].ToString();
            tb_des_plv_2.Text = frm_dat.Rows[0]["va_des_plv"].ToString();

            // GENERAL
            tb_cod_bod.Text = frm_dat.Rows[0]["va_cod_bod"].ToString();
            Fi_obt_bod();
            val = int.Parse(frm_dat.Rows[0]["va_cam_bod"].ToString());
            if (val == 0)
                ch_cam_bod.Checked =false;
            else
                ch_cam_bod.Checked = true;

            tb_cod_lis.Text = frm_dat.Rows[0]["va_cod_lis"].ToString();
            Fi_obt_lis();
            val = int.Parse(frm_dat.Rows[0]["va_cam_lis"].ToString());
            if (val == 0)
                ch_cam_lis.Checked = false;
            else
                ch_cam_lis.Checked = true;
 
            tb_cod_ven.Text = frm_dat.Rows[0]["va_cod_ven"].ToString();
            Fi_obt_ven();

            cb_cam_ven.SelectedIndex = int.Parse(frm_dat.Rows[0]["va_cam_ven"].ToString());


            //cb_cam_mon.SelectedIndex = int.Parse(frm_dat.Rows[0]["va_cam_mon"].ToString());
            tb_dia_ret.Text = frm_dat.Rows[0]["va_dia_ret"].ToString();

            tb_cod_del.Text = frm_dat.Rows[0]["va_cod_del"].ToString();
            Fi_obt_del();
            val = int.Parse(frm_dat.Rows[0]["va_cam_del"].ToString());
            if (val == 0)
                ch_cam_del.Checked = false;
            else
                ch_cam_del.Checked = true;


            tb_cod_per.Text = frm_dat.Rows[0]["va_cod_cli"].ToString();
            Fi_obt_per();

            cb_for_pag.SelectedIndex = int.Parse(frm_dat.Rows[0]["va_for_pgo"].ToString());
            val = int.Parse(frm_dat.Rows[0]["va_cam_fpg"].ToString());
            if (val == 0)
                ch_cam_fpg.Checked = false;
            else
                ch_cam_fpg.Checked = true;

            cb_bus_pro.SelectedIndex = int.Parse(frm_dat.Rows[0]["va_bus_pro"].ToString());

            val = int.Parse(frm_dat.Rows[0]["va_img_pro"].ToString());
            if (val == 0)
                ch_img_pro.Checked = false;
            else
                ch_img_pro.Checked = true;


            // DOCUMENTOS E IMPRESORAS
            tb_cod_doc_con.Text = frm_dat.Rows[0]["va_doc_con"].ToString();
            tb_nro_tal_con.Text = frm_dat.Rows[0]["va_tal_con"].ToString();
            tb_imp_con.Text = frm_dat.Rows[0]["va_imp_con"].ToString();

            tb_cod_doc_opd.Text = frm_dat.Rows[0]["va_doc_opd"].ToString();
            tb_nro_tal_opd.Text = frm_dat.Rows[0]["va_tal_opd"].ToString();
            tb_imp_opd.Text = frm_dat.Rows[0]["va_imp_opd"].ToString();

            tb_cod_doc_nvt.Text = frm_dat.Rows[0]["va_doc_ntv"].ToString();
            tb_nro_tal_nvt.Text = frm_dat.Rows[0]["va_tal_ntv"].ToString();
            tb_imp_nvt.Text = frm_dat.Rows[0]["va_imp_ntv"].ToString();

            tb_cod_doc_fac.Text = frm_dat.Rows[0]["va_doc_fac"].ToString();
            tb_nro_tal_fac.Text = frm_dat.Rows[0]["va_tal_fac"].ToString();
            tb_imp_fac.Text = frm_dat.Rows[0]["va_imp_fac"].ToString();

          
            // Obtiene talonarios
            opc_doc = 1;
            Fi_obt_tal();

            opc_doc = 2;
            Fi_obt_tal();

            opc_doc = 3;
            Fi_obt_tal();

            opc_doc = 4;
            Fi_obt_tal();


            val = int.Parse(frm_dat.Rows[0]["va_ban_av1"].ToString());
            if (val == 0)
                ch_imp_av1.Checked = false;
            else
            {
                ch_imp_av1.Checked = true;
                tb_imp_av1.Text = frm_dat.Rows[0]["va_imp_av1"].ToString();
            }
                


            val = int.Parse(frm_dat.Rows[0]["va_ban_av2"].ToString());
            if (val == 0)
                ch_imp_av2.Checked = false;
            else
            {
                ch_imp_av2.Checked = true;
                tb_imp_av2.Text = frm_dat.Rows[0]["va_imp_av2"].ToString();
            }


            tb_cod_plv.Focus();
        }
        void Fi_lim_frm()
        {
            tb_cod_plv.Clear();
            tb_nom_plv.Clear();
            tb_des_plv.Clear();

            tb_cod_plv_2.Clear();
            tb_nom_plv_2.Clear();
            tb_des_plv_2.Clear();

            tb_cod_bod.Clear();

        }

        private void creaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar( this);
        }

        private void mn_edi_tar_Click(object sender, EventArgs e)
        {

        }


        protected string Fi_val_dat()
        {
            int val = 0;
            try
            {
                val = int.Parse(tb_cod_plv.Text);
            }
            catch (Exception)
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_cod_plv.Focus();
                return "El codigo para la plantilla no es valido";
            }

            //Verifica si el codigo no esta en la base de datos
            tabla = new DataTable();
            tabla = o_res004.Fe_con_plv(val.ToString());
            if(tabla.Rows.Count ==0)
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_cod_plv.Focus();
                return "La plantilla de venta NO se encuentra registrada";
            }
            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_cod_plv.Focus();
                return "La plantilla de venta se encuentra Deshabilitada";
            }

            //Verifica que los datos nombre esten rellenos
            if (tb_nom_plv.Text.Trim() =="")
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_nom_plv.Focus();
                return "Debe proporcionar el nombre para la plantilla de venta";
            }

            //Verifica Bodega
            try
            {
                val = int.Parse(tb_cod_bod.Text);
            }
            catch (Exception)
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_cod_bod.Focus();
                return "Debe proporcionar una bodega valida";
            }
            tabla = new DataTable();
            tabla = o_inv002.Fe_con_bod(int.Parse(tb_cod_bod.Text));
            if (tabla.Rows.Count == 0)
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_cod_bod.Focus();
                return "La bodega NO se encuentra registrada";
            }
            if(tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_cod_bod.Focus();
                return "La bodega se encuentra Deshabilitada";
            }


            //Verifica Lista de Precio
            try
            {
                val = int.Parse(tb_cod_lis.Text);
            }
            catch (Exception)
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_cod_lis.Focus();
                return "Debe proporcionar una Lista de precio valida";
            }
            tabla = new DataTable();
            tabla = o_cmr001.Fe_con_lis(int.Parse(tb_cod_lis.Text));
            if (tabla.Rows.Count == 0)
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_cod_lis.Focus();
                return "La Lista de precio NO se encuentra registrada";
            }
            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_cod_bod.Focus();
                return "La Lista de precio se encuentra Deshabilitada";
            }

            //Verifica Vendedor
            try
            {
                val = int.Parse(tb_cod_ven.Text);
            }
            catch (Exception)
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_cod_ven.Focus();
                return "Debe proporcionar un Vendedor valido";
            }
            tabla = new DataTable();
            tabla = o_cmr014.Fe_con_ven(int.Parse(tb_cod_ven.Text),1);
            if (tabla.Rows.Count == 0)
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_cod_ven.Focus();
                return "El Venderodr NO se encuentra registrado";
            }
            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_cod_ven.Focus();
                return "El vendedor se encuentra Deshabilitado";
            }

            //Verifica Delivery
            try
            {
                val = int.Parse(tb_cod_del.Text);
            }
            catch (Exception)
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_cod_del.Focus();
                return "Debe proporcionar un Vendedor valido";
            }
            tabla = new DataTable();
            tabla = o_cmr015.Fe_con_del(int.Parse(tb_cod_del.Text));
            if (tabla.Rows.Count == 0)
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_cod_del.Focus();
                return "El Delivery NO se encuentra registrado";
            }
            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_cod_ven.Focus();
                return "El Delivery se encuentra Deshabilitado";
            }

            //Verifica Cliente (persona)
            try
            {
                val = int.Parse(tb_cod_per.Text);
            }
            catch (Exception)
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_cod_per.Focus();
                return "Debe proporcionar una persona valida";
            }
            tabla = new DataTable();
            tabla = o_adp002.Fe_con_per(int.Parse(tb_cod_per.Text));
            if (tabla.Rows.Count == 0)
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_cod_per.Focus();
                return "La persona NO se encuentra registrada";
            }
            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tc_pla_vta.SelectedIndex = 0;
                tb_cod_per.Focus();
                return "La persona se encuentra Deshabilitada";
            }



            return "";
        }

        private void Fi_lim_pia()
        {

            tc_pla_vta.SelectedIndex = 0;
            tb_cod_plv.Clear();
            tb_nom_plv.Clear();
            tb_des_plv.Clear();

            tb_cod_plv.Focus();
        }


        //******* BODEGA *******\\
         private void Bt_bus_bod_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_bod();
        }
        private void Tb_cod_bod_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca bodega
                Fi_abr_bus_bod();
            }

        }
        void Fi_abr_bus_bod()
        {
            inv002_01 frm = new inv002_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_bod.Text = frm.tb_sel_bus.Text;
                Fi_obt_bod();
            }


        }
        private void Tb_cod_bod_Validated(object sender, EventArgs e)
        {
            Fi_obt_bod();
        }
        /// <summary>
        /// Obtiene ide y nombre bodega para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_bod()
        {
            int val = 0;
            try
            {
                val = int.Parse(tb_cod_bod.Text);
            }
            catch (Exception)
            {
                lb_nom_bod.Text = "";
                return;
            }

            // Obtiene ide y nombre documento
            tabla = o_inv002.Fe_con_bod(int.Parse(tb_cod_bod.Text));
            if (tabla.Rows.Count == 0)
            {
                lb_nom_bod.Text="";
            }
            else
            {
                tb_cod_bod.Text = tabla.Rows[0]["va_cod_bod"].ToString();
                lb_nom_bod.Text = tabla.Rows[0]["va_nom_bod"].ToString();
            }
        }


        //******* LISTA DE PRECIO *******\\
        private void Bt_bus_lis_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_lis();
        }
        private void Tb_cod_lis_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca bodega
                Fi_abr_bus_lis();
            }
        }
        void Fi_abr_bus_lis()
        {
            cmr001_01 frm = new cmr001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_lis.Text = frm.tb_sel_bus.Text;
                Fi_obt_lis();
            }
        }
        private void Tb_cod_lis_Validated(object sender, EventArgs e)
        {
            Fi_obt_lis();
        }
        /// <summary>
        /// Obtiene ide y nombre bodega para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_lis()
        {
            int val = 0;
            try
            {
                val = int.Parse(tb_cod_lis.Text);
            }
            catch (Exception)
            {
                lb_nom_lis.Text = "";
                return;
            }

            // Obtiene ide y nombre documento
            tabla = o_cmr001.Fe_con_lis(int.Parse(tb_cod_lis.Text));
            if (tabla.Rows.Count == 0)
            {
                lb_nom_lis.Text = "";
            }
            else
            {
                tb_cod_lis.Text = tabla.Rows[0]["va_cod_lis"].ToString();
                lb_nom_lis.Text = tabla.Rows[0]["va_nom_lis"].ToString();
            }
        }


        //******* VENDEDOR *******\\
        private void Bt_bus_ven_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_ven();
        }
        private void Tb_cod_ven_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca bodega
                Fi_abr_bus_ven();
            }
        }
        void Fi_abr_bus_ven()
        {
            cmr014_01 frm = new cmr014_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_ven.Text = frm.tb_sel_bus.Text;
                Fi_obt_ven();
            }
        }
        private void Tb_cod_ven_Validated(object sender, EventArgs e)
        {
            Fi_obt_ven();
        }
        /// <summary>
        /// Obtiene ide y nombre bodega para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_ven()
        {
            int val = 0;
            try
            {
                val = int.Parse(tb_cod_ven.Text);
            }
            catch (Exception)
            {
                lb_nom_ven.Text = "";
                return;
            }

            // Obtiene ide y nombre documento
            tabla = o_cmr014.Fe_con_ven(int.Parse(tb_cod_ven.Text),1);
            if (tabla.Rows.Count == 0)
            {
                lb_nom_ven.Text = "";
            }
            else
            {
                tb_cod_ven.Text = tabla.Rows[0]["va_cod_ide"].ToString();
                lb_nom_ven.Text = tabla.Rows[0]["va_nom_bre"].ToString();
            }
        }


        //******* DELIVERY *******\\
        private void Bt_bus_del_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_del();
        }
        private void Tb_cod_del_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca bodega
                Fi_abr_bus_del();
            }
        }
        void Fi_abr_bus_del()
        {
            cmr015_01 frm = new cmr015_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_del.Text = frm.tb_sel_bus.Text;
                Fi_obt_del();
            }
        }
        private void Tb_cod_del_Validated(object sender, EventArgs e)
        {
            Fi_obt_del();
        }
        /// <summary>
        /// Obtiene ide y nombre bodega para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_del()
        {
            int val = 0;
            try
            {
                val = int.Parse(tb_cod_del.Text);
            }
            catch (Exception)
            {
                lb_nom_del.Text = "";
                return;
            }

            // Obtiene ide y nombre documento
            tabla = o_cmr015.Fe_con_del(int.Parse(tb_cod_del.Text));
            if (tabla.Rows.Count == 0)
            {
                lb_nom_del.Text = "";
            }
            else
            {
                tb_cod_del.Text = tabla.Rows[0]["va_cod_del"].ToString();
                lb_nom_del.Text = tabla.Rows[0]["va_nom_del"].ToString();
            }
        }


        //******* CLIENTE *******\\
        private void Bt_bus_per_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_per();
        }
        private void Tb_cod_per_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca bodega
                Fi_abr_bus_per();
            }
        }
        void Fi_abr_bus_per()
        {
            adp002_01 frm = new adp002_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_per.Text = frm.tb_cod_per.Text;
                Fi_obt_per();
            }
        }
        private void Tb_cod_per_Validated(object sender, EventArgs e)
        {
            Fi_obt_per();
        }
        /// <summary>
        /// Obtiene ide y nombre bodega para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_per()
        {
            int val = 0;
            try
            {
                val = int.Parse(tb_cod_per.Text);
            }
            catch (Exception)
            {
                lb_raz_soc.Text = "";
                return;
            }

            // Obtiene ide y nombre documento
            tabla = o_adp002.Fe_con_per(int.Parse(tb_cod_per.Text));
            if (tabla.Rows.Count == 0)
            {
                lb_raz_soc.Text = "";
            }
            else
            {
                tb_cod_per.Text = tabla.Rows[0]["va_cod_per"].ToString();
                lb_raz_soc.Text = tabla.Rows[0]["va_raz_soc"].ToString();
            }
        }






       
        //******* TALONARIO *******\\
        private void bt_bus_tal_con_Click(object sender, EventArgs e)
        {
            opc_doc = 1;
            Fi_abr_bus_tal();
        }
        private void tb_nro_tal_con_KeyDown(object sender, KeyEventArgs e)
        {
            opc_doc = 1;
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca bodega
                Fi_abr_bus_tal();
            }
        }
        private void Tb_nro_tal_con_Validated(object sender, EventArgs e)
        {
            opc_doc = 1;
            Fi_obt_tal();
        }

        private void bt_bus_tal_opd_Click(object sender, EventArgs e)
        {
            opc_doc = 2;
            Fi_abr_bus_tal();
        }
        private void tb_nro_tal_opd_KeyDown(object sender, KeyEventArgs e)
        {
            opc_doc = 2;
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca bodega
                Fi_abr_bus_tal();
            }
        }
        private void Tb_nro_tal_opd_Validated(object sender, EventArgs e)
        {
            opc_doc = 2;
            Fi_obt_tal();
        }




        private void bt_bus_tal_nvt_Click(object sender, EventArgs e)
        {
            opc_doc = 3;
            Fi_abr_bus_tal();
        }
        private void tb_nro_tal_nvt_KeyDown(object sender, KeyEventArgs e)
        {
            opc_doc = 3;
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca bodega
                Fi_abr_bus_tal();
            }
        }
        private void Tb_nro_tal_nvt_Validated(object sender, EventArgs e)
        {
            opc_doc = 3;
            Fi_obt_tal();
        }
        private void bt_bus_tal_fac_Click(object sender, EventArgs e)
        {
            opc_doc = 4;
            Fi_abr_bus_tal();
        }
        private void tb_nro_tal_fac_KeyDown(object sender, KeyEventArgs e)
        {
            opc_doc = 4;
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca bodega
                Fi_abr_bus_tal();
            }
        }
        private void Tb_nro_tal_fac_Validated(object sender, EventArgs e)
        {
            opc_doc = 4;
            Fi_obt_tal();
        }
        void Fi_abr_bus_tal()
        {
            // Construye tabla parametros
            tab_prm = new DataTable();
            tab_prm.Columns.Add("va_ide_doc");
            tab_prm.Columns.Add("va_nom_doc");

            tab_prm.Rows.Add();

            switch (opc_doc)
            {
                case 1: // CON
                    tab_prm.Rows[0]["va_ide_doc"] = tb_cod_doc_con.Text;
                    tab_prm.Rows[0]["va_nom_doc"] = "NOTA DE CONSUMO";
                    break;
                case 2: // OPD
                    tab_prm.Rows[0]["va_ide_doc"] = tb_cod_doc_opd.Text;
                    tab_prm.Rows[0]["va_nom_doc"] = "ORDEN DE PRODUCCIÓN";
                    break;
                case 3: // NTV
                    tab_prm.Rows[0]["va_ide_doc"] = tb_cod_doc_nvt.Text;
                    tab_prm.Rows[0]["va_nom_doc"] = "NOTA DE VENTA";
                    break;
                case 4: // FAC
                    tab_prm.Rows[0]["va_ide_doc"] = tb_cod_doc_fac.Text;
                    tab_prm.Rows[0]["va_nom_doc"] = "FACTURA";
                    break;
            }


            ads004_01 frm = new ads004_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si, tab_prm);

            if (frm.DialogResult == DialogResult.OK)
            {
                switch(opc_doc)
                {
                    case 1: // CON
                        tb_nro_tal_con.Text = frm.tb_nro_tal.Text;
                        break;
                    case 2: // OPD
                        tb_nro_tal_opd.Text = frm.tb_nro_tal.Text;
                        break;
                    case 3: // NTV
                        tb_nro_tal_nvt.Text = frm.tb_nro_tal.Text;
                        break;
                    case 4: // FAC
                        tb_nro_tal_fac.Text = frm.tb_nro_tal.Text;
                        break;
                }
               // tb_cod_per.Text = frm.tb_sel_tal.Text;
                Fi_obt_tal();
            }
        }
       
        /// <summary>
        /// Obtiene ide y nombre bodega para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_tal()
        {
            int val = 0;
            string cod_doc = "";

            try
            {
                switch (opc_doc)
                {
                    case 1: // CON
                        val = int.Parse(tb_nro_tal_con.Text);
                        cod_doc = tb_cod_doc_con.Text;
                        break;
                    case 2: // OPD
                        val = int.Parse(tb_nro_tal_opd.Text);
                        cod_doc = tb_cod_doc_opd.Text;
                        break;
                    case 3: // NTV
                        val = int.Parse(tb_nro_tal_nvt.Text);
                        cod_doc = tb_cod_doc_nvt.Text;
                        break;
                    case 4: // FAC
                        val = int.Parse(tb_nro_tal_fac.Text);
                        cod_doc = tb_cod_doc_fac.Text;
                        break;
                }
               
            }
            catch (Exception)
            {
                switch (opc_doc)
                {
                    case 1: // CON
                        tb_nom_tal_con.Text = "";
                        break;
                    case 2: // OPD
                        tb_nom_tal_opd.Text = "";
                        break;
                    case 3: // NTV
                        tb_nom_tal_nvt.Text = "";
                        break;
                    case 4: // FAC
                        tb_nom_tal_fac.Text = "";
                        break;
                }
                return;
            }

            // Obtiene ide y nombre documento
            tabla = new DataTable();
            tabla = o_ads004.Fe_con_tal(cod_doc,val);
            if (tabla.Rows.Count == 0)
            {
                switch (opc_doc)
                {
                    case 1: // CON
                        tb_nom_tal_con.Text = "";
                        break;
                    case 2: // OPD
                        tb_nom_tal_opd.Text = "";
                        break;
                    case 3: // NTV
                        tb_nom_tal_nvt.Text = "";
                        break;
                    case 4: // FAC
                        tb_nom_tal_fac.Text = "";
                        break;
                }
            }
            else
            {
                switch (opc_doc)
                {
                    case 1: // CON
                        tb_nro_tal_con.Text = tabla.Rows[0]["va_nro_tal"].ToString();
                        tb_nom_tal_con.Text = tabla.Rows[0]["va_nom_tal"].ToString();
                        break;
                    case 2: // OPD
                        tb_nro_tal_opd.Text = tabla.Rows[0]["va_nro_tal"].ToString();
                        tb_nom_tal_opd.Text = tabla.Rows[0]["va_nom_tal"].ToString();
                        break;
                    case 3: // NTV
                        tb_nro_tal_nvt.Text = tabla.Rows[0]["va_nro_tal"].ToString();
                        tb_nom_tal_nvt.Text = tabla.Rows[0]["va_nom_tal"].ToString();
                        break;
                    case 4: // FAC
                        tb_nro_tal_fac.Text = tabla.Rows[0]["va_nro_tal"].ToString();
                        tb_nom_tal_fac.Text = tabla.Rows[0]["va_nom_tal"].ToString();
                        break;
                }
               
            }
        }




        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            string msg_val = "";
            DialogResult msg_res;
            int cam_bod = 0, cam_lis = 0, cam_fpg = 0, cam_del = 0,
                img_pro = 0, imp_av1 = 0, imp_av2 = 0;
           
            // funcion para validar datos
            msg_val = Fi_val_dat();
            if (msg_val != "")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Edita Plantilla de venta", MessageBoxButtons.OKCancel);
            if(msg_res== DialogResult.OK)
            {
               

                string variable =  ch_cam_bod.Checked.ToString() ;
                if (ch_cam_bod.Checked == true)
                    cam_bod = 1;
                if (ch_cam_lis.Checked == true)
                    cam_lis = 1;
                if (ch_cam_del.Checked == true)
                    cam_del = 1;
                if (ch_cam_fpg.Checked == true)
                    cam_fpg = 1;
               
                if (ch_img_pro.Checked == true)
                    img_pro = 1; 
                if (ch_imp_av1.Checked == true)
                    imp_av1 = 1;
                if (ch_imp_av2.Checked == true)
                    imp_av2 = 1;


                o_res004.Fe_edi_tar(tb_cod_plv.Text, tb_nom_plv.Text, tb_des_plv.Text, tb_cod_bod.Text, cam_bod.ToString(), tb_cod_per.Text,
                    "0", "0", tb_cod_lis.Text, cam_lis.ToString(), tb_cod_ven.Text, cb_cam_ven.SelectedIndex.ToString(),
                    tb_cod_del.Text, cam_del.ToString(), tb_dia_ret.Text, cb_for_pag.SelectedIndex.ToString(), cam_fpg.ToString(),
                    "0", "2", "0", "0", cb_bus_pro.SelectedIndex.ToString(), img_pro.ToString(),
                    tb_cod_doc_fac.Text, tb_nro_tal_fac.Text, tb_cod_doc_nvt.Text, tb_nro_tal_nvt.Text, tb_cod_doc_opd.Text, tb_nro_tal_opd.Text,
                    tb_cod_doc_con.Text, tb_nro_tal_con.Text, "", "0", "", "0",
                    tb_imp_fac.Text, tb_imp_nvt.Text, tb_imp_opd.Text, tb_imp_con.Text, "", "", imp_av1.ToString(), tb_imp_av1.Text,
                    imp_av2.ToString(), tb_imp_av2.Text, "2");

                frm_pad.Fe_act_frm(int.Parse(tb_cod_plv.Text));

                MessageBox.Show("Los datos se Editaron satisfactoriamente", "Edita Plantilla de venta", MessageBoxButtons.OK);

                cl_glo_frm.Cerrar(this);
            
            }

          

        }

        private void bt_bus_imp_con_Click(object sender, EventArgs e)
        {
            ads000_12 frm = new ads000_12();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);
            if (frm.DialogResult == DialogResult.OK)
            {
                tb_imp_con.Text = frm.dg_res_ult.Rows[frm.dg_res_ult.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
        }
        private void bt_bus_imp_opd_Click(object sender, EventArgs e)
        {
            ads000_12 frm = new ads000_12();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);
            if (frm.DialogResult == DialogResult.OK)
            {
                tb_imp_opd.Text = frm.dg_res_ult.Rows[frm.dg_res_ult.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
        }
        private void bt_bus_imp_nvt_Click(object sender, EventArgs e)
        {
            ads000_12 frm = new ads000_12();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);
            if (frm.DialogResult == DialogResult.OK)
            {
                tb_imp_nvt.Text = frm.dg_res_ult.Rows[frm.dg_res_ult.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void bt_bus_imp_fac_Click(object sender, EventArgs e)
        {
            ads000_12 frm = new ads000_12();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);
            if (frm.DialogResult == DialogResult.OK)
            {
                tb_imp_fac.Text = frm.dg_res_ult.Rows[frm.dg_res_ult.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void bt_bus_imp_av1_Click(object sender, EventArgs e)
        {
            ads000_12 frm = new ads000_12();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);
            if (frm.DialogResult == DialogResult.OK)
            {
                tb_imp_av1.Text = frm.dg_res_ult.Rows[frm.dg_res_ult.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void bt_bus_imp_av2_Click(object sender, EventArgs e)
        {
            ads000_12 frm = new ads000_12();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);
            if (frm.DialogResult == DialogResult.OK)
            {
                tb_imp_av2.Text = frm.dg_res_ult.Rows[frm.dg_res_ult.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void ch_imp_av1_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_imp_av1.Checked == true)
            {
                bt_bus_imp_av1.Enabled = true;
                tb_imp_av1.Enabled = true;
            }
            if (ch_imp_av1.Checked == false)
            {
                bt_bus_imp_av1.Enabled = false;
                tb_imp_av1.Enabled = false ;
            }
            
        }

        private void ch_imp_av2_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_imp_av2.Checked == true)
            {
                bt_bus_imp_av2.Enabled = true;
                tb_imp_av2.Enabled = true;
            }
            if (ch_imp_av2.Checked == false)
            {
                bt_bus_imp_av2.Enabled = false;
                tb_imp_av1.Enabled = false;
            }
        }

        private void tc_pla_vta_Selected(object sender, TabControlEventArgs e)
        {
            //Obtiene codigo, nombre y descripcion dela plantilla
            if (e.TabPageIndex == 1)
            {
                tb_cod_plv_2.Text = tb_cod_plv.Text;
                tb_nom_plv_2.Text = tb_nom_plv.Text;
                tb_des_plv_2.Text = tb_des_plv.Text;
                
            }
            if (e.TabPageIndex == 0)
            {
                tb_cod_plv.Text = tb_cod_plv_2.Text;
                tb_nom_plv.Text = tb_nom_plv_2.Text;
                tb_des_plv.Text = tb_des_plv_2.Text;
 
            }
        }
    }
}
