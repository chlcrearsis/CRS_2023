using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads003 - Definición de Documento                      */
    /*      Opción: Crear Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 22-08-2022         */
    /**********************************************************************/
    public partial class ads003_02b : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias
        ads003 o_ads003 = new ads003();
        ads019 o_ads019 = new ads019();
        DataTable Tabla = new DataTable();

        public ads003_02b()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
          

        }             

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {            
            // Verifica SI existe documentos registrado en el sistema
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_lis_doc("0");
            if (Tabla.Rows.Count > 0)
                return "No se puede realizar esta operación. Existe documento registrado en el Sistema";
                     
            return "OK";
        }

              
        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult msg_res;

                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "OK")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", Text, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {
                    // Graba Registro p/Defectos 
                    o_ads003.Fe_reg_doc();
                    // Graba Bitacora de Operaciones
                    o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "N", "Documentos p/Defectos", SystemInformation.ComputerName);
                    // Inicializa el Formulario Principal
                    frm_pad.fi_ini_frm();
                    // Despliega Mensaje
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK);
                    // Cierra Formulario
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }        
    }
}
