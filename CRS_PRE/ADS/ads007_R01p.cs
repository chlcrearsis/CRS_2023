﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads007 - Usuario                                      */
    /*      Opción: Informe R01 - Parametros                              */
    /*       Autor: JEJR - Crearsis             Fecha: 07-08-2023         */
    /**********************************************************************/
    public partial class ads007_R01p : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        // Instancia        
        ads007 o_ads007 = new ads007();
        ads019 o_ads019 = new ads019();
        DataTable Tabla = new DataTable();

        public ads007_R01p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            // Desplega Información inicial            
            cb_est_ado.SelectedIndex = 0;
            rb_ord_cod.Checked = true;
            rb_ord_nom.Checked = false;
        }

        // Valida los datos de pantalla
        protected string Fi_val_dat()
        {
            try
            {
                return "OK";
            }
            catch (Exception)
            {
                return "Los datos proporcionados NO pasaron el proceso de validación.";
            }
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            // funcion para validar datos
            string est_ado = "";
            string ord_dat = "";
            string msg_val = Fi_val_dat();

            if (msg_val != "OK")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }

            // Obtiene el estado del reporte
            if (cb_est_ado.SelectedIndex == 0)
                est_ado = "T";
            if (cb_est_ado.SelectedIndex == 1)
                est_ado = "H";
            if (cb_est_ado.SelectedIndex == 2)
                est_ado = "N";

            // Obtiene el criterio de ordenamiento
            if (rb_ord_cod.Checked)
                ord_dat = "C";
            if (rb_ord_nom.Checked)
                ord_dat = "N";

            // Obtiene Datos
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_inf_R01(est_ado, ord_dat);

            // Graba Bitacora de Operaciones
            o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "I", "", SystemInformation.ComputerName);

            // Genera el Informe
            ads007_R01w frm = new ads007_R01w();
            frm.vp_est_ado = est_ado;
            frm.vp_ord_dat = ord_dat;
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, Tabla);
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            // Cierra Formulario
            cl_glo_frm.Cerrar(this);
        }
    }
}
