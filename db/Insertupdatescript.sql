USE [EquipmentVentilation]
GO

/****** Object:  StoredProcedure [dbo].[InsertVentilationMonitorMain]    Script Date: 2/17/2020 12:43:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--DECLARE @Objects VentilationMonitorMain;

--INSERT INTO @Objects (Unit, DepartmentName, Quantity)
--VALUES ('Unit21', 'Dept1', 21)
--    , ('Unit21', 'Dept2', 34)
--    , ('Unit21', 'Dept3', 45)
--	, ('Unit21', 'Dept4', 45)
--	, ('Unit21', 'Dept5', 34);

--EXECUTE dbo.InsertVentilationMonitorMain @Objects = @Objects

CREATE PROCEDURE [dbo].[InsertVentilationMonitorMain] (@Objects VentilationMonitorMain READONLY)
AS
	 SET NOCOUNT ON;
	BEGIN
	IF OBJECT_ID('tempdb..##temp') IS NOT NULL 
	DROP TABLE ##temp
    SELECT * into ##temp
    FROM @Objects;

	DECLARE @cols AS NVARCHAR(MAX),
    @query  AS NVARCHAR(MAX);
	
	SET @cols = STUFF((SELECT distinct ',' + QUOTENAME(c.DepartmentName) 
            FROM ##temp c
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,1,'')



--Check if field exists or not
	IF OBJECT_ID('VentilationMonitorMainVariant') IS NULL
	CREATE TABLE VentilationMonitorMainVariant (ID INT Identity(1,1) not null,Unit VARCHAR(8000))

	IF OBJECT_ID('tempdb..#tmpColumnList') IS NOT NULL
	DROP TABLE #tmpColumnList

	SELECT COLUMN_NAME AS colName
	INTO #tmpColumnList
	from INFORMATION_SCHEMA.COLUMNS
	where TABLE_NAME='VentilationMonitorMainVariant'

	DECLARE @ColList VARCHAR(8000)
	SET @ColList = STUFF((SELECT distinct ',' +'''' +c.colName +''''
				FROM #tmpColumnList c
				FOR XML PATH(''), TYPE
				).value('.', 'NVARCHAR(MAX)') 
			,1,1,'')


	--select * from #tmpColumnList

	IF OBJECT_ID('tempdb..##ColumnCretedList') IS NOT NULL
	DROP TABLE ##ColumnCretedList

	DECLARE @SqlStm VARCHAR(8000)

	SET @SqlStm='
	SELECT DepartmentName
	INTO ##ColumnCretedList
	FROM ##temp
	WHERE DepartmentName NOT IN ('+@ColList+')'

	PRINT(@SqlStm)
	EXEC(@SqlStm)

	DECLARE @ColCreatedList VARCHAR(8000)

	SET @ColCreatedList = STUFF((SELECT distinct ','  +c.DepartmentName +' VARCHAR(8000)'
				FROM ##ColumnCretedList c
				FOR XML PATH(''), TYPE
				).value('.', 'NVARCHAR(MAX)') 
			,1,1,'')

declare @mode nvarchar(100)


if(exists(select @ColCreatedList) and   exists (Select top 1 * from VentilationMonitorMainVariant where unit in  (select Unit from ##temp)))
begin
 set @mode='U'
end
else if(exists(select @ColCreatedList) and  not  exists (Select top 1 * from VentilationMonitorMainVariant where unit in  (select Unit from ##temp)))
begin
 set @mode='I'
end
else
begin
set @mode='U'
end
print @mode
SET @SqlStm='ALTER TABLE VentilationMonitorMainVariant ADD '+@ColCreatedList+''
		PRINT(@SqlStm)
		EXEC(@SqlStm)	

	If (@mode='I')
		BEGIN
			SET @query = '
				INSERT INTO VentilationMonitorMainVariant
				SELECT Unit, ' + @cols + ' from 
							(
								select Unit
									, Quantity
									, DepartmentName
								from ##temp
						   ) x
							pivot 
							(
								 max(Quantity)
								for DepartmentName in (' + @cols + ')
							) p '

			print @query
			EXECUTE(@query)
		END
		ELSE 
		BEGIN
			
			Declare @colNameUpdate nvarchar(max)
			Declare @QuantityUpdate int
			Declare @Units nvarchar(max)
			Declare @Id int
			Declare @count int = (select count(*) from ##temp)
			
			WHILE (@count> = 0)
				BEGIN
					Select Top 1 @Id=Id ,@colNameUpdate = DepartmentName,@QuantityUpdate=Quantity,@Units=Unit from ##temp

					--SET  @colNameUpdate = (select DepartmentName from ##temp)
					--SET  @QuantityUpdate = (select Quantity from ##temp)
					--SET  @Units = (select Unit from ##temp)

					Declare @sql nvarchar(MAX)
					DECLARE @ParmDefinition nvarchar(500)
					SET @ParmDefinition = N'@Units1 nvarchar(max),@QuantityUpdate1 int';

					Set @sql = N'update dbo.VentilationMonitorMainVariant SET '+ @colNameUpdate+ '=@QuantityUpdate1 Where Unit = @Units1;'
					
					   exec sp_executesql @sql, @ParmDefinition, @Units,@QuantityUpdate;
					   DELETE FROM	##temp where Id=@Id
					   Set @count = @count - 1
				END
			END
--------------------

	



	END

GO


