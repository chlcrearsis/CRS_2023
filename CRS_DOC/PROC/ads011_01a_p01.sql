/***********************************************************************/
/*	ARCHIVO: ads011_01a_p01.sql                                        */
/*	PROCEDIMIENTO: REGISTRA OPCIONES DEL MENU                          */
/*      ARGUMENTO: @ar_nom_frm  VARCHAR(10) --** Nombre Formulario     */
/*                 @ar_ide_men  VARCHAR(10) --** ID. Menu Formulario   */
/*                 @ar_tex_men  VARCHAR(10) --** Texto Menu Formulario */
/*                 @ar_des_men  VARCHAR(10) --** Descripción           */
/*                 @ar_ide_pad  VARCHAR(10) --** ID. Menu Padre        */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 19/08/2022                   */
/***********************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads011_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads011_01a_p01
GO

CREATE PROCEDURE ads011_01a_p01		@ar_nom_frm  VARCHAR(10),  
                                    @ar_ide_men  VARCHAR(10),
									@ar_tex_men  VARCHAR(10),  
									@ar_des_men  VARCHAR(10),
									@ar_ide_pad  VARCHAR(10)   WITH ENCRYPTION AS

DECLARE     @va_nro_reg  INT

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Verifica si el registro ya se encuentra en la bd
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*)
  FROM ads011
 WHERE va_nom_frm = @ar_nom_frm
   AND va_ide_men = @ar_ide_men

--** Si no se encuentra lo registra, sino lo actualiza
IF (@va_nro_reg = 0)
BEGIN
	--** Registra Menu
	INSERT INTO ads011 VALUES (@ar_nom_frm, @ar_ide_men, @ar_tex_men, @ar_des_men, @ar_ide_pad)
	IF (@@ERROR > 0)
		RETURN 0
END	
ELSE
BEGIN
	--** Actualiza Menu
	UPDATE ads011 SET va_tex_men = @ar_tex_men,
	                  va_des_men = @ar_des_men,
					  va_ide_pad = @ar_ide_pad
			    WHERE va_nom_frm = @ar_nom_frm
				  AND va_ide_men = @ar_ide_men
	IF (@@ERROR > 0)
		RETURN 0
END

--** Todo OK
RETURN 1