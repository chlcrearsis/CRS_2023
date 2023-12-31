/*****************************************************************/
/*	ARCHIVO: ads008_04a_p01.sql                                  */
/*	PROCEDIMIENTO: PERMISO USUARIO SOBRE LISTA DE PRECIO         */
/*  PARAMETROS:   @ar_ide_usr  CHAR(16)  ID. Usuario             */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 31/08/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads008_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads008_04a_p01
GO

CREATE PROCEDURE ads008_04a_p01		@ar_ide_usr  CHAR(16)	WITH ENCRYPTION AS

DECLARE		@va_cod_lis  INT,        	--** Código Lista
			@va_nom_lis	 VARCHAR(30),	--** Nombre Lista
			@va_mon_lis	 VARCHAR(10),	--** Moneda (B=Bolivianos; U=Dolares)
			@va_nro_reg  INT,           --** Nro. Registro
			@va_per_mis  CHAR(01)  	    --** Permiso Registro
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_per_ldp
(
	va_cod_lis	INT,
    va_nom_lis	VARCHAR(30),
	va_mon_lis	VARCHAR(10),
	va_per_mis  CHAR(01)
)

--** Obtiene los datos de las aplicaciones del sistema
DECLARE vc_per_ldp CURSOR LOCAL FOR
 SELECT va_cod_lis, va_nom_lis, 
		CASE WHEN va_mon_lis = 'B'
		    THEN 'Bolivianos' 
		    ELSE 'Dolares' 
	    END AS va_mon_lis
   FROM cmr001
  WHERE va_est_ado = 'H'

--** Abre Cursor
OPEN vc_per_ldp
--** Lee el primer registro
FETCH NEXT FROM vc_per_ldp INTO @va_cod_lis, @va_nom_lis, @va_mon_lis
														
WHILE (@@FETCH_STATUS = 0)
BEGIN
	--** Verifica si tiene habilitado el usuario ese permiso
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads008
	 WHERE va_ide_tab = 'cmr001'
	   AND va_ide_uno = @va_cod_lis
	   AND va_ide_usr = @ar_ide_usr

	IF (@va_nro_reg = 0)
		SET @va_per_mis = 'N'
	ELSE
		SET @va_per_mis = 'S'

	--** Inserta en la tabla temporal
	INSERT INTO #tm_per_ldp VALUES (@va_cod_lis, @va_nom_lis, @va_mon_lis, @va_per_mis)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_per_ldp INTO @va_cod_lis, @va_nom_lis, @va_mon_lis
END	

CLOSE vc_per_ldp
DEALLOCATE vc_per_ldp


--** Retorna los datos
SELECT va_cod_lis, va_nom_lis, va_mon_lis, 
       va_per_mis
  FROM #tm_per_ldp
 ORDER BY va_cod_lis
