/**********************************************************************/
/*	ARCHIVO: ads007_R06.sql                                           */
/*	PROCEDIMIENTO: TALONARIOS AUTORIZADOS P/RANGO DE USUARIO          */
/*  PARAMETROS:   @ar_usr_ini  VARCHAR(15)  --** ID. Usuario Inicial  */
/*                @ar_usr_fin  VARCHAR(15)  --** ID. Usuario Final    */
/*                @ar_mod_ini  INT          --** ID. Modulo Inicial   */
/*                @ar_mod_fin  INT          --** ID. Modulo Final     */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 12/09/2023                  */
/**********************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_R06') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_R06
GO

CREATE PROCEDURE ads007_R06		@ar_usr_ini  VARCHAR(15),
                                @ar_usr_fin  VARCHAR(15),
								@ar_mod_ini  INT,
								@ar_mod_fin  INT	WITH ENCRYPTION AS

DECLARE		@va_ide_usr  VARCHAR(25),	--** ID. Usuario
            @va_nom_usr	 VARCHAR(30),	--** Nombre Usuario
			@va_ide_mod  INT,           --** ID. Módulo
			@va_nom_mod	 VARCHAR(30),	--** Nombre Módulo						
			@va_ide_uno  VARCHAR(15),   --** ID. Registro Uno
			@va_ide_dos  VARCHAR(15),   --** ID. Registro Dos
			@va_ide_doc  CHAR(03),      --** ID. Documento
			@va_nro_tal  INT,           --** Nro. Talonario
			@va_nom_doc  VARCHAR(30),   --** Nombre Documento
			@va_nom_tal  VARCHAR(60),   --** Nombre Talonario			
			@va_usr_reg  VARCHAR(15),   --** ID. Usuario Registro
			@va_fch_reg  DATETIME       --** Fecha y Hora de Registro
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_per_usr
(
	va_ide_usr  VARCHAR(25),
    va_nom_usr	VARCHAR(30),
	va_ide_mod  INT,
	va_nom_mod	VARCHAR(30),
	va_ide_doc  CHAR(03),
	va_nom_doc  VARCHAR(30),	
	va_nro_tal	INT,
	va_nom_tal	VARCHAR(60),	
	va_usr_reg 	VARCHAR(15),
	va_fch_reg  VARCHAR(19)
)

--** Obtiene los datos de las aplicaciones del sistema
DECLARE vc_per_usr CURSOR LOCAL FOR
 SELECT va_ide_usr, va_ide_uno, va_ide_dos, 
        va_usr_reg, va_fch_reg
   FROM ads008
  WHERE va_ide_tab = 'ads004'  --** Talonario
    AND va_ide_usr BETWEEN @ar_usr_ini AND @ar_usr_fin

--** Abre Cursor
OPEN vc_per_usr
--** Lee el primer registro
FETCH NEXT FROM vc_per_usr INTO @va_ide_usr, @va_ide_uno, @va_ide_dos,
                                @va_usr_reg, @va_fch_reg
														
WHILE (@@FETCH_STATUS = 0)
BEGIN
    --** Obtiene el nombre del Usuario
	SELECT @va_nom_usr = va_nom_usr
	  FROM ads007
	 WHERE va_ide_usr = @va_ide_usr

	 IF (@@ROWCOUNT = 0)
		SET @va_nom_usr = ''	

	--** Obtiene el nombre del Talonario
	SELECT @va_ide_doc = va_ide_doc,	       
		   @va_nom_tal = va_nom_tal,
		   @va_nro_tal = va_nro_tal
	  FROM ads004
	 WHERE va_ide_doc = CONVERT(CHAR(03), @va_ide_uno)
	   AND va_nro_tal = CONVERT(INT, @va_ide_dos)

	IF (@@ROWCOUNT = 0)
	BEGIN
		SET @va_ide_doc = ''
	    SET @va_nom_tal = ''
		SET @va_nro_tal = 0
	END

	--** Obtiene el nombre del Documento
	SELECT @va_nom_doc = va_nom_doc,
		   @va_ide_mod = va_ide_mod
	  FROM ads003
	 WHERE va_ide_doc = @va_ide_doc

	IF (@@ROWCOUNT = 0)
	BEGIN
		SET @va_nom_doc = ''
		SET @va_ide_mod = 0
	END

	--** Obtiene el nombre del módulo
	SELECT @va_nom_mod = va_nom_mod
	  FROM ads001
	 WHERE va_ide_mod = @va_ide_mod

	IF (@@ROWCOUNT = 0)
		SET @va_nom_mod = ''

	SET @va_ide_usr = 'Usuario : ' + @va_ide_usr

	--** Inserta en la tabla temporal
	INSERT INTO #tm_per_usr VALUES (@va_ide_usr, @va_nom_usr, @va_ide_mod,
	                                @va_nom_mod, @va_ide_doc, @va_nom_doc,
									@va_nro_tal, @va_nom_tal, @va_usr_reg,
									FORMAT(@va_fch_reg, 'dd/MM/yyyy hh:mm:ss'))

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_per_usr INTO @va_ide_usr, @va_ide_uno, @va_ide_dos,
                                    @va_usr_reg, @va_fch_reg
END	

CLOSE vc_per_usr
DEALLOCATE vc_per_usr

--** Retorna los datos
SELECT va_ide_usr, va_nom_usr, va_nom_mod, 
       va_ide_doc, va_nom_doc, va_nro_tal, 
	   va_nom_tal, va_usr_reg, va_fch_reg
  FROM #tm_per_usr
 WHERE va_ide_mod BETWEEN @ar_mod_ini AND @ar_mod_fin
 ORDER BY va_ide_usr, va_ide_mod, va_ide_doc
