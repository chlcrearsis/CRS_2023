﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads002 - Aplicación del Sistema                       */
    /*      Opción: Informe R01 - Parametros                              */
    /*       Autor: JEJR - Crearsis             Fecha: 20-04-2023         */
    /**********************************************************************/
    public partial class ads002_R01p : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias
        ads001 o_ads001 = new ads001();
        ads002 o_ads002 = new ads002();
        ads019 o_ads019 = new ads019();
        DataTable Tabla = new DataTable();

        public ads002_R01p()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {     
            // Desplega Información inicial
            tb_mod_ini.Text = string.Empty;
            tb_mod_fin.Text = string.Empty;
            lb_nmo_ini.Text = string.Empty;
            lb_nmo_fin.Text = string.Empty;
            cb_est_ado.SelectedIndex = 0;

            // Obtiene y Desplega el tipo de atributo inicial y final
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_lis_mod("H");
            if (Tabla.Rows.Count > 0){
                // Obtiene el Tipo de Atributo Inicial
                tb_mod_ini.Text = Tabla.Rows[0]["va_ide_mod"].ToString().Trim();
                lb_nmo_ini.Text = Tabla.Rows[0]["va_nom_mod"].ToString().Trim();
                // Obtiene el Tipo de Atributo Final
                tb_mod_fin.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_ide_mod"].ToString().Trim();
                lb_nmo_fin.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_nom_mod"].ToString().Trim();
            }else {
                // Obtiene el Tipo de Atributo Inicial
                tb_mod_ini.Text = "0";
                lb_nmo_ini.Text = "Módulo Inicial";
                // Obtiene el Tipo de Atributo Final
                tb_mod_fin.Text = "99";
                lb_nmo_fin.Text = "Módulo Final";
            }
        }

        /// <summary>
        /// Valida Datos
        /// </summary>
        /// <returns></returns>
        protected string Fi_val_dat()
        {
            try
            {
                // Verificar el Módulo Inicial sea distinto a vacio
                if (tb_mod_ini.Text.Trim().CompareTo("") == 0){
                    tb_mod_ini.Focus();
                    return "DEBE proporcionar el Módulo Inicial";
                }

                // Verifica que el ID. Módulo Inicial sea numerico
                if (!cl_glo_bal.IsNumeric(tb_mod_ini.Text.Trim())){
                    tb_mod_ini.Focus();
                    return "El ID. Módulo Inicial DEBE ser Numerico";
                }

                // Valida que el modulo Inicial este registrada
                if (tb_mod_ini.Text.Trim().CompareTo("0") != 0){
                    Tabla = new DataTable();
                    Tabla = o_ads001.Fe_con_mod(int.Parse(tb_mod_ini.Text));
                    if (Tabla.Rows.Count == 0){
                        tb_mod_ini.Focus();
                        return "La Módulo Inicial NO se encuentra registrado";
                    }
                }

                // Verificar el Módulo Final sea distinto a vacio
                if (tb_mod_fin.Text.Trim().CompareTo("") == 0){
                    tb_mod_fin.Focus();
                    return "DEBE proporcionar el Módulo Final";
                }

                // Verifica que el ID. Módulo Final sea numerico
                if (!cl_glo_bal.IsNumeric(tb_mod_fin.Text.Trim())){
                    tb_mod_fin.Focus();
                    return "El ID. Módulo Final DEBE ser Numerico";
                }

                // Valida que el modulo Final este registrada
                if (tb_mod_fin.Text.Trim().CompareTo("0") != 0){
                    Tabla = new DataTable();
                    Tabla = o_ads001.Fe_con_mod(int.Parse(tb_mod_fin.Text));
                    if (Tabla.Rows.Count == 0){
                        tb_mod_fin.Focus();
                        return "La Módulo Final NO se encuentra registrado";
                    }
                }

                // Valida que el Módulo Inicial sea MENOR que el Módulo Final
                if (int.Parse(tb_mod_ini.Text) > int.Parse(tb_mod_fin.Text)) {
                    tb_mod_ini.Focus();
                    return "El Módulo Inicial DEBE ser menor al Módulo Final";
                }

                return "OK";
            }
            catch (Exception)
            {
                return "Los datos proporcionados NO pasaron el proceso de validación.";
            }
        }

        /// <summary>
        /// Obtiene el nombre del Módulo
        /// </summary>
        void Fi_obt_mod(int ini_fin, int ide_mod)
        {
            // Obtiene y Desplega datos del Módulo
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(ide_mod);
            if (Tabla.Rows.Count == 0){
                if (ini_fin == 1)
                    lb_nmo_ini.Text = "...";
                else
                    lb_nmo_fin.Text = "...";
            }else{
                if (ini_fin == 1)
                    lb_nmo_ini.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
                else
                    lb_nmo_fin.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
            }
        }

        /// <summary>
        /// Función: Abre Formulario para Buscar el Módulo
        /// </summary>
        /// <param name="ini_fin">1=Modulo Inicial; 2=Módulo Final</param>
        private void Fi_bus_mod(int ini_fin)
        {
            ads001_01 frm = new ads001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                if (ini_fin == 1)
                {
                    tb_mod_ini.Text = frm.tb_ide_mod.Text;
                    Fi_obt_mod(1, int.Parse(tb_mod_ini.Text));
                }
                else
                {
                    tb_mod_fin.Text = frm.tb_ide_mod.Text;
                    Fi_obt_mod(2, int.Parse(tb_mod_fin.Text));
                }
            }
        }

        // Evento KeyDown: ID. Módulo Inicial
        private void tb_mod_ini_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Usuario
                Fi_bus_mod(1);
            }
        }

        // Evento KeyDown: ID. Módulo Final
        private void tb_mod_fin_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Usuario
                Fi_bus_mod(2);
            }
        }

        // Evento Leave: ID. Módulo Inicial
        private void tb_mod_ini_Leave(object sender, EventArgs e)
        {
            // Obtiene el Tipo de Atributo Inicial           
            Fi_obt_mod(1, int.Parse(tb_mod_ini.Text));
        }

        // Evento Leave: ID. Módulo Final
        private void tb_mod_fin_Leave(object sender, EventArgs e)
        {
            Fi_obt_mod(2, int.Parse(tb_mod_fin.Text));
        }

        // Evento Click: Button Módulo Inicial
        private void bt_mod_ini_Click(object sender, EventArgs e)
        {
            Fi_bus_mod(1);
        }

        // Evento Click: Button Módulo Final
        private void bt_mod_fin_Click(object sender, EventArgs e)
        {
            Fi_bus_mod(2);
        }                

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            // funcion para validar datos
            string msg_val = Fi_val_dat();
            string est_ado = "";            

            if (msg_val != "OK")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }

            // Obtiene parametros de pantalla
            int mod_ini = int.Parse(tb_mod_ini.Text);
            int mod_fin = int.Parse(tb_mod_fin.Text);

            // Obtiene el estado del reporte
            if (cb_est_ado.SelectedIndex == 0)
                est_ado = "T";
            if (cb_est_ado.SelectedIndex == 1)
                est_ado = "H";
            if (cb_est_ado.SelectedIndex == 2)
                est_ado = "N";

            // Obtiene Datos
            Tabla = new DataTable();
            Tabla = o_ads002.Fe_inf_R01(est_ado, mod_ini, mod_fin);

            // Graba Bitacora de Operaciones
            o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "I", "", SystemInformation.ComputerName);

            // Genera el Informe
            ads002_R01w frm = new ads002_R01w{
                vp_est_ado = est_ado,
                vp_mod_ini = mod_ini,
                vp_mod_fin = mod_fin
            };
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
