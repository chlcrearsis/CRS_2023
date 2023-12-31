/*****************************************************************/
/*	ARCHIVO: ads016_R02.sql                                      */
/*	PROCEDIMIENTO: INFORME LISTA DE GESTIÓN                      */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 19/04/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads016_R02') and sysstat & 0xf = 4)
	drop procedure dbo.ads016_R02
GO

CREATE PROCEDURE ads016_R02		WITH ENCRYPTION AS

--** Obtiene el informe en el orden especificado
SELECT va_ges_tio, va_ges_per, va_nom_per,
       CONVERT(CHAR(10), va_fec_ini, 103) AS va_fec_ini,
	   CONVERT(CHAR(10), va_fec_fin, 103) AS va_fec_fin
  FROM ads016
 ORDER BY va_ges_tio, va_ges_per