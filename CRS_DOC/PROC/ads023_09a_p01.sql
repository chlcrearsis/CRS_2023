/*****************************************************************/
/*	ARCHIVO: ads023_09a_p01.sql                                  */
/*	PROCEDIMIENTO: IMPORTA INFORME TASA DE CAMBIO Bs/Ufv A EXCEL */
/*  PARAMETROS:   @ar_fec_ini  DATETIME  --** Fecha Inicial      */
/*                @ar_fec_fin  DATETIME  --** Fecha Final        */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 09/01/2024             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads023_09a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads023_09a_p01
GO

CREATE PROCEDURE ads023_09a_p01		@ar_fec_tas	DATETIME,
									@ar_tas_cam	DECIMAL(8,4) WITH ENCRYPTION AS

DECLARE		@va_msn_err	 NVARCHAR(200),	--** Mensaje de Error
            @va_nro_reg  INT			--** Nro. de Registro encontrados
			
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Inicio de Transación  
BEGIN TRAN TR_ads023
BEGIN TRY 

--** Valida que la fecha sea correcta
IF (@ar_fec_tas IS NULL) 
BEGIN 
    RAISERROR ('La Fecha de la T.C a Importar es Nulo', 16, 1)
	ROLLBACK TRAN TR_ads023
	RETURN 
END

--** Valida que la fecha sea correcta
IF (ISDATE(@ar_fec_tas) != 1) 
BEGIN 
    RAISERROR ('La Fecha de la T.C a Importar es incorrecta', 16, 1)
	ROLLBACK TRAN TR_ads023
	RETURN 
END

--** Valida que la fecha sea correcta
IF (@ar_tas_cam = 0)
BEGIN 
    RAISERROR ('La T.C a Importar DEBE ser distinta a Cero', 16, 1)
	ROLLBACK TRAN TR_ads023
	RETURN 
END

--** Verifica si hay registro en la fecha
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads023
 WHERE va_fec_tas = @ar_fec_tas


IF (@va_nro_reg = 0)
BEGIN
	--** Inserta Registro
	INSERT INTO ads023 VALUES (@ar_fec_tas, @ar_tas_cam)

	IF (@@ERROR > 0)
	BEGIN
		RAISERROR ('Error al Insertar la T.C en la Tabla (ads023) ',16,1)
		ROLLBACK TRAN TR_ads023
		RETURN
	END
END
ELSE
BEGIN
	--** Actualiza Registro
	UPDATE ads023 SET va_tas_cam = @ar_tas_cam WHERE va_fec_tas = @ar_fec_tas
	
	--** Inserta TC. en la tabla
	IF (@@ERROR > 0)
	BEGIN
		RAISERROR ('Error al Actualizar la T.C en la Tabla (ads023) ',16,1)
		ROLLBACK TRAN TR_ads023
		RETURN
	END
END

COMMIT TRAN TR_ads023
RETURN
END TRY
BEGIN CATCH	
	SET @va_msn_err = 'Error: ' + 
	ERROR_MESSAGE() + ' (Línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@va_msn_err,16,1)
	ROLLBACK TRAN TR_ads023
	RETURN
END CATCH	
GO