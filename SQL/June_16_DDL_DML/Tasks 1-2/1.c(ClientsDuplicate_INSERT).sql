USE [Altexsoft_Delivery]
GO

DROP TABLE ClientsDuplicate

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ClientsDuplicate](
	[ClientID] [int] IDENTITY(0,1) NOT NULL,
	[FirstName] [nvarchar](15) NOT NULL,
	[LastName] [nvarchar](20) NULL,
	[Dob] [date] NULL,
	[PhoneNumber] [nvarchar](40) NULL,
	[Email] [nvarchar](40) NULL,
	[CreditCardAttached] [bit] NOT NULL,
 CONSTRAINT [PK_ClientsDuplicate] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO ClientsDuplicate
SELECT FirstName, LastName, Dob, PhoneNumber, Email, CreditCardAttached
FROM Clients
