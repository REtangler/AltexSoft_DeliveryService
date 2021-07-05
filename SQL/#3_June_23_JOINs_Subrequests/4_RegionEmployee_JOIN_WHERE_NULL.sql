USE [Northwind]
GO

SELECT Region.RegionID
      ,[RegionDescription]
  FROM [dbo].[EmployeeTerritories]
  INNER JOIN Territories ON Territories.TerritoryID = EmployeeTerritories.TerritoryID
  RIGHT JOIN [dbo].[Region] ON Region.RegionID = Territories.RegionID
  WHERE Territories.RegionID IS NULL

GO


