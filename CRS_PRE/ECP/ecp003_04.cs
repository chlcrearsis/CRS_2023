using System;
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

namespace CRS_PRE
{
    public partial class ecp003_04 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        

        //Instancias
        adp002 o_adp002 = new adp002();
        ecp001 o_ecp001 = new ecp001();
        ecp002 o_ecp002 = new ecp002();
        ecp003 o_ecp003 = new ecp003();

        DataTable tabla = new DataTable();
        string raz_soc = "";
        string nom_bre = "";
        int ced_per = 0;
        int cod_per = 0;

        public ecp003_04()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
             //** Obtiene datos de la persona
            cod_per = int.Parse(frm_dat.Rows[0]["va_cod_per"].ToString());

            tabla = o_adp002.Fe_con_per(cod_per);

            cod_per = int.Parse(tabla.Rows[0]["va_cod_per"].ToString());
            raz_soc = tabla.Rows[0]["va_raz_soc"].ToString();
            nom_bre = tabla.Rows[0]["va_ape_pat"].ToString() + " " + tabla.Rows[0]["va_ape_mat"].ToString() + ", " + tabla.Rows[0]["va_nom_bre"].ToString();
            ced_per = int.Parse(tabla.Rows[0]["va_nro_doc"].ToString());

            lb_raz_soc.Text = raz_soc + "  (" + cod_per + ")";
            lb_nom_bre.Text = nom_bre;
            lb_nro_doc.Text = ced_per.ToString();

            tb_max_cuo.Text = "0";
            tb_des_lib.Text = "";
            tb_fec_exp.Text = DateTime.Today.AddMonths(3).ToString();

            tb_cod_lib.Text = frm_dat.Rows[0]["va_cod_lib"].ToString();
            Fi_obt_lib();

            tb_mto_lim.Text = frm_dat.Rows[0]["va_mto_lim"].ToString().Trim();
            tb_fec_exp.Text = DateTime.Parse(frm_dat.Rows[0]["va_fec_exp"].ToString()).ToString("d");
            tb_cod_plg.Text = frm_dat.Rows[0]["va_cod_plg"].ToString();
            Fi_obt_plg();

            tb_max_cuo.Text = frm_dat.Rows[0]["va_max_cuo"].ToString();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";
        }

        protected string Fi_val_dat()
        {

            if (tb_cod_lib.Text.Trim() == "")
            {
                tb_cod_lib.Focus();
                return "Debe proporcionar la libreta";
            }

            //Verificar si la libreta existe
            tabla = o_ecp002.Fe_con_lib(int.Parse(tb_cod_lib.Text));
            if (tabla.Rows.Count == 0)
            {
                tb_cod_lib.Focus();
                return "La libreta no se encuentra registrada";
            }
            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_cod_lib.Focus();
                return "La libreta se encuentra Deshabilitada";
            }

            //Verificar si esta inscrito
            tabla = o_ecp003.Fe_con_sus( int.Parse(tb_cod_lib.Text),cod_per);
            if (tabla.Rows.Count == 0)
            {
                tb_cod_lib.Focus();
                return "La persona no se encuentra inscrita en esta libreta";
            }

            //Verificar plan de pago
            if (tb_cod_plg.Text.Trim() == "")
            {
                tb_cod_plg.Focus();
                return "Debe proporcionar el plan de pago";
            }

            //Verificar si el plan de pago existe
            tabla = o_ecp001.Fe_con_plg(int.Parse(tb_cod_plg.Text));
            if (tabla.Rows.Count == 0)
            {
                tb_cod_lib.Focus();
                return "El plan de pago no se encuentra registrado";
            }

            //Verificar nro maximo de cuotas vencidas
            if (tb_max_cuo.Text.Trim() == "")
            {
                tb_max_cuo.Focus();
                return "Debe proporcionar el numero máximo de cuotas vencidas";
            }
            return "";
        }


      
        /// <summary>
        /// Obtiene ide y nombre documento para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_lib()
        {
            // Obtiene ide y nombre de libreta
            tabla = o_ecp002.Fe_con_lib(int.Parse(tb_cod_lib.Text));
            if (tabla.Rows.Count == 0)
            {
                tb_des_lib.Text = "";
                tb_mon_lib.Text = "";
            }
            else
            {
                tb_cod_lib.Text = tabla.Rows[0]["va_cod_lib"].ToString();
                tb_des_lib.Text = tabla.Rows[0]["va_des_lib"].ToString();
                if (tabla.Rows[0]["va_mon_lib"].ToString() == "B")
                    tb_mon_lib.Text = "Bolivianos";
                else
                    tb_mon_lib.Text = "Dólares";

            }
        }






        private void Bt_bus_plg_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_plg();
        }
        private void Tb_cod_plg_KeyDown(object sender, KeyEventArgs e)
        {

        }

        void Fi_abr_bus_plg()
        {
            ecp001_01 frm = new ecp001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_plg.Text = frm.tb_sel_ecc.Text;
                Fi_obt_plg();
            }
        }

        private void Tb_cod_plg_Validated(object sender, EventArgs e)
        {
            Fi_obt_plg();
        }

        /// <summary>
        /// Obtiene ide y nombre documento para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_plg()
        {
            // Obtiene ide y nombre de libreta
            tabla = o_ecp001.Fe_con_plg(int.Parse(tb_cod_plg.Text));
            if (tabla.Rows.Count == 0)
            {
                tb_des_plg.Text = "";
            }
            else
            {
                tb_cod_plg.Text = tabla.Rows[0]["va_cod_plg"].ToString();
                tb_des_plg.Text = tabla.Rows[0]["va_des_plg"].ToString();               
            }
        }




        private void Fi_lim_pia()
        {
           
            tb_cod_lib.Text = "0"; 
            tb_des_lib.Clear();
           
            tb_cod_lib.Focus();
        }
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
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
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                msg_res = MessageBox.Show("Esta seguro de Deshabilitar la inscripción?", "Deshabilita Inscripción", MessageBoxButtons.OKCancel);
            else
                msg_res = MessageBox.Show("Esta seguro de Habilitar la inscripción?", "Habilita Inscripción", MessageBoxButtons.OKCancel);

            if (msg_res == DialogResult.OK)
            {
                if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                    o_ecp003.Fe_dhb_sus(int.Parse(tb_cod_lib.Text), cod_per);
                else
                    o_ecp003.Fe_hab_sus(int.Parse(tb_cod_lib.Text), cod_per);

                frm_pad.Fe_act_frm(int.Parse(tb_cod_lib.Text));
                cl_glo_frm.Cerrar(this);
            }

        }
        private void tb_nro_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }


    }
}
