USE [Northwind]
GO

SELECT LastName
      ,FirstName
	  ,Territories.TerritoryDescription
	  ,Region.RegionDescription
  FROM [dbo].[Employees]
  RIGHT JOIN [dbo].[EmployeeTerritories] ON Employees.EmployeeID = EmployeeTerritories.EmployeeID
  LEFT JOIN [dbo].[Territories] ON EmployeeTerritories.TerritoryID = Territories.TerritoryID
  LEFT JOIN [dbo].[Region] ON Territories.RegionID = Region.RegionID

GO


