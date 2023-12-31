/*****************************************************************/
/*	ARCHIVO: adp009_R01.sql                                      */
/*	PROCEDIMIENTO: INFORME LISTA DE PRECIO ASIG. A LA PERSONA    */
/*  PARAMETROS:   @ar_cod_per  INT  Código Persona               */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 08/08/2022             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp009_R01') and sysstat & 0xf = 4)
	drop procedure dbo.adp009_R01
GO

CREATE PROCEDURE adp009_R01			@ar_cod_per  INT	--** Código de Persona
									WITH ENCRYPTION AS

DECLARE		@va_nro_reg  INT,		   --** Nro de Registro
            @va_cod_lis	 INT,	       --** Codigo del la lista
			@va_nom_lis	 VARCHAR(30),  --** Nombre
			@va_mon_lis	 CHAR(01),	   --** Moneda (B=Bolivianos; D=Dolares)
			@vx_mon_lis  VARCHAR(15),  --** Moneda (Bolivianos; Dolares)
			@va_fec_ini	 DATE,	       --** Fecha inicio
			@vx_fec_ini	 CHAR(10),	   --** Fecha inicio String
			@va_fec_fin	 DATE,	       --** Fecha final
			@vx_fec_fin	 CHAR(10),	   --** Fecha Final String
			@va_per_mis  CHAR(01),     --** Permiso (S=Si; N=No)
			@va_est_lis  CHAR(01),     --** Estado de Lista (H=Habilitado; N=Deshabiliotado)
			@vx_est_lis  VARCHAR(15)   --** Nombre Estado de Lista

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_lis_asi
(
	va_cod_lis	INT,
	va_nom_lis	VARCHAR(30),
	va_mon_lis	CHAR(15),
	va_fec_ini	CHAR(10),
	va_fec_fin	CHAR(10),
	va_est_lis  VARCHAR(15)
)

--** Obtiene la lista de precio asignada al usuario
DECLARE vc_lis_pre CURSOR LOCAL FOR
SELECT va_cod_lis
  FROM adp009
 WHERE va_cod_per = @ar_cod_per

--** Abre cursor
OPEN vc_lis_pre

--** Lee primer registro
FETCH NEXT FROM vc_lis_pre INTO @va_cod_lis

WHILE (@@FETCH_STATUS = 0)
BEGIN	

	--** Obtiene datos de la lista de precio
	SELECT @va_nom_lis = va_nom_lis, 
	       @va_mon_lis = va_mon_lis,
           @va_fec_ini = va_fec_ini, 
		   @va_fec_fin = va_fec_fin,
		   @va_est_lis = va_est_ado
	  FROM cmr001
	 WHERE va_cod_lis = @va_cod_lis

	 IF (@va_est_lis = 'H')
	 BEGIN
		--** Caste la moneda de la lista
		IF (@va_mon_lis = 'B')
			SET @vx_mon_lis = 'Bolivianos'
		IF (@va_mon_lis = 'U')
			SET @vx_mon_lis = 'Dolares'

		IF (@va_est_lis = 'H')
			SET @vx_est_lis = 'Habilitado'
		IF (@va_est_lis = 'N')
			SET @vx_est_lis = 'Deshabilitado'

		--** Caste las fecha inicial y final
		SET @vx_fec_ini = CONVERT(CHAR(10), @va_fec_ini, 103)
		SET @vx_fec_fin = CONVERT(CHAR(10), @va_fec_fin, 103)

		--** Graba el atributo de persona
		INSERT INTO #tm_lis_asi VALUES (@va_cod_lis, @va_nom_lis, @vx_mon_lis,
										@vx_fec_ini, @vx_fec_fin, @vx_est_lis)
	END

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_lis_pre INTO @va_cod_lis 
END

--** Cierre y destruya cursor
CLOSE vc_lis_pre
DEALLOCATE vc_lis_pre

--** Devuelve datos
SELECT va_cod_lis, va_nom_lis, va_mon_lis,
	   va_fec_ini, va_fec_fin, va_est_lis
  FROM #tm_lis_asi


