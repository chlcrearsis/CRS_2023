/*--**********************************************
ARCHIVO:	ads018.sql	
TABLA:		Tabla de "Bitacora de Inicio de Sesion"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		10-01-2024
*/--**********************************************

PRINT 'Crea la Tabla: ads018 - Bitacora de Inicio de Sesion'
CREATE TABLE ads018 
(
	--** Llave Primaria
	va_ide_uni  CHAR(32)     NOT NULL DEFAULT(''),  --** Identificador Unico
	--** Atributos     
	va_ide_usr 	VARCHAR(15)  NOT NULL DEFAULT(''),	--** Identificador Usuario
	va_fec_reg	DATETIME     NOT NULL,				--** Fecha Actual Sin hh:MM:ss
	va_nom_maq  VARCHAR(30)  NOT NULL DEFAULT(''),  --** Nombre de la Maquina
	va_fec_ini  DATETIME     NOT NULL,              --** Fecha y Hora de Inicio
	va_fec_fin  DATETIME,                           --** Fecha y Hora de Cierre

CONSTRAINT pk1_ads018 PRIMARY KEY(va_ide_uni)
)
GO