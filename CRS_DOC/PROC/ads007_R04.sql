/**********************************************************************/
/*	ARCHIVO: ads007_R04.sql                                           */
/*	PROCEDIMIENTO: INFORME AUTORIZACIONES P/RANGO DE USUARIO          */
/*  PARAMETROS:   @ar_usr_ini  VARCHAR(15)  --** ID. Usuario Inicial  */
/*                @ar_usr_fin  VARCHAR(15)  --** ID. Usuario Final    */
/*                @ar_mod_ini  INT          --** ID. Modulo Inicial   */
/*                @ar_mod_fin  INT          --** ID. Modulo Final     */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 12/09/2023                  */
/**********************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_R04') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_R04
GO

CREATE PROCEDURE ads007_R04		@ar_usr_ini  VARCHAR(15),
                                @ar_usr_fin  VARCHAR(15),
								@ar_mod_ini  INT,
								@ar_mod_fin  INT	WITH ENCRYPTION AS

DECLARE		@va_ide_usr  VARCHAR(30),	--** ID. Usuario
            @va_nom_usr	 VARCHAR(30),	--** Nombre Usuario
			@va_ide_mod  INT,           --** ID. Módulo
			@va_abr_mod	 CHAR(03),      --** Abrebiacion Módulo
			@va_nom_mod	 VARCHAR(30),	--** Nombre Módulo
			@va_ide_tab	 VARCHAR(06),	--** ID. Tabla
			@va_nom_tab  VARCHAR(30),   --** Nombre Tabla
			@va_cod_reg  VARCHAR(15),   --** Código Registro
			@va_ide_uno  VARCHAR(15),   --** ID. Registro Uno
			@va_ide_dos  VARCHAR(15),   --** ID. Registro Dos
			@va_ide_tre  VARCHAR(15),   --** ID. Registro Tres
			@va_nom_reg  VARCHAR(30),   --** Nombre Registro
			@va_usr_reg  VARCHAR(15),   --** ID. Usuario Registro
			@va_fch_reg  DATETIME,      --** Fecha y Hora de Registro
			@va_nro_reg  INT            --** Nro. de Registro
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_per_usr
(
	va_ide_usr  VARCHAR(30),
    va_nom_usr	VARCHAR(30),
	va_ide_mod  INT,
	va_nom_mod	VARCHAR(30),
	va_ide_tab  CHAR(06),
	va_nom_tab  VARCHAR(30),
	va_cod_reg  VARCHAR(15),
	va_nom_reg  VARCHAR(30),
	va_usr_reg 	VARCHAR(15),
	va_fch_reg  VARCHAR(19)
)

--** Crea tabla temporal de las tablas
CREATE TABLE #tm_lis_tab
(
	va_ide_tab	CHAR(06),
	va_ide_ind  INT,
	va_nom_tab  VARCHAR(30)
)

--** Inserta las tablas de los permisos
INSERT INTO #tm_lis_tab VALUES ('adp001', 0, 'GRUPO DE PERSONA')
INSERT INTO #tm_lis_tab VALUES ('ads002', 0, 'APLICACIONES DEL SISTEMA')
INSERT INTO #tm_lis_tab VALUES ('cmr001', 0, 'LISTA DE PRECIO')
INSERT INTO #tm_lis_tab VALUES ('cmr004', 0, 'PLANTILLA DE VENTA')
INSERT INTO #tm_lis_tab VALUES ('cmr014', 1, 'VENDEDOR')
INSERT INTO #tm_lis_tab VALUES ('cmr014', 2, 'COBRADOR')
INSERT INTO #tm_lis_tab VALUES ('inv001', 0, 'GRUPO DE BODEGAS')
INSERT INTO #tm_lis_tab VALUES ('inv002', 0, 'BODEGAS')

--** Obtiene los datos de las aplicaciones del sistema
DECLARE vc_per_usr CURSOR LOCAL FOR
 SELECT va_ide_usr, va_ide_tab, va_ide_uno, va_ide_dos,
	    va_ide_tre, va_usr_reg, va_fch_reg
   FROM ads008
  WHERE va_ide_usr BETWEEN @ar_usr_ini AND @ar_usr_fin
    AND va_ide_tab <> 'ads004'  --** Distinto a los Series Documentos
	AND va_ide_tab <> 'ads002'  --** Distinto a las aplicaciones del sistema

--** Abre Cursor
OPEN vc_per_usr
--** Lee el primer registro
FETCH NEXT FROM vc_per_usr INTO @va_ide_usr, @va_ide_tab, @va_ide_uno, @va_ide_dos,
								@va_ide_tre, @va_usr_reg, @va_fch_reg
														
WHILE (@@FETCH_STATUS = 0)
BEGIN
    --** Obtiene el nombre del Usuario
	SELECT @va_nom_usr = va_nom_usr
	  FROM ads007
	 WHERE va_ide_usr = @va_ide_usr

	 IF (@@ROWCOUNT = 0)
		SET @va_nom_usr = ''

	--** Obtiene el nombre del modulo
	SET @va_abr_mod = UPPER(SUBSTRING(@va_ide_tab, 1, 3))

	SELECT @va_ide_mod = va_ide_mod,
	       @va_nom_mod = UPPER(va_nom_mod) 
	  FROM ads001
	 WHERE va_abr_mod = @va_abr_mod

	 IF (@@ROWCOUNT = 0)
	 BEGIN
		SET @va_nom_mod = ''
		SET @va_ide_mod = 0
	 END

	--** Obtiene el nombre de la tabla
	IF (@va_ide_tab = 'cmr014')
	BEGIN
		SELECT @va_nom_tab = CONVERT(VARCHAR(30), va_nom_tab)
		  FROM #tm_lis_tab
		 WHERE va_ide_tab = @va_ide_tab
		   AND va_ide_ind = CONVERT(INT, @va_ide_uno)

		IF (@@ROWCOUNT = 0)
			SET @va_nom_tab = ''
	END
	ELSE
	BEGIN
		SELECT @va_nom_tab = CONVERT(VARCHAR(30), va_nom_tab)
		  FROM #tm_lis_tab
		 WHERE va_ide_tab = @va_ide_tab

		IF (@@ROWCOUNT = 0)
			SET @va_nom_tab = ''
	END


	--** Obtiene el nombre del registro
	IF (@va_ide_tab = 'adp001')  --** Grupo Persona
	BEGIN
	    SET @va_cod_reg = @va_ide_uno
		SELECT @va_nom_reg = CONVERT(VARCHAR(30), va_nom_gru)
		  FROM adp001
		 WHERE va_cod_gru = @va_ide_uno

		IF (@@ROWCOUNT = 0)
			SET @va_nom_reg = ''
	END

	IF (@va_ide_tab = 'ads002')  --** Aplicaciones del Sistema
	BEGIN
	    SET @va_cod_reg = @va_ide_uno
		SELECT @va_nom_reg = CONVERT(VARCHAR(30), va_nom_apl)
		  FROM ads002
		 WHERE va_ide_apl = @va_ide_uno

		IF (@@ROWCOUNT = 0)
			SET @va_nom_reg = ''
	END

	IF (@va_ide_tab = 'cmr001')  --** Lista de Precio
	BEGIN
	    SET @va_cod_reg = @va_ide_uno
		SELECT @va_nom_reg = CONVERT(VARCHAR(30), va_nom_lis)
		  FROM cmr001
		 WHERE va_cod_lis = @va_ide_uno

		IF (@@ROWCOUNT = 0)
			SET @va_nom_reg = ''
	END

	IF (@va_ide_tab = 'cmr004')  --** Plantilla de Venta
	BEGIN
	    SET @va_cod_reg = @va_ide_uno
		SELECT @va_nom_reg = CONVERT(VARCHAR(30), va_nom_plv)
		  FROM cmr004
		 WHERE va_cod_plv = @va_ide_uno

		IF (@@ROWCOUNT = 0)
			SET @va_nom_reg = ''
	END

	IF (@va_ide_tab = 'cmr014')  --** Vendedor/Cobrador
	BEGIN
	    SET @va_cod_reg = @va_ide_dos
		SELECT @va_nom_reg = CONVERT(VARCHAR(30), va_nom_bre)
		  FROM cmr014
		 WHERE va_ide_tip = @va_ide_uno
		   AND va_cod_ide = @va_ide_dos

		IF (@@ROWCOUNT = 0)
			SET @va_nom_reg = ''
	END

	IF (@va_ide_tab = 'inv001')  --** Grupo de Bodegas
	BEGIN
	    SET @va_cod_reg = @va_ide_uno
		SELECT @va_nom_reg = va_nom_gru
		  FROM inv001
		 WHERE va_ide_gru = @va_ide_uno

		IF (@@ROWCOUNT = 0)
			SET @va_nom_reg = ''
	END

	IF (@va_ide_tab = 'inv002')  --** Bodegas
	BEGIN
	    SET @va_cod_reg = @va_ide_uno
		SELECT @va_nom_reg = va_nom_bod
		  FROM inv002
		 WHERE va_cod_bod = @va_ide_uno

		IF (@@ROWCOUNT = 0)
			SET @va_nom_reg = ''
	END

	SET @va_ide_usr = 'Usuario : ' + @va_ide_usr

	--** Inserta en la tabla temporal
	INSERT INTO #tm_per_usr VALUES (@va_ide_usr, @va_nom_usr, @va_ide_mod, @va_nom_mod, 
	                                @va_ide_tab, @va_nom_tab, @va_cod_reg, @va_nom_reg, 
									@va_usr_reg, FORMAT(@va_fch_reg, 'dd/MM/yyyy hh:mm:ss'))

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_per_usr INTO @va_ide_usr, @va_ide_tab, @va_ide_uno, @va_ide_dos,
								    @va_ide_tre, @va_usr_reg, @va_fch_reg
END	

CLOSE vc_per_usr
DEALLOCATE vc_per_usr


--** Retorna los datos
SELECT va_ide_usr, va_nom_usr, va_nom_mod, va_ide_tab, va_nom_tab, 
       va_cod_reg, va_nom_reg, va_usr_reg, va_fch_reg
  FROM #tm_per_usr
 WHERE va_ide_mod BETWEEN @ar_mod_ini AND @ar_mod_fin
 ORDER BY va_ide_usr, va_ide_mod, va_ide_tab, va_nom_tab, va_cod_reg
