/*****************************************************************/
/*	ARCHIVO: ads013_02b_p01.sql                                  */
/*	PROCEDIMIENTO: REGISTRA GLOBALES POR DEFECTOS                */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 14/06/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads013_02b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads013_02b_p01
GO

CREATE PROCEDURE ads013_02b_p01	WITH ENCRYPTION AS

DECLARE		@va_nro_reg	 INT	--** Nro. Registro
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

/*************************************************/
/**      MODULO : ADMNISTRACIÓN Y SEGURIDAD     **/
/*************************************************/
--** Razon Social Empresa
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 1 AND va_ide_glo = 1)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (1, 1, 'Razon Social Empresa', 2, 0, 0.00000, 'Empresa S.R.L.')

--** Representante Legal
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 1 AND va_ide_glo = 2)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (1, 2, 'Representante Legal', 2, 0, 0.00000, 'Nombre Representante')

--** NIT de la empresa
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 1 AND va_ide_glo = 3)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (1, 3, 'NIT de la empresa', 1, 0.00000, 1234567890, '')

--** Telefono Fijo
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 1 AND va_ide_glo = 4)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (1, 4, 'Telefono Fijo', 2, 0, 0.00000, '33-333333')

--** Telefono Celular
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 1 AND va_ide_glo = 5)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (1, 5, 'Telefono Celular', 2, 0, 0.00000, '999-99999')

--** Email
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 1 AND va_ide_glo = 6)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (1, 6, 'Email', 2, 0, 0.00000, 'empresa@gmail.com')

--** Dirección
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 1 AND va_ide_glo = 7)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (1, 7, 'Dirección', 2, 0, 0.00000, 'Direccion')

--** Clave Wifi
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 1 AND va_ide_glo = 8)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (1, 8, 'Clave Wifi', 2, 0, 0.00000, 'Wifi123.')

--** Logo Empresa
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 1 AND va_ide_glo = 9)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (1, 9, 'Logo Empresa', 2, 0, 0.00000, '')

--** Logo B
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 1 AND va_ide_glo = 10)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (1, 10, 'Logo B', 2, 0, 0.00000, '')

--** Logo C
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 1 AND va_ide_glo = 11)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (1, 11, 'Logo C', 2, 0, 0.00000, '')

--** Logo D
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 1 AND va_ide_glo = 12)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (1, 12, 'Logo D', 2, 0, 0.00000, '')

--** Longitud Mínima Contraseña Usuario
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 1 AND va_ide_glo = 20)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (1, 20, 'Longitud Mínima Contraseña Usuario', 0, 4, 0.00000,'')

--** Contraseña por defecto
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 1 AND va_ide_glo = 21)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (1, 21, 'Contraseña por defecto', 2, 0, 0.00000,'Contra123.')

--** Versión del sistema
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 1 AND va_ide_glo = 100)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (1, 100, 'Versión del sistema', 2, 0, 0.00000, '1.0.0')

/*************************************************/
/**          MODULO : COMERCIALIZACIÓN          **/
/*************************************************/
--** Formulario Ventas
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 3 AND va_ide_glo = 1)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (3, 1, 'Formulario Ventas', 2, 0, 0.00000, 'Normal')

--** Productos Farmacia
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 3 AND va_ide_glo = 2)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (3, 2, 'Productos Farmacia', 2, 0, 0.00000, 'Normal')

/*************************************************/
/**            MODULO : CONTABILIDAD            **/
/*************************************************/
--** Gestión
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 4 AND va_ide_glo = 1)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (4, 1, 'Gestión', 0, 2023, 0.00000, '')

--** Periodo
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads013 
 WHERE (va_ide_mod = 4 AND va_ide_glo = 2)

IF (@va_nro_reg = 0)
	INSERT INTO ads013 VALUES (4, 2, 'Periodo', 0, 11, 0.00000, '')
	
GO

