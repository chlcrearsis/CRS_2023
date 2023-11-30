using System;
using System.Data;
using System.Text;
using CRS_DAT;
namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads010                                              ##
    //##      Nombre: Opciones del Menú                                   ##
    //## Descripcion: Opciones del Menú Formulario                        ##         
    //##       Autor: EJER - (07-09-2021)                                 ##
    //######################################################################
    public class ads011
    {        
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "Registrar Definicion Claves"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_cla">ID. Clave</param>
        /// <param name="nom_cla">Nombre</param>
        /// <param name="des_cla">Descripción</param>
        /// <param name="cla_req">Clave Requerido (S=Si; N=No)</param>
        public void Fe_nue_reg(int ide_mod, int ide_cla, string nom_cla, string des_cla, string cla_req)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads011 VALUES (" + ide_mod + ", " + ide_cla + ", '" + nom_cla + "', '" + des_cla + "', '" + cla_req + "')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Modifica Definicion Claves"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_cla">ID. Clave</param>
        /// <param name="nom_cla">Nombre</param>
        /// <param name="des_cla">Descripción</param>
        /// <param name="cla_req">Clave Requerido (S=Si; N=No)</param>
        /// <returns></returns>
        public void Fe_edi_tar(int ide_mod, int ide_cla, string nom_cla, string des_cla, string cla_req)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads011 SET va_nom_cla = '" + nom_cla + "',");
                cadena.AppendLine("                  va_des_cla = '" + des_cla + "',");
                cadena.AppendLine("                  va_cla_req = '" + cla_req + "'");
                cadena.AppendLine("            WHERE va_ide_mod = " + ide_mod + "");
                cadena.AppendLine("              AND va_ide_cla = " + ide_cla + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina Definicion Claves"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_cla">ID. Clave</param>
        /// <returns></returns>
        public void Fe_eli_min(int ide_mod, int ide_cla)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads011 WHERE va_ide_mod = " + ide_mod + " AND va_ide_cla = " + ide_cla + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "FILTRA MÓDULOS DEL SISTEMA"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (0=va_ide_mod; 1=va_ide_cla; 2=va_nom_cla)</param>
        /// <param name="ide_mod">ID. Módulo (0=Todos)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string cri_bus, int prm_bus, int ide_mod = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads001.va_abr_mod, ads001.va_nom_mod, ads011.va_ide_mod,");
                cadena.AppendLine("       ads011.va_ide_cla, ads011.va_nom_cla, ads011.va_des_cla,");
                cadena.AppendLine("       ads011.va_cla_req");
                cadena.AppendLine("  FROM ads011, ads001");
                cadena.AppendLine(" WHERE ads011.va_ide_mod = ads001.va_ide_mod");
                switch (prm_bus)
                {
                    case 0: cadena.AppendLine(" AND va_ide_mod like '" + cri_bus + "%'"); break;
                    case 1: cadena.AppendLine(" AND va_ide_cla like '" + cri_bus + "%'"); break;
                    case 2: cadena.AppendLine(" AND va_nom_cla like '" + cri_bus + "%'"); break;
                }
                

                if (ide_mod != 0)
                {
                    cadena.AppendLine(" AND va_ide_mod = " + ide_mod + "");
                }

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Consulta Definición Claves"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_cla">ID. Clave</param>
        /// <returns></returns>
        public DataTable Fe_con_mod(int ide_mod, int ide_cla)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads001.va_abr_mod, ads001.va_nom_mod, ads011.va_ide_mod,");
                cadena.AppendLine("       ads011.va_ide_cla, ads011.va_nom_cla, ads011.va_des_cla,");
                cadena.AppendLine("       ads011.va_cla_req");
                cadena.AppendLine("  FROM ads011, ads001");
                cadena.AppendLine(" WHERE ads011.va_ide_mod = ads001.va_ide_mod");
                cadena.AppendLine("   AND ads011.va_ide_mod = " + ide_mod + "");
                cadena.AppendLine("   AND ads011.va_ide_cla = " + ide_cla + "");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Consulta Definición Claves p/Módulo"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <returns></returns>
        public DataTable Fe_con_mod(int ide_mod)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads001.va_abr_mod, ads001.va_nom_mod, ads011.va_ide_mod,");
                cadena.AppendLine("       ads011.va_ide_cla, ads011.va_nom_cla, ads011.va_des_cla,");
                cadena.AppendLine("       ads011.va_cla_req");
                cadena.AppendLine("  FROM ads011, ads001");
                cadena.AppendLine("   AND ads011.va_ide_mod = ads001.va_ide_mod");
                cadena.AppendLine("   AND ads011.va_ide_mod = " + ide_mod + "");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Consulta Definición Claves p/Nombre"
        /// </summary>
        /// <param name="nom_cla">Nombre Clave</param>
        /// <returns></returns>
        public DataTable Fe_con_mod(string nom_cla)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads001.va_abr_mod, ads001.va_nom_mod, ads011.va_ide_mod,");
                cadena.AppendLine("       ads011.va_ide_cla, ads011.va_nom_cla, ads011.va_des_cla,");
                cadena.AppendLine("       ads011.va_cla_req");
                cadena.AppendLine("  FROM ads011, ads001");
                cadena.AppendLine(" WHERE ads011.va_ide_mod = ads001.va_ide_mod");
                cadena.AppendLine("   AND ads011.va_nom_cla like '" + nom_cla + "%'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Consulta Definición Claves p/Descripción"
        /// </summary>
        /// <param name="des_cla">Descripción Clave</param>
        /// <returns></returns>
        public DataTable Fe_con_des(string des_cla)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads001.va_abr_mod, ads001.va_nom_mod, ads011.va_ide_mod,");
                cadena.AppendLine("       ads011.va_ide_cla, ads011.va_nom_cla, ads011.va_des_cla,");
                cadena.AppendLine("       ads011.va_cla_req");
                cadena.AppendLine("  FROM ads011, ads001");
                cadena.AppendLine(" WHERE ads011.va_ide_mod = ads001.va_ide_mod");
                cadena.AppendLine("   AND ads011.va_des_cla like '" + des_cla + "%'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}