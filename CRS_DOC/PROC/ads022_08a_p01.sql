/*****************************************************************/
/*	ARCHIVO: ads022_08a_p01.sql                                  */
/*	PROCEDIMIENTO: EXPORTA INFORME TASA DE CAMBIO Bs/Us A EXCEL  */
/*  PARAMETROS:   @ar_fec_ini  DATETIME  --** Fecha Inicial      */
/*                @ar_fec_fin  DATETIME  --** Fecha Final        */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 05/01/2024             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads022_08a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads022_08a_p01
GO

CREATE PROCEDURE ads022_08a_p01		@ar_fec_ini  DATETIME,
                                    @ar_fec_fin  DATETIME WITH ENCRYPTION AS

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Obtiene el informe en el orden especificado
SELECT CONVERT(VARCHAR, va_fec_tas, 10) AS va_fec_tas,  
       va_tas_cam
  FROM ads022
 WHERE va_fec_tas BETWEEN @ar_fec_ini AND @ar_fec_fin
 ORDER BY va_fec_tas ASC

GO


