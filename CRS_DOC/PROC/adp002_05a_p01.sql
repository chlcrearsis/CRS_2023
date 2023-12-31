/***********************************************************************/
/*	ARCHIVO: adp002_05a_p01.sql                                        */
/*	PROCEDIMIENTO: CONSULTA PERSONA                                    */
/*      ARGUMENTO: @ar_cod_gru  INT         --** Código Grupo          */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 23/09/2021                   */
/***********************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp002_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.adp002_05a_p01
GO

CREATE PROCEDURE adp002_05a_p01		@ar_cod_per	 INT WITH ENCRYPTION AS

DECLARE     @va_cod_per  INT,	      --** Codigo Persona (2 de Grup. Per y 5 de Persona)
			@va_cod_gru	 INT,	      --** Cod Grupo Persona
			@va_nom_gru  VARCHAR(50), --** Nombre Grupo Persona
			@va_tip_per  CHAR(01),    --** Tipo de Cliente (P=Particular; E=Empresa)
			@va_nom_bre  VARCHAR(30), --** Nombre
			@va_ape_pat  VARCHAR(20), --** Apellido Paterno
			@va_ape_mat  VARCHAR(20), --** Apellido Materno
			@va_raz_soc	 VARCHAR(80), --** Razon Social
			@va_nom_fac	 VARCHAR(120), --** Nombre a Facturar
			@va_ruc_nit	 BIGINT,	  --** RUC/NIT
			@va_sex_per  CHAR(01),    --** Sexo (H=Hombre; M=Mujer)
			@va_fec_nac  DATETIME,    --** Fecha de Nacimiento
			@va_tip_doc  CHAR(02),    --** Tipo Documento
			@va_nro_doc	 BIGINT,	  --** Carnet de Identidad	
			@va_ext_doc  CHAR(02),    --** Extension Documento
			@va_tel_per	 VARCHAR(15), --** Telefono Personal
			@va_cel_ula	 VARCHAR(15), --** Telefono Celular
			@va_tel_fij	 VARCHAR(15), --** Telefono Fijo
			@va_dir_pri	 VARCHAR(80), --** Direccion Principal
			@va_dir_ent	 VARCHAR(80), --** Direccion de Entrega
			@va_ema_ail	 VARCHAR(30), --** Email
			@va_ubi_gps	 GEOGRAPHY,	  --** Ubicación Geografica
			@va_cod_ven	 INT,	      --** Código de Vendedor Asignado
			@va_nom_ven  VARCHAR(30), --** Nombre del Vendedor Asignado
			@va_cod_cob	 INT,	      --** Código de Cobrador Asignado	   	    	  	   		
			@va_nom_cob  VARCHAR(30), --** Nombre del Cobrador Asignado
			@va_est_ado	 CHAR(01),	  --** Estado(H=Habilitado; N=Deshabilitado)
			@va_ban_err  INT          --** Bandera Mensaje de Error (0=Sin Error; 1=Con Error)

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

SET @va_ban_err = 0

--** Obtiene los datos de la persona
SELECT @va_cod_per = va_cod_per, @va_cod_gru = va_cod_gru, 
       @va_tip_per = va_tip_per, @va_nom_bre = va_nom_bre,
	   @va_ape_pat = va_ape_pat, @va_ape_mat = va_ape_mat, 
	   @va_raz_soc = va_raz_soc, @va_ruc_nit = va_ruc_nit,
  	   @va_sex_per = va_sex_per, @va_fec_nac = va_fec_nac, 
	   @va_tip_doc = va_tip_doc, @va_nro_doc = va_nro_doc,
	   @va_ext_doc = va_ext_doc, @va_tel_per = va_tel_per, 
	   @va_cel_ula = va_cel_ula, @va_tel_fij = va_tel_fij, 
	   @va_dir_pri = va_dir_pri, @va_dir_ent = va_dir_ent, 
	   @va_ema_ail = va_ema_ail, @va_ubi_gps = va_ubi_gps, 
	   @va_cod_ven = va_cod_ven, @va_cod_cob = va_cod_cob, 
	   @va_est_ado = va_est_ado
  FROM adp002
 WHERE va_cod_per = @ar_cod_per

IF (@@ROWCOUNT = 0)
BEGIN
   SET @va_ban_err = 1
END

--** Obtiene nombre del Grupo
SELECT @va_nom_gru = va_nom_gru
  FROM adp001
 WHERE va_cod_gru = @va_cod_gru
	
IF (@@ROWCOUNT = 0)
	SET @va_nom_gru = ''

--** Obtiene el nombre a Facturar
SELECT @va_nom_fac = va_raz_soc
  FROM cmr013
 WHERE va_cod_per = @va_cod_per

IF (@@ROWCOUNT = 0)
	SET @va_nom_fac = ''

--** Obtiene el nombre del vendedor
SET @va_nom_ven = ''
SELECT @va_nom_ven = va_nom_bre
  FROM cmr014
 WHERE va_ide_tip = 1
   AND va_cod_ide = @va_cod_ven

--** Obtiene el nombre del cobrador
SET @va_nom_cob = ''
SELECT @va_nom_cob = va_nom_bre
  FROM cmr014
 WHERE va_ide_tip = 2
   AND va_cod_ide = @va_cod_cob

--** Devuelve los datos de la persona
IF (@va_ban_err = 0)
BEGIN
	SELECT @va_cod_per AS va_cod_per, @va_cod_gru AS va_cod_gru, 
		   @va_nom_gru AS va_nom_gru, @va_tip_per AS va_tip_per, 
		   @va_nom_bre AS va_nom_bre, @va_ape_pat AS va_ape_pat, 
		   @va_ape_mat AS va_ape_mat, @va_raz_soc AS va_raz_soc,
		   @va_nom_fac AS va_nom_fac, @va_ruc_nit AS va_ruc_nit, 
		   @va_sex_per AS va_sex_per, @va_fec_nac AS va_fec_nac, 
		   @va_tip_doc AS va_tip_doc, @va_nro_doc AS va_nro_doc, 
		   @va_ext_doc AS va_ext_doc, @va_tel_per AS va_tel_per, 
		   @va_cel_ula AS va_cel_ula, @va_tel_fij AS va_tel_fij, 
		   @va_dir_pri AS va_dir_pri, @va_dir_ent AS va_dir_ent, 
		   @va_ema_ail AS va_ema_ail, @va_ubi_gps AS va_ubi_gps, 
		   @va_cod_ven AS va_cod_ven, @va_nom_ven AS va_nom_ven, 
		   @va_cod_cob AS va_cod_cob, @va_nom_cob AS va_nom_cob, 
		   @va_est_ado AS va_est_ado
END