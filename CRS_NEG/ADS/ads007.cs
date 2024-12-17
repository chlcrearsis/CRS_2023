using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads007                                              ##
    //##      Nombre: Usuario                                             ##
    //## Descripcion: Inicio Sesion Usuario                               ##         
    //##       Autor: JEJR - (05-01-2019)                                 ##
    //######################################################################
    public class ads007
    {        
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        public string va_ser_bda;   // Servidor
        public string va_ins_bda;   // Instancia
        public string va_nom_bda;   // Base de Datos

        public ads007()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
        }

        /// <summary>
        /// Función: "Registra Nuevo Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="nom_usr">Nombre de Usuario</param>
        /// <param name="tel_usr">Teléfono</param>
        /// <param name="car_usr">Cargo Usuario</param>
        /// <param name="dir_tra">Directorio Trabajo</param>
        /// <param name="ema_usr">Email</param>
        /// <param name="ven_max">Máximo de Ventanas Abiertas</param>
        /// <param name="ide_per">ID. Persona</param>
        /// <param name="ide_tus">Tipo de Usuario</param>
        /// <param name="usr_new">Usuario Nuevo (1=Nuevo; 2=Antiguo)</param>
        public void Fe_nue_reg(string ide_usr, string nom_usr, string tel_usr, string car_usr,
                               string dir_tra, string ema_usr,    int ven_max,    int ide_per,
                                  int ide_tus, int usr_new)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads007_02a_p01 '" + ide_usr + "', '" + nom_usr + "', '" + tel_usr + "', '" + car_usr + "',");
                cadena.AppendLine("                       '" + dir_tra + "', '" + ema_usr + "',  " + ven_max + ",   " + ide_per + ",");
                cadena.AppendLine("                        " + ide_tus + ",   " + usr_new + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Modifica Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="nom_usr">Nombre de Usuario</param>
        /// <param name="tel_usr">Teléfono</param>
        /// <param name="car_usr">Cargo Usuario</param>
        /// <param name="dir_tra">Directorio Trabajo</param>
        /// <param name="ema_usr">Email</param>
        /// <param name="ven_max">Máximo de Ventanas Abiertas</param>
        /// <param name="ide_per">ID. Persona</param>
        /// <param name="ide_tus">Tipo de Usuario</param>
        public void Fe_edi_tar(string ide_usr, string nom_usr, string tel_usr, string car_usr,
                               string dir_tra, string ema_usr, int ven_max, int ide_per, int ide_tus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads007 SET va_nom_usr = '" + nom_usr + "', va_tel_usr = '" + tel_usr + "',");
                cadena.AppendLine("                  va_car_usr = '" + car_usr + "', va_dir_tra = '" + dir_tra + "',");
                cadena.AppendLine("                  va_ema_usr = '" + ema_usr + "', va_ven_max =  " + ven_max + ",");
                cadena.AppendLine("                  va_ide_per =  " + ide_per + ",  va_ide_tus =  " + ide_tus + "");
                cadena.AppendLine("            WHERE va_ide_usr = '" + ide_usr + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Habilita/Deshabilita Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="est_ado">Estado (H=Habilitado; N=Deshabilitado)</param>
        public void Fe_hab_des(string ide_usr, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads007 SET va_est_ado = '" + est_ado + "' WHERE va_ide_usr = '" + ide_usr + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Elimina Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        public void Fe_eli_min(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads007_06_p01 '" + ide_usr + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Verifica que el usuario SQL este definida en el SQL Server"
        /// </summary>
        /// <param name="ser_bda">Servidor/Base de Datos</param>
        /// <param name="usr_sql">ID. Usuario SQL</param>
        /// <param name="pas_sql">Contraseña SQL</param>
        /// <returns></returns>
        public DataTable Fe_usr_sql(string ser_bda, string usr_sql, string pas_sql)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT name FROM master.sys.server_principals WHERE name = '" + usr_sql + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString(), ser_bda, usr_sql, pas_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Consulta SI el Usuario Logeado tiene los permisos 
        ///           necesario para Ingresar al Sistema"
        /// </summary>
        /// <param name="ser_bda">Servidor/Base de Datos</param>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="pas_usr">Contraseña</param>
        /// <returns></returns>
        public DataTable Fe_ver_usr(string ser_bda, string ide_usr, string pas_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads000_01a_p01 '" + ide_usr + "', '" + pas_usr + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString(), ser_bda, ide_usr, pas_usr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Ingreso al Sistema -> (Primera Conexion)"
        /// </summary>
        /// <param name="ide_uni">Identificador Unico de Conexion</param>
        /// <param name="ser_bda">Servidor/Base de Datos</param>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="pas_usr">Contraseña</param>
        /// <returns></returns>
        public string Fe_ing_sis(string ide_uni, string ser_bda, string ide_usr, string pas_usr)
        {            
            try
            {
                ob_con_ecA.fe_arg_cnx(ide_uni, ser_bda, ide_usr, pas_usr);
                return ob_con_ecA.fe_abr_cnx();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Ingreso al Sistema -> (Segunda Conexion)"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="pas_usr">Contraseña</param>
        /// <returns></returns>
        public string Fe_ing_sis(string ide_usr, string pas_usr)
        {
            try
            {                
                return ob_con_ecA.fe_log_sql(ide_usr, pas_usr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Cierra Conexion"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="pas_usr">Contraseña</param>
        /// <returns></returns>
        public string Fe_cie_cnx()
        {
            try
            {
                // Cierra Conexion Primaria
                return ob_con_ecA.fe_cer_cnx();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Cambia el Tipo de usuario al usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="tus_nue">ID. Tipo de Usuario Nuevo</param>
        public void Fe_cam_tus(string ide_usr, int tus_nue)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads007_03d_p01 '" + ide_usr + "', " + tus_nue + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Restablece los Permisos del Usuario a la del
        ///           Tipo de Usuario asignado"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        public void Fe_rei_per(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads007_03e_p01 '" + ide_usr + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Modifica Contraseña del Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="pas_new">Nueva contraseña</param>
        public void Fe_edi_psw(string ide_usr, string pas_new)
        {            
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads007_03b_p01 '" + ide_usr + "', '" + pas_new + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Inicializa Contraseña de Usuario a p/Defecto"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        public void Fe_ini_con(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads007_03c_p01 '" + ide_usr + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Consulta Usuario p/ID. Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_con_ide(string ide_usr, string est_ado = "T")
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads007.va_ide_usr, ads007.va_nom_usr, ads007.va_tel_usr,");
                cadena.AppendLine("       ads007.va_car_usr, ads007.va_dir_tra, ads007.va_ema_usr,");
                cadena.AppendLine("       ads007.va_ven_max, ads007.va_ide_per, ads007.va_ide_tus,");
                cadena.AppendLine("       ads006.va_nom_tus, ads007.va_est_ado");
                cadena.AppendLine("  FROM ads007, ads006");
                cadena.AppendLine(" WHERE ads007.va_ide_tus = ads006.va_ide_tus");
                cadena.AppendLine("   AND ads007.va_ide_usr = '" + ide_usr + "'");
                if (est_ado.CompareTo("T") != 0)
                    cadena.AppendLine("   AND ads007.va_est_ado = '" + est_ado + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Consulta Usuario p/Tipo de Usuario"
        /// </summary>
        /// <param name="ide_tus"> ID. Tipo de Usuario</param>
        /// <param name="est_ado"> Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_con_tus(int ide_tus, string est_ado = "T")
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads007.va_ide_usr, ads007.va_nom_usr, ads007.va_tel_usr,");
                cadena.AppendLine("       ads007.va_car_usr, ads007.va_dir_tra, ads007.va_ema_usr,");
                cadena.AppendLine("       ads007.va_ven_max, ads007.va_ide_per, ads007.va_ide_tus,");
                cadena.AppendLine("       ads006.va_nom_tus, ads007.va_est_ado");
                cadena.AppendLine("  FROM ads007, ads006");
                cadena.AppendLine(" WHERE ads007.va_ide_tus = ads006.va_ide_tus");
                cadena.AppendLine("   AND ads007.va_ide_tus = " + ide_tus + "");
                if (est_ado.CompareTo("T") != 0)
                    cadena.AppendLine("   AND ads007.va_est_ado = '" + est_ado + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Consulta Lista Usuario"
        /// </summary>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_usr(string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads007.va_ide_usr, ads007.va_nom_usr, ads007.va_tel_usr,");
                cadena.AppendLine("       ads007.va_car_usr, ads007.va_dir_tra, ads007.va_ema_usr,");
                cadena.AppendLine("       ads007.va_ven_max, ads007.va_ide_per, ads007.va_ide_tus,");
                cadena.AppendLine("       ads006.va_nom_tus, ads007.va_est_ado");
                cadena.AppendLine("  FROM ads007, ads006");
                cadena.AppendLine(" WHERE ads007.va_ide_tus = ads006.va_ide_tus");
                if (est_ado.CompareTo("T") != 0)
                    cadena.AppendLine("   AND ads007.va_est_ado = '" + est_ado + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Lista Usuario p/Definicion de Clave"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_cla">ID. Clave</param>
        /// <returns></returns>
        public DataTable Fe_usr_cla(int ide_mod, int ide_cla)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads007.va_ide_usr, ads007.va_nom_usr, ads007.va_tel_usr,");
                cadena.AppendLine("       ads007.va_car_usr, ads007.va_dir_tra, ads007.va_ema_usr,");
                cadena.AppendLine("       ads007.va_ven_max, ads007.va_ide_per, ads007.va_ide_tus,");
                cadena.AppendLine("       ads006.va_nom_tus, ads007.va_est_ado");
                cadena.AppendLine("  FROM ads007, ads006, ads014");
                cadena.AppendLine(" WHERE ads007.va_ide_tus = ads006.va_ide_tus");
                cadena.AppendLine("   AND ads007.va_ide_usr = ads014.va_ide_usr");
                cadena.AppendLine("   AND ads007.va_est_ado = 'H'");
                cadena.AppendLine("   AND ads014.va_ide_mod = " + ide_mod + "");
                cadena.AppendLine("   AND ads014.va_ide_cla = " + ide_cla + "");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Filtra Usuario"
        /// </summary>        
        /// <param name="cri_bus">Texto a Buscar</param>
        /// <param name="prm_bus">Criterio de Busqueda</param>
        /// <param name="est_bus">Estado Documento (H=Habilitado; N=Deshabilitado; T=Todos)</param>
        /// <param name="ide_tus">ID. Tipo Usuario (0=Todos)</param>
        /// <returns></returns>
        public DataTable Fe_bus_usu(string cri_bus, int prm_bus, string est_bus, int ide_tus = 0)
        {           
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads007.va_ide_usr, ads007.va_nom_usr, ads007.va_tel_usr,");
                cadena.AppendLine("       ads007.va_car_usr, ads007.va_dir_tra, ads007.va_ema_usr,");
                cadena.AppendLine("       ads007.va_ven_max, ads007.va_ide_per, ads007.va_ide_tus,");
                cadena.AppendLine("       ads006.va_nom_tus, ads007.va_est_ado");
                cadena.AppendLine("  FROM ads007, ads006");
                cadena.AppendLine(" WHERE ads007.va_ide_tus = ads006.va_ide_tus");
                if (ide_tus != 0)
                    cadena.AppendLine(" AND ads007.va_ide_tus = " + ide_tus + "");
                switch (prm_bus){
                    case 0: cadena.AppendLine(" AND ads007.va_ide_usr LIKE '" + cri_bus + "%'"); break;
                    case 1: cadena.AppendLine(" AND ads007.va_nom_usr LIKE '" + cri_bus + "%'"); break;
                    case 2: cadena.AppendLine(" AND ads007.va_car_usr LIKE '" + cri_bus + "%'"); break;
                }                                
                if (est_bus != "T")                
                    cadena.AppendLine(" AND ads007.va_est_ado = '" + est_bus + "'");                                               

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Función: "Inicios de Sesión Creados en el SQL-Server"
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_usr_sql()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT name AS va_ide_usr");
                cadena.AppendLine("  FROM sys.syslogins");
                cadena.AppendLine(" WHERE dbcreator = 1");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe 01: "Lista de Usuario"
        /// </summary>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <param name="ord_dat">Ordenar Por (C=Código; N=Nombre)</param>
        /// <returns></returns>
        public DataTable Fe_inf_R01(string est_ado, string ord_dat)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads007_R01 '" + est_ado + "', '" + ord_dat + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe 02: "Lista de Usuario p/Tipo de Usuario"
        /// </summary>
        /// <param name="tus_ini">Tipo de Usuario Inicial</param>
        /// <param name="tus_fin">Tipo de Usuario Final</param>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <param name="ord_dat">Ordenar Por (C=Código; N=Nombre)</param>
        /// <returns></returns>
        public DataTable Fe_inf_R02(int tus_ini, int tus_fin, string est_ado, string ord_dat)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads007_R02 " + tus_ini + ", " + tus_fin + ", '" + est_ado + "', '" + ord_dat + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe 03: "Autorizaciones del Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="mod_ini">ID. Módulo Inicial</param>
        /// <param name="mod_fin">ID. Módulo Final</param>
        /// <returns></returns>
        public DataTable Fe_inf_R03(string ide_usr, int mod_ini, int mod_fin)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads007_R03 '" + ide_usr + "', " + mod_ini + ", " + mod_fin + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe 04: "Autorizaciones p/Rango de Usuario"
        /// </summary>
        /// <param name="usr_ini">ID. Usuario Inicial</param>
        /// <param name="usr_fin">ID. Usuario Final</param>
        /// <param name="mod_ini">ID. Módulo Inicial</param>
        /// <param name="mod_fin">ID. Módulo Final</param>
        /// <returns></returns>
        public DataTable Fe_inf_R04(string usr_ini, string usr_fin, int mod_ini, int mod_fin)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads007_R04 '" + usr_ini + "', '" + usr_fin + "', " + mod_ini + ", " + mod_fin + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe 05: "Aplicaciones Autorizadas p/Rango de Usuario"
        /// </summary>
        /// <param name="usr_ini">ID. Usuario Inicial</param>
        /// <param name="usr_fin">ID. Usuario Final</param>
        /// <param name="mod_ini">ID. Módulo Inicial</param>
        /// <param name="mod_fin">ID. Módulo Final</param>
        /// <returns></returns>
        public DataTable Fe_inf_R05(string usr_ini, string usr_fin, int mod_ini, int mod_fin)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads007_R05 '" + usr_ini + "', '" + usr_fin + "', " + mod_ini + ", " + mod_fin + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe 06: "Talonarios Autorizadas p/Rango de Usuario"
        /// </summary>
        /// <param name="usr_ini">ID. Usuario Inicial</param>
        /// <param name="usr_fin">ID. Usuario Final</param>
        /// <param name="mod_ini">ID. Módulo Inicial</param>
        /// <param name="mod_fin">ID. Módulo Final</param>
        /// <returns></returns>
        public DataTable Fe_inf_R06(string usr_ini, string usr_fin, int mod_ini, int mod_fin)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads007_R06 '" + usr_ini + "', '" + usr_fin + "', " + mod_ini + ", " + mod_fin + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
