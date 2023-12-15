using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads014                                              ##
    //##      Nombre: Clave Usuario p/Global                              ##
    //## Descripcion: Definición Clave Usuario p/Global                   ##         
    //##       Autor: EJER - (13-12-2023)                                 ##
    //######################################################################
    public class ads014
    {
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "Registra Clave Usuario p/Global"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_cla">ID. Clave</param>
        /// <param name="cla_usr">Clave Usuario</param>
        public void Fe_nue_reg(string ide_usr, int ide_mod, int ide_cla, string cla_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads014 VALUES ('" + ide_usr + "', " + ide_mod + ", " + ide_cla + ", '" + cla_usr + "', GETDATE())");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Funcion "Modifica Clave Usuario p/Global"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_cla">ID. Clave</param>
        /// <param name="cla_usr">Clave Usuario</param>
        public void Fe_edi_tar(string ide_usr, int ide_mod, int ide_cla, string cla_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads014 SET va_cla_usr = '" + cla_usr + "',");
                cadena.AppendLine("                  va_fec_reg = GETDATE()");
                cadena.AppendLine("            WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("              AND va_ide_mod =  " + ide_mod + "");
                cadena.AppendLine("              AND va_ide_cla =  " + ide_cla + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }                

        /// <summary>
        /// Funcion "Elimina Clave Usuario p/Global"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_cla">ID. Clave</param>
        /// <returns></returns>
        public void Fe_eli_min(string ide_usr, int ide_mod, int ide_cla)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads014 WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("                AND va_ide_mod =  " + ide_mod + "");
                cadena.AppendLine("                AND va_ide_cla =  " + ide_cla + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina Clave Usuario p/Global"
        /// </summary>        
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_cla">ID. Clave</param>
        /// <returns></returns>
        public void Fe_eli_min(int ide_mod, int ide_cla)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads014 WHERE va_ide_mod =  " + ide_mod + "");
                cadena.AppendLine("                AND va_ide_cla =  " + ide_cla + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Obtiene Clave Usuario p/Global"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_cla">ID. Clave</param>
        /// <returns></returns>
        public DataTable Fe_obt_cla(string ide_usr, int ide_mod, int ide_cla)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads014.va_ide_usr, ads014.va_ide_mod, ads001.va_nom_mod,");
                cadena.AppendLine("       ads014.va_ide_cla, ads011.va_nom_cla, ads014.va_cla_usr,");
                cadena.AppendLine("       ads014.va_fec_reg");
                cadena.AppendLine("  FROM ads014, ads011, ads001");
                cadena.AppendLine(" WHERE ads014.va_ide_mod = ads001.va_ide_mod");
                cadena.AppendLine("   AND ads014.va_ide_cla = ads011.va_ide_cla");
                cadena.AppendLine("   AND ads014.va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("   AND ads014.va_ide_mod =  " + ide_mod + "");
                cadena.AppendLine("   AND ads014.va_ide_cla =  " + ide_cla + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Obtiene Claves del Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <returns></returns>
        public DataTable Fe_cla_usr(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads014.va_ide_usr, ads014.va_ide_mod, ads001.va_nom_mod,");
                cadena.AppendLine("       ads014.va_ide_cla, ads011.va_nom_cla, ads014.va_cla_usr,");
                cadena.AppendLine("       ads014.va_fec_reg");
                cadena.AppendLine("  FROM ads014, ads011, ads001");
                cadena.AppendLine(" WHERE ads014.va_ide_mod = ads001.va_ide_mod");
                cadena.AppendLine("   AND ads014.va_ide_cla = ads011.va_ide_cla");
                cadena.AppendLine("   AND ads014.va_ide_usr = '" + ide_usr + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Lista de Claves Autorizadas p/Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <returns></returns>
        public DataTable Fe_lis_cla(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads014_01a_p01 '" + ide_usr + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
