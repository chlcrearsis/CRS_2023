/*****************************************************************/
/*	ARCHIVO: ads100_02a_p01.sql                                  */
/*	PROCEDIMIENTO: GRABA LICENCIA DEL SISTEMA                    */
/*  PARAMETROS:   @ag_nro_usr  INT       Nro. de Usuario         */
/*                @ag_fec_exp  CHAR(10)  Fecha de Expiración     */
/*                @ag_mod_ads  CHAR(01)  Modulo Administración   */
/*                @ag_mod_inv  CHAR(01)  Modulo Inventario       */
/*                @ag_mod_cmr  CHAR(01)  Modulo Comercializacion */
/*                @ag_mod_ctb  CHAR(01)  Modulo Contabilidad     */
/*                @ag_mod_tes  CHAR(01)  Modulo Tesoreria        */
/*                @ag_mod_res  CHAR(01)  Modulo Restaurant       */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 28/11/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads100_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads100_02a_p01
GO

CREATE PROCEDURE ads100_02a_p01		@ag_nro_usr	 INT,
                                    @ag_fec_exp  CHAR(10),
									@ag_mod_ads  CHAR(01),
									@ag_mod_inv  CHAR(01),
									@ag_mod_cmr  CHAR(01),
									@ag_mod_ctb  CHAR(01),
									@ag_mod_tes  CHAR(01),
									@ag_mod_res  CHAR(01)  WITH ENCRYPTION AS

DECLARE		@va_nom_ser  NVARCHAR(120), --** Nombre del Servidor
			@va_nom_bda  CHAR(80),      --** Nombre de la Base de Datos
			@va_nro_usr  INT,           --** Nro. Usuario
			@va_fec_exp  CHAR(08),      --** Fecha de Expiración		
			@va_nro_reg  INT            --** Nro de Registro

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Inicializa Variable
SET @va_nom_ser = ''
SET @va_nom_bda = ''
SET @va_nro_usr = 0
SET @va_fec_exp = ''

--** Obtiene el nombre del servidor
SELECT @va_nom_ser = @@SERVERNAME

--** Inserta en la Global el nombre del servidor
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*)
  FROM ads100 
 WHERE va_ind_pri = 1 
   AND va_ind_sec = 1

IF (@va_nro_reg = 0)
BEGIN	
	INSERT INTO ads100 VALUES (1, 1, 'Jj5QluOusIYVPYTdM2hbtdDTsl6ZrT', @va_nom_ser)
END
ELSE
BEGIN
	UPDATE ads100 SET va_des_cri = @va_nom_ser	                  
				WHERE va_ind_pri = 1 
                  AND va_ind_sec = 1
END

--** Obtiene el nombre de la Base de Datos
SELECT @va_nom_bda = DB_NAME()

--** Inserta en la Global el nombre de la Base de Datos
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*)
  FROM ads100 
 WHERE va_ind_pri = 1 
   AND va_ind_sec = 2

IF (@va_nro_reg = 0)
BEGIN	
	INSERT INTO ads100 VALUES (1, 2, 'A2wahsDvtOhDcSjGyIQ1sTPiVKpOsk', @va_nom_bda)
END
ELSE
BEGIN
	UPDATE ads100 SET va_des_cri = @va_nom_bda					  
				WHERE va_ind_pri = 1 
                  AND va_ind_sec = 2
END

--** Inserta el Nro de usuario concurrentes
IF (@ag_nro_usr > 0)
BEGIN
	SET @va_nro_usr = @ag_nro_usr * 1024

	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads100 
	 WHERE va_ind_pri = 1 
       AND va_ind_sec = 3

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads100 VALUES (1, 3, 'GbBoIdvOUtsNKGqLXoySdeOSBo4dUj', RTRIM(CONVERT(CHAR(10), @va_nro_usr)))
	END
	ELSE
	BEGIN
		UPDATE ads100 SET va_des_cri = RTRIM(CONVERT(CHAR(10), @va_nro_usr))
					WHERE va_ind_pri = 1 
                      AND va_ind_sec = 3
	END
END

--** Inserta la fecha de expiración de la licencia

IF (@ag_fec_exp <> '')
BEGIN
	SET @va_fec_exp = SUBSTRING(@ag_fec_exp, 10, 1) +
					  SUBSTRING(@ag_fec_exp, 1, 1) + 
					  SUBSTRING(@ag_fec_exp, 9, 1) +
					  SUBSTRING(@ag_fec_exp, 2, 1) + 
					  SUBSTRING(@ag_fec_exp, 8, 1) +
					  SUBSTRING(@ag_fec_exp, 4, 1) +
					  SUBSTRING(@ag_fec_exp, 7, 1) +
					  SUBSTRING(@ag_fec_exp, 5, 1)

	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads100 
	 WHERE va_ind_pri = 1 
       AND va_ind_sec = 4

	IF (@va_nro_reg = 0)
	BEGIN		
		INSERT INTO ads100 VALUES (1, 4, 'KXJfyoHpaqpaISNIgfKH2Zze73vZ3B', @va_fec_exp)
	END
	ELSE
	BEGIN
		UPDATE ads100 SET va_des_cri = @va_fec_exp						  
					WHERE va_ind_pri = 1 
                      AND va_ind_sec = 4
	END					  
END

--***************************************************
--**       INSERTA LAS LICENCIAS POR MODULOS       **
--***************************************************

--** Verifica e Inserta el Modulo de Administrador
IF (@ag_mod_ads = 'S')
BEGIN
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads100 
	 WHERE va_ind_pri = 2 --** Módulos
       AND va_ind_sec = 1 --** ADS=Administrador

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads100 VALUES (2, 1, 'SWaNCj6X3WDAW2rEdEU2XHASc3hAdS', '1024')
	END
	ELSE
	BEGIN
		UPDATE ads100 SET va_des_cri = '1024'
					WHERE va_ind_pri = 2 AND va_ind_sec = 1
	END	
END
ELSE
BEGIN
	UPDATE ads100 SET va_des_cri = '0'
			    WHERE va_ind_pri = 2 AND va_ind_sec = 1
END

--** Verifica e Inserta el Modulo de Inventario
IF (@ag_mod_inv = 'S')
BEGIN
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads100 
	 WHERE va_ind_pri = 2 --** Módulos
       AND va_ind_sec = 2 --** INV=Inventario

	IF (@va_nro_reg = 0)
	BEGIN		
		INSERT INTO ads100 VALUES (2, 2, 'Dcbmm8iBaurRjF6eHsJkijLlR9VInV', '2048')
	END
	ELSE
	BEGIN
		UPDATE ads100 SET va_des_cri = '2048'
					WHERE va_ind_pri = 2 AND va_ind_sec = 2
	END	
END
ELSE
BEGIN
	UPDATE ads100 SET va_des_cri = '0'
					WHERE va_ind_pri = 2 AND va_ind_sec = 2
END


--** Verifica e Inserta el Modulo de Comercialización
IF (@ag_mod_cmr = 'S')
BEGIN
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads100 
	 WHERE va_ind_pri = 2 --** Módulos
       AND va_ind_sec = 3 --** CRM=Comercializacion

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads100 VALUES (2, 3, 'KeHthL6b4J525tP1qiq8wgvgzpfCmR', '3072')
	END
	ELSE
	BEGIN
		UPDATE ads100 SET va_des_cri = '3072'
					WHERE va_ind_pri = 2 AND va_ind_sec = 3
	END	
END
ELSE
BEGIN
	UPDATE ads100 SET va_des_cri = '0'
			    WHERE va_ind_pri = 2 AND va_ind_sec = 3
END

--** Verifica e Inserta el Modulo de Contabilidad
IF (@ag_mod_ctb = 'S')
BEGIN
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads100 
	 WHERE va_ind_pri = 2 --** Módulos
       AND va_ind_sec = 4 --** CTB=Contabilidad

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads100 VALUES (2, 4, 'LO2FoI0phSd7597DTLm5fX9BHOACtB', '4096')
	END
	ELSE
	BEGIN
		UPDATE ads100 SET va_des_cri = '4096'
			    WHERE va_ind_pri = 2 AND va_ind_sec = 4
	END	
END
ELSE
BEGIN
	UPDATE ads100 SET va_des_cri = '0'
			    WHERE va_ind_pri = 2 AND va_ind_sec = 4
END

--** Verifica e Inserta el Modulo de Tesoreria
IF (@ag_mod_tes = 'S')
BEGIN
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads100 
	 WHERE va_ind_pri = 2 --** Módulos
       AND va_ind_sec = 5 --** TES=Tesoreria

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads100 VALUES (2, 5, 'SUjBKrqFbYt8CZQWaXNbIATFatpTeS', '5120')
	END
	ELSE
	BEGIN
		UPDATE ads100 SET va_des_cri = '5120'
			        WHERE va_ind_pri = 2 AND va_ind_sec = 5
	END	
END
ELSE
BEGIN
	UPDATE ads100 SET va_des_cri = '0'
			    WHERE va_ind_pri = 2 AND va_ind_sec = 5
END


--** Verifica e Inserta el Modulo de Restaurant
IF (@ag_mod_res = 'S')
BEGIN
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads100 
	 WHERE va_ind_pri = 2 --** Módulos
       AND va_ind_sec = 6 --** RES=Restaurant

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads100 VALUES (2, 6, 'TNarguMK1Yc9twZNSs1+E6YKDTwReS', '6144') 
	END
	ELSE
	BEGIN
		UPDATE ads100 SET va_des_cri = '6144'
			        WHERE va_ind_pri = 2 AND va_ind_sec = 6
	END	
END
ELSE
BEGIN
	UPDATE ads100 SET va_des_cri = '0'
			        WHERE va_ind_pri = 2 AND va_ind_sec = 6
END

RETURN

GO