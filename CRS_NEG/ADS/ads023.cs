using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads023                                              ##
    //##      Nombre: Tasa de Cambio Bs/Us                                ##
    //## Descripcion: Tasa de Cambio Bs/Us                                ##         
    //##       Autor: EJR - (29-12-2023)                                  ##
    //######################################################################
    public class ads023
    {
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Función: "Registra Tasa de Cambio p/Fecha"
        /// </summary>
        /// <param name="fec_tas">Fecha</param>
        /// <param name="tas_cam">Tasa de Cambio</param>
        /// <returns></returns>
        public void Fe_nue_reg(string fec_tas, double tas_cam)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads023 VALUES ('" + fec_tas + "', " + tas_cam + ")");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Registra Tasa de Cambio p/Rango de Fecha"
        /// </summary>
        /// <param name="fec_ini">Fecha Inicial</param>
        /// <param name="fec_fin">Fecha Final</param>
        /// <param name="tas_cam">Tasa de Cambio</param>
        /// <returns></returns>
        public void Fe_nue_reg(string fec_ini, string fec_fin, double tas_cam)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads023_02b_p01 '" + fec_ini + "', '" + fec_fin + "', " + tas_cam + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Modifica Tasa de Cambio"
        /// </summary>
        /// <param name="fec_tas">Fecha</param>
        /// <param name="tas_cam">Tasa de Cambio</param>
        /// <returns></returns>
        public void Fe_edi_tar(string fec_tas, double tas_cam)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads023 SET va_tas_cam = " + tas_cam + " WHERE va_fec_tas = '" + fec_tas + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Busca tipos de cambio de un mes en el año
        /// </summary>
        /// <param name="mes_tdc">Mes T.C (1-12)</param>
        /// <param name="año_tdc">Año T.C</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(int mes_tdc, int año_tdc)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads023_01a_p01 " + mes_tdc + ", " + año_tdc + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Consulta Tasa de Cambio"
        /// </summary>
        /// <param name="fec_tas">Fecha T.C</param>
        /// <returns></returns>
        public DataTable Fe_con_tas(string fec_tas)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_fec_tas, va_tas_cam");
                cadena.AppendLine("  FROM ads023");
                cadena.AppendLine(" WHERE va_fec_tas = '" + fec_tas + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Exportar Tasa de Cambio a Excel"
        /// </summary>
        /// <param name="fec_ini">Fecha Inicial</param>
        /// <param name="fec_fin">Fecha Final</param>
        /// <returns></returns>
        public DataTable Fe_exp_tas(string fec_ini, string fec_fin)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads023_08a_p01 '" + fec_ini + "', '" + fec_fin + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Importa Tasa de Cambio desde Excel"
        /// </summary>
        /// <param name="fec_tas">Fecha</param>
        /// <param name="tas_cam">Tasa de Cambio</param>
        /// <returns></returns>
        public DataTable Fe_imp_tas(string fec_tas, double tas_cam)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads023_09a_p01 '" + fec_tas + "', " + tas_cam + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe 01: "Tasa de Cambio"
        /// </summary>
        /// <param name="fec_ini">Fecha Inicial</param>
        /// <param name="fec_fin">Fecha Final</param>
        /// <returns></returns>
        public DataTable Fe_inf_R01(string fec_ini, string fec_fin)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads023_R01 '" + fec_ini + "', '" + fec_fin + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
