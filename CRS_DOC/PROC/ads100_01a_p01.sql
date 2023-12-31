/*****************************************************************/
/*	ARCHIVO: ads100_01a_p01.sql                                  */
/*	PROCEDIMIENTO: OBTIENE LA LICENCIA DEL SISTEMA               */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 29/11/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads100_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads100_01a_p01
GO

CREATE PROCEDURE ads100_01a_p01		WITH ENCRYPTION AS

DECLARE		@va_nom_ser  NVARCHAR(120), --** Nombre del Servidor
            @va_ser_nom  NVARCHAR(120), --** Nombre del Servidor
			@va_nom_bda  CHAR(80),      --** Nombre de la Base de Datos
			@va_bda_nom  CHAR(80),      --** Nombre de la Base de Datos
            @va_fec_act  DATETIME,      --** Fecha actual
			@va_fec_str  CHAR(10),      --** Fecha String
			@va_nro_usr  INT,           --** Nro. Usuario,
			@va_fch_exp  CHAR(08),      --** Fecha de Expiración Cifrada
			@va_fec_exp  CHAR(10),      --** Fecha de Expiración,
			@va_mod_act  INT,           --** Módulo Activado Cifrado
			@va_mod_ads  CHAR(01),      --** Módulo de Administrador
			@va_mod_inv  CHAR(01),      --** Módulo de Inventario
			@va_mod_cmr  CHAR(01),      --** Módulo de Comercializacion
			@va_mod_ctb  CHAR(01),      --** Módulo de Contabilidad
            @va_mod_tes  CHAR(01),      --** Módulo de Tesoreria
			@va_mod_res  CHAR(01)       --** Módulo de Restaurant

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Inicializa Variable
SET @va_nom_ser = ''
SET @va_ser_nom = ''
SET @va_bda_nom = ''
SET @va_nom_bda = ''
SET @va_nro_usr = 0
SET @va_fch_exp = ''
SET @va_fec_exp = ''
SET @va_mod_ads = 'N'
SET @va_mod_inv = 'N'
SET @va_mod_cmr = 'N'
SET @va_mod_ctb = 'N'
SET @va_mod_tes = 'N'
SET @va_mod_res = 'N'

--** Obtiene la fecha actual en formato dd/MM/yyyy
SET @va_fec_act = GETDATE()
SET @va_fec_str = CONVERT(CHAR(10), @va_fec_act, 103)

--** Obtiene el nombre del servidor
SELECT @va_nom_ser = @@SERVERNAME

--** Obtiene el nombre de la Base de Datos
SELECT @va_nom_bda = DB_NAME()

--** Obtiene el Nombre del Servidor Licenciado
SELECT @va_ser_nom = va_des_cri
  FROM ads100 
 WHERE va_ind_pri = 1 AND va_ind_sec = 1

--** Obtiene el Nombre de la Base de Datos Licenciado
SELECT @va_bda_nom = va_des_cri
  FROM ads100 
 WHERE va_ind_pri = 1 AND va_ind_sec = 2

IF (@va_nom_ser = @va_ser_nom AND 
    @va_nom_bda = @va_bda_nom)
BEGIN
	--** Obtiene el Nro. de Usuario Concurrente
	SELECT @va_nro_usr = CONVERT(INT, va_des_cri)
	  FROM ads100 
	 WHERE va_ind_pri = 1 AND va_ind_sec = 3

	IF (@va_nro_usr > 0)
		SET @va_nro_usr = @va_nro_usr / 1024

	--** Obtiene la fecha de Caducidad
	SELECT @va_fch_exp = va_des_cri
	  FROM ads100 
	 WHERE va_ind_pri = 1 AND va_ind_sec = 4

	IF (@va_fch_exp <> '')
	BEGIN
		SET @va_fec_exp = SUBSTRING(@va_fch_exp, 2, 1) +
						  SUBSTRING(@va_fch_exp, 4, 1) + '/' +
						  SUBSTRING(@va_fch_exp, 6, 1) +
						  SUBSTRING(@va_fch_exp, 8, 1) + '/' +
						  SUBSTRING(@va_fch_exp, 7, 1) +
						  SUBSTRING(@va_fch_exp, 5, 1) +
						  SUBSTRING(@va_fch_exp, 3, 1) +
						  SUBSTRING(@va_fch_exp, 1, 1)
	END

	--****************************************************
	--**         OBTIENE LAS LICENCIA POR MODULOS       **    
	--****************************************************
	--** Obtiene SI tiene licencia sobre el Modulo de Administrador
	SET @va_mod_act = 0
	SELECT @va_mod_act = CONVERT(INT, va_des_cri)
	  FROM ads100 
	 WHERE va_ind_pri = 2 AND va_ind_sec = 1

	IF (@@ROWCOUNT != 0 AND @va_mod_act = 1024)
		SET @va_mod_ads = 'S'
	ELSE
		SET @va_mod_ads = 'N'

	--** Obtiene SI tiene licencia sobre el Modulo de Inventario
	SET @va_mod_act = 0
	SELECT @va_mod_act = CONVERT(INT, va_des_cri)
	  FROM ads100 
	 WHERE va_ind_pri = 2 AND va_ind_sec = 2

	IF (@@ROWCOUNT != 0 AND @va_mod_act = 2048)
		SET @va_mod_inv = 'S'
	ELSE
		SET @va_mod_inv = 'N'

	--** Obtiene SI tiene licencia sobre el Modulo de Comercialización
	SET @va_mod_act = 0
	SELECT @va_mod_act = CONVERT(INT, va_des_cri)
	  FROM ads100 
	 WHERE va_ind_pri = 2 AND va_ind_sec = 3

	IF (@@ROWCOUNT != 0 AND @va_mod_act = 3072)
		SET @va_mod_cmr = 'S'
	ELSE
		SET @va_mod_cmr = 'N'

	--** Obtiene SI tiene licencia sobre el Modulo de Contabilidad
	SET @va_mod_act = 0
	SELECT @va_mod_act = CONVERT(INT, va_des_cri)
	  FROM ads100 
	 WHERE va_ind_pri = 2 AND va_ind_sec = 4

	IF (@@ROWCOUNT != 0 AND @va_mod_act = 4096)
		SET @va_mod_ctb = 'S'
	ELSE
		SET @va_mod_ctb = 'N'

	--** Obtiene SI tiene licencia sobre el Modulo de Tesoreria
	SET @va_mod_act = 0
	SELECT @va_mod_act = CONVERT(INT, va_des_cri)
	  FROM ads100 
	 WHERE va_ind_pri = 2 AND va_ind_sec = 5

	IF (@@ROWCOUNT != 0 AND @va_mod_act = 5120)
		SET @va_mod_tes = 'S'
	ELSE
		SET @va_mod_tes = 'N'

	--** Obtiene SI tiene licencia sobre el Modulo de Restaurant
	SET @va_mod_act = 0
	SELECT @va_mod_act = CONVERT(INT, va_des_cri)
	  FROM ads100 
	 WHERE va_ind_pri = 2 AND va_ind_sec = 6

	IF (@@ROWCOUNT != 0 AND @va_mod_act = 6144)
		SET @va_mod_res = 'S'
	ELSE
		SET @va_mod_res = 'N'
END

/* Devuelve Datos de la licencia */
SELECT @va_nom_ser AS va_nom_ser,
       @va_nom_bda AS va_nom_bda,
       @va_nro_usr AS va_nro_usr,
       @va_fec_exp AS va_fec_exp,
	   @va_mod_ads AS va_mod_ads,
	   @va_mod_inv AS va_mod_inv,
	   @va_mod_cmr AS va_mod_cmr,
	   @va_mod_ctb AS va_mod_ctb,
	   @va_mod_tes AS va_mod_tes,
	   @va_mod_res AS va_mod_res

GO