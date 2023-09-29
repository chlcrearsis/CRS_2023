/*****************************************************************/
/*	ARCHIVO: ads009_01a_p01.sql                                  */
/*	PROCEDIMIENTO: PERMISO TIPO DE USUARIO SOBRE APLICACIÓN      */
/*  PARAMETROS:   @ar_ide_tus  INT   ID. Tipo de Usuario         */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 29/08/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads009_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads009_01a_p01
GO

CREATE PROCEDURE ads009_01a_p01		@ar_ide_tus  CHAR(16)	WITH ENCRYPTION AS

DECLARE		@va_ide_mod  INT,        	--** ID. Módulo
            @va_ide_apl	 VARCHAR(06),	--** ID. Aplicación
			@va_nom_apl	 VARCHAR(30),	--** Nombre Aplicacion
			@va_abr_mod	 CHAR(03),	    --** Abreviación Módulo
			@va_nro_reg  INT,           --** Nro. Registro
			@va_per_mis  CHAR(01)  	    --** Permiso Registro
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_per_apl
(
	va_abr_mod	CHAR(03),
    va_ide_apl	VARCHAR(06),
	va_nom_apl	VARCHAR(30),
	va_per_mis  CHAR(01)
)

--** Obtiene los datos de las aplicaciones del sistema
DECLARE vc_per_apl CURSOR LOCAL FOR
 SELECT va_ide_mod, va_ide_apl, va_nom_apl
   FROM ads002
  WHERE va_est_ado = 'H'

--** Abre Cursor
OPEN vc_per_apl
--** Lee el primer registro
FETCH NEXT FROM vc_per_apl INTO @va_ide_mod, @va_ide_apl, @va_nom_apl
														
WHILE (@@FETCH_STATUS = 0)
BEGIN
	--** Obtiene datos del modulo
	SELECT @va_abr_mod = va_abr_mod
	  FROM ads001
	 WHERE va_ide_mod = @va_ide_mod

	 IF (@@ROWCOUNT = 0)
		SET @va_abr_mod = ''

	--** Verifica si tiene habilitado el usuario ese permiso
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads009
	 WHERE va_ide_tab = 'ads002'
	   AND va_ide_uno = @va_ide_apl
	   AND va_ide_tus = @ar_ide_tus

	IF (@va_nro_reg = 0)
		SET @va_per_mis = 'N'
	ELSE
		SET @va_per_mis = 'S'

	--** Inserta en la tabla temporal
	INSERT INTO #tm_per_apl VALUES (@va_abr_mod, @va_ide_apl, @va_nom_apl, @va_per_mis)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_per_apl INTO @va_ide_mod, @va_ide_apl, @va_nom_apl
END	

CLOSE vc_per_apl
DEALLOCATE vc_per_apl


--** Retorna los datos
SELECT va_abr_mod, va_ide_apl, va_nom_apl, 
       va_per_mis
  FROM #tm_per_apl
 ORDER BY va_abr_mod
