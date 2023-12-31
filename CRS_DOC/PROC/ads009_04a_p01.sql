/*****************************************************************/
/*	ARCHIVO: ads009_04a_p01.sql                                  */
/*	PROCEDIMIENTO: PERMISO TIPO USUARIO SOBRE LISTA DE PRECIO    */
/*  PARAMETROS:   @ar_ide_tus  INT	--** ID. Tipo Usuario        */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 31/08/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads009_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads009_04a_p01
GO

CREATE PROCEDURE ads009_04a_p01		@ar_ide_tus  INT	WITH ENCRYPTION AS

DECLARE		@va_cod_lis  INT,        	--** Código
			@va_nom_lis	 VARCHAR(30),	--** Nombre
			@va_mon_lis	 VARCHAR(10),	--** Moneda (B=Boliviano; U=Dolares)
			@va_nro_reg  INT,           --** Nro. Registro
			@va_per_mis  CHAR(01)  	    --** Permiso Registro
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_per_lis
(
	va_cod_lis	INT,
    va_nom_lis	VARCHAR(30),
	va_mon_lis	VARCHAR(10),
	va_per_mis  CHAR(01)
)

--** Obtiene los datos de las aplicaciones del sistema
DECLARE vc_per_lis CURSOR LOCAL FOR
 SELECT va_cod_lis, va_nom_lis, 
		CASE WHEN va_mon_lis = 'B'
		    THEN 'Bolivianos' 
		    ELSE 'Dolares' 
	    END AS va_nom_lis
   FROM cmr001
  WHERE va_est_ado = 'H'

--** Abre Cursor
OPEN vc_per_lis
--** Lee el primer registro
FETCH NEXT FROM vc_per_lis INTO @va_cod_lis, @va_nom_lis, @va_mon_lis
														
WHILE (@@FETCH_STATUS = 0)
BEGIN
	--** Verifica si tiene habilitado el usuario ese permiso
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads009
	 WHERE va_ide_tab = 'cmr001'
	   AND va_ide_uno = @va_cod_lis
	   AND va_ide_tus = @ar_ide_tus

	IF (@va_nro_reg = 0)
		SET @va_per_mis = 'N'
	ELSE
		SET @va_per_mis = 'S'

	--** Inserta en la tabla temporal
	INSERT INTO #tm_per_lis VALUES (@va_cod_lis, @va_nom_lis, @va_mon_lis, @va_per_mis)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_per_lis INTO @va_cod_lis, @va_nom_lis, @va_mon_lis
END	

CLOSE vc_per_lis
DEALLOCATE vc_per_lis


--** Retorna los datos
SELECT va_cod_lis, va_nom_lis, va_mon_lis, 
       va_per_mis
  FROM #tm_per_lis
 ORDER BY va_cod_lis
