USE [EquipmentVentilation]
GO
/****** Object:  StoredProcedure [dbo].[DeleteVentilationEquipment]    Script Date: 2/17/2020 2:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[DeleteVentilationEquipment](
@Id int
) 
As
	BEGIN
		DELETE FROM VentilationMonitorMainVariant WHERE ID=@Id
	END