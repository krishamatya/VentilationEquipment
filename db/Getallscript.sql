USE [EquipmentVentilation]
GO

/****** Object:  StoredProcedure [dbo].[GetAllVentilationEquipment]    Script Date: 2/17/2020 12:43:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllVentilationEquipment] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from VentilationMonitorMainVariant
END

GO


