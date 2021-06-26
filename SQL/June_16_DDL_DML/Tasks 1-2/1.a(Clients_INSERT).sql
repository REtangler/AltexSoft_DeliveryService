USE [Altexsoft_Delivery]
GO

ALTER TABLE Clients
ALTER COLUMN Dob date;
ALTER TABLE Clients
ALTER COLUMN Email nvarchar(40);

INSERT INTO [dbo].[Clients]
     VALUES
           ('Steffen', 'Schultz', '1955-06-02', '04681 35 07 72', 'SteffenSchultz@jourrapide.com', 1),
		   ('Mandy', 'Junker', '1970-09-21', '0421 60 57 15', 'MandyJunker@teleworm.us', 0),
		   ('Erik', 'Bauer', '1939-05-31', '06486 74 13 52', 'ErikBauer@jourrapide.com', 1),
		   ('Alice', 'Uvarova', '1974-12-01', '850-304-7248', 'AliceUvarova@dayrep.com', 1),
		   ('Arina', 'Prokhorova', '1963-04-15', '719-372-8173', 'ArinaProkhorova@armyspy.com', 0),
		   ('Novel', 'Kovalev', '1964-02-10', '719-676-8417', 'NovelKovalev@rhyta.com', 0),
		   ('Charles', 'Staab', '1972-01-06', '417-298-5298', 'CharlesSStaab@dayrep.com', 0),
		   ('John', 'Mahler', '1952-09-13', '404-579-0659', 'JohnPMahler@teleworm.us', 1)
GO


