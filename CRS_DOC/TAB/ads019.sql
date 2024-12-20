/*--**********************************************
ARCHIVO:	ads025.sql	
TABLA:		Tabla de "Bitacora de Operaciones"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		23-09-2021
*/--**********************************************

PRINT 'Crea la Tabla: ads019 - Bitacora de Operaciones'
CREATE TABLE ads019 
(
	--** Llave Primaria
	va_ide_usr 	VARCHAR(15)  NOT NULL DEFAULT(''),	--** ID. Usuario
	va_fch_reg  DATETIME     NOT NULL,				--** Fecha y Hora de Registro
	--** Atributos     
	va_ide_mod  INT          NOT NULL DEFAULT(0),   --** ID. Módulo
	va_ide_apl  VARCHAR(12)  NOT NULL DEFAULT(''),	--** ID. Aplicación
	va_nom_apl  VARCHAR(60)  NOT NULL DEFAULT(''),	--** Nombre Aplicación
	va_tip_ope  CHAR(01)     NOT NULL DEFAULT(''),	--** Tipo de Operación 
	                                                --** (N=Nuevo; E=Edita; H=Habilita; D=Deshabilita; A=Anula; L=Elimina; 
													--**  C=Concluye; P=Aprueba; R=Rechaza; M=Importa; X=Exporta; I=Informe)	
	va_obs_reg  VARCHAR(120) NOT NULL DEFAULT(''),	--** Observación
	va_nom_maq  VARCHAR(30)  NOT NULL DEFAULT(''),	--** Nombre de la Maquina

	CONSTRAINT pk1_ads019 PRIMARY KEY(va_ide_usr, va_fch_reg)
)
GO