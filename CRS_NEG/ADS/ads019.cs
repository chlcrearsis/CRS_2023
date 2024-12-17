using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads019                                              ##
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
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_apl">ID. Aplicación</param>
        /// <param name="nom_apl">Nombre Aplicación</param>
        /// <param name="tip_ope">Tipo de Operación (N=Nuevo; E=Edita; H=Habilita; D=Deshabilita; A=Anula; C=Concluye; P=Aprueba; R=Rechaza</param>        
        /// <param name="obs_reg">Observación</param>
        /// <param name="nom_maq">Nombre de la Maquina</param>
        /// <returns></returns>
        public void Fe_nue_reg(string ide_usr, int ide_mod, string ide_apl, string nom_apl, string tip_ope, string obs_reg, string nom_maq)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads019 VALUES ('" + ide_usr + "', GETDATE(), " + ide_mod + ", '" + ide_apl + "', '" + nom_apl + "', '" + tip_ope + "', '" + obs_reg + "', '" + nom_maq + "')");
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
                cadena.AppendLine("SELECT ads019.va_ide_usr, ads019.va_fch_reg, ads019.va_ide_mod,");
                cadena.AppendLine("       ads019.va_ide_apl, ads019.va_nom_apl, ads019.va_tip_ope,");
                cadena.AppendLine("       ads019.va_obs_reg, ads019.va_nom_maq");
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
        /// Informe 01: "Bitácora de Operaciónes p/Rango de Fecha"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="apl_ini">ID. Usuario Inicial</param>
        /// <param name="apl_fin">ID. Usuario Final</param>
        /// <param name="fec_ini">Fecha Inicial</param>
        /// <param name="fec_fin">Fecha Final</param>
        /// <param name="tip_ope">Tipo de Operacion (T=Todos; N=Nuevo; E=Edita; A=Anula; C=Concluye; L=Elimina; P=Aprueba; R=Rechaza; M=Importa; X=Exporta; I=Informe)</param>
        /// <returns></returns>
        public DataTable Fe_inf_R01(int ide_mod, string apl_ini, string apl_fin, string fec_ini, string fec_fin, string tip_ope)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads019_R01 " + ide_mod + ", '" + apl_ini + "', '" + apl_fin + "', '" + fec_ini + "', '" + fec_fin + "', '" + tip_ope + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
