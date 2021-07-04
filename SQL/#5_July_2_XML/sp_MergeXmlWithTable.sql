SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_MergeXmlWithTable (
	@request XML, 
	@tableName VARCHAR(40),
	@hdoc INT OUTPUT)
AS
BEGIN
	SET NOCOUNT ON;
	
	EXEC sp_XML_preparedocument @hdoc OUTPUT, @request

	CREATE TABLE #TempXmlTable (XmlID INT, XmlName VARCHAR(40), XmlDesc VARCHAR(40))
	INSERT INTO #TempXmlTable 
	SELECT XmlID, XmlName, XmlDesc FROM OPENXML(@hdoc, '/XmlTest/Element', 2) 
	WITH (XmlID INT, XmlName VARCHAR(40), XmlDesc VARCHAR(40))

	SELECT * FROM #TempXmlTable
	
	EXEC(
		'MERGE ' + @tableName + ' AS TARGET
		USING #TempXmlTable AS SOURCE
		ON TARGET.XmlID = SOURCE.XmlID

		WHEN MATCHED AND TARGET.XmlName <> SOURCE.XmlName
		THEN UPDATE SET TARGET.XmlName = SOURCE.XmlName

		WHEN NOT MATCHED BY TARGET 
		THEN INSERT (XmlID, XmlName, XmlDesc) VALUES (SOURCE.XmlID, SOURCE.XmlName, SOURCE.XmlDesc)
		WHEN NOT MATCHED BY SOURCE 
		THEN DELETE 

		OUTPUT $action, 
		DELETED.XmlID AS TargetXmlID, 
		DELETED.XmlName AS TargetXmlName, 
		DELETED.XmlDesc AS XmlDesc, 
		INSERTED.XmlID AS SourceXmlID, 
		INSERTED.XmlName AS SourceXmlName, 
		INSERTED.XmlDesc AS XmlDesc;'
		)
END
GO
