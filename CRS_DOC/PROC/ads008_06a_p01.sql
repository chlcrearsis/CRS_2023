/*****************************************************************/
/*	ARCHIVO: ads008_06a_p01.sql                                  */
/*	PROCEDIMIENTO: PERMISO USUARIO SOBRE GRUPO DE PERSONA        */
/*  PARAMETROS:   @ar_ide_usr  CHAR(16)  --** ID. Usuario        */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 30/08/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads008_06a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads008_06a_p01
GO

CREATE PROCEDURE ads008_06a_p01		@ar_ide_usr  CHAR(16)	WITH ENCRYPTION AS

DECLARE		@va_cod_gru  INT,			--** ID. Grupo Persona
            @va_nom_gru	 VARCHAR(30),   --** Nombre Grupo Persona
			@va_nro_reg  INT,           --** Nro. Registro
			@va_per_mis  CHAR(01)  	    --** Permiso Registro
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_per_grp
(
	va_cod_gru  INT,
    va_nom_gru	VARCHAR(30),
	va_per_mis  CHAR(01)
)

--** Obtiene los datos de las aplicaciones del sistema
DECLARE vc_per_grp CURSOR LOCAL FOR
 SELECT va_cod_gru, va_nom_gru
   FROM adp001
  WHERE va_est_ado = 'H'      

--** Abre Cursor
OPEN vc_per_grp
--** Lee el primer registro
FETCH NEXT FROM vc_per_grp INTO @va_cod_gru, @va_nom_gru
														
WHILE (@@FETCH_STATUS = 0)
BEGIN
	--** Verifica si tiene habilitado el usuario ese permiso
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads008
	 WHERE va_ide_tab = 'adp001'
	   AND va_ide_uno = @va_cod_gru
	   AND va_ide_usr = @ar_ide_usr

	IF (@va_nro_reg = 0)
		SET @va_per_mis = 'N'
	ELSE
		SET @va_per_mis = 'S'

	--** Inserta en la tabla temporal
	INSERT INTO #tm_per_grp VALUES (@va_cod_gru, @va_nom_gru, @va_per_mis)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_per_grp INTO @va_cod_gru, @va_nom_gru
END	

CLOSE vc_per_grp
DEALLOCATE vc_per_grp

--** Retorna los datos
SELECT va_cod_gru, va_nom_gru, va_per_mis
  FROM #tm_per_grp
 ORDER BY va_cod_gru
