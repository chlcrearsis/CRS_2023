using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads019 - Bitacora de Operaciones                      */
    /*      Opción: Informe R01 - Parametros                              */
    /*       Autor: JEJR - Crearsis             Fecha: 09-02-2024         */
    /**********************************************************************/
    public partial class ads019_R01p : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancia
        ads001 o_ads001 = new ads001();
        ads019 o_ads019 = new ads019();
        DataTable Tabla = new DataTable();

        public ads019_R01p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            // Desplega Información Usuario Inicial y Final         
            tb_apl_ini.Text = "AAAAAAA";
            tb_apl_fin.Text = "ZZZZZZZ";
            tb_fch_ini.Text = "";
            tb_fch_fin.Text = "";

            // Crea Todos los Tipo de Operacion         
            Tabla = new DataTable();
            Tabla.Columns.Add("va_ide_ope");
            Tabla.Columns.Add("va_nom_ope");
            Tabla.Rows.Add("T", "Todos");
            Tabla.Rows.Add("N", "Nuevo");
            Tabla.Rows.Add("E", "Edita");
            Tabla.Rows.Add("A", "Anula");
            Tabla.Rows.Add("C", "Concluye");
            Tabla.Rows.Add("L", "Elimina");
            Tabla.Rows.Add("P", "Aprueba");
            Tabla.Rows.Add("R", "Rechaza");
            Tabla.Rows.Add("M", "Impota");
            Tabla.Rows.Add("X", "Exporta");
            Tabla.Rows.Add("I", "Informe");

            // Carga los Tipos de Operacion a la lista
            cb_tip_ope.Items.Clear();
            cb_tip_ope.DataSource = Tabla;
            cb_tip_ope.ValueMember = "va_ide_ope";
            cb_tip_ope.DisplayMember = "va_nom_ope";
            cb_tip_ope.SelectedIndex = 0;           
        }

        // Funcion: Buscar Módulo
        private void Fi_bus_mod()
        {
            ads001_01 frm = new ads001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_ide_mod.Text = frm.tb_ide_mod.Text;
                Fi_obt_mod();
            }
        }

        /// <summary>
        /// Obtiene datos del Módulo
        /// </summary>
        private void Fi_obt_mod()
        {
            if (tb_ide_mod.Text.Trim().CompareTo("") == 0)
                return;

            // Obtiene y desplega datos del Módulo
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(int.Parse(tb_ide_mod.Text));
            if (Tabla.Rows.Count == 0)            
                lb_nom_mod.Text = "...";            
            else{
                tb_ide_mod.Text = Tabla.Rows[0]["va_ide_mod"].ToString();
                lb_nom_mod.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
            }
        }

        // Valida los datos de pantalla
        protected string Fi_val_dat()
        {
            try
            {
                // Valida que el ID. Módulo no esten vacio
                if (tb_ide_mod.Text.Trim().CompareTo("") == 0 || 
                    tb_ide_mod.Text.Trim().CompareTo("0") == 0){
                    tb_ide_mod.Focus();
                    return "DEBE proporcionar el ID. Módulo";
                }

                // Valida que la Aplicación Inicial no esten vacio
                if (tb_apl_ini.Text.Trim().CompareTo("") == 0){
                    tb_apl_ini.Focus();
                    return "DEBE proporcionar la Aplicación Inicial";
                }

                // Valida que la Aplicación Inicial no esten vacio
                if (tb_apl_fin.Text.Trim().CompareTo("") == 0){
                    tb_apl_fin.Focus();
                    return "DEBE proporcionar la Aplicación Final";
                }                

                // Valida que el campo Fecha Inicial NO este vacio
                if (tb_fch_ini.Text.Trim() == "  /  /" ||
                    tb_fch_ini.Text.Trim() == "00/00/0000"){
                    tb_fch_ini.Focus();
                    return "DEBE proporcionar la Fecha Inicial";
                }

                // Valida que el campo Fecha Final NO este vacio
                if (tb_fch_fin.Text.Trim() == "  /  /" ||
                    tb_fch_fin.Text.Trim() == "00/00/0000"){
                    tb_fch_fin.Focus();
                    return "DEBE proporcionar la Fecha Final";
                }

                // Valida que la Fecha Inicial sea una fecha válida
                if (!cl_glo_bal.IsDateTime(tb_fch_ini.Text.Trim())){
                    tb_fch_ini.Focus();
                    return "La Fecha Inicial proporcionada NO es valido";
                }

                // Valida que la Fecha Final sea una fecha válida
                if (!cl_glo_bal.IsDateTime(tb_fch_fin.Text.Trim())){
                    tb_fch_fin.Focus();
                    return "La Fecha Final proporcionada NO es valido";
                }

                // Valida que la Fecha Inicial sea MAYOR a la Fecha Final
                if (DateTime.Parse(tb_fch_ini.Text) > DateTime.Parse(tb_fch_fin.Text)){
                    tb_fch_fin.Focus();
                    return "La Fecha Final DEBE ser MAYOR a la Fecha Inicial";
                }

                return "OK";
            }
            catch (Exception)
            {
                return "Los datos proporcionados NO pasaron el proceso de validación.";
            }
        }

        // Evento Validated : ID. Módulo
        private void tb_ide_mod_Validated(object sender, EventArgs e)
        {
            Fi_obt_mod();
        }

        // Evento KeyPress : ID. Módulo
        private void tb_ide_mod_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyDown : ID. Módulo
        private void tb_ide_mod_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Módulo
                Fi_bus_mod();
            }
        }

        // Evento Click: Button Buscar Módulo
        private void bt_bus_mod_Click(object sender, EventArgs e)
        {
            // Abre la ventana Busca Modulo
            Fi_bus_mod();
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            // funcion para validar datos            
            string msg_val = Fi_val_dat();

            if (msg_val != "OK"){
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }

            // Graba Bitacora de Operaciones
            o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "I", "", SystemInformation.ComputerName);

            // Obtiene Datos
            Tabla = new DataTable();
            Tabla = o_ads019.Fe_inf_R01(int.Parse(tb_ide_mod.Text.Trim()), tb_apl_ini.Text.Trim(), tb_apl_fin.Text.Trim(), tb_fch_ini.Text.Trim(), tb_fch_fin.Text.Trim(), cb_tip_ope.SelectedValue.ToString());            

            // Genera el Informe
            ads019_R01w frm = new ads019_R01w{
                vp_apl_ini = tb_apl_ini.Text.Trim(),
                vp_apl_fin = tb_apl_fin.Text.Trim(),
                vp_fch_ini = tb_fch_ini.Text.Trim(),
                vp_fch_fin = tb_fch_fin.Text.Trim(),
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
