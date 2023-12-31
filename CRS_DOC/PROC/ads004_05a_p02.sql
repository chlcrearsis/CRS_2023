/****************************************************************************/
/*	ARCHIVO: ads004_05a_p02.sql                                             */
/*	PROCEDIMIENTO: PERMISO SOBRE TALONARIO AL USUARIO                       */
/*      ARGUMENTO: @ar_ide_usr 	VARCHAR(15) --** ID. Usuario                */
/*                 @ar_ide_doc	CHAR(03)	--** ID. Documento              */
/*                 @ar_nro_tal	INT			--** Nro Talonario              */
/*                 @ar_est_tal CHAR(01)		--** Estado Talonario           */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 16/05/2020                        */
/****************************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads004_05a_p02') and sysstat & 0xf = 4)
	drop procedure dbo.ads004_05a_p02
GO

CREATE PROCEDURE ads004_05a_p02		@ar_ide_usr VARCHAR(15),
                                    @ar_ide_doc	CHAR(03),
									@ar_est_tal CHAR(01)	WITH ENCRYPTION AS

DECLARE		@va_msn_err	 NVARCHAR(200),	--** Mensaje de Error
			@va_nro_reg  INT,			--** Nro. de Registro encontrados
			@va_ide_doc	 CHAR(03),      --** ID. Documento
            @va_nom_doc	 NVARCHAR(30),  --** Nombre Documento
            @va_nro_tal	 INT,           --** Nro. Talonario
            @va_nom_tal	 NVARCHAR(60),  --** Nombre Talonario
            @va_est_ado	 CHAR(01)       --** Estado (H=Habilitado; N=Deshabilitado)

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Crea la Tabla Temporal
CREATE TABLE #tm_per_tal
(
	va_ide_doc	CHAR(03),
	va_nom_doc	NVARCHAR(30),
	va_nro_tal	INT,
	va_nom_tal	NVARCHAR(60),
	va_est_ado	CHAR(01)
)

--** Obtiene todos los talonarios del Sistema
DECLARE vc_per_tal CURSOR LOCAL FOR
 SELECT va_ide_doc, va_nro_tal, va_nom_tal,va_est_ado
   FROM ads004
  WHERE va_ide_doc = @ar_ide_doc
	AND va_est_ado = @ar_est_tal

--** Abre Cursor		   
OPEN vc_per_tal

--** Lee el primer registro
FETCH NEXT FROM vc_per_tal INTO @va_ide_doc, @va_nro_tal, @va_nom_tal, @va_est_ado
WHILE (@@FETCH_STATUS = 0)
BEGIN
	--** Verifica si el usuario tiene permiso sobre el talonario
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads008
	 WHERE va_ide_usr = @ar_ide_usr	
	   AND va_ide_tab = 'ads004'
	   AND va_ide_uno = @va_ide_doc
	   AND va_ide_dos = @va_nro_tal

	IF (@va_nro_reg > 0)
	BEGIN 	
		--** Obtiene el nombre del documento
		SET @va_nom_doc = ''
		SELECT @va_nom_doc = va_nom_doc
		  FROM ads003
		 WHERE va_ide_doc = @va_ide_doc

		 --** Inserta en la tabla temporal	 
		 INSERT INTO #tm_per_tal VALUES (@va_ide_doc, @va_nom_doc, @va_nro_tal, @va_nom_tal, @va_est_ado)

		 IF (@@ERROR > 0)
			RETURN
	END
	
	--** Lee el siguiente registro
	FETCH NEXT FROM vc_per_tal INTO @va_ide_doc, @va_nro_tal, @va_nom_tal, @va_est_ado
END	

--** Cierra y destruye cursor
CLOSE vc_per_tal
DEALLOCATE vc_per_tal

--** Retorna lista de permisos autorizados al usuario
SELECT va_ide_doc, va_nom_doc, va_nro_tal,
	   va_nom_tal, va_est_ado
  FROM #tm_per_tal
  ORDER BY va_ide_doc, va_nro_tal ASC