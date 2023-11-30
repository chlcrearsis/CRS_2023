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
	va_des_cla	VARCHAR(120) NOT NULL DEFAULT(''),	--** Descripción
	va_cla_req	CHAR(01)	 NOT NULL DEFAULT('')	--** Clave Requerido (S=Si; N=No)

CONSTRAINT pk1_ads011 PRIMARY KEY(va_ide_mod, va_ide_cla)
)
GO


--** Inserta registros por defectos
INSERT INTO ads011 VALUES (1, 1, 'Elimina Registros Tablas', 'Elimina Registros Tablas', 'S')
INSERT INTO ads011 VALUES (1, 2, 'Modifica Parametros Estructurales', 'Modifica Parametros Estructurales', 'S')
INSERT INTO ads011 VALUES (1, 3, 'Inicializa Contraseña Usuario', 'Inicializa Contraseña Usuario', 'S')
INSERT INTO ads011 VALUES (1, 4, 'Modifica PIN Usuario', 'Modifica PIN Usuario', 'S')
INSERT INTO ads011 VALUES (1, 5, 'Inicializa PIN Usuario', 'Inicializa PIN Usuario', 'S')