using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CRS_NEG;


namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads000 - PIN de Acceso                                */
    /*      Opción: Seguridad - Control del Acceso                        */
    /*       Autor: JEJR - Crearsis             Fecha: 16-10-2023         */
    /**********************************************************************/
    public partial class ads000_07 : Form
    {
        /* Variables */
        public int vp_ide_mod = 0;  // ID. Módulo
        public int vp_ide_glo = 0;  // ID. Global
        private int va_coo_pox = 0;
        private int va_coo_poy = 0;
        private bool va_est_ven = false;
        /* Objetos */
        DataTable Tabla = new DataTable();
        ads001 o_ads001 = new ads001();
        ads007 o_ads007 = new ads007();
        ads013 o_ads013 = new ads013();
        ads014 o_ads014 = new ads014();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public ads000_07()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pn_ide_usr.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_ide_usr.Width, pn_ide_usr.Height, 15, 15));
            pn_fon_usr.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_fon_usr.Width, pn_fon_usr.Height, 15, 15));
            pn_pas_usr.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_pas_usr.Width, pn_pas_usr.Height, 15, 15));
            pn_fon_pas.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_fon_pas.Width, pn_fon_pas.Height, 15, 15));
            pn_cla_usr.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_cla_usr.Width, pn_cla_usr.Height, 15, 15));
            pn_fon_rep.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_fon_rep.Width, pn_fon_rep.Height, 15, 15));
        }

        private void ads000_07_Load(object sender, EventArgs e)
        {
            // Inicializa Datos
            Fi_lim_pia();
            // Despliega Datos
            Tabla = new DataTable();
            Tabla = o_ads013.Fe_obt_glo(vp_ide_mod, vp_ide_glo);
            if (Tabla.Rows.Count > 0){
                lb_glo_bal.Text = Tabla.Rows[0]["va_ide_mod"].ToString() + " - " +
                                  Tabla.Rows[0]["va_ide_glo"].ToString() + " : " +
                                  Tabla.Rows[0]["va_nom_glo"].ToString();
            }else {
                lb_glo_bal.Text = vp_ide_mod + " - " +
                                  vp_ide_glo + " : Global NO definido";
            }
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            lb_glo_bal.Text = string.Empty;
            tb_ide_usr.Text = string.Empty;
            tb_pas_usr.Text = string.Empty;
            tb_cla_usr.Text = string.Empty;
            tb_ide_usr.Focus();
        }

        // Evento MouseMove : Formulario Principal
        private void ads000_07_MouseMove(object sender, MouseEventArgs e)
        {            
            if (va_est_ven){
                Left = Left + (e.X - va_coo_pox);
                Top = Top + (e.Y - va_coo_poy);
            }
        }
        // Evento MouseDown : Formulario Principal
        private void ads000_07_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left){
                va_est_ven = true;
                va_coo_pox = e.X;
                va_coo_poy = e.Y;
            }
        }
        // Evento MouseUp : Formulario Principal
        private void ads000_07_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)           
                va_est_ven = false;            
        }
        // Evento MouseHover : Mostrar Password
        private void pb_mos_pas_MouseHover(object sender, EventArgs e)
        {
            tb_pas_usr.UseSystemPasswordChar = false;
        }
        // Evento MouseLeave : Mostrar Password
        private void pb_mos_pas_MouseLeave(object sender, EventArgs e)
        {
            tb_pas_usr.UseSystemPasswordChar = true;
        }

        // Evento Enter : ID. Usuario
        private void tb_ide_usr_Enter(object sender, EventArgs e)
        {
            ps_sel_usr.Visible = true;
            ps_sel_pas.Visible = false;
            ps_sel_cla.Visible = false;
        }

        // Evento Validated : ID. Usuario
        private void tb_ide_usr_Validated(object sender, EventArgs e)
        {
            ps_sel_usr.Visible = false;
            ps_sel_pas.Visible = false;
            ps_sel_cla.Visible = false;
        }

        // Evento Enter : Password Usuario
        private void tb_pas_usr_Enter(object sender, EventArgs e)
        {
            if (tb_pas_usr.Text.Trim() == "Contraseña")
                tb_pas_usr.Clear();

            ps_sel_usr.Visible = false;
            ps_sel_pas.Visible = true;
            ps_sel_cla.Visible = false;
        }
        // Evento Validated : Password Usuario
        private void tb_pas_usr_Validated(object sender, EventArgs e)
        {
            if (tb_pas_usr.Text.Trim() == "")
                tb_pas_usr.Text = "Contraseña";

            ps_sel_usr.Visible = false;
            ps_sel_pas.Visible = false;
            ps_sel_cla.Visible = false;
        }

        // Evento Enter : Clave Usuario
        private void tb_cla_usr_Enter(object sender, EventArgs e)
        {
            ps_sel_usr.Visible = false;
            ps_sel_pas.Visible = false;
            ps_sel_cla.Visible = true;
        }

        // Evento Validated : Clave Usuario
        private void tb_cla_usr_Validated(object sender, EventArgs e)
        {
            ps_sel_usr.Visible = false;
            ps_sel_pas.Visible = false;
            ps_sel_cla.Visible = false;
        }

        // Evento KeyPress : Clave Usuario
        private void tb_cla_usr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
                Fi_gra_reg();
        }

        // Valida los datos proporcionados
        private string Fi_val_dat()
        {
            // Valida que exista el Módulo
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(vp_ide_mod);
            if (Tabla.Rows.Count == 0)
                return "El ID. Módulo (" + vp_ide_mod + ") NO está definido en el sistema.";

            // Valida que exista la Global
            Tabla = new DataTable();
            Tabla = o_ads013.Fe_obt_glo(vp_ide_mod, vp_ide_glo);
            if (Tabla.Rows.Count == 0)
                return "La Global (" + vp_ide_mod + " - " + vp_ide_glo + ") NO está definido en el sistema.";

            // Valida que el campo ID. Usuario NO este vacio
            if (tb_ide_usr.Text.Trim() == ""){
                tb_ide_usr.Focus();
                return "DEBE proporcionar el ID. Usuario";
            }

            // Valida que el campo la Contraseña NO este vacio
            if (tb_pas_usr.Text.Trim() == "" || tb_pas_usr.Text.Trim() == "Contraseña"){
                tb_pas_usr.Focus();
                return "DEBE proporcionar la Contraseña del del Usuario";
            }

            // Valida que el campo Clave del Usuario NO este vacio
            if (tb_cla_usr.Text.Trim() == ""){
                tb_cla_usr.Focus();
                return "DEBE proporcionar la Clave Usuario";
            }

            // Verifica SI existe el Usuario Administrador
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_con_ide(tb_ide_usr.Text.Trim());
            if (Tabla.Rows.Count == 0){
                tb_ide_usr.Focus();
                return "NO está registrado el Usuario (" + tb_ide_usr.Text.Trim() + ")";
            }
            if (Tabla.Rows[0]["va_est_ado"].ToString().CompareTo("H") != 0){
                tb_ide_usr.Focus();
                return "El Usuario (" + tb_ide_usr.Text.Trim() + ") está Deshabilitado";
            }

            // Verifica SI la contraseña del Usuario es correcta
            string res_ini = o_ads007.Fe_ing_sis(tb_ide_usr.Text.Trim(), tb_pas_usr.Text.Trim());
            if (res_ini != "OK"){
                tb_pas_usr.Focus();
                return "La Contraseña del Usuario (" + tb_ide_usr.Text.Trim() + ") es incorrecta";
            }

            // Verifica la Clave que este definido y bien proporcionado
            Tabla = new DataTable();
            Tabla = o_ads014.Fe_obt_cla(tb_ide_usr.Text.Trim(), vp_ide_mod, vp_ide_glo);
            if (Tabla.Rows.Count == 0){
                tb_ide_usr.Focus();
                return "El Usuario (" + tb_ide_usr.Text.Trim() + ") NO tiene definido la clave para la Global";
            }
            if (Tabla.Rows[0]["va_cla_glo"].ToString().CompareTo(tb_cla_usr.Text.Trim()) != 0){
                tb_cla_usr.Focus();
                return "La Clave proporcionado es incorrecta";
            }

            return "OK";
        }

        // Graba Registro
        private void Fi_gra_reg()
        {
            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "OK")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                // Devuelve Estado de Resultado
                DialogResult = DialogResult.OK;
                // Cierra Formulario
                cl_glo_frm.Cerrar(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click : Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            Fi_gra_reg();
        }
        // Evento Click : Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            // Devuelve Cancel Como resultado
            DialogResult = DialogResult.Cancel;
            // Cierra Formulario
            cl_glo_frm.Cerrar(this);
        }
    }
}
