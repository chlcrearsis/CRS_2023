/*****************************************************************/
/*	ARCHIVO: ads016_R01.sql                                      */
/*	PROCEDIMIENTO: INFORME GESTIÓN PERIODO                       */
/*  PARAMETROS:   @ar_ges_tio  INT       Gestión                 */
/*                @ar_ord_dat  CHAR(02)  Orden Datos             */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 18/04/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads016_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads016_R01
GO

CREATE PROCEDURE ads016_R01		@ar_ges_tio  INT,
                                @ar_ord_dat  CHAR(01) WITH ENCRYPTION AS

--** Obtiene el informe en el orden especificado
SELECT va_ges_tio, va_ges_per, va_nom_per,
       CONVERT(CHAR(10), va_fec_ini, 103) AS va_fec_ini,
	   CONVERT(CHAR(10), va_fec_fin, 103) AS va_fec_fin
  FROM ads016
 WHERE (va_ges_tio = @ar_ges_tio)
 ORDER BY 
  CASE WHEN @ar_ord_dat = 'P' THEN va_ges_per END ASC,
  CASE WHEN @ar_ord_dat = 'N' THEN va_nom_per END ASC