using CRS_DAT;
using System;
using System.Data;
using System.Text;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads010                                              ##
    //##      Nombre: Autorixación del Menú p/Usuario                     ##
    //## Descripcion: Autorixación del Menú p/Usuario                     ##         
    //##       Autor: EJER - (30-09-2023)                                 ##
    //######################################################################
    public class ads012
    {
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;
       
        /// <summary>
        /// Funcion "Registrar Autorización del Menu p/Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="nom_frm">Nombre Formulario</param>
        /// <param name="ide_men">ID. Menu Formulario</param>
        /// <returns></returns>
        public void Fe_nue_reg(string ide_usr, string nom_frm, string ide_men)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads012 VALUES ('" + ide_usr + "', '" + nom_frm + "', '" + ide_men + "')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina Autorización del Menu p/Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="nom_frm">Nombre Formulario</param>
        /// <param name="ide_men">ID. Menu Formulario</param>
        /// <returns></returns>
        public void Fe_eli_min(string ide_usr, string nom_frm, string ide_men)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads012 WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("                AND va_nom_frm = '" + nom_frm + "'");
                cadena.AppendLine("                AND va_ide_men = '" + ide_men + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA AUTORIZACIÓN DEL MENU P/USUARIO"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <returns></returns>
        public DataTable Fe_aut_men(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_usr, va_nom_frm, va_ide_men");
                cadena.AppendLine("  FROM ads012");
                cadena.AppendLine(" WHERE va_ide_usr = '" + ide_usr + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA AUTORIZACIÓN DEL MENU P/USUARIO"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="nom_frm">Nombre Formulario</param>
        /// <returns></returns>
        public DataTable Fe_aut_men(string ide_usr, string nom_frm)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_usr, va_nom_frm, va_ide_men");
                cadena.AppendLine("  FROM ads012");
                cadena.AppendLine(" WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("   AND va_nom_frm = '" + nom_frm + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA AUTORIZACIÓN DEL MENU P/USUARIO"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="nom_frm">Nombre Formulario</param>
        /// <param name="ide_men">ID. Menu Formulario</param>
        /// <returns></returns>
        public DataTable Fe_aut_men(string ide_usr, string nom_frm, string ide_men)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_usr, va_nom_frm, va_ide_men");
                cadena.AppendLine("  FROM ads012");
                cadena.AppendLine(" WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("   AND va_nom_frm = '" + nom_frm + "'");
                cadena.AppendLine("   AND va_ide_men = '" + ide_men + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }                       
    }
}
