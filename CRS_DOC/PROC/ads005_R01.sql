/*****************************************************************/
/*	ARCHIVO: ads005_R01.sql                                      */
/*	PROCEDIMIENTO: INFORME CONTROL NUMERACIÓN                    */
/*  PARAMETROS:   @ar_ges_tio  INT       Gestión                 */
/*                @ar_doc_ini  CHAR(03)  Documento Inicial       */
/*                @ar_doc_fin  CHAR(03)  Documento Final         */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 20/06/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads005_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads005_R01
GO

CREATE PROCEDURE ads005_R01		@ar_ges_tio INT,
								@ar_doc_ini CHAR(03),
								@ar_doc_fin	CHAR(03)	WITH ENCRYPTION AS							

DECLARE		@va_ide_mod	 INT,			--** ID. Módulo
            @va_nom_mod  VARCHAR(30),	--** Nombre Módulo            
			@va_ges_tio	 INT,			--** Gestion
			@va_ide_doc	 CHAR(03),		--** ID. Documento
			@va_nom_doc	 VARCHAR(30),	--** Nombre Documento
			@va_tip_tal  INT,           --** Tipo de Talonario (0=Manual; 1=Automatico)
			@vx_tip_tal  VARCHAR(15),   --** Tipo de Talonario (Manual; Automatico)
			@va_nro_tal	 INT,			--** Nro de Talonario
			@va_nom_tal	 VARCHAR(60),	--** Nombre Talonario
			@va_fec_ini  CHAR(10),      --** Fecha Inicial
			@va_fec_fin  CHAR(10),      --** Fecha Final
			@va_con_act  INT,           --** Contador Actual
			@va_con_fin  INT            --** Contador Final

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON		

--** Crea Tabla Temporal
CREATE TABLE #tm_num_tal(
	va_ide_mod  INT,
	va_nom_mod  VARCHAR(30),
	va_ide_doc	CHAR(03),
	va_nom_doc	VARCHAR(30),
	va_tip_tal  VARCHAR(10),
	va_nro_tal	INT,
	va_nom_tal	VARCHAR(60),
	va_ges_tio	INT,
	va_fec_ini	CHAR(10),
	va_fec_fin	CHAR(10),
	va_con_act	INT,
	va_con_fin	INT,				
)

--** Obtiene los datos de Numeracion de Talonario
DECLARE vc_num_tal CURSOR LOCAL FOR
SELECT va_ges_tio, va_ide_doc, va_nro_tal, 
       CONVERT(CHAR(10), va_fec_ini, 103),
       CONVERT(CHAR(10), va_fec_fin, 103), 
	   va_con_act, va_con_fin 
  FROM ads005
 WHERE va_ges_tio = @ar_ges_tio
   AND va_ide_doc BETWEEN @ar_doc_ini AND @ar_doc_fin

--** Abre Cursor
OPEN vc_num_tal
--** Lee el primer registro
FETCH NEXT FROM vc_num_tal INTO @va_ges_tio, @va_ide_doc, @va_nro_tal, @va_fec_ini,
                                @va_fec_fin, @va_con_act, @va_con_fin
														
WHILE (@@FETCH_STATUS = 0)
BEGIN
	--** Obtiene Datos del Talonario
	SET @va_nom_tal = ''
	SET @vx_tip_tal = ''
    SELECT @va_nom_tal = va_nom_tal,
	       @va_tip_tal = va_tip_tal
      FROM ads004
     WHERE va_ide_doc = @va_ide_doc
       AND va_nro_tal = @va_nro_tal

	--** Castea el Tipo Talonario
	IF (@va_tip_tal = 0)
		SET @vx_tip_tal = 'Manual'
	IF (@va_tip_tal = 1)
		SET @vx_tip_tal = 'Automático'

	--** Obtiene Datos del Documento	
    SELECT @va_ide_mod = va_ide_mod,
           @va_nom_doc = va_nom_doc 
      FROM ads003
     WHERE va_ide_doc = @va_ide_doc

	IF (@@ROWCOUNT = 0)
	BEGIN
		SET @va_ide_mod = 0
		SET @va_nom_doc = ''
	END

	--** Obtiene Datos del Módulo
    SELECT @va_nom_mod = va_nom_mod
      FROM ads001
     WHERE va_ide_mod = @va_ide_mod

	IF (@@ROWCOUNT = 0)
		SET @va_nom_mod = ''	

	IF (@va_nom_mod <> '' AND @va_nom_doc <> '' AND @va_nom_tal	<> '')
	BEGIN
		INSERT INTO #tm_num_tal VALUES (@va_ide_mod, @va_nom_mod, @va_ide_doc, @va_nom_doc,
	                                    @vx_tip_tal, @va_nro_tal, @va_nom_tal, @va_ges_tio, 
										@va_fec_ini, @va_fec_fin, @va_con_act, @va_con_fin)
		IF (@@ERROR <> 0)
			RAISERROR('Error al cargar los datos en la tabla temporal', 16, 1) 
	END


	--** Lee el siguiente registro
	FETCH NEXT FROM vc_num_tal INTO @va_ges_tio, @va_ide_doc, @va_nro_tal, @va_fec_ini,
                                    @va_fec_fin, @va_con_act, @va_con_fin
END	

--** Termina y Destruye Cursor
CLOSE vc_num_tal
DEALLOCATE vc_num_tal

--** Devuelve datos
SELECT va_ide_mod, va_nom_mod, va_ide_doc, va_nom_doc,
       va_tip_tal, va_nro_tal, va_nom_tal, va_ges_tio, 
	   va_fec_ini, va_fec_fin, va_con_act, va_con_fin
  FROM #tm_num_tal
  ORDER BY va_ide_mod, va_ide_doc, va_nro_tal
