/****************************************************************************/
/*	ARCHIVO: ads004_10_p01.sql                                              */
/*	PROCEDIMIENTO: LISTA USUARIOS AUTORIZADOS P/DOCUMENTO                   */
/*      ARGUMENTO: @ar_ide_tus	INT      	--** ID. Tipo Usuario           */
/*                 @ar_est_usr	CHAR(01)	--** Estado Usuario             */
/*                 @ar_ide_doc	CHAR(03)	--** ID. Documento              */
/*                 @ar_nro_tal	INT	        --** Nro. Talonario             */
/*                 @ar_est_usr	CHAR(01)	--** Estado Usuario             */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 28/06/2023                        */
/****************************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads004_10_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads004_10_p01
GO

CREATE PROCEDURE ads004_10_p01		@ar_ide_tus INT,
                                    @ar_est_usr CHAR(01),
                                    @ar_ide_doc	CHAR(03),
                                    @ar_nro_tal	INT	WITH ENCRYPTION AS

DECLARE		@va_ide_usr  VARCHAR(15),   --** ID. Usuario
	        @va_nom_usr	 VARCHAR(30),	--** Nombre
	        @va_ide_tus	 INT,			--** ID. Tipo de Usuario
			@va_nom_tus  VARCHAR(30),   --** Nombre Tipo de Usuario
	        @va_est_usr	 CHAR(01),	    --** Estado Usuario (H=habilitado; N=deshabilitado)
			@va_ide_mod	 INT,           --** ID. Modulo
			@va_nom_mod	 VARCHAR(30),   --** Nombre Módulo
			@va_ide_doc	 CHAR(03),      --** ID. Documento
			@va_nom_doc	 VARCHAR(30),   --** Nombre Documento
			@va_nro_tal	 INT,           --** Nro. Talonario
			@va_nom_tal	 VARCHAR(60),   --** Nombre Talonario
			@va_opc_sel  CHAR(01),      --** Permitido (S=Si; N=No),
			@va_nro_reg  INT            --** Nro. de Registro
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Crea la Tabla Temporal
CREATE TABLE #tm_usr_tal(
	va_ide_usr 	VARCHAR(15),
	va_nom_usr	VARCHAR(30),
	va_ide_tus	INT,
	va_nom_tus	VARCHAR(30),
	va_est_usr	CHAR(01),
	va_ide_mod	INT,
	va_nom_mod	VARCHAR(30),
	va_ide_doc	CHAR(03),
	va_nom_doc	VARCHAR(30),
	va_nro_tal	INT,
	va_nom_tal	VARCHAR(60),
	va_opc_sel  CHAR(01)
)

--** Lee el nombre del Documento
SET @va_nom_doc = ''
SELECT @va_ide_doc = va_ide_doc,
       @va_nom_doc = va_nom_doc,
       @va_ide_mod = va_ide_mod 
  FROM ads003
 WHERE va_ide_doc = @ar_ide_doc

 IF (@@ROWCOUNT = 0)
	SET @va_nom_doc = ''

--** Lee el nombre del Talonario
SET @va_nom_tal = ''
SELECT @va_nro_tal = va_nro_tal,
       @va_nom_tal = va_nom_tal
  FROM ads004
 WHERE va_ide_doc = @ar_ide_doc
   AND va_nro_tal = @ar_nro_tal

 IF (@@ROWCOUNT = 0)
	SET @va_nom_tal = ''

--** Lee el nombre del Módulo
SET @va_nom_mod = ''
SELECT @va_nom_mod = va_nom_mod
  FROM ads001
 WHERE va_ide_mod = @va_ide_mod

 IF (@@ROWCOUNT = 0)
	SET @va_nom_mod = ''	 

--** Castea el Estado del Usuario
IF (@ar_est_usr = 'T')
	SET @ar_est_usr = ''

--** Obtiene todos los talonarios del Sistema
DECLARE vc_usr_tal CURSOR LOCAL FOR
 SELECT va_ide_usr, va_nom_usr, va_tip_usr, va_est_ado
   FROM ads007
  WHERE va_est_ado LIKE RTRIM(@ar_est_usr) + '%'

--** Abre Cursor		   
OPEN vc_usr_tal

--** Lee el primer registro
FETCH NEXT FROM vc_usr_tal INTO @va_ide_usr, @va_nom_usr, @va_ide_tus, @va_est_usr
WHILE (@@FETCH_STATUS = 0)
BEGIN
	--** Obtiene el nombre del Tipo Usuario
	print @va_ide_usr
	SET @va_nom_tus = ''
	SELECT @va_nom_tus = va_nom_tus
	  FROM ads006
	 WHERE va_ide_tus = @va_ide_tus	

	--** Verifica si el usuario tiene permiso sobre el talonario
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads008
	 WHERE va_ide_usr = @va_ide_usr	
	   AND va_ide_tab = 'ads004'
	   AND va_ide_uno = @va_ide_doc
	   AND va_ide_dos = @va_nro_tal

	IF (@va_nro_reg > 0)
		SET @va_opc_sel = 'S'
	ELSE
		SET @va_opc_sel = 'N'

	--** Inserta en la tabla temporal	 
	INSERT INTO #tm_usr_tal VALUES (@va_ide_usr, @va_nom_usr, @va_ide_tus, @va_nom_tus, 
	                                @va_est_usr, @va_ide_mod, @va_nom_mod, @va_ide_doc,
									@va_nom_doc, @va_nro_tal, @va_nom_tal, @va_opc_sel)

	IF (@@ERROR > 0)
	RETURN
	
	--** Lee el siguiente registro
	FETCH NEXT FROM vc_usr_tal INTO @va_ide_usr, @va_nom_usr, @va_ide_tus, @va_est_usr
END	

--** Cierra y destruye cursor
CLOSE vc_usr_tal
DEALLOCATE vc_usr_tal

--** Retorna lista de permisos autorizados al usuario
IF (@ar_ide_tus = 0) --** TODOS
BEGIN
	SELECT va_ide_usr, va_nom_usr, va_ide_tus, va_nom_tus, 
		   va_est_usr, va_ide_mod, va_nom_mod, va_ide_doc,
		   va_nom_doc, va_nro_tal, va_nom_tal, va_opc_sel
	  FROM #tm_usr_tal
	  ORDER BY va_ide_usr ASC
END
ELSE
BEGIN   --** X TIPO DE USUARIO
	SELECT va_ide_usr, va_nom_usr, va_ide_tus, va_nom_tus, 
		   va_est_usr, va_ide_mod, va_nom_mod, va_ide_doc,
		   va_nom_doc, va_nro_tal, va_nom_tal, va_opc_sel
	  FROM #tm_usr_tal
	 WHERE va_ide_tus = @ar_ide_tus
	 ORDER BY va_ide_usr ASC
END

RETURN --** Fin de Proceedimiento