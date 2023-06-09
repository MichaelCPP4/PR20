USE [master]
GO
/****** Object:  Database [Bd10]    Script Date: 04.05.2023 16:13:36 ******/
CREATE DATABASE [Bd10]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bd10', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Bd10.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'Bd10_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Bd10_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Bd10] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bd10].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bd10] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bd10] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bd10] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bd10] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bd10] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bd10] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bd10] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bd10] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bd10] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bd10] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bd10] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bd10] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bd10] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bd10] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bd10] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Bd10] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bd10] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bd10] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bd10] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bd10] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bd10] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bd10] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bd10] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Bd10] SET  MULTI_USER 
GO
ALTER DATABASE [Bd10] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bd10] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bd10] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bd10] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Bd10] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Bd10] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Bd10] SET QUERY_STORE = OFF
GO
USE [Bd10]
GO
/****** Object:  Table [dbo].[DirectoryOfEmployees]    Script Date: 04.05.2023 16:13:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DirectoryOfEmployees](
	[ID] [int] NOT NULL,
	[ServiceNumber] [int] NOT NULL,
	[Surname] [nchar](15) NOT NULL,
	[Category] [nchar](20) NOT NULL,
	[Workshop] [nchar](20) NOT NULL,
 CONSTRAINT [PK_DirectoryOfEmployees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListOfWorkshops]    Script Date: 04.05.2023 16:13:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListOfWorkshops](
	[Workshop] [nchar](20) NOT NULL,
	[WorkshopName] [nchar](20) NOT NULL,
 CONSTRAINT [PK_ListOfWorkshops] PRIMARY KEY CLUSTERED 
(
	[Workshop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportCard]    Script Date: 04.05.2023 16:13:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportCard](
	[ServiceNumber] [int] NOT NULL,
	[TimeWorkedInHours] [int] NOT NULL,
	[MonthNumber] [int] NOT NULL,
 CONSTRAINT [PK_ReportCard] PRIMARY KEY CLUSTERED 
(
	[ServiceNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TariffReference]    Script Date: 04.05.2023 16:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TariffReference](
	[Category] [nchar](20) NOT NULL,
	[rate] [money] NOT NULL,
 CONSTRAINT [PK_TariffReference_1] PRIMARY KEY CLUSTERED 
(
	[Category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DirectoryOfEmployees] ([ID], [ServiceNumber], [Surname], [Category], [Workshop]) VALUES (1, 1, N'Карпов         ', N'Равномерная         ', N'Основной            ')
INSERT [dbo].[DirectoryOfEmployees] ([ID], [ServiceNumber], [Surname], [Category], [Workshop]) VALUES (2, 2, N'Ибрагим        ', N'Регрессивная        ', N'Вспомогательный     ')
INSERT [dbo].[DirectoryOfEmployees] ([ID], [ServiceNumber], [Surname], [Category], [Workshop]) VALUES (3, 3, N'Петров         ', N'Прогрессивная       ', N'Заготовитель        ')
INSERT [dbo].[DirectoryOfEmployees] ([ID], [ServiceNumber], [Surname], [Category], [Workshop]) VALUES (4, 4, N'Богданов       ', N'Равномерная         ', N'Основной            ')
INSERT [dbo].[DirectoryOfEmployees] ([ID], [ServiceNumber], [Surname], [Category], [Workshop]) VALUES (5, 5, N'Сидоров        ', N'Регрессивная        ', N'Вспомогательный     ')
GO
INSERT [dbo].[ListOfWorkshops] ([Workshop], [WorkshopName]) VALUES (N'Вспомогательный     ', N'РемонтныйАБОБА      ')
INSERT [dbo].[ListOfWorkshops] ([Workshop], [WorkshopName]) VALUES (N'Заготовитель        ', N'Кузнечный           ')
INSERT [dbo].[ListOfWorkshops] ([Workshop], [WorkshopName]) VALUES (N'Основной            ', N'Механический        ')
GO
INSERT [dbo].[ReportCard] ([ServiceNumber], [TimeWorkedInHours], [MonthNumber]) VALUES (1, 76, 5)
INSERT [dbo].[ReportCard] ([ServiceNumber], [TimeWorkedInHours], [MonthNumber]) VALUES (2, 100, 12)
INSERT [dbo].[ReportCard] ([ServiceNumber], [TimeWorkedInHours], [MonthNumber]) VALUES (3, 96, 9)
INSERT [dbo].[ReportCard] ([ServiceNumber], [TimeWorkedInHours], [MonthNumber]) VALUES (4, 56, 10)
INSERT [dbo].[ReportCard] ([ServiceNumber], [TimeWorkedInHours], [MonthNumber]) VALUES (5, 456, 4)
GO
INSERT [dbo].[TariffReference] ([Category], [rate]) VALUES (N'1                   ', 1.0000)
INSERT [dbo].[TariffReference] ([Category], [rate]) VALUES (N'Прогрессивная       ', 54.0000)
INSERT [dbo].[TariffReference] ([Category], [rate]) VALUES (N'Равномерная         ', 200.0000)
INSERT [dbo].[TariffReference] ([Category], [rate]) VALUES (N'Регрессивная        ', 230.0000)
INSERT [dbo].[TariffReference] ([Category], [rate]) VALUES (N'Смешанная           ', 216.0000)
GO
ALTER TABLE [dbo].[DirectoryOfEmployees]  WITH CHECK ADD  CONSTRAINT [FK_DirectoryOfEmployees_ListOfWorkshops] FOREIGN KEY([Workshop])
REFERENCES [dbo].[ListOfWorkshops] ([Workshop])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DirectoryOfEmployees] CHECK CONSTRAINT [FK_DirectoryOfEmployees_ListOfWorkshops]
GO
ALTER TABLE [dbo].[DirectoryOfEmployees]  WITH CHECK ADD  CONSTRAINT [FK_DirectoryOfEmployees_ReportCard] FOREIGN KEY([ServiceNumber])
REFERENCES [dbo].[ReportCard] ([ServiceNumber])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DirectoryOfEmployees] CHECK CONSTRAINT [FK_DirectoryOfEmployees_ReportCard]
GO
ALTER TABLE [dbo].[DirectoryOfEmployees]  WITH CHECK ADD  CONSTRAINT [FK_DirectoryOfEmployees_TariffReference] FOREIGN KEY([Category])
REFERENCES [dbo].[TariffReference] ([Category])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DirectoryOfEmployees] CHECK CONSTRAINT [FK_DirectoryOfEmployees_TariffReference]
GO
USE [master]
GO
ALTER DATABASE [Bd10] SET  READ_WRITE 
GO
