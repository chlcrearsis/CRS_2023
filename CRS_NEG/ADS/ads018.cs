using System;
using System.Data;
using System.Text;
using CRS_DAT;
namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads018_01                                           ##
    //##      Nombre: Bitacora de Inicio de Sesion                        ##
    //## Descripcion: Registro de Inicio y Cierre de Sesión               ##         
    //##       Autor: JEJR - (27-02-2021)                                 ##
    //######################################################################
    public class ads018
    {
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Registra Bitacora de Inicio de Sesion
        /// </summary>
        /// <param name="ide_uni">Identificador Unico</param>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="nom_maq">Nombre de la Maquina</param>
        /// <returns></returns>
        public void Fe_ini_ses(string ide_uni, string ide_usr, string nom_maq)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads018_01a_p01 '" + ide_uni + "', '" + ide_usr + "', '" + nom_maq + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Registra Bitacora de Cierre de Sesion
        /// </summary>
        /// <param name="ide_uni">Identificador Unico</param>
        public void Fe_fin_ses(string ide_uni)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads018_02a_p01 '" + ide_uni + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe 01: "Bitacora de Inicio de Sesion"
        /// </summary>
        /// <param name="usr_ini">ID. Usuario Inicial</param>
        /// <param name="usr_fin">ID. Usuario Final</param>
        /// <param name="fec_ini">Fecha Inicial</param>
        /// <param name="fec_fin">Fecha Final</param>
        /// <returns></returns>
        public DataTable Fe_inf_R01(string usr_ini, string usr_fin, string fec_ini, string fec_fin)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads018_R01 '" + usr_ini + "', '" + usr_fin + "', '" + fec_ini + "', '" + fec_fin + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
