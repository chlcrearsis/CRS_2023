using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads018 - Bitacora de Inicio de Sesion                 */
    /*      Opción: Informe R04 - Parametros                              */
    /*       Autor: JEJR - Crearsis             Fecha: 10-01-2024         */
    /**********************************************************************/
    public partial class ads018_R01p : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancia
        private DataTable Tabla;        
        private ads007 o_ads007 = new ads007();
        private ads018 o_ads018 = new ads018();

        public ads018_R01p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            // Desplega Información Usuario Inicial y Final         
            tb_usr_ini.Text = "";
            lb_nus_ini.Text = "...";
            tb_usr_fin.Text = "";            
            lb_nus_fin.Text = "...";
            tb_fec_ini.Text = "";
            tb_fec_fin.Text = "";

            // Desplega Información Usuario Inicial y Final         
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_lis_usr("H");
            if (Tabla.Rows.Count > 0){
                tb_usr_ini.Text = Tabla.Rows[0]["va_ide_usr"].ToString();
                lb_nus_ini.Text = Tabla.Rows[0]["va_nom_usr"].ToString();
                tb_usr_fin.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_ide_usr"].ToString();
                lb_nus_fin.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_nom_usr"].ToString();
            }            
        }

        // Valida los datos de pantalla
        protected string Fi_val_dat()
        {
            try
            {
                // Valida que el Usuario Inicial no esten vacio
                if (tb_usr_ini.Text.Trim().CompareTo("") == 0){
                    return "DEBE proporcionar el Usuario Inicial";
                }

                // Valida que el Usuario Inicial no esten vacio
                if (tb_usr_fin.Text.Trim().CompareTo("") == 0){
                    return "DEBE proporcionar el Usuario Final";
                }

                // Verifica si existe el Usuario Inicial
                Tabla = new DataTable();
                Tabla = o_ads007.Fe_con_ide(tb_usr_ini.Text.Trim());
                if (Tabla.Rows.Count == 0){
                    return "El Usuario Inicial NO esta registrado en el sistema";
                }

                // Verifica si existe el Usuario Final
                Tabla = new DataTable();
                Tabla = o_ads007.Fe_con_ide(tb_usr_fin.Text.Trim());
                if (Tabla.Rows.Count == 0){
                    return "El Usuario Final NO esta registrado en el sistema";
                }

                // Valida que el campo Fecha Inicial NO este vacio
                if (tb_fec_ini.Text.Trim() == "  /  /" ||
                    tb_fec_ini.Text.Trim() == "00/00/0000"){
                    tb_fec_ini.Focus();
                    return "DEBE proporcionar la Fecha Inicial";
                }

                // Valida que el campo Fecha Final NO este vacio
                if (tb_fec_fin.Text.Trim() == "  /  /" ||
                    tb_fec_fin.Text.Trim() == "00/00/0000"){
                    tb_fec_fin.Focus();
                    return "DEBE proporcionar la Fecha Final";
                }

                // Valida que la Fecha Inicial sea una fecha válida
                if (!cl_glo_bal.IsDateTime(tb_fec_ini.Text.Trim())){
                    tb_fec_ini.Focus();
                    return "La Fecha Inicial proporcionada NO es valido";
                }

                // Valida que la Fecha Final sea una fecha válida
                if (!cl_glo_bal.IsDateTime(tb_fec_fin.Text.Trim())){
                    tb_fec_fin.Focus();
                    return "La Fecha Final proporcionada NO es valido";
                }

                // Valida que la Fecha Inicial sea MAYOR a la Fecha Final
                if (DateTime.Parse(tb_fec_ini.Text) > DateTime.Parse(tb_fec_fin.Text)){
                    tb_fec_fin.Focus();
                    return "La Fecha Final DEBE ser MAYOR a la Fecha Inicial";
                }

                return "OK";
            }
            catch (Exception)
            {
                return "Los datos proporcionados NO pasaron el proceso de validación.";
            }
        }

        /// <summary>
        /// Obtiene el nombre del Usuario
        /// </summary>
        void Fi_obt_usr(int ini_fin, string ide_usr)
        {
            // Obtiene y Desplega datos del Módulo
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_con_ide(ide_usr);
            if (Tabla.Rows.Count == 0){
                if (ini_fin == 1)
                    lb_nus_ini.Text = "...";
                else
                    lb_nus_fin.Text = "...";
            }else{
                if (ini_fin == 1)
                    lb_nus_ini.Text = Tabla.Rows[0]["va_nom_usr"].ToString();
                else
                    lb_nus_fin.Text = Tabla.Rows[0]["va_nom_usr"].ToString();
            }
        }       

        /// <summary>
        /// Función: Abre Formulario para Buscar el Usuario
        /// </summary>
        /// <param name="ini_fin">1=Usuario Inicial; 2=Usuario Final</param>
        private void Fi_bus_usr(int ini_fin)
        {
            ads007_01b frm = new ads007_01b();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                if (ini_fin == 1){
                    tb_usr_ini.Text = frm.tb_ide_usr.Text;
                    Fi_obt_usr(1, tb_usr_ini.Text.Trim());
                }else{
                    tb_usr_fin.Text = frm.tb_ide_usr.Text;
                    Fi_obt_usr(2, tb_usr_fin.Text.Trim());
                }
            }
        }                     

        // Evento KeyDown: Usuario Inicial
        private void tb_usr_ini_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up){
                // Abre la ventana Busca Módulo
                Fi_bus_usr(1);
            }
        }

        // Evento KeyDown: Usuario Final
        private void tb_usr_fin_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up){
                // Abre la ventana Busca Módulo
                Fi_bus_usr(2);
            }
        }     

        // Evento Leave: Usuario Inicial
        private void tb_usr_ini_Leave(object sender, EventArgs e)
        {
            // Obtiene el Usuario Inicial
            if (tb_usr_ini.Text.Trim().CompareTo("") != 0)
                Fi_obt_usr(1, tb_usr_ini.Text.Trim());
        }

        // Evento Leave: Usuario Final
        private void tb_usr_fin_Leave(object sender, EventArgs e)
        {
            // Obtiene el Usuario Inicial
            if (tb_usr_ini.Text.Trim().CompareTo("") != 0)
                Fi_obt_usr(2, tb_usr_ini.Text.Trim());
        }        

        // Evento Click: Button Usuario Inicial
        private void bt_usr_ini_Click(object sender, EventArgs e)
        {
            Fi_bus_usr(1);
        }

        // Evento Click: Button Usuario Final
        private void bt_usr_fin_Click(object sender, EventArgs e)
        {
            Fi_bus_usr(2);
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
            
            // Obtiene Datos
            Tabla = new DataTable();
            Tabla = o_ads018.Fe_inf_R01(tb_usr_ini.Text.Trim(), tb_usr_fin.Text.Trim(), tb_fec_ini.Text.Trim(), tb_fec_fin.Text.Trim());

            // Genera el Informe
            ads018_R01w frm = new ads018_R01w{
                vp_usr_ini = tb_usr_ini.Text.Trim(),
                vp_usr_fin = tb_usr_fin.Text.Trim(),
                vp_fec_ini = tb_fec_ini.Text.Trim(),
                vp_fec_fin = tb_fec_fin.Text.Trim(),
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
