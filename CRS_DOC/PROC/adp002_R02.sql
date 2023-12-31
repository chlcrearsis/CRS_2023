/*****************************************************************/
/*	ARCHIVO: adp002_R02.sql                                      */
/*	PROCEDIMIENTO: INFORME REGISTRO PERSONA POR CRITERIO         */
/*  PARAMETROS:   @ar_gru_ini  INT       Grupo Inicial           */
/*                @ar_gru_fin  INT       Grupo Final             */
/*                @ar_ide_tip  INT       ID. Tipo Atributo       */
/*                @ar_atr_ini  INT       ID. Atributo Inicial    */
/*                @ar_atr_fin  INT       ID. Atributo Final      */
/*                @ar_est_ado  CHAR(01)  Estado                  */
/*                @ar_ord_dat  CHAR(02)  Orden Datos             */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 22/07/2022             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp002_R02') and sysstat & 0xf = 4)
	drop procedure dbo.adp002_R02
GO

CREATE PROCEDURE adp002_R02		@ar_gru_ini  INT,  @ar_gru_fin  INT,
								@ar_ide_tip  INT,  @ar_atr_ini  INT,
								@ar_atr_fin  INT,  @ar_est_ado  CHAR(01),
                                @ar_ord_dat  CHAR(01) WITH ENCRYPTION AS

DECLARE			@va_cod_per	 INT,			--** Código Persona
                @va_raz_soc  VARCHAR(80),	--** Razon Social
				@vx_nom_ape  VARCHAR(75),   --** Nombre y Apellido
				@va_ape_pat  VARCHAR(20),	--** Apellido Paterno
				@va_ape_mat  VARCHAR(20),   --** Apellido Materno
                @va_nom_bre  VARCHAR(30),   --** Nombre
				@vx_tel_cel  VARCHAR(35),   --** Telefonos Personal - Celular
				@va_tel_per  VARCHAR(15),   --** Telefono Personal
				@va_cel_ula  VARCHAR(15),   --** Telefono Celular
				@va_dir_pri  VARCHAR(120),  --** Dirección Principal
				@va_est_ado  VARCHAR(13)    --** Estado (H=Habilitado; N=Deshabilitado)


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
	va_nom_ape  VARCHAR(75),
	va_tel_cel  VARCHAR(35),
	va_dir_pri  VARCHAR(120),
	va_est_ado  VARCHAR(15)
)

--** Obtiene la lista de clientes que cumplan los parametros
INSERT INTO #tm_cod_per 
SELECT va_cod_per
  FROM adp005
 WHERE va_ide_tip = @ar_ide_tip
   AND va_ide_atr BETWEEN @ar_atr_ini AND @ar_atr_fin

--** Obtiene el informe en el orden especificado
DECLARE vc_reg_per CURSOR LOCAL FOR
SELECT adp002.va_cod_per, adp002.va_raz_soc, adp002.va_ape_pat, 
       adp002.va_ape_mat, adp002.va_nom_bre, adp002.va_tel_per, 
	   adp002.va_cel_ula, adp002.va_dir_pri,
	   CASE WHEN adp002.va_est_ado = 'H'
		    THEN 'Habilitado' 
		    ELSE 'Deshabilitado' 
	   END AS va_est_ado
  FROM adp002, #tm_cod_per
 WHERE adp002.va_cod_per = #tm_cod_per.va_cod_per
   AND adp002.va_est_ado LIKE '%' + RTRIM(@ar_est_ado)
   AND adp002.va_cod_gru BETWEEN @ar_gru_ini AND @ar_gru_fin

--** Abre Cursor
OPEN vc_reg_per
--** Lee el primer registro
FETCH NEXT FROM vc_reg_per INTO @va_cod_per, @va_raz_soc, @va_ape_pat, @va_ape_mat,
                                @va_nom_bre, @va_tel_per, @va_cel_ula, @va_dir_pri,
								@va_est_ado														
WHILE (@@FETCH_STATUS = 0)
BEGIN	

	--** Verifica el campo Apellido Paterno
	IF (RTRIM(@va_ape_pat) = '.' OR RTRIM(@va_ape_pat) = ',' OR 
	    RTRIM(@va_ape_pat) = '-' OR RTRIM(@va_ape_pat) = '*')
		SET @va_ape_pat = ''

    --** Verifica el campo Apellido Materno
	IF (RTRIM(@va_ape_mat) = '.' OR RTRIM(@va_ape_mat) = ',' OR 
	    RTRIM(@va_ape_mat) = '-' OR RTRIM(@va_ape_mat) = '*')
		SET @va_ape_mat = ''	

	--** Verifica el campo Nombre
	IF (RTRIM(@va_nom_bre) = '.' OR RTRIM(@va_nom_bre) = ',' OR 
	    RTRIM(@va_nom_bre) = '-' OR RTRIM(@va_nom_bre) = '*')
		SET @va_nom_bre = ''

	--** Verifica el Telefono Personal
	IF (RTRIM(@va_tel_per) = '' OR RTRIM(@va_tel_per) = '-' OR 
	    RTRIM(@va_tel_per) = '00' OR RTRIM(@va_tel_per) = '0')
		SET @va_tel_per = ''

	--** Verifica el Telefono Celular
	IF (RTRIM(@va_cel_ula) = '' OR RTRIM(@va_cel_ula) = '-' OR 
	    RTRIM(@va_cel_ula) = '00' OR RTRIM(@va_cel_ula) = '0')
		SET @va_cel_ula = ''

	--** Verifica el Telefono Celular
	IF (RTRIM(@va_dir_pri) = '.' OR RTRIM(@va_dir_pri) = '' OR 
	    RTRIM(@va_dir_pri) = '0' OR RTRIM(@va_dir_pri) = '*')
		SET @va_dir_pri = 'S/N'

	--** Concatena Apellidos y Nombre
	SET @vx_nom_ape = ''
	IF (RTRIM(@va_ape_pat) <> '')
		SET @vx_nom_ape = RTRIM(@va_ape_pat)

	IF (RTRIM(@va_ape_mat) <> '')	
	BEGIN
		IF (@vx_nom_ape <> '')		
			SET @vx_nom_ape = RTRIM(@vx_nom_ape) + ' ' + RTRIM(@va_ape_mat)
		ELSE
			SET @vx_nom_ape = RTRIM(@va_ape_mat)
	END

	IF (RTRIM(@va_nom_bre) <> '')	
		SET @vx_nom_ape = RTRIM(@vx_nom_ape) + ', ' + RTRIM(@va_nom_bre)
		
	--** Concatena Telefonos
	SET  @vx_tel_cel = ''
	IF (RTRIM(@va_tel_per) <> '')
		SET @vx_tel_cel = RTRIM(@va_tel_per)

	IF (RTRIM(@va_cel_ula) <> '')	
	BEGIN
		IF (@vx_tel_cel <> '')		
			SET @vx_tel_cel = RTRIM(@vx_tel_cel) + ' - ' + RTRIM(@va_cel_ula)
		ELSE
			SET @vx_tel_cel = RTRIM(@va_cel_ula)
	END

	--** Inserta en la tabla temporal
	INSERT INTO #tm_reg_per VALUES (@va_cod_per, @va_raz_soc, @vx_nom_ape, 
	                                @vx_tel_cel, @va_dir_pri, @va_est_ado)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_reg_per INTO @va_cod_per, @va_raz_soc, @va_ape_pat, @va_ape_mat,
                                    @va_nom_bre, @va_tel_per, @va_cel_ula, @va_dir_pri,
								    @va_est_ado	
END	

CLOSE vc_reg_per
DEALLOCATE vc_reg_per

--** Retorna los datos
SELECT va_cod_per, va_raz_soc, va_nom_ape, 
	   va_tel_cel, va_dir_pri, va_est_ado
  FROM #tm_reg_per
 ORDER BY 
  CASE WHEN @ar_ord_dat = 'C' THEN va_cod_per END ASC,
  CASE WHEN @ar_ord_dat = 'R' THEN va_raz_soc END ASC

