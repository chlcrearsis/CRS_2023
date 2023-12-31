﻿using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp006 - Imagen Persona                               */
    /*      Opción: Registra Registro                                     */
    /*       Autor: JEJR - Crearsis             Fecha: 25-10-2021         */
    /**********************************************************************/
    public partial class adp006_02 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        adp002 o_adp002 = new adp002();
        adp006 o_adp006 = new adp006();
        ads010 o_ads010 = new ads010();
        General general = new General();
        DataTable Tabla = new DataTable();

        public adp006_02()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            Fi_lim_pia();
        }       

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia(){
            tb_cod_per.Text = string.Empty;
            tb_raz_soc.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
            tb_ide_tip.Text = string.Empty;
            tb_nom_tip.Text = string.Empty;
            tb_ext_arc.Text = string.Empty;
            tb_tam_arc.Text = string.Empty;
            tb_tam_kbs.Text = string.Empty;
            tb_ide_usr.Text = string.Empty;
            tb_fec_reg.Text = string.Empty;
            tb_hor_reg.Text = string.Empty;
            tb_nom_equ.Text = string.Empty;
            tb_dir_arc.Text = string.Empty;
            pb_ima_per.Image = null;
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan() {
            // Despliega Datos en Pantalla
            tb_cod_per.Text = frm_dat.Rows[0]["va_cod_per"].ToString();
            tb_raz_soc.Text = frm_dat.Rows[0]["va_raz_soc"].ToString();
            tb_ide_tip.Text = frm_dat.Rows[0]["va_ide_tip"].ToString();
            tb_nom_tip.Text = frm_dat.Rows[0]["va_nom_tip"].ToString();
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";

            tb_ide_usr.Text = cl_glo_bal.glo_ide_usr;
            tb_fec_reg.Text = general.Fe_fch_act();
            tb_hor_reg.Text = general.Fe_hor_act();
            tb_nom_equ.Text = SystemInformation.ComputerName;
            tb_dir_arc.Focus();
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat(){
            if (tb_cod_per.Text.Trim() == "")
                return "DEBE proporcionar el Código de la Persona";

            if (tb_ide_tip.Text.Trim() == "")
                return "DEBE proporcionar el Tipo de Imagen";

            if (tb_est_ado.Text.Trim() == "Deshabilitado")
                return "NO se puede registrar la imagen. La Persona esta Deshabilitada";


            // Verifica SI existe la personsa registrada
            Tabla = new DataTable();
            Tabla = o_adp002.Fe_con_per(int.Parse(tb_cod_per.Text));
            if(Tabla.Rows.Count == 0)
                return "La persona con el código (" + tb_cod_per.Text + "). NO se encuentra registrada.";
            

            // Verifica SI existe el Tipo de Imagenes
            Tabla = new DataTable();
            Tabla = o_ads010.Fe_con_tip(tb_ide_tip.Text);
            if (Tabla.Rows.Count == 0)
                return "El Tipo de Imagen (" + tb_ide_tip.Text + "). NO se encuentra registrada.";
            
            return "";
        }        

        private void bt_abr_arc_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivo (JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo file = new FileInfo(ofd.FileName);
                pb_ima_per.Image = Image.FromFile(ofd.FileName);
                tb_dir_arc.Text = ofd.FileName;
                tb_tam_arc.Text = Math.Round((file.Length / 1024f), 2).ToString();
                tb_tam_kbs.Text = "KB";
                tb_ext_arc.Text = Path.GetExtension(ofd.FileName).ToString().Replace(".", "").ToUpper();
            }
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;
            try{
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != ""){
                    MessageBox.Show("Error: " + msg_val, Text, MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", Text, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK){
                    //'Convierte la imagen a byte para ser guardada
                    byte[] img_arc = cl_glo_bal.fg_img_byt(pb_ima_per.Image);

                    // Obtiene la fecha y hora actual
                    string fec_reg = tb_fec_reg.Text + " " + tb_hor_reg.Text;

                    // Graba el registro en la BD.
                    o_adp006.Fe_nue_reg(int.Parse(tb_cod_per.Text), tb_ide_tip.Text, img_arc, tb_ext_arc.Text, decimal.Parse(tb_tam_arc.Text), tb_ide_usr.Text, fec_reg, tb_nom_equ.Text);

                    // Actualiza Lista Formulario Padre */
                    frm_pad.Fe_act_frm(tb_ide_tip.Text);
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK);
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex) {
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
