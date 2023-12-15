using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads006                                              ##
    //##      Nombre: Tipo de Usuario                                     ##
    //## Descripcion: Definición Tipo de Usuario                          ##         
    //##       Autor: EJR - (06-04-2023)                                  ##
    //######################################################################
    public class ads006
    {
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Función: "Registra Nuevo Tipo de Usuario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <param name="nom_tus">Nombre</param>
        /// <param name="des_tus">Descripción</param>
        public void Fe_nue_reg(int ide_tus, string nom_tus, string des_tus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads006 VALUES (" + ide_tus + ", '" + nom_tus + "', '" + des_tus + "', 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Modifica Tipo de Usuario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo Usuario</param>
        /// <param name="nom_tus">Nombre</param>
        /// <param name="des_tus">Descripción</param>
        public void Fe_edi_tar(int ide_tus, string nom_tus, string des_tus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads006 SET va_nom_tus = '" + nom_tus + "', va_des_tus = '" + des_tus + "' WHERE va_ide_tus = " + ide_tus + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Habilita/Deshabilita Tipo de Usuario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo Usuario</param>
        /// <param name="est_ado">Estado (H=Habilitado; N=Deshabilitado)</param>
        public void Fe_hab_des(int ide_tus, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads006 SET va_est_ado = '" + est_ado + "' WHERE va_ide_tus = " + ide_tus + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Elimina Tipo de Usuario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo Usuario</param>
        public void Fe_eli_min(int ide_tus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads006 WHERE va_ide_tus = " + ide_tus + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Filtra Tipo de Usuario"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (0=va_ide_mod; 1=va_nom_mod; 2=va_abr_mod)</param>
        /// <param name="est_bus">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string cri_bus, int prm_bus, string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tus, va_nom_tus, va_des_tus, va_est_ado");
                cadena.AppendLine("  FROM ads006");
                switch (prm_bus){
                    case 0: cadena.AppendLine(" WHERE va_ide_tus like '" + cri_bus + "%'"); break;
                    case 1: cadena.AppendLine(" WHERE va_nom_tus like '" + cri_bus + "%'"); break;
                    case 2: cadena.AppendLine(" WHERE va_des_tus like '" + cri_bus + "%'"); break;
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
        /// Función: "Consulta Tipo de Usuario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo Usuario</param>
        /// <returns></returns>
        public DataTable Fe_con_tus(int ide_tus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tus, va_nom_tus, va_des_tus, va_est_ado");
                cadena.AppendLine("  FROM ads006");
                cadena.AppendLine(" WHERE va_ide_tus = " + ide_tus + "");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Consulta Tipo de Usuario p/Nombre"
        /// </summary>
        /// <param name="nom_tus">Nombre</param>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <returns></returns>
        public DataTable Fe_con_nom(string nom_tus, int ide_tus = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tus, va_nom_tus, va_des_tus, va_est_ado");
                cadena.AppendLine("  FROM ads006");
                cadena.AppendLine(" WHERE va_nom_tus = '" + nom_tus + "'");
                if (ide_tus > 0)
                    cadena.AppendLine(" AND va_ide_tus <> " + ide_tus + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Consulta Tipo de Usuario p/Descripcion"
        /// </summary>
        /// <param name="des_tus">Descripción</param>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <returns></returns>
        public DataTable Fe_con_des(string des_tus, int ide_tus = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tus, va_nom_tus, va_des_tus, va_est_ado");
                cadena.AppendLine("  FROM ads006");
                cadena.AppendLine(" WHERE va_des_tus = '" + des_tus + "'");
                if (ide_tus > 0)
                    cadena.AppendLine(" AND va_ide_tus <> " + ide_tus + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Lista Tipo de Usuario p/Estado"
        /// </summary>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_tus(string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tus, va_nom_tus, va_des_tus, va_est_ado");
                cadena.AppendLine("  FROM ads006");                
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
        /// Función: "Obtiene Último ID. Tipo de Usuario"
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_obt_ide()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DECLARE @va_ide_tus INT ");
                cadena.AppendLine(" SELECT @va_ide_tus = ISNULL(MAX(va_ide_tus), 0) FROM ads006");
                cadena.AppendLine(" SELECT @va_ide_tus + 1 AS va_ide_tus");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe 01: "Lista Tipo de Usuario"
        /// </summary>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <param name="ord_dat">Ordenar Por (C=Código; N=Nombre)</param>
        /// <returns></returns>
        public DataTable Fe_inf_R01(string est_ado, string ord_dat)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads006_R01 '" + est_ado + "', '" + ord_dat + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe 02: "Autorizaciones por Tipo de Usuario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <param name="mod_ini">ID. Módulo Inicial</param>
        /// <param name="mod_fin">ID. Módulo Final</param>
        /// <returns></returns>
        public DataTable Fe_inf_R02(int ide_tus, int mod_ini, int mod_fin)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads006_R03 " + ide_tus + ", " + mod_ini + ", " + mod_fin + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
