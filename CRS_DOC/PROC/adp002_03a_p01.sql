/*****************************************************************/
/*	ARCHIVO: adp002_03a_p01.sql                                  */
/*	PROCEDIMIENTO: ACTUALIZA REGISTRO PERSONA                    */
/*                 - (adp002) Actualiza Registro de Persona      */
/*				   - (cmr013) Actualiza Registro de NIT          */
/*				   - (adp005) Actualiza Atributos de Cliente	 */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 17/09/2021             */
/*   NOTA: En caso de error devuelve del 101 as 118              */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp002_03a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.adp002_03a_p01
GO

CREATE PROCEDURE adp002_03a_p01		@ar_cod_per  INT,	        --** Codigo Persona (2 de Grup. Per y 5 de Persona)
																		
									@ar_nom_bre  VARCHAR(30),   --** Nombre
									@ar_ape_pat  VARCHAR(20),   --** Apellido Paterno
									@ar_ape_mat  VARCHAR(20),   --** Apellido Materno
									@ar_raz_soc	 VARCHAR(80),	--** Razon Social
									@ar_nom_fac	 VARCHAR(120),	--** Nombre a Facturar
									@ar_ruc_nit	 BIGINT,	    --** RUC/NIT
									@ar_sex_per  CHAR(01),      --** Sexo (H=Hombre; M=Mujer)
									@ar_fec_nac  DATETIME,      --** Fecha de Nacimiento
									@ar_tip_doc  CHAR(02),      --** Tipo Documento	
									@ar_nro_doc	 BIGINT,	    --** Carnet de Identidad
									@ar_ext_doc  CHAR(02),      --** Extension Documento	
									@ar_tel_per	 VARCHAR(15),	--** Telefono Personal
									@ar_cel_ula	 VARCHAR(15),	--** Telefono Celular
									@ar_tel_fij	 VARCHAR(15),	--** Telefono Fijo
									@ar_dir_pri	 VARCHAR(80),	--** Direccion Principal
									@ar_dir_ent	 VARCHAR(80),	--** Direccion de Entrega
									@ar_ema_ail	 VARCHAR(30),	--** Email
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

--** Verifica que existena el registro con el mismo ID.
SELECT @va_nro_reg = COUNT(*) 
  FROM adp002
 WHERE va_cod_per = @ar_cod_per

IF (@@ROWCOUNT = 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 102: La persona con el codigo %d NO está definido en la base de datos.', 16, 1, @ar_cod_per)
	RETURN
END

IF (@ar_nom_bre = '')
BEGIN
	ROLLBACK TRANSACTION
	RAISERROR ('Error 103: El campo Nombre NO DEBE estar vacío.', 16, 1)
	RETURN
END

IF (@ar_ape_pat = '')
BEGIN
	ROLLBACK TRANSACTION
	RAISERROR ('Error 104: El campo Apellido Paterno NO DEBE estar vacío.', 16, 1)
	RETURN
END

IF (@ar_raz_soc = '')
BEGIN
	ROLLBACK TRANSACTION
	RAISERROR ('Error 105: El campo Razón Social NO DEBE estar vacío.', 16, 1)
	RETURN
END

IF (@ar_sex_per <> 'H' AND @ar_sex_per <> 'M')
BEGIN
	ROLLBACK TRANSACTION
	RAISERROR ('Error 106: El Sexo de la Persona tiene que ser (H=Hombre o M=Mujer).', 16, 1)
	RETURN
END

IF (@ar_fec_nac IS NOT NULL)
BEGIN
	IF (@ar_fec_nac > @va_fec_act)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('Error 107: La Fecha de Nacimiento tiene que ser MENOR a la fecha actual.', 16, 1)
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
	RAISERROR ('Error 108: El Tipo de Documento %s NO está definido en la base de datos.', 16, 1, @ar_tip_doc)
	RETURN
END

IF (@va_est_ado = 'F')
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 109: El Tipo de Documento %s está Deshabilitado en la base de datos.', 16, 1, @ar_tip_doc)
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
	RAISERROR ('Error 110: El Vendedor %d NO está definido en la base de datos.', 16, 1, @ar_cod_ven)
	RETURN
END

IF (@va_est_ado = 'F')
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 111: El Vendedor %d está Deshabilitado en la base de datos.', 16, 1, @ar_cod_ven)
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
	RAISERROR ('Error 112: El Cobrador %d NO está definido en la base de datos.', 16, 1, @ar_cod_cob)
	RETURN
END

IF (@va_est_ado = 'F')
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 113: El Cobrador %d está Deshabilitado en la base de datos.', 16, 1, @ar_cod_cob)
	RETURN
END

--** Inserta datos de la persona
UPDATE adp002 SET va_nom_bre = @ar_nom_bre,
				  va_ape_pat = @ar_ape_pat, 
				  va_ape_mat = @ar_ape_mat, 
				  va_raz_soc = @ar_raz_soc, 
				  va_ruc_nit = @ar_ruc_nit, 
				  va_sex_per = @ar_sex_per, 
				  va_fec_nac = @ar_fec_nac, 
				  va_tip_doc = @ar_tip_doc, 
				  va_nro_doc = @ar_nro_doc,
				  va_ext_doc = @ar_ext_doc, 
				  va_tel_per = @ar_tel_per, 
				  va_cel_ula = @ar_cel_ula,
				  va_tel_fij = @ar_tel_fij, 
				  va_dir_pri = @ar_dir_pri, 
				  va_dir_ent = @ar_dir_ent, 
				  va_ema_ail = @ar_ema_ail,				  
				  va_cod_ven = @ar_cod_ven, 
				  va_cod_cob = @ar_cod_cob
		    WHERE va_cod_per = @ar_cod_per

IF (@@ERROR <> 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 114: Error al actualizar los datos de la persona (adp002).', 16, 1)
	RETURN
END

IF (@ar_ruc_nit > 0)
BEGIN
	--** Elimina el Registro del NIT
	DELETE cmr013 WHERE va_cod_per = @ar_cod_per
	               AND va_nit_per = @ar_ruc_nit

	--** Inserta el NIT
	INSERT INTO cmr013 VALUES (@ar_cod_per, @ar_ruc_nit, @ar_nom_fac, 1)
	
	IF (@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('Error 115: Error al actualizar datos en la tabla (cmr013).', 16, 1)
		RETURN
	END
END

--** Elimina los atributos del cliente
DELETE adp005 WHERE va_cod_per = @ar_cod_per

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
		RAISERROR ('Error 116: El Tipo de Atributo %d. NO está definido en la base de datos.', 16, 1, @va_tip_atr)
		RETURN
	END

	IF (@va_est_ado = 'F')
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('Error 117: El Tipo de Atributo %d. está deshabilitado en la base de datos.', 16, 1, @va_tip_atr)
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
		RAISERROR ('Error 118: El Atributo %d de %s NO está definido en la base de datos.', 12, 1, @va_tip_atr, @va_nom_tip)
		RETURN
	END

	IF (@va_est_ado = 'F')
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('Error 119: El Atributo %d de %s está deshabilitado en la base de datos.', 12, 1, @va_tip_atr, @va_nom_tip)
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


