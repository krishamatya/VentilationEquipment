USE [EquipmentVentilation]
GO

/****** Object:  UserDefinedTableType [dbo].[VentilationMonitorMain]    Script Date: 2/16/2020 10:12:04 PM ******/
CREATE TYPE [dbo].[VentilationMonitorMain] AS TABLE(
	[Id] [int] NOT NULL,
	[Unit] [varchar](8000) NULL,
	[DepartmentName] [varchar](max) NULL,
	[Quantity] [int] NULL)	
GO


