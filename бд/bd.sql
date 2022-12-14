USE [master]
GO
/****** Object:  Database [MatveevPP]    Script Date: 18.10.2022 13:16:05 ******/
CREATE DATABASE [MatveevPP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MatveevPP', FILENAME = N'D:\SQLSERVER\MatveevPP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MatveevPP_log', FILENAME = N'D:\SQLSERVER\MatveevPP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MatveevPP] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MatveevPP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MatveevPP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MatveevPP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MatveevPP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MatveevPP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MatveevPP] SET ARITHABORT OFF 
GO
ALTER DATABASE [MatveevPP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MatveevPP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MatveevPP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MatveevPP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MatveevPP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MatveevPP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MatveevPP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MatveevPP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MatveevPP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MatveevPP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MatveevPP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MatveevPP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MatveevPP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MatveevPP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MatveevPP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MatveevPP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MatveevPP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MatveevPP] SET RECOVERY FULL 
GO
ALTER DATABASE [MatveevPP] SET  MULTI_USER 
GO
ALTER DATABASE [MatveevPP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MatveevPP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MatveevPP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MatveevPP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MatveevPP] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MatveevPP', N'ON'
GO
ALTER DATABASE [MatveevPP] SET QUERY_STORE = OFF
GO
USE [MatveevPP]
GO
/****** Object:  Table [dbo].[ADD_customers]    Script Date: 18.10.2022 13:16:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADD_customers](
	[ADD_code] [int] IDENTITY(1,1) NOT NULL,
	[Organizations_code] [int] NOT NULL,
	[ServicesADD_code] [int] NOT NULL,
 CONSTRAINT [PK_ADD] PRIMARY KEY CLUSTERED 
(
	[ADD_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calculation]    Script Date: 18.10.2022 13:16:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calculation](
	[Calculation_code] [int] IDENTITY(1,1) NOT NULL,
	[Organizations_code] [int] NOT NULL,
	[MG_OSIPS] [float] NOT NULL,
	[MG_m200] [float] NOT NULL,
 CONSTRAINT [PK_Calculation] PRIMARY KEY CLUSTERED 
(
	[Calculation_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Internet]    Script Date: 18.10.2022 13:16:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Internet](
	[Internet_code] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](100) NOT NULL,
	[Cost] [float] NOT NULL,
 CONSTRAINT [PK_Internet] PRIMARY KEY CLUSTERED 
(
	[Internet_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Number]    Script Date: 18.10.2022 13:16:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Number](
	[Number_code] [int] IDENTITY(1,1) NOT NULL,
	[Organizations_code] [int] NOT NULL,
	[Number] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Number] PRIMARY KEY CLUSTERED 
(
	[Number_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organizations]    Script Date: 18.10.2022 13:16:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organizations](
	[Organizations_code] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Organizations] PRIMARY KEY CLUSTERED 
(
	[Organizations_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services_customers]    Script Date: 18.10.2022 13:16:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services_customers](
	[Services_customers_code] [int] IDENTITY(1,1) NOT NULL,
	[Organizations_code] [int] NOT NULL,
	[Internet_code] [int] NOT NULL,
	[AP_code] [int] NOT NULL,
 CONSTRAINT [PK_Services_customers] PRIMARY KEY CLUSTERED 
(
	[Services_customers_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServicesADD]    Script Date: 18.10.2022 13:16:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServicesADD](
	[ServicesADD_code] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](100) NOT NULL,
	[Cost] [float] NOT NULL,
 CONSTRAINT [PK_ServicesADD] PRIMARY KEY CLUSTERED 
(
	[ServicesADD_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubscriptionFee]    Script Date: 18.10.2022 13:16:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubscriptionFee](
	[AP_code] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](100) NOT NULL,
	[Cost] [float] NOT NULL,
 CONSTRAINT [PK_SubscriptionFee] PRIMARY KEY CLUSTERED 
(
	[AP_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ADD_customers]  WITH CHECK ADD  CONSTRAINT [FK_ADD_customers_ServicesADD] FOREIGN KEY([ServicesADD_code])
REFERENCES [dbo].[ServicesADD] ([ServicesADD_code])
GO
ALTER TABLE [dbo].[ADD_customers] CHECK CONSTRAINT [FK_ADD_customers_ServicesADD]
GO
ALTER TABLE [dbo].[ADD_customers]  WITH CHECK ADD  CONSTRAINT [FK_ADD_Organizations] FOREIGN KEY([Organizations_code])
REFERENCES [dbo].[Organizations] ([Organizations_code])
GO
ALTER TABLE [dbo].[ADD_customers] CHECK CONSTRAINT [FK_ADD_Organizations]
GO
ALTER TABLE [dbo].[Calculation]  WITH CHECK ADD  CONSTRAINT [FK_Calculation_Organizations] FOREIGN KEY([Organizations_code])
REFERENCES [dbo].[Organizations] ([Organizations_code])
GO
ALTER TABLE [dbo].[Calculation] CHECK CONSTRAINT [FK_Calculation_Organizations]
GO
ALTER TABLE [dbo].[Number]  WITH CHECK ADD  CONSTRAINT [FK_Number_Organizations] FOREIGN KEY([Organizations_code])
REFERENCES [dbo].[Organizations] ([Organizations_code])
GO
ALTER TABLE [dbo].[Number] CHECK CONSTRAINT [FK_Number_Organizations]
GO
ALTER TABLE [dbo].[Services_customers]  WITH CHECK ADD  CONSTRAINT [FK_Services_customers_Internet] FOREIGN KEY([Internet_code])
REFERENCES [dbo].[Internet] ([Internet_code])
GO
ALTER TABLE [dbo].[Services_customers] CHECK CONSTRAINT [FK_Services_customers_Internet]
GO
ALTER TABLE [dbo].[Services_customers]  WITH CHECK ADD  CONSTRAINT [FK_Services_customers_Organizations] FOREIGN KEY([Organizations_code])
REFERENCES [dbo].[Organizations] ([Organizations_code])
GO
ALTER TABLE [dbo].[Services_customers] CHECK CONSTRAINT [FK_Services_customers_Organizations]
GO
ALTER TABLE [dbo].[Services_customers]  WITH CHECK ADD  CONSTRAINT [FK_Services_customers_SubscriptionFee] FOREIGN KEY([AP_code])
REFERENCES [dbo].[SubscriptionFee] ([AP_code])
GO
ALTER TABLE [dbo].[Services_customers] CHECK CONSTRAINT [FK_Services_customers_SubscriptionFee]
GO
USE [master]
GO
ALTER DATABASE [MatveevPP] SET  READ_WRITE 
GO
