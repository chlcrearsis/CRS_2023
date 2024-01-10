using ClosedXML.Excel;
using CRS_NEG;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads023 - Tasa de Cambio Bs/Ufv                        */
    /*      Opción: Importa Tasa de Cambio Bs/Ufv desde Excel             */
    /*       Autor: JEJR - Crearsis             Fecha: 09-01-2024         */
    /**********************************************************************/
    public partial class ads023_09 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancia
        private DataTable Tabla;
        private ads023 o_ads023 = new ads023();
        private General general = new General();

        public ads023_09()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Establece datos por defectos 
            tb_dir_arc.Text = string.Empty;
            tb_con_err.Text = "...";
            tb_sin_err.Text = "...";
            tb_tot_reg.Text = "...";
        }

        // Valida los datos de pantalla
        protected string Fi_val_dat()
        {
            try
            {
                // Valida que el campo Fecha Inicial NO este vacio
                if (dg_res_ult.Rows.Count == 0)
                    return "No hay ningún registro para importar";                

                // Valida que el campo Fecha Final NO este vacio
                if (int.Parse(tb_con_err.Text.Replace(",", "")) > 0){
                    return "Existen errores en el archivo, verifique e intente nuevamente";
                }
                
                return "OK";
            }
            catch (Exception) {
                return "Los datos proporcionados NO pasaron el proceso de validación.";
            }            
        }

        // Evento Click: Buscar Archivo Excel
        private void bt_bus_arc_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ope_fil = new OpenFileDialog();
                ope_fil.Filter = "Excel Files |*.xlsx";
                ope_fil.Title = "Seleccione el archivo de Excel";
                if (ope_fil.ShowDialog() == DialogResult.OK)
                {
                    if (ope_fil.FileName.CompareTo("") != 0)
                        tb_dir_arc.Text = ope_fil.FileName;
                    else
                        tb_dir_arc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Evento Click: Cargar Datos al DataGridView
        private void bt_car_dat_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpia Datos
                dg_res_ult.Rows.Clear();
                tb_con_err.Text = "...";
                tb_sin_err.Text = "...";
                tb_tot_reg.Text = "...";
                // Lectura el archivo excel
                XLWorkbook arc_exc = new XLWorkbook(tb_dir_arc.Text.Trim());
                // Lectura la Hoja de Trabajo del archivo
                var hoj_tra = arc_exc.Worksheet(1);
                // Crea un DataTable para almacenar los datos
                DataTable mTabla = new DataTable();
                // Agrega las columnas al DataTable
                mTabla.Columns.Add("va_nro_reg");
                mTabla.Columns.Add("va_fec_tas");
                mTabla.Columns.Add("va_tas_cam");
                mTabla.Columns.Add("va_obs_reg");
                // Recorre las Filas de la Hoja de Trabajo
                int nro_fil = 0;
                int con_err = 0;
                int sin_err = 0;
                foreach (IXLRow fil_tab in hoj_tra.Rows())
                {
                    // Empieza a cargar despues del encabezado
                    if (nro_fil > 0)
                    {
                        string fec_tas = fil_tab.Cell(1).GetValue<string>();
                        string tas_cam = fil_tab.Cell(2).GetValue<string>();
                        string nro_reg = nro_fil.ToString();
                        string obs_reg = "OK";

                        // Realiza validaciones de la fecha
                        if (obs_reg.CompareTo("OK") == 0 &&
                            fec_tas.CompareTo("") == 0)
                            obs_reg = "La Fecha está vacía";
                        if (obs_reg.CompareTo("OK") == 0 &&
                            !cl_glo_bal.IsDateTime(fec_tas.Substring(0, 10)))
                            obs_reg = "La Fecha NO es válida";
                        if (obs_reg.CompareTo("OK") == 0)
                        {
                            fec_tas = fec_tas.Substring(0, 10);
                        }

                        // Realiza validaciones de la T.C
                        if (obs_reg.CompareTo("OK") == 0 &&
                            tas_cam.CompareTo("") == 0)
                            obs_reg = "La Tasa de Cambio está vacía";
                        if (obs_reg.CompareTo("OK") == 0 &&
                            !cl_glo_bal.IsDecimal(tas_cam))
                            obs_reg = "La Tasa de Cambio No es válido";
                        if (obs_reg.CompareTo("OK") == 0 &&
                            double.Parse(tas_cam) == 0)
                            obs_reg = "La T.C DEBE ser MAYOR a cero";
                        if (obs_reg.CompareTo("OK") == 0 &&
                            double.Parse(tas_cam) > 100)
                            obs_reg = "La T.C DEBE ser MENOR a cien";

                        if (obs_reg.CompareTo("OK") == 0)
                        {
                            sin_err++;
                            tas_cam = string.Format("{0:#,##0.0000}", tas_cam);
                        }
                        else
                        {
                            con_err++;
                        }

                        // Carga el Registro al DataGridView
                        dg_res_ult.Rows.Add();
                        dg_res_ult.Rows[nro_fil - 1].Cells["va_nro_reg"].Value = nro_reg;
                        dg_res_ult.Rows[nro_fil - 1].Cells["va_fec_tas"].Value = fec_tas;
                        dg_res_ult.Rows[nro_fil - 1].Cells["va_tas_cam"].Value = tas_cam;
                        dg_res_ult.Rows[nro_fil - 1].Cells["va_obs_reg"].Value = obs_reg;

                        // Establece el color del Texto
                        if (obs_reg.CompareTo("OK") == 0)
                        {
                            dg_res_ult.Rows[nro_fil - 1].Cells["va_nro_reg"].Style.ForeColor = Color.Black;
                            dg_res_ult.Rows[nro_fil - 1].Cells["va_fec_tas"].Style.ForeColor = Color.Black;
                            dg_res_ult.Rows[nro_fil - 1].Cells["va_tas_cam"].Style.ForeColor = Color.Black;
                            dg_res_ult.Rows[nro_fil - 1].Cells["va_obs_reg"].Style.ForeColor = Color.Black;
                        }
                        else
                        {
                            dg_res_ult.Rows[nro_fil - 1].Cells["va_nro_reg"].Style.ForeColor = Color.Red;
                            dg_res_ult.Rows[nro_fil - 1].Cells["va_fec_tas"].Style.ForeColor = Color.Red;
                            dg_res_ult.Rows[nro_fil - 1].Cells["va_tas_cam"].Style.ForeColor = Color.Red;
                            dg_res_ult.Rows[nro_fil - 1].Cells["va_obs_reg"].Style.ForeColor = Color.Red;
                        }
                    }
                    nro_fil++;
                }
                // Desplega Totales
                tb_con_err.Text = string.Format("{0:#,##0}", con_err);
                tb_sin_err.Text = string.Format("{0:#,##0}", sin_err);
                tb_tot_reg.Text = string.Format("{0:#,##0}", nro_fil - 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                /* Despliega Mensaje de Confirmación */
                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {                    
                    /* Recorre los Item del DataGridView */
                    for (int i = 0; i < dg_res_ult.RowCount; i++)
                    {   /* Obtiene Datos */
                        string fec_tas = dg_res_ult.Rows[i].Cells["va_fec_tas"].Value.ToString();
                        string tas_cam = dg_res_ult.Rows[i].Cells["va_tas_cam"].Value.ToString();
                        /* Importa Registro */
                        o_ads023.Fe_imp_tas(fec_tas, double.Parse(tas_cam));                        
                    }
                    /* Actualiza el Formulario Principal */
                    frm_pad.Fe_act_frm();
                    /* Despliega Mensaje */
                    MessageBox.Show("Se ha importado " + tb_tot_reg.Text + ", registros exitosamente", Text, MessageBoxButtons.OK);
                    /* Cierra Formulario */
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            // Cierra Formulario
            cl_glo_frm.Cerrar(this);
        }        
    }
}
