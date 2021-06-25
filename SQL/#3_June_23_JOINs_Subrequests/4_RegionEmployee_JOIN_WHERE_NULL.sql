USE [Northwind]
GO

SELECT Region.RegionID
      ,[RegionDescription]
	  ,Territories.RegionID AS TerritoriesRegionID
  FROM [dbo].[Region]
  LEFT OUTER JOIN Territories ON Territories.RegionID = Region.RegionID
  WHERE Territories.RegionID IS NULL

GO


