/*--**********************************************
ARCHIVO:	ads011.sql	
TABLA:		Tabla de "Definicion Claves"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		20-10-2023
*/--**********************************************

PRINT 'ads011 : Definicion Claves'
CREATE TABLE ads011 
(
	--** Llave Primaria
	va_ide_mod	INT			NOT NULL DEFAULT(0),	--** ID. Módulo
	va_ide_cla	INT			NOT NULL DEFAULT(0),	--** ID. Clave
	--** Atributos
	va_nom_cla	VARCHAR(60)	 NOT NULL DEFAULT(''),	--** Nombre	
	va_obs_cla	VARCHAR(160) NOT NULL DEFAULT(''),	--** Observación
	va_cla_req	CHAR(01)	 NOT NULL DEFAULT('')	--** Clave Requerido (S=Si; N=No)

CONSTRAINT pk1_ads011 PRIMARY KEY(va_ide_mod, va_ide_cla)
)
GO

--** Módulo de Administracion y Seguridad
INSERT INTO ads011 VALUES (1, 1, 'Modifica Parametros Estructurales', 'Modifica Parametros Estructurales', 'S')
INSERT INTO ads011 VALUES (1, 2, 'Inicializa Contraseña Usuario', 'Inicializa Contraseña Usuario', 'S')
INSERT INTO ads011 VALUES (1, 3, 'Modifica PIN Usuario', 'Modifica PIN Usuario', 'S')
INSERT INTO ads011 VALUES (1, 4, 'Elimina Registro Usuario', 'Elimina Registro Usuario', 'S')
INSERT INTO ads011 VALUES (1, 5, 'Inicializa PIN Usuario', 'Inicializa PIN Usuario', 'S')
--** Módulo de Comercialización
INSERT INTO ads011 VALUES (3, 1, 'Registra/Modifica Facturas Fuera Fecha', 'Registra/Modifica Facturas Fuera Fecha', 'S')
INSERT INTO ads011 VALUES (3, 2, 'Anula Factura', 'Anula Factura', 'S')
INSERT INTO ads011 VALUES (3, 3, 'Elimina Factura', 'Anula Factura', 'S')
INSERT INTO ads011 VALUES (3, 4, 'Permite Ventas Menores a lo permitido', 'Permite Ventas Menores a lo permitido', 'S')
INSERT INTO ads011 VALUES (3, 5, 'Reemprimir Factura', 'Reemprimir Factura', 'S')
--** Módulo de Tesoreria
INSERT INTO ads011 VALUES (5, 1, 'Reapertura Caja Facturación', 'Reapertura Caja Facturación', 'S')
INSERT INTO ads011 VALUES (5, 2, 'Anula Recibo de Ingreso', 'Anula Recibo de Ingreso', 'S')
INSERT INTO ads011 VALUES (5, 3, 'Elimina Recibo de Ingreso', 'Anula Recibo de Ingreso', 'S')