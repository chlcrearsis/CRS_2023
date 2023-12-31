/*****************************************************************/
/*	ARCHIVO: ads007_03c_p01.sql                                  */
/*	PROCEDIMIENTO: INICIALIZA CONTRASEÑA POR DEFECTO             */
/*  PARAMETROS:   @ar_ide_usr  NVARCHAR(15)  ID. Usuario         */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 01/08/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_03c_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_03c_p01
GO

CREATE PROCEDURE ads007_03c_p01		@ag_ide_usr NVARCHAR(15) WITH ENCRYPTION AS

DECLARE		@va_est_ado  CHAR(01),	    --** Estado (H=habilitado ; N=Deshabilitado)
            @va_com_sql  NVARCHAR(200), --** Comando de Ejecución SQL
			@va_est_sql	 CHAR(01),		--** Estado de la ejecucion de la sentencia SQL
			@va_con_def	 VARCHAR(15),	--** Contraseña por defecto
			@va_msn_err  NVARCHAR(200)  --** Mensaje de Error

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
 

BEGIN TRY   
    --** Verifica que exista el usuario creado y Habilitado
	SELECT @va_est_ado = va_est_ado
	  FROM ads007
	 WHERE va_ide_usr = @ag_ide_usr

	IF (@@ROWCOUNT = 0)
	BEGIN
		RAISERROR('El Usuario NO se encuentra registrado (ads007)', 16, 1)
		RETURN
	END

	IF (@va_est_ado <> 'H')
	BEGIN
		RAISERROR('El Usuario se encuentra Deshabilitado', 16, 1)
		RETURN
	END

	--** Obtiene Contraseña por defecto de la global (1-21)
	SELECT @va_con_def = va_glo_car
	  FROM ads013
	 WHERE va_ide_mod = 1	--** Módulo
	   AND va_ide_glo = 21   --** Global
	
	IF (@@ROWCOUNT = 0)
	BEGIN
		RAISERROR('NO se encuentra definida la Global (1-21). Contraseña por Defecto', 16, 1)
		RETURN
	END

	--** Verifica SI existe el Inicio de Sesion
	IF (NOT EXISTS (SELECT name FROM master.sys.server_principals
                               WHERE name = @ag_ide_usr))
	BEGIN
    	RAISERROR('El Inicio de Sesion del Usuario NO está registrado en el SQL-Server', 16, 1)
		RETURN
	END

	--** Construye la sentencia SQL-Server
	SET @va_com_sql = 'ALTER LOGIN [' + RTRIM(@ag_ide_usr) + '] WITH PASSWORD = ''' + RTRIM(@va_con_def) + ''''    
      
	--** Ejecuta Sentencia SQL-Server
	EXEC @va_est_sql = sp_executesql @va_com_sql

	--** Verifica si se ejecuto bien la sentencia
	IF (@va_est_sql <> 0)
	BEGIN
		RAISERROR('La contraseña del Usuario NO pudo ser inicializada.', 16, 1)
		RETURN
	END

END TRY
BEGIN CATCH	
	SET @va_msn_err = 'Error: ' + ERROR_MESSAGE() + ' (Línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@va_msn_err, 16, 1)
	RETURN
END CATCH	

GO