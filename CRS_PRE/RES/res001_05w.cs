﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRS_NEG;
using CRS_PRE;
using CRS_PRE.RES;
//using CRS_PRE.RES;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace CRS_PRE
{
    public partial class res001_05w : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        res001 o_res001 = new res001();
        ads016 o_ads016 = new ads016();
        ads013 o_ads013 = new ads013();
        ads004 o_ads004 = new ads004();

        DataTable tabla = new DataTable();
        DataTable tab_not_vta = new DataTable(); 
        DataTable tab_ads013 = new DataTable();
        DataTable tab_ads004 = new DataTable();

        string va_nom_emp="";
        string va_dir_emp = "";
        string va_tel_emp = "";
        string va_cla_wif = "";

        string va_ide_vta = "";
        int va_ges_vta = 0;

        ReportDocument rd_con_vta = new ReportDocument();


        int va_nro_pag;
        public res001_05w()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            Fe_pob_rep();
        }

        public void Fe_pob_rep()
        {
            va_ide_vta = frm_dat.Rows[0]["va_ide_vta"].ToString();
            va_ges_vta = int.Parse(frm_dat.Rows[0]["va_ges_vta"].ToString());

            // Obtiene datos de la factura
            tabla = o_res001.Fe_con_vta(va_ide_vta, va_ges_vta);


            // ** OBTIENE DATOS DE LA NOTA DE VENTA **\\
            //tab_not_vta = o_res001.Fe_con_vta(va_ide_vta, va_ges_vta);

            // Hacer grande la pantalla
            Dock = DockStyle.Fill;

            //obtener nombre de la empresa
            tab_ads013 = o_ads013.Fe_obt_glo(1, 1);
            va_nom_emp = tab_ads013.Rows[0]["va_glo_car"].ToString();

            //obtener direccion de la empresa
            tab_ads013 = new DataTable();
            tab_ads013 = o_ads013.Fe_obt_glo(1, 7);
            va_dir_emp = tab_ads013.Rows[0]["va_glo_car"].ToString();
            
            //obtener Telefono de la empresa
            tab_ads013 = new DataTable();
            tab_ads013 = o_ads013.Fe_obt_glo(1, 4);
            va_tel_emp = tab_ads013.Rows[0]["va_glo_car"].ToString();


            //obtener WIFI de la empresa
            tab_ads013 = new DataTable();
            tab_ads013 = o_ads013.Fe_obt_glo(1, 8);
            va_cla_wif = tab_ads013.Rows[0]["va_glo_car"].ToString();
           
            // ** SELECCION DE FORMATO DE IMPRESION DEL DOCUMENTO NOTA DE VENTA ** \\
            switch (int.Parse(tabla.Rows[0]["va_for_mat"].ToString()))
            {
                case 0: // Nota de venta en rollo
                    rd_con_vta = res001_05a_p01;
                    break;
                case 1:
                    rd_con_vta = res001_05a_p01;
                    break;
                default:
                    rd_con_vta = res001_05a_p02;
                    break;
            }


            cr_rep_ort.ReportSource = rd_con_vta;

            //Logueo manual el ReportDocument asociado al crystal report
            rd_con_vta.SetDatabaseLogon(Program.gl_ide_usr, Program.gl_pas_usr, Program.gl_ser_bdo + "\\" + Program.gl_ins_bdo, Program.gl_nom_bdo);


            // Paso los datos obtenidos del procedimiento en la anterior ventana
            rd_con_vta.SetDataSource(tabla);
            // Para enviar parametros directos al reporte (nombre del parametro en crystal report, valor que se enviara)
            rd_con_vta.SetParameterValue("vc_ide_usr", Program.gl_ide_usr);
            rd_con_vta.SetParameterValue("vc_nom_emp", va_nom_emp);
            rd_con_vta.SetParameterValue("vc_dir_emp", va_dir_emp);
            rd_con_vta.SetParameterValue("vc_tel_emp", va_tel_emp);
            rd_con_vta.SetParameterValue("vc_cla_wif", va_cla_wif);

            // Obtiene nro de paginas
            va_nro_pag = cr_rep_ort.GetCurrentPageNumber();
        }

        public void Fe_imp_doc(string cod_doc, int nro_tal,string nom_imp,int nro_cop)
        {

            //** Obtiene numero de compias a imprimir
            //tab_ads004 = o_ads004.Fe_con_tal(cod_doc, nro_tal);
            //nro_cop = int.Parse(tab_ads004.Rows[0]["va_nro_cop"].ToString());

            rd_con_vta.PrintOptions.PrinterName = nom_imp;
            rd_con_vta.PrintToPrinter(1, false, 0, 0);

            for (int i = 0; i < nro_cop; i++)
            {
                rd_con_vta.PrintToPrinter(1, false, 0, 0);
            }
        }



        private void Mn_imp_rim_Click(object sender, EventArgs e)
        {
            cr_rep_ort.PrintReport();
        }

        private void Mn_exp_ort_Click(object sender, EventArgs e)
        {
           // ExportOptions exp_opc = new ExportOptions();
            
            cr_rep_ort.ExportReport();
        }

        private void Mn_bus_car_Click(object sender, EventArgs e)
        {
            ads000_10 frm = new ads000_10();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.no);

        }
        // Funcion activada desde Formulario: ads000_10 (buscar texto en reporte)
        public void Fe_bus_txt(string ar_bus_txt)
        {
            cr_rep_ort.SearchForText(ar_bus_txt);
        }

        private void Mn_zoo_anc_Click(object sender, EventArgs e)
        {
            cr_rep_ort.Zoom(200);
        }

        private void Mn_zoo_tod_Click(object sender, EventArgs e)
        {
            cr_rep_ort.Zoom(200);

        }

        private void Mn_zoo_200_Click(object sender, EventArgs e)
        {
            cr_rep_ort.Zoom(200);
        }

        private void Mn_zoo_150_Click(object sender, EventArgs e)
        {
            cr_rep_ort.Zoom(150);
        }

        private void Mn_zoo_100_Click(object sender, EventArgs e)
        {
            cr_rep_ort.Zoom(100);
        }

        private void Mn_zoo_075_Click(object sender, EventArgs e)
        {
            cr_rep_ort.Zoom(75);
        }

        private void Mn_zoo_025_Click(object sender, EventArgs e)
        {
            cr_rep_ort.Zoom(25);
        }

        private void Mn_pri_pag_Click(object sender, EventArgs e)
        {
            cr_rep_ort.ShowFirstPage();
            mn_nro_pag.Text = cr_rep_ort.GetCurrentPageNumber().ToString();
        }

        private void Mn_ant_pag_Click(object sender, EventArgs e)
        {
            cr_rep_ort.ShowPreviousPage();
            mn_nro_pag.Text = cr_rep_ort.GetCurrentPageNumber().ToString();
        }

        private void Mn_sig_pag_Click(object sender, EventArgs e)
        {
            cr_rep_ort.ShowNextPage();
            mn_nro_pag.Text = cr_rep_ort.GetCurrentPageNumber().ToString();
        }

        private void Mn_ult_pag_Click(object sender, EventArgs e)
        {
            cr_rep_ort.ShowLastPage();
            mn_nro_pag.Text = cr_rep_ort.GetCurrentPageNumber().ToString();
        }

        private void Mn_nro_pag_Leave(object sender, EventArgs e)
        {
            cr_rep_ort.ShowNthPage(int.Parse(mn_nro_pag.Text));
            mn_nro_pag.Text = cr_rep_ort.GetCurrentPageNumber().ToString();
        }

        private void Mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

    }
}
