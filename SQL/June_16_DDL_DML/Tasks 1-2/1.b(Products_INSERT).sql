USE [Altexsoft_Delivery]
GO

ALTER TABLE Products
ALTER COLUMN Name nvarchar(100);
DELETE FROM Products
DBCC CHECKIDENT ('Altexsoft_Delivery.dbo.Products',RESEED, 0)

INSERT INTO [dbo].[Products] (Name, Category, Price, Amount)
     VALUES
           ('GeForce GTX 1050 Ti', 'GPU', 7999, 131),
		   ('GeForce GTX 1650', 'GPU', 11199, 232),
		   ('Radeon RX 6700 XT', 'GPU', 40999, 54),
		   ('Ryzen 5 1600', 'CPU', 3927, 445),
		   ('Ryzen 5 5600X', 'CPU', 9509, 333),
		   ('Core i7-11700', 'CPU', 11505, 150),
		   ('Core i5-11400', 'CPU', 7429, 432),
		   ('HyperX DDR4-2666 16384MB', 'RAM', 2659, 298),
		   ('Prime H410M-K', 'MB', 1999, 233),
		   ('870 Evo-Series 500GB', 'SSD', 2499, 103),
		   ('M185 Wireless Grey', 'Mice', 539, 59),
		   ('M170 Wireless Black', 'Mice', 339, 122),
		   ('MX Master 3 Advanced Wireless Bluetooth Black', 'Mice', 2999, 22),
		   ('B100 USB Black', 'Mice', 199, 232),
		   ('Alloy FPS Pro Cherry MX Red USB', 'Keyboards', 2299, 54),
		   ('8700 Backlit USB GTX 1050 Ti', 'Keyboards', 369, 322)
GO


