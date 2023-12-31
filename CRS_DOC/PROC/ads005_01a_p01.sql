/**********************************************************************/
/*	ARCHIVO: ads005_01a_p01.sql                                       */
/*	PROCEDIMIENTO: BUSCA NUMERACIÓN DE TALONARIO                      */
/*  PARAMETROS:   @ar_ide_mod  INT         --** ID. Módulo            */
/*                @ar_ges_tio  INT         --** Gestión               */
/*                @ar_tex_bus  VARCHAR(60) --** Texto a Buscar        */
/*                @ar_cri_bus  INT         --** Criterio de Busqueda  */
/*                @ar_est_ado  CHAR(01)    --** Estado del Documento  */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 11/04/2023                  */
/**********************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads005_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads005_01a_p01
GO

CREATE PROCEDURE ads005_01a_p01		@ar_ide_mod	 INT,			--** ID. Módulo
									@ar_ges_tio	 INT,			--** Gestion
									@ar_tex_bus	 VARCHAR(60),	--** Texto a Buscar
									@ar_cri_bus	 INT,			--** Criterio de Busqueda (0=ID. Documento; 1=Nombre Doc; 2=Nombre Talonario)
									@ar_est_ado  CHAR(01)       --** Estado del Documento (H=Habilitado; N=Deshabilitado; T=Todos)      
									WITH ENCRYPTION AS

DECLARE     @va_ide_mod  INT,			--** ID. Módulo
			@va_nom_mod  VARCHAR(30),    --** Nombre Módulo
			@va_ges_tio	 INT,			--** Gestión			
			@va_ide_doc	 CHAR(03),		--** ID. Documento
			@va_nom_doc	 VARCHAR(30),	--** Nombre Documento
			@va_nro_tal	 INT,			--** Nro. Talonario
			@va_nom_tal	 VARCHAR(30),	--** Nombre Talonario
			@va_fec_ini  DATETIME,		--** Fecha Inicial
			@vx_fec_ini  CHAR(10),		--** Fecha Inicial Char
			@va_fec_fin  DATETIME,		--** Fecha Final		
			@vx_fec_fin  CHAR(10),		--** Fecha Final Char
			@va_con_act	 INT,			--** Contador Actual
			@va_con_fin	 INT,			--** Contador Final	
			@va_est_tal  CHAR(01)       --** Estado (H=Habilitado; N=Deshabilitado)

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_num_tal (
    va_ide_mod  INT,            --** ID. Módulo
	va_nom_mod  VARCHAR(30),    --** Nombre Módulo
	va_ges_tio	INT,            --** Gestión
	va_ide_doc	CHAR(03),       --** ID. Documento
	va_nom_doc	VARCHAR(30),    --** Nombre Documento
	va_nro_tal	INT,            --** Nro. Talonario
	va_nom_tal	VARCHAR(30),    --** Nombre Talonario
	va_fec_ini	DATETIME,       --** Fecha Inicial
	va_fec_fin	DATETIME,	    --** Fecha Final	
	va_con_act	INT,			--** Contador Actual
	va_con_fin	INT,			--** Contador Final	
	va_est_tal  CHAR(01)        --** Estado (H=Habilitado; N=Deshabilitado)
)

--** Crea tabla temporal
CREATE TABLE #tm_mod_ulo(
	va_ide_mod  INT
)

IF (@ar_ide_mod = 0)
	INSERT INTO #tm_mod_ulo SELECT va_ide_mod FROM ads001 WHERE va_est_ado = 'H'
ELSE
    INSERT INTO #tm_mod_ulo VALUES (@ar_ide_mod)


--** Declara un cursor
DECLARE vc_num_tal CURSOR LOCAL FOR
--** Obtiene los datos
SELECT ads003.va_ide_mod, ads005.va_ges_tio, ads003.va_ide_doc, ads003.va_nom_doc, 
       ads005.va_nro_tal, ads005.va_fec_ini, ads005.va_fec_fin, ads005.va_con_act,
	   ads005.va_con_fin
  FROM ads005, ads003, #tm_mod_ulo
 WHERE ads003.va_ide_doc = ads005.va_ide_doc
   AND ads003.va_ide_mod = #tm_mod_ulo.va_ide_mod
   AND ads005.va_ges_tio = @ar_ges_tio

--** Abre el cursor
OPEN vc_num_tal
--** Lee el primer registro
FETCH NEXT FROM vc_num_tal INTO @va_ide_mod, @va_ges_tio, @va_ide_doc, @va_nom_doc, 
                                @va_nro_tal, @va_fec_ini, @va_fec_fin, @va_con_act,
								@va_con_fin

WHILE (@@FETCH_STATUS = 0)
BEGIN
    --** Inicializa Variable
    SET @va_nom_mod = ''
    SET @va_nom_tal = ''
	SET @va_est_tal = ''

    -- Obtiene nombre del Módulo	
	SELECT @va_nom_mod = va_nom_mod
	  FROM ads001
	 WHERE va_ide_mod = @va_ide_mod

	-- Obtiene nombre del Taolonario	
	SELECT @va_nom_tal = va_nom_tal,
	       @va_est_tal = va_est_ado
	  FROM ads004
	 WHERE va_ide_doc = @va_ide_doc
	   AND va_nro_tal = @va_nro_tal

	--** Convierte la fecha en cadena dd/MM/yyyy
	SET @vx_fec_ini = CONVERT(CHAR(10), @va_fec_ini, 103)
	SET @vx_fec_fin = CONVERT(CHAR(10), @va_fec_fin, 103)
	 
	INSERT INTO #tm_num_tal VALUES (@va_ide_mod, @va_nom_mod, @va_ges_tio, @va_ide_doc, 
	                                @va_nom_doc, @va_nro_tal, @va_nom_tal, @vx_fec_ini, 
									@vx_fec_fin, @va_con_act, @va_con_fin, @va_est_tal)

	IF (@@ERROR <> 0)
		RETURN

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_num_tal INTO @va_ide_mod, @va_ges_tio, @va_ide_doc, @va_nom_doc, 
									@va_nro_tal, @va_fec_ini, @va_fec_fin, @va_con_act,
								    @va_con_fin
END	

CLOSE vc_num_tal
DEALLOCATE vc_num_tal

IF (@ar_est_ado = 'T')
	SET @ar_est_ado = ''

--** Retorna los resultados de acuerdo los criterios
IF(@ar_cri_bus = 0)  --** ID. Documento
BEGIN
	SELECT va_ide_mod, va_nom_mod, va_ges_tio, va_ide_doc, 
	       va_nom_doc, va_nro_tal, va_nom_tal, va_fec_ini, 
		   va_fec_fin, va_con_act, va_con_fin, va_est_tal
	  FROM #tm_num_tal
	 WHERE va_ide_doc LIKE @ar_tex_bus + '%'
	   AND va_est_tal LIKE RTRIM(@ar_est_ado) + '%'
END

IF(@ar_cri_bus = 1)  --** Nombre Documento
BEGIN
	SELECT va_ide_mod, va_nom_mod, va_ges_tio, va_ide_doc, 
	       va_nom_doc, va_nro_tal, va_nom_tal, va_fec_ini, 
		   va_fec_fin, va_con_act, va_con_fin, va_est_tal
	  FROM #tm_num_tal
	 WHERE va_nom_doc LIKE @ar_tex_bus + '%'
	   AND va_est_tal LIKE RTRIM(@ar_est_ado) + '%'
END

IF(@ar_cri_bus = 2)  --** Nombre Talonario
BEGIN
	SELECT va_ide_mod, va_nom_mod, va_ges_tio, va_ide_doc, 
	       va_nom_doc, va_nro_tal, va_nom_tal, va_fec_ini, 
		   va_fec_fin, va_con_act, va_con_fin, va_est_tal
	  FROM #tm_num_tal
	 WHERE va_nom_tal LIKE @ar_tex_bus + '%'
	   AND va_est_tal LIKE RTRIM(@ar_est_ado) + '%'
END

RETURN 
GO


