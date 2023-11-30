/*--**********************************************
ARCHIVO:	ads015.sql	
TABLA:		Tabla de "Región"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		06-11-2029
*/--**********************************************

PRINT 'ads015 : Región'
CREATE TABLE ads015
(
	--** Llave Primaria
	va_ide_mod	INT			 NOT NULL DEFAULT(0),	--** ID. Módulo (ads001)
	--** Atributos
	va_ide_reg 	INT			 NOT NULL DEFAULT(0),	--** ID. Región
	va_nom_reg	VARCHAR(30)	 NOT NULL DEFAULT(0),	--** Nombre
	va_est_ado	CHAR(01)	 NOT NULL DEFAULT(0),	--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_ads015 PRIMARY KEY(va_ide_reg)
)
GO