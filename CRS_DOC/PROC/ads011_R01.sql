/********************************************************************/
/*	ARCHIVO: ads011_R01.sql                                         */
/*	PROCEDIMIENTO: INFORME DEFINICIÓN DE CLAVES                     */
/*  PARAMETROS:   @ar_mod_ini  INT       Módulo Inicial             */
/*                @ar_mod_fin  INT       Módulo Final               */
/*                @ar_ord_dat  CHAR(01)  Orden (C=Código; N=Nombre) */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 20/08/2022                */
/********************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads011_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads011_R01
GO

CREATE PROCEDURE ads011_R01		@ar_mod_ini  INT,
								@ar_mod_fin  INT,
								@ar_ord_dat  CHAR(01) WITH ENCRYPTION AS

DECLARE		@va_ide_mod	 INT,			--** ID. Módulo
            @va_nom_mod  VARCHAR(30),	--** Nombre Módulo
			@va_ide_cla  INT,	        --** ID. Global
			@va_nom_cla  VARCHAR(60),	--** Nombre Global
			@va_obs_cla  VARCHAR(160),	--** Observación Global
			@va_cla_req  CHAR(01),      --** Clave Requerida
			@vx_cla_req  CHAR(02)       --** Clave Requerida (S=Si; N=No)
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_def_cla
(
	va_ide_mod	INT,
	va_nom_mod  VARCHAR(30),
    va_ide_cla	INT,
    va_nom_cla	VARCHAR(60),
    va_obs_cla	VARCHAR(160),
	va_cla_req	CHAR(02),
)

--** Obtiene los datos de las definiciones de claves
DECLARE vc_def_cla CURSOR LOCAL FOR
 SELECT va_ide_mod, va_ide_cla, va_nom_cla,
        va_obs_cla, va_cla_req
   FROM ads011
  WHERE va_ide_mod >= @ar_mod_ini
	AND va_ide_mod <= @ar_mod_fin

--** Abre Cursor
OPEN vc_def_cla
--** Lee el primer registro
FETCH NEXT FROM vc_def_cla INTO @va_ide_mod, @va_ide_cla, @va_nom_cla,
                                @va_obs_cla, @va_cla_req
														
WHILE (@@FETCH_STATUS = 0)
BEGIN

	--** Obtiene nombre del Módulo
	SET @va_nom_mod = ''
	SELECT @va_nom_mod = UPPER(va_nom_mod)
	  FROM ads001
	 WHERE va_ide_mod = @va_ide_mod
	
	IF (@@ROWCOUNT = 0)
		SET @va_nom_mod = ''
	
	--** Castea Clave Requerida
	IF (@va_cla_req = 'S')
		SET @vx_cla_req = 'Si'
	IF (@va_cla_req = 'N')
		SET @vx_cla_req = 'No'

	--** Inserta en la tabla temporal
	INSERT INTO #tm_def_cla VALUES (@va_ide_mod, @va_nom_mod, @va_ide_cla, 
	                                @va_nom_cla, @va_obs_cla, @vx_cla_req)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_def_cla INTO @va_ide_mod, @va_ide_cla, @va_nom_cla,
                                    @va_obs_cla, @va_cla_req
END	

CLOSE vc_def_cla
DEALLOCATE vc_def_cla


--** Retorna los datos
IF (@ar_ord_dat = 'N')
BEGIN  --** Por Nombre
	SELECT va_ide_mod, va_nom_mod, va_ide_cla, 
		   va_nom_cla, va_obs_cla, va_cla_req
	  FROM #tm_def_cla
	 ORDER BY va_nom_cla ASC
END
ELSE
BEGIN	--** Por Código
	SELECT va_ide_mod, va_nom_mod, va_ide_cla, 
		   va_nom_cla, va_obs_cla, va_cla_req
	  FROM #tm_def_cla
	 ORDER BY va_ide_cla ASC
END

GO
