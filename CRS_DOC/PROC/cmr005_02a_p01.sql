/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: cmr005_02a_p01.sql
PROCEDIMIENTO: PROCEDIMIENTO REGISTRA VENTA
	(venta, suma existencia, kardex, 
	registra movimiento efectivo/CxC )
AUTOR:	CREARSIS(chl)
FECHA:	12-10-2018 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr005_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr005_02a_p01
GO

CREATE PROCEDURE cmr005_02a_p01 --@ar_cod_usr NVARCHAR(15),	-- Usuario registro
							@ar_cod_tmp	 DATETIME,	-- Codigo de la temporal
							
							@ar_pla_vta	INT,			-- Plantilla de Venta
							@ar_tip_vta	INT,			-- Tipo de operacion 
													-- ( 1=Factura; 2=Nota de Venta;  
							@ar_cod_bod CHAR(06),		-- Bodega
							@ar_cod_cli INT,			-- codigo Cliente
							@ar_nit_cli	NVARCHAR(20),	-- Nit del cliente
							@ar_raz_soc	NVARCHAR(100),	-- Razon Social del cliente
							@ar_mon_vta CHAR(01),		-- Moneda de venta (B=Bs ; U=Us )
							@ar_fec_vta DATE,			-- Fecha de venta
							@ar_for_pag INT,			-- Forma de pago (0=Contado; 1=Credito)
							@ar_ven_ded	INT,			-- Vendedor de la venta
							@ar_lis_pre	INT,			-- Lista de precio usada en la venta
							@ar_cod_caj INT,			-- Codigo de caja
							@ar_lin_cxc INT,			-- Linea Cta. x Cob. (codigo de libro)
							
							@ar_tip_cam	DECIMAL(7,5),	-- Tipo de cambio
							@ar_des_cue DECIMAL(10,2),	-- Descuento General
							@ar_obs_vta NVARCHAR(200),  -- Observacion
							@ar_vta_par CHAR(01)	,	-- Venta para (M=Mesa; L=Llevar; D=Delivery)
							@ar_cod_del	INT			,	-- Codigo Delivery
							
							@ar_ref_vta NVARCHAR(20),	-- Referecia del documento
							@ar_mto_efe DECIMAL(16,5),	-- Monto cancelado en la moneda del documento
							@ar_cam_bio	DECIMAL(16,5),	-- Cambio en la moneda del documento
							@ar_nro_aut	VARCHAR(20)		-- Numero de autorizacion/Dosificacion 
														
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),

@va_ide_doc		CHAR(03),
@va_nro_tal		INT,
@va_nro_tal_tmp	INT,			-- Numero de talonario temporal para obtener formato

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

-- VARIABLES PARA CALCULO DE COSTOS
@va_sal_can		DECIMAL(14,2),	--Saldo stock actual EN UNIDAD DE MEDIDA INVENTARIO
@va_cos_ubs		DECIMAL(14,6),	--Costo Unitario (promedio ponderado en Bs)
@va_cos_uus		DECIMAL(14,6),	--Costo Unitario (promedio ponderado en Us)

@va_iva_uBs		DECIMAL(14,6),	--Iva unitario por item en Bs
@va_iva_uUs		DECIMAL(14,6),	--Iva unitario por item en Us
@va_itr_uBs		DECIMAL(14,6),	--ITr unitario por item en Bs
@va_itr_uUs		DECIMAL(14,6),	--ITr unitario por item en Us


-- variables para gestion
@va_ges_vta		INT,
@va_ges_tio		INT,
@va_ges_per		INT,
@va_fec_ini		DATE, 
@va_fec_fin		DATE,

@va_fec_exp		DATE,			-- Fecha de expiracion de la libreta de  la persona
@va_sal_act		DECIMAL(16,2),	-- Saldo actual de la libreta de la persona
@va_mto_lim		DECIMAL(16,2),	-- monto limite autorizado en la libreta de la persona

@va_sal_aut		DECIMAL(16,2),	-- Saldo autorizado de credito (@va_mto_lim - @va_sal_act)
@va_mon_lib		CHAR(01),		-- Moneda de la libreta

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

BEGIN TRAN TR_vta001
BEGIN TRY     
  
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
	SELECT @va_est_ado = va_est_ado
	FROM cmr004
	WHERE va_cod_plv = @ar_pla_vta
		  
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('La Plantilla de Venta no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('La Plantilla de Venta se encuentra Deshabilitada',16,1)
		RETURN
	END	
	
	--// Obtiene documento de venta de la plantilla
	IF(@ar_tip_vta = 1) --FACTURA
	BEGIN
		SELECT @va_ide_doc = va_doc_fac,
			   @va_nro_tal = va_tal_fac
		 FROM cmr004
		WHERE (va_cod_plv = @ar_pla_vta)
	END
	IF(@ar_tip_vta = 2) --NOTA DE VENTA
	BEGIN
		SELECT @va_ide_doc = va_doc_ntv,
			   @va_nro_tal = va_tal_ntv
		 FROM cmr004
		WHERE (va_cod_plv = @ar_pla_vta)
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
	
	SELECT @va_nro_vta = va_con_tad,
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
	SELECT @va_est_ado = va_est_ado
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
	
	
	--Suma en uno el contador de venta
	SET @va_nro_vta = @va_nro_vta + 1
	
	
	SET @va_nro_tal_tmp = 1000 + @va_nro_tal
	SET @va_nro_vta_tmp = 1000000 + @va_nro_vta
	
	--Prepara identificador de la venta XXX-000-00000
	SET @va_ide_vta = @va_ide_doc + '-' + SUBSTRING(CAST (@va_nro_tal_tmp AS VARCHAR(4)),2,3) + '-' + SUBSTRING(CAST(@va_nro_vta_tmp AS VARCHAR(7)),2,7)
	
	
	IF @ar_mon_vta ='B'
	BEGIN
		SELECT @va_tot_bBs = SUM(va_pre_tot) 
		FROM #tm_vta001
		
		SET @va_tot_bUs = @va_tot_bBs / @ar_tip_cam
		
		SET @va_des_cBs = @ar_des_cue
		SET @va_des_cUs = @ar_des_cue / @ar_tip_cam
		
		SET @va_tot_nBs = @va_tot_bBs - @va_des_cBs
		SET @va_tot_nUs = @va_tot_nBs / @ar_tip_cam
	END
	ELSE
	BEGIN
		SELECT @va_tot_bUs = SUM(va_pre_tot) 
		FROM #tm_vta001
		
		SET @va_tot_bBs = @va_tot_bUs * @ar_tip_cam
		
		SET @va_des_cUs = @ar_des_cue
		SET @va_des_cBs = @va_des_cUs * @ar_tip_cam
		
		SET @va_tot_nUs = @va_tot_bUs - @va_des_cUs
		SET @va_tot_nBs = @va_tot_nUs * @ar_tip_cam
	END
	
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
	
	
	-- Obtiene Porcentaje Delivery
	SET @va_por_del = 0
	IF(@ar_vta_par ='D')
	BEGIN
		SELECT @va_por_del = va_por_del 
		  FROM cmr015
		 WHERE va_cod_del = @ar_cod_del
	END
	ELSE
	BEGIN
		SET @ar_cod_del = 0
		SET @va_por_del = 0
	END
		
	-- REGISTRA ENCABEZADO venta select * from cmr005
	INSERT INTO cmr005 VALUES(@va_ide_doc, @va_nro_tal, @va_nro_vta, @va_ges_vta, @va_ide_vta, @ar_tip_vta, @ar_cod_cli,
							  @ar_raz_soc,@ar_nit_cli, @ar_fec_vta, @ar_tip_cam, @ar_pla_vta, @ar_ven_ded, @ar_mon_vta,
							  @ar_for_pag,@ar_cod_caj,@ar_lin_cxc,@ar_ref_vta,
							  @ar_cod_bod, @ar_lis_pre, @ar_vta_par,@ar_cod_del, @va_por_del,  
							  @va_tot_bBs, @va_tot_bUs,@va_des_cBs, @va_des_cUs,@va_tot_nBs, @va_tot_nUs, 
							  @ar_obs_vta, @va_cod_usr, GETDATE(), '', '01/01/1900','V')
				 		 
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Ocurrio un error al ingresar el encabezado de venta',16,1)
		RETURN
	END
		
	/*	
	--// Si es factura 
	if (@ar_tip_vta = 1)
	BEGIN
	
	
	--//graba debito fiscal
	INSERT INTO ctb008 VALUES (@va_ges_vta,@va_prd_vta,@va_ide_vta,@va_nro_vta,@ar_nro_aut,@ar_nit_cli,@ar_raz_soc,@va_tot_bBs,
								@va_des_cBs,@va_tot_nBs, (@va_tot_nBs * 0.13), '' , @ar_fec_vta,GETDATE(),null)
	
		
	END	
	*/		
--//OBTIENE IMPORTE TOTAL DEL DOCUMENTO
SELECT @va_imp_tot = sum(va_pre_tot)
FROM #tm_vta001
	/*
	--// SI ES EFECTIVO-GRABA RECIBO DE INGRESO A CAJA
	IF (@ar_for_pag = 0 ) --Contado
	BEGIN
	 --select * from tes002
		INSERT INTO TES002 VALUES (@ar_cod_caj,@ar_ide_doc,@ar_nro_tal,@va_nro_vta,@va_ges_vta,@va_ide_vta,@ar_cod_cli,@ar_raz_soc,0,
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
		
	-- VERIFICA EXISTENCIA
	IF (@va_tip_fam <> 'S' AND @va_tip_fam <> 'C' )
	BEGIN
		SET @va_stk_act = 0
		
		
		EXECUTE inv100_01a_p02 @va_cod_bod, @va_cod_pro, @ar_fec_vta, @va_stk_act OUTPUT
		
		IF (@va_stk_act IS NULL)
			SET @va_stk_act = 0
			
		IF (@va_stk_act = 0) OR (@va_can_uin > @va_stk_act)	
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : 
El producto ('+ @va_cod_pro +') NO cuenta con existencia suficiente  
Saldo a la fecha: (' + CAST(@va_stk_act AS VARCHAR(16)) + ')   '
			RAISERROR (@msg,16,1)
			RETURN
		END
	END
	/*
	IF(@va_tip_fam = 'C')
	BEGIN
		-- OBTIENE PRODUCTOS QUE COMPONEN EL COMBO
	
	END
	*/
	
	-- Calcula Precios unitarios
	IF @ar_mon_vta = 'B' AND (@va_und_umd = @va_und_vta)
	BEGIN
		SET @va_pre_uBs = @va_pre_uni
		SET @va_pre_uUs = @va_pre_uBs / @ar_tip_cam
	END
	
	IF @ar_mon_vta = 'B' AND (@va_und_umd <> @va_und_vta)
	BEGIN
		IF (@va_opc_und = 0) --// SI LA UNIDAD SELECCIONADA EN LA VENTA FUE "UNIDAD DE VENTA" ENTONCES DIVIDIR PRECIO UNITARIO ENTRE EQUIVALENTE
			SET @va_pre_uni = @va_pre_uni / @va_eqv_vta
			
		SET @va_pre_uBs = @va_pre_uni
		SET @va_pre_uUs = @va_pre_uBs / @ar_tip_cam
	END
	
	IF @ar_mon_vta = 'U' AND (@va_und_umd = @va_und_vta)
	BEGIN
		SET @va_pre_uUs = @va_pre_uni
		SET @va_pre_uBs = @va_pre_uUs * @ar_tip_cam
	END
	
	IF @ar_mon_vta = 'U' AND (@va_und_umd <> @va_und_vta)
	BEGIN
		IF (@va_opc_und = 0) --// SI LA UNIDAD SELECCIONADA EN LA VENTA FUE "UNIDAD DE VENTA" ENTONCES DIVIDIR PRECIO UNITARIO ENTRE EQUIVALENTE
			SET @va_pre_uni = @va_pre_uni / @va_eqv_vta
			
		SET @va_pre_uUs = @va_pre_uni
		SET @va_pre_uBs = @va_pre_uUs * @ar_tip_cam
	END
	
	-- Calcula Precios y descuento unitarios Totales 
	IF @ar_mon_vta = 'B'
	BEGIN
		SET @va_pre_tBs = @va_pre_tot
		SET @va_pre_tUs = @va_pre_tot / @ar_tip_cam
		
		SET @va_dto_uBs = @va_des_cue
		SET @va_dto_uUs = @va_des_cue / @ar_tip_cam
	END
	IF @ar_mon_vta = 'U'
	BEGIN
		SET @va_pre_tUs = @va_pre_tot
		SET @va_pre_tBs = @va_pre_tot * @ar_tip_cam
		
		SET @va_dto_uUs = @va_des_cue
		SET @va_dto_uBs = @va_des_cue * @ar_tip_cam
	END
	
	
	SET @va_sal_can = 0
	SET @va_cos_ubs = 0
	SET @va_cos_uUs = 0
	
	IF (@va_tip_fam = 'D')
	BEGIN
		--//VERIFICA EXISTENCIA EN Bodega Y OBTIENE COSTO
		SELECT @va_sal_can = va_sal_can,
			   @va_cos_ubs = va_cos_ubs,
			   @va_cos_uUs = va_cos_uUs
		  FROM inv099
		WHERE va_cod_bod = @ar_cod_bod	AND
			  va_cod_pro = @va_cod_pro
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +') jamas tuvo movimiento en el Bodega'
			RAISERROR (@msg,16,1)
			RETURN
		END
		IF @va_can_uin > @va_sal_can 
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +') no cuenta con stock suficiente ('+ CAST(@va_sal_can AS NVARCHAR(10)) +')  '
			RAISERROR (@msg,16,1)
			RETURN
		END
		
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
	
	-- PRORATEA DESCUENTO GENERAL DOCUMENTO A LOS ITEM, EN MONEDA DEL DOCUMENTO
	SET @va_por_cen = (@va_pre_tot * 100) / @va_imp_tot
	
	SET @va_des_uni = (@va_por_cen * @ar_des_cue) / 100
	SET @va_des_acu = @va_des_acu + @va_des_uni
	
	IF @@CURSOR_ROWS = @va_con_tad
	BEGIN
		IF @va_des_acu <> @ar_des_cue
			SET @va_des_uni = @va_des_uni + (@ar_des_cue - @va_des_acu)
	END
	
	-- OBTIENE DESCUENTO GLOBAL UNITARIOS PRORATEADOS EN BS Y US PARA CALCULOS
	IF @ar_mon_vta ='B'
	BEGIN
		SET @va_des_unB = @va_des_uni
		SET @va_des_unU = @va_des_uni / @ar_tip_cam
	END
	ELSE
	BEGIN
		SET @va_des_unU = @va_des_uni
		SET @va_des_unB = @va_des_uni * @ar_tip_cam
	END
	
	--// CALCULA VALORES IMPOSITIVOS
	--IVA
	SET @va_iva_uBs = (@va_pre_tBs - @va_des_unU) * 0.13
	SET @va_iva_uUs = (@va_pre_tUs - @va_des_unB) * 0.13

	--ITR
	SET @va_itr_uBs = (@va_pre_tBs - @va_des_unU)  * 0.03
	SET @va_itr_uUs = (@va_pre_tUs - @va_des_unB) * 0.03
		
		
	
	-- REGISTRA DETALLE DE venta select * from cmr006
	INSERT INTO cmr006 VALUES(@va_ide_doc, @va_nro_tal, @va_nro_vta, @va_ges_vta, @va_ide_vta, @va_nro_itm,
							  @va_cod_pro,@va_des_pro, @va_opc_und,@va_und_vta,@va_und_umd,@va_eqv_vta,@va_can_vta,@va_can_uin,
							  @va_pre_lis, (@va_pre_uBs + @va_dto_uBs), (@va_pre_uUs + @va_dto_uUs), 
							  @va_dto_uBs, @va_dto_uUs,@va_por_ite, @va_pre_tBs,@va_pre_tUs,
							  @va_cos_uBs, @va_cos_uUs, @va_iva_uBs, @va_iva_uUs, @va_itr_uBs, @va_itr_uUs )
	
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Item: :Error al ingresar item del detalle',16,1)
		RETURN
	END

	--//ACTUALIZA EXISTENCIA
	 UPDATE inv099 
	    SET va_sal_can = va_sal_can - @va_can_uin
	  WHERE va_cod_bod = @ar_cod_bod AND va_cod_pro = @va_cod_pro
  	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Item: :Error al actualizar saldos de stock',16,1)
		RETURN
	END
  
	--//REGISTRA KARDEX
	INSERT INTO inv100 VALUES (@va_ges_vta,@va_ide_doc,@va_nro_tal,@va_nro_vta,@va_ide_vta, @va_nro_itm,
							   @ar_fec_vta, GETDATE(), @ar_ref_vta, @ar_mon_vta,@ar_obs_vta, @va_cod_pro,
							   0,@va_can_uin,@va_cos_ubs,@va_cos_uus,(@va_cos_ubs * @va_can_vta),(@va_cos_uus * @va_can_vta), 
							   @va_cos_ubs,@va_cos_uus, @va_cod_bod, 'Lote: ', @ar_tip_cam, @va_cod_usr)
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Item: :Error al registrar el kardex',16,1)
		RETURN
   END
   
 
FETCH NEXT FROM vc_det_vta 
INTO @va_nro_itm,@va_cod_pro,@va_des_pro,@va_opc_und,@va_can_vta,@va_pre_uni,
	 @va_pre_tot, @va_pre_lis, @va_des_cue, @va_por_ite
END


--// GRABA CXC 

--// GRABA INGRESO EFECTIVO


--// ACTUALIZA CONTADOR
UPDATE ads005 SET va_con_tad = @va_nro_vta
WHERE va_ide_doc = @va_ide_doc AND 
	  va_nro_tal = @va_nro_tal AND
	  va_ges_tio = @va_ges_vta

CLOSE vc_det_vta
DEALLOCATE vc_det_vta

-- Borra temporal
DELETE cmr006tmp
WHERE va_cod_tmp = @ar_cod_tmp AND
	  va_cod_usr = @va_cod_usr

SELECT * FROM  cmr005
WHERE va_doc_vta = @va_ide_doc	AND
	  va_nro_tal = @va_nro_tal	AND
	  va_nro_vta = @va_nro_vta	AND
	  va_ges_vta = @va_ges_vta 
	
	COMMIT TRAN TR_vta001
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_vta001
	RETURN
END CATCH	

GO