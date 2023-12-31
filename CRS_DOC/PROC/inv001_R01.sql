/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv001_R01.sql
PROCEDIMIENTO: REPORTE LISTADO DE GRUPO DE BODEGAS
	
AUTOR:	CREARSIS(CHL)
FECHA:	22-07-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv001_R01') and sysstat & 0xf = 4)
	drop procedure dbo.inv001_R01
GO

CREATE PROCEDURE inv001_R01	@ar_est_ado		CHAR(01)
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_est_ado		CHAR(01)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 --/ Inicializa variable contador de registro
	IF(@ar_est_ado = 'T')
		SET @va_est_ado = '%'
	IF(@ar_est_ado <> 'T')
		SET @va_est_ado = @ar_est_ado
			
		 
	 SELECT inv001.va_ide_gru,
            inv001.va_nom_gru, inv001.va_des_gru, inv001.va_est_ado
	  FROM	inv001 
	 WHERE (inv001.va_est_ado LIKE @va_est_ado)
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO
