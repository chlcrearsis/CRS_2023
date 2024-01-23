using System.Data.SqlClient;
using System.Data;

using CRS_DAT.Properties;
using System;

namespace CRS_DAT
{
    //######################################################################
    //##       Clase: conexion_a                                          ##
    //##      Nombre: Clase de Conexion al SQL-Server                     ##
    //## Descripcion: Ejecutas Sentencias al SQL-Server                   ##         
    //##       Autor: JEJR - (17-01-2024)                                 ##
    //######################################################################
    public class conexion_a
    {
        // Variables Publicas
        public string va_ser_bda = Settings.Default.va_ser_bda;  // Nombre del Servidor
        public string va_ins_bda = Settings.Default.va_ins_bda;  // Nombre de la Instancia
        public string va_nom_bda = Settings.Default.va_nom_bda;  // Nombre de la BD
        public string va_ide_usr = Settings.Default.va_ide_usr;  // ID Usuario
        public string va_pas_usr = Settings.Default.va_pas_usr;  // Contraseña Usuario
        // Variables de Conexion
        SqlConnection va_cxn_sql = new SqlConnection(); // Conexion Primaria SQL-Server
        SqlConnection va_cxn_usr = new SqlConnection(); // Conexion Secundaria Usuario
        SqlCommand va_sql_cmd = new SqlCommand();       // Instancia el Objeto SqlCommand
        // Variable Local
        string StrSQL;

        /// <summary>
        /// Funcion: Argumentos de Conexion
        /// </summary>
        /// <param name="ide_uni">Identificador Unico</param>
        /// <param name="ser_bda">Servidor/Iinstancia:Base de Datos</param>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="pas_usr">Contraseña</param>
        public void fe_arg_cnx(string ide_uni, string ser_bda, string ide_usr, string pas_usr )
        {
            // Obtiene el indice del Servidor y la Instancia
            int srv_bda = ser_bda.LastIndexOf("\\");
            int ins_bda = ser_bda.LastIndexOf(":");
            int nom_bda = ser_bda.Length;
            // Obtiene los datos de Conexion
            va_ide_usr = ide_usr;
            va_pas_usr = pas_usr;
            va_ser_bda = ser_bda.Substring(0, srv_bda);
            va_ins_bda = ser_bda.Substring(srv_bda + 1, ins_bda - srv_bda - 1);
            va_nom_bda = ser_bda.Substring(ins_bda + 1, nom_bda - ins_bda - 1);
            // Graba los argumentos de conexion en la Configuración
            Settings.Default.va_ide_uni = ide_uni;
            Settings.Default.va_ser_bda = va_ser_bda;
            Settings.Default.va_ins_bda = va_ins_bda;
            Settings.Default.va_nom_bda = va_nom_bda;
            Settings.Default.va_ide_usr = va_ide_usr;
            Settings.Default.va_pas_usr = va_pas_usr;
        }

        /// <summary>
        /// Funcion Conexion Inicial (Al loguearse)
        /// </summary>
        public string fe_abr_cnx()
        {
            try
            {
                //Obtiene los argumentos de conexion
                va_ser_bda = Settings.Default.va_ser_bda;
                va_ins_bda = Settings.Default.va_ins_bda;
                va_nom_bda = Settings.Default.va_nom_bda;
                va_ide_usr = Settings.Default.va_ide_usr;
                va_pas_usr = Settings.Default.va_pas_usr;
                //Obtiene la Cadena de Conexion
                StrSQL = "Data Source=" + va_ser_bda + "\\" + va_ins_bda + "; Initial Catalog = " + va_nom_bda + "; User Id = " + va_ide_usr + "; Password = " + va_pas_usr + "";
                //Coneta con el Servidor
                if (va_cxn_sql.State == ConnectionState.Closed){
                    va_cxn_sql.ConnectionString = StrSQL;
                    va_cxn_sql.Open();
                }
            
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
       
        /// <summary>
        /// Cierra la coneccion
        /// </summary>
        public string fe_cer_cnx()
        {
            try
            {
                // Cierra Conexion
                va_cxn_sql.Close(); // Conexion Primaria

                return "OK";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }  
        }

        /// <summary>
        /// Función para comprobar segundas conecciones
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="pas_usr">Contraseña</param>
        /// <returns></returns>
        public string fe_log_sql(string ide_usr, string pas_usr)
        {
            try
            {
                // Obtiene los argumentos de Conexion
                va_ser_bda = Settings.Default.va_ser_bda;
                va_ins_bda = Settings.Default.va_ins_bda;
                va_nom_bda = Settings.Default.va_nom_bda;
                // Concatena la Cadena de Conexion
                StrSQL = "Data Source=" + va_ser_bda + "\\" + va_ins_bda + "; Initial Catalog = " + va_nom_bda + "; User Id = " + ide_usr + "; Password = " + pas_usr + "";
                // Coneta con el Servidor
                if (va_cxn_usr.State == ConnectionState.Closed){
                    va_cxn_usr.ConnectionString = StrSQL;
                    va_cxn_usr.Open();
                    va_cxn_usr.Close();
                }
                return "OK";
            }
            catch (Exception)
            {
                return "ERROR";
            }
        }

        /// <summary>
        /// Funcion que Ejecuta comando SQL CON RETORNO
        /// </summary>
        /// <param name="StrQuery">Sentencia Query SQL</param>
        /// <returns></returns>
        public DataTable fe_exe_sql(string StrQuery)  
        {
            try
            {
                DataTable dts = new DataTable();
                // Abre Conexion
                fe_abr_cnx();
                // Ejecuta Sentencia en el SQL
                SqlDataAdapter Adaptador = new SqlDataAdapter(StrQuery, va_cxn_sql);
                // Carga Datos al Adaptador
                Adaptador.Fill(dts);
                // Retorna Datos
                return dts;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        /// <summary>
        /// Ejecuta comando SQL con retorno, Usuario (crssql)
        /// </summary>
        /// <param name="StrQuery">Sentencia Query SQL</param>
        /// <param name="ser_bda">Servidor/Instancia:Base de Datos</param>
        /// <param name="usr_sql">Usuario SQL</param>
        /// <param name="pas_sql">Contraseña SQL</param>
        /// <returns></returns>
        public DataTable fe_exe_sql(string StrQuery, string ser_bda, string usr_sql, string pas_sql)
        {
            DataTable dts = new DataTable();
            try
            {                
                // Obtiene el indice del Servidor y la Instancia
                int srv_bda = ser_bda.LastIndexOf("\\");
                int ins_bda = ser_bda.LastIndexOf(":");
                int nom_bda = ser_bda.Length;
                // Obtiene los datos de Conexion                
                va_ser_bda = ser_bda.Substring(0, srv_bda);
                va_ins_bda = ser_bda.Substring(srv_bda + 1, ins_bda - srv_bda - 1);
                va_nom_bda = ser_bda.Substring(srv_bda + 1, nom_bda - ins_bda - 1);
                // Obtiene la Cadena de Conexion
                StrSQL = "Data Source=" + ser_bda + "; Initial Catalog = " + va_nom_bda + "; User Id = " + usr_sql + "; Password = " + pas_sql + "";
                // Coneta con el Servidor SQL-Server
                if (va_cxn_sql.State == ConnectionState.Closed){
                    va_cxn_sql.ConnectionString = StrSQL;
                    va_cxn_sql.Open();
                }
                // Ejecuta Sentencia en el SQL
                SqlDataAdapter Adaptador = new SqlDataAdapter(StrQuery, va_cxn_sql);
                Adaptador.Fill(dts);
                return dts;
            }catch (Exception){
                return dts;
            }            
        }

        /// <summary>
        /// Funcion que guarda imagen a Base de Datos
        /// </summary>
        /// <param name="StrQuery">Sentencia Query SQL</param>
        /// <param name="nom_img">Nombre de Variable Temporal de Imagen</param>
        /// <param name="byt_img">Byte de la Imagen a guardar</param>
        public string fe_sql_img(string StrQuery, string nom_img, byte[] byt_img)
        {
            try
            {
                // Inicializa Instancia del Objeto SQLCommand
                va_sql_cmd = new SqlCommand();     
                // Abre la Conexion  
                fe_abr_cnx();
                // Pasa Argumentos al SQLCommand
                va_sql_cmd.CommandText = StrQuery;
                va_sql_cmd.Connection = va_cxn_sql;
                // Agrega Parametro con la Imagen
                va_sql_cmd.Parameters.Add(nom_img, SqlDbType.VarBinary, byt_img.Length).Value = byt_img;
                // Ejecuta Consulta en el SQL-Server
                va_sql_cmd.ExecuteNonQuery();                
                return "OK";
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}
