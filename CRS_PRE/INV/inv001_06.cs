﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using CRS_NEG;

namespace CRS_PRE.INV
{
    public partial class inv001_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        inv001 o_inv001 = new inv001();

        DataTable tabla = new DataTable();

        public inv001_06()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {

            tb_ide_gru.Text = frm_dat.Rows[0]["va_ide_gru"].ToString();
            tb_nom_gru.Text = frm_dat.Rows[0]["va_nom_gru"].ToString();
            tb_des_gru.Text = frm_dat.Rows[0]["va_des_gru"].ToString();
            
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }




        protected string Fi_val_dat()
        {
            if (tb_nom_gru.Text.Trim()=="")
            {
                tb_nom_gru.Focus();
                return "Debe proporcionar el nombre para el Grupo de Bodega";
            }

            tabla = o_inv001.Fe_con_gru(int.Parse(tb_ide_gru.Text));
            if (tabla.Rows.Count == 0)
            {
                return "EL Grupo de Bodega no se encuentra en la base de datos";
            }

            return "";

        }
             
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {

                string msg_val = "";
            DialogResult msg_res;

            // funcion para validar datos
            msg_val = Fi_val_dat();
            if (msg_val != "")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }

            if (tb_est_ado.Text == "Habilitado")
            {
                MessageBox.Show("No puede Eliminar, el Grupo de Bodega debe de estar Deshabilitado", "Edita Grupo de Bodega", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            else
                msg_res = MessageBox.Show("Esta seguro de Deshabilitar el Grupo de Bodega?", "Edita Grupo de Bodega", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (msg_res == DialogResult.OK)
            {
                o_inv001.Fe_eli_min(int.Parse(tb_ide_gru.Text));

                MessageBox.Show("Los datos se grabaron correctamente", "Elimina Grupo de Bodega", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(tb_ide_gru.Text);
                cl_glo_frm.Cerrar(this);
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
