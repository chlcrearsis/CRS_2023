/**********************************************************************/
/*	ARCHIVO: ads005_05a_p01.sql                                       */
/*	PROCEDIMIENTO: CONSULTA NUMERACION                                */
/*  PARAMETROS:   @ar_ide_doc  CHAR(03)    --** ID. Documento         */
/*                @ar_nro_tal  INT         --** Nro. Talonario        */
/*                @ar_ges_tio  INT         --** Gestión               */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 20/06/2023                  */
/**********************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads005_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads005_05a_p01
GO

CREATE PROCEDURE ads005_05a_p01		@ar_ges_tio	INT,
                                    @ar_ide_doc	CHAR(03),
									@ar_nro_tal	INT WITH ENCRYPTION AS
							
DECLARE			@va_msn_ret  NVARCHAR(200), --** Mensaje de Retorno
				@va_ide_mod  INT,           --** ID. Módulo
	            @va_nom_mod  VARCHAR(30),   --** Nombre Módulo
				@va_ges_tio	 INT,			--** Gestión
				@va_ide_doc	 CHAR(03),		--** ID. Documento
				@va_nom_doc	 VARCHAR(30),	--** Nombre Documento
				@va_nro_tal	 INT,			--** Nro. Talonario
				@va_nom_tal	 VARCHAR(60),	--** Nombre Talonario				
				@va_fec_ini	 CHAR(10),		--** Fecha Inicial
				@va_fec_fin	 CHAR(10),		--** Fecha Final
				@va_con_act	 INT,			--** Contador Actual
				@va_con_fin	 INT,			--** Contador Final
				@va_nro_reg  INT            --** Nro. Registro

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Crea Tabla Temporal
CREATE TABLE #tm_nro_tal(
	va_ide_mod  INT,
	va_nom_mod  VARCHAR(30),
	va_ges_tio  INT,
	va_ide_doc  CHAR(03),
	va_nom_doc  VARCHAR(30),
	va_nro_tal  INT,
	va_nom_tal  VARCHAR(60),	
	va_fec_ini  CHAR(10),
	va_fec_fin  CHAR(10),
	va_con_act  INT,
	va_con_fin  INT
)

--** Inicializa Variables
SET @va_ges_tio = 0
SET @va_ide_doc = ''
SET @va_nom_doc = ''
SET @va_nro_tal = 0
SET @va_nom_tal = ''
SET @va_fec_ini = ''
SET @va_fec_fin = ''
SET @va_con_act = 0
SET @va_con_fin = 0
SET @va_nro_reg = 0

--** Obtiene Datos de Numeración Talonario
SELECT @va_ges_tio = va_ges_tio,
       @va_ide_doc = va_ide_doc, 
	   @va_nro_tal = va_nro_tal, 	   
	   @va_fec_ini = CONVERT(CHAR(10), va_fec_ini, 103),
	   @va_fec_fin = CONVERT(CHAR(10), va_fec_fin, 103),
	   @va_con_act = va_con_act,
	   @va_con_fin = va_con_fin
  FROM ads005
 WHERE va_ges_tio = @ar_ges_tio
   AND va_ide_doc = @ar_ide_doc
   AND va_nro_tal = @ar_nro_tal

IF (@@ROWCOUNT = 0)
	SET @va_nro_reg = -1

--** Obtiene Datos del Talonario
SELECT @va_nom_tal = va_nom_tal 
  FROM ads004
 WHERE va_ide_doc = @ar_ide_doc
   AND va_nro_tal = @ar_nro_tal

IF (@@ROWCOUNT = 0)
	SET @va_nro_reg = -1

--** Obtiene Datos del Documento
SELECT @va_ide_mod = va_ide_mod,
       @va_nom_doc = va_nom_doc 
  FROM ads003
 WHERE va_ide_doc = @ar_ide_doc

IF (@@ROWCOUNT = 0)
	SET @va_nro_reg = -1

--** Obtiene Datos del Módulo
SELECT @va_nom_mod = va_nom_mod
  FROM ads001
 WHERE va_ide_mod = @va_ide_mod

IF (@@ROWCOUNT = 0)
	SET @va_nro_reg = -1

--** Inserta en la tabla temporal
IF (@va_nro_reg = 0)
BEGIN
	INSERT INTO #tm_nro_tal VALUES (@va_ide_mod, @va_nom_mod, @va_ges_tio, @va_ide_doc,
	                                @va_nom_doc, @va_nro_tal, @va_nom_tal, @va_fec_ini,
	                                @va_fec_fin, @va_con_act, @va_con_fin)
END 

--** Devuelve los datos de retorno
SELECT va_ide_mod AS va_ide_mod,
       va_nom_mod AS va_nom_mod,
	   va_ges_tio AS va_ges_tio,
       va_ide_doc AS va_ide_doc,
	   va_nom_doc AS va_nom_doc,
   	   va_nro_tal AS va_nro_tal,
	   va_nom_tal AS va_nom_tal,
	   va_fec_ini AS va_fec_ini,
	   va_fec_fin AS va_fec_fin,
	   va_con_act AS va_con_act,
	   va_con_fin AS va_con_fin
  FROM #tm_nro_tal
ORDER BY va_ges_tio, va_ide_doc, va_nro_tal