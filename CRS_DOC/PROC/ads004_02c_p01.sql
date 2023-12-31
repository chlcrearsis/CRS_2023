/*****************************************************************/
/*	ARCHIVO: ads004_02c_p01.sql                                  */
/*	PROCEDIMIENTO: GRABA TALONARIO AUTOMATICO                    */
/*     ARGUMENTOS: - @ar_ide_doc  CHAR(03) ID. Documento         */
/*				   - @ar_tal_anu  CHAR(01) Talonario Anual       */
/*				   - @ar_tal_mes  CHAR(01) Talonario Mensual     */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 19/06/2023             */
/*   NOTA: En caso de error devuelve del 101 as 120              */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads004_02c_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads004_02c_p01
GO

CREATE PROCEDURE ads004_02c_p01		@ar_ide_doc  CHAR(03),   --** ID. Documento
									@ar_tal_anu  CHAR(01),   --** Talonario Anual (N=No; S=Si)
									@ar_tal_mes  CHAR(01)    --** Talonario Mensual (N=No; S=Si)									
									WITH ENCRYPTION AS

DECLARE		@va_nro_reg  INT,		  --** Nro de Registro
            @va_est_ado  CHAR(01),    --** Estado
			@va_nro_tal  INT,         --** Nro. Talonario
			@va_nom_doc  CHAR(30),    --** Nombre Documento
			@va_nom_tal  CHAR(30),    --** Nombre Talonario
			@va_tip_tal	 INT,	      --** Tipo de Talonario (0=Manual; 1=Automatico)
			@va_nro_aut  DEC(15,0),   --** Nro. Autorización
			@va_for_mat	 INT,		  --** Formato de Impresión
	        @va_nro_cop	 INT,		  --** Nro. de Copias a Imprimir
	        @va_fir_ma1	 VARCHAR(15), --** Firma Nro. 1
	        @va_fir_ma2	 VARCHAR(15), --** Firma Nro. 2
	        @va_fir_ma3	 VARCHAR(15), --** Firma Nro. 3
	        @va_fir_ma4	 VARCHAR(15), --** Firma Nro. 4
	        @va_for_log	 INT,		  --** Formato de Logo	
									  --** 0=Razon Social de Empresa; 1=Logotipo 1
									  --** 2=Logotipo 2 ;3=Logotipo 3    
            @va_obs_uno  VARCHAR(80), --** Observación 1
	        @va_obs_dos  VARCHAR(80), --** Observación 2
	        @va_est_tal	 CHAR(01)     --** Estado (H=Habilitado; N=Deshabilitado)
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Iniciliza Variables
SET @va_tip_tal = 1 --** Automatico
SET @va_nro_aut = 0
SET @va_for_mat = 100
SET @va_nro_cop = 1
SET @va_fir_ma1 = 'Elaborado por'
SET @va_fir_ma2 = 'Revisado por'
SET @va_fir_ma3 = 'Aprobado por'
SET @va_fir_ma4 = ''
SET @va_for_log = 0 --** Razon Social de Empresa
SET @va_obs_uno = ''
SET @va_obs_dos = ''
SET @va_est_tal = 'H'

--** Crea Tabla Temporal
CREATE TABLE #tm_tal_mes(
	va_nro_tal INT,
	va_nom_tal VARCHAR(30)
)

--** Inserta la tabla temporal
INSERT INTO #tm_tal_mes VALUES (1, 'Talonario Enero')
INSERT INTO #tm_tal_mes VALUES (2, 'Talonario Febrero')
INSERT INTO #tm_tal_mes VALUES (3, 'Talonario Marzo')
INSERT INTO #tm_tal_mes VALUES (4, 'Talonario Abril')
INSERT INTO #tm_tal_mes VALUES (5, 'Talonario Mayo')
INSERT INTO #tm_tal_mes VALUES (6, 'Talonario Junio')
INSERT INTO #tm_tal_mes VALUES (7, 'Talonario Julio')
INSERT INTO #tm_tal_mes VALUES (8, 'Talonario Agosto')
INSERT INTO #tm_tal_mes VALUES (9, 'Talonario Septiembre')
INSERT INTO #tm_tal_mes VALUES (10, 'Talonario Octubre')
INSERT INTO #tm_tal_mes VALUES (11, 'Talonario Noviembre')
INSERT INTO #tm_tal_mes VALUES (12, 'Talonario Diciembre')

BEGIN TRANSACTION

--** Verifica si el documento esta registrado y habilitado
SET @va_est_ado = ''
SET @va_nom_doc = ''
SELECT @va_est_ado = va_est_ado,
       @va_nom_doc = va_nom_doc
  FROM ads003
 WHERE va_ide_doc = 'AJC'

IF (@@ROWCOUNT = 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 101: El Documento %s NO se encuentra registrado', 16, 1, @ar_ide_doc)	
	RETURN
END

IF (@va_est_ado = 'N')
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 102: El Documento %s se encuentra deshabilitado', 16, 1, @ar_ide_doc)
	RETURN
END

--** Verifica si la bandera Serie Anual esta habilitada
IF (@ar_tal_anu = 'S')
BEGIN
    --** Verifica si ya se encuentra registrado el Talonario 0
    SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(0)
	  FROM ads004
	 WHERE va_ide_doc = @ar_ide_doc
	   AND va_nro_tal = 0

	--** Si NO existe el registro, inserta un nuevo talonario
	IF (@va_nro_reg = 0)
	BEGIN
	    SET @va_nro_tal = 0
		SET @va_nom_tal = 'Talonario Anual'

		INSERT INTO ads004 VALUES (@ar_ide_doc, @va_nro_tal, @va_nom_tal, @va_tip_tal,
		                           @va_nro_aut, @va_for_mat, @va_nro_cop, @va_fir_ma1,
								   @va_fir_ma2, @va_fir_ma3, @va_fir_ma4, @va_for_log,
								   @va_obs_uno, @va_obs_dos, @va_est_tal)

		IF (@@ERROR > 0)
		BEGIN
			ROLLBACK TRANSACTION
			RAISERROR ('Error 103: Error al Insertar el Talonario 0 del Documento %s.', 16, 1, @ar_ide_doc)
			RETURN
		END
	END
END

--** Verifica si la bandera Serie Anual esta habilitada
IF (@ar_tal_mes = 'S')
BEGIN
	--** Obtiene la lista de Talonario a grabar
	DECLARE vc_tal_mes CURSOR LOCAL FOR
	 SELECT va_nro_tal, va_nom_tal
	   FROM #tm_tal_mes

	--** Abre cursor
	OPEN vc_tal_mes

	--** Lee primer registro
	FETCH NEXT FROM vc_tal_mes INTO @va_nro_tal, @va_nom_tal

	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		--** Verifica si ya se encuentra registrado el talonario
		SET @va_nro_reg = 0
		SELECT @va_nro_reg = COUNT(0)
		  FROM ads004
		 WHERE va_ide_doc = @ar_ide_doc
		   AND va_nro_tal = @va_nro_tal

		--** Si NO existe el registro, inserta un nuevo talonario
		IF (@va_nro_reg = 0)
		BEGIN
			INSERT INTO ads004 VALUES (@ar_ide_doc, @va_nro_tal, @va_nom_tal, @va_tip_tal,
									   @va_nro_aut, @va_for_mat, @va_nro_cop, @va_fir_ma1,
									   @va_fir_ma2, @va_fir_ma3, @va_fir_ma4, @va_for_log,
									   @va_obs_uno, @va_obs_dos, @va_est_tal)

			IF (@@ERROR > 0)
			BEGIN
				ROLLBACK TRANSACTION
				RAISERROR ('Error 104: Error al Insertar el Talonario %d del Documento %s.', 16, 1, @va_nro_tal, @ar_ide_doc)
				RETURN
			END
		END

		--** Lee el siguiente registro
		FETCH NEXT FROM vc_tal_mes INTO @va_nro_tal, @va_nom_tal
	END

	--** Cierre y destruya cursor
	CLOSE vc_tal_mes
	DEALLOCATE vc_tal_mes
END

COMMIT TRANSACTION
RETURN

