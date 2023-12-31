/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ctb007_01a_p01.sql
PROCEDIMIENTO: BUSCA DOSIFICACIÓN
	
AUTOR:	CREARSIS(CHL)
FECHA:	06-10-20201
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ctb007_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ctb007_01a_p01
GO

CREATE PROCEDURE ctb007_01a_p01		@ar_tex_bus		VARCHAR(60),	-- Texto a ser buscado
									@ar_fec_ini		DATE,
									@ar_fec_fin		DATE
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT,				-- Contador de registros para verificar
@va_tip_fac		INT,
@va_tip_nom		VARCHAR(15),
@va_nro_aut		DECIMAL(15,0),
@va_ide_suc		INT,
@va_nom_suc		VARCHAR(30), 
@va_fec_ini		DATE, 
@va_fec_fin		DATE, 
@va_nro_ini		INT, 
@va_nro_fin		INT, 
@va_cod_act		INT, 
@va_cod_ley		INT, 
@va_lla_vee		NVARCHAR(500), 
@va_con_tad		INT


CREATE TABLE #resultado
(
va_nro_aut		DECIMAL(15,0),
va_ide_suc		INT,
va_nom_suc		NVARCHAR(30),
va_tip_fac		INT,
va_tip_nom		VARCHAR(15),
va_fec_ini		DATE,
va_fec_fin		DATE,
va_con_tad		INT

)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 

-- Crea cursor para busqueda
	DECLARE vc_dos_ifi CURSOR LOCAL FOR
	SELECT va_nro_aut,va_tip_fac, va_cod_suc, va_fec_ini, va_fec_fin, va_nro_ini, va_nro_fin, 
		   va_cod_act, va_cod_ley, va_lla_vee, va_con_act
	FROM ctb007 
	WHERE (va_nro_aut LIKE @ar_tex_bus + '%')		AND
		  (va_fec_ini BETWEEN @ar_fec_ini AND @ar_fec_fin)
		  

OPEN vc_dos_ifi
FETCH NEXT FROM vc_dos_ifi INTO @va_nro_aut, @va_tip_fac, @va_ide_suc, @va_fec_ini, @va_fec_fin, 
				@va_nro_ini, @va_nro_fin, @va_cod_act, @va_cod_ley, @va_lla_vee, @va_con_tad
						
WHILE (@@FETCH_STATUS = 0)
BEGIN

	-- Obtiene nombre de sucursal
	SELECT @va_nom_suc = va_nom_suc
	  FROM cmr003
	 WHERE va_ide_suc = @va_ide_suc
 
	IF(@va_tip_fac = 1)
		SET @va_tip_nom = 'Manual'
  
	IF(@va_tip_fac = 2)
		SET @va_tip_nom = 'Automático'
		
	 INSERT INTO #resultado VALUES (@va_nro_aut,
									@va_ide_suc,
									@va_nom_suc	,
									@va_tip_fac,
									@va_tip_nom,
									@va_fec_ini,
									@va_fec_fin,
									@va_con_tad
									)

	FETCH NEXT FROM vc_dos_ifi INTO @va_nro_aut, @va_tip_fac, @va_ide_suc, @va_fec_ini, @va_fec_fin, @va_nro_ini, @va_nro_fin, @va_cod_act, @va_cod_ley, @va_lla_vee,@va_con_tad
END	

CLOSE vc_dos_ifi
DEALLOCATE vc_dos_ifi

	SELECT * 
	FROM #resultado


RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO


