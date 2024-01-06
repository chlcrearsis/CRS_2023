using CRS_NEG;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads022 - Tasa de Cambio                               */
    /*      Opción: Exporta T.C a Excel                                   */
    /*       Autor: JEJR - Crearsis             Fecha: 03-01-2024         */
    /**********************************************************************/
    public partial class ads022_08 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancia
        private DataTable Tabla;
        private ads007 o_ads007 = new ads007();
        private ads022 o_ads022 = new ads022();
        private General general = new General();

        public ads022_08()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Establece datos por defectos 
            tb_fec_ini.Text = string.Empty;
            tb_fec_fin.Text = string.Empty;
            tb_fec_ini.Focus();            
        }

        // Valida los datos de pantalla
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

        // Metodo para exportar a Excel desde un DataGridView      
        public void Fe_exp_exc(DataTable mTabla)
        {
            try
            {
                SaveFileDialog archivo = new SaveFileDialog();
                //archivo.Filter = "Excel (*.xls)|*.xls";
                archivo.Filter = "Microsoft Office Excel Workbook(*.xlsx)|*.xlsx";
                archivo.FileName = "TasaCambio_" + DateTime.Now.Date.ToShortDateString().Replace("/", "");
                if (archivo.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application apl_exc;
                    Microsoft.Office.Interop.Excel.Workbook lib_tra;
                    Microsoft.Office.Interop.Excel.Worksheet hoj_tra;
                    apl_exc = new Microsoft.Office.Interop.Excel.Application();
                    lib_tra = apl_exc.Workbooks.Add();
                    hoj_tra = (Microsoft.Office.Interop.Excel.Worksheet)lib_tra.Worksheets.get_Item(1);
                    // Estable el Titulo en el Encabezado
                    hoj_tra.Cells[1, "A"] = "Fecha";
                    hoj_tra.Cells[1, "B"] = "Tasa de Cambio";
                    // Ajusta Automaticamente las columnas
                    hoj_tra.Columns[1].AutoFit();
                    hoj_tra.Columns[2].AutoFit();
                    // Establece el Nombre de la Hoja
                    hoj_tra.Name = "Tasa de Cambio";
                    // Establece el Ancho de la Columna
                    hoj_tra.Columns[1].ColumnWidth = 12;
                    hoj_tra.Columns[2].ColumnWidth = 17;
                    // Definir estilo para el encabezado
                    Microsoft.Office.Interop.Excel.Style est_enc = lib_tra.Styles.Add("est_enc");
                    est_enc.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    est_enc.Font.Name = "Arial";
                    est_enc.Font.Bold = true;                        
                    est_enc.Font.Size = 11;
                    // Definir estilo para el la fecha
                    Microsoft.Office.Interop.Excel.Style sty_fch = lib_tra.Styles.Add("sty_fch");
                    sty_fch.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    sty_fch.NumberFormat = "dd/MM/yyyy";
                    sty_fch.Font.Name = "Arial";
                    sty_fch.Font.Size = 11;
                    // Definir estilo para el decimal
                    Microsoft.Office.Interop.Excel.Style sty_dec = lib_tra.Styles.Add("sty_dec");
                    sty_dec.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    sty_dec.NumberFormat = "#,##0.0000";
                    sty_dec.Font.Name = "Arial";
                    sty_dec.Font.Size = 11;
                    // Aplica el estilo a la encabezado de la celda
                    hoj_tra.Cells[1, 1].Style = est_enc;
                    hoj_tra.Cells[1, 2].Style = est_enc;

                    // Recorremos el DataGridView rellenando la hoja de trabajo
                    for (int i = 0; i < mTabla.Rows.Count; i++)
                    {
                        // Aplica el estilo a la celda
                        hoj_tra.Cells[i + 2, 1].Style = sty_fch;
                        hoj_tra.Cells[i + 2, 2].Style = sty_dec;
                        // Inserta datos en la celda                       
                        hoj_tra.Cells[i + 2, 1] = mTabla.Rows[i][0].ToString().Trim();
                        hoj_tra.Cells[i + 2, 2] = mTabla.Rows[i][1].ToString().Trim();
                    }

                    // Graba el archivo en el directorio establecido
                    lib_tra.SaveAs(archivo.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook,
                                   Missing.Value, Missing.Value, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                                   Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlUserResolution, true,
                                   Missing.Value, Missing.Value, Missing.Value);
                    lib_tra.Close(true);
                    apl_exc.Quit();
                    // Despliega Mensaje
                    MessageBox.Show("Se exporto exitosamente los registros a Excel", Text);
                    // Cierra Formulario
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex)
            {
                // Despliega Mensaje
                MessageBox.Show("Error al exportar la informacion debido a: " + ex.ToString(), Text);
            }
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            // Funcion para validar datos
            string fec_ini = tb_fec_ini.Text.Trim();
            string fec_fin = tb_fec_fin.Text.Trim();
            string msg_val = Fi_val_dat();

            if (msg_val != "OK")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }            

            // Obtiene Datos para Exportar
            Tabla = new DataTable();
            Tabla = o_ads022.Fe_exp_tas(fec_ini, fec_fin);

            // Exporta a Excel
            Fe_exp_exc(Tabla);            
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            // Cierra Formulario
            cl_glo_frm.Cerrar(this);
        }
    }
}
