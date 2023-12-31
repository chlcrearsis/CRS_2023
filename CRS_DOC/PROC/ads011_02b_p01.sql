/*****************************************************************/
/*	ARCHIVO: ads011_02b_p01.sql                                  */
/*	PROCEDIMIENTO: REGISTRA CLAVES POR DEFECTOS                  */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 05/12/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads011_02b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads011_02b_p01
GO

CREATE PROCEDURE ads011_02b_p01	WITH ENCRYPTION AS

DECLARE		@va_nro_reg	 INT	--** Nro. Registro
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

/*************************************************/
/**      MODULO : ADMNISTRACIÓN Y SEGURIDAD     **/
/*************************************************/
--** Modifica Parametros Estructurales
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads011
 WHERE (va_ide_mod = 1 AND va_ide_cla = 1)

IF (@va_nro_reg = 0)
	INSERT INTO ads011 VALUES (1, 1, 'Modifica Parametros Estructurales', 'Modifica Parametros Estructurales', 'S')

--** Inicializa Contraseña Usuario
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads011
 WHERE (va_ide_mod = 1 AND va_ide_cla = 2)

IF (@va_nro_reg = 0)
	INSERT INTO ads011 VALUES (1, 2, 'Inicializa Contraseña Usuario', 'Inicializa Contraseña Usuario', 'S')

--** Modifica PIN Usuario
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads011
 WHERE (va_ide_mod = 1 AND va_ide_cla = 3)

IF (@va_nro_reg = 0)
	INSERT INTO ads011 VALUES (1, 3, 'Modifica PIN Usuario', 'Modifica PIN Usuario', 'S')

--** Elimina Registro Usuario
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads011
 WHERE (va_ide_mod = 1 AND va_ide_cla = 4)

IF (@va_nro_reg = 0)
	INSERT INTO ads011 VALUES (1, 4, 'Elimina Registro Usuario', 'Elimina Registro Usuario', 'S')

--** Inicializa PIN Usuario
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads011
 WHERE (va_ide_mod = 1 AND va_ide_cla = 5)

IF (@va_nro_reg = 0)
	INSERT INTO ads011 VALUES (1, 5, 'Inicializa PIN Usuario', 'Inicializa PIN Usuario', 'S')

/*************************************************/
/**          MODULO : COMERCIALIZACIÓN          **/
/*************************************************/
--** Registra/Modifica Facturas Fuera Fecha
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads011 
 WHERE (va_ide_mod = 3 AND va_ide_cla = 1)

IF (@va_nro_reg = 0)
	INSERT INTO ads011 VALUES (3, 1, 'Registra/Modifica Facturas Fuera Fecha', 'Registra/Modifica Facturas Fuera Fecha', 'S')

--** Anula Factura
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads011
 WHERE (va_ide_mod = 3 AND va_ide_cla = 2)

IF (@va_nro_reg = 0)
	INSERT INTO ads011 VALUES (3, 2, 'Anula Factura', 'Anula Factura', 'S')

--** Elimina Factura
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads011
 WHERE (va_ide_mod = 3 AND va_ide_cla = 3)

IF (@va_nro_reg = 0)
	INSERT INTO ads011 VALUES (3, 3, 'Elimina Factura', 'Anula Factura', 'S')

--** Permite Ventas Menores a lo permitido
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads011
 WHERE (va_ide_mod = 3 AND va_ide_cla = 4)

IF (@va_nro_reg = 0)
	INSERT INTO ads011 VALUES (3, 4, 'Permite Ventas Menores a lo permitido', 'Permite Ventas Menores a lo permitido', 'S')

--** Reemprimir Factura
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads011
 WHERE (va_ide_mod = 3 AND va_ide_cla = 5)

IF (@va_nro_reg = 0)
	INSERT INTO ads011 VALUES (3, 5, 'Reemprimir Factura', 'Reemprimir Factura', 'N')

/*************************************************/
/**            MODULO : TESORERIA               **/
/*************************************************/
--** Reapertura Caja Facturación
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads011 
 WHERE (va_ide_mod = 5 AND va_ide_cla = 1)

IF (@va_nro_reg = 0)
	INSERT INTO ads011 VALUES (5, 1, 'Reapertura Caja Facturación', 'Reapertura Caja Facturación', 'S')

--** Anula Recibo de Ingreso
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads011 
 WHERE (va_ide_mod = 5 AND va_ide_cla = 2)

IF (@va_nro_reg = 0)
	INSERT INTO ads011 VALUES (5, 2, 'Anula Recibo de Ingreso', 'Anula Recibo de Ingreso', 'S')

--** Elimina Recibo de Ingreso
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads011 
 WHERE (va_ide_mod = 5 AND va_ide_cla = 3)

IF (@va_nro_reg = 0)
	INSERT INTO ads011 VALUES (5, 3, 'Elimina Recibo de Ingreso', 'Anula Recibo de Ingreso', 'S')
	
GO

