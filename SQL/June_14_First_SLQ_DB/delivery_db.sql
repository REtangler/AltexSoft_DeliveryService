USE [master]
GO
/****** Object:  Database [Altexsoft_Delivery]    Script Date: 17.06.2021 23:53:16 ******/
CREATE DATABASE [Altexsoft_Delivery]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Altexsoft_Delivery', FILENAME = N'C:\Users\lysak\Altexsoft_Delivery.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Altexsoft_Delivery_log', FILENAME = N'C:\Users\lysak\Altexsoft_Delivery_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Altexsoft_Delivery] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Altexsoft_Delivery].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Altexsoft_Delivery] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET ARITHABORT OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Altexsoft_Delivery] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Altexsoft_Delivery] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Altexsoft_Delivery] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Altexsoft_Delivery] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Altexsoft_Delivery] SET  MULTI_USER 
GO
ALTER DATABASE [Altexsoft_Delivery] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Altexsoft_Delivery] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Altexsoft_Delivery] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Altexsoft_Delivery] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Altexsoft_Delivery] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Altexsoft_Delivery] SET QUERY_STORE = OFF
GO
USE [Altexsoft_Delivery]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Altexsoft_Delivery]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 17.06.2021 23:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientID] [int] IDENTITY(0,1) NOT NULL,
	[FirstName] [nvarchar](15) NOT NULL,
	[LastName] [nvarchar](20) NULL,
	[Dob] [datetime] NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[Email] [nvarchar](20) NOT NULL,
	[CreditCardAttached] [bit] NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 17.06.2021 23:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(0,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[FullPrice] [decimal](18, 0) NOT NULL,
	[Address] [nvarchar](25) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdersProducts]    Script Date: 17.06.2021 23:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersProducts](
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_OrdersProducts] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 17.06.2021 23:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(0,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[Category] [nvarchar](20) NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Manufacturer] [nvarchar](20) NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_PcParts1] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Clients] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Clients]
GO
ALTER TABLE [dbo].[OrdersProducts]  WITH CHECK ADD  CONSTRAINT [FK_OrdersProducts_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrdersProducts] CHECK CONSTRAINT [FK_OrdersProducts_Orders]
GO
ALTER TABLE [dbo].[OrdersProducts]  WITH CHECK ADD  CONSTRAINT [FK_OrdersProducts_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[OrdersProducts] CHECK CONSTRAINT [FK_OrdersProducts_Products]
GO
USE [master]
GO
ALTER DATABASE [Altexsoft_Delivery] SET  READ_WRITE 
GO
