/*****************************************************************/
/*	ARCHIVO: ads009_02a_p01.sql                                  */
/*	PROCEDIMIENTO: PERMISO USUARIO SOBRE TALONARIO               */
/*  PARAMETROS:   @ar_ide_tus  INT       --** ID. Tipo Usuario   */
/*                @ar_ide_mod  INT       --** ID. Módulo         */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 30/08/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads009_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads009_02a_p01
GO

CREATE PROCEDURE ads009_02a_p01		@ar_ide_tus  INT,
                                    @ar_ide_mod  INT	WITH ENCRYPTION AS

DECLARE		@va_ide_doc	 CHAR(03),	    --** ID. Aplicación
			@va_nro_tal  INT,           --** Nro. Talonario
			@va_ide_mod  INT,           --** ID. Módulo 
			@va_nom_doc	 VARCHAR(30),	--** Nombre Documento
			@va_nom_tal	 VARCHAR(60),	--** Nombre Documento
			@va_nro_reg  INT,           --** Nro. Registro
			@va_per_mis  CHAR(01)  	    --** Permiso Registro
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_per_tal
(
	va_ide_doc	CHAR(03),
	va_nro_tal  INT,
	va_ide_mod  INT,
    va_nom_doc	VARCHAR(30),
	va_nom_tal	VARCHAR(60),
	va_per_mis  CHAR(01)
)

--** Obtiene los datos de las aplicaciones del sistema
DECLARE vc_per_tal CURSOR LOCAL FOR
 SELECT va_ide_doc, va_nro_tal, va_nom_tal
   FROM ads004
  WHERE va_est_ado = 'H'      

--** Abre Cursor
OPEN vc_per_tal
--** Lee el primer registro
FETCH NEXT FROM vc_per_tal INTO @va_ide_doc, @va_nro_tal, @va_nom_tal
														
WHILE (@@FETCH_STATUS = 0)
BEGIN
	--** Obtiene datos del modulo
	SELECT @va_nom_doc = va_nom_doc,
	       @va_ide_mod = va_ide_mod
	  FROM ads003
	 WHERE va_ide_doc = @va_ide_doc

	 IF (@@ROWCOUNT = 0)
	 BEGIN
		SET @va_nom_doc = ''
		SET @va_ide_mod = ''
	 END

	--** Verifica si tiene habilitado el usuario ese permiso
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads009
	 WHERE va_ide_tab = 'ads004'
	   AND va_ide_uno = @va_ide_doc
	   AND va_ide_dos = @va_nro_tal
	   AND va_ide_tus = @ar_ide_tus

	IF (@va_nro_reg = 0)
		SET @va_per_mis = 'N'
	ELSE
		SET @va_per_mis = 'S'

	--** Inserta en la tabla temporal
	INSERT INTO #tm_per_tal VALUES (@va_ide_doc, @va_nro_tal, @va_ide_mod, 
	                                @va_nom_doc, @va_nom_tal, @va_per_mis)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_per_tal INTO @va_ide_doc, @va_nro_tal, @va_nom_tal
END	

CLOSE vc_per_tal
DEALLOCATE vc_per_tal


--** Retorna los datos
IF (@ar_ide_mod = 0)
BEGIN
	SELECT va_ide_doc, va_nro_tal, va_nom_doc, 
		   va_nom_tal, va_per_mis
	 FROM #tm_per_tal
	ORDER BY va_ide_doc, va_nro_tal
END
ELSE
BEGIN
	SELECT va_ide_doc, va_nro_tal, va_nom_doc, 
		   va_nom_tal, va_per_mis
	 FROM #tm_per_tal
	WHERE va_ide_mod = @ar_ide_mod
	ORDER BY va_ide_doc, va_nro_tal	  
END
