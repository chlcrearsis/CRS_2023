/*--**********************************************
ARCHIVO:	ads022.sql	
TABLA:		Tabla de "Tasa de Cambio Bs/Us"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		22-04-2021
*/--**********************************************

PRINT 'ads022 : Tasa de Cambio Bs/Us'
CREATE TABLE ads022
(
	--** Llave Primaria
	va_fec_tas	DATETIME	 NOT NULL,				--** Fecha 
	--** Atributos     	
	va_tas_cam	DECIMAL(8,4) NOT NULL DEFAULT(0)	--** T.C (Bs; Us)

CONSTRAINT pk1_ads022 PRIMARY KEY(va_fec_tas)
)
GO
