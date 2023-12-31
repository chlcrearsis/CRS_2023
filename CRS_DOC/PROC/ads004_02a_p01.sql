/****************************************************************************/
/*	ARCHIVO: ads004_02a_p01.sql                                             */
/*	PROCEDIMIENTO: REGISTRA TALONARIO Y NUMERACIÓN                          */
/*      ARGUMENTO: @ar_ide_doc	CHAR(03)	--** ID. Documento              */
/*                 @ar_nro_tal	INT			--** Nro Talonario              */
/*                 @ar_nom_tal	VARCHAR(60)	--** Nombre del Talonario       */
/*                 @ar_tip_tal	INT			--** 0=Manual; 1=Automatico     */
/*                 @ar_nro_aut	BIGINT		--** Nro de Dosificación        */
/*                 @ar_for_mat	INT			--** Nro de Formato p/Impresión */
/*                 @ar_nro_cop	INT			--** Nro de Copias de Impresión */
/*                 @ar_fir_ma1	VARCHAR(15)	--** Firma 1 para el documento  */
/*                 @ar_fir_ma2	VARCHAR(15)	--** Firma 2 para el documento  */
/*                 @ar_fir_ma3	VARCHAR(15)	--** Firma 3 para el documento  */
/*                 @ar_fir_ma4	VARCHAR(15)	--** Firma 4 para el documento  */
/*                 @ar_for_log	INT			--** Formato de Logo            */
/*                 @ar_ges_tio	INT			--** Gestion Año                */
/*                 @ar_anu_mes	INT			--** (0=Anual ; 1=Mensual)      */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 17/05/2020                        */
/****************************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads004_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads004_02a_p01
GO

CREATE PROCEDURE ads004_02a_p01		@ar_ide_doc	CHAR(03),	 @ar_nro_tal INT,
									@ar_nom_tal	VARCHAR(60), @ar_tip_tal INT,
									@ar_nro_aut	BIGINT,      @ar_for_mat INT,
									@ar_nro_cop	INT,	     @ar_fir_ma1 VARCHAR(15),
									@ar_fir_ma2	VARCHAR(15), @ar_fir_ma3 VARCHAR(15),
									@ar_fir_ma4	VARCHAR(15), @ar_for_log INT,
									@ar_obs_uno VARCHAR(80), @ar_obs_dos VARCHAR(80),
									@ar_ges_tio	INT,		 @ar_anu_mes INT	WITH ENCRYPTION AS

DECLARE		@va_msn_err	 NVARCHAR(200),	--** Mensaje de Error
			@va_nro_reg  INT,			--** Nro. de Registro encontrados
			@va_ges_tio	 INT,			--** Gestión
			@va_mes_per	 INT,	        --** Mes Periodo
			@va_nom_per	 VARCHAR(10),	--** Nombre de periodo
			@va_pri_dia	 DATE,	        --** Primer dia del mes
			@va_ult_dia	 DATE,			--** Ultimo dia del mes
		    @va_ide_doc	 CHAR(03),	    --** ID. Docuento
			@va_nro_tal	 INT,	        --** Número del Talonario
			@va_nom_tal	 VARCHAR(60),	--** Nombre del talonario
			@va_con_tad	 INT	        --** Contador de periodos

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Inicio de Transación  
BEGIN TRAN TR_ads005
BEGIN TRY   
	--** Crea una tabla temporal
	CREATE TABLE #MES
	(	
		va_ide_mes		INT,
		va_nom_mes		VARCHAR(10)
	)
	
	--** Inserta los meses del año
	INSERT INTO #MES VALUES (1,'Enero')
	INSERT INTO #MES VALUES (2,'Febrero')
	INSERT INTO #MES VALUES (3,'Marzo')
	INSERT INTO #MES VALUES (4,'Abril')
	INSERT INTO #MES VALUES (5,'Mayo')
	INSERT INTO #MES VALUES (6,'Junio')
	INSERT INTO #MES VALUES (7,'Julio')
	INSERT INTO #MES VALUES (8,'Agosto')
	INSERT INTO #MES VALUES (9,'Septiembre')
	INSERT INTO #MES VALUES (10,'Octubre')
	INSERT INTO #MES VALUES (11,'Noviembre')
	INSERT INTO #MES VALUES (12,'Diciembre')
	
	--** Inicializa variables
	SET @va_ges_tio = @ar_ges_tio
	SET @va_ide_doc = @ar_ide_doc
	SET @va_nro_tal = @ar_nro_tal
		
	--** Verifica que la Gestión se encuentre registrada
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads016
	 WHERE va_ges_tio = @ar_ges_tio
	 
	 IF(@va_nro_reg = 0)
	 BEGIN		
		RAISERROR ('La Gestión proporsionada no se encuentra registrada. ',16,1)
		ROLLBACK TRAN TR_ads005
		RETURN
	 END
	
	--** Obtiene MES inicial de la gestion
	SELECT @va_mes_per = va_ges_per 
	  FROM ads016
	 WHERE va_ges_tio = @ar_ges_tio
	 ORDER BY va_ges_per DESC
	
	--** En caso de ser Talonario Anual
	IF(@ar_anu_mes = 0)
	BEGIN
		--** Crea Talonario Anual
		INSERT INTO ads004 VALUES (@va_ide_doc, @va_nro_tal, @ar_nom_tal, @ar_tip_tal, @ar_nro_aut,
								   @ar_for_mat, @ar_nro_cop, @ar_fir_ma1, @ar_fir_ma2, @ar_fir_ma3,
								   @ar_fir_ma4, @ar_for_log, @ar_obs_uno, @ar_obs_dos, 'H')

		IF (@@ERROR > 0)
		BEGIN
			RAISERROR ('Error al grabar el Talonario (ads004)', 16, 1)
			ROLLBACK TRAN TR_ads004
			RETURN
		END
		
		--** Obtiene primer y último día de la Gestión
		SELECT @va_pri_dia = MIN(va_fec_ini) , 
			   @va_ult_dia = MAX(va_fec_fin)  
		  FROM ads016
		 WHERE va_ges_tio = @ar_ges_tio
		 
		--** Créa Numeración Anual			  
		INSERT INTO ads005 VALUES (@ar_ges_tio, @va_ide_doc, @va_nro_tal, @va_pri_dia,@va_ult_dia, 0, 999999)
		
		IF (@@ERROR > 0)
		BEGIN
			RAISERROR ('Error al grabar el Control Numeración (ads005)', 16, 1)
			ROLLBACK TRAN TR_ads005
			RETURN
		END
	
	END
	
	--** En caso de ser Talonario Mensual, segun Gestión
	IF(@ar_anu_mes = 1)
	BEGIN
		SET @va_con_tad = 1

		--** Recorre los 12 Meses del Año
		WHILE (@va_con_tad <= 12)
		BEGIN			
			--** Obtiene datos del periodo
			SELECT @va_nom_per = va_nom_per,
				   @va_pri_dia = va_fec_ini,
				   @va_ult_dia = va_fec_fin
			  FROM ads016
			 WHERE va_ges_tio = @ar_ges_tio
			   AND va_ges_per = @va_con_tad
			
			--** Compone nombre de talonario + nombre del mes correspondiente
			SET @va_nom_tal = @ar_nom_tal + ' - ' + @va_nom_per
			
			--** Verifica que el Talonario a crear en el mes, aun no este creado
			SET @va_nro_reg = 0
			SELECT @va_nro_reg = COUNT(*)
			  FROM ads004
			 WHERE va_ide_doc = @va_ide_doc
			   AND va_nro_tal = @va_nro_tal

			IF (@va_nro_reg > 0)
			BEGIN
				SET @va_msn_err = 'NO se puede crear un Talonario duplicado, el talonario: ' +  RTRIM(CONVERT(VARCHAR(255), @va_nro_tal)) +
						          ' para el Documento ' + RTRIM(@va_ide_doc) + ' YA se encuentra registrado'
				
				RAISERROR (@va_msn_err ,16,1)
				ROLLBACK TRAN TR_ads004
				RETURN
			END
			
			--** Créa Talonario por Mes
			INSERT INTO ads004 VALUES (@va_ide_doc, @va_nro_tal, @va_nom_tal, @ar_tip_tal, @ar_nro_aut,
									   @ar_for_mat, @ar_nro_cop, @ar_fir_ma1, @ar_fir_ma2, @ar_fir_ma3,
									   @ar_fir_ma4, @ar_for_log, @ar_obs_uno, @ar_obs_dos, 'H')

			IF (@@ERROR > 0)
			BEGIN
				RAISERROR ('Error al grabar el Talonario (ads004)', 16, 1)
				ROLLBACK TRAN TR_ads004
				RETURN
			END
									   
			--** Créa Numeración por Mes
			INSERT INTO ads005 VALUES (@ar_ges_tio, @va_ide_doc, @va_nro_tal, @va_pri_dia, @va_ult_dia, 0, 999999)

			IF (@@ERROR > 0)
			BEGIN
				RAISERROR ('Error al grabar el Control Numeración (ads005)', 16, 1)
				ROLLBACK TRAN TR_ads005
				RETURN
			END
			
			--** Incrementa Contadores
			SET @va_con_tad = @va_con_tad + 1
			SET @va_nro_tal = @va_nro_tal + 1			
		END	
	END	
COMMIT TRAN TR_ads005
RETURN
END TRY
BEGIN CATCH	
	SET @va_msn_err = 'Error: ' + 
	ERROR_MESSAGE() + ' (Línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@va_msn_err,16,1)
    ROLLBACK TRAN TR_ads004
	ROLLBACK TRAN TR_ads005
	RETURN
END CATCH	
GO