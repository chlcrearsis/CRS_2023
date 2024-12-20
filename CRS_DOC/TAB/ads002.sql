/*--**********************************************
ARCHIVO:	ads002.sql	
TABLA:		Tabla de "Aplicaciones"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		21-08-2019
*/--**********************************************

PRINT 'Crea la Tabla: ads002 - Aplicaciones'
CREATE TABLE ads002
(
	--** Llave Primaria
	va_ide_mod	INT			 NOT NULL DEFAULT(0),	--** ID. Módulo
	va_ide_apl	CHAR(06)	 NOT NULL DEFAULT(''),	--** ID. Aplicación
	--** Atributos
	va_nom_apl	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Nombre Aplicación
	va_est_ado	CHAR(01)	 NOT NULL DEFAULT(''),	--** Estado (H=Habilitado; N=Deshabilitado)

	CONSTRAINT pk1_ads002 PRIMARY KEY(va_ide_mod,va_ide_apl)
)
GO

--** INSERTA APLICACIONES DEL SISTEMA POR DEFECTO
INSERT INTO ads002 VALUES (1, 'ads200', 'Administrador', 'H')
INSERT INTO ads002 VALUES (2, 'inv200', 'Inventario', 'H')
INSERT INTO ads002 VALUES (3, 'cmr200', 'Comercialización', 'H')
INSERT INTO ads002 VALUES (3, 'res200', 'Restaurant', 'H')
INSERT INTO ads002 VALUES (4, 'ctb200', 'Contabilidad', 'H')
INSERT INTO ads002 VALUES (5, 'tes200', 'Tesorería', 'H')




