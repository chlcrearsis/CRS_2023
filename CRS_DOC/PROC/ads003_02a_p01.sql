/*****************************************************************/
/*	ARCHIVO: ads003_02a_p01.sql                                  */
/*	PROCEDIMIENTO: REGISTRA DOCUMENTOS POR DEFECTOS              */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 14/06/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads003_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads003_02a_p01
GO

CREATE PROCEDURE ads003_02a_p01	WITH ENCRYPTION AS

DECLARE		@va_nro_reg	 INT	--** Nro. Registro
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

/*************************************************/
/**               MODULO INVENTARIO             **/
/*************************************************/
--** Compra en Bodega
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 2 AND va_ide_doc = 'CMP')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(2, 'CMP', 'Compra en Bodega', 'Compra en Bodega', 'H')

--** Ajuste de Ingreso
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 2 AND va_ide_doc = 'AJI')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(2, 'AJI', 'Ajuste de Ingreso', 'Ajuste de Ingreso', 'H')

--** Ajuste de Salida
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 2 AND va_ide_doc = 'AJE')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(2, 'AJE', 'Ajuste de Salida', 'Ajuste de Salida', 'H')

--** Ajuste al Costo
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 2 AND va_ide_doc = 'AJC')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(2, 'AJC', 'Ajuste al Costo', 'Ajuste al Costo', 'H')

--** Traspaso entre Bodegas
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 2 AND va_ide_doc = 'TRA')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(2, 'TRA', 'Traspaso entre Bodegas', 'Traspaso entre Bodegas', 'H')

--** Orden de Producción
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 2 AND va_ide_doc = 'OPD')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(2, 'OPD', 'Orden de Producción', 'Orden de Producción', 'H')

/*************************************************/
/**            MODULO COMERCIALIZACIÓN          **/
/*************************************************/
--** Cotización
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 3 AND va_ide_doc = 'COT')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(3, 'COT', 'Cotización', 'Cotización', 'H')

--** Pedido
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 3 AND va_ide_doc = 'PED')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(3, 'PED', 'Pedido', 'Pedido', 'H')

--** Nota de Venta
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 3 AND va_ide_doc = 'VTS')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(3, 'VTS', 'Nota de Venta', 'Nota de Venta', 'H')

--** Factura
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 3 AND va_ide_doc = 'VTF')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(3, 'VTF', 'Factura', 'Factura', 'H')

--** Nota de Venta Restaurant
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 3 AND va_ide_doc = 'VRS')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(3, 'VRS', 'Nota de Venta Restaurant', 'Nota de Venta Restaurant', 'H')

--** Factura Restaurant
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 3 AND va_ide_doc = 'VRF')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(3, 'VRF', 'Factura Restaurant', 'Factura Restaurant', 'H')

--** Nota de Consumo
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 3 AND va_ide_doc = 'CON')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(3, 'CON', 'Nota de Consumo', 'Nota de Consumo', 'H')

/*************************************************/
/**                MODULO EXIGIBLE              **/
/*************************************************/
--** Ctas por Cobrar
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 4 AND va_ide_doc = 'CXC')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(4, 'CXC', 'Ctas por Cobrar', 'Ctas por Cobrar', 'H')

--** Ctas por Pagar
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 4 AND va_ide_doc = 'CXP')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(4, 'CXP', 'Ctas por Pagar', 'Ctas por Pagar', 'H')

--** Diario Auxiliar
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 4 AND va_ide_doc = 'DAU')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(4, 'DAU', 'Diario Auxiliar', 'Diario Auxiliar', 'H')

/*************************************************/
/**               MODULO TESORERIA              **/
/*************************************************/
--** Recibo de Ingreso
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 5 AND va_ide_doc = 'RIN')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(5, 'RIN', 'Recibo de Ingreso', 'Recibo de Ingreso', 'H')

--** Recibo de Egreso
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 5 AND va_ide_doc = 'REG')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(5, 'REG', 'Recibo de Egreso', 'Recibo de Egreso', 'H')

--** Comprobante de Ingreso
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 5 AND va_ide_doc = 'TIN')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(5, 'TIN', 'Comprobante de Ingreso', 'Comprobante de Ingreso', 'H')

--** Comprobante de Egreso
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*) 
  FROM ads003 
 WHERE (va_ide_mod = 5 AND va_ide_doc = 'TEG')

IF (@va_nro_reg = 0)
	INSERT INTO ads003 VALUES(5, 'TEG', 'Comprobante de Egreso', 'Comprobante de Egreso', 'H')

GO

