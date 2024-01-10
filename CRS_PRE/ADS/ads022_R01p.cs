using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads022 - Tasa de Cambio Bs/Us                         */
    /*      Opción: Informe R01 - Parametros                              */
    /*       Autor: JEJR - Crearsis             Fecha: 02-01-2024         */
    /**********************************************************************/
    public partial class ads022_R01p : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancia
        private DataTable Tabla;
        private ads022 o_ads022 = new ads022();

        public ads022_R01p()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Inicializa Datos 
            tb_fec_ini.Text = string.Empty;
            tb_fec_fin.Text = string.Empty;
            tb_fec_ini.Focus();
        }

        // Valida datos proporcionado en pantalla
        protected string Fi_val_dat()
        {
            try
            {
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
            catch (Exception) {
                return "Los datos proporcionados NO pasaron el proceso de validación.";
            }            
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            // funcion para validar datos
            string fec_ini = tb_fec_ini.Text.Trim();
            string fec_fin = tb_fec_fin.Text.Trim();
            string msg_val = Fi_val_dat();

            if (msg_val != "OK")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }            

            // Obtiene Datos
            Tabla = new DataTable();
            Tabla = o_ads022.Fe_inf_R01(fec_ini, fec_fin);

            // Genera el Informe
            ads022_R01w frm = new ads022_R01w{
                vp_fec_ini = fec_ini,
                vp_fec_fin = fec_fin
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
