/*****************************************************************/
/*	ARCHIVO: ads007_R01.sql                                      */
/*	PROCEDIMIENTO: INFORME USUARIO DEL SISTEMA                   */
/*  PARAMETROS:   @ar_est_ado  CHAR(01)  Estado                  */
/*                @ar_ord_dat  CHAR(01)  Orden Datos             */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 04/08/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_R01
GO

CREATE PROCEDURE ads007_R01		@ar_est_ado  CHAR(01),
                                @ar_ord_dat  CHAR(01)	WITH ENCRYPTION AS

DECLARE		@va_ide_usr  VARCHAR(15),	--** ID. Usuario
            @va_nom_usr	 VARCHAR(30),	--** Nombre Usuario
			@va_tel_usr	 VARCHAR(15),	--** Telefono
			@va_car_usr	 VARCHAR(30),	--** Cargo
			@va_dir_tra	 VARCHAR(30),   --** Directorio de Trabajo
			@va_ema_usr	 VARCHAR(90),   --** Email
			@va_ven_max	 INT,           --** Nro. Maximo de Ventanas Abierta
			@va_ide_per	 INT,           --** ID. Persona Asociada
			@va_raz_soc	 VARCHAR(80),	--** Razon Social
			@va_ide_tus	 INT,           --** ID. Tipo de Usuario
			@va_nom_tus	 VARCHAR(30),	--** Nombre Tipo de Usuario
			@va_est_ado  CHAR(01), 	    --** Estado (H=Habilitado; N=Deshabilitado)
			@va_nro_reg  INT
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_lis_usr
(
	va_ide_usr  VARCHAR(15),
    va_nom_usr	VARCHAR(30),
	va_tel_usr	VARCHAR(15),
	va_car_usr	VARCHAR(30),
	va_dir_tra	VARCHAR(30),
	va_ema_usr	VARCHAR(90),
	va_ven_max	INT,        
	va_ide_per	INT,        
	va_raz_soc	VARCHAR(80),
	va_ide_tus	INT,        
	va_nom_tus	VARCHAR(30),
	va_est_ado  CHAR(01)
)

--** Castea el estado si es T=Todos
IF (@ar_est_ado = 'T')
	SET @ar_est_ado = ''

--** Obtiene los datos de las aplicaciones del sistema
DECLARE vc_reg_usr CURSOR LOCAL FOR
 SELECT va_ide_usr, va_nom_usr, va_tel_usr, va_car_usr,
	    va_dir_tra, va_ema_usr, va_ven_max, va_ide_per,
	    va_ide_tus, va_est_ado
   FROM ads007
  WHERE va_est_ado LIKE '%' + RTRIM(@ar_est_ado)

--** Abre Cursor
OPEN vc_reg_usr
--** Lee el primer registro
FETCH NEXT FROM vc_reg_usr INTO @va_ide_usr, @va_nom_usr, @va_tel_usr, @va_car_usr,
	                            @va_dir_tra, @va_ema_usr, @va_ven_max, @va_ide_per,
	                            @va_ide_tus, @va_est_ado
														
WHILE (@@FETCH_STATUS = 0)
BEGIN
	--** Inicializa variables
	SET @va_raz_soc = ''
	SET @va_nom_tus = ''

	--** Lee datos de la Persona
	IF (@va_ide_per <> 0)
	BEGIN
		SELECT @va_raz_soc = va_raz_soc
		  FROM adp002
		 WHERE va_cod_per = @va_ide_per
		IF (@@ROWCOUNT = 0)
			SET @va_raz_soc = ''
	END

	--** Lee datos del tipo de usuario
	IF (@va_ide_tus <> 0)
	BEGIN
		SELECT @va_nom_tus = va_nom_tus
		  FROM ads006
		 WHERE va_ide_tus = @va_ide_tus

		IF (@@ROWCOUNT = 0)
			SET @va_nom_tus = ''
	END

	--** Inserta en la tabla temporal
	INSERT INTO #tm_lis_usr VALUES (@va_ide_usr, @va_nom_usr, @va_tel_usr, @va_car_usr,
	                                @va_dir_tra, @va_ema_usr, @va_ven_max, @va_ide_per,
	                                @va_raz_soc, @va_ide_tus, @va_nom_tus, @va_est_ado)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_reg_usr INTO @va_ide_usr, @va_nom_usr, @va_tel_usr, @va_car_usr,
	                                @va_dir_tra, @va_ema_usr, @va_ven_max, @va_ide_per,
	                                @va_ide_tus, @va_est_ado
END	

CLOSE vc_reg_usr
DEALLOCATE vc_reg_usr


--** Retorna los datos
SELECT va_ide_usr, va_nom_usr, va_tel_usr, va_car_usr,
       va_dir_tra, va_ema_usr, va_ven_max, va_ide_per,
       va_raz_soc, va_ide_tus, va_nom_tus,
	   CASE WHEN va_est_ado = 'H'
		    THEN 'Habilitado' 
		    ELSE 'Deshabilitado' 
	   END AS va_est_ado
  FROM #tm_lis_usr
 WHERE va_est_ado LIKE '%' + RTRIM(@ar_est_ado)
 ORDER BY 
  CASE WHEN @ar_ord_dat = 'C' THEN va_ide_usr END ASC,	--** Código
  CASE WHEN @ar_ord_dat = 'N' THEN va_nom_usr END ASC	--** Nombre
