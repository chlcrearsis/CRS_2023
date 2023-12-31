﻿using System;
using System.Data;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    /// Clase: EXISTENCIA DE PRODUCTOS
    /// </summary>
    public class inv008
    {
        //######################################################################
        //##       Tabla: inv007                                              ##
        //##      Nombre: EXISTENCIA DE PRODUCTOS                             ##
        //## Descripcion: Existencia de Productos                             ##         
        //##       Autor: CHL  - (11-09-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        string cadena = "";
     
        public DataTable Fe_con_exi( string ar_cod_pro)
        {
            cadena = " EXECUTE inv099_05a_p01  '" + ar_cod_pro + "' ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// KARDEX POR PRODUCTO DE UN ALMACEN
        /// </summary>
        /// <param name="ar_cod_pro">Codigo producto</param>
        /// <param name="ar_cod_bod">codigo bodega</param>
        /// <param name="ar_fec_ini">Fecha inicial</param>
        /// <param name="ar_fec_fin">Fecha final</param>
        /// <returns></returns>
        public DataTable Fe_inv099_R01(  int ar_cod_bod,string ar_cod_pro, DateTime ar_fec_ini, DateTime ar_fec_fin)
        {
            cadena = " EXECUTE inv099_R01   " + ar_cod_bod + ", '" + ar_cod_pro + "' , '" + ar_fec_ini + "', '" + ar_fec_fin + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        /// <summary>
        /// EXISTENCIAS EN BODEGA A LA FECHA
        /// </summary>
        /// <param name="ar_cod_pro">Codigo producto</param>
        /// <param name="ar_cod_bod">codigo bodega</param>
        /// <param name="ar_fec_ini">Fecha inicial</param>
        /// <param name="ar_fec_fin">Fecha final</param>
        /// <returns></returns>
        public DataTable Fe_inv099_R02(int ar_cod_bo1, int ar_cod_bo2, string ar_cod_fa1, string ar_cod_fa2, DateTime ar_fec_exi)
        {
            cadena = " EXECUTE inv099_R02 " + ar_cod_bo1 + ", " + ar_cod_bo2 + ", '" + ar_cod_fa1 + "','" + ar_cod_fa2 + "', '" + ar_fec_exi + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        public DataTable Fe_exi_bod_fec(int ar_bod_ini, int ar_bod_fin, DateTime va_fec_exi)
        {
            cadena = " EXECUTE inv099_01a_p02  " + ar_bod_ini + ",  " + ar_bod_ini + ",  '" + ar_bod_ini + "' ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }


    }
}
