/*****************************************************************/
/*	ARCHIVO: ads018_01a_p01.sql                                  */
/*	PROCEDIMIENTO: BITACORA DE INICIO DE SESION                  */
/*  PARAMETROS:   @ag_ide_uni  CHAR(32)    --** Identificador    */
/*                @ag_ide_usr  CHAR(16)    --** ID. Usuario      */
/*                @ag_nom_maq  VARCHAR(30) --** Nombre Maquina   */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 10/01/2024             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads018_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads018_01a_p01
GO

CREATE PROCEDURE ads018_01a_p01		@ag_ide_uni  CHAR(32),
                                    @ag_ide_usr  CHAR(16),
									@ag_nom_maq  VARCHAR(30) 	WITH ENCRYPTION AS

DECLARE		@va_fec_ini  DATETIME,      --** Fecha y Hora de Ingreso
            @va_fec_fin  DATETIME,      --** Fecha y Hora de Salida
			@va_fec_reg  DATETIME,      --** Fecha de Registro Sin HH:mm:ss
			@va_fec_act  DATETIME,      --** Fecha Actual
			@va_fec_str  CHAR(10),      --** Fecha String
			@va_nro_reg  INT            --** Nro. Registro

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Obtiene la fecha actual en formato dd/MM/yyyy
SET @va_fec_act = GETDATE()
SET @va_fec_str = CONVERT(CHAR(10), @va_fec_act, 103)

--** Inicializa Variable
SET @va_fec_ini = GETDATE()
SET @va_fec_fin = NULL
SET @va_fec_reg = CONVERT(DATETIME,  @va_fec_str)

IF (@ag_ide_uni <> '')
BEGIN
	SELECT @va_nro_reg = COUNT(*) 
	  FROM ads018
	 WHERE va_ide_uni = @ag_ide_uni

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads018 VALUES (@ag_ide_uni, @ag_ide_usr, @va_fec_reg,
		                           @ag_nom_maq, @va_fec_ini, @va_fec_fin)
	END
END

GO