USE [Northwind]
GO

SELECT Region.RegionID
      ,[RegionDescription]
  FROM [dbo].[Region]
  LEFT OUTER JOIN Territories ON Territories.RegionID = Region.RegionID
  LEFT OUTER JOIN [dbo].[EmployeeTerritories] ON EmployeeTerritories.TerritoryID = Territories.TerritoryID
  WHERE EmployeeTerritories.TerritoryID IS NULL AND Territories.RegionID IS NULL

GO


