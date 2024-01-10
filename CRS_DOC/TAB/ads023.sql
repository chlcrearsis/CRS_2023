/*--**********************************************
ARCHIVO:	ads023.sql	
TABLA:		Tabla de "Tasa de Cambio Bs/Ufv"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		22-04-2021
*/--**********************************************

PRINT 'ads023 : Tasa de Cambio Bs/Ufv'
CREATE TABLE ads023
(
	--** Llave Primaria
	va_fec_tas	DATETIME	 NOT NULL,				--** Fecha 
	--** Atributos     	
	va_tas_cam	DECIMAL(8,4) NOT NULL DEFAULT(0)	--** Tasa de Cambio Bs/Ufv

CONSTRAINT pk1_ads023 PRIMARY KEY(va_fec_tas)
)
GO