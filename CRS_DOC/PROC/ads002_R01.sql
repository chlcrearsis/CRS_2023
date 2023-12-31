/*****************************************************************/
/*	ARCHIVO: ads002_R01.sql                                      */
/*	PROCEDIMIENTO: INFORME APLICACIONES DEL SISTEMA              */
/*  PARAMETROS:   @ar_est_ado  CHAR(01)  Estado                  */
/*                @ar_mod_ini  INT       Módulo Inicial          */
/*                @ar_mod_fin  INT       Módulo Final            */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 19/08/2022             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads002_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads002_R01
GO

CREATE PROCEDURE ads002_R01		@ar_est_ado  CHAR(01),
                                @ar_mod_ini  INT,
								@ar_mod_fin  INT WITH ENCRYPTION AS

DECLARE		@va_ide_mod	 INT,			--** ID. Módulo
            @va_nom_mod  VARCHAR(30),	--** Nombre Módulo
			@va_ide_apl  VARCHAR(20),	--** ID. Aplicación
			@va_nom_apl  VARCHAR(30),	--** Nombre Aplicaciones
			@va_est_apl  CHAR(01), 	    --** Estado (H=Habilitado; N=Deshabilitado)
			@va_est_ado  VARCHAR(15)    --** Estado (Habilitado; Deshabilitado)
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_apl_sis
(
	va_ide_mod	INT,
	va_nom_mod  VARCHAR(30),
    va_ide_apl  VARCHAR(20),
	va_nom_apl  VARCHAR(120),
	va_est_ado  VARCHAR(15)
)

--** Castea el estado si es T=Todos
IF (@ar_est_ado = 'T')
	SET @ar_est_ado = ''

--** Obtiene los datos de las aplicaciones del sistema
DECLARE vc_apl_sis CURSOR LOCAL FOR
 SELECT va_ide_mod, va_ide_apl, va_nom_apl,
        va_est_ado
   FROM ads002
  WHERE va_est_ado LIKE '%' + RTRIM(@ar_est_ado)
    AND va_ide_mod >= @ar_mod_ini
	AND va_ide_mod <= @ar_mod_fin

--** Abre Cursor
OPEN vc_apl_sis
--** Lee el primer registro
FETCH NEXT FROM vc_apl_sis INTO @va_ide_mod, @va_ide_apl, @va_nom_apl, @va_est_apl
														
WHILE (@@FETCH_STATUS = 0)
BEGIN

	--** Obtiene nombre del tipo de atributo
	SET @va_nom_mod = ''
	SELECT @va_nom_mod = va_nom_mod
	  FROM ads001
	 WHERE va_ide_mod = @va_ide_mod
	
	IF (@@ROWCOUNT = 0)
		SET @va_nom_mod = ''

	SET @va_est_ado = ''
	IF (@va_est_apl = 'H')
		SET @va_est_ado = 'Habilitado'
	IF (@va_est_apl = 'N')
		SET @va_est_ado = 'Deshabilitado'

	--** Inserta en la tabla temporal
	INSERT INTO #tm_apl_sis VALUES (@va_ide_mod, @va_nom_mod, @va_ide_apl, 
	                                @va_nom_apl, @va_est_ado)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_apl_sis INTO @va_ide_mod, @va_ide_apl, @va_nom_apl, @va_est_apl
END	

CLOSE vc_apl_sis
DEALLOCATE vc_apl_sis


--** Retorna los datos
SELECT va_ide_mod, va_nom_mod, va_ide_apl, 
	   va_nom_apl, va_est_ado
  FROM #tm_apl_sis
