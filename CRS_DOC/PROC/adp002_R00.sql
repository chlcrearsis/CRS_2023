/*****************************************************************/
/*	ARCHIVO: adp002_R00.sql                                      */
/*	PROCEDIMIENTO: INFORME FICHA REGISTRO CLIENTE                */
/*  PARAMETROS:   @ar_cod_per  INT       ID. Persona             */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 08/08/2022             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp002_R00') and sysstat & 0xf = 4)
	drop procedure dbo.adp002_R00
GO

CREATE PROCEDURE adp002_R00		@ar_cod_per  INT  WITH ENCRYPTION AS

DECLARE			@va_cod_per	 INT,			--** Código Persona
				@va_cod_gru	 INT,	        --** Cod Grupo Persona
				@vx_nom_gru  VARCHAR(50),   --** Nombre Grupo Persona
				@va_tip_per  CHAR(01),      --** Tipo de Cliente (P=Particular; E=Empresa)
				@vx_tip_per  VARCHAR(15),   --** Nombre Tipo de Persona
				@va_nom_bre  VARCHAR(30),   --** Nombre
				@va_ape_pat  VARCHAR(20),   --** Apellido Paterno
				@va_ape_mat  VARCHAR(20),   --** Apellido Materno
				@va_raz_soc	 VARCHAR(80),	--** Razon Social
				@va_nom_fac  VARCHAR(120),  --** Nombre a Facturar
				@va_ruc_nit	 BIGINT,	    --** RUC/NIT
				@va_sex_per  CHAR(01),      --** Sexo (H=Hombre; M=Mujer)
				@vx_sex_per  VARCHAR(06),   --** Nombre Sexo
				@va_fec_nac  DATETIME,      --** Fecha de Nacimiento
				@vx_fec_nac  VARCHAR(10),   --** Fecha de Nacimiento String      
				@va_tip_doc  CHAR(02),      --** Tipo Documento	
				@va_nro_doc	 BIGINT,	    --** Carnet de Identidad
				@va_ext_doc  CHAR(02),      --** Extensión Documento	
				@va_tel_per	 VARCHAR(15),	--** Telefono Personal
				@va_cel_ula	 VARCHAR(15),	--** Telefono Celular
				@va_tel_fij	 VARCHAR(15),	--** Telefono Fijo
				@va_dir_pri	 VARCHAR(120),	--** Direccion Principal
				@va_dir_ent	 VARCHAR(120),	--** Direccion de Entrega
				@va_ema_ail	 VARCHAR(30),	--** Email
				@va_cod_ven	 INT,	        --** Código de Vendedor Asignado
				@vx_nom_ven  VARCHAR(50),   --** Nombre Vendedor
				@va_cod_cob	 INT,	        --** Código de Cobrador Asignado	
				@vx_nom_cob  VARCHAR(50),   --** Nombre Cobrador   	    	  	   		
				@va_est_ado	 CHAR(01),	    --** Estado(H=Habilitado; N=Deshabilitado)
				@vx_est_ado  VARCHAR(15),   --** Nombre Estado
				@va_ide_tip  INT,           --** ID. Tipo Atributo
				@va_nom_tip  VARCHAR(30),   --** Nombre Tipo Atributo
				@va_ide_atr  INT,           --** ID. Atributo
				@va_nom_atr  VARCHAR(30),   --** Nombre Tipo Atributo
				@vx_tip_atr  VARCHAR(MAX),  --** Lista Tipo Atributos
				@vx_nom_atr  VARCHAR(MAX)   --** Lista Atributo


--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Inicializa las variable
SET @va_cod_gru = 0
SET @va_tip_per = ''
SET @va_nom_bre = ''
SET @va_ape_pat = ''
SET @va_ape_mat = ''
SET @va_raz_soc = ''
SET @va_nom_fac = ''
SET @va_ruc_nit = 0
SET @va_sex_per = ''
SET @va_fec_nac = NULL
SET @va_tip_doc = ''
SET @va_nro_doc = 0
SET @va_ext_doc = ''
SET @va_tel_per = ''
SET @va_cel_ula = ''
SET @va_tel_fij = ''
SET @va_dir_pri = ''
SET @va_dir_ent = ''
SET @va_ema_ail = ''
SET @va_cod_ven = 0
SET @va_cod_cob = 0
SET @va_est_ado = ''

--** Obtiene datos de la persona
SELECT @va_cod_gru = va_cod_gru, 
       @va_tip_per = va_tip_per, 
	   @va_nom_bre = va_nom_bre,
	   @va_ape_pat = va_ape_pat,
	   @va_ape_mat = va_ape_mat,
	   @va_raz_soc = va_raz_soc,
	   @va_nom_fac = va_nom_fac,
	   @va_ruc_nit = va_ruc_nit,
	   @va_sex_per = va_sex_per,
	   @va_fec_nac = va_fec_nac,
	   @va_tip_doc = va_tip_doc,
	   @va_nro_doc = va_nro_doc,
	   @va_ext_doc = va_ext_doc,
	   @va_tel_per = va_tel_per,
	   @va_cel_ula = va_cel_ula,
	   @va_tel_fij = va_tel_fij,
	   @va_dir_pri = va_dir_pri,
	   @va_dir_ent = va_dir_ent,
	   @va_ema_ail = va_ema_ail,
	   @va_cod_ven = va_cod_ven,
	   @va_cod_cob = va_cod_cob,
	   @va_est_ado = va_est_ado
  FROM adp002
 WHERE va_cod_per = @ar_cod_per

--** Obtiene el nombre del Grupo
SET @vx_nom_gru = ''
SELECT @vx_nom_gru = va_nom_gru
  FROM adp001
 WHERE va_cod_gru = @va_cod_gru

--** Obtiene Tipo de Persona
SET @vx_tip_per = ''
IF (@va_tip_per = 'P')
	SET @vx_tip_per = 'Particular'

IF (@va_tip_per = 'E')
	SET @vx_tip_per = 'Empresa'

--** Obtiene Sexo de Persona
SET @vx_sex_per = ''
IF (@va_sex_per = 'H')
	SET @vx_sex_per = 'Hombre'

IF (@va_sex_per = 'M')
	SET @vx_sex_per = 'Mujer'

--** Castea la fecha de nacimiento
SET @vx_fec_nac = ''
IF (@va_fec_nac != NULL)
	SET @vx_fec_nac = CONVERT(CHAR(10), @va_fec_nac, 103)

--** Obtiene Nombre del Vendedor
SET @vx_nom_ven = ''
SELECT @vx_nom_ven = va_nom_bre
  FROM cmr014  
 WHERE va_ide_tip = 1
   AND va_cod_ide = @va_cod_ven

--** Obtiene Nombre del Cobrador
SET @vx_nom_cob = ''
SELECT @vx_nom_cob = va_nom_bre
  FROM cmr014  
 WHERE va_ide_tip = 2
   AND va_cod_ide = @va_cod_cob

--** Obtiene el estado
SET @vx_est_ado = ''
IF (@va_est_ado = 'H')
	SET @vx_est_ado = 'Habilitado'
ELSE
	SET @vx_est_ado = 'Deshabilitado'

SET @vx_tip_atr = ''
SET @vx_nom_atr = ''

--** Obtiene el atributo de la persona
DECLARE vc_atr_per CURSOR LOCAL FOR
SELECT va_ide_tip, va_ide_atr
  FROM adp005
 WHERE va_cod_per = @ar_cod_per

--** Abre Cursor
OPEN vc_atr_per

--** Lee el primer registro
FETCH NEXT FROM vc_atr_per INTO @va_ide_tip, @va_ide_atr												
WHILE (@@FETCH_STATUS = 0)
BEGIN	
    --** Obtiene datos del tipo atributo
	SET @va_nom_tip = ''
	SELECT @va_nom_tip = va_nom_tip 
	  FROM adp003
	 WHERE va_ide_tip = @va_ide_tip
	   AND va_est_ado = 'H'

	IF (@@ROWCOUNT > 0)
	BEGIN
	    --** Obtiene datos del tipo atributo
		SET @va_nom_atr = ''
		SELECT @va_nom_atr = va_nom_atr 
		  FROM adp004
		 WHERE va_ide_tip = @va_ide_tip
		   AND va_ide_atr = @va_ide_atr

		--** Cantena los tipo de atributos
		IF (RTRIM(@vx_tip_atr) = '')
			SET @vx_tip_atr = @va_nom_tip
		ELSE 
			SET @vx_tip_atr = @vx_tip_atr + char(10) + @va_nom_tip

		--** Cantena los atributos
		IF (RTRIM(@vx_nom_atr) = '')
			SET @vx_nom_atr = @va_nom_atr
		ELSE
			SET @vx_nom_atr = @vx_nom_atr + char(10) + @va_nom_atr
	END

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_atr_per INTO @va_ide_tip, @va_ide_atr
END	

CLOSE vc_atr_per
DEALLOCATE vc_atr_per

--** Devuelve los datos de la persona
SELECT @ar_cod_per AS va_cod_per,
       @va_cod_gru AS va_cod_gru,
       @vx_nom_gru AS va_nom_gru, 
       @vx_tip_per AS va_tip_per, 
	   @va_nom_bre AS va_nom_bre,
	   @va_ape_pat AS va_ape_pat,
	   @va_ape_mat AS va_ape_mat,
	   @va_raz_soc AS va_raz_soc,
	   @va_nom_fac AS va_nom_fac,
	   @va_ruc_nit AS va_ruc_nit,
	   @vx_sex_per AS va_sex_per,
	   @vx_fec_nac AS va_fec_nac,
	   @va_tip_doc AS va_tip_doc,
	   @va_nro_doc AS va_nro_doc,
	   @va_ext_doc AS va_ext_doc,
	   @va_tel_per AS va_tel_per,
	   @va_cel_ula AS va_cel_ula,
	   @va_tel_fij AS va_tel_fij,
	   @va_dir_pri AS va_dir_pri,
	   @va_dir_ent AS va_dir_ent,
	   @va_ema_ail AS va_ema_ail,
	   @vx_nom_ven AS va_nom_ven,
	   @vx_nom_cob AS va_nom_cob,
	   @vx_est_ado AS va_est_ado,
	   @vx_tip_atr AS va_tip_atr,
	   @vx_nom_atr AS va_nom_atr

