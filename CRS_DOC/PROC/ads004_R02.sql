/*****************************************************************/
/*	ARCHIVO: ads004_R02.sql                                      */
/*	PROCEDIMIENTO: INFORME TALONARIO FORMATOS Y DEFINICIÓN       */
/*                 DE FIRMAS                                     */
/*  PARAMETROS:   @ar_ide_mod  INT       ID. Módulo              */
/*                @ar_doc_ini  CHAR(03)  ID. Documento Inicial   */
/*                @ar_doc_fin  CHAR(03)  ID. Documento Final     */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 01/04/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads004_R02') and sysstat & 0xf = 4)
	drop procedure dbo.ads004_R02
GO

CREATE PROCEDURE ads004_R02		@ar_ide_mod	INT,
								@ar_doc_ini	CHAR(03),
								@ar_doc_fin	CHAR(03)	WITH ENCRYPTION AS							

DECLARE		@va_ide_mod	 INT,			--** ID. Módulo
            @va_nom_doc	 VARCHAR(30),	--** Nombre Módulo
			@va_ide_doc	 CHAR(03),		--** ID. Documento
			@va_nro_tal	 INT,			--** Nro de Talonario
			@va_nom_tal	 VARCHAR(60),	--** Nombre Talonario
			@va_tip_tal	 INT,	        --** Tipo de Talonario
			@va_nro_aut	 DECIMAL(15,0),	--** Número de Autorización
			@va_for_mat	 INT,	        --** Formato de Impresión
			@va_nro_cop	 INT,	        --** Nro de Copias a Imprimir
			@va_fir_ma1	 VARCHAR(30),	--** Firma Nro 1
			@va_fir_ma2	 VARCHAR(30),	--** Firma Nro 2
			@va_fir_ma3	 VARCHAR(30),	--** Firma Nro 3
			@va_fir_ma4	 VARCHAR(30),	--** Firma Nro 4
			@va_for_log	 INT,           --** Formato Logo
			@va_est_tal	 CHAR(01),      --** Estado (H=Habilitado; N=Deshabilitado)
			@va_est_ado  VARCHAR(15)    --** Estado (Habilitado; Deshabilitado)

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON		

--** Crea Tabla Temporal
CREATE TABLE #tm_tal_doc
(
	va_ide_doc	CHAR(03),
	va_nom_doc	VARCHAR(30),
	va_nro_tal	INT,
	va_nom_tal	VARCHAR(60),
	va_for_mat	INT,
	va_fir_ma1	VARCHAR(30),
	va_fir_ma2	VARCHAR(30),
	va_fir_ma3	VARCHAR(30),
	va_fir_ma4	VARCHAR(30),
	va_est_ado  VARCHAR(15)				
)
--** Obtiene los datos del Talonario
DECLARE vc_tal_doc CURSOR LOCAL FOR
 SELECT va_ide_doc, va_nro_tal, va_nom_tal, va_for_mat, 
	    va_fir_ma1, va_fir_ma2, va_fir_ma3, va_fir_ma4
   FROM ads004
  WHERE va_ide_doc BETWEEN @ar_doc_ini AND @ar_doc_fin

--** Abre Cursor	  
OPEN vc_tal_doc    
--** Lee el primer registro
FETCH NEXT FROM vc_tal_doc INTO @va_ide_doc, @va_nro_tal, @va_nom_tal, @va_for_mat, 
	                            @va_fir_ma1, @va_fir_ma2, @va_fir_ma3, @va_fir_ma4
WHILE (@@FETCH_STATUS = 0)
BEGIN

	--** Obtiene el nombre del documento
	SELECT @va_nom_doc = va_nom_doc
	  FROM ads003
	 WHERE va_ide_doc = @va_ide_doc

	SET @va_est_ado = ''
	IF (@va_est_tal = 'H')
		SET @va_est_ado = 'Habilitado'
	IF (@va_est_tal = 'N')
		SET @va_est_ado = 'Deshabilitado'
		
	--** Inserta en la Tabla Temporal
	INSERT INTO #tm_tal_doc VALUES (@va_ide_doc, @va_nom_doc, @va_nro_tal, @va_nom_tal, 
		                            @va_for_mat, @va_fir_ma1, @va_fir_ma2, @va_fir_ma3, 
									@va_fir_ma4, @va_est_ado)


	--** Lee el siguiente registro
	FETCH NEXT FROM vc_tal_doc INTO @va_ide_doc, @va_nro_tal, @va_nom_tal, @va_for_mat, 
	                                @va_fir_ma1, @va_fir_ma2, @va_fir_ma3, @va_fir_ma4
END	
--** Termina y Destruye Cursor
CLOSE vc_tal_doc
DEALLOCATE vc_tal_doc
	
--** Devuelve datos
SELECT va_ide_doc, va_nom_doc, va_nro_tal, va_nom_tal, 
	   va_for_mat, va_fir_ma1, va_fir_ma2, va_fir_ma3, 
	   va_fir_ma4, va_est_ado 
  FROM #tm_tal_doc
  ORDER BY va_ide_doc, va_nro_tal
