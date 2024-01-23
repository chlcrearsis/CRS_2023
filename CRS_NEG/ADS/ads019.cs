using System;
using System.Data;
using System.Text;
using CRS_DAT;
namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads019_01                                           ##
    //##      Nombre: Bitacora de Operaciones                             ##
    //## Descripcion: Registro de Bitacora de Operaciones                 ##         
    //##       Autor: JEJR - (13-01-2024)                                 ##
    //######################################################################
    public class ads019
    {
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Función: "Registra Bitacora de Operaciones"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="nom_apl">Nombre Aplicación</param>
        /// <param name="tip_ope">Tipo de Operación (N=Nuevo; E=Edita; H=Habilita; D=Deshabilita; A=Anula; C=Concluye; P=Aprueba; R=Rechaza</param>
        /// <param name="nom_maq">Nombre de la Maquina</param>
        /// <param name="obs_reg">Observación</param>
        /// <returns></returns>
        public void Fe_nue_reg(string ide_usr, string nom_apl, string tip_ope, string nom_maq, string obs_reg)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads019 VALUES ('" + ide_usr + "', GETDATE(), '" + nom_apl + "', '" + tip_ope + "', '" + nom_maq + "', '" + obs_reg + "')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Consultar Bitacora de Operaciones p/Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <returns></returns>
        public DataTable Fe_con_usr(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads019.va_ide_usr, ads019.va_fch_reg, ads019.va_nom_apl,");
                cadena.AppendLine("       ads019.va_tip_ope, ads019.va_nom_maq, ads019.va_obs_reg,");
                cadena.AppendLine("       ads019.va_obs_reg");
                cadena.AppendLine("  FROM ads019, ads007");
                cadena.AppendLine(" WHERE ads019.va_ide_usr = ads007.va_ide_usr");
                cadena.AppendLine("   AND ads019.va_ide_usr = '" + ide_usr + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
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
                cadena.AppendLine("EXECUTE ads019_R01 '" + usr_ini + "', '" + usr_fin + "', '" + fec_ini + "', '" + fec_fin + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
