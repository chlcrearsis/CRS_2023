/*--**********************************************
ARCHIVO:	ads007.sql	
TABLA:		Tabla de "Usuario"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		06-11-2019
*/--**********************************************

PRINT 'Crea la Tabla: ads007 - Usuario'
CREATE TABLE ads007
(
	--** Llave Primaria
	va_ide_usr 	VARCHAR(15)  NOT NULL DEFAULT(''),	--** ID. Usuario
	--** Atributos
	va_nom_usr	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Nombre
	va_tel_usr	VARCHAR(15)	 NOT NULL DEFAULT(''),	--** Tel�fono
	va_car_usr	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Cargo
	va_dir_tra	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Directorio de Trabajo
	va_ema_usr	VARCHAR(90)	 NOT NULL DEFAULT(''),	--** Email
	va_ven_max	INT			 NOT NULL DEFAULT(0),	--** Nro. Maximo de Ventanas Abierta
	va_ide_per	INT			 NOT NULL DEFAULT(0),	--** ID. Persona Asociada
	va_ide_tus	INT			 NOT NULL DEFAULT(0),	--** ID. Tipo de Usuario
	va_est_ado	CHAR(01)	 NOT NULL DEFAULT(''),	--** Estado (H=habilitado; N=deshabilitado)

CONSTRAINT pk1_ads007 PRIMARY KEY(va_ide_usr)
)
GO