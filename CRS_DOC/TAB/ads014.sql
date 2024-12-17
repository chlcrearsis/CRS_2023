/*--**********************************************
ARCHIVO:	ads014.sql	
TABLA:		Tabla de "Clave Usuario p/Global"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		06-11-2029
*/--**********************************************

PRINT 'Crea la Tabla: ads014 - Clave Usuario p/Global'
CREATE TABLE ads014
(
	--** Llave Primaria
	va_ide_usr 	VARCHAR(15)  NOT NULL DEFAULT(''),	--** ID. Usuario
	va_ide_mod	INT			 NOT NULL DEFAULT(0),	--** ID. Módulo
	va_ide_cla  INT          NOT NULL DEFAULT(0),   --** ID. Global
	--** Atributos
	va_cla_usr 	VARCHAR(15)  NOT NULL DEFAULT(0),	--** Clave del Usuario
	va_fec_reg	DATETIME,	                        --** Fecha Registro

CONSTRAINT pk1_ads014 PRIMARY KEY(va_ide_usr, va_ide_mod, va_ide_cla)
)
GO