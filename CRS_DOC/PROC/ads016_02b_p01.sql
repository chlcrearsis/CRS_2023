/***************************************************************************/
/*	ARCHIVO: ads016_02b_p01.sql                                            */
/*	PROCEDIMIENTO: REGISTRA SIGUIENTE GESTION                              */
/*  PARAMETROS:   @ag_ant_ges  INT           --** Anterior Gestion         */
/*                @ag_nue_ges  INT           --** Nueva Gestion            */
/*	AUTOR:	CREARSIS(EJR)        FECHA : 23/03/2020                        */
/***************************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads016_02b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads016_02b_p01
GO

CREATE PROCEDURE ads016_02b_p01		@ag_ant_ges INT,
                                    @ag_nue_ges	INT	WITH ENCRYPTION AS

DECLARE		@va_ges_tio	 INT,			--** Gestion
			@va_ges_per	 INT,			--** Periodo
			@va_nom_per	 VARCHAR(10),	--** Nombre de periodo
			@va_fec_ini	 DATE,			--** Primer Dia del Mes
			@va_fec_fin	 DATE,			--** Ultimo Dia del Mes
			@va_ide_doc  CHAR(03),      --** ID. Documento
			@va_nro_tal  INT,           --** Nro. Talonario
			@va_nro_reg  INT,           --** Nro. de Registro
			@va_fec_act  DATETIME,      --** Fecha Actual
			@vx_fec_act  CHAR(10)       --** Fecha Actual String

--** Inhabilita Mensajes Numero de filas afectadas
SET NOCOUNT ON

--**************************************************
--**   GRABA GESTION Y PERIODOS  -> (ads016)      **
--**************************************************

BEGIN TRANSACTION

--** Crea cursor de la gestion anterior
DECLARE vc_ges_tio CURSOR LOCAL FOR
 SELECT va_ges_tio, va_ges_per, va_nom_per, 
	    va_fec_ini, va_fec_fin 
  FROM ads016
 WHERE va_ges_tio = @ag_ant_ges
	
--** Abre cursor		  
OPEN vc_ges_tio    
--** Lee el primer registro
FETCH NEXT FROM vc_ges_tio INTO @va_ges_tio, @va_ges_per, @va_nom_per, 
	                            @va_fec_ini , @va_fec_fin
WHILE (@@FETCH_STATUS = 0)
BEGIN
	--** Incrementa 1 año a las fechas y gestion actual
	SET @va_fec_ini = CONVERT(DATE, DATEADD(YEAR, 1, @va_fec_ini), 101) 
	SET @va_fec_fin = CONVERT(DATE, DATEADD(YEAR, 1, @va_fec_fin), 101)

	--** Verifica si esta creado ese periodo en el sistema
	SELECT @va_nro_reg = COUNT(*) 
	  FROM ads016
	 WHERE va_ges_tio = @ag_nue_ges
	   AND va_ges_per = @va_ges_per

	IF (@va_nro_reg > 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR('Error 201: YA hay un periodo creado en la Nueva Gestion (ads016)', 16, 1)
		RETURN
	END

	--** Inserta el periodo, de la nueva gestion
	INSERT INTO ads016 VALUES (@ag_nue_ges, @va_ges_per, @va_nom_per, @va_fec_ini, @va_fec_fin)

	IF (@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR('Error 202: Error al grabar el periodo de la nueva Gestión (ads016)', 16, 1)
		RETURN
	END

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_ges_tio INTO @va_ges_tio, @va_ges_per, @va_nom_per, 
									@va_fec_ini, @va_fec_fin
END

CLOSE vc_ges_tio
DEALLOCATE vc_ges_tio

--**************************************************
--**      NUMERADOR DE TALONARIOS -> (ads005)     **
--**************************************************
--** Crea cursor con los Numeradores de la gestion anterior
DECLARE vc_num_tal CURSOR LOCAL FOR
 SELECT va_ide_doc, va_nro_tal, va_fec_ini, va_fec_fin
   FROM ads005
  WHERE va_ges_tio = @ag_ant_ges
  ORDER BY va_ide_doc, va_nro_tal ASC
	
--** Abre cursor		  
OPEN vc_num_tal    
--** Lee el primer registro		 
FETCH NEXT FROM vc_num_tal INTO @va_ide_doc, @va_nro_tal, @va_fec_ini, @va_fec_fin

WHILE (@@FETCH_STATUS = 0)
BEGIN
	--** Incrementa 1 año a las fechas y gestion actual
	SET @va_fec_ini = CONVERT(DATE, DATEADD(YEAR, 1, @va_fec_ini), 101) 
	SET @va_fec_fin = CONVERT(DATE, DATEADD(YEAR, 1, @va_fec_fin), 101)

	--** Verifica si esta creado ese periodo en el sistema
	SELECT @va_nro_reg = COUNT(*) 
	  FROM ads005
	 WHERE va_ges_tio = @ag_nue_ges
	   AND va_ide_doc = @va_ide_doc
	   AND va_nro_tal = @va_nro_tal

	IF (@va_nro_reg = 0)
	BEGIN
		--** Inserta el Numerador del Documento
		INSERT INTO ads005 VALUES (@ag_nue_ges, @va_ide_doc, @va_nro_tal, @va_fec_ini, @va_fec_fin, 0, 999999)

		IF (@@ERROR <> 0)
		BEGIN
			ROLLBACK TRANSACTION
			RAISERROR('Error 204: Error al Grabar los Numerador del Documento (ads005)', 16, 1)
			RETURN
		END	
	END			
	
	--** Lee el siguiente registro		 
	FETCH NEXT FROM vc_num_tal INTO @va_ide_doc, @va_nro_tal, @va_fec_ini, @va_fec_fin
END

CLOSE vc_num_tal
DEALLOCATE vc_num_tal

COMMIT TRANSACTION

GO