using System;
using System.Windows.Forms;

using CRS_NEG;
using CRS_PRE.INV;
using CRS_PRE;

namespace CRS_PRE
{
    public partial class ads200 : Form
    {
        // Instancia
        dynamic o_frm;
        public dynamic frm_pad;

        // Objetos
        ads013 o_ads013 = new ads013();        

        public ads200()
        {
            InitializeComponent();
        }

        private void ads200_Load(object sender, EventArgs e)
        {
            // Inicializa Datos
            ts_usr_usr.Text = o_ads013.va_ide_usr;
            ts_bas_dat.Text = o_ads013.va_nom_bda;
            ts_ide_app.Text = Name;
            ts_rut_app.Text = Text;

            // Verifica Restricciones del Menu al Usuario
            m_mod_ulo = cl_glo_bal.fg_ver_mnu(ts_usr_usr.Text, Name, m_mod_ulo);
        }

        private void ads200_MdiChildActivate(object sender, EventArgs e)
        {
            if (ActiveMdiChild is null){
                ts_ide_app.Text = Name;
                ts_rut_app.Text = Text;

                // Verifica Restricciones del Menu al Usuario
                m_mod_ulo = cl_glo_bal.fg_ver_mnu(ts_usr_usr.Text, Name, m_mod_ulo);
            }else{
                // Verifica Restricciones del Menu al Usuario
                m_frm_hja = cl_glo_bal.fg_ver_mnu(ts_usr_usr.Text, ActiveMdiChild.Name, m_frm_hja);

                // Ide de la app
                ts_ide_app.Text = ActiveMdiChild.Name;

                // Ruta de la app
                ts_rut_app.Text = "";

                dynamic frm = ActiveMdiChild;
                dynamic[] ruta = new dynamic[100];

                int i = 0;
                do
                {
                    i = i + 1;
                    ruta[i] = frm.frm_pad.Text;
                    frm = frm.frm_pad;

                } while (frm.frm_pad != null);

                do
                {
                    ts_rut_app.Text = ts_rut_app.Text + ruta[i] + " -> ";
                    i = i - 1;

                } while (i != 0);

                ts_rut_app.Text = ts_rut_app.Text + ActiveMdiChild.Text;
            }
        }

        /// <summary>
        /// Verifica Menú al Activarse el formulario
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="frm_act">Formulario Activo</param>
        public void fu_ver_mnu(string ide_usr, Form frm_act)
        {
            // verifica Restricciones del Menu de la aplicacion para el usuario
            if (m_mod_ulo.Visible == true)                           
                m_mod_ulo = cl_glo_bal.fg_ver_mnu(ide_usr, frm_act.Name, m_mod_ulo);            
            else            
                m_frm_hja = cl_glo_bal.fg_ver_mnu(ide_usr, frm_act.Name, m_frm_hja);            
        }


        // Evento Click: Usuario
        private void mn_usu_ari_Click(object sender, EventArgs e)
        {
            o_frm = new ads007_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Gestion
        private void mn_ges_tio_Click(object sender, EventArgs e)
        {
            o_frm = new ads016_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Definición Documento
        private void mn_def_doc_Click(object sender, EventArgs e)
        {
            o_frm = new ads003_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Talonario Documento
        private void mn_tal_doc_Click(object sender, EventArgs e)
        {
            o_frm = new ads004_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Numeración Talonario
        private void mn_num_tal_Click(object sender, EventArgs e)
        {
            o_frm = new ads005_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Bitácora de Operaciones
        private void mn_bit_ope_Click(object sender, EventArgs e)
        {

        }

        // Evento Click: Bitácora de Documento
        private void mn_bit_doc_Click(object sender, EventArgs e)
        {

        }

        // Evento Click: Bitácora de Inicio de Sesión
        private void mn_bit_ses_Click(object sender, EventArgs e)
        {
            o_frm = new ads024_R01p();
            cl_glo_frm.abrir(this, o_frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);
        }

        // Evento Click: Grupo Bodega
        private void mn_gru_bod_Click(object sender, EventArgs e)
        {
            o_frm = new inv001_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Bodega
        private void mn_bod_ega_Click(object sender, EventArgs e)
        {
            o_frm = new inv002_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Familia Producto
        private void mn_fam_pro_Click(object sender, EventArgs e)
        {
            o_frm = new inv003_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Producto
        private void mn_pro_duc_Click(object sender, EventArgs e)
        {
            o_frm = new inv004_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Marca Producto
        private void mn_mar_pro_Click(object sender, EventArgs e)
        {
            o_frm = new inv006_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Unidad de Medida
        private void mn_uni_med_Click(object sender, EventArgs e)
        {
            o_frm = new inv005_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Sucursal
        private void mn_suc_urs_Click(object sender, EventArgs e)
        {
            o_frm = new cmr003_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Lista de Precio
        private void mn_lis_pre_Click(object sender, EventArgs e)
        {
            o_frm = new cmr001_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Definición de Precio
        private void mn_def_pre_Click(object sender, EventArgs e)
        {
            o_frm = new cmr002_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Delivery
        private void mn_del_ive_Click(object sender, EventArgs e)
        {
            o_frm = new cmr015_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Registro Vendedor
        private void mn_reg_ven_Click(object sender, EventArgs e)
        {
            o_frm = new cmr014_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Registro Cobrador
        private void mn_reg_cob_Click(object sender, EventArgs e)
        {
            o_frm = new cmr014_01c();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Plantilla de Venta
        private void mn_pla_vta_Click(object sender, EventArgs e)
        {
            o_frm = new cmr004_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Grupo Persona
        private void mn_gru_per_Click(object sender, EventArgs e)
        {
            o_frm = new adp001_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Registro Persona
        private void mn_reg_per_Click(object sender, EventArgs e)
        {
            o_frm = new adp002_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Tipo de Atributo
        private void mn_tip_atr_Click(object sender, EventArgs e)
        {
            o_frm = new adp003_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Definición de Atributo
        private void mn_def_atr_Click(object sender, EventArgs e)
        {
            o_frm = new adp004_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Tipo Documento Persona
        private void mn_tip_doc_Click(object sender, EventArgs e)
        {
            o_frm = new adp014_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Grupo Empresarial
        private void mn_gru_emp_Click(object sender, EventArgs e)
        {
            o_frm = new adp018_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Definición de Rutas
        private void mn_def_rut_Click(object sender, EventArgs e)
        {
            o_frm = new adp007_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Relación Contacto Persona
        private void mn_rel_con_Click(object sender, EventArgs e)
        {
            o_frm = new adp017_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Valida Registro Persona
        private void mn_val_reg_Click(object sender, EventArgs e)
        {
            o_frm = new adp015_01();
            cl_glo_frm.abrir(this, o_frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        // Evento Click: Dosificación
        private void mn_dos_ifi_Click(object sender, EventArgs e)
        {
            o_frm = new ctb007_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Actividad Económica
        private void mn_act_eco_Click(object sender, EventArgs e)
        {
            o_frm = new cmr016_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Leyenda
        private void mn_ley_end_Click(object sender, EventArgs e)
        {
            o_frm = new ctb006_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Libretas
        private void mn_lib_ret_Click(object sender, EventArgs e)
        {
            o_frm = new ecp002_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Plan de Pago
        private void mn_pla_pgo_Click(object sender, EventArgs e)
        {
            o_frm = new ecp001_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Tasa de Cambio
        private void mn_tas_cam_Click(object sender, EventArgs e)
        {
            o_frm = new ads022_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Módulo
        private void mn_mod_ulo_Click(object sender, EventArgs e)
        {
            o_frm = new ads001_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Aplicaciones
        private void mn_apl_ica_Click(object sender, EventArgs e)
        {
            o_frm = new ads002_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Licencias Autorizadas
        private void mn_lic_aut_Click(object sender, EventArgs e)
        {

        }

        // Evento Click: Tipos de Imagen
        private void mn_tip_ima_Click(object sender, EventArgs e)
        {
            o_frm = new ads010_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        // Evento Click: Cerrar
        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            Close();
        }


        // Evento Click: Pie de Ventana
        private void st_bar_pie_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            o_frm = new ads000_06();
            Form frm_pad = new Form();

            //verifica que exista un menu valido            
            if (m_mod_ulo.Visible == true)
            {
                if (m_mod_ulo.Items.Count != 0)
                    frm_pad = this;
            }
            else
            {
                if (m_frm_hja.Items.Count != 0)
                    frm_pad = ActiveMdiChild;
            }
            
            if (frm_pad != null) { 
                cl_glo_frm.abrir(frm_pad, o_frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);
                if (o_frm.DialogResult == DialogResult.OK)
                    cl_glo_bal.fg_per_mnu(o_frm.tb_ide_usr.Text, frm_pad);
            }
        }        
    }
}
