/*****************************************************************/
/*	ARCHIVO: ads006_R01.sql                                      */
/*	PROCEDIMIENTO: INFORME TIPO DE USUARIO                       */
/*  PARAMETROS:   @ar_est_ado  CHAR(01)  Estado                  */
/*                @ar_ord_dat  CHAR(02)  Orden Datos             */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 06/04/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads006_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads006_R01
GO

CREATE PROCEDURE ads006_R01		@ar_est_ado  CHAR(01),
                                @ar_ord_dat  CHAR(01) WITH ENCRYPTION AS

--** Castea el estado si es T=Todos
IF (@ar_est_ado = 'T')
	SET @ar_est_ado = ''

--** Obtiene el informe en el orden especificado
SELECT va_ide_tus, va_nom_tus, va_des_tus,  
       CASE WHEN va_est_ado = 'H'
		    THEN 'Habilitado' 
		    ELSE 'Deshabilitado' 
	   END AS va_est_ado
  FROM ads006
 WHERE va_est_ado LIKE '%' + RTRIM(@ar_est_ado)
 ORDER BY 
  CASE WHEN @ar_ord_dat = 'C' THEN va_ide_tus END ASC,
  CASE WHEN @ar_ord_dat = 'N' THEN va_nom_tus END ASC


