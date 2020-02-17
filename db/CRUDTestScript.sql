DECLARE @Objects VentilationMonitorMain;

INSERT INTO @Objects (Id,Unit, DepartmentName, Quantity)
VALUES ('0','Unit1', 'LGW', 21),
('0','Unit1', 'MG13', 23),
('0','Unit1', 'MG14', 23)
   

EXECUTE dbo.InsertVentilationMonitorMain @Objects = @Objects