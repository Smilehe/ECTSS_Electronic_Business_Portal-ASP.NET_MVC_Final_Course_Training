﻿USE [master]
GO
/****** Object:  Database [ECTSS]    Script Date: 2017/6/15 23:32:14 ******/
CREATE DATABASE [ECTSS] ON  PRIMARY 
( NAME = N'Shop', FILENAME = N'D:\Shop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Shop_log', FILENAME = N'D:\Shop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ECTSS] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ECTSS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ECTSS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ECTSS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ECTSS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ECTSS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ECTSS] SET ARITHABORT OFF 
GO
ALTER DATABASE [ECTSS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ECTSS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ECTSS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ECTSS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ECTSS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ECTSS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ECTSS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ECTSS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ECTSS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ECTSS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ECTSS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ECTSS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ECTSS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ECTSS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ECTSS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ECTSS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ECTSS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ECTSS] SET RECOVERY FULL 
GO
ALTER DATABASE [ECTSS] SET  MULTI_USER 
GO
ALTER DATABASE [ECTSS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ECTSS] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ECTSS', N'ON'
GO
USE [ECTSS]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [ECTSS]
GO
/****** Object:  Table [dbo].[AUser]    Script Date: 2017/6/15 23:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccNumber] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Nickname] [nvarchar](50) NULL,
	[Category] [int] NOT NULL,
	[Jurisdiction] [int] NOT NULL,
	[AccessRecord] [int] NOT NULL,
 CONSTRAINT [PK_AUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CategoryI]    Script Date: 2017/6/15 23:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CategoryI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CategoryII]    Script Date: 2017/6/15 23:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryII](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategorylID] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[Categoryl] [nchar](10) NOT NULL,
 CONSTRAINT [PK_CategoryII] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 2017/6/15 23:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](50) NOT NULL,
	[SoNumber] [nvarchar](50) NOT NULL,
	[SoNum] [int] NOT NULL,
	[CategoryI] [nvarchar](50) NOT NULL,
	[CategoryII] [nvarchar](50) NOT NULL,
	[SuNumber] [nvarchar](50) NOT NULL,
	[Total] [int] NOT NULL,
	[Payment] [int] NOT NULL,
	[DelGoods] [int] NOT NULL,
	[Time] [nvarchar](50) NOT NULL,
	[BuyerName] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[DelAddress] [nvarchar](50) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Shops]    Script Date: 2017/6/15 23:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shops](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PurPrice] [float] NOT NULL,
	[Price] [float] NOT NULL,
	[SalesVolumes] [int] NOT NULL,
	[CategoryI] [int] NOT NULL,
	[CategoryII] [int] NOT NULL,
	[Supplier] [int] NOT NULL,
	[KeyAttribute] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Shop] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 2017/6/15 23:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Keyword] [nvarchar](50) NOT NULL,
	[Postcode] [nvarchar](50) NOT NULL,
	[ContNumber] [nvarchar](50) NOT NULL,
	[Contacts] [nvarchar](50) NOT NULL,
	[CommodityI] [int] NOT NULL,
	[CommodityII] [int] NOT NULL,
	[BankAccount] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[AUser] ON 

INSERT [dbo].[AUser] ([ID], [AccNumber], [Password], [Name], [Nickname], [Category], [Jurisdiction], [AccessRecord]) VALUES (1, N'17052301', N'000000', N'陈建', N'admin', 3, 3, 0)
INSERT [dbo].[AUser] ([ID], [AccNumber], [Password], [Name], [Nickname], [Category], [Jurisdiction], [AccessRecord]) VALUES (2, N'17053002', N'000000', N'陈贺', N'ch', 2, 2, 0)
INSERT [dbo].[AUser] ([ID], [AccNumber], [Password], [Name], [Nickname], [Category], [Jurisdiction], [AccessRecord]) VALUES (3, N'17053003', N'000000', N'王磊', N'wl', 2, 2, 0)
INSERT [dbo].[AUser] ([ID], [AccNumber], [Password], [Name], [Nickname], [Category], [Jurisdiction], [AccessRecord]) VALUES (11, N'1706093', N'000000', N'姚奇', N'yq', 1, 1, 0)
INSERT [dbo].[AUser] ([ID], [AccNumber], [Password], [Name], [Nickname], [Category], [Jurisdiction], [AccessRecord]) VALUES (12, N'1706094', N'000000', N'王凯', N'wk', 1, 1, 0)
INSERT [dbo].[AUser] ([ID], [AccNumber], [Password], [Name], [Nickname], [Category], [Jurisdiction], [AccessRecord]) VALUES (13, N'1706095', N'000000', N'高波', N'gb', 1, 1, 0)
INSERT [dbo].[AUser] ([ID], [AccNumber], [Password], [Name], [Nickname], [Category], [Jurisdiction], [AccessRecord]) VALUES (15, N'1706117', N'000000', N'卢永康', NULL, 1, 1, 0)
INSERT [dbo].[AUser] ([ID], [AccNumber], [Password], [Name], [Nickname], [Category], [Jurisdiction], [AccessRecord]) VALUES (16, N'1706158', N'000000', N'王磊', NULL, 1, 1, 0)
INSERT [dbo].[AUser] ([ID], [AccNumber], [Password], [Name], [Nickname], [Category], [Jurisdiction], [AccessRecord]) VALUES (17, N'1706159', N'000000', N'王三石', NULL, 1, 1, 0)
SET IDENTITY_INSERT [dbo].[AUser] OFF
SET IDENTITY_INSERT [dbo].[CategoryI] ON 

INSERT [dbo].[CategoryI] ([ID], [Number], [Category]) VALUES (1, 1, N'家电')
INSERT [dbo].[CategoryI] ([ID], [Number], [Category]) VALUES (2, 2, N'数码')
INSERT [dbo].[CategoryI] ([ID], [Number], [Category]) VALUES (3, 3, N'手机')
INSERT [dbo].[CategoryI] ([ID], [Number], [Category]) VALUES (4, 4, N'运动')
INSERT [dbo].[CategoryI] ([ID], [Number], [Category]) VALUES (5, 5, N'户外')
SET IDENTITY_INSERT [dbo].[CategoryI] OFF
SET IDENTITY_INSERT [dbo].[CategoryII] ON 

INSERT [dbo].[CategoryII] ([ID], [CategorylID], [Number], [Categoryl]) VALUES (1, 1, 1, N'生活电器      ')
INSERT [dbo].[CategoryII] ([ID], [CategorylID], [Number], [Categoryl]) VALUES (2, 1, 2, N'厨房电器      ')
INSERT [dbo].[CategoryII] ([ID], [CategorylID], [Number], [Categoryl]) VALUES (4, 1, 3, N'吸尘器       ')
INSERT [dbo].[CategoryII] ([ID], [CategorylID], [Number], [Categoryl]) VALUES (5, 1, 4, N'空气进化器     ')
INSERT [dbo].[CategoryII] ([ID], [CategorylID], [Number], [Categoryl]) VALUES (6, 2, 1, N'电脑主机      ')
INSERT [dbo].[CategoryII] ([ID], [CategorylID], [Number], [Categoryl]) VALUES (7, 2, 2, N'数码相机      ')
INSERT [dbo].[CategoryII] ([ID], [CategorylID], [Number], [Categoryl]) VALUES (8, 2, 3, N'游戏主机      ')
INSERT [dbo].[CategoryII] ([ID], [CategorylID], [Number], [Categoryl]) VALUES (9, 2, 4, N'单反相机      ')
INSERT [dbo].[CategoryII] ([ID], [CategorylID], [Number], [Categoryl]) VALUES (10, 3, 1, N'小米        ')
INSERT [dbo].[CategoryII] ([ID], [CategorylID], [Number], [Categoryl]) VALUES (11, 2, 10, N'笔记本       ')
SET IDENTITY_INSERT [dbo].[CategoryII] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID], [Number], [SoNumber], [SoNum], [CategoryI], [CategoryII], [SuNumber], [Total], [Payment], [DelGoods], [Time], [BuyerName], [PhoneNumber], [DelAddress]) VALUES (12, N'1706094213', N'九阳电饭煲', 1, N'家电', N'厨房电器', N'杭州', 300, 0, 0, N'2017/6/9 21:44:10', N'张三', N'18333566532', N'常州')
INSERT [dbo].[Order] ([ID], [Number], [SoNumber], [SoNum], [CategoryI], [CategoryII], [SuNumber], [Total], [Payment], [DelGoods], [Time], [BuyerName], [PhoneNumber], [DelAddress]) VALUES (13, N'1706092112', N'Suface Book', 1, N'数码', N'笔记本', N'天津', 12000, 1, 1, N'2017/6/9 21:47:50', N'李四', N'13997867556', N'苏州')
INSERT [dbo].[Order] ([ID], [Number], [SoNumber], [SoNum], [CategoryI], [CategoryII], [SuNumber], [Total], [Payment], [DelGoods], [Time], [BuyerName], [PhoneNumber], [DelAddress]) VALUES (18, N'1706101211', N'小米净水器', 1, N'家电', N'生活电器', N'北京', 1200, 1, 1, N'2017/6/9 21:47:50', N'王五', N'13878996565', N'南京')
INSERT [dbo].[Order] ([ID], [Number], [SoNumber], [SoNum], [CategoryI], [CategoryII], [SuNumber], [Total], [Payment], [DelGoods], [Time], [BuyerName], [PhoneNumber], [DelAddress]) VALUES (20, N'1706101211', N'小米6', 1, N'数码', N'手机', N'北京', 3000, 0, 0, N'2017/6/10', N'孙膑', N'13165767688', N'常州')
INSERT [dbo].[Order] ([ID], [Number], [SoNumber], [SoNum], [CategoryI], [CategoryII], [SuNumber], [Total], [Payment], [DelGoods], [Time], [BuyerName], [PhoneNumber], [DelAddress]) VALUES (21, N'1707321522', N'iPhone6', 1, N'数码', N'手机', N'深圳', 6000, 1, 0, N'2017/5/29', N'周雨', N'18331698774', N'杭州')
INSERT [dbo].[Order] ([ID], [Number], [SoNumber], [SoNum], [CategoryI], [CategoryII], [SuNumber], [Total], [Payment], [DelGoods], [Time], [BuyerName], [PhoneNumber], [DelAddress]) VALUES (22, N'1707321522', N'ThinkPad', 1, N'数码', N'笔记本', N'北京', 4500, 1, 1, N'2017/5/29', N'周雨', N'18331698774', N'杭州')
INSERT [dbo].[Order] ([ID], [Number], [SoNumber], [SoNum], [CategoryI], [CategoryII], [SuNumber], [Total], [Payment], [DelGoods], [Time], [BuyerName], [PhoneNumber], [DelAddress]) VALUES (23, N'1707321522', N'B&O', 1, N'数码', N'音响', N'深圳', 18000, 1, 1, N'2017/5/29', N'周雨', N'18331698774', N'杭州')
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[Shops] ON 

INSERT [dbo].[Shops] ([ID], [Number], [Name], [PurPrice], [Price], [SalesVolumes], [CategoryI], [CategoryII], [Supplier], [KeyAttribute]) VALUES (2, N'2', N'小米净水器', 2000, 3000, 0, 3, 1, 2, N'手机/小米')
INSERT [dbo].[Shops] ([ID], [Number], [Name], [PurPrice], [Price], [SalesVolumes], [CategoryI], [CategoryII], [Supplier], [KeyAttribute]) VALUES (3, N'3', N'九阳榨汁机', 200, 350, 0, 1, 2, 1, N'')
INSERT [dbo].[Shops] ([ID], [Number], [Name], [PurPrice], [Price], [SalesVolumes], [CategoryI], [CategoryII], [Supplier], [KeyAttribute]) VALUES (5, N'4', N'九阳电饭煲', 200, 300, 0, 1, 2, 1, N'')
INSERT [dbo].[Shops] ([ID], [Number], [Name], [PurPrice], [Price], [SalesVolumes], [CategoryI], [CategoryII], [Supplier], [KeyAttribute]) VALUES (6, N'4', N'Surface Studio', 14000, 18000, 0, 2, 1, 3, N'')
SET IDENTITY_INSERT [dbo].[Shops] OFF
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([ID], [Number], [Name], [Address], [Keyword], [Postcode], [ContNumber], [Contacts], [CommodityI], [CommodityII], [BankAccount]) VALUES (1, 1, N'杭州九阳生活电器有限公司', N'杭州', N'九阳/电饭煲', N'320456', N'15367365388', N'杭州九阳生活电器有限公司', 1, 2, N'342563453453453234')
INSERT [dbo].[Supplier] ([ID], [Number], [Name], [Address], [Keyword], [Postcode], [ContNumber], [Contacts], [CommodityI], [CommodityII], [BankAccount]) VALUES (3, 2, N'北京小米科技有限责任公司', N'北京', N'小米/净水器/手机', N'345264', N'12452213332', N'雷军', 1, 1, N'2342342423423234234')
INSERT [dbo].[Supplier] ([ID], [Number], [Name], [Address], [Keyword], [Postcode], [ContNumber], [Contacts], [CommodityI], [CommodityII], [BankAccount]) VALUES (5, 3, N'Microsoft Corporation ', N'北京', N'微软/平板/Suface', N'432341', N'12323423454', N'Microsoft Corporation ', 2, 1, N'24234234234234234')
INSERT [dbo].[Supplier] ([ID], [Number], [Name], [Address], [Keyword], [Postcode], [ContNumber], [Contacts], [CommodityI], [CommodityII], [BankAccount]) VALUES (7, 5, N'联想集团', N'北京', N'XX/XX', N'34543', N'15635556788', N'朱云', 2, 10, N'536257536725675632')
SET IDENTITY_INSERT [dbo].[Supplier] OFF
USE [master]
GO
ALTER DATABASE [ECTSS] SET  READ_WRITE 
GO
