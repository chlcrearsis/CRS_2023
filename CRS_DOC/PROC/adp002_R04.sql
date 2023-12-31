/*****************************************************************/
/*	ARCHIVO: adp002_R04.sql                                      */
/*	PROCEDIMIENTO: INFORME REGISTRO PERSONA P/CRITERIOS Y RUTEO  */
/*  PARAMETROS:   @ar_gru_ini  INT       Grupo Inicial           */
/*                @ar_gru_fin  INT       Grupo Final             */
/*                @ar_ide_tip  INT       ID. Tipo Atributo       */
/*                @ar_atr_ini  INT       ID. Atributo Inicial    */
/*                @ar_atr_fin  INT       ID. Atributo Final      */
/*                @ar_rut_ini  INT       ID. Ruta Inicial        */
/*                @ar_rut_fin  INT       ID. Ruta Final          */
/*                @ar_est_ado  CHAR(01)  Estado                  */
/*                @ar_ord_dat  CHAR(02)  Orden Datos             */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 01/08/2022             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp002_R04') and sysstat & 0xf = 4)
	drop procedure dbo.adp002_R04
GO

CREATE PROCEDURE adp002_R04		@ar_gru_ini  INT,      @ar_gru_fin  INT,
								@ar_ide_tip  INT,      @ar_atr_ini  INT,
								@ar_atr_fin  INT,      @ar_rut_ini  INT, 
								@ar_rut_fin  INT,      @ar_est_ado  CHAR(01), 
								@ar_ord_dat  CHAR(01)  WITH ENCRYPTION AS

DECLARE			@va_cod_per	 INT,			--** Código Persona
                @va_raz_soc  VARCHAR(80),	--** Razon Social	
				@va_rut_per  VARCHAR(150),	--** Rutas Personas
				@va_ide_rut  INT,           --** ID. Ruta 
				@va_nom_cor  VARCHAR(15),   --** Nombre Corto Ruta
				@va_dir_pri  VARCHAR(120),  --** Dirección Principal
				@va_est_ado  VARCHAR(13),   --** Estado (H=Habilitado; N=Deshabilitado)
				@va_nro_reg  INT            --** Nro. de Registro

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Castea el estado si es T=Todos
IF (@ar_est_ado = 'T')
	SET @ar_est_ado = ''

--** Tabla temporal de codigo de persona
CREATE TABLE #tm_cod_per(
	va_cod_per  INT
)

CREATE TABLE #tm_reg_per
(
	va_cod_per	INT,
	va_raz_soc  VARCHAR(80),
	va_rut_per  VARCHAR(150),
	va_dir_pri  VARCHAR(120)
)

--** Obtiene la lista de clientes que cumplan el criterio
INSERT INTO #tm_cod_per 
SELECT va_cod_per
  FROM adp005
 WHERE (va_ide_tip = @ar_ide_tip
   AND va_ide_atr BETWEEN @ar_atr_ini AND @ar_atr_fin)


--** Obtiene el informe en el orden especificado
DECLARE vc_reg_per CURSOR LOCAL FOR
SELECT adp002.va_cod_per, adp002.va_raz_soc, adp002.va_dir_pri
  FROM adp002, #tm_cod_per
 WHERE adp002.va_cod_per = #tm_cod_per.va_cod_per
   AND adp002.va_est_ado LIKE '%' + RTRIM(@ar_est_ado)
   AND adp002.va_cod_gru BETWEEN @ar_gru_ini AND @ar_gru_fin

--** Abre Cursor
OPEN vc_reg_per
--** Lee el primer registro
FETCH NEXT FROM vc_reg_per INTO @va_cod_per, @va_raz_soc, @va_dir_pri														
WHILE (@@FETCH_STATUS = 0)
BEGIN	
	
	SET @va_rut_per = ''

	--** Lee las Rutas establecidas de la personas en el rango de parametros
	DECLARE vc_rut_per CURSOR LOCAL FOR
	SELECT va_ide_rut, va_nom_cor 
	  FROM adp007
	 WHERE va_ide_rut BETWEEN @ar_rut_ini AND @ar_rut_fin

	 --** Abre Cursor
	OPEN vc_rut_per
	--** Lee el primer registro
	FETCH NEXT FROM vc_rut_per INTO @va_ide_rut, @va_nom_cor
	WHILE (@@FETCH_STATUS = 0)
	BEGIN

		--** Verifica si la persona tiene esa ruta asignada
		SET @va_nro_reg = 0
		SELECT @va_nro_reg = COUNT(*) 
		  FROM adp008
		 WHERE va_cod_per = @va_cod_per
		   AND va_ide_rut = @va_ide_rut

		IF (@va_nro_reg > 0)
		BEGIN
			IF (RTRIM(@va_rut_per) = '')
				SET @va_rut_per = RTRIM(@va_nom_cor)
			ELSE
				SET @va_rut_per = RTRIM(@va_rut_per) + ' / ' + RTRIM(@va_nom_cor)
		END

		--** Lee el siguiente registro
		FETCH NEXT FROM vc_rut_per INTO @va_ide_rut, @va_nom_cor

	END	
	CLOSE vc_rut_per
	DEALLOCATE vc_rut_per
	
	--** Inserta en la tabla temporal
	INSERT INTO #tm_reg_per VALUES (@va_cod_per, @va_raz_soc, @va_rut_per, @va_dir_pri)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_reg_per INTO @va_cod_per, @va_raz_soc, @va_dir_pri	
END	

CLOSE vc_reg_per
DEALLOCATE vc_reg_per

--** Retorna los datos
SELECT va_cod_per, va_raz_soc, va_rut_per, 
	   va_dir_pri
  FROM #tm_reg_per
 ORDER BY 
  CASE WHEN @ar_ord_dat = 'C' THEN va_cod_per END ASC,
  CASE WHEN @ar_ord_dat = 'R' THEN va_raz_soc END ASC

