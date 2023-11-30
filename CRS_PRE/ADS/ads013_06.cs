using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads013 - Definición de Global                         */
    /*      Opción: Elimina Registro                                      */
    /*       Autor: JEJR - Crearsis             Fecha: 30-11-2023         */
    /**********************************************************************/
    public partial class ads013_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads001 o_ads001 = new ads001();
        ads013 o_ads013 = new ads013();
        DataTable Tabla = new DataTable();

        public ads013_06()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_ide_mod.Text = frm_dat.Rows[0]["va_ide_mod"].ToString().Trim();
            lb_nom_mod.Text = frm_dat.Rows[0]["va_nom_mod"].ToString().Trim();
            tb_ide_glo.Text = frm_dat.Rows[0]["va_ide_glo"].ToString().Trim();
            tb_nom_glo.Text = frm_dat.Rows[0]["va_nom_glo"].ToString().Trim();
            switch (frm_dat.Rows[0]["va_tip_glo"].ToString())
            {
                case "0":
                    tb_tip_glo.Text = "Entero";
                    tb_glo_ent.Text = frm_dat.Rows[0]["va_glo_ent"].ToString().Trim();
                    break;
                case "1":
                    tb_tip_glo.Text = "Decimal";
                    tb_glo_dec.Text = frm_dat.Rows[0]["va_glo_dec"].ToString().Trim();
                    break;
                case "2":
                    tb_tip_glo.Text = "Caracter";
                    tb_glo_car.Text = frm_dat.Rows[0]["va_glo_car"].ToString().Trim();
                    break;
            }
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_mod.Text = string.Empty;
            lb_nom_mod.Text = string.Empty;
            tb_ide_glo.Text = string.Empty;
            tb_nom_glo.Text = string.Empty;
            tb_tip_glo.Text = string.Empty;
            tb_glo_ent.Text = string.Empty;
            tb_glo_dec.Text = string.Empty;
            tb_glo_car.Text = string.Empty;
        }


        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo ID. Módulo NO este vacio
            if (tb_ide_mod.Text.Trim() == "" ||
                tb_ide_mod.Text.Trim() == "0")
                return "DEBE proporcionar el ID. Módulo";


            // Valida que el campo código sea un valor válido
            if (!cl_glo_bal.IsNumeric(tb_ide_mod.Text.Trim()))
                return "El ID. Módulo NO es valido";

            // Valida que el campo ID. Global NO este vacio
            if (tb_ide_glo.Text.Trim() == "")
                return "DEBE proporcionar el ID. Global";

            // Valida que el campo código sea un valor válido
            if (!cl_glo_bal.IsNumeric(tb_ide_glo.Text.Trim()))
                return "El ID. Global NO es valido";

            // Valida que el Módulo este registrado en el sistema
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(int.Parse(tb_ide_mod.Text));
            if (Tabla.Rows.Count == 0)
                return "El Módulo NO se encuentra registrado";

            // Verifica SI la Global se encuentra registrado
            Tabla = new DataTable();
            Tabla = o_ads013.Fe_con_glo(int.Parse(tb_ide_mod.Text), int.Parse(tb_ide_glo.Text));
            if (Tabla.Rows.Count == 0)
                return "La Global (" + tb_ide_mod.Text + "-" + tb_ide_glo.Text + ") NO se encuentra registrado";           

            return "OK";
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;

            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "OK")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Está seguro de eliminar la información?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Elimina el registro
                    o_ads013.Fe_eli_min(int.Parse(tb_ide_mod.Text), int.Parse(tb_ide_glo.Text));
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(tb_ide_mod.Text.Trim(), tb_ide_glo.Text);
                    // Despliega Mensaje
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
