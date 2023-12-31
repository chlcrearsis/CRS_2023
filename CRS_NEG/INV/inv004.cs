﻿using System.Data;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    /// Clase: PRODUCTOS
    /// </summary>
    public class inv004
    {
        //######################################################################
        //##       Tabla: INV004                                              ##
        //##      Nombre: PRODUCTOS                                           ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (22-07-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        string cadena = "";       
 
        public void Fe_crea(string ar_cod_pro, string ar_cod_fam,string ar_cod_umd,string ar_und_cmp, string ar_und_vta, 
            int ar_cod_mar, string ar_nom_pro, string ar_des_pro,string ar_cod_bar,
            string ar_fab_ric,double ar_eqv_cmp, double ar_eqv_vta,int ar_nro_dec, int ar_ban_ser,int ar_ban_lot)
        {
            cadena = " INSERT INTO INV004 VALUES('" + ar_cod_pro + "','" + ar_cod_fam + "','" + ar_cod_umd + "', '" + ar_und_cmp + "', '" + ar_und_vta + "'," +
                "" + ar_cod_mar + ", '" + ar_nom_pro + "','" + ar_des_pro + "','" + ar_cod_bar + "','" + ar_fab_ric + "'," +
                " '" + ar_eqv_cmp + "','" + ar_eqv_vta + "'," + ar_nro_dec + "," + ar_ban_ser + "," + ar_ban_lot + ",'H')";

            ob_con_ecA.fe_exe_sql(cadena);
        }
        

        /// <summary>
        /// GRABA PRODUCTO CON DATOS DE VADEMECUM
        /// </summary>
        /// <param name="ar_cod_pro"></param>
        /// <param name="ar_cod_fam"></param>
        /// <param name="ar_cod_umd"></param>
        /// <param name="ar_und_cmp"></param>
        /// <param name="ar_und_vta"></param>
        /// <param name="ar_cod_mar"></param>
        /// <param name="ar_nom_pro"></param>
        /// <param name="ar_des_pro"></param>
        /// <param name="ar_cod_bar"></param>
        /// <param name="ar_fab_ric"></param>
        /// <param name="ar_eqv_cmp"></param>
        /// <param name="ar_eqv_vta"></param>
        /// <param name="ar_nro_dec"></param>
        /// <param name="ar_ban_ser"></param>
        /// <param name="ar_ban_lot"></param>
        /// <param name="ar_pri_act"></param>
        /// <param name="ar_pro_ind"></param>
        /// <param name="ar_con_ind"></param>
        public void Fe_creaB(string ar_cod_pro, string ar_cod_fam, string ar_cod_umd, string ar_und_cmp, string ar_und_vta,
            int ar_cod_mar, string ar_nom_pro, string ar_des_pro, string ar_cod_bar,
            string ar_fab_ric, double ar_eqv_cmp, double ar_eqv_vta, int ar_nro_dec, int ar_ban_ser, int ar_ban_lot, 
            string ar_pri_act, string ar_pro_ind, string ar_con_ind)
        {
            cadena = " INSERT INTO INV004 VALUES('" + ar_cod_pro + "','" + ar_cod_fam + "','" + ar_cod_umd + "', '" + ar_und_cmp + "', '" + ar_und_vta + "'," +
                "" + ar_cod_mar + ", '" + ar_nom_pro + "','" + ar_des_pro + "','" + ar_cod_bar + "','" + ar_fab_ric + "'," +
                " '" + ar_eqv_cmp + "','" + ar_eqv_vta + "'," + ar_nro_dec + "," + ar_ban_ser + "," + ar_ban_lot + ",'H')";

            ob_con_ecA.fe_exe_sql(cadena);

            // GRABA DATOS DEL VADEMECUM
            cadena = " INSERT INTO INV009 VALUES('" + ar_cod_pro + "','" + ar_pri_act + "','" + ar_pro_ind + "', '" + ar_con_ind + "')";

            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_edi_pro(string ar_cod_pro,   
            int ar_cod_mar, string ar_nom_pro, string ar_des_pro, string ar_cod_bar,
            string ar_fab_ric,  int ar_nro_dec )
        { 
            cadena = " UPDATE INV004 SET va_cod_mar = " + ar_cod_mar + ", va_nom_pro = '" + ar_nom_pro + "', va_des_pro = '" + ar_des_pro + "', " +   
                " va_cod_bar = '" + ar_cod_bar + "', va_fab_ric = '" + ar_fab_ric + "', va_nro_dec = " + ar_nro_dec +
                " WHERE  va_cod_pro = '" + ar_cod_pro + "'";

            ob_con_ecA.fe_exe_sql(cadena);
        }
        public void Fe_edi_proB(string ar_cod_pro,
           int ar_cod_mar, string ar_nom_pro, string ar_des_pro, string ar_cod_bar,
           string ar_fab_ric, int ar_nro_dec,
           string ar_pri_act, string ar_pro_ind, string ar_con_ind)
        {
            cadena = " UPDATE INV004 SET va_cod_mar = " + ar_cod_mar + ", va_nom_pro = '" + ar_nom_pro + "', va_des_pro = '" + ar_des_pro + "', " +
                " va_cod_bar = '" + ar_cod_bar + "', va_fab_ric = '" + ar_fab_ric + "', va_nro_dec = " + ar_nro_dec +
                " WHERE  va_cod_pro = '" + ar_cod_pro + "'";

            ob_con_ecA.fe_exe_sql(cadena);

            cadena = " UPDATE INV009 SET va_pri_act = " + ar_pri_act + ", va_pro_ind = '" + ar_pro_ind + "', va_con_ind = '" + ar_con_ind + "', " +
                " WHERE  va_cod_pro = '" + ar_cod_pro + "'";

            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_hab_des(string ar_cod_pro, string ar_est_ado )
        {
            cadena = " UPDATE INV004 SET va_est_ado = '"+ ar_est_ado  + "' " +
                    " WHERE va_cod_pro = '" + ar_cod_pro + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_eli_pro(string ar_cod_pro )
        {
            cadena = " INV004_06a_p01 '" + ar_cod_pro + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_pro( string ar_cod_pro)
        {
            cadena = " INV004_05a_p01 '" + ar_cod_pro + "' ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        public string Fe_con_cod_max(string ar_cod_fam)
        {
            DataTable tabla = new DataTable();
            string cod_pro = "";

            cadena = " inv004_02a_p03 '" + ar_cod_fam + "' ";
             tabla = ob_con_ecA.fe_exe_sql(cadena);

            if (tabla.Rows.Count > 0)
                cod_pro = tabla.Rows[0][0].ToString();

            return cod_pro;
        }

        public DataTable Fe_con_pro_fam(string ar_cod_fam)
        {
            cadena = " SELECT * FROM inv004" +
                " WHERE va_cod_fam = " + ar_cod_fam + " ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }
        public DataTable Fe_bus_car(string ar_tex_bus,int ar_par_ame, string ar_est_ado , string ar_cod_fam = "000000")
        {
            cadena = " inv004_01a_p01 '" + ar_tex_bus + "' , " + ar_par_ame + " , " +
                "'" + ar_est_ado + "', '" + ar_cod_fam + "'" ;
           
 
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_bus_car(string ar_tex_bus, int ar_par_ame, string ar_est_ado, int ar_cod_lis, int ar_cod_bod, string ar_cod_fam = "000000")
        {

            cadena = " inv004_01b_p01 '" + ar_tex_bus + "' , " + ar_par_ame + " ,'" + ar_est_ado + "', " +
                "" + ar_cod_lis + " ," + ar_cod_bod + " , '" + ar_cod_fam + "'";


            return ob_con_ecA.fe_exe_sql(cadena);
        }


        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: PERIODOS DE UNA GESTION
        /// </summary>
        /// <param name="ar_cod_pro"> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_INV004_R01( string ar_est_ado)
        {   
            cadena = " INV004_R01 '" + ar_est_ado + "'" ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

       
    }
}
