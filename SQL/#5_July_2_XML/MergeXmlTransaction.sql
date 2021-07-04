DECLARE @hdoc INT
DECLARE @request NVARCHAR(4000)
SET @request = N'<XmlTest>
	<Element>
		<XmlID>1</XmlID>
		<XmlName>TestName1</XmlName>
		<XmlDesc>description1</XmlDesc>
	</Element>
	<Element>
		<XmlID>2</XmlID>
		<XmlName>TestName2</XmlName>
		<XmlDesc>description2</XmlDesc>
	</Element>
	<Element>
		<XmlID>3</XmlID>
		<XmlName>TestName3</XmlName>
		<XmlDesc>description3</XmlDesc>
	</Element>
	<Element>
		<XmlID>4</XmlID>
		<XmlName>TestName4</XmlName>
		<XmlDesc>description4</XmlDesc>
	</Element>
</XmlTest>'
DECLARE @tableName NVARCHAR(40)
SET @tableName = 'XmlTest'

BEGIN TRANSACTION

BEGIN TRY
	EXEC sp_MergeXmlWithTable @request, @tableName, @hdoc
	EXEC sp_XML_removedocument @hdoc
	COMMIT
END TRY
BEGIN CATCH
	EXEC sp_XML_removedocument @hdoc
	ROLLBACK
END CATCH

SELECT * FROM XmlTest