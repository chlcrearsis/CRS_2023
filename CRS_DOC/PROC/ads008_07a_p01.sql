/*****************************************************************/
/*	ARCHIVO: ads008_07a_p01.sql                                  */
/*	PROCEDIMIENTO: PERMISO USUARIO SOBRE VENDEDOR                */
/*  PARAMETROS:   @ar_ide_usr  VARCHAR(16)  --** ID. Usuario     */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 30/08/2023             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads008_07a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads008_07a_p01
GO

CREATE PROCEDURE ads008_07a_p01		@ar_ide_usr  VARCHAR(16)	WITH ENCRYPTION AS

DECLARE		@va_ide_ven	 INT,		    --** Código
			@va_nom_ven	 VARCHAR(50),	--** Nombre Grupo
			@va_pro_ced  VARCHAR(07),   --** Procedencia (1=Interno ; 2=Externo)
			@va_nro_reg  INT,           --** Nro. Registro
			@va_per_mis  CHAR(01)  	    --** Permiso Registro
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_per_ven
(
	va_ide_ven	INT,
    va_nom_ven	VARCHAR(50),
	va_pro_ced  VARCHAR(07),
	va_per_mis  CHAR(01)
)

--** Obtiene los datos de las aplicaciones del sistema
DECLARE vc_per_ven CURSOR LOCAL FOR
 SELECT va_cod_ide, va_nom_bre,
	   CASE WHEN va_pro_ced = 1
		    THEN 'Interno' 
		    ELSE 'Externo' 
	   END AS va_pro_ced
   FROM cmr014
  WHERE va_ide_tip = 1 --** Vendedor
    AND va_est_ado = 'H'      

--** Abre Cursor
OPEN vc_per_ven
--** Lee el primer registro
FETCH NEXT FROM vc_per_ven INTO @va_ide_ven, @va_nom_ven, @va_pro_ced
														
WHILE (@@FETCH_STATUS = 0)
BEGIN
	--** Verifica si tiene habilitado el usuario ese permiso
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads008
	 WHERE va_ide_tab = 'cmr014'
	   AND va_ide_uno = 1
	   AND va_ide_dos = @va_ide_ven
	   AND va_ide_usr = @ar_ide_usr

	IF (@va_nro_reg = 0)
		SET @va_per_mis = 'N'
	ELSE
		SET @va_per_mis = 'S'

	--** Inserta en la tabla temporal
	INSERT INTO #tm_per_ven VALUES (@va_ide_ven, @va_nom_ven, @va_pro_ced, @va_per_mis)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_per_ven INTO @va_ide_ven, @va_nom_ven, @va_pro_ced
END	

CLOSE vc_per_ven
DEALLOCATE vc_per_ven


--** Retorna los datos
SELECT va_ide_ven, va_nom_ven, va_pro_ced, va_per_mis
  FROM #tm_per_ven
 ORDER BY va_ide_ven
