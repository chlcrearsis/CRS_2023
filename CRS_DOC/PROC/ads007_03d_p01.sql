/***********************************************************************/
/*	ARCHIVO: ads007_03c_p01.sql                                        */
/*	PROCEDIMIENTO: CAMBIA TIPO DE USUARIO AL USUARIO                   */
/*  PARAMETROS:   @ar_ide_usr  VARCHAR(15)  --** ID. Usuario           */
/*                @ag_tus_nue  INT          --** Nuevo Tipo de Usuario */              
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 03/08/2023                   */
/***********************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_03d_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_03d_p01
GO

CREATE PROCEDURE ads007_03d_p01		@ag_ide_usr VARCHAR(15),
							        @ag_tus_nue	INT		WITH ENCRYPTION AS

DECLARE		@va_est_ado  CHAR(01),	    --** Estado (H=habilitado ; N=Deshabilitado)
            @va_tus_act  INT,			--** Tipo de usuario actual
			@va_est_tus  CHAR(01),	    --** Estado Tipo de Usuario (H=habilitado ; N=Deshabilitado)
            @va_msn_err  NVARCHAR(200)  --** Mensaje de Error


--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
  
BEGIN TRANSACTION 
	--** Verifica que exista el usuario creado y Habilitado
	SELECT @va_est_ado = va_est_ado,
	       @va_tus_act = va_ide_tus
	  FROM ads007
	 WHERE va_ide_usr = @ag_ide_usr

	IF (@@ROWCOUNT = 0)
	BEGIN
	    ROLLBACK TRANSACTION 
		RAISERROR('El Usuario NO se encuentra registrado (ads007)', 16, 1)
		RETURN
	END

	IF (@va_est_ado <> 'H')
	BEGIN
	    ROLLBACK TRANSACTION 
		RAISERROR('El Usuario se encuentra Deshabilitado', 16, 1)
		RETURN
	END

	--** Verifica si existe el Nuevo Tipo de Usuario y esta habilitado
	SELECT @va_est_tus = va_est_ado 
	  FROM ads006
	 WHERE va_ide_tus = @ag_tus_nue

	IF (@@ROWCOUNT = 0)
	BEGIN
	    ROLLBACK TRANSACTION 
		RAISERROR('El Tipo de Usuario Nuevo NO se encuentra registrado (ads006)', 16, 1)
		RETURN
	END

	IF (@va_est_tus <> 'H')
	BEGIN
	    ROLLBACK TRANSACTION 
		RAISERROR('El Tipo de Usuario Nuevo se encuentra Deshabilitado', 16, 1)
		RETURN
	END

	--** Valida que el Tipo de Usuario nuevo sea distinto al actual
	IF (@va_tus_act = @ag_tus_nue)
	BEGIN
	    ROLLBACK TRANSACTION 
		RAISERROR('El Tipo de Usuario Nuevo es IGUAL al Tipo de Usuario actual', 16, 1)
		RETURN
	END

	--** ACTUALIZA EL TIPO DE USUARIO DE LA TABLA USUARIO (ads007)
	UPDATE ads007 SET va_ide_tus = @ag_tus_nue
	            WHERE va_ide_usr = @ag_ide_usr 

	IF (@@ERROR > 0)
	BEGIN
	    ROLLBACK TRANSACTION 
		RAISERROR('Error al actualizar datos del Usuario (ads007)', 16, 1)
		RETURN
	END

	--** ELIMINA LOS PERMISOS DEL USUARIO
	DELETE ads008 WHERE va_ide_usr = @ag_ide_usr

	IF (@@ERROR > 0)
	BEGIN
	    ROLLBACK TRANSACTION 
		RAISERROR('Error al eliminar los permisos autorizados al Usuario (ads008)', 16, 1)
		RETURN
	END
	
	--** COPIA LOS PERMISOS DEL TIPO DE USUARIO AL USUARIO
	INSERT INTO ads008
	SELECT @ag_ide_usr, va_ide_tab, va_ide_uno, 
	       va_ide_dos,  va_ide_tre, va_ide_int,
		   va_usr_reg,  va_fch_reg
	  FROM ads009
	 WHERE va_ide_tus = @ag_tus_nue

	IF (@@ERROR > 0)
	BEGIN
	    ROLLBACK TRANSACTION 
		RAISERROR('Error al insertar los permisos al Usuario (ads009)', 16, 1)
		RETURN
	END
	
	 
COMMIT TRANSACTION

RETURN

GO