/**********************************************************************/
/*	ARCHIVO: ads018_R01.sql                                           */
/*	PROCEDIMIENTO: INFORME BITACORA DE INICIO DE SESION               */
/*  PARAMETROS:   @ar_usr_ini  VARCHAR(15)  --** ID. Usuario Inicial  */
/*                @ar_usr_fin  VARCHAR(15)  --** ID. Usuario Final    */
/*                @ar_fec_ini  DATETIME     --** Fecha Inicial        */
/*                @ar_fec_fin  DATETIME     --** Fecha Final          */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 10/01/2024                  */
/**********************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads018_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads018_R01
GO

CREATE PROCEDURE ads018_R01		@ar_usr_ini  VARCHAR(15),
                                @ar_usr_fin  VARCHAR(15),
								@ar_fec_ini  DATETIME,
								@ar_fec_fin  DATETIME	WITH ENCRYPTION AS

DECLARE		@va_ide_usr  VARCHAR(30),	--** ID. Usuario
            @va_nom_usr	 VARCHAR(30),	--** Nombre Usuario
			@va_ide_tus  INT,           --** ID. Tipo Usuario
			@va_nom_tus	 VARCHAR(30),   --** Nombre Tipo de Usuario
			@va_nom_maq  VARCHAR(30),   --** Nombre Maquina
			@va_dia_sem  VARCHAR(09),   --** Dia de la Semana
			@va_fec_reg	 DATETIME,      --** Fecha de Registro			
			@va_fec_ini	 DATETIME,	    --** Hora Inicial
			@va_fec_fin	 DATETIME,	    --** Hora Final
			@vx_fec_reg	 CHAR(22),      --** Fecha de Registro
			@va_hor_ini	 CHAR(08),	    --** Hora Inicial
			@va_hor_fin	 CHAR(08),	    --** Hora Final
			@va_dif_tie  CHAR(08),      --** Diferencia de Tiempo
			@va_nro_reg  INT            --** Nro. de Registro
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Establece el Formato del Lenaguaje Español
SET DATEFORMAT DMY

--** Crea tabla temporal
CREATE TABLE #tm_ini_ses
(
	va_ide_usr  VARCHAR(30),
    va_nom_usr	VARCHAR(30),
	va_nom_tus	VARCHAR(30),
	va_nom_maq  VARCHAR(30),
	va_fec_reg  VARCHAR(21),
	va_hor_ini	CHAR(08),
	va_hor_fin  CHAR(08),
	va_dif_tie  CHAR(08)
)

--** Obtiene los datos de los inicio de sesion
DECLARE vc_ini_ses CURSOR LOCAL FOR
 SELECT va_ide_usr, va_fec_reg, va_nom_maq, 
        va_fec_ini, va_fec_fin
   FROM ads018
  WHERE va_ide_usr BETWEEN @ar_usr_ini AND @ar_usr_fin
    AND va_fec_reg BETWEEN @ar_fec_ini AND @ar_fec_fin

--** Abre Cursor
OPEN vc_ini_ses
--** Lee el primer registro
FETCH NEXT FROM vc_ini_ses INTO @va_ide_usr, @va_fec_reg, @va_nom_maq, 
                                @va_fec_ini, @va_fec_fin
														
WHILE (@@FETCH_STATUS = 0)
BEGIN
    --** Obtiene el nombre del Usuario
	SELECT @va_nom_usr = va_nom_usr,
	       @va_ide_tus = va_ide_tus
	  FROM ads007
	 WHERE va_ide_usr = @va_ide_usr

	 IF (@@ROWCOUNT = 0)
	 BEGIN
		SET @va_nom_usr = ''
		SET @va_ide_tus = 0
	 END

	--** Obtiene el nombre Tipo de Usuario
	SELECT @va_nom_tus = va_nom_tus
	  FROM ads006
	 WHERE va_ide_tus = @va_ide_tus

	IF (@@ROWCOUNT = 0)
		SET @va_nom_tus = ''

	--** Obtiene el dia de la semana
	SET @va_nro_reg = DATEPART(wk, @va_fec_reg)

	SET @va_dia_sem = 
		CASE @va_nro_reg
			WHEN 1 THEN 'Lunes'
			WHEN 2 THEN 'Martes'
			WHEN 3 THEN 'Miercoles'
			WHEN 4 THEN 'Jueves'
			WHEN 5 THEN 'Viernes'
			WHEN 6 THEN 'Sábado'
			WHEN 7 THEN 'Domingo'
		END


	--** Castea la fecha de registro
	IF (@va_fec_reg IS NULL)
		SET @vx_fec_reg = ''
	ELSE
		SET @vx_fec_reg = @va_dia_sem + '  ' + CONVERT(CHAR(10), @va_fec_reg, 103)

	--** Obtiene la hora inicial
	IF (@va_fec_ini IS NULL)
		SET @va_hor_ini = ''
	ELSE
		SET @va_hor_ini = CONVERT(CHAR(08), @va_fec_ini, 108)

	--** Obtiene la hora final
	IF (@va_fec_fin IS NULL)
		SET @va_hor_fin = ''
	ELSE
		SET @va_hor_fin = CONVERT(CHAR(08), @va_fec_fin, 108)

	--** Obtiene la diferencia de Horas 
	IF (RTRIM(@va_hor_fin) <> '')
		SET @va_dif_tie = CONVERT(CHAR(08), CAST(@va_fec_fin-@va_fec_ini AS TIME));
	ELSE
		SET @va_dif_tie = '';

	--** Inserta en la tabla temporal
	INSERT INTO #tm_ini_ses VALUES (@va_ide_usr, @va_nom_usr, @va_nom_tus,
	                                @va_nom_maq, @vx_fec_reg, @va_hor_ini, 
									@va_hor_fin, @va_dif_tie)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_ini_ses INTO @va_ide_usr, @va_fec_reg, @va_nom_maq, 
                                    @va_fec_ini, @va_fec_fin
END

CLOSE vc_ini_ses
DEALLOCATE vc_ini_ses

--** Retorna los datos
SELECT va_ide_usr, va_nom_usr, va_nom_tus,
       va_nom_maq, va_fec_reg, va_hor_ini, 
	   va_hor_fin, va_dif_tie
  FROM #tm_ini_ses
 ORDER BY va_ide_usr, va_fec_reg, va_hor_ini
