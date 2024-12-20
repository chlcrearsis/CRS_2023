/********************************************************************/
/*	ARCHIVO: ads023_02b_p01.sql                                     */
/*	PROCEDIMIENTO: REGISTRA TASA DE CAMBIO Bs/Ufv P/RANGO DE FECHA	*/
/*      ARGUMENTO: @ar_fec_ini	DATETIME	 --** Fecha Inicial     */
/*                 @ar_fec_fin	DATETIME	 --** Fecha Final       */
/*                 @ar_tas_cam	DECIMAL(8,4) --** Tasa de Cambio    */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 09/01/2024                */
/********************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads023_02b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads023_02b_p01
GO

CREATE PROCEDURE ads023_02b_p01		@ar_fec_ini	DATETIME,
									@ar_fec_fin	DATETIME,
									@ar_tas_cam	DECIMAL(8,4) WITH ENCRYPTION AS

DECLARE		@va_msn_err	 NVARCHAR(200),	--** Mensaje de Error
			@va_nro_reg  INT,			--** Nro. de Registro encontrados
			@va_nro_dia	 INT,			--** Nro. de Dias
			@va_fec_tas  DATETIME,      --** Fecha Tasa de Cambio
			@va_ban_reg  CHAR(01),      --** Bandera Registro (S=Si; N=No)
			@va_fec_act  DATETIME,      --** Fecha Actual
			@va_fch_act  CHAR(10)       --** Fecha Actual String

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Inicio de Transación  
BEGIN TRAN TR_ads023
BEGIN TRY  

--** Crea la Tabla Temporal
CREATE TABLE #tm_fec_tas(
	va_fec_tas  DATETIME
)

--** Obtiene la fecha actual
SET @va_fec_act = GETDATE()
SET @va_fch_act = CONVERT(CHAR(10), @va_fec_act, 103)
SET @va_fec_act = CONVERT(DATETIME, @va_fch_act) 

--** Obtiene el nro de dias
SET @va_nro_dia = DATEDIFF(DAY, @ar_fec_ini, @ar_fec_fin);

WITH
Fecha AS (
SELECT TOP (@va_nro_dia + 1) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 n
  from sys.all_columns
)

--** Agrega las fechas en la tabla temporal
INSERT INTO #tm_fec_tas
SELECT DATEADD(DAY, n, @ar_fec_ini) Fecha
  FROM Fecha

--** Lectura las fechas
DECLARE vc_tas_cam CURSOR LOCAL FOR
SELECT va_fec_tas FROM #tm_fec_tas

--** Abre Cursor
OPEN vc_tas_cam
--** Lee el primer registro
FETCH NEXT FROM vc_tas_cam INTO @va_fec_tas														
WHILE (@@FETCH_STATUS = 0)
BEGIN	
	SET @va_ban_reg = ''


	IF (@va_fec_tas <= @va_fec_act)
	BEGIN		
		--** Verifica si la fecha existe
		SELECT @va_nro_reg = COUNT(*)
		  FROM ads023
		 WHERE va_fec_tas = @va_fec_tas

		IF (@va_nro_reg = 0)
		BEGIN
			--** Inserta TC. en la tabla
			INSERT INTO ads023 VALUES (@va_fec_tas, @ar_tas_cam)

			IF (@@ERROR > 0)
			BEGIN
				RAISERROR ('Error al Insertar la T.C en la Tabla (ads023) ',16,1)
				ROLLBACK TRAN TR_ads023
				RETURN
			END
		END		
	END
	ELSE
	BEGIN
		--** Verifica si la fecha existe
		SELECT @va_nro_reg = COUNT(*)
		  FROM ads023
		 WHERE va_fec_tas = @va_fec_tas

		 IF (@va_nro_reg = 0)
		 BEGIN
			--** Inserta TC. en la tabla
			INSERT INTO ads023 VALUES (@va_fec_tas, @ar_tas_cam)

			IF (@@ERROR > 0)
			BEGIN
				RAISERROR ('Error al Insertar la T.C en la Tabla (ads023) ',16,1)
				ROLLBACK TRAN TR_ads023
				RETURN
			END
		 END
		 ELSE
		 BEGIN
			--** Modifica TC. en la tabla
			UPDATE ads023 SET va_tas_cam = @ar_tas_cam WHERE va_fec_tas = @va_fec_tas

			IF (@@ERROR > 0)
			BEGIN
				RAISERROR ('Error al Insertar la T.C en la Tabla (ads023) ',16,1)
				ROLLBACK TRAN TR_ads023
				RETURN
			END
		 END
	END
	
	--** Lee el siguiente registro
	FETCH NEXT FROM vc_tas_cam INTO @va_fec_tas
END	

CLOSE vc_tas_cam
DEALLOCATE vc_tas_cam


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