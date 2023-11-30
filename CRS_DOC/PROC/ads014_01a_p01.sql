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

DECLARE		@va_nem_mod  CHAR(03),      --** Nemónico Módulo
            @va_ide_mod	 INT,			--** ID. Modulo
            @va_ide_cla  INT,	        --** ID. Clave
			@va_nom_glo  VARCHAR(60),	--** Nombre Global
			@va_des_cla  VARCHAR(70),	--** Descripcion Global
			@va_nro_reg  INT,           --** Nro. de Registro
			@va_ban_cla  CHAR(01)       --** Bandera Global (S=Si; N=No)
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_cla_usr
(
	va_nem_mod  CHAR(03),
	va_ide_mod	INT,
	va_ide_cla	INT,	
    va_des_cla  VARCHAR(70),
	va_ban_cla  CHAR(01)
)

--** Obtiene los datos de las aplicaciones del sistema
DECLARE vc_cla_usr CURSOR LOCAL FOR
 SELECT va_ide_mod, va_ide_cla, va_nom_cla
   FROM ads011
  WHERE va_cla_req = 'S'

--** Abre Cursor
OPEN vc_cla_usr
--** Lee el primer registro
FETCH NEXT FROM vc_cla_usr INTO @va_ide_mod, @va_ide_cla, @va_nom_glo
														
WHILE (@@FETCH_STATUS = 0)
BEGIN

	--** Obtiene Nemonico del Módulo
	SET @va_nem_mod = ''
	SELECT @va_nem_mod = va_nom_mod
	  FROM ads001
	 WHERE va_ide_mod = @va_ide_mod
	
	IF (@@ROWCOUNT = 0)
		SET @va_nem_mod = ''

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
	
	--** Concatena la descripcion de la global
	SET @va_des_cla = '(' +  RTRIM(CONVERT(CHAR(02), @va_ide_cla)) + ' - ' + 
	                         RTRIM(CONVERT(CHAR(03), @va_ide_cla)) + ')  ' + @va_nom_glo

	--** Inserta en la tabla temporal
	INSERT INTO #tm_cla_usr VALUES (@va_nem_mod, @va_ide_mod, @va_ide_cla, 
	                                @va_des_cla, @va_ban_cla)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_cla_usr INTO @va_ide_mod, @va_ide_cla, @va_nom_glo
END	

CLOSE vc_cla_usr
DEALLOCATE vc_cla_usr


--** Retorna los datos
SELECT va_nem_mod, va_ide_mod, va_ide_cla, 
	   va_des_cla, va_ban_cla
  FROM #tm_cla_usr
