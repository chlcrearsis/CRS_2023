/*****************************************************************/
/*	ARCHIVO: ads018_02a_p01.sql                                  */
/*	PROCEDIMIENTO: BITACORA DE CIERRE DE SESION                  */
/*  PARAMETROS:   @ag_ide_uni  CHAR(32)    --** Identificador    */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 10/01/2024             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads018_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads018_02a_p01
GO

CREATE PROCEDURE ads018_02a_p01		@ag_ide_uni  CHAR(32) 	WITH ENCRYPTION AS

DECLARE		@va_fec_fin  DATETIME,      --** Fecha y Hora de Salida
			@va_nro_reg  INT            --** Nro. Registro


--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

IF (RTRIM(@ag_ide_uni) <> '')
BEGIN
    SET @va_fec_fin = NULL
	SELECT @va_fec_fin = va_fec_fin
	  FROM ads018
	 WHERE va_ide_uni = RTRIM(@ag_ide_uni)

	IF (@@ROWCOUNT = 1 AND @va_fec_fin IS NULL)
	BEGIN
		SET @va_fec_fin = GETDATE()
		UPDATE ads018 SET va_fec_fin = @va_fec_fin
		            WHERE va_ide_uni = @ag_ide_uni
	END
END

GO