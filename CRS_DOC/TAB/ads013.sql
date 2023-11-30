/*--**********************************************
ARCHIVO:	ads013.sql	
TABLA:		Tabla de "Globales"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		06-11-2029
*/--**********************************************

PRINT 'ads013 : Globales'
CREATE TABLE ads013
(
	--** Llave Primaria
	va_ide_mod	INT			 NOT NULL DEFAULT(0),	--** ID. Módulo (ads001)
    va_ide_glo	INT			 NOT NULL DEFAULT(0),	--** ID. Global
	--** Atributos
    va_nom_glo	VARCHAR(60)	 NOT NULL DEFAULT(''),	--** Nombre
    va_tip_glo	INT			 NOT NULL DEFAULT(0),	--** Tipo Global (0=Numérico; 1=Decimal; 2=Caracter)    											
    va_glo_ent 	INT 		 NOT NULL DEFAULT(0),	--** Global Numérico
    va_glo_dec	DEC(18,5)    NOT NULL DEFAULT(0),	--** Global Decimal
	va_glo_car	VARCHAR(120) NOT NULL DEFAULT(''),	--** Global Caracter

CONSTRAINT pk1_ads013 PRIMARY KEY(va_ide_mod, va_ide_glo)
)
GO

--** Módulo: Administración y Seguridad
INSERT INTO ads013 VALUES (1, 1, 'Razon Social Empresa', 2, 0, 0.00000, 'Empresa S.R.L.')
INSERT INTO ads013 VALUES (1, 2, 'Representante Legal', 2, 0, 0.00000, 'Nombre Representante')
INSERT INTO ads013 VALUES (1, 3, 'NIT de la empresa', 1, 0.00000, 123456789, '')
INSERT INTO ads013 VALUES (1, 4, 'Telefono fijo', 2, 0, 0.00000, '33-333333')
INSERT INTO ads013 VALUES (1, 5, 'Telefono Celular', 2, 0, 0.00000, '999-99999')
INSERT INTO ads013 VALUES (1, 6, 'Email', 2, 0, 0.00000, 'empresa@gmail.com')
INSERT INTO ads013 VALUES (1, 7, 'Dirección', 2, 0, 0.00000, 'Direccion')
INSERT INTO ads013 VALUES (1, 8, 'Clave Wifi', 2, 0, 0.00000, 'Wifi123.')
INSERT INTO ads013 VALUES (1, 9, 'Logo Empresa', 2, 0, 0.00000, '')
INSERT INTO ads013 VALUES (1, 10, 'Logo B', 2, 0, 0.00000, '')
INSERT INTO ads013 VALUES (1, 11, 'Logo C', 2, 0, 0.00000, '')
INSERT INTO ads013 VALUES (1, 12, 'Logo D', 2, 0, 0.00000, '')
INSERT INTO ads013 VALUES (1, 20, 'Longitud Mínima Contraseña Usuario', 0, 4, 0.00000,'')
INSERT INTO ads013 VALUES (1, 21, 'Contraseña por defecto', 2, 0, 0.00000,'Contra123.')
INSERT INTO ads013 VALUES (1, 100, 'Versión del sistema', 2, 0, 0.00000, '1.0.0')
--** Módulo: Comercialización
INSERT INTO ads013 VALUES (3, 1, 'Formulario Ventas', 2, 0, 0.00000, 'Normal')  --** 1=Normal ; 2=Tactil
INSERT INTO ads013 VALUES (3, 2, 'Productos Farmacia', 2, 0, 0.00000, 'Normal') --** 1=Normal ; 2=Farmacia
--** Módulo: Contabilidad
INSERT INTO ads013 VALUES (4, 1, 'Gestión', 0, 2023, 0.00000, '')
INSERT INTO ads013 VALUES (4, 2, 'Periodo', 0, 11, 0.00000, '')

delete ads013
GO