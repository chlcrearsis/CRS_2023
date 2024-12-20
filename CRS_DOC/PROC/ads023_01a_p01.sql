/*****************************************************************/
/*	ARCHIVO: ads023_01a_p01.sql                                  */
/*	PROCEDIMIENTO: OBTIENE LAS TASAS DE CAMBIO Bs/Ufv            */
/*                 DE UN MES EN UN AÑO ESPECIFICO                */
/*      ARGUMENTO: @ar_mes_tdc	INT		--** Mes de la T.C       */
/*                 @ar_año_tdc	INT     --** Año de la T.C       */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 09/01/2024             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads023_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads023_01a_p01
GO

CREATE PROCEDURE ads023_01a_p01		@ar_mes_tdc	INT,
									@ar_año_tdc	INT	 WITH ENCRYPTION AS

DECLARE		@va_fch_str	 CHAR(10),	--** Fecha Cadena
            @va_fec_ini  DATETIME,  --** Fecha Inicial
			@va_fec_fin  DATETIME   --** Fecha Final

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

IF (@ar_mes_tdc < 10)
	SET @va_fch_str = '01/0' + CONVERT(CHAR(01), @ar_mes_tdc) + '/' + CONVERT(CHAR(04), @ar_año_tdc)
ELSE
	SET @va_fch_str = '01/'  + CONVERT(CHAR(02), @ar_mes_tdc) + '/' + CONVERT(CHAR(04), @ar_año_tdc)

--** Castea la fecha inicial
SET @va_fec_ini = CONVERT(DATETIME, @va_fch_str)

--** Obtiene la fecha final
SET @va_fec_fin = DATEADD(MONTH, 1, @va_fec_ini)
SET @va_fec_fin = DATEADD(DAY,  -1, @va_fec_fin)

--** Retorna la lista de resultado
SELECT va_fec_tas, va_tas_cam
  FROM ads023
 WHERE va_fec_tas BETWEEN @va_fec_ini AND @va_fec_fin
 ORDER BY va_fec_tas ASC

GO