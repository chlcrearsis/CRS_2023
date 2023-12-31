/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: cmr005_02a_p02.sql
PROCEDIMIENTO: PROCEDIMIENTO VERIFICA ANTES DE GRABAR VENTA
AUTOR:	CREARSIS(chl)
FECHA:	21-04-2021
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr005_02a_p02') and sysstat & 0xf = 4)
	drop procedure dbo.cmr005_02a_p02
GO

CREATE PROCEDURE cmr005_02a_p02 
							@ar_cod_tmp	 DATETIME,	-- Codigo de la temporal
							@ar_tip_vta INT,		-- Tipo de venta (1= FAC, 2 = NOTA DE VENTA)
							@ar_pla_vta	INT,			-- Plantilla de venta 
							@ar_cod_bod INT,			-- Bodega
							@ar_cod_cli INT,			-- codigo Cliente
							@ar_fec_vta DATE,			-- Fecha de venta
							@ar_for_pag INT,			-- Forma de pago (0=Contado; 1=Credito)
							@ar_lis_pre	INT			-- Lista de precio usada en la venta
							
														
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),

@va_ide_doc		CHAR(03),
@va_nro_tal		INT,

@va_nro_vta		INT,			-- Numero de del documento
@va_nro_vta_tmp INT,
@va_ide_vta		VARCHAR(20),	--Identificador de la venta (XXX|000-00000)
@va_nro_reg		INT,
@va_est_ado		CHAR(01),
@va_cod_usr		VARCHAR(15),	--Codigo del usuario
@va_cod_tmp		DATETIME,		--Codigo temporal (fecha y hora)
@va_nro_itm		INT,			--Numero de item 
@va_cod_pro		VARCHAR(15),	--Codigo Producto
@va_des_pro		varchar(80),	--Descripcion del Producto 

@va_opc_und		INT,			--Opcion de unidad de medida seleccionado
@va_und_umd		CHAR(03),		--Unidad de medida inventario del producto
@va_und_vta		CHAR(03),		--Unidad de medida de venta del producto
@va_can_uin		DECIMAL(14,4),	--Cantidad inventario de producto
@va_can_vta		DECIMAL(14,4),	--Cantidad de producto
@va_eqv_vta		DECIMAL(7,3),	-- Equivalencia entre @va_und_vta y @va_und_umd
@va_pre_uni		DECIMAL(14,4),	--Precio Unitario de item en la moneda del documento
@va_pre_tot		DECIMAL(16,2),	--Precio Total de item en la moneda del documento
@va_des_cue		DECIMAL(16,2),	--Descuento del item en moneda de la venta
@va_pre_lis		DECIMAL(16,2),	--Precio de la lista de precio del item en moneda de la venta
@va_imp_tot		DECIMAL(16,2),	--Importe Total en la moneda del documento
@va_cod_fam		VARCHAR(15),	-- Codigo de familida a la que pertenece el producto
@va_tip_fam		CHAR(01),		-- Tipo de familia 

@va_tot_bBs		DECIMAL(16,2),	-- Total bruto del documento en Bs
@va_tot_bUs		DECIMAL(16,2),	-- Total bruto del documento en Us
@va_des_cBs		DECIMAL(16,2),	-- Descuento global al documento en Bs.
@va_des_cUs		DECIMAL(16,2),	-- Descuento global al documento en Us.
@va_tot_nBs		DECIMAL(16,2),	-- Total neto del documento en Bs.
@va_tot_nUs		DECIMAL(16,2),	-- total neto del documento en Us.

@va_pre_uBs		DECIMAL(16,2),	-- Precio unitario en Bs
@va_pre_uUs		DECIMAL(16,2),	-- Precio unitario en Us.
@va_pre_tBs		DECIMAL(16,2),	-- Precio total en Bs.
@va_pre_tUs		DECIMAL(16,2),	-- precio total en Us.
@va_dto_uBs		DECIMAL(16,2),	-- Descueto lineal unitario en Bs.
@va_dto_uUs		DECIMAL(16,2),	-- Descueto lineal unitario en Us.
@va_por_ite		DECIMAL(16,2),	-- Porcentaje lineal unitario

@va_con_tad		INT,			-- Contador para validar

--// Valores para prorratear descuento global del documento sobre los items
@va_por_cen		DECIMAL(16,5),	-- Porcentaje de descuento unitario
@va_des_uni		DECIMAL(16,2),	-- Valor de descuento unitario
@va_des_unB		DECIMAL(16,2),	-- Descuento unitario en Bs para calculo
@va_des_unU		DECIMAL(16,2),	-- Descuento unitario en Us para calculo
@va_des_acu		DECIMAL(16,2),	-- Descuento acumulado para calculo
@va_pmx_des		DECIMAL(16,2),	-- Porcentaje Descuento permitido segun lista de precio
@va_pmx_inc		DECIMAL(16,2),	-- Porcentaje Incremento permitido segun lista de precio

-- variables para gestion
@va_ges_vta		INT,
@va_ges_tio		INT,
@va_ges_per		INT,
@va_fec_ini		DATE, 
@va_fec_fin		DATE,

@va_fec_exp		DATE,			-- Fecha de expiracion de la libreta de  la persona

@va_fec_fin_lis		DATE,			-- Fecha de fin de la lista de precio
@va_fec_ini_lis		DATE,			-- Fecha de inicio de la lista de precio

@va_sal_act		DECIMAL(16,2),	-- Saldo actual de la libreta de la persona
@va_mto_lim		DECIMAL(16,2),	-- monto limite autorizado en la libreta de la persona

@va_sal_aut		DECIMAL(16,2),	-- Saldo autorizado de credito (@va_mto_lim - @va_sal_act)
@va_mon_lib		CHAR(01),		-- Moneda de la libreta

@va_tip_cam		DECIMAL(7,5),	-- TIPO DE CAMBIO

@va_stk_act		DECIMAL(16,4),	-- ESTOCK ACTUAL DEL PRODUCTO OBTENIDO DEL PROCEDIMIENTO (inv100_01p2)
@va_prd_vta		INT			 ,	-- Periodo de la venta
@va_cod_bod		INT			 ,	-- Codigo de bodega en  INT
@va_por_del		DECIMAL (3,1)	-- Porcentaje correspondiente al delivery
			
	
--** CREA TABLA TEMPORAL
CREATE TABLE #tm_vta001(
	va_cod_usr		VARCHAR(15)		NOT NULL,	--Codigo del usuario
	va_cod_tmp		DATETIME		NOT NULL,	--Codigo temporal (fecha y hora)
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
	va_des_pro		varchar(80)		not null,	--Descripcion del Producto 
	va_opc_und		INT						,	--Codigo de la Unidad de Medida
	va_can_tid		DECIMAL(14,4),				--Cantidad de producto
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
	va_pre_tot		DECIMAL(16,2),				--Precio Total en la moneda del documento
	va_pre_lis		DECIMAL(16,2),				--Precio de lista en la moneda del documento
	va_des_cue		DECIMAL(16,2),				--Descuento en la moneda del documento
	va_por_cen		DECIMAL(16,2) 				--Pocentaje de descuento
	
   )
   
IF @@ERROR <> 0
   RETURN

--BEGIN TRAN TR_vta001
BEGIN TRY     
  
	
  SET @va_tip_cam = 1
  SET @va_cod_usr = SYSTEM_USER
  
  
   -- Carga temporal de venta
   INSERT INTO #tm_vta001
	SELECT * FROM cmr006tmp
	WHERE va_cod_tmp = @ar_cod_tmp AND
		  va_cod_usr = @va_cod_usr
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('No hay ningun item para la venta',16,1)
		RETURN
	END

	
	-- Verifica plantilla de venta
	SET @va_est_ado = 'N'
	IF(@ar_tip_vta = 1) -- FACTURA
	BEGIN
		SELECT @va_est_ado = va_est_ado,
			   @va_ide_doc = va_doc_fac,
			   @va_nro_tal = va_tal_fac
		FROM cmr004
		WHERE va_cod_plv = @ar_pla_vta
	END	  
	IF(@ar_tip_vta = 2) -- NOTA DE VENTA
	BEGIN
		SELECT @va_est_ado = va_est_ado,
			   @va_ide_doc = va_doc_ntv,
			   @va_nro_tal = va_tal_ntv
		FROM cmr004
		WHERE va_cod_plv = @ar_pla_vta
	END	 	 
		  
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('La Plantilla de venta no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('La Plantilla de venta se encuentra Deshabilitada',16,1)
		RETURN
	END	
	
	
	--// Verifica Documento
	SET @va_est_ado = 'N'
	SELECT @va_est_ado = va_est_ado
	 FROM ads003
	WHERE va_ide_doc = @va_ide_doc 
		  
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Documento no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Documento se encuentra Deshabilitado',16,1)
		RETURN
	END

	--// Verifica Talonario
	SELECT @va_est_ado = va_est_ado
	 FROM ads004
	WHERE va_ide_doc = @va_ide_doc AND 
		  va_nro_tal = @va_nro_tal
		   
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Talonario no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Talonario se encuentra Deshabilitado',16,1)
		RETURN
	END
	
	
		SELECT	--@va_est_ado = va_est_ado,
				@va_ges_vta = va_ges_tio,
				@va_prd_vta = va_ges_per,
				@va_fec_ini = va_fec_ini,
				@va_fec_fin = va_fec_fin
		  FROM	ads016
		 WHERE	(@ar_fec_vta BETWEEN va_fec_ini AND va_fec_fin)
		 
		  
		
 IF (@va_ges_vta = 0)
 BEGIN
	RAISERROR ('la fecha del documento no se encuentra dentro de una gestion definida',16,1)
	RETURN
 END
/*
 IF (@va_est_ado = 'C')
 BEGIN
	RAISERROR ('la fecha del documento se encuentra dentro de un periodo cerrado',16,1)
	RETURN
 END
*/
		
--// Verifica Numeracion / inicialilza fechas iniciales para numeracion
	SET @va_fec_ini = '01.01.1990'
	SET @va_fec_fin = '01.01.1990'
	
	SELECT @va_nro_vta = va_con_act,
		   @va_fec_ini = va_fec_ini,
		   @va_fec_fin = va_fec_fin
	FROM ads005
	WHERE va_ide_doc = @va_ide_doc AND 
		  va_nro_tal = @va_nro_tal AND
		  va_ges_tio = @va_ges_vta
	IF @@ROWCOUNT = 0
	BEGIN
		
	    SET @msg = 'El Talonario NO dispone de numeracion para la gestion ' + CAST (@va_ges_vta AS VARCHAR(3))
		RAISERROR ( @msg ,16,1)
		RETURN
	END
	
	IF NOT (@ar_fec_vta > @va_fec_ini AND @ar_fec_vta < @va_fec_fin)
	BEGIN
		RAISERROR ('La fecha del documento no esta dentro del rango permitido en la numeracion para la gestion',16,1)
		RETURN
	END	
	
	--// Verifica Bodega
	SELECT @va_est_ado = va_est_ado
	FROM inv002
	WHERE va_cod_bod = @ar_cod_bod
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Bodega no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Bodega se encuentra Deshabilitada',16,1)
		RETURN
	END
	
	
	--// Verifica CLIENTE
	SELECT @va_est_ado = va_est_ado
	FROM adp002
	WHERE va_cod_per = @ar_cod_cli
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Cliente no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Cliente se encuentra Deshabilitado',16,1)
		RETURN
	END

	/*
	--// Verifica Caja si es al contado
	IF @ar_for_pag = 0
	BEGIN
		SELECT @va_est_ado = va_est_ado
		FROM tes001
		WHERE va_cod_cjb = @ar_cod_caj
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('La Caja/Banco no se encuentra registrada',16,1)
			RETURN
		END
		IF @va_est_ado = 'N'
		BEGIN
			RAISERROR ('La Caja/Banco se encuentra Deshabilitada',16,1)
			RETURN
		END
	END
	*/
	
	--// Verifica LISTA DE PRECIO
	SELECT @va_est_ado = va_est_ado,
			@va_fec_fin_lis = va_fec_fin,
			@va_fec_ini_lis = va_fec_ini
	FROM cmr001
	WHERE va_cod_lis = @ar_lis_pre
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('La Lista de Precio no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('La Lista de Precio se encuentra Deshabilitada',16,1)
		RETURN
	END

	-- Verifica que la fecha de la venta este dentro del rango de fechas de la lista de precios
	IF( @ar_fec_vta > @va_fec_fin_lis or @ar_fec_vta < @va_fec_ini_lis)
	BEGIN
		RAISERROR ('La Lista de Precio NO puede ser usada para la fecha del documento',16,1)
		RETURN
	END




/*
	--// Verifica Caja si es al contado
	IF @ar_for_pag = 0
	BEGIN
		SELECT @va_est_ado = va_est_ado
		FROM tes001
		WHERE va_cod_cjb = @ar_cod_caj
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('La Caja/Banco no se encuentra registrada',16,1)
			RETURN
		END
		IF @va_est_ado = 'N'
		BEGIN
			RAISERROR ('La Caja/Banco se encuentra Deshabilitada',16,1)
			RETURN
		END
	END
	*/
	
	
	/*
	--// Verifica Linea de credito si es al credito
	IF @ar_for_pag = 1
	BEGIN
		SELECT @va_est_ado = va_est_ado
		FROM ecp007
		WHERE va_cod_per = @ar_cod_cli AND
			  va_cod_lib = @ar_lin_cxc
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('La persona no tiene la libreta de la linea de credito espesificada',16,1)
			RETURN
		END
		IF @va_est_ado = 'N'
		BEGIN
			RAISERROR ('La persona no tiene habilitada la linea de credito espesificada',16,1)
			RETURN
		END
		
		IF( @ar_fec_vta > @va_fec_exp)
		BEGIN
			RAISERROR ('La linea de credito de la persona a expirado',16,1)
			RETURN
		END
		
		SELECT @va_mon_lib = va_mon_lib
		  FROM ecp006
		WHERE  va_cod_lib = @ar_lin_cxc
		
		SET @va_sal_aut = @va_mto_lim - @va_sal_act
		
		IF (@va_mon_lib = 'B')
		BEGIN
			IF (@va_tot_nBs > @va_saL_aut )
			BEGIN
				RAISERROR ('El monto de la venta supera el saldo autorizado de la linea de credito',16,1)
				RETURN
			END
		END
		ELSE
		BEGIN
			IF (@va_tot_nus > @va_saL_aut )
			BEGIN
				RAISERROR ('El monto de la venta supera el saldo autorizado de la linea de credito',16,1)
				RETURN
			END
		END
		
	END
	*/

	/*
	--// SI ES EFECTIVO-GRABA RECIBO DE INGRESO A CAJA
	IF (@ar_for_pag = 0 ) --Contado
	BEGIN
	 --select * from tes002
		INSERT INTO TES002 VALUES (@ar_cod_caj,@va_ide_doc,@va_nro_tal,@va_nro_vta,@va_ges_vta,@va_ide_vta,@ar_cod_cli,@ar_raz_soc,0,
									@ar_mon_vta,@va_imp_tot,@ar_mto_efe, @ar_cam_bio, @ar_obs_vta,'V')
	END
	ELSE -- SI ES AL CREDITO GRABA EXIGIBLE X COBRAR
	BEGIN
	
	
	END
	*/
	

	
	
	
--// Cursor sobre temporal
DECLARE vc_det_vta CURSOR LOCAL FOR
SELECT va_nro_itm,va_cod_pro,va_des_pro,va_opc_und, va_can_tid,va_pre_uni,
	   va_pre_tot, va_pre_lis, va_des_cue, va_por_cen
FROM #tm_vta001	
	
--** Abre cursor		  
OPEN vc_det_vta    
	 
SET @va_con_tad = 0
FETCH NEXT FROM vc_det_vta 
INTO @va_nro_itm,@va_cod_pro,@va_des_pro,@va_opc_und,@va_can_vta,@va_pre_uni,
	 @va_pre_tot, @va_pre_lis, @va_des_cue, @va_por_ite

WHILE (@@FETCH_STATUS = 0)
BEGIN

	SET @va_con_tad = @va_con_tad + 1
	
	-- Verifica producto
	SELECT @va_est_ado = va_est_ado,
		   @va_und_umd = va_cod_umd,
		   @va_und_vta = va_und_vta,
		   @va_eqv_vta = va_eqv_vta,
		   @va_cod_fam = va_cod_fam
	FROM inv004
	WHERE va_cod_pro = @va_cod_pro
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +') no se encuentra registrado'
		RAISERROR (@msg,16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +')  se encuentra deshabilitado'
		RAISERROR (@msg,16,1)
		RETURN
	END
	
	
	--//VERIFICA TIPO DE FAMILIA (SERVICIO/DETALLE/...)
	SELECT @va_est_ado = va_est_ado,
		   @va_tip_fam = va_tip_fam
	  FROM inv003
	 WHERE va_cod_fam = @va_cod_fam
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : La familia del producto ('+ @va_cod_pro +') no se encuentra registrada'
		RAISERROR (@msg,16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : La familia del producto ('+ @va_cod_pro +')  se encuentra deshabilitada'
		RAISERROR (@msg,16,1)
		RETURN
	END
	
	
	-- Calcula cantidades segun unidades de medida
	SET @va_can_uin = @va_can_vta
	
	IF (@va_tip_fam <> 'S')
	BEGIN
		IF (@va_und_umd <> @va_und_vta) 
		BEGIN
			IF(@va_opc_und = 0)
				SET @va_can_uin = @va_can_vta * @va_eqv_vta
		END
	END
	
	SET @va_cod_bod = @ar_cod_bod
		
--	-- VERIFICA EXISTENCIA
--	IF (@va_tip_fam <> 'S' AND @va_tip_fam <> 'C' )
--	BEGIN
--		SET @va_stk_act = 0
		
		
--		EXECUTE inv100_01a_p02 @va_cod_bod, @va_cod_pro, @ar_fec_vta, @va_stk_act OUTPUT
		
--		IF (@va_stk_act IS NULL)
--			SET @va_stk_act = 0
			
--		IF (@va_stk_act = 0) OR (@va_can_uin > @va_stk_act)	
--		BEGIN
--			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : 
--El producto ('+ @va_cod_pro +') NO cuenta con existencia suficiente  
--Saldo a la fecha: (' + CAST(@va_stk_act AS VARCHAR(16)) + ')   '
--			RAISERROR (@msg,16,1)
--			RETURN
--		END
--	END
	
	
	/*
	IF(@va_tip_fam = 'C')
	BEGIN
		-- OBTIENE PRODUCTOS QUE COMPONEN EL COMBO
	
	END
	*/
	
	
	
	
	IF (@va_tip_fam = 'D')
	BEGIN
		
		--//VERIFICA LIMITES DE DESCUENTO SEGUN LISTA DE PRECIO
		SELECT @va_pmx_des = va_pmx_des,
			   @va_pmx_inc = va_pmx_inc
		FROM cmr002
		 WHERE va_cod_lis = @ar_lis_pre AND
			   va_cod_pro = @va_cod_pro
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +') no cuenta con precio definido en la lista de precio ('+ CAST(@ar_lis_pre AS NVARCHAR(10))  +')'
			RAISERROR (@msg,16,1)
			RETURN
		END
		IF @va_por_ite > @va_pmx_des 
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El descuento para el producto ('+ @va_cod_pro +'), supera el permitido (Desc. Max.: '+ CAST(@va_pmx_des AS NVARCHAR(10)) +' %)  '
			RAISERROR (@msg,16,1)
			RETURN
		END
	END
	
	
   
 
FETCH NEXT FROM vc_det_vta 
INTO @va_nro_itm,@va_cod_pro,@va_des_pro,@va_opc_und,@va_can_vta,@va_pre_uni,
	 @va_pre_tot, @va_pre_lis, @va_des_cue, @va_por_ite
END


CLOSE vc_det_vta
DEALLOCATE vc_det_vta
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_vta001
	RETURN
END CATCH	

GO