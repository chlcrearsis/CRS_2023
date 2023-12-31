/**********************************************************************/
/*	ARCHIVO: ads007_R05.sql                                           */
/*	PROCEDIMIENTO: APLICACIONES AUTORIZADAS P/RANGO DE USUARIO        */
/*  PARAMETROS:   @ar_usr_ini  VARCHAR(15)  --** ID. Usuario Inicial  */
/*                @ar_usr_fin  VARCHAR(15)  --** ID. Usuario Final    */
/*                @ar_mod_ini  INT          --** ID. Modulo Inicial   */
/*                @ar_mod_fin  INT          --** ID. Modulo Final     */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 12/09/2023                  */
/**********************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_R05') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_R05
GO

CREATE PROCEDURE ads007_R05		@ar_usr_ini  VARCHAR(15),
                                @ar_usr_fin  VARCHAR(15),
								@ar_mod_ini  INT,
								@ar_mod_fin  INT	WITH ENCRYPTION AS

DECLARE		@va_ide_usr  VARCHAR(25),	--** ID. Usuario
            @va_nom_usr	 VARCHAR(30),	--** Nombre Usuario
			@va_ide_mod  INT,           --** ID. Módulo
			@va_nom_mod	 VARCHAR(30),	--** Nombre Módulo						
			@va_ide_uno  VARCHAR(15),   --** ID. Registro Uno
			@va_ide_apl  CHAR(06),      --** ID. Aplicación
			@va_nom_apl  VARCHAR(30),   --** Nombre Aplicacion			
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
	va_ide_apl  CHAR(06),
	va_nom_apl  VARCHAR(30),	
	va_usr_reg 	VARCHAR(15),
	va_fch_reg  VARCHAR(19)
)

--** Obtiene los datos de las aplicaciones del sistema
DECLARE vc_per_usr CURSOR LOCAL FOR
 SELECT va_ide_usr, va_ide_uno, va_usr_reg, 
        va_fch_reg
   FROM ads008
  WHERE va_ide_tab = 'ads002'  --** Aplicaciones del sistema
    AND va_ide_usr BETWEEN @ar_usr_ini AND @ar_usr_fin

--** Abre Cursor
OPEN vc_per_usr
--** Lee el primer registro
FETCH NEXT FROM vc_per_usr INTO @va_ide_usr, @va_ide_uno, @va_usr_reg, 
                                @va_fch_reg
														
WHILE (@@FETCH_STATUS = 0)
BEGIN
    --** Obtiene el nombre del Usuario
	SELECT @va_nom_usr = va_nom_usr
	  FROM ads007
	 WHERE va_ide_usr = @va_ide_usr

	 IF (@@ROWCOUNT = 0)
		SET @va_nom_usr = ''	

	--** Obtiene el nombre de la aplicacion	
	SELECT @va_ide_apl = va_ide_apl,
	       @va_nom_apl = va_nom_apl,
		   @va_ide_mod = va_ide_mod
	  FROM ads002
	 WHERE va_ide_apl = @va_ide_uno

	IF (@@ROWCOUNT = 0)
	BEGIN
		SET @va_ide_apl = ''
	    SET @va_nom_apl = ''
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
	                                @va_nom_mod, @va_ide_apl, @va_nom_apl, 
									@va_usr_reg, FORMAT(@va_fch_reg, 'dd/MM/yyyy hh:mm:ss'))

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_per_usr INTO @va_ide_usr, @va_ide_uno, @va_usr_reg, 
                                    @va_fch_reg
END	

CLOSE vc_per_usr
DEALLOCATE vc_per_usr


--** Retorna los datos
SELECT va_ide_usr, va_nom_usr, va_nom_mod, 
       va_ide_apl, va_nom_apl, va_usr_reg, 
	   va_fch_reg
  FROM #tm_per_usr
 WHERE va_ide_mod BETWEEN @ar_mod_ini AND @ar_mod_fin
 ORDER BY va_ide_usr, va_ide_mod, va_ide_apl
