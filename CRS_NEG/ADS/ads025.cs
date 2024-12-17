using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads025                                              ##
    //##      Nombre: Validación Clave Usuario                            ##
    //## Descripcion: Registro de Validación Clave Usuario                ##         
    //##       Autor: JEJR - (13-01-2024)                                 ##
    //######################################################################
    public class ads025
    {
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Función: "Registra Bitacora de Operaciones"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="usr_sol">ID. Usuario Solicitante</param>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_cla">ID. Clave</param>
        /// <param name="nom_maq">Nombre PC-Maquina</param>
        /// <param name="obs_reg">Observación</param>
        /// <returns></returns>
        public void Fe_nue_reg(string ide_usr, string usr_sol, int ide_mod, int ide_cla, string nom_maq, string obs_reg)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads025 VALUES ('" + ide_usr + "', GETDATE(), '" + usr_sol + "', " + ide_mod + ", " + ide_cla + ", '" + nom_maq + "', '" + obs_reg + "')");
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
                cadena.AppendLine("EXECUTE ads025_R01 '" + usr_ini + "', '" + usr_fin + "', '" + fec_ini + "', '" + fec_fin + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
