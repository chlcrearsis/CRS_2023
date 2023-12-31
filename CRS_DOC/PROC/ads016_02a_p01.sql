/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads016_02a_p01.sql
PROCEDIMIENTO: REGISTRA GESTION PERIODO por primera vez
	
AUTOR:	CREARSIS(CHL)
FECHA:	23-03-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads016_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads016_02a_p01
GO

CREATE PROCEDURE ads016_02a_p01		@ag_ges_tio	INT,	--** Gestion año
									@ag_per_ini	INT		--** Periodo en el que empezara la gestion
							        WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_ges_tio		INT			,	-- Gestion
@va_mes_per		INT			,	-- Mes periodo
@va_con_tad		INT			,	-- Contador de periodos
@va_nom_per		VARCHAR(10)	,	-- Nombre de periodo
@va_pri_dia		DATE		,	-- Primer dia del mes
@va_ult_dia		DATE		,	-- Ultimo dia del mes
@va_fec_aux		DATE		,	-- Fecha auxiliar
@va_ide_doc		CHAR(03)	,	-- Ide del docuento
@va_nro_tal		INT			,	-- Numero del talonario

@comando	NVARCHAR(200)	-- Comando para ejecutar sentencia sql
  
IF @@ERROR <> 0
   RETURN

BEGIN TRAN TR_ads016
BEGIN TRY   
	
	CREATE TABLE #MES
	(
		va_ide_mes		INT,
		va_nom_mes		VARCHAR(10)
	)
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
	

	SET @va_ges_tio = @ag_ges_tio
	SET @va_mes_per = @ag_per_ini
	
	--Verifica que sea la primer gestion que se crée
	SELECT *
	FROM ads016
	IF @@ROWCOUNT <> 0
	BEGIN
		RAISERROR ('Esta opcion es solo para crear la gestion por primera vez, ya hay gestion creada',16,1)
		Rollback TRAN TR_ads016
		RETURN
	END


	
	--Obtiene el mes (periodo) en el que iniciara la gestion
	SET @va_con_tad = 1
	
	WHILE (@va_con_tad <= 12)
	BEGIN
		--Obtiene el primer dia del mes
		SET @va_pri_dia = '01/' + CONVERT(VARCHAR(02),@va_mes_per)+'/' + CONVERT(VARCHAR(04),@va_ges_tio) --CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@mydate)-1),@mydate),101)
		
		--Obtiene Ultimo Dia
		if (@va_mes_per <> 12)
		BEGIN
			SET @va_fec_aux = '01/'+ CONVERT(VARCHAR(02),@va_mes_per + 1)+ '/' + CONVERT(VARCHAR(04),@va_ges_tio)
			SET @va_ult_dia = CONVERT(DATE,DATEADD(DAY,-1,@va_fec_aux),101)
		END
		
		if (@va_mes_per = 12)
		BEGIN
			
			SET @va_fec_aux = '01/'+ CONVERT(VARCHAR(02),1)+ '/' + CONVERT(VARCHAR(04),@va_ges_tio + 1)
			SET @va_ult_dia = CONVERT(DATE,DATEADD(DAY,-1,@va_fec_aux),101) 
		END
		
		--Obtiene nombre del periodo
		SELECT @va_nom_per = va_nom_mes
		FROM #MES
		WHERE va_ide_mes = @va_mes_per
		
		--** Registra la Gestion/Periodo
		INSERT INTO ads016 VALUES (@ag_ges_tio, @va_con_tad, @va_nom_per,@va_pri_dia , @va_ult_dia)
		
		
		--Incrementa contadores
		if (@va_mes_per <> 12)
		BEGIN
			SET @va_mes_per = @va_mes_per + 1
		END
		ELSE IF (@va_mes_per = 12)
		BEGIN
			SET @va_mes_per = 1
			SET @va_ges_tio = @va_ges_tio + 1
		END
			
		SET @va_con_tad = @va_con_tad + 1
	END
	
	
		--Crea cursor para los talonarios
	DECLARE vc_tal_doc CURSOR LOCAL FOR
	SELECT va_ide_doc, va_nro_tal
	FROM ads004
	ORDER BY va_ide_doc ,va_nro_tal asc
	
	--** Abre cursor		  
	OPEN vc_tal_doc    
		 
	FETCH NEXT FROM vc_tal_doc INTO @va_ide_doc, @va_nro_tal

	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		IF (@va_nro_tal = 0)
		BEGIN
			--** Registra los numeradores de los talonarios para la gestion 
			
			SELECT @va_pri_dia = MIN(va_fec_ini) , 
				   @va_ult_dia = MAX(va_fec_fin)  
			  FROM ads016
			  
			INSERT INTO ads005 VALUES (@ag_ges_tio, @va_ide_doc, @va_nro_tal, @va_pri_dia, @va_ult_dia, 0, 999999)
			
		END 
		
		IF (@va_nro_tal <> 0)
		BEGIN
			SELECT @va_pri_dia = MIN(va_fec_ini) , 
				   @va_ult_dia = MAX(va_fec_fin)  
			  FROM ads016
			 WHERE va_ges_per = @va_nro_tal
			 
			INSERT INTO ads005 VALUES (@ag_ges_tio, @va_ide_doc, @va_nro_tal, @va_pri_dia, @va_ult_dia, 0, 999999)
		END
		
		-- Pasa al siguiente registro del talonario
		FETCH NEXT FROM vc_tal_doc INTO @va_ide_doc, @va_nro_tal
		
	END	
	
CLOSE vc_tal_doc
DEALLOCATE vc_tal_doc
	
COMMIT TRAN TR_ads016
RETURN
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + 
	ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_ads016
	RETURN
END CATCH	

GO