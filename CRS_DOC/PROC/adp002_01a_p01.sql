/***********************************************************************/
/*	ARCHIVO: adp002_01a_p01.sql                                        */
/*	PROCEDIMIENTO: BUSCA PERSONA                                       */
/*      ARGUMENTO: @ar_cod_gru  INT         --** Código Grupo          */
/*                 @ar_tex_bus  VARCHAR(60) --** Texto a ser buscado   */
/*				   @ar_cri_bus  INT         --** Criterio de Busqueda  */
/*                 @ar_est_ado  CHAR(01)    --** Estado                */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 23/09/2021                   */
/***********************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp002_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.adp002_01a_p01
GO

CREATE PROCEDURE adp002_01a_p01		@ar_cod_gru	 VARCHAR(02),	--** Código Grupo
                                    @ar_tip_per  CHAR(01),      --** Tipo de Cliente (P=Particular; E=Empresa; T=Todos)
									@ar_tex_bus	 VARCHAR(60),	--** Texto a ser buscado
									@ar_cri_bus	 INT,			--** Criterio de Busqueda (0=Cod. Persona; 1=Razon Social;
									                            --** 2=Nombre; 3=Ape. Paterno; 4=Ape. Materno; 5=NIT; 6=Documento; 7=Teléfono)
									@ar_est_ado	 CHAR(01)		--** Estado (H=Habilitado; N=Deshabilitado; T=Todos)
									WITH ENCRYPTION AS

DECLARE     @va_cod_per  INT,	      --** Codigo Persona (2 de Grup. Per y 5 de Persona)
			@va_cod_gru	 INT,	      --** Cod Grupo Persona
			@va_nom_gru  VARCHAR(50), --** Nombre Grupo Persona
			@va_tip_per  CHAR(01),    --** Tipo de Cliente (P=Particular; E=Empresa)
			@va_nom_bre  VARCHAR(30), --** Nombre
			@va_ape_pat  VARCHAR(20), --** Apellido Paterno
			@va_ape_mat  VARCHAR(20), --** Apellido Materno
			@va_raz_soc	 VARCHAR(80), --** Razon Social
			@va_ruc_nit	 BIGINT,	  --** RUC/NIT
			@va_sex_per  CHAR(01),    --** Sexo (H=Hombre; M=Mujer)
			@va_fec_nac  DATETIME,    --** Fecha de Nacimiento
			@va_tip_doc  CHAR(02),    --** Tipo Documento
			@va_des_tip  VARCHAR(30), --** Descripción de Documento	
			@va_nro_doc	 BIGINT,	  --** Carnet de Identidad	
			@va_tel_per	 VARCHAR(15), --** Telefono Personal
			@va_cel_ula	 VARCHAR(15), --** Telefono Celular
			@va_tel_fij	 VARCHAR(15), --** Telefono Fijo
			@va_dir_pri	 VARCHAR(80), --** Direccion Principal
			@va_dir_ent	 VARCHAR(80), --** Direccion de Entrega
			@va_ema_ail	 VARCHAR(30), --** Email
			@va_ubi_lat	 VARCHAR(30),	  --** Ubicación latitud
			@va_ubi_lon	 VARCHAR(30),	  --** Ubicación longitud
			@va_cod_ven	 INT,	      --** Código de Vendedor Asignado
			@va_nom_ven  CHAR(30),    --** Nombre del Vendedor Asignadao
			@va_cod_cob	 INT,	      --** Código de Cobrador Asignado	   	    	  	   		
			@va_nom_cob  CHAR(30),    --** Nombre del Cobrador Asignadao
			@va_est_ado	 CHAR(01),	  --** Estado(H=Habilitado; N=Deshabilitado)
			@va_msn_err  VARCHAR(200) --** Nro. Registro

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Tabla Temporal: Lista Persona
CREATE TABLE #tm_lis_per (
    va_cod_per  INT,
    va_cod_gru	INT,
	va_nom_gru  VARCHAR(50),
	va_tip_per  CHAR(01),
	va_nom_bre  VARCHAR(30),
	va_ape_pat  VARCHAR(20),
	va_ape_mat  VARCHAR(20),
	va_raz_soc	VARCHAR(80),
	va_ruc_nit	BIGINT,
	va_sex_per  CHAR(01),
	va_fec_nac  DATETIME,
	va_tip_doc  CHAR(02),
	va_des_tip  VARCHAR(30),
	va_nro_doc	BIGINT,
	va_tel_per	VARCHAR(15),
	va_cel_ula	VARCHAR(15),
	va_tel_fij	VARCHAR(15),
	va_dir_pri	VARCHAR(80),
	va_dir_ent	VARCHAR(80),
	va_ema_ail	VARCHAR(30),
	va_ubi_lat	VARCHAR(30),
	va_ubi_lon	VARCHAR(30),
	va_cod_ven	INT,
	va_nom_ven  VARCHAR(30),
	va_cod_cob	INT,
	va_nom_cob  VARCHAR(30),
	va_est_ado	CHAR(1)
)

--** Tabla Temporal: Codigo Persona
CREATE TABLE #tm_cod_per(
	va_cod_per  INT
)
   
BEGIN TRY 

--** Verifica si el estado es T=Todos
IF(@ar_cod_gru = '0')
	SET @ar_cod_gru = ''

--** Verifica si el estado es T=Todos
IF(@ar_est_ado = 'T')
	SET @ar_est_ado = '%'

--** Verifica si el tipo de persona es T=Todos
IF (@ar_tip_per = 'T')
	SET @ar_tip_per = '%'

--** Obtiene las lista de persona filtradas
IF(@ar_cri_bus = 0)  -- Codigo Persona
BEGIN
	INSERT INTO #tm_cod_per
	SELECT va_cod_per
	  FROM adp002
	 WHERE va_cod_gru LIKE '%' + @ar_cod_gru
	   AND va_tip_per LIKE '%' + @ar_tip_per
	   AND va_est_ado LIKE '%' + @ar_est_ado
	   AND va_cod_per LIKE @ar_tex_bus + '%'
END
IF(@ar_cri_bus = 1)  -- Razón Social
BEGIN
	INSERT INTO #tm_cod_per
	SELECT va_cod_per
	  FROM adp002
	 WHERE va_cod_gru LIKE '%' + @ar_cod_gru
	   AND va_tip_per LIKE '%' + @ar_tip_per
	   AND va_est_ado LIKE '%' + @ar_est_ado
	   AND va_raz_soc LIKE @ar_tex_bus + '%'
END
IF(@ar_cri_bus = 2)  -- Nombres
BEGIN
	INSERT INTO #tm_cod_per
	SELECT va_cod_per
	  FROM adp002
	 WHERE va_cod_gru LIKE '%' + @ar_cod_gru
	   AND va_tip_per LIKE '%' + @ar_tip_per
	   AND va_est_ado LIKE '%' + @ar_est_ado
	   AND va_nom_bre LIKE @ar_tex_bus + '%'
END
IF(@ar_cri_bus = 3)  -- Ape. Paterno
BEGIN
	INSERT INTO #tm_cod_per
	SELECT va_cod_per
	  FROM adp002
	 WHERE va_cod_gru LIKE '%' + @ar_cod_gru
	   AND va_tip_per LIKE '%' + @ar_tip_per
	   AND va_est_ado LIKE '%' + @ar_est_ado
	   AND va_ape_pat LIKE @ar_tex_bus + '%'
END
IF(@ar_cri_bus = 4)  -- Ape. Materno
BEGIN
	INSERT INTO #tm_cod_per
	SELECT va_cod_per
	  FROM adp002
	 WHERE va_cod_gru LIKE '%' + @ar_cod_gru
	   AND va_tip_per LIKE '%' + @ar_tip_per
	   AND va_est_ado LIKE '%' + @ar_est_ado
	   AND va_ape_mat LIKE @ar_tex_bus + '%'
END
IF(@ar_cri_bus = 5)  -- NIT
BEGIN
	INSERT INTO #tm_cod_per
	SELECT va_cod_per
	  FROM adp002
	 WHERE va_cod_gru LIKE '%' + @ar_cod_gru
	   AND va_tip_per LIKE '%' + @ar_tip_per
	   AND va_est_ado LIKE '%' + @ar_est_ado
	   AND va_ruc_nit LIKE @ar_tex_bus + '%'
END
IF(@ar_cri_bus = 6)  -- Nro. Documento
BEGIN
	INSERT INTO #tm_cod_per
	SELECT va_cod_per
	  FROM adp002
	 WHERE va_cod_gru LIKE '%' + @ar_cod_gru
	   AND va_tip_per LIKE '%' + @ar_tip_per
	   AND va_est_ado LIKE '%' + @ar_est_ado
	   AND va_nro_doc LIKE @ar_tex_bus + '%'
END
IF(@ar_cri_bus = 7)  -- Teléfono
BEGIN
	INSERT INTO #tm_cod_per
	SELECT va_cod_per
	  FROM adp002
	 WHERE va_cod_gru LIKE '%' + @ar_cod_gru
	   AND va_tip_per LIKE '%' + @ar_tip_per
	   AND va_est_ado LIKE '%' + @ar_est_ado
	   AND (va_tel_per LIKE @ar_tex_bus + '%' OR
	        va_cel_ula LIKE @ar_tex_bus + '%' OR
			va_tel_fij LIKE @ar_tex_bus + '%')
END

--** Obtiene los datos de la persona
DECLARE vc_per_son CURSOR LOCAL FOR
 SELECT va_cod_per, va_cod_gru, va_tip_per, va_nom_bre,
	    va_ape_pat, va_ape_mat, va_raz_soc, va_ruc_nit,
	    va_sex_per, va_fec_nac, va_tip_doc, va_nro_doc,
	    va_tel_per, va_cel_ula, va_tel_fij, va_dir_pri,
	    va_dir_ent, va_ema_ail, va_ubi_lat, va_ubi_lon,
	    va_cod_ven, va_cod_cob, va_est_ado
   FROM adp002
  WHERE va_cod_per IN (SELECT va_cod_per FROM #tm_cod_per)

--** Abre Cursor
OPEN vc_per_son
--** Lee el primer registro
FETCH NEXT FROM vc_per_son INTO @va_cod_per, @va_cod_gru, @va_tip_per, @va_nom_bre,
								@va_ape_pat, @va_ape_mat, @va_raz_soc, @va_ruc_nit,
								@va_sex_per, @va_fec_nac, @va_tip_doc, @va_nro_doc,
								@va_tel_per, @va_cel_ula, @va_tel_fij, @va_dir_pri,
								@va_dir_ent, @va_ema_ail, @va_ubi_lat, @va_ubi_lon,
								@va_cod_ven, @va_cod_cob, @va_est_ado
														
WHILE (@@FETCH_STATUS = 0)
BEGIN
	--** Obtiene nombre del Grupo
	SELECT @va_nom_gru = va_nom_gru
	  FROM adp001
	 WHERE va_cod_gru = @va_cod_gru
	
	IF (@@ROWCOUNT = 0)
		SET @va_nom_gru = ''

	--** Obtiene nombre del Tipo de Documento
	SELECT @va_des_tip = va_des_tip
	  FROM adp014
	 WHERE va_ide_tip = @va_tip_doc

	 IF (@@ROWCOUNT = 0)
		SET @va_des_tip = ''

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
   
	--** Inserta en la tabla temporal
	INSERT INTO #tm_lis_per VALUES (@va_cod_per, @va_cod_gru, @va_nom_gru, @va_tip_per, 
	                                @va_nom_bre, @va_ape_pat, @va_ape_mat, @va_raz_soc, 
									@va_ruc_nit, @va_sex_per, @va_fec_nac, @va_tip_doc, 
									@va_des_tip, @va_nro_doc, @va_tel_per, @va_cel_ula, 
									@va_tel_fij, @va_dir_pri, @va_dir_ent, @va_ema_ail, 
									@va_ubi_lat, @va_ubi_lon, @va_cod_ven, @va_nom_ven,  
									@va_cod_cob, @va_nom_cob, @va_est_ado)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_per_son INTO @va_cod_per, @va_cod_gru, @va_tip_per, @va_nom_bre,
								    @va_ape_pat, @va_ape_mat, @va_raz_soc, @va_ruc_nit,
								    @va_sex_per, @va_fec_nac, @va_tip_doc, @va_nro_doc,
								    @va_tel_per, @va_cel_ula, @va_tel_fij, @va_dir_pri,
								    @va_dir_ent, @va_ema_ail, @va_ubi_lat, @va_ubi_lon, 
								    @va_cod_ven, @va_cod_cob, @va_est_ado
END	

CLOSE vc_per_son
DEALLOCATE vc_per_son

--** Obtiene resultado TODO los Grupos
SELECT va_cod_per, va_cod_gru, va_nom_gru, va_tip_per, 
	   va_nom_bre, va_ape_pat, va_ape_mat, va_raz_soc, 
	   va_ruc_nit, va_sex_per, va_fec_nac, va_tip_doc, 
	   va_des_tip, va_nro_doc, va_tel_per, va_cel_ula, 
	   va_tel_fij, va_dir_pri, va_dir_ent, va_ema_ail, 
	   va_ubi_lat, va_ubi_lon, va_cod_ven, va_nom_ven, 
	   va_cod_cob, va_nom_cob, va_est_ado
  FROM #tm_lis_per


END TRY
BEGIN CATCH	
	SET @va_msn_err = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@va_msn_err,16,1)
	RETURN
END CATCH	   
GO


