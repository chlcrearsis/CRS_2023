/*--**********************************************
ARCHIVO:	ads100.sql	
TABLA:		Tabla de "Licencia del Sistema"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		21-08-2019
*/--**********************************************

PRINT 'ads100 : Licencia del Sistema'
CREATE TABLE ads100
(
	--** Llave Primaria
	va_ind_pri	INT			 NOT NULL DEFAULT(0),	--** ID. Principal
	va_ind_sec	INT			 NOT NULL DEFAULT(0),	--** ID. Secunadario
	--** Atributos
	va_nom_bre	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Nombre
	va_des_cri	VARCHAR(60)	 NOT NULL DEFAULT(''),	--** Descripcion

	CONSTRAINT pk1_ads100 PRIMARY KEY(va_ind_pri, va_ind_sec)
)
GO

--** INSERTA MODULO DEL SISTEMA POR DEFECTO
INSERT INTO ads100 VALUES (1, 1, 'Jj5QluOusIYVPYTdM2hbtdDTsl6ZrT', '')  --** Nombre Servidor
INSERT INTO ads100 VALUES (1, 2, 'A2wahsDvtOhDcSjGyIQ1sTPiVKpOsk', '')  --** Nombre Base de Datos
INSERT INTO ads100 VALUES (1, 3, 'GbBoIdvOUtsNKGqLXoySdeOSBo4dUj', '')  --** Nro. Usuario
INSERT INTO ads100 VALUES (1, 4, 'KXJfyoHpaqpaISNIgfKH2Zze73vZ3B', '')  --** Fecha Expiracion
INSERT INTO ads100 VALUES (2, 1, 'SWaNCj6X3WDAW2rEdEU2XHASc3hAdS', '')  --** Módulo ADS: 1024 -> Administrador
INSERT INTO ads100 VALUES (2, 2, 'Dcbmm8iBaurRjF6eHsJkijLlR9VInV', '')  --** Módulo INV: 2048 -> Inventario
INSERT INTO ads100 VALUES (2, 3, 'KeHthL6b4J525tP1qiq8wgvgzpfCmR', '')  --** Módulo CMR: 3072 -> Comercialización
INSERT INTO ads100 VALUES (2, 4, 'LO2FoI0phSd7597DTLm5fX9BHOACtB', '')  --** Módulo CTB: 4096 -> Contabilidad
INSERT INTO ads100 VALUES (2, 5, 'SUjBKrqFbYt8CZQWaXNbIATFatpTeS', '')  --** Módulo TES: 5120 -> Tesoreria
INSERT INTO ads100 VALUES (2, 6, 'TNarguMK1Yc9twZNSs1+E6YKDTwReS', '')  --** Módulo RES: 6144 -> Restaurant

