/********************************************************************/
/*	ARCHIVO: ads013_R01.sql                                         */
/*	PROCEDIMIENTO: INFORME DEFINICIÓN DE GLOBALES                   */
/*  PARAMETROS:   @ar_mod_ini  INT       Módulo Inicial             */
/*                @ar_mod_fin  INT       Módulo Final               */
/*                @ar_ord_dat  CHAR(01)  Orden (C=Código; N=Nombre) */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 20/08/2022                */
/********************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads013_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads013_R01
GO

CREATE PROCEDURE ads013_R01		@ar_mod_ini  INT,
								@ar_mod_fin  INT,
								@ar_ord_dat  CHAR(01) WITH ENCRYPTION AS

DECLARE		@va_ide_mod	 INT,			--** ID. Módulo
            @va_nom_mod  VARCHAR(30),	--** Nombre Módulo
			@va_ide_glo  INT,	        --** ID. Global
			@va_nom_glo  VARCHAR(60),	--** Nombre Global
			@va_tip_glo  INT,	        --** Tipo Global (0=Entero; 1=Decimal; 2=Carecter)
			@vx_tip_glo  VARCHAR(08),   --** Tipo Global Cadena
			@va_glo_ent  INT, 	        --** Global Entero
			@va_glo_dec  INT, 	        --** Global Decimal
			@va_glo_car  VARCHAR(120)   --** Global Caracter
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_def_glo
(
	va_ide_mod	INT,
	va_nom_mod  VARCHAR(30),
    va_ide_glo	INT,
    va_nom_glo	VARCHAR(60),
    va_tip_glo	VARCHAR(08),
    va_glo_ent 	INT,
    va_glo_dec	DEC(18,5),
	va_glo_car	VARCHAR(120),
)

--** Obtiene los datos de las globales
DECLARE vc_def_glo CURSOR LOCAL FOR
 SELECT va_ide_mod, va_ide_glo, va_nom_glo,
        va_tip_glo, va_glo_ent, va_glo_dec,
		va_glo_car
   FROM ads013
  WHERE va_ide_mod >= @ar_mod_ini
	AND va_ide_mod <= @ar_mod_fin

--** Abre Cursor
OPEN vc_def_glo
--** Lee el primer registro
FETCH NEXT FROM vc_def_glo INTO @va_ide_mod, @va_ide_glo, @va_nom_glo, @va_tip_glo, 
                                @va_glo_ent, @va_glo_dec, @va_glo_car
														
WHILE (@@FETCH_STATUS = 0)
BEGIN

	--** Obtiene nombre del módulo
	SET @va_nom_mod = ''
	SELECT @va_nom_mod = UPPER(va_nom_mod)
	  FROM ads001
	 WHERE va_ide_mod = @va_ide_mod
	
	IF (@@ROWCOUNT = 0)
		SET @va_nom_mod = ''
	
	--** Castea el Tipo de Global
	IF (@va_tip_glo = 0)
		SET @vx_tip_glo = 'Entero'
	IF (@va_tip_glo = 1)
		SET @vx_tip_glo = 'Decimal'
	IF (@va_tip_glo = 2)
		SET @vx_tip_glo = 'Caracter'

	--** Inserta en la tabla temporal
	INSERT INTO #tm_def_glo VALUES (@va_ide_mod, @va_nom_mod, @va_ide_glo, 
	                                @va_nom_glo, @vx_tip_glo, @va_glo_ent,
									@va_glo_dec, @va_glo_car)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_def_glo INTO @va_ide_mod, @va_ide_glo, @va_nom_glo, @va_tip_glo, 
                                    @va_glo_ent, @va_glo_dec, @va_glo_car
END	

CLOSE vc_def_glo
DEALLOCATE vc_def_glo

--** Retorna los datos
IF (@ar_ord_dat = 'N')
BEGIN  --** Por Nombre
	SELECT va_ide_mod, va_nom_mod, va_ide_glo, 
		   va_nom_glo, va_tip_glo, va_glo_ent,
		   va_glo_dec, va_glo_car
	  FROM #tm_def_glo
	 ORDER BY va_nom_glo ASC
END
ELSE
BEGIN	--** Por Código
	SELECT va_ide_mod, va_nom_mod, va_ide_glo, 
		   va_nom_glo, va_tip_glo, va_glo_ent,
		   va_glo_dec, va_glo_car
	  FROM #tm_def_glo
	 ORDER BY va_ide_glo ASC
END

GO
