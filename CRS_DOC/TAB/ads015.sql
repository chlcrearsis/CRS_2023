/*--**********************************************
ARCHIVO:	ads015.sql	
TABLA:		Tabla de "Regiónal"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		06-11-2029
*/--**********************************************

PRINT 'ads015 : Regional'
CREATE TABLE ads015
(
	--** Llave Primaria
	va_ide_reg 	INT			 NOT NULL DEFAULT(0),	--** ID. Regional
	--** Atributos
	va_nom_reg	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Nombre
	va_nom_cor  VARCHAR(10)  NOT NULL DEFAULT(''),  --** Nombre Corto
	va_est_ado	CHAR(01)	 NOT NULL DEFAULT(''),	--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_ads015 PRIMARY KEY(va_ide_reg)
)
GO

--** Registro por Defecto
INSERT INTO ads015 VALUES (1, 'Central', 'Central', 'V')