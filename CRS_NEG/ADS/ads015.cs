using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads015                                              ##
    //##      Nombre: Regional                                            ##
    //## Descripcion: Regional/Unidad de Negocio                          ##         
    //##       Autor: EJR - (15-12-2023)                                  ##
    //######################################################################
    public class ads015
    {        
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Función: "Registrar Regional"
        /// </summary>
        /// <param name="ide_reg">ID. Regional</param>
        /// <param name="nom_reg">Nombre</param>
        /// <param name="nom_cor">Nombre Corto</param>
        /// <returns></returns>
        public void Fe_nue_reg(int ide_reg, string nom_reg, string nom_cor)
        {            
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads015 VALUES (" + ide_reg + ", '" + nom_reg + "', '" + nom_cor + "', 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Modifica Regional"
        /// </summary>
        /// <param name="ide_reg">ID. Regional</param>
        /// <param name="nom_reg">Nombre</param>
        /// <param name="nom_cor">Nombre Corto</param>
        /// <returns></returns>
        public void Fe_edi_tar(int ide_reg, string nom_reg, string nom_cor)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads015 SET va_nom_reg = '" + nom_reg + "', va_nom_cor = '" + nom_cor + "' WHERE va_ide_reg = " + ide_reg + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Habilita/Deshabilita Regional"
        /// </summary>
        /// <param name="ide_reg">ID. Regional</param>
        /// <param name="est_ado">Estado (H=Habilitado; N=Deshabilitado)</param>
        /// <remarks></remarks>
        public void Fe_hab_des(int ide_reg, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads015 SET va_est_ado = '" + est_ado + "' WHERE va_ide_reg = " + ide_reg + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Elimina Regional"
        /// </summary>
        /// <param name="ide_reg">ID. Regional</param>
        /// <returns></returns>
        public void Fe_eli_min(int ide_reg)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads015 WHERE va_ide_reg = " + ide_reg + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Filtra Regional"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (0=va_ide_reg; 1=va_nom_reg; 2=va_nom_cor)</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string cri_bus, int prm_bus, string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_reg, va_nom_reg, va_nom_cor, va_est_ado");
                cadena.AppendLine("  FROM ads015");
                switch (prm_bus){
                    case 0: cadena.AppendLine(" WHERE va_ide_reg like '" + cri_bus + "%'"); break;
                    case 1: cadena.AppendLine(" WHERE va_nom_reg like '" + cri_bus + "%'"); break;
                    case 2: cadena.AppendLine(" WHERE va_nom_cor like '" + cri_bus + "%'"); break;
                }                

                if (est_bus != "T")                
                    cadena.AppendLine(" AND va_est_ado = '" + est_bus + "'");                

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Consulta Regional"
        /// </summary>
        /// <param name="ide_reg">ID. Módulo</param>
        /// <returns></returns>
        public DataTable Fe_con_reg(int ide_reg)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_reg, va_nom_reg, va_nom_cor, va_est_ado");
                cadena.AppendLine("  FROM ads015");
                cadena.AppendLine(" WHERE va_ide_reg = " + ide_reg + "");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Consulta Regional p/Nombre"
        /// </summary>
        /// <param name="nom_reg">Nombre</param>
        /// <param name="ide_reg">ID. Módulo</param>
        /// <returns></returns>
        public DataTable Fe_con_nom(string nom_reg, int ide_reg = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_reg, va_nom_reg, va_nom_cor, va_est_ado");
                cadena.AppendLine("  FROM ads015");
                cadena.AppendLine(" WHERE va_nom_reg = '" + nom_reg + "'");
                if (ide_reg > 0)
                    cadena.AppendLine(" AND va_ide_reg <> " + ide_reg + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Consulta Regional p/Nombre Corto"
        /// </summary>
        /// <param name="nom_cor">Nombre Corto</param>
        /// <param name="ide_reg">ID. Módulo</param>
        /// <returns></returns>
        public DataTable Fe_con_cor(string nom_cor, int ide_reg = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_reg, va_nom_reg, va_nom_cor, va_est_ado");
                cadena.AppendLine("  FROM ads015");
                cadena.AppendLine(" WHERE va_nom_cor = '" + nom_cor + "'");
                if (ide_reg > 0)
                    cadena.AppendLine(" AND va_ide_reg <> " + ide_reg + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Lista Regional p/Estado"
        /// </summary>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_reg(string est_ado = "T")
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_reg, va_nom_reg, va_nom_cor, va_est_ado");
                cadena.AppendLine("  FROM ads015");                
                if (est_ado != "T")
                    cadena.AppendLine(" WHERE va_est_ado = '" + est_ado + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Obtiene Último ID. Regional"
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_obt_ide()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DECLARE @va_ide_reg INT ");
                cadena.AppendLine(" SELECT @va_ide_reg = ISNULL(MAX(va_ide_reg), 0) FROM ads015");
                cadena.AppendLine(" SELECT @va_ide_reg + 1 AS va_ide_reg");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe 01: "Lista Regional"
        /// </summary>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <param name="ord_dat">Ordenar Por (C=Código; A=Abreviación; N=Nombre)</param>
        /// <returns></returns>
        public DataTable Fe_inf_R01(string est_ado, string ord_dat)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads015_R01 '" + est_ado + "', '" + ord_dat + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }     
    }
}