USE [master]
GO
/****** Object:  Database [CoronaCheck]    Script Date: 17-12-2021 10:30:40 ******/
CREATE DATABASE [CoronaCheck]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CoronaCheck', FILENAME = N'C:\Users\Richard Swinkels\CoronaCheck.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CoronaCheck_log', FILENAME = N'C:\Users\Richard Swinkels\CoronaCheck_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CoronaCheck] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CoronaCheck].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CoronaCheck] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CoronaCheck] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CoronaCheck] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CoronaCheck] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CoronaCheck] SET ARITHABORT OFF 
GO
ALTER DATABASE [CoronaCheck] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CoronaCheck] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CoronaCheck] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CoronaCheck] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CoronaCheck] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CoronaCheck] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CoronaCheck] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CoronaCheck] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CoronaCheck] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CoronaCheck] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CoronaCheck] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CoronaCheck] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CoronaCheck] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CoronaCheck] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CoronaCheck] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CoronaCheck] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CoronaCheck] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CoronaCheck] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CoronaCheck] SET  MULTI_USER 
GO
ALTER DATABASE [CoronaCheck] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CoronaCheck] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CoronaCheck] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CoronaCheck] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CoronaCheck] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CoronaCheck] SET QUERY_STORE = OFF
GO
USE [CoronaCheck]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [CoronaCheck]
GO
/****** Object:  Table [dbo].[Binnenwedstrijden]    Script Date: 17-12-2021 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Binnenwedstrijden](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [varchar](200) NULL,
	[StartDatum] [date] NULL,
	[WedstrijdDuur] [time](7) NULL,
	[Doorstroom] [bit] NOT NULL,
 CONSTRAINT [PK_Binnenwedstrijd] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BioscoopUitjes]    Script Date: 17-12-2021 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BioscoopUitjes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [varchar](200) NULL,
	[StartDatum] [date] NULL,
	[Doorstroom] [bit] NOT NULL,
	[BinnenEvent] [bit] NOT NULL,
	[AanvangsTijdstip] [datetime] NOT NULL,
	[Duur] [time](7) NOT NULL,
	[Film] [varchar](200) NOT NULL,
	[Zaal] [varchar](3) NOT NULL,
	[Stoel] [varchar](3) NOT NULL,
 CONSTRAINT [PK_BioscoopUitje] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Buitenwedstrijden]    Script Date: 17-12-2021 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buitenwedstrijden](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [varchar](200) NULL,
	[StartDatum] [date] NULL,
	[WedstrijdDuur] [time](7) NULL,
	[Doorstroom] [bit] NOT NULL,
 CONSTRAINT [PK_Buitenwedstrijden] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MuseumUitjes]    Script Date: 17-12-2021 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MuseumUitjes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [varchar](200) NULL,
	[StartDatum] [date] NULL,
	[Doorstroom] [bit] NOT NULL,
	[BinnenEvent] [bit] NOT NULL,
	[Toegangsprijs] [money] NOT NULL,
 CONSTRAINT [PK_MuseumUitjes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Binnenwedstrijden] ON 

INSERT [dbo].[Binnenwedstrijden] ([Id], [Naam], [StartDatum], [WedstrijdDuur], [Doorstroom]) VALUES (1001, N'Zaalvoetbal', CAST(N'2021-12-17' AS Date), CAST(N'01:30:00' AS Time), 0)
INSERT [dbo].[Binnenwedstrijden] ([Id], [Naam], [StartDatum], [WedstrijdDuur], [Doorstroom]) VALUES (2001, N'Wedstrijd', CAST(N'2021-12-17' AS Date), CAST(N'01:30:00' AS Time), 0)
SET IDENTITY_INSERT [dbo].[Binnenwedstrijden] OFF
GO
SET IDENTITY_INSERT [dbo].[BioscoopUitjes] ON 

INSERT [dbo].[BioscoopUitjes] ([Id], [Naam], [StartDatum], [Doorstroom], [BinnenEvent], [AanvangsTijdstip], [Duur], [Film], [Zaal], [Stoel]) VALUES (1001, N'Bioscoop', CAST(N'2021-12-17' AS Date), 0, 1, CAST(N'2021-12-17T10:00:00.000' AS DateTime), CAST(N'02:00:00' AS Time), N'test', N'1', N'1')
SET IDENTITY_INSERT [dbo].[BioscoopUitjes] OFF
GO
SET IDENTITY_INSERT [dbo].[Buitenwedstrijden] ON 

INSERT [dbo].[Buitenwedstrijden] ([Id], [Naam], [StartDatum], [WedstrijdDuur], [Doorstroom]) VALUES (1, N'Buitenvoetbal', CAST(N'2021-12-17' AS Date), CAST(N'01:30:00' AS Time), 0)
SET IDENTITY_INSERT [dbo].[Buitenwedstrijden] OFF
GO
SET IDENTITY_INSERT [dbo].[MuseumUitjes] ON 

INSERT [dbo].[MuseumUitjes] ([Id], [Naam], [StartDatum], [Doorstroom], [BinnenEvent], [Toegangsprijs]) VALUES (1001, N'Museum', CAST(N'2021-12-17' AS Date), 0, 0, 20.0000)
SET IDENTITY_INSERT [dbo].[MuseumUitjes] OFF
GO
USE [master]
GO
ALTER DATABASE [CoronaCheck] SET  READ_WRITE 
GO
