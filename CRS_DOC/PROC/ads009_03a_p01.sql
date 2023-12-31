/********************************************************************/
/*	ARCHIVO: ads009_03a_p01.sql                                     */
/*	PROCEDIMIENTO: PERMISO TIPO DE USUARIO SOBRE PLANTILLA DE VENTA */
/*  PARAMETROS:   @ar_ide_tus  INT  --** ID. Usuario                */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 31/08/2023                */
/********************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads009_03a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads009_03a_p01
GO

CREATE PROCEDURE ads009_03a_p01		@ar_ide_tus  INT	WITH ENCRYPTION AS

DECLARE		@va_cod_pdv  INT,        	--** Código
			@va_nom_pdv	 VARCHAR(30),	--** Nombre
			@va_des_pdv	 VARCHAR(60),	--** Descripción
			@va_nro_reg  INT,           --** Nro. Registro
			@va_per_mis  CHAR(01)  	    --** Permiso Registro
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_per_pdv
(
	va_cod_pdv	CHAR(03),
    va_nom_pdv	VARCHAR(30),
	va_des_pdv	VARCHAR(60),
	va_per_mis  CHAR(01)
)

--** Obtiene los datos de las aplicaciones del sistema
DECLARE vc_per_pdv CURSOR LOCAL FOR
 SELECT va_cod_plv, va_nom_plv, va_des_plv
   FROM cmr004
  WHERE va_est_ado = 'H'

--** Abre Cursor
OPEN vc_per_pdv
--** Lee el primer registro
FETCH NEXT FROM vc_per_pdv INTO @va_cod_pdv, @va_nom_pdv, @va_des_pdv
														
WHILE (@@FETCH_STATUS = 0)
BEGIN
	--** Verifica si tiene habilitado el usuario ese permiso
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads009
	 WHERE va_ide_tab = 'cmr004'
	   AND va_ide_uno = @va_cod_pdv
	   AND va_ide_tus = @ar_ide_tus

	IF (@va_nro_reg = 0)
		SET @va_per_mis = 'N'
	ELSE
		SET @va_per_mis = 'S'

	--** Inserta en la tabla temporal
	INSERT INTO #tm_per_pdv VALUES (@va_cod_pdv, @va_nom_pdv, @va_des_pdv, @va_per_mis)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_per_pdv INTO @va_cod_pdv, @va_nom_pdv, @va_des_pdv
END	

CLOSE vc_per_pdv
DEALLOCATE vc_per_pdv


--** Retorna los datos
SELECT va_cod_pdv, va_nom_pdv, va_des_pdv, 
       va_per_mis
  FROM #tm_per_pdv
 ORDER BY va_cod_pdv
