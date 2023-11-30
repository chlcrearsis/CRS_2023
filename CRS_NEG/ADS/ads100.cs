using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads100                                              ##
    //##      Nombre: Licencia del Sistema                                ##
    //## Descripcion: Obtiene y Establece las Licencias del Sistema       ##         
    //##       Autor: EJER - (27-11-2023)                                 ##
    //######################################################################
    public class ads100
    {
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

       
       
        /// <summary>
        /// Funcion "OBTIENE LICENCIA DEL SISTEMA"
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_obt_lic()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads100_01a_p01");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Funcion "Registra Licencia"
        /// </summary>
        /// <param name="nro_usr">Nro. Usuario</param>
        /// <param name="fec_exp">Fecha de Expiración</param>
        /// <param name="mod_ads">Módulo ADS -> Administración</param>
        /// <param name="mod_inv">Módulo INV -> Inventario</param>
        /// <param name="mod_cmr">Módulo CMR -> Comercialización</param>
        /// <param name="mod_ctb">Módulo CTB -> Contabilidad</param>
        /// <param name="mod_tes">Módulo TES -> Tesoreria</param>
        /// <param name="mod_res">Módulo RES -> Restaurant</param>
        public void Fe_gra_lic(int nro_usr, string fec_exp, string mod_ads, string mod_inv, 
                            string mod_cmr, string mod_ctb, string mod_tes, string mod_res)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads100_02a_p01 " + nro_usr + ",");
                cadena.AppendLine("                      '" + fec_exp + "',");
                cadena.AppendLine("                      '" + mod_ads + "',");
                cadena.AppendLine("                      '" + mod_inv + "',");
                cadena.AppendLine("                      '" + mod_cmr + "',");
                cadena.AppendLine("                      '" + mod_ctb + "',");
                cadena.AppendLine("                      '" + mod_tes + "',");
                cadena.AppendLine("                      '" + mod_res + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
