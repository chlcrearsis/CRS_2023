/*--**********************************************
ARCHIVO:	ads018.sql	
TABLA:		Tabla de "Autorizacion Usuario s/Plantilla de Ventas
            p/Restaurant (res004)"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		27-10-2020
*/--**********************************************

PRINT 'ads018 : Autorizacion Usuario s/Plantilla de Ventas p/Restaurant'
CREATE TABLE ads018
(
	--** Llave Primaria
	va_ide_usr	VARCHAR(15)	 NOT NULL DEFAULT(''),	--** ID. Usuario
	va_cod_plv	INT	 		 NOT NULL DEFAULT(0),	--** Codigo de la plantilla

CONSTRAINT pk1_ads018 PRIMARY KEY(va_ide_usr, va_cod_plv)
)
GO


