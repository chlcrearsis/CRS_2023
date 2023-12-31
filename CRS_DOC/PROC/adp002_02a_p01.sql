/*****************************************************************/
/*	ARCHIVO: adp002_02a_p01.sql                                  */
/*	PROCEDIMIENTO: GRABA REGISTRO PERSONA                        */
/*                 - (adp002) Inserta Registro de Persona        */
/*				   - (cmr013) Inserta Registro de NIT            */
/*				   - (adp005) Inserta Atributos de Cliente	     */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 30/08/2021             */
/*   NOTA: En caso de error devuelve del 101 as 118              */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp002_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.adp002_02a_p01
GO

CREATE PROCEDURE adp002_02a_p01		@ar_cod_per  INT,	        --** Codigo Persona (2 de Grup. Per y 5 de Persona)
									@ar_cod_gru	 INT,           --** Cod Grupo Persona
									@ar_tip_per  CHAR(01),      --** Tipo de Cliente (P=Particular; E=Empresa)
									@ar_nom_bre  VARCHAR(30),   --** Nombre
									@ar_ape_pat  VARCHAR(20),   --** Apellido Paterno
									@ar_ape_mat  VARCHAR(20),   --** Apellido Materno
									@ar_raz_soc	 VARCHAR(80),	--** Razon Social
									@ar_nom_fac	 VARCHAR(120),	--** Nombre a Facturar
									@ar_ruc_nit	 BIGINT,	    --** RUC/NIT
									@ar_sex_per  CHAR(01),      --** Sexo (H=Hombre; M=Mujer)
									@ar_fec_nac  DATETIME,      --** Fecha de Nacimiento
									@ar_tip_doc  CHAR(02),      --** Tipo Documento	
									@ar_nro_doc	 BIGINT,	    --** Nro. Documento
									@ar_ext_doc  CHAR(02),      --** Extension Documento
									@ar_tel_per	 VARCHAR(15),	--** Telefono Personal
									@ar_cel_ula	 VARCHAR(15),	--** Telefono Celular
									@ar_tel_fij	 VARCHAR(15),	--** Telefono Fijo
									@ar_dir_pri	 VARCHAR(80),	--** Direccion Principal
									@ar_dir_ent	 VARCHAR(80),	--** Direccion de Entrega
									@ar_ema_ail	 VARCHAR(30),	--** Email
									@ar_ubi_gps	 GEOGRAPHY,		--** Ubicación Geografica
									@ar_cod_ven	 INT, 	        --** Código de Vendedor Asignado
									@ar_cod_cob	 INT,           --** Código de Cobrador Asignado

									@ar_tip_atr  VARCHAR(MAX),	--** Array Tipo de Atributo
									@ar_ide_atr  VARCHAR(MAX)	--** Array tributo Seleccionado
									WITH ENCRYPTION AS

DECLARE		@va_nro_reg  INT,		 --** Nro de Registro
            @va_est_ado  CHAR(01),   --** Estado
			@va_fec_act  DATETIME,   --** Fecha Actual
			@va_fec_str  CHAR(10),   --** Fecha Actual
			@va_tip_atr  INT,        --** ID. Tipo Atributo
			@va_ide_atr  INT,        --** ID. Atributo
			@va_nom_tip  VARCHAR(30) --** Nombre Tipo de Atributo

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

BEGIN TRANSACTION

--** Obtiene la fecha actual en dd/MM/yyyy 
SET @va_fec_act = GETDATE()
SET @va_fec_str = CONVERT(CHAR(10), @va_fec_act, 103)
SET @va_fec_act = CONVERT(DATETIME, @va_fec_str)

--** Verifica que el Código Persona sea distinto a cero
IF (@ar_cod_per = 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 101: El Código de Persona tiene que ser DISTINTO a Cero', 16, 1)
	RETURN
END

--** Verifica que no existena otro registro con el mismo ID.
SELECT @va_nro_reg = COUNT(*) 
  FROM adp002
 WHERE va_cod_per = @ar_cod_per

IF (@va_nro_reg > 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 102: Ya existe una persona con el mismo código %d en la base de datos.', 16, 1, @ar_cod_per)
	RETURN
END

--** Valida que el grupo de persona este definido y habilitado
SELECT @va_est_ado = va_est_ado 
  FROM adp001
 WHERE va_cod_gru = @ar_cod_gru

IF (@@ROWCOUNT = 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 103: El Grupo de Persona %d NO está definido en la base de datos.', 16, 1, @ar_cod_per)
	RETURN
END

IF (@va_est_ado = 'F')
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 104: El Grupo de Persona %d está Deshabilitado en la base de datos.', 16, 1, @ar_cod_per)
	RETURN
END

IF (@ar_tip_per <> 'P' AND @ar_tip_per <> 'E')
BEGIN
	ROLLBACK TRANSACTION
	RAISERROR ('Error 105: El Tipo de Persona tiene que ser (P=Particular o E=Empresa).', 16, 1)
	RETURN
END

IF (@ar_nom_bre = '')
BEGIN
	ROLLBACK TRANSACTION
	RAISERROR ('Error 106: El campo Nombre NO DEBE estar vacío.', 16, 1)
	RETURN
END

IF (@ar_ape_pat = '')
BEGIN
	ROLLBACK TRANSACTION
	RAISERROR ('Error 107: El campo Apellido Paterno NO DEBE estar vacío.', 16, 1)
	RETURN
END

IF (@ar_raz_soc = '')
BEGIN
	ROLLBACK TRANSACTION
	RAISERROR ('Error 108: El campo Razón Social NO DEBE estar vacío.', 16, 1)
	RETURN
END

IF (@ar_sex_per <> 'H' AND @ar_sex_per <> 'M')
BEGIN
	ROLLBACK TRANSACTION
	RAISERROR ('Error 109: El Sexo de la Persona tiene que ser (H=Hombre o M=Mujer).', 16, 1)
	RETURN
END

IF (@ar_fec_nac IS NOT NULL)
BEGIN
	IF (@ar_fec_nac > @va_fec_act)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('Error 110: La Fecha de Nacimiento tiene que ser MENOR a la fecha actual.', 16, 1)
		RETURN
	END
END

--** Valida que el tipo de documento este definido y habilitado
SELECT @va_est_ado = va_est_ado 
  FROM adp014
 WHERE va_ide_tip = @ar_tip_doc

IF (@@ROWCOUNT = 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 111: El Tipo de Documento %s NO está definido en la base de datos.', 16, 1, @ar_tip_doc)
	RETURN
END

IF (@va_est_ado = 'F')
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 112: El Tipo de Documento %s está Deshabilitado en la base de datos.', 16, 1, @ar_tip_doc)
	RETURN
END

--** Valida que el Vendedor este definido y habilitado
SELECT @va_est_ado = va_est_ado 
  FROM cmr014
 WHERE va_ide_tip = 1
   AND va_cod_ide = @ar_cod_ven

IF (@@ROWCOUNT = 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 113: El Vendedor %d NO está definido en la base de datos.', 16, 1, @ar_cod_ven)
	RETURN
END

IF (@va_est_ado = 'F')
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 114: El Vendedor %d está Deshabilitado en la base de datos.', 16, 1, @ar_cod_ven)
	RETURN
END

--** Valida que el Cobrador este definido y habilitado
SELECT @va_est_ado = va_est_ado 
  FROM cmr014
 WHERE va_ide_tip = 2
   AND va_cod_ide = @ar_cod_cob

IF (@@ROWCOUNT = 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 115: El Cobrador %d NO está definido en la base de datos.', 16, 1, @ar_cod_cob)
	RETURN
END

IF (@va_est_ado = 'F')
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 116: El Cobrador %d está Deshabilitado en la base de datos.', 16, 1, @ar_cod_cob)
	RETURN
END

--** Inserta datos de la persona
INSERT INTO adp002 VALUES (@ar_cod_per, @ar_cod_gru, @ar_tip_per, @ar_nom_bre,
						   @ar_ape_pat, @ar_ape_mat, @ar_raz_soc,@ar_nom_fac, @ar_ruc_nit, 
						   @ar_sex_per, @ar_fec_nac, @ar_tip_doc, @ar_nro_doc, 
						   @ar_ext_doc, @ar_tel_per, @ar_cel_ula, @ar_tel_fij, 
						   @ar_dir_pri, @ar_dir_ent, @ar_ema_ail, @ar_ubi_gps, 
						   @ar_cod_ven, @ar_cod_cob, 'H')

IF (@@ERROR <> 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 117: Error al inserta datos de la persona (adp002).', 16, 1)
	RETURN
END

--** Verifica si el NIT es distinto a CERO, Si es haci lo inserta
IF (@ar_ruc_nit > 0)
BEGIN
	--** Inserta el NIT del cliente
	INSERT INTO cmr013 VALUES (@ar_cod_per, @ar_ruc_nit, @ar_nom_fac, 1)
END

IF (@@ERROR <> 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 118: Error al inserta datos en la tabla (cmr013).', 16, 1)
	RETURN
END

--** Graba los atributos seleccionado del usuario
DECLARE vc_atr_cli CURSOR LOCAL FOR
SELECT va_ide_tip, va_ide_atr
  FROM adp002_fu01(@ar_tip_atr, @ar_ide_atr, '-')

--** Abre cursor
OPEN vc_atr_cli

--** Lee primer registro
FETCH NEXT FROM vc_atr_cli INTO @va_tip_atr, @va_ide_atr

WHILE (@@FETCH_STATUS = 0)
BEGIN	
	--** Verifica si el tipo de atributo esta definido y habilitado
	SELECT @va_est_ado = va_est_ado, 
	       @va_nom_tip = va_nom_tip
	  FROM adp003
	 WHERE va_ide_tip = @va_tip_atr

	 IF (@@ROWCOUNT = 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('Error 119: El Tipo de Atributo %d. NO está definido en la base de datos.', 16, 1, @va_tip_atr)
		RETURN
	END

	IF (@va_est_ado = 'F')
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('Error 120: El Tipo de Atributo %d. está deshabilitado en la base de datos.', 16, 1, @va_tip_atr)
		RETURN
	END

	--** Verifica si el atributo esta definido y habilitado
	SELECT @va_est_ado = va_est_ado 
	  FROM adp004
	 WHERE va_ide_tip = @va_tip_atr
	   AND va_ide_atr = @va_ide_atr

	 IF (@@ROWCOUNT = 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('Error 121: El Atributo %d de %s NO está definido en la base de datos.', 12, 1, @va_tip_atr, @va_nom_tip)
		RETURN
	END

	IF (@va_est_ado = 'F')
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('Error 122: El Atributo %d de %s está deshabilitado en la base de datos.', 12, 1, @va_tip_atr, @va_nom_tip)
		RETURN
	END

	--** Graba el atributo de persona
	INSERT INTO adp005 VALUES (@ar_cod_per, @va_tip_atr, @va_ide_atr)


	FETCH NEXT FROM vc_atr_cli INTO @va_tip_atr, @va_ide_atr
END

--** Cierre y destruya cursor
CLOSE vc_atr_cli
DEALLOCATE vc_atr_cli

COMMIT TRANSACTION

RETURN


