using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads013                                              ##
    //##      Nombre: Globales del Sistema                                ##
    //## Descripcion: Definiciones de Globales                            ##         
    //##       Autor: EJER - (27-11-2023)                                 ##
    //######################################################################
    public class ads013
    {
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "Registra Globales por Defectos"
        /// </summary>
        public void Fe_reg_glo()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads013_02b_p01");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Registra Global"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_glo">ID. Global</param>
        /// <param name="nom_glo">Nombre</param>
        /// <param name="tip_glo">Tipo Global (1=Caracter; 2=Numérico; 3=Decimal)</param>
        /// <param name="glo_car">Global Caracter</param>
        /// <param name="glo_ent">Global Numérico</param>
        /// <param name="glo_dec">Global Decimal</param>
        public void Fe_nue_reg(int ide_mod, int ide_glo, string nom_glo, int tip_glo, int glo_ent, decimal glo_dec, string glo_car)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads013 VALUES ( " + ide_mod + ", " + ide_glo + ", '" + nom_glo + "', " + tip_glo + ", " + glo_ent + ", " + glo_dec + ", '" + glo_car + "')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Funcion "Modifica Global"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_glo">ID. Global</param>
        /// <param name="nom_glo">Nombre</param>
        /// <param name="tip_glo">Tipo Global (1=Caracter; 2=Numérico; 3=Decimal)</param>
        /// <param name="glo_car">Global Caracter</param>
        /// <param name="glo_ent">Global Numérico</param>
        /// <param name="glo_dec">Global Decimal</param>
        public void Fe_edi_tar(int ide_mod, int ide_glo, string nom_glo, int tip_glo, int glo_ent, decimal glo_dec, string glo_car)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads013 SET va_nom_glo = '" + nom_glo + "',");
                cadena.AppendLine("                  va_tip_glo =  " + tip_glo + ",");                
                cadena.AppendLine("                  va_glo_ent =  " + glo_ent + ",");
                cadena.AppendLine("                  va_glo_dec =  " + glo_dec + ",");
                cadena.AppendLine("                  va_glo_car = '" + glo_car + "'");
                cadena.AppendLine("            WHERE va_ide_mod =  " + ide_mod + "");
                cadena.AppendLine("              AND va_ide_glo =  " + ide_glo + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina Global"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_glo">ID. Global</param>
        /// <returns></returns>
        public void Fe_eli_min(int ide_mod, int ide_glo)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads013 WHERE va_ide_mod = " + ide_mod + " AND va_ide_glo = " + ide_glo + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "FILTRA GLOBALES DEL SISTEMA"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (0=va_ide_glo; 1=va_nom_glo)</param>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string cri_bus, int prm_bus, int ide_mod = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads013.va_ide_mod, ads001.va_nom_mod, ads013.va_ide_glo,");
                cadena.AppendLine("       ads013.va_nom_glo, ads013.va_tip_glo, ads013.va_glo_ent,");
                cadena.AppendLine("       ads013.va_glo_dec, ads013.va_glo_car");
                cadena.AppendLine("  FROM ads013, ads001");
                cadena.AppendLine(" WHERE ads013.va_ide_mod = ads001.va_ide_mod");
                cadena.AppendLine("   AND ads013.va_ide_glo < 100");
                
                if (ide_mod != 0)
                    cadena.AppendLine(" AND ads013.va_ide_mod = " + ide_mod);

                switch (prm_bus)
                {
                    case 0: cadena.AppendLine(" AND ads013.va_ide_glo like '" + cri_bus + "%'"); break;
                    case 1: cadena.AppendLine(" AND ads013.va_nom_glo like '" + cri_bus + "%'"); break;
                }
                

                        return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA LA GLOBAL"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_glo">ID. Global</param>
        /// <returns></returns>
        public DataTable Fe_con_glo(int ide_mod, int ide_glo)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads013.va_ide_mod, ads001.va_nom_mod, ads013.va_ide_glo,");
                cadena.AppendLine("       ads013.va_nom_glo, ads013.va_tip_glo, ads013.va_glo_ent,");
                cadena.AppendLine("       ads013.va_glo_dec, ads013.va_glo_car");
                cadena.AppendLine("  FROM ads013, ads001");
                cadena.AppendLine(" WHERE ads013.va_ide_mod = ads001.va_ide_mod");
                cadena.AppendLine("   AND ads013.va_ide_mod = " + ide_mod + "");
                cadena.AppendLine("   AND ads013.va_ide_glo = " + ide_glo + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA LA GLOBAL"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="nom_glo">Nombre Global</param>
        /// <returns></returns>
        public DataTable Fe_con_nom(int ide_mod, string nom_glo, int ide_glo = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads013.va_ide_mod, ads001.va_nom_mod, ads013.va_ide_glo,");
                cadena.AppendLine("       ads013.va_nom_glo, ads013.va_tip_glo, ads013.va_glo_ent,");
                cadena.AppendLine("       ads013.va_glo_dec, ads013.va_glo_car");
                cadena.AppendLine("  FROM ads013, ads001");
                cadena.AppendLine(" WHERE ads013.va_ide_mod = ads001.va_ide_mod");
                cadena.AppendLine("   AND ads013.va_ide_mod =  " + ide_mod + "");
                cadena.AppendLine("   AND ads013.va_nom_glo = '" + nom_glo + "'");

                if (ide_glo > 0)
                    cadena.AppendLine("   AND ads013.va_ide_glo <>  " + ide_glo + "");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "OBTIENE GLOBAL"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_glo">ID. Global</param>
        /// <returns></returns>
        public DataTable Fe_obt_glo(int ide_mod, int ide_glo)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads013.va_ide_mod, ads001.va_nom_mod, ads013.va_ide_glo,");
                cadena.AppendLine("       ads013.va_nom_glo, ads013.va_tip_glo, ads013.va_glo_ent,");
                cadena.AppendLine("       ads013.va_glo_dec, ads013.va_glo_car");
                cadena.AppendLine("  FROM ads013, ads001");
                cadena.AppendLine(" WHERE ads013.va_ide_mod = ads001.va_ide_mod");
                cadena.AppendLine("   AND ads013.va_ide_mod = " + ide_mod + "");
                cadena.AppendLine("   AND ads013.va_ide_glo = " + ide_glo + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        /// <summary>
        /// Funcion "Obtiene el Último ID. Global"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <returns></returns>
        public DataTable Fe_obt_ide(int ide_mod)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DECLARE @va_ide_glo INT ");
                cadena.AppendLine(" SELECT @va_ide_glo = ISNULL(MAX(va_ide_glo), 0) FROM ads013 WHERE va_ide_mod = " + ide_mod + "");
                cadena.AppendLine(" SELECT @va_ide_glo + 1 AS va_ide_glo");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe: Definición de Globales
        /// </summary>        
        /// <param name="mod_ini">ID. Módulo Inicial</param>
        /// <param name="mod_fin">ID. Módulo Final</param>
        /// <param name="ord_dat">Orden Datos (C=Código; N=Nombre)</param>
        /// <returns></returns>
        public DataTable Fe_inf_R01(int mod_ini, int mod_fin, string ord_dat)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads013_R01 " + mod_ini + ", " + mod_fin + ", '" + ord_dat + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
