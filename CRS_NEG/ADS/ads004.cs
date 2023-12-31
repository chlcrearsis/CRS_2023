﻿using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads004                                              ##
    //##      Nombre: Talonarios                                          ##
    //## Descripcion: Talonarios (Definición)                             ##         
    //##       Autor: CHL  - (15-05-2020)                                 ##
    //######################################################################
    public class ads004
    {
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Función: "Registra Nuevo Talonario"
        /// </summary>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <param name="nom_tal">Nombre Talonario</param>
        /// <param name="tip_tal">Tipo de Talonario (0=Manual; 1=Automatico)</param>
        /// <param name="nro_aut">Número de Autorización</param>
        /// <param name="for_mat">Formato de Impresión</param>
        /// <param name="nro_cop">Nro. de Copias a Imprimir</param>
        /// <param name="fir_ma1">Firma Nro. 1</param>
        /// <param name="fir_ma2">Firma Nro. 2</param>
        /// <param name="fir_ma3">Firma Nro. 3</param>
        /// <param name="fir_ma4">Firma Nro. 4</param>
        /// <param name="for_log">Formato de Logo (0=Razon Social de Empresa; 1=Logotipo 1; 2=Logotipo 2 ;3=Logotipo 3</param>
        /// <param name="obs_uno">Observación 1</param>
        /// <param name="obs_dos">Observación 2</param>
        /// <returns></returns>
        public void Fe_nue_reg(string ide_doc,    int nro_tal, string nom_tal,    int tip_tal, int nro_aut,    int for_mat,    int nro_cop, 
                               string fir_ma1, string fir_ma2, string fir_ma3, string fir_ma4, int for_log, string obs_uno, string obs_dos){
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads004 VALUES ('" + ide_doc + "', " + nro_tal + ", '" + nom_tal + "', " + tip_tal + ",");
                cadena.AppendLine("                            " + nro_aut + ",  " + for_mat + ",  " + nro_cop + ", '" + fir_ma1 + "',");
                cadena.AppendLine("                           '" + fir_ma2 + "','" + fir_ma3 + "','" + fir_ma4 + "', " + for_log + ",");
                cadena.AppendLine("                           '" + obs_uno + "','" + obs_dos + "', 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Función: "Registra Nuevo Talonario y Control Numeración"
        /// </summary>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <param name="nom_tal">Nombre Talonario</param>
        /// <param name="tip_tal">Tipo de Talonario (0=Manual; 1=Automatico)</param>
        /// <param name="nro_aut">Número de Autorización</param>
        /// <param name="for_mat">Formato de Impresión</param>
        /// <param name="nro_cop">Nro. de Copias a Imprimir</param>
        /// <param name="fir_ma1">Firma Nro. 1</param>
        /// <param name="fir_ma2">Firma Nro. 2</param>
        /// <param name="fir_ma3">Firma Nro. 3</param>
        /// <param name="fir_ma4">Firma Nro. 4</param>
        /// <param name="for_log">Formato de Logo (0=Razon Social de Empresa; 1=Logotipo 1; 2=Logotipo 2 ;3=Logotipo 3</param>
        /// <param name="obs_uno">Observación 1</param>
        /// <param name="obs_dos">Observación 2</param>
        /// <param name="ges_tio">Gestion Año</param>
        /// <param name="anu_mes">(0=Anual ; 1=Mensual)</param>
        /// <returns></returns>
        public void Fe_nue_reg(string ide_doc,    int nro_tal, string nom_tal,    int tip_tal, int nro_aut,    int for_mat,    int nro_cop, 
                               string fir_ma1, string fir_ma2, string fir_ma3, string fir_ma4, int for_log, string obs_uno, string obs_dos, 
                                  int ges_tio,    int anu_mes)
        {            
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads004_02a_p01 '" + ide_doc + "', " + nro_tal + ", '" + nom_tal + "', " + tip_tal + ",");
                cadena.AppendLine("                        " + nro_aut + ",  " + for_mat + ",  " + nro_cop + ", '" + fir_ma1 + "',");
                cadena.AppendLine("                       '" + fir_ma2 + "','" + fir_ma3 + "','" + fir_ma4 + "', " + for_log + ",");
                cadena.AppendLine("                       '" + obs_uno + "','" + obs_dos + "', " + ges_tio + ", " + anu_mes + ", 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Registra Talonarios Automático"
        /// </summary>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="tal_anu">Talonario Anual (0)</param>
        /// <param name="tal_mes">Talonario Mensual (1-12)</param>
        /// <returns></returns>
        public void Fe_nue_aut(string ide_doc, string tal_anu, string tal_mes)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads004_02c_p01 '" + ide_doc + "', '" + tal_anu + "', '" + tal_mes + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Modifica Talonario"
        /// </summary>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <param name="nom_tal">Nombre Talonario</param>
        /// <param name="tip_tal">Tipo de Talonario (0=Manual; 1=Automatico)</param>
        /// <param name="nro_aut">Número de Autorización</param>
        /// <param name="for_mat">Formato de Impresión</param>
        /// <param name="nro_cop">Nro. de Copias a Imprimir</param>
        /// <param name="fir_ma1">Firma Nro. 1</param>
        /// <param name="fir_ma2">Firma Nro. 2</param>
        /// <param name="fir_ma3">Firma Nro. 3</param>
        /// <param name="fir_ma4">Firma Nro. 4</param>
        /// <param name="for_log">Formato de Logo (0=Razon Social de Empresa; 1=Logotipo 1; 2=Logotipo 2 ;3=Logotipo 3</param>
        /// <returns></returns>
        public void Fe_edi_tar(string ide_doc, int nro_tal, string nom_tal,    int tip_tal,    int nro_aut, 
                                  int for_mat, int nro_cop, string fir_ma1, string fir_ma2, string fir_ma3, 
                               string fir_ma4, int for_log, string obs_uno, string obs_dos)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads004 SET va_nom_tal = '" + nom_tal + "', va_tip_tal =  " + tip_tal + ",");
                cadena.AppendLine("                  va_nro_aut =  " + nro_aut + ",  va_for_mat =  " + for_mat + ",");
                cadena.AppendLine("                  va_nro_cop =  " + nro_cop + ",  va_fir_ma1 = '" + fir_ma1 + "',");
                cadena.AppendLine("                  va_fir_ma2 = '" + fir_ma2 + "', va_fir_ma3 = '" + fir_ma3 + "',");
                cadena.AppendLine("                  va_fir_ma4 = '" + fir_ma4 + "', va_for_log =  " + for_log + ",");
                cadena.AppendLine("                  va_obs_uno = '" + obs_uno + "', va_obs_dos = '" + obs_dos + "'");
                cadena.AppendLine("            WHERE va_ide_doc = '" + ide_doc + "'");
                cadena.AppendLine("              AND va_nro_tal =  " + nro_tal + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Habilita/Deshabilita Talonario"
        /// </summary>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <param name="est_ado">Estado (H=Habilitado; N=Deshabilitado)</param>
        /// <remarks></remarks>
        public void Fe_hab_des(string ide_doc, int nro_tal, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads004 SET va_est_ado = '" + est_ado + "' WHERE va_ide_doc = '" + ide_doc + "' AND va_nro_tal = " + nro_tal + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Elimina Talonario"
        /// </summary>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <returns></returns>
        public void Fe_eli_min(string ide_doc, int nro_tal)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads004 WHERE va_ide_doc = '" + ide_doc + "' AND va_nro_tal = " + nro_tal + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Filtra Talonarios"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (0=va_ide_doc; 1=va_nom_doc; 2=va_des_doc)</param>
        /// <param name="est_bus">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>       
        public DataTable Fe_bus_car(string cri_bus, int prm_bus, string est_bus, int ide_mod = 0)
        {            
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads004.va_ide_doc, ads003.va_nom_doc, ads004.va_nro_tal, ads004.va_nom_tal,");
                cadena.AppendLine("       ads004.va_tip_tal, ads004.va_nro_aut, ads004.va_for_mat, ads004.va_nro_cop,");
                cadena.AppendLine("       ads004.va_fir_ma1, ads004.va_fir_ma2, ads004.va_fir_ma3, ads004.va_fir_ma4,");
                cadena.AppendLine("       ads004.va_for_log, ads004.va_obs_uno, ads004.va_obs_dos, ads004.va_est_ado");
                cadena.AppendLine("  FROM ads004, ads003");
                cadena.AppendLine(" WHERE ads004.va_ide_doc = ads003.va_ide_doc");
                if (ide_mod != 0)
                    cadena.AppendLine(" AND ads003.va_ide_mod = " + ide_mod + "");
                
                switch (prm_bus){
                    case 0: cadena.AppendLine(" AND ads004.va_nom_tal like '" + cri_bus + "%'"); break;
                    case 1: cadena.AppendLine(" AND ads003.va_nom_doc like '" + cri_bus + "%'"); break;
                    case 2: cadena.AppendLine(" AND ads003.va_ide_doc like '" + cri_bus + "%'"); break;
                }                

                if (est_bus != "T")                
                    cadena.AppendLine(" AND ads004.va_est_ado = '" + est_bus + "'");                

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Consulta Talonario"
        /// </summary>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <returns></returns>
        public DataTable Fe_con_tal(string ide_doc, int nro_tal)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads004.va_ide_doc, ads003.va_nom_doc, ads004.va_nro_tal, ads004.va_nom_tal,");
                cadena.AppendLine("       ads004.va_tip_tal, ads004.va_nro_aut, ads004.va_for_mat, ads004.va_nro_cop,");
                cadena.AppendLine("       ads004.va_fir_ma1, ads004.va_fir_ma2, ads004.va_fir_ma3, ads004.va_fir_ma4,");
                cadena.AppendLine("       ads004.va_for_log, ads004.va_obs_uno, ads004.va_obs_dos, ads004.va_est_ado");
                cadena.AppendLine("  FROM ads004, ads003");
                cadena.AppendLine(" WHERE ads004.va_ide_doc = ads003.va_ide_doc");
                cadena.AppendLine("   AND ads004.va_ide_doc = '" + ide_doc + "'");
                cadena.AppendLine("   AND ads004.va_nro_tal =  " + nro_tal + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Consulta Talonarios p/ID. Documento"
        /// </summary>
        /// <param name="ide_doc">ID. Documentos</param>
        /// <returns></returns>
        public DataTable Fe_con_doc(string ide_doc)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads004.va_ide_doc, ads003.va_nom_doc, ads004.va_nro_tal, ads004.va_nom_tal,");
                cadena.AppendLine("       ads004.va_tip_tal, ads004.va_nro_aut, ads004.va_for_mat, ads004.va_nro_cop,");
                cadena.AppendLine("       ads004.va_fir_ma1, ads004.va_fir_ma2, ads004.va_fir_ma3, ads004.va_fir_ma4,");
                cadena.AppendLine("       ads004.va_for_log, ads004.va_obs_uno, ads004.va_obs_dos, ads004.va_est_ado");
                cadena.AppendLine("  FROM ads004, ads003");
                cadena.AppendLine(" WHERE ads004.va_ide_doc = ads003.va_ide_doc");
                cadena.AppendLine("   AND ads004.va_ide_doc = '" + ide_doc + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Consulta Talonarios p/Nombre"
        /// </summary>
        /// <param name="nom_tal">Nombre Talonario</param>
        /// <param name="ide_doc">ID. Documentos</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <returns></returns>
        public DataTable Fe_con_nom(string nom_tal, string ide_doc, int nro_tal = 9999)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads004.va_ide_doc, ads003.va_nom_doc, ads004.va_nro_tal, ads004.va_nom_tal,");
                cadena.AppendLine("       ads004.va_tip_tal, ads004.va_nro_aut, ads004.va_for_mat, ads004.va_nro_cop,");
                cadena.AppendLine("       ads004.va_fir_ma1, ads004.va_fir_ma2, ads004.va_fir_ma3, ads004.va_fir_ma4,");
                cadena.AppendLine("       ads004.va_for_log, ads004.va_obs_uno, ads004.va_obs_dos, ads004.va_est_ado");
                cadena.AppendLine("  FROM ads004, ads003");
                cadena.AppendLine(" WHERE ads004.va_ide_doc = ads003.va_ide_doc");
                cadena.AppendLine(" WHERE ads004.va_ide_doc = '" + ide_doc + "'");
                cadena.AppendLine(" WHERE ads004.va_nom_tal = '" + nom_tal + "'");
                if (nro_tal != 9999)
                    cadena.AppendLine("   AND ads004.va_nro_tal <> " + nro_tal + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Lista Talonarios p/Estado"
        /// </summary>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_tal(string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads004.va_ide_doc, ads003.va_nom_doc, ads004.va_nro_tal, ads004.va_nom_tal,");
                cadena.AppendLine("       ads004.va_tip_tal, ads004.va_nro_aut, ads004.va_for_mat, ads004.va_nro_cop,");
                cadena.AppendLine("       ads004.va_fir_ma1, ads004.va_fir_ma2, ads004.va_fir_ma3, ads004.va_fir_ma4,");
                cadena.AppendLine("       ads004.va_for_log, ads004.va_obs_uno, ads004.va_obs_dos, ads004.va_est_ado");
                cadena.AppendLine("  FROM ads004, ads003");
                cadena.AppendLine(" WHERE ads004.va_ide_doc = ads003.va_ide_doc");
               
                if (est_ado != "T")
                    cadena.AppendLine(" AND ads004.va_est_ado = '" + est_ado + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Permiso sobre el Talonario al Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_doc">ID. Documentos</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <param name="est_tal">Estado (H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_per_tal(string ide_usr, string ide_doc, int nro_tal, string est_tal)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads004_05a_p02 '" + ide_usr + "', '" + ide_doc + "', " + nro_tal + ", '" + est_tal + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Permiso sobre el Talonario al Usuario p/Documento"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_doc">ID. Documentos</param>
        /// <param name="est_tal">Estado (H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_tal_usr(string ide_usr, string ide_doc, string est_tal)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads004_05a_p02 '" + ide_usr + "', '" + ide_doc + "', '" + est_tal + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Busca Talonario con Permiso al Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_doc">ID. Documentos</param>
        /// <param name="tex_bus">Texto a Buscar</param>
        /// <param name="est_tal">Estado (H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>       
        public DataTable Fe_per_tal(string ide_usr, string ide_doc, string tex_bus, string est_tal)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads004_01b_p01 '" + ide_usr + "', '" + ide_doc + "', '" + tex_bus + "', '" + est_tal + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Lista Usuarios Autorizados p/Talonario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo Usuario</param>
        /// <param name="est_usr">Estado Usuario (H=Habilitado; N=Deshabilitado; T=Todos)</param>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <returns></returns>       
        public DataTable Fe_usr_tal(int ide_tus, string est_usr, string ide_doc, int nro_tal)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads004_10_p01 " + ide_tus + ", '" + est_usr + "', '" + ide_doc + "', " + nro_tal + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe 01: "Lista Talonarios"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_inf_R01(int ide_mod, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads004_R01 " + ide_mod + ", '" + est_ado + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe 02: "Talonarios Formato y Definición de Firmas"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="doc_ini">Documento Inicial</param>
        /// <param name="doc_fin">Documento Final</param>
        /// <returns></returns>
        public DataTable Fe_inf_R02(int ide_mod, string doc_ini, string doc_fin)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads004_R02 " + ide_mod + ", '" + doc_ini + "', '" + doc_fin + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
