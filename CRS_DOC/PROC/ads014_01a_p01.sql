/*****************************************************************/
/*	ARCHIVO: ads014_01a_p01.sql                                  */
/*	PROCEDIMIENTO: Claves del Usuario p/Cada Global              */
/*  PARAMETROS:   @ar_ide_usr  VARCHAR(15)  ID. Usuario          */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 20/10/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads014_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads014_01a_p01
GO

CREATE PROCEDURE ads014_01a_p01		@ar_ide_usr  VARCHAR(15) WITH ENCRYPTION AS

DECLARE		@va_ide_mod	 INT,			--** ID. Modulo
			@va_nom_mod  VARCHAR(30),   --** Nombre Módulo
            @va_ide_cla  INT,	        --** ID. Clave
			@va_nom_cla  VARCHAR(60),	--** Nombre Global
			@va_ban_cla  CHAR(01),      --** Bandera Clave Proporcionada (S=Si; N=No)
			@va_nro_reg  INT            --** Nro. de Registro
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_cla_usr
(
	va_ide_mod	INT,
	va_nom_mod  VARCHAR(30),
    va_ide_cla  INT,
	va_nom_cla  VARCHAR(60),
	va_ban_cla  CHAR(01),
)

--** Obtiene los datos de las claves requeridas
DECLARE vc_cla_usr CURSOR LOCAL FOR
 SELECT va_ide_mod, va_ide_cla, va_nom_cla
   FROM ads011
  WHERE va_cla_req = 'S'

--** Abre Cursor
OPEN vc_cla_usr
--** Lee el primer registro
FETCH NEXT FROM vc_cla_usr INTO @va_ide_mod, @va_ide_cla, @va_nom_cla
														
WHILE (@@FETCH_STATUS = 0)
BEGIN

	--** Obtiene datos del Módulo
	SET @va_nom_mod = ''
	SELECT @va_nom_mod = va_nom_mod
	  FROM ads001
	 WHERE va_ide_mod = @va_ide_mod
	
	IF (@@ROWCOUNT = 0)
		SET @va_nom_mod = ''	

	--** Obtiene SI la global tiene clave proporcionado por el usuario
	SET @va_ban_cla = ''
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads014
	 WHERE va_ide_usr = @ar_ide_usr
	   AND va_ide_mod = @va_ide_mod
	   AND va_ide_cla = @va_ide_cla
	
	IF (@va_nro_reg > 0)
		SET @va_ban_cla = 'S'
	ELSE
		SET @va_ban_cla = 'N'
	
	--** Inserta en la tabla temporal
	INSERT INTO #tm_cla_usr VALUES (@va_ide_mod, @va_nom_mod, @va_ide_cla, 
	                                @va_nom_cla, @va_ban_cla)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_cla_usr INTO @va_ide_mod, @va_ide_cla, @va_nom_cla
END	

CLOSE vc_cla_usr
DEALLOCATE vc_cla_usr


--** Retorna los datos
SELECT va_ide_mod, va_nom_mod, va_ide_cla,
	   va_nom_cla, va_ban_cla
  FROM #tm_cla_usr
 ORDER BY va_ide_mod, va_ide_cla
