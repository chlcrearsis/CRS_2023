/*--**********************************************
ARCHIVO:	ads025.sql	
TABLA:		Tabla de "Validación Clave Usuario"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		13-01-2024
*/--**********************************************

PRINT 'Crea la Tabla: ads025 - Validación Clave Usuario'
CREATE TABLE ads025 
(
	--** Llave Primaria
	va_ide_usr 	VARCHAR(15)  NOT NULL DEFAULT(''),	--** ID. Usuario
	va_fch_reg  DATETIME     NOT NULL,				--** Fecha y Hora de Registro
	--** Atributos     	
	va_usr_sol 	VARCHAR(15)  NOT NULL DEFAULT(''),	--** ID. Usuario Solicitante
	va_ide_mod  INT          NOT NULL DEFAULT(0),	--** ID. Módulo	
	va_ide_cla  INT          NOT NULL DEFAULT(0),	--** ID. Clave	
	va_nom_maq  VARCHAR(30)  NOT NULL DEFAULT(''),	--** Nombre PC-Maquina
	va_obs_reg  VARCHAR(60)  NOT NULL DEFAULT(''),	--** Observación
	

	CONSTRAINT pk1_ads025 PRIMARY KEY(va_ide_usr, va_fch_reg)
)
GO