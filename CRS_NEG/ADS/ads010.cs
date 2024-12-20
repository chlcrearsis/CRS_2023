﻿using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads010                                              ##
    //##      Nombre: Tipos de Imagen                                     ##
    //## Descripcion: Definiciones Tipos de Imagen                        ##         
    //##       Autor: EJR - (30-09-2023)                                  ##
    //######################################################################
    public class ads010
    {        
        conexion_a ob_con_ecA = new conexion_a();        
        StringBuilder cadena;

        /// <summary>
        /// Función: "Registra Nuevo Tipo de Imagen"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo Imagen</param>
        /// <param name="nom_tip">Nombre</param>
        /// <param name="ide_tab">ID. Tabla</param>
        public void Fe_nue_reg(string ide_tip , string nom_tip , string ide_tab)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads010 VALUES ('" + ide_tip + "', '" + nom_tip + "', '" + ide_tab + "', 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Modifica Tipo de Imagen"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo Imagen</param>
        /// <param name="nom_tip">Nombre</param>
        /// <param name="ide_tab">ID. Tabla</param>
        public void Fe_edi_tar(string ide_tip, string nom_tip, string ide_tab)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads010 SET va_nom_tip = '" + nom_tip + "', va_ide_tab = '" + ide_tab + "'");
                cadena.AppendLine("            WHERE va_ide_tip = '" + ide_tip + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Funcion "Habilita/Deshabilita Tipo de Imagen"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo Imagen</param>
        /// <param name="est_ado">Estado (H= habilitado; N=deshabilitado)</param>
        public void Fe_hab_des(string ide_tip, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads010 SET va_est_ado = '" + est_ado + "'");
                cadena.AppendLine("            WHERE va_ide_tip = '" + ide_tip + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Funcion "Elimina Tipo de Imagen"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo Imagen</param>
        public void Fe_eli_min(string ide_tip)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads010 WHERE va_ide_tip = '" + ide_tip + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        /// <summary>
        /// Función: "Filtra Tipo de Imagen"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (0=va_ide_tip; 1=va_nom_tip)</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string cri_bus, int prm_bus, string est_bus, string ide_tab)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tip, va_nom_tip, va_ide_tab, va_est_ado");
                cadena.AppendLine("  FROM ads010");
                cadena.AppendLine(" WHERE va_ide_tab LIKE '%" + ide_tab + "%'");
                switch (prm_bus){
                    case 0: cadena.AppendLine(" AND va_ide_tip LIKE '" + cri_bus + "%'"); break;
                    case 1: cadena.AppendLine(" AND va_nom_tip LIKE '" + cri_bus + "%'"); break;

                }
                switch (est_bus){
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T")
                    cadena.AppendLine(" AND va_est_ado ='" + est_bus + "'");                

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Consulta Tipo de Imagen"
        /// </summary>
        /// <param name="ide_tip"></param>
        /// <returns></returns>
        public DataTable Fe_con_tip(string ide_tip)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tip, va_nom_tip, va_ide_tab, va_est_ado");
                cadena.AppendLine("  FROM ads010");
                cadena.AppendLine(" WHERE va_ide_tip = '" + ide_tip + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Consulta Tipo de Imagen p/Nombre"
        /// </summary>
        /// <param name="nom_tip">Nombre</param>
        /// <returns></returns>
        public DataTable Fe_con_nom(string nom_tip, string ide_tip = "")
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tip, va_nom_tip, va_ide_tab, va_est_ado");
                cadena.AppendLine("  FROM ads010");
                cadena.AppendLine(" WHERE va_nom_tip = '" + nom_tip + "'");
                if (ide_tip.CompareTo("") != 0)
                    cadena.AppendLine(" AND va_ide_tip <> '" + ide_tip + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Lista Tipo de Imagen p/Estado"
        /// </summary>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_tip(string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tip, va_nom_tip, va_ide_tab, va_est_ado");
                cadena.AppendLine("  FROM ads010");
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
        /// Informe: "Lista Tipos de Imagen"
        /// </summary>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <param name="ord_dat">Ordenar Por (C=Código; D=Descripción)</param>
        /// <returns></returns>
        public DataTable Fe_inf_R01(string est_ado, string ord_dat)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads010_R01 '" + est_ado + "', '" + ord_dat + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}