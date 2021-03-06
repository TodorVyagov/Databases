USE [master]
GO
/****** Object:  Database [Earth]    Script Date: 22-Aug-14 17:28:40 ******/
CREATE DATABASE [Earth]
GO
ALTER DATABASE [Earth] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Earth].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Earth] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Earth] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Earth] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Earth] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Earth] SET ARITHABORT OFF 
GO
ALTER DATABASE [Earth] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Earth] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Earth] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Earth] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Earth] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Earth] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Earth] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Earth] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Earth] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Earth] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Earth] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Earth] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Earth] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Earth] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Earth] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Earth] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Earth] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Earth] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Earth] SET RECOVERY FULL 
GO
ALTER DATABASE [Earth] SET  MULTI_USER 
GO
ALTER DATABASE [Earth] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Earth] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Earth] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Earth] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Earth', N'ON'
GO
USE [Earth]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 22-Aug-14 17:28:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[AddressText] [nvarchar](50) NOT NULL,
	[TownID] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 22-Aug-14 17:28:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[ContinentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[ContinentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 22-Aug-14 17:28:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinentID] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 22-Aug-14 17:28:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FIrstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressID] [int] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 22-Aug-14 17:28:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[TownID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[TownID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([AddressID], [AddressText], [TownID]) VALUES (1, N'Mladost1A', 4)
INSERT [dbo].[Addresses] ([AddressID], [AddressText], [TownID]) VALUES (2, N'zh.k.Trakiya', 5)
INSERT [dbo].[Addresses] ([AddressID], [AddressText], [TownID]) VALUES (3, N'Krasno Selo', 4)
INSERT [dbo].[Addresses] ([AddressID], [AddressText], [TownID]) VALUES (4, N'Manhattan', 1)
INSERT [dbo].[Addresses] ([AddressID], [AddressText], [TownID]) VALUES (5, N'Bronx', 1)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (1, N'Africa')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (2, N'South America')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (3, N'North America')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (4, N'Europe')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (5, N'Asia')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (6, N'Australia')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (1, N'Bulgaria', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (2, N'USA', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (3, N'Germany', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (4, N'China', 5)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (5, N'Ivory Coast', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (6, N'Brasilia', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (7, N'Canada', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (8, N'Japan', 5)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([ID], [FIrstName], [LastName], [AddressID]) VALUES (1, N'Ivaylo', N'Kenov', 1)
INSERT [dbo].[Persons] ([ID], [FIrstName], [LastName], [AddressID]) VALUES (2, N'Doncho ', N'Minkov', 1)
INSERT [dbo].[Persons] ([ID], [FIrstName], [LastName], [AddressID]) VALUES (3, N'John', N'Smith', 4)
INSERT [dbo].[Persons] ([ID], [FIrstName], [LastName], [AddressID]) VALUES (4, N'Nikolay', N'Kostov', 3)
INSERT [dbo].[Persons] ([ID], [FIrstName], [LastName], [AddressID]) VALUES (8, N'Philip', N'Smith', 5)
SET IDENTITY_INSERT [dbo].[Persons] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (1, N'New York', 2)
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (2, N'Berlin', 3)
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (3, N'Rio', 6)
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (4, N'Sofia', 1)
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (5, N'Plovdiv', 1)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownID])
REFERENCES [dbo].[Towns] ([TownID])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentID])
REFERENCES [dbo].[Continents] ([ContinentID])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Addresses] FOREIGN KEY([AddressID])
REFERENCES [dbo].[Addresses] ([AddressID])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([CountryID])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
USE [master]
GO
ALTER DATABASE [Earth] SET  READ_WRITE 
GO
