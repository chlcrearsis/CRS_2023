/***************************************************************************/
/*	ARCHIVO: ads007_06_p01.sql                                             */
/*	PROCEDIMIENTO: ELIMINA USUARIO                                         */
/*  PARAMETROS:   @ag_ide_usr NVARCHAR(15)         --** ID. Usuario        */
/*                @ag_cod_err INT OUTPUT           --** Código Error       */
/*                @ag_obs_err NVARCHAR(250) OUTPUT --** Observación Error  */
/*	AUTOR:	CREARSIS(EJR)        FECHA : 05/07/2023                        */
/*  NOTA : En caso de error devuelve codigo de error desde 200 hasta 500   */
/***************************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_06_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_06_p01
GO

CREATE PROCEDURE ads007_06_p01		@ag_ide_usr NVARCHAR(15),
                                    @ag_cod_err INT OUTPUT,
                                    @ag_obs_err NVARCHAR(250) OUTPUT
                                    WITH ENCRYPTION AS

DECLARE		@va_com_sql	 NVARCHAR(200), --** Comando para ejecutar sentencia sql
            @va_ide_usr NVARCHAR(15),	--** ID. Usuario
            @va_est_ado CHAR(01),		--** Estado (H=Habilitado; N=Deshabilitado)
			@va_nro_reg INT,            --** Nro. de Registro
			@va_msn_err	NVARCHAR(200)  --** Mensaje de Error

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Inicializa Transación
BEGIN TRANSACTION

--** Verifica que el Usuario este registrado y Deshabilitado
SELECT @va_est_ado = va_est_ado
  FROM ads007
 WHERE va_ide_usr = @ag_ide_usr

IF (@@ROWCOUNT = 0)
BEGIN
	ROLLBACK TRANSACTION
	SET @ag_obs_err = 'El Usuario (' + RTRIM(@ag_ide_usr) + ') NO se encuentra registrado en la BD.'
	SET @ag_cod_err = 200 
	RETURN
END
	
IF(@va_est_ado = 'H')
BEGIN
	ROLLBACK TRANSACTION
	SET @ag_obs_err = 'El Usuario (' + RTRIM(@ag_ide_usr) + ') está Habilitado, NO puede ser eliminado'
	SET @ag_cod_err = 200 
	RETURN
END

--** Elimina el Usuario de la B.D
DELETE ads007 WHERE va_ide_usr = @ag_ide_usr

IF (@@ERROR > 0)
BEGIN
	ROLLBACK TRANSACTION
	SET @ag_obs_err = 'Error al eliminar el Usuario de la BD. (ads007)'
	SET @ag_cod_err = 200 
	RETURN
END

--** Elimina Autorizaciones del Usuario
DELETE ads008 WHERE va_ide_usr = @ag_ide_usr

IF (@@ERROR > 0)
BEGIN
	ROLLBACK TRANSACTION
	SET @ag_obs_err = 'Error al eliminar las Autorizaciones del Usuario (ads008)'
	SET @ag_cod_err = 200 
	RETURN
END

--** Elimina Restriccion Menú al Usuario
DELETE ads012 WHERE va_ide_usr = @ag_ide_usr

IF (@@ERROR > 0)
BEGIN
	ROLLBACK TRANSACTION
	SET @ag_obs_err = 'Error al eliminar las Restriccion Menú al Usuario (ads012)'
	SET @ag_cod_err = 200 
	RETURN
END

--** Verifica Si el Usuario esta creado en la base de datos
SELECT @va_nro_reg = COUNT(*) 
  FROM sysusers 
 WHERE name = @ag_ide_usr

IF (@va_nro_reg > 0)
BEGIN
	--** Genera el comando para eliminar usuario en la base de datos
	SET @va_com_sql = 'DROP USER ' + RTRIM(@ag_ide_usr)

	--** Ejecuta comando
	EXEC sp_executesql @va_com_sql	 

	IF (@@ERROR > 0)
	BEGIN
		ROLLBACK TRANSACTION
		SET @ag_obs_err = 'Error al eliminar el usuario de la BD. (USER)'
		SET @ag_cod_err = 200 
		RETURN
	END
END 

SET @va_com_sql = 'DROP LOGIN ' + RTRIM(@ag_ide_usr)

EXEC sp_executesql @va_com_sql

IF (@@ERROR > 0)
	BEGIN
		ROLLBACK TRANSACTION
		SET @ag_obs_err = 'Error al eliminar el inicio de seccion de la BD.'
		SET @ag_cod_err = 201
		RETURN
	END

GO