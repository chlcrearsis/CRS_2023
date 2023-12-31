/*****************************************************************/
/*	ARCHIVO: ads008_09a_p01.sql                                  */
/*	PROCEDIMIENTO: PERMISO USUARIO SOBRE GRUPO DE BODEGA         */
/*  PARAMETROS:   @ar_ide_usr  CHAR(16)  --** ID. Usuario        */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 30/08/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads008_09a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads008_09a_p01
GO

CREATE PROCEDURE ads008_09a_p01		@ar_ide_usr  CHAR(16)	WITH ENCRYPTION AS

DECLARE		@va_ide_gru  INT,			--** ID. Grupo Bodega
            @va_nom_gru	 VARCHAR(30),   --** Nombre Grupo Bodega
			@va_nro_reg  INT,           --** Nro. Registro
			@va_per_mis  CHAR(01)  	    --** Permiso Registro
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_per_gdb
(
	va_ide_gru  INT,
    va_nom_gru	VARCHAR(30),
	va_per_mis  CHAR(01)
)

--** Obtiene los datos de las aplicaciones del sistema
DECLARE vc_per_gdb CURSOR LOCAL FOR
 SELECT va_ide_gru, va_nom_gru
   FROM inv001
  WHERE va_est_ado = 'H'      

--** Abre Cursor
OPEN vc_per_gdb
--** Lee el primer registro
FETCH NEXT FROM vc_per_gdb INTO @va_ide_gru, @va_nom_gru
														
WHILE (@@FETCH_STATUS = 0)
BEGIN
	--** Verifica si tiene habilitado el usuario ese permiso
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads008
	 WHERE va_ide_tab = 'inv001'
	   AND va_ide_uno = @va_ide_gru
	   AND va_ide_usr = @ar_ide_usr

	IF (@va_nro_reg = 0)
		SET @va_per_mis = 'N'
	ELSE
		SET @va_per_mis = 'S'

	--** Inserta en la tabla temporal
	INSERT INTO #tm_per_gdb VALUES (@va_ide_gru, @va_nom_gru, @va_per_mis)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_per_gdb INTO @va_ide_gru, @va_nom_gru
END	

CLOSE vc_per_gdb
DEALLOCATE vc_per_gdb

--** Retorna los datos
SELECT va_ide_gru, va_nom_gru, va_per_mis
  FROM #tm_per_gdb
 ORDER BY va_ide_gru
