/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv004_06a_p01.sql
PROCEDIMIENTO: ELIMINAR PRODUCTO
	
AUTOR:	CREARSIS(CHL)
FECHA:	01-08-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv004_06a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv004_06a_p01
GO

CREATE PROCEDURE inv004_06a_p01		@ar_cod_pro		NVARCHAR(15)
								WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg				nvarchar(200),
@count				INT,
@va_est_ado			CHAR(01)	    --** Estado producto



IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	-- Inicializa contador de registros en 0  
	SET @count = 0
	  
	SELECT @count = COUNT(*)
	  FROM inv004 
	 WHERE (va_cod_pro = @ar_cod_pro)
	
	IF (@count = 0)
	BEGIN
		RAISERROR ('El producto que desea eliminar, no se encuentra registrado' ,16,1)
		RETURN
	END
	
	-- Verifica el producto no este registrado en la lista de precio
	SET @count = 0
	
	SELECT @count = COUNT(*)
	  FROM cmr002
	 WHERE va_cod_pro = @ar_cod_pro
	 
	IF(@count > 0)
	BEGIN
		RAISERROR ('No puede Elminiar el producto por que esta registrado en una o mas listas de precios' ,16,1)
		RETURN
	END

	--** Verifica que producto no tenga movimientos en el kardex
	SET @count = 0
	
	SELECT @count = COUNT(*)
	  FROM inv100
	 WHERE va_cod_pro = @ar_cod_pro
	 
	IF(@count > 0)
	BEGIN
		RAISERROR ('No puede Elminiar el producto por que ya cuenta con movimiento' ,16,1)
		RETURN
	END



	--** Elimina producto
	DELETE inv004
	WHERE va_cod_pro = @ar_cod_pro
	
	--** Elimina producto de vademecum
	DELETE inv009
	WHERE va_cod_pro = @ar_cod_pro
	
	--** Registrar bitacora por operacion
	--INSERT INTO
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO