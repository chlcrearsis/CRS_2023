using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads012 - Autorización del Menú p/Usuario              */
    /* Descripción: Registra Autorización                                 */
    /*       Autor: JEJR - Crearsis             Fecha: 30-09-2023         */
    /**********************************************************************/
    public partial class ads012_01 : Form
    {        
        public int frm_tip;
        public DataTable frm_dat;
        public dynamic frm_pad;
        // Instancias
        ads007 o_ads007 = new ads007();
        ads012 o_ads012 = new ads012();
        ads019 o_ads019 = new ads019();
        DataTable Tabla = new DataTable();
        // Variables 
        bool vp_chk_reg = true;
        bool vp_ini_ope = false;
        public string vp_ide_usr;
        public string vp_ide_frm;
        public string vp_tex_frm;
        public MenuStrip mn_men_usr;        

        public ads012_01()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Inicializa Datos
            tb_ide_usr.Text = vp_ide_usr;
            tb_ide_frm.Text = vp_ide_frm;
            lb_nom_frm.Text = vp_tex_frm;

            // Obtiene datos del Usuario
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_con_ide(vp_ide_usr);
            if (Tabla.Rows.Count > 0)
                lb_nom_usr.Text = Tabla.Rows[0]["va_nom_usr"].ToString();
            else
                lb_nom_usr.Text = "NO Existe";

            // Busca y Desplega Opcion del Hilo Nivel 1
            fi_bus_hi1();
            // Establece el Cheked Todos 
            ch_che_tod.Checked = vp_chk_reg;
            // Habilita el Inicio de Operación
            vp_ini_ope = true;
        }

        /// <summary>
        /// Busca y Desplega Opcion del Hilo Nivel 1
        /// </summary>
        public void fi_bus_hi1()
        {
            vp_chk_reg = true;

            // Recrea todas las opciones del menu en el arbol
            foreach (object item in mn_men_usr.Items)
            {
                // Verifica que no sea ToolStripSeparator
                if (!(item is ToolStripMenuItem itm_hi1))
                    continue;

                // Valida que no se quite el boton de atras
                if (itm_hi1.Text == "&Atras")                
                    break;                

                // Adiciona la opcion del menu al arbol
                dg_res_ult.Nodes.Add(itm_hi1.Name, itm_hi1.Text.Replace("&", ""));

                // Verifica si la opcion está o no restringida
                Tabla = new DataTable();
                Tabla = o_ads012.Fe_aut_men(tb_ide_usr.Text, tb_ide_frm.Text, itm_hi1.Name);

                // Si Existe = Restringido
                if (Tabla.Rows.Count != 0) {
                    vp_chk_reg = false;
                    dg_res_ult.Nodes[itm_hi1.Name].Checked = false;
                }else // Si No existe = Tiene Permiso                                   
                    dg_res_ult.Nodes[itm_hi1.Name].Checked = true;

                // Busca y Desplega Opcion del Hilo Nivel 2
                fi_bus_hi2(itm_hi1);
            }
        }

        /// <summary>
        /// Busca y Desplega Opcion del Hilo Nivel 2
        /// </summary>
        /// <param name="itm_hi1">Item Hilo Nivel 1</param>
        private void fi_bus_hi2(ToolStripMenuItem itm_hi1)
        {
            foreach (object item in itm_hi1.DropDownItems)
            {
                // Verifica que no sea ToolStripSeparator
                if (!(item is ToolStripMenuItem itm_hi2))
                    continue;

                // Adiciona la opcion del menu al arbol
                dg_res_ult.Nodes[itm_hi1.Name].Nodes.Add(itm_hi2.Name, itm_hi2.Text.Replace("&", ""));

                // Verifica que la opcion no este restringida
                Tabla = new DataTable();
                Tabla = o_ads012.Fe_aut_men(tb_ide_usr.Text, tb_ide_frm.Text, itm_hi2.Name);

                // Si existe = permiso restringido
                if (Tabla.Rows.Count != 0){
                    vp_chk_reg = false;
                    dg_res_ult.Nodes[itm_hi1.Name].Nodes[itm_hi2.Name].Checked = false;
                }else
                    // Si NO existe = Tiene permiso
                    dg_res_ult.Nodes[itm_hi1.Name].Nodes[itm_hi2.Name].Checked = true;

                // Busca y Desplega Opcion del Hilo Nivel 3
                if (itm_hi2.DropDownItems.Count > 0)                
                    fi_bus_hi3(itm_hi1, itm_hi2);                
            }
        }

        /// <summary>
        /// Busca y Desplega Opcion del Hilo Nivel 3
        /// </summary>
        /// <param name="itm_hi1">Item Hilo Nivel 1</param>
        /// <param name="itm_hi2">Item Hilo Nivel 2</param>
        private void fi_bus_hi3(ToolStripMenuItem itm_hi1, ToolStripMenuItem itm_hi2)
        {            
            foreach (object item in itm_hi2.DropDownItems)
            {
                // Verifica que no sea ToolStripSeparator
                if (!(item is ToolStripMenuItem itm_hi3))
                    continue;

                // Adiciona la opcion del menu al arbol
                dg_res_ult.Nodes[itm_hi1.Name].Nodes[itm_hi2.Name].Nodes.Add(itm_hi3.Name, itm_hi3.Text.Replace("&", ""));

                // verifica que la opcion no este restringida
                Tabla = new DataTable();
                Tabla = o_ads012.Fe_aut_men(tb_ide_usr.Text, tb_ide_frm.Text, itm_hi3.Name);

                // Si existe = permiso restringido
                if (Tabla.Rows.Count != 0){
                    vp_chk_reg = false;
                    dg_res_ult.Nodes[itm_hi1.Name].Nodes[itm_hi2.Name].Nodes[itm_hi3.Name].Checked = false;
                }else // Si NO existe = Tiene permiso
                    dg_res_ult.Nodes[itm_hi1.Name].Nodes[itm_hi2.Name].Nodes[itm_hi3.Name].Checked = true;

                // Busca y Desplega Opcion del Hilo Nivel 3
                if (itm_hi3.DropDownItems.Count > 0)
                    fi_bus_hi4(itm_hi1, itm_hi2, itm_hi3);
            }            
        }

        /// <summary>
        /// Busca y Desplega Opcion del Hilo Nivel 4
        /// </summary>
        /// <param name="itm_hi1">Item Hilo Nivel 1</param>
        /// <param name="itm_hi2">Item Hilo Nivel 2</param>
        /// <param name="itm_hi3">Item Hilo Nivel 3</param>
        private void fi_bus_hi4(ToolStripMenuItem itm_hi1, ToolStripMenuItem itm_hi2, ToolStripMenuItem itm_hi3)
        {
            foreach (object item in itm_hi3.DropDownItems)
            {
                // Verifica que no sea ToolStripSeparator
                if (!(item is ToolStripMenuItem itm_hi4))
                    continue;

                // Adiciona la opcion del menu al arbol
                dg_res_ult.Nodes[itm_hi1.Name].Nodes[itm_hi2.Name].Nodes[itm_hi3.Name].Nodes.Add(itm_hi4.Name, itm_hi3.Text.Replace("&", ""));

                // Verifica que la opcion no este restringida
                Tabla = new DataTable();
                Tabla = o_ads012.Fe_aut_men(tb_ide_usr.Text, tb_ide_frm.Text, itm_hi4.Name);

                // Si existe = permiso restringido
                if (Tabla.Rows.Count != 0){
                    vp_chk_reg = false;
                    dg_res_ult.Nodes[itm_hi1.Name].Nodes[itm_hi2.Name].Nodes[itm_hi3.Name].Nodes[itm_hi4.Name].Checked = false;
                }else // Si NO existe = Tiene permiso
                    dg_res_ult.Nodes[itm_hi1.Name].Nodes[itm_hi2.Name].Nodes[itm_hi3.Name].Nodes[itm_hi4.Name].Checked = true;
            }
        }

        /// <summary>
        /// Graba Opcion del Hilo Nivel 1
        /// </summary>
        private void fi_gra_hi1()
        {
            foreach (TreeNode tnd_hi1 in dg_res_ult.Nodes)
            {
                // Permitido
                if (dg_res_ult.Nodes[tnd_hi1.Name].Checked == true)                
                    // Si esta tikeado, no deberia tener registro en la BD (permiso permitido)
                    o_ads012.Fe_eli_min(tb_ide_usr.Text, tb_ide_frm.Text, tnd_hi1.Name);
                else { // Denegado
                    // Si NO esta tikeado, Deberia tener registro en la BD (permiso denegado)
                    o_ads012.Fe_eli_min(tb_ide_usr.Text, tb_ide_frm.Text, tnd_hi1.Name);                    
                    o_ads012.Fe_nue_reg(tb_ide_usr.Text, tb_ide_frm.Text, tnd_hi1.Name);
                }
                // Graba Item Opción Nivel 2
                fi_gra_hi2(tnd_hi1);
            }

            // Vuelve a Cargar el Menu
            if (frm_pad.IsMdiContainer == true)
                frm_pad.fu_ver_mnu(tb_ide_usr.Text, frm_pad);            
            else
                frm_pad.MdiParent.fu_ver_mnu(tb_ide_usr.Text, frm_pad);            
        }

        /// <summary>
        /// Graba Opcion del Hilo Nivel 2
        /// </summary>
        /// <param name="tnd_hi1">Item Hilo Nivel 1</param>
        private void fi_gra_hi2(TreeNode tnd_hi1)
        {
            foreach (TreeNode tnd_hi2 in tnd_hi1.Nodes)
            {
                // Permitido
                if (tnd_hi1.Nodes[tnd_hi2.Name].Checked == true)                
                    // Si esta tikeado, no deberia tener registro en la BD (permiso permitido)
                    o_ads012.Fe_eli_min(tb_ide_usr.Text, tb_ide_frm.Text, tnd_hi2.Name);                                    
                else { // Denegado
                    // Si NO esta tikeado, Deberia tener registro en la BD (permiso denegado)
                    o_ads012.Fe_eli_min(tb_ide_usr.Text, tb_ide_frm.Text, tnd_hi2.Name);
                    o_ads012.Fe_nue_reg(tb_ide_usr.Text, tb_ide_frm.Text, tnd_hi2.Name);                    
                }
                // Graba Item Opción Nivel 3
                fu_gra_hi3(tnd_hi2);
            }
        }

        /// <summary>
        /// Graba Opcion del Hilo Nivel 3
        /// </summary>
        /// <param name="tnd_hi2">Item Hilo Nivel 2</param>
        private void fu_gra_hi3(TreeNode tnd_hi2)
        {
            foreach (TreeNode tnd_hi3 in tnd_hi2.Nodes)
            {
                // Permitido
                if (tnd_hi2.Nodes[tnd_hi3.Name].Checked == true)
                    // Si esta tikeado, no deberia tener registro en la BD (permiso permitido)
                    o_ads012.Fe_eli_min(tb_ide_usr.Text, tb_ide_frm.Text, tnd_hi3.Name);
                else { // Denegado
                    // Si NO esta tikeado, Deberia tener registro en la BD (permiso denegado)
                    o_ads012.Fe_eli_min(tb_ide_usr.Text, tb_ide_frm.Text, tnd_hi3.Name);
                    o_ads012.Fe_nue_reg(tb_ide_usr.Text, tb_ide_frm.Text, tnd_hi3.Name);
                }
                // Graba Item Opción Nivel 4
                fu_gra_hi4(tnd_hi3);
            }
        }

        /// <summary>
        /// Graba Opcion del Hilo Nivel 4
        /// </summary>
        /// <param name="tnd_hi3">Item Hilo Nivel 3</param>
        private void fu_gra_hi4(TreeNode tnd_hi3)
        {
            foreach (TreeNode tnd_hi4 in tnd_hi3.Nodes)
            {
                // Permitido
                if (tnd_hi3.Nodes[tnd_hi4.Name].Checked == true)
                    // Si esta tikeado, no deberia tener registro en la BD (permiso permitido)
                    o_ads012.Fe_eli_min(tb_ide_usr.Text, tb_ide_frm.Text, tnd_hi4.Name);
                else { // Denegado
                    // Si NO esta tikeado, Deberia tener registro en la BD (permiso denegado)
                    o_ads012.Fe_eli_min(tb_ide_usr.Text, tb_ide_frm.Text, tnd_hi4.Name);
                    o_ads012.Fe_nue_reg(tb_ide_usr.Text, tb_ide_frm.Text, tnd_hi4.Name);
                }
            }
        }

        // Funcion: CheckeAll Nodes
        public void CheckAllNodes(TreeNodeCollection nodes, bool est_ado)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = est_ado;
                CheckChildren(node, est_ado);
            }
        }

        // Funcion: CheckeAll o Not Checke Nodes
        private void CheckChildren(TreeNode rootNode, bool isChecked)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }

        // Evento CheckedChanged: Checked Todos
        private void ch_che_tod_CheckedChanged(object sender, EventArgs e)
        {
            if (vp_ini_ope)
            {
                // Establece el estado del Checked
                if (vp_chk_reg)
                    vp_chk_reg = false;
                else
                    vp_chk_reg = true;

                // Cambia el estado del Nodo
                CheckAllNodes(dg_res_ult.Nodes, vp_chk_reg);
            }
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                // Graba Permisos del Menu al Usuario
                fi_gra_hi1();
                // Graba Bitacora de Operaciones
                o_ads019.Fe_nue_reg(cl_glo_bal.glo_ide_usr, 1, Name, Text, "E", "Usuario: " + tb_ide_usr.Text.Trim() + "-" + lb_nom_usr.Text.Trim(), SystemInformation.ComputerName);
                // Despliega Mensaje
                MessageBox.Show("Operación completada exitosamente", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Cierra Formulario
                cl_glo_frm.Cerrar(this);
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
