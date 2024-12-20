/***************************************************************************/
/*	ARCHIVO: ads007_02a_p01.sql                                            */
/*	PROCEDIMIENTO: REGISTRA USUARIO NUEVO                                  */
/*  PARAMETROS:   @ag_ide_usr  NVARCHAR(15)  --** ID. Usuario              */
/*                @ag_nom_usr  NVARCHAR(30)  --** Nombre Usuario           */
/*                @ag_tel_usr  NVARCHAR(15)  --** Teléfono                 */
/*                @ag_car_usr  NVARCHAR(30)  --** Cargo Usuario            */
/*                @ag_dir_tra  NVARCHAR(30)  --** Directorio de Trabajo    */
/*                @ag_ema_usr  NVARCHAR(30)  --** Email                    */
/*                @ag_ven_max  INT           --** Ventanas Máx. Permitidas */
/*                @ag_ide_per  INT           --** ID. Persona              */
/*                @ag_ide_tus  INT           --** Tipo de Usuario          */
/*                @ag_usr_new  INT           --** 0=Nuevo Usuario;         */
/*                                           --** 1=Usuario Creado         */
/*	AUTOR:	CREARSIS(CHL)        FECHA : 13/11/2019                        */
/***************************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_02a_p01
GO

CREATE PROCEDURE ads007_02a_p01		@ag_ide_usr NVARCHAR(15),	@ag_nom_usr	NVARCHAR(30),
                                    @ag_tel_usr	NVARCHAR(15),	@ag_car_usr	NVARCHAR(30),
							        @ag_dir_tra	NVARCHAR(30),	@ag_ema_usr NVARCHAR(30),
							        @ag_ven_max INT,	        @ag_ide_per INT,
							        @ag_ide_tus INT,			@ag_usr_new	INT	WITH ENCRYPTION AS

DECLARE		@va_ide_usr  NVARCHAR(15),	--** Usuario registro
			@va_nom_usr	 NVARCHAR(30),	--** Nombre de usuario
			@va_psw_usr	 NVARCHAR(30),	--** Contraseña por defecto
			@va_tel_usr	 NVARCHAR(15),	--** Telefono usuario
			@va_car_usr	 NVARCHAR(30),	--** Cargo usuario						
			@va_ema_usr  NVARCHAR(30),	--** Email usuario
			@va_ven_max  INT,			--** Nro ventanas abiertas permitidas al usuario
			@va_ide_per  INT,			--** Codigo persona relacionada con el usuario
			@va_est_ado  CHAR(01),		--** Estado usuario (V=habilitado ; N=Deshabilitado)
			@va_nom_bda	 NVARCHAR(20),	--** Nombre de base de datos
			@va_com_sql	 NVARCHAR(200), --** Comando para ejecutar sentencia sql
			@va_nro_reg	 INT,           --** Nro. de Registro
			@va_msg_err	 NVARCHAR(200)  --** Mensaje de Error

--** Inhabilita Mensajes Numero de filas afectadas
SET NOCOUNT ON
  
--** Inicializa Transación
BEGIN TRANSACTION  
--** Obtiene nombre de Base de Datos
SELECT @va_nom_bda = DB_NAME() 

--** Inicializa Nro de Registro
SET @va_nro_reg = 0

--** Obtiene contraseña por defecto de la global (1-21)
SET @va_psw_usr = ''
SELECT @va_psw_usr = va_glo_car
  FROM ads013
 WHERE va_ide_mod = 1
   AND va_ide_glo = 21

--** Si Global NO se encuentra definida, proporciona una fija
IF (@@ROWCOUNT = 0)
BEGIN
	ROLLBACK TRANSACTION
	RAISERROR ('NO está definido la clave por defecto (1-21) en el sistema.',16,1)
	RETURN
END 	

--** Si el Usuario a Registrar es Nuevo
IF (@ag_usr_new = 0)
BEGIN 
	--** Verifica SI el existe el Inicio de sesion
    SELECT @va_nro_reg = COUNT(*)
    FROM sys.sql_logins
    WHERE name = @ag_ide_usr	
      
    IF (@va_nro_reg = 0)
    BEGIN      
		--** CREA UN NUEVO LOGIN     
		--** Prepare para Crear Usuario en SLQ2005/SQL2008 cuando no se especifica
		--** la Directiva de Seguridad por defecto esta en 'ON'
		SET @va_com_sql = 'CREATE LOGIN [' + RTRIM(@ag_ide_usr) + ']' +
						  ' WITH PASSWORD = ''' + RTRIM(@va_psw_usr) +
						  ''', DEFAULT_DATABASE = ' + RTRIM(@va_nom_bda) + 
						  ', DEFAULT_LANGUAGE = spanish, CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF'

			--** Ejecuta Prepare de Creacion de Login
		EXEC sp_executesql @va_com_sql

		IF (@@ERROR > 0)
		BEGIN
			ROLLBACK TRANSACTION
			RAISERROR ('Error al crear el Login en la Base de Datos de SQL-Server.',16,1)
			RETURN
		END
    END
END
		
--** CREA USUARIO EN LA BASE DE DATOS
SELECT @va_nro_reg = COUNT(*) 
  FROM sysusers 
 WHERE name = @ag_ide_usr

IF (@va_nro_reg = 0)
BEGIN
	--** Genera el comando para crear usuario en la base de datos
	SET @va_com_sql = 'CREATE USER [' + RTRIM(@ag_ide_usr) + ']' +
	                  '  FOR LOGIN [' + RTRIM(@ag_ide_usr) + ']'

	--** Ejecuta comando
	EXEC sp_executesql @va_com_sql

	IF (@@ERROR > 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('Error al crear el Usuario en la Base de Datos de SQL-Server.',16,1)
		RETURN
	END
END   
    
--** Adiciona Inicio de Sesion a roles del servidor
EXEC sp_addsrvrolemember @ag_ide_usr, dbcreator
EXEC sp_addsrvrolemember @ag_ide_usr, sysadmin
EXEC sp_addsrvrolemember @ag_ide_usr, serveradmin		
	
--** Registra Usuario en Tabla del Sistema
SELECT @va_nro_reg = COUNT(*)
  FROM ads007
 WHERE va_ide_usr = @ag_ide_usr

--** Verifica si YA el usuario esta creado el usuario en la tabla (ads007)
IF (@va_nro_reg > 0)
BEGIN
	ROLLBACK TRANSACTION
	RAISERROR ('Ya existe creado el Usuario en el sistema (ads007).',16,1)
	RETURN
END

--** Inserta el usuario en la tabla ads007
INSERT INTO ads007 values(@ag_ide_usr, @ag_nom_usr, @ag_tel_usr, @ag_car_usr,
						  @ag_dir_tra, @ag_ema_usr, @ag_ven_max, @ag_ide_per,
						  @ag_ide_tus, 'H')
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION
	RAISERROR ('Error al registrar Usuario en la Tabla (ads007)',16,1)
	RETURN
END
	
COMMIT TRANSACTION

RETURN

GO