/**********************************************************************/
/*	ARCHIVO: ads019_R01.sql                                           */
/*	PROCEDIMIENTO: INFORME BITACORA DE OPERACIÓN P/RANGO DE FECHA     */
/*  PARAMETROS:   @ar_usr_ini  VARCHAR(15)  --** ID. Usuario Inicial  */
/*                @ar_usr_fin  VARCHAR(15)  --** ID. Usuario Final    */
/*                @ar_fec_ini  DATETIME     --** Fecha Inicial        */
/*                @ar_fec_fin  DATETIME     --** Fecha Final          */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 10/01/2024                  */
/**********************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads019_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads019_R01
GO

CREATE PROCEDURE ads019_R01		@ar_ide_mod  INT,
                                @ar_apl_ini  VARCHAR(12),
                                @ar_apl_fin  VARCHAR(12),
								@ar_fec_ini  DATETIME,
								@ar_fec_fin  DATETIME,
								@ar_tip_ope  CHAR(01)	WITH ENCRYPTION AS

DECLARE		@va_ide_usr  VARCHAR(30),	--** ID. Usuario
            @va_nom_usr	 VARCHAR(30),	--** Nombre Usuario
			@va_fch_reg	 DATETIME,      --** Fecha de Registro
			@va_ide_mod  INT,           --** ID. Módulo
			@va_nom_mod	 VARCHAR(36),   --** Nombre Módulo
			@va_ide_apl  VARCHAR(12),   --** ID. Aplicación
	        @va_nom_apl  VARCHAR(60),   --** Nombre Aplicacion
			@va_tip_ope  CHAR(01),      --** Tipo de Operacion
	        @vx_tip_ope  VARCHAR(12),   --** Tipo de Operacion Casteado
	        @va_obs_reg  VARCHAR(120),  --** Observación
	        @va_nom_maq  VARCHAR(30)    --** Nombre Maquina
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Establece el Formato del Lenaguaje Español
SET DATEFORMAT DMY

--** Crea tabla temporal
CREATE TABLE #tm_bit_ope
(
    va_ide_usr 	VARCHAR(15),
	va_nom_usr	VARCHAR(30),
	va_fch_reg  DATETIME,
	va_ide_mod  INT,
    va_nom_mod	VARCHAR(36),
	va_ide_apl  VARCHAR(12),
	va_nom_apl  VARCHAR(60),
	va_tip_ope  VARCHAR(12),
	va_obs_reg  VARCHAR(120),
	va_nom_maq  VARCHAR(30)
)

--** Castea el tipo de operación
IF (@ar_tip_ope = 'T')
	SET @ar_tip_ope = '%'

--** Obtiene los datos de la bitacora
DECLARE vc_bit_ope CURSOR LOCAL FOR
 SELECT va_ide_usr, va_fch_reg, va_ide_mod, 
        va_ide_apl, va_nom_apl, va_tip_ope,
		va_obs_reg, va_nom_maq
   FROM ads019
  WHERE va_ide_mod = @ar_ide_mod
    AND va_ide_apl BETWEEN @ar_apl_ini AND @ar_apl_fin
    AND va_fch_reg BETWEEN @ar_fec_ini AND @ar_fec_fin
	AND va_tip_ope LIKE @ar_tip_ope

--** Abre Cursor
OPEN vc_bit_ope
--** Lee el primer registro
FETCH NEXT FROM vc_bit_ope INTO @va_ide_usr, @va_fch_reg, @va_ide_mod, 
                                @va_ide_apl, @va_nom_apl, @va_tip_ope,
								@va_obs_reg, @va_nom_maq
														
WHILE (@@FETCH_STATUS = 0)
BEGIN
    --** Obtiene el nombre del Usuario
	SELECT @va_nom_usr = va_nom_usr
	  FROM ads007
	 WHERE va_ide_usr = @va_ide_usr

	 IF (@@ROWCOUNT = 0)
		SET @va_nom_usr = ''

	--** Obtiene el nombre del módulo
	SELECT @va_nom_mod = va_abr_mod + ' - ' + va_nom_mod
	  FROM ads001
	 WHERE va_ide_mod = @va_ide_mod

	 IF (@@ROWCOUNT = 0)
		SET @va_nom_mod = ''

	--** Castea el tipo de Operación
	SET @vx_tip_ope = 
		CASE @va_tip_ope
			WHEN 'N' THEN 'Nuevo'
			WHEN 'E' THEN 'Edita'
			WHEN 'A' THEN 'Anula'
			WHEN 'C' THEN 'Concluye'
			WHEN 'L' THEN 'Elimina'
			WHEN 'P' THEN 'Aprueba'
			WHEN 'R' THEN 'Rechaza'
			WHEN 'M' THEN 'Importa'
			WHEN 'X' THEN 'Exporta'
			WHEN 'I' THEN 'Informe'
		END


	--** Inserta en la tabla temporal
	INSERT INTO #tm_bit_ope VALUES (@va_ide_usr, @va_nom_usr, @va_fch_reg, @va_ide_mod, 
                                    @va_nom_mod, @va_ide_apl, @va_nom_apl, @vx_tip_ope,
								    @va_obs_reg, @va_nom_maq)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_bit_ope INTO @va_ide_usr, @va_fch_reg, @va_ide_mod, 
                                    @va_ide_apl, @va_nom_apl, @va_tip_ope,
								    @va_obs_reg, @va_nom_maq
END

CLOSE vc_bit_ope
DEALLOCATE vc_bit_ope

--** Retorna los datos
SELECT va_ide_usr, va_nom_usr, va_fch_reg, va_ide_mod, 
       va_nom_mod, va_ide_apl, va_nom_apl, va_tip_ope,
	   va_obs_reg, va_nom_maq
  FROM #tm_bit_ope
 ORDER BY va_ide_usr, va_fch_reg
