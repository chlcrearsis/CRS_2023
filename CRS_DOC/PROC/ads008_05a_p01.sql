/*****************************************************************/
/*	ARCHIVO: ads008_05a_p01.sql                                  */
/*	PROCEDIMIENTO: PERMISO USUARIO SOBRE BODEGA                  */
/*  PARAMETROS:   @ar_ide_usr  CHAR(16)  --** ID. Usuario        */
/*                @ar_grp_bod  INT       --** ID. Grupo Bodega   */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 30/08/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads008_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads008_05a_p01
GO

CREATE PROCEDURE ads008_05a_p01		@ar_ide_usr  CHAR(16),
                                    @ar_grp_bod  INT	WITH ENCRYPTION AS

DECLARE		@va_ide_gru  INT,           --** ID. Grupo Bodega
  		    @va_nom_gru  VARCHAR(30),   --** Nombre Grupo Bodega
            @va_cod_bod  INT,           --** Código Bodega
			@va_nom_bod	 VARCHAR(60),	--** Nombre Bodega
			@va_nro_reg  INT,           --** Nro. Registro
			@va_per_mis  CHAR(01)  	    --** Permiso Registro
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_per_bod
(	
	va_cod_bod  INT,
	va_nom_bod	VARCHAR(60),
	va_ide_gru  INT,
	va_nom_gru	VARCHAR(30),
	va_per_mis  CHAR(01)
)

--** Obtiene los datos de las aplicaciones del sistema
DECLARE vc_per_bod CURSOR LOCAL FOR
 SELECT va_ide_gru, va_cod_bod, va_nom_bod
   FROM inv002
  WHERE va_est_ado = 'H'      

--** Abre Cursor
OPEN vc_per_bod
--** Lee el primer registro
FETCH NEXT FROM vc_per_bod INTO @va_ide_gru, @va_cod_bod, @va_nom_bod
														
WHILE (@@FETCH_STATUS = 0)
BEGIN
	--** Obtiene el nombre del grupo bodega
	SELECT @va_nom_gru = va_nom_gru
	  FROM inv001
	 WHERE va_ide_gru = @va_ide_gru

	IF (@@ROWCOUNT = 0)
		SET @va_nom_gru = ''

	--** Verifica si tiene habilitado el usuario ese permiso
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads008
	 WHERE va_ide_tab = 'inv002'
	   AND va_ide_uno = @va_cod_bod
	   AND va_ide_usr = @ar_ide_usr

	IF (@va_nro_reg = 0)
		SET @va_per_mis = 'N'
	ELSE
		SET @va_per_mis = 'S'

	--** Inserta en la tabla temporal
	INSERT INTO #tm_per_bod VALUES (@va_cod_bod, @va_nom_bod, @va_ide_gru, @va_nom_gru, @va_per_mis)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_per_bod INTO @va_ide_gru, @va_cod_bod, @va_nom_bod
END	

CLOSE vc_per_bod
DEALLOCATE vc_per_bod


--** Retorna los datos
IF (@ar_grp_bod = 0)
BEGIN
	SELECT va_cod_bod, va_nom_bod, va_ide_gru, 
	       va_nom_gru, va_per_mis
	 FROM #tm_per_bod
	ORDER BY va_ide_gru, va_cod_bod
END
ELSE
BEGIN
	SELECT va_cod_bod, va_nom_bod, va_ide_gru, 
	       va_nom_gru, va_per_mis
	 FROM #tm_per_bod
	WHERE va_ide_gru = @ar_grp_bod
	ORDER BY va_ide_gru, va_cod_bod  
END
