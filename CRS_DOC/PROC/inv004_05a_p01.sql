/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv004_05a_p01.sql
PROCEDIMIENTO: BUSCA PRODUCTO ABM
	
AUTOR:	CREARSIS(CHL)
FECHA:	07-09-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv004_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv004_05a_p01
GO

CREATE PROCEDURE inv004_05a_p01		@ar_cod_pro		VARCHAR(15)	-- Codigo Producto
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar
@va_cod_pro		VARCHAR(15),
@va_nom_pro		NVARCHAR(80),
@va_des_pro		NVARCHAR(200),
@va_cod_umd		CHAR(03),
@va_und_cmp		CHAR(03),
@va_und_vta		CHAR(03),
@va_cod_mar		INT,
@va_nom_mar		VARCHAR(20),
@va_eqv_cmp		DECIMAL(6,2),
@va_eqv_vta		DECIMAL(6,2),
@va_nro_dec		INT,
@va_ban_ser		INT,
@va_ban_lot		INT,
@va_cod_fam		VARCHAR(06),
@va_nom_fam		VARCHAR(60),
@va_tip_fam		CHAR(01),
@va_cod_bar		VARCHAR(15),
@va_fab_ric		VARCHAR(50),

--** CAMPOS DE VADEMECUM
@va_pri_act		VARCHAR(150),
@va_pro_ind		VARCHAR(150),
@va_con_ind		VARCHAR(150),


@va_est_ado		CHAR(01)


CREATE TABLE #resultado
(
va_cod_pro		VARCHAR(15),
va_nom_pro		NVARCHAR(80),
va_des_pro		NVARCHAR(200),
va_cod_umd		CHAR(03),
va_und_cmp		CHAR(03),
va_und_vta		CHAR(03),
va_cod_mar		INT,
va_nom_mar		VARCHAR(20),
va_cod_bar		VARCHAR(15),
va_fab_ric		VARCHAR(50),
va_eqv_cmp		DECIMAL(6,2),
va_eqv_vta		DECIMAL(6,2),
va_nro_dec		INT,
va_ban_ser		INT,
va_ban_lot		INT,
va_cod_fam		VARCHAR(06),
va_nom_fam		VARCHAR(60),
va_tip_fam		CHAR(01),
va_est_ado		CHAR(01),

--** CAMPOS DE VADEMECUM
va_pri_act		VARCHAR(150),
va_pro_ind		VARCHAR(150),
va_con_ind		VARCHAR(150)

)



IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 

	SELECT @va_cod_pro = va_cod_pro, 
		   @va_nom_pro = va_nom_pro,
		   @va_des_pro = va_des_pro, 
		   @va_cod_umd = va_cod_umd, 
		   @va_und_cmp = va_und_cmp,
		   @va_und_vta = va_und_vta,
		   @va_cod_mar = va_cod_mar,
		   @va_cod_bar = va_cod_bar,
		   @va_fab_ric = va_fab_ric,
		   @va_eqv_cmp = va_eqv_cmp,
		   @va_eqv_vta = va_eqv_vta,
		   @va_nro_dec = va_nro_dec,
		   @va_ban_ser = va_ban_ser,
		   @va_ban_lot = va_ban_ser,
		   @va_cod_fam = va_cod_fam,
		   @va_est_ado = va_est_ado
	FROM inv004
	WHERE va_cod_pro = @ar_cod_pro
	
	IF @@ROWCOUNT = 0
	BEGIN
		SELECT * FROM #resultado
		RETURN
		--DELETE #resultado
	END

	-- Obtiene nombre del Marca
	SELECT @va_nom_mar = va_nom_mar
	  FROM inv006
	 WHERE va_cod_mar = @va_cod_mar
	 
	-- Obtiene nombre de la familia
	SELECT @va_nom_fam = va_nom_fam,
		   @va_tip_fam = va_tip_fam
	  FROM inv003
	 WHERE va_cod_fam = @va_cod_fam 
	 

	--** OBTIENE CAMPOS DE VADEMECUM
	SELECT @va_pri_act = va_pri_act,
		   @va_pro_ind = va_pro_ind,
		   @va_con_ind = va_con_ind
	  FROM inv009
	 WHERE va_cod_pro = @va_cod_pro
	
	 INSERT INTO #resultado VALUES (@va_cod_pro		,
									@va_nom_pro		,
									@va_des_pro		,
									@va_cod_umd		,
									@va_und_cmp		,
									@va_und_vta		,
									@va_cod_mar		,
									@va_nom_mar		,
									@va_cod_bar		,
									@va_fab_ric		,								
									@va_eqv_cmp		,
									@va_eqv_vta		,
									@va_nro_dec		,
									@va_ban_ser		,
									@va_ban_lot		,
									@va_cod_fam		,
									@va_nom_fam		,
									@va_tip_fam		,
									@va_est_ado		,
									
									--** Datos Vademecum
									@va_pri_act		,
									@va_pro_ind		,
									@va_con_ind
									)

	SELECT * FROM #resultado    		
	RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO


