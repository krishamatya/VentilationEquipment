USE [EquipmentVentilation]
GO

/****** Object:  StoredProcedure [dbo].[DeleteVentilationEquipment]    Script Date: 2/17/2020 12:43:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[DeleteVentilationEquipment](
@Id int
) 
As
	BEGIN
		DELETE FROM VentilationMonitorMainVariant WHERE ID=@Id
	END
GO


