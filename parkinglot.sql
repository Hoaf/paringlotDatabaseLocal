USE [master]
GO
/****** Object:  Database [ParkingLotOnline]    Script Date: 3/24/2019 12:36:29 PM ******/
CREATE DATABASE [ParkingLotOnline]
GO
ALTER DATABASE [ParkingLotOnline] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ParkingLotOnline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ParkingLotOnline] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ParkingLotOnline] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ParkingLotOnline] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ParkingLotOnline] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ParkingLotOnline] SET ARITHABORT OFF 
GO
ALTER DATABASE [ParkingLotOnline] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ParkingLotOnline] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ParkingLotOnline] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ParkingLotOnline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ParkingLotOnline] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ParkingLotOnline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ParkingLotOnline] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ParkingLotOnline] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ParkingLotOnline] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ParkingLotOnline] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ParkingLotOnline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ParkingLotOnline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ParkingLotOnline] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ParkingLotOnline] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [ParkingLotOnline] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ParkingLotOnline] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ParkingLotOnline] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ParkingLotOnline] SET RECOVERY FULL 
GO
ALTER DATABASE [ParkingLotOnline] SET  MULTI_USER 
GO
ALTER DATABASE [ParkingLotOnline] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ParkingLotOnline] SET DB_CHAINING OFF 
GO
USE [ParkingLotOnline]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 3/24/2019 12:36:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[ID] [varchar](20) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PhoneNumber] [numeric](18, 0) NULL,
	[Address] [nvarchar](500) NOT NULL,
	[isEnable] [bit] NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookingLot]    Script Date: 3/24/2019 12:36:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookingLot](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DriverID] [varchar](20) NOT NULL,
	[EntryDateTime] [datetime] NOT NULL CONSTRAINT [DF__BookingLo__Entry__1273C1CD]  DEFAULT (getdate()),
	[ExitDateTime] [datetime] NULL,
 CONSTRAINT [PK__BookingL__3214EC27F158632A] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookingLotDetail]    Script Date: 3/24/2019 12:36:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookingLotDetail](
	[BLDId] [int] IDENTITY(1,1) NOT NULL,
	[HostID] [varchar](20) NOT NULL,
	[LotID] [varchar](10) NOT NULL,
	[BookingLotID] [int] NOT NULL,
	[UnitPrice] [float] NULL,
	[status] [int] NULL,
 CONSTRAINT [PK__BookingL__4BF040351447E100] PRIMARY KEY CLUSTERED 
(
	[BLDId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookingStatus]    Script Date: 3/24/2019 12:36:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookingStatus](
	[ID] [int] NOT NULL,
	[Name] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[City]    Script Date: 3/24/2019 12:36:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[City](
	[ID] [varchar](10) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[County]    Script Date: 3/24/2019 12:36:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[County](
	[ID] [varchar](10) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[CityID] [varchar](10) NOT NULL,
 CONSTRAINT [PK_County] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Driver]    Script Date: 3/24/2019 12:36:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Driver](
	[Username] [varchar](20) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[PhoneNumber] [int] NOT NULL,
	[isEnable] [bit] NULL,
 CONSTRAINT [PK_Driver] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Host]    Script Date: 3/24/2019 12:36:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Host](
	[ID] [varchar](20) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Fullname] [nvarchar](50) NULL,
	[Address] [nvarchar](150) NOT NULL,
	[CountyID] [varchar](10) NOT NULL,
	[isEnable] [bit] NOT NULL,
 CONSTRAINT [PK_Host] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Lot]    Script Date: 3/24/2019 12:36:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lot](
	[ID] [varchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[UnitPrice] [float] NOT NULL,
	[Image] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LotHost]    Script Date: 3/24/2019 12:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LotHost](
	[LoHID] [varchar](10) NOT NULL,
	[HostID] [varchar](20) NOT NULL,
	[LotID] [varchar](10) NULL,
	[Available] [bit] NOT NULL,
	[isEnable] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[LoHID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Admin] ([ID], [Password], [Name], [PhoneNumber], [Address], [isEnable]) VALUES (N'admin', N'123456', N'Văn hòa', CAST(2877797977 AS Numeric(18, 0)), N'no no', 1)
SET IDENTITY_INSERT [dbo].[BookingLot] ON 

INSERT [dbo].[BookingLot] ([ID], [DriverID], [EntryDateTime], [ExitDateTime]) VALUES (1, N'an', CAST(N'2000-01-12 00:00:00.000' AS DateTime), CAST(N'2019-03-11 20:26:59.497' AS DateTime))
INSERT [dbo].[BookingLot] ([ID], [DriverID], [EntryDateTime], [ExitDateTime]) VALUES (3, N'an', CAST(N'2019-03-11 14:34:12.870' AS DateTime), CAST(N'2019-03-11 20:27:33.113' AS DateTime))
INSERT [dbo].[BookingLot] ([ID], [DriverID], [EntryDateTime], [ExitDateTime]) VALUES (7, N'an', CAST(N'2018-09-09 00:00:00.000' AS DateTime), CAST(N'2019-03-11 20:37:39.630' AS DateTime))
INSERT [dbo].[BookingLot] ([ID], [DriverID], [EntryDateTime], [ExitDateTime]) VALUES (12, N'an', CAST(N'2019-03-11 19:02:21.453' AS DateTime), CAST(N'2019-03-11 20:26:33.717' AS DateTime))
INSERT [dbo].[BookingLot] ([ID], [DriverID], [EntryDateTime], [ExitDateTime]) VALUES (13, N'an', CAST(N'2019-03-11 20:39:43.657' AS DateTime), CAST(N'2019-03-11 20:40:31.167' AS DateTime))
INSERT [dbo].[BookingLot] ([ID], [DriverID], [EntryDateTime], [ExitDateTime]) VALUES (23, N'nhan', CAST(N'2019-03-22 17:17:30.737' AS DateTime), NULL)
INSERT [dbo].[BookingLot] ([ID], [DriverID], [EntryDateTime], [ExitDateTime]) VALUES (27, N'abcd', CAST(N'2019-03-23 00:28:25.553' AS DateTime), CAST(N'2019-03-23 00:28:33.183' AS DateTime))
INSERT [dbo].[BookingLot] ([ID], [DriverID], [EntryDateTime], [ExitDateTime]) VALUES (29, N'abcde', CAST(N'2019-03-23 00:35:51.653' AS DateTime), CAST(N'2019-03-23 00:36:13.443' AS DateTime))
INSERT [dbo].[BookingLot] ([ID], [DriverID], [EntryDateTime], [ExitDateTime]) VALUES (30, N'abc', CAST(N'2019-03-23 21:35:27.100' AS DateTime), CAST(N'2019-03-23 21:36:19.703' AS DateTime))
INSERT [dbo].[BookingLot] ([ID], [DriverID], [EntryDateTime], [ExitDateTime]) VALUES (31, N'abcd', CAST(N'2019-03-23 21:37:29.910' AS DateTime), NULL)
INSERT [dbo].[BookingLot] ([ID], [DriverID], [EntryDateTime], [ExitDateTime]) VALUES (32, N'abc', CAST(N'2019-03-23 21:56:38.290' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[BookingLot] OFF
SET IDENTITY_INSERT [dbo].[BookingLotDetail] ON 

INSERT [dbo].[BookingLotDetail] ([BLDId], [HostID], [LotID], [BookingLotID], [UnitPrice], [status]) VALUES (1, N'host', N'H01', 1, 500000, 3)
INSERT [dbo].[BookingLotDetail] ([BLDId], [HostID], [LotID], [BookingLotID], [UnitPrice], [status]) VALUES (2, N'host', N'H03', 7, 500000, 3)
INSERT [dbo].[BookingLotDetail] ([BLDId], [HostID], [LotID], [BookingLotID], [UnitPrice], [status]) VALUES (3, N'host1', N'H05', 3, 300000, 3)
INSERT [dbo].[BookingLotDetail] ([BLDId], [HostID], [LotID], [BookingLotID], [UnitPrice], [status]) VALUES (13, N'host', N'H11', 12, 2000, 3)
INSERT [dbo].[BookingLotDetail] ([BLDId], [HostID], [LotID], [BookingLotID], [UnitPrice], [status]) VALUES (14, N'host', N'H06', 13, 15000, 3)
INSERT [dbo].[BookingLotDetail] ([BLDId], [HostID], [LotID], [BookingLotID], [UnitPrice], [status]) VALUES (24, N'host', N'H11', 23, 2000, 1)
INSERT [dbo].[BookingLotDetail] ([BLDId], [HostID], [LotID], [BookingLotID], [UnitPrice], [status]) VALUES (28, N'host', N'H02', 27, 3000, 3)
INSERT [dbo].[BookingLotDetail] ([BLDId], [HostID], [LotID], [BookingLotID], [UnitPrice], [status]) VALUES (30, N'host', N'H12', 29, 2000, 3)
INSERT [dbo].[BookingLotDetail] ([BLDId], [HostID], [LotID], [BookingLotID], [UnitPrice], [status]) VALUES (31, N'host', N'H10', 30, 2000, 3)
INSERT [dbo].[BookingLotDetail] ([BLDId], [HostID], [LotID], [BookingLotID], [UnitPrice], [status]) VALUES (32, N'host', N'H08', 31, 0, 2)
INSERT [dbo].[BookingLotDetail] ([BLDId], [HostID], [LotID], [BookingLotID], [UnitPrice], [status]) VALUES (33, N'host', N'A1', 32, 0, 1)
SET IDENTITY_INSERT [dbo].[BookingLotDetail] OFF
INSERT [dbo].[BookingStatus] ([ID], [Name]) VALUES (1, N'Booking')
INSERT [dbo].[BookingStatus] ([ID], [Name]) VALUES (2, N'Cancel')
INSERT [dbo].[BookingStatus] ([ID], [Name]) VALUES (3, N'Paid')
INSERT [dbo].[City] ([ID], [Name]) VALUES (N'DN', N'Đà Nẵng')
INSERT [dbo].[City] ([ID], [Name]) VALUES (N'HCM', N'TP.Ho Chi Minh')
INSERT [dbo].[City] ([ID], [Name]) VALUES (N'HN', N'Hà Nội')
INSERT [dbo].[County] ([ID], [Name], [CityID]) VALUES (N'Q1', N'Quận 1', N'HCM')
INSERT [dbo].[County] ([ID], [Name], [CityID]) VALUES (N'Q12', N'Quận 12', N'HCM')
INSERT [dbo].[County] ([ID], [Name], [CityID]) VALUES (N'QBD', N'Quận Ba Đình', N'HN')
INSERT [dbo].[County] ([ID], [Name], [CityID]) VALUES (N'QHC', N'Quận Hải Châu', N'DN')
INSERT [dbo].[County] ([ID], [Name], [CityID]) VALUES (N'QHK', N'Quận Hoàng Kiếm', N'HN')
INSERT [dbo].[County] ([ID], [Name], [CityID]) VALUES (N'QTK', N'Quận Thanh Khê', N'DN')
INSERT [dbo].[Driver] ([Username], [Password], [Fullname], [PhoneNumber], [isEnable]) VALUES (N'1', N'123', N'hoa1', 1231, 0)
INSERT [dbo].[Driver] ([Username], [Password], [Fullname], [PhoneNumber], [isEnable]) VALUES (N'13', N'123', N'nhan3', 114, 1)
INSERT [dbo].[Driver] ([Username], [Password], [Fullname], [PhoneNumber], [isEnable]) VALUES (N'2', N'123', N'Hoa223', 1123, 1)
INSERT [dbo].[Driver] ([Username], [Password], [Fullname], [PhoneNumber], [isEnable]) VALUES (N'3', N'123', N'nhan2', 113, 0)
INSERT [dbo].[Driver] ([Username], [Password], [Fullname], [PhoneNumber], [isEnable]) VALUES (N'4', N'123', N'as', 22, 1)
INSERT [dbo].[Driver] ([Username], [Password], [Fullname], [PhoneNumber], [isEnable]) VALUES (N'5', N'123', N'nhan678', 115, 1)
INSERT [dbo].[Driver] ([Username], [Password], [Fullname], [PhoneNumber], [isEnable]) VALUES (N'abc', N'123', N'Nguyễn Văn Hòa', 120500, 1)
INSERT [dbo].[Driver] ([Username], [Password], [Fullname], [PhoneNumber], [isEnable]) VALUES (N'abcd', N'abcd', N'abcd', 123, 0)
INSERT [dbo].[Driver] ([Username], [Password], [Fullname], [PhoneNumber], [isEnable]) VALUES (N'abcde', N'123', N'abcd', 123, 1)
INSERT [dbo].[Driver] ([Username], [Password], [Fullname], [PhoneNumber], [isEnable]) VALUES (N'an', N'123456', N'Nguyễn Thúy An', 1234, 1)
INSERT [dbo].[Driver] ([Username], [Password], [Fullname], [PhoneNumber], [isEnable]) VALUES (N'nhan', N'123456', N'thanh nhàn', 9112348, 1)
INSERT [dbo].[Host] ([ID], [Password], [Fullname], [Address], [CountyID], [isEnable]) VALUES (N'host', N'123456', N'Nguyễn Thanh Nhàn', N'309 Lê Văn Khương', N'Q12', 1)
INSERT [dbo].[Host] ([ID], [Password], [Fullname], [Address], [CountyID], [isEnable]) VALUES (N'host1', N'123', N'Nguyễn Văn Hòa', N'Hòa Binh', N'Q1', 1)
INSERT [dbo].[Host] ([ID], [Password], [Fullname], [Address], [CountyID], [isEnable]) VALUES (N'host2', N'123', N'Nguyễn Văn Lương', N'123 Đong Bắc', N'Q12', 1)
INSERT [dbo].[Host] ([ID], [Password], [Fullname], [Address], [CountyID], [isEnable]) VALUES (N'host3', N'123', N'Nguyen Nghia Mai Linh', N'156/4D TX21', N'QHC', 0)
INSERT [dbo].[Lot] ([ID], [Name], [Description], [UnitPrice], [Image]) VALUES (N'L0', N'Bycicle', NULL, 2000, N'/assets/img/type/bycicle.png')
INSERT [dbo].[Lot] ([ID], [Name], [Description], [UnitPrice], [Image]) VALUES (N'L1', N'Motorbike', NULL, 3000, N'/assets/img/type/motor.png')
INSERT [dbo].[Lot] ([ID], [Name], [Description], [UnitPrice], [Image]) VALUES (N'L2', N'5 Seats', NULL, 10000, N'/assets/img/type/5.png')
INSERT [dbo].[Lot] ([ID], [Name], [Description], [UnitPrice], [Image]) VALUES (N'L3', N'7 Seats', NULL, 15000, N'/assets/img/type/7.png')
INSERT [dbo].[Lot] ([ID], [Name], [Description], [UnitPrice], [Image]) VALUES (N'L4', N'Pick up', NULL, 15000, N'/assets/img/type/PU.png')
INSERT [dbo].[Lot] ([ID], [Name], [Description], [UnitPrice], [Image]) VALUES (N'L5', N'45 Seats', NULL, 30000, N'/assets/img/type/45.png')
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'A1', N'host', N'L5', 0, 1)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'F13', N'host', N'L1', 1, 1)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'H01', N'host', N'L1', 1, 1)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'H02', N'host', N'L1', 1, 1)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'H03', N'host', N'L2', 1, 1)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'H04', N'host', N'L2', 1, 1)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'H05', N'host', N'L3', 1, 1)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'H06', N'host', N'L4', 1, 1)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'H07', N'host', N'L5', 1, 1)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'H08', N'host', N'L4', 1, 1)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'H09', N'host', N'L5', 1, 1)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'H10', N'host', N'L0', 1, 1)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'H11', N'host', N'L0', 0, 1)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'H112', N'host', N'L0', 1, 0)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'H113', N'host', N'L3', 1, 0)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'H12', N'host', N'L0', 1, 1)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'H14', N'host', N'L1', 1, 0)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'H33', N'host', N'L3', 1, 0)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'HOST18', N'host', N'L0', 1, 0)
INSERT [dbo].[LotHost] ([LoHID], [HostID], [LotID], [Available], [isEnable]) VALUES (N'HOST19', N'host', N'L0', 1, 0)
ALTER TABLE [dbo].[BookingLot]  WITH CHECK ADD  CONSTRAINT [FK_BookingLot_Driver] FOREIGN KEY([DriverID])
REFERENCES [dbo].[Driver] ([Username])
GO
ALTER TABLE [dbo].[BookingLot] CHECK CONSTRAINT [FK_BookingLot_Driver]
GO
ALTER TABLE [dbo].[BookingLotDetail]  WITH CHECK ADD  CONSTRAINT [FK_BookingLotDetail_BookingLot] FOREIGN KEY([BookingLotID])
REFERENCES [dbo].[BookingLot] ([ID])
GO
ALTER TABLE [dbo].[BookingLotDetail] CHECK CONSTRAINT [FK_BookingLotDetail_BookingLot]
GO
ALTER TABLE [dbo].[BookingLotDetail]  WITH CHECK ADD  CONSTRAINT [FK_BookingLotDetail_Host] FOREIGN KEY([HostID])
REFERENCES [dbo].[Host] ([ID])
GO
ALTER TABLE [dbo].[BookingLotDetail] CHECK CONSTRAINT [FK_BookingLotDetail_Host]
GO
ALTER TABLE [dbo].[BookingLotDetail]  WITH CHECK ADD  CONSTRAINT [FK_BookingLotDetail_LotHost] FOREIGN KEY([LotID])
REFERENCES [dbo].[LotHost] ([LoHID])
GO
ALTER TABLE [dbo].[BookingLotDetail] CHECK CONSTRAINT [FK_BookingLotDetail_LotHost]
GO
ALTER TABLE [dbo].[County]  WITH CHECK ADD  CONSTRAINT [FK_County_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[City] ([ID])
GO
ALTER TABLE [dbo].[County] CHECK CONSTRAINT [FK_County_City]
GO
ALTER TABLE [dbo].[Host]  WITH CHECK ADD  CONSTRAINT [FK_Host_County] FOREIGN KEY([CountyID])
REFERENCES [dbo].[County] ([ID])
GO
ALTER TABLE [dbo].[Host] CHECK CONSTRAINT [FK_Host_County]
GO
ALTER TABLE [dbo].[LotHost]  WITH CHECK ADD  CONSTRAINT [FK_LotHost_Host1] FOREIGN KEY([HostID])
REFERENCES [dbo].[Host] ([ID])
GO
ALTER TABLE [dbo].[LotHost] CHECK CONSTRAINT [FK_LotHost_Host1]
GO
ALTER TABLE [dbo].[LotHost]  WITH CHECK ADD  CONSTRAINT [FK_LotHost_Lot] FOREIGN KEY([LotID])
REFERENCES [dbo].[Lot] ([ID])
GO
ALTER TABLE [dbo].[LotHost] CHECK CONSTRAINT [FK_LotHost_Lot]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Admin_Host_AcceptRequest]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_Admin_Host_AcceptRequest] 
	@LoHID varchar(10)
as
begin
	Update LotHost set isEnable = 'true' where LoHID = @LoHID
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_Admin_Host_CancelRequest]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Sp_Admin_Host_CancelRequest] 
	@LoHID varchar(10)
as
begin
	Delete LotHost where LoHID = @LoHID and isEnable = 'false'
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_Admin_Host_CountNotific]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_Admin_Host_CountNotific] 

as
begin
	select count(lh.isEnable) as Notific from LotHost lh where lh.isEnable = 'false'
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_Admin_Host_Detail]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_Admin_Host_Detail] 
	@HostID varchar(20)
as
begin
	select h.ID,h.Password,h.Fullname,h.Address,ct.Name as CountyName,c.Name as CityName,h.isEnable from Host h inner join County ct on h.CountyID = ct.ID
inner join City c on ct.CityID = c.ID where h.ID = @HostID
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_Admin_Host_Enable]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_Admin_Host_Enable] 
	@HostID varchar(20)
as
begin
	Update Host set isEnable='True' Where ID=@HostID
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_Admin_Host_Register]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_Admin_Host_Register] 
	@HostID varchar(20),
	@FullName nvarchar(50),
	@Address nvarchar(150),
	@Password varchar(50),
	@CountyID varchar(10)
as
begin
	Insert into Host(ID,Fullname,Address,Password,CountyID,isEnable) values(@HostID,@FullName,@Address,@Password,@CountyID,'True')
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_Admin_Host_Request]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_Admin_Host_Request] 

as
begin
	select h.ID,h.Fullname,lh.LoHID,l.Name,l.UnitPrice 
	from Host h inner join LotHost lh on h.ID = lh.HostID inner join Lot l on lh.LotID = l.ID 
	where lh.isEnable = 'false'
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_Admin_Host_UnEnable]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_Admin_Host_UnEnable] 
	@HostID varchar(20)
as
begin
	Update Host set isEnable='False' Where ID=@HostID
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_Admin_Host_Update]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_Admin_Host_Update] 
	@FullName nvarchar(50),
	@Address nvarchar(150),
	@Password varchar(50),
	@CountyID varchar(10),
	@HostID varchar(20)
as
begin
	Update Host set Fullname=@FullName,Address=@Address,Password=@Password,CountyID=@CountyID Where ID=@HostID
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_Admin_ListHost]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_Admin_ListHost] 
as
begin

	select h.ID,h.Fullname,h.Address,ct.Name as CountyName, c.Name as CityName,h.isEnable
	from Host h inner join County ct on h.CountyID = ct.ID 
			inner join City c on ct.CityID = c.ID
	
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_Admin_ListLotHot]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Sp_Admin_ListLotHot] 
	@HostID varchar(20)
as
begin

	select  lh.LoHID,lh.Available,l.Name,l.UnitPrice
	from LotHost lh inner join Lot l on lh.LotID = l.ID 
	where lh.HostID = @HostID and lh.isEnable = 'true'
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_Admin_Login]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_Admin_Login] 
	@UserName varchar(20),
	@Password varchar(50)
as
begin

	select Name from Admin where ID = @UserName and Password =@Password
end

GO
/****** Object:  StoredProcedure [dbo].[Sp_Admin_LotHot_UpdateLoHID]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Sp_Admin_LotHot_UpdateLoHID] 
	@LotID varchar(10),
	@LoHID varchar(10)
as
begin
	Update LotHost set LotID = @LotID where LoHID = @LoHID
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_BookingDetail_Cancel]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Sp_BookingDetail_Cancel] 
	@BookingID int,
	@LoHID varchar(10),
	@HostID varchar(20)
as
begin
	update BookingLotDetail set Status=2 where BookingLotID = @BookingID and LotID = @LoHID  and HostID = @HostID
end

GO
/****** Object:  StoredProcedure [dbo].[Sp_BookingLot_ByYearAndMonth]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Sp_BookingLot_ByYearAndMonth]
	@Month int, 
	@Year int,
	@HostID varchar(20)

as
begin
	select   bl.ID, bl.DriverID,bl.EntryDateTime,bl.ExitDateTime from BookingLot bl 
	inner join BookingLotDetail bld on bl.ID = bld.BookingLotID
	where MONTH(EntryDateTime) = @Month and YEAR(EntryDateTime) = @Year and bld.Status='3' and bld.HostID = @HostID
end

GO
/****** Object:  StoredProcedure [dbo].[Sp_BookingLot_Current]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_BookingLot_Current] 
	@HostID varchar(20)
as
begin
	select distinct bl.ID, bl.DriverID,bl.EntryDateTime,bl.ExitDateTime from BookingLot bl inner join BookingLotDetail bld on bl.ID = bld.BookingLotID
where MONTH(EntryDateTime) = MONTH(getDate()) and YEAR(EntryDateTime) = YEAR(GETDATE()) and bld.Status='3' and bld.HostID = @HostID
end


GO
/****** Object:  StoredProcedure [dbo].[Sp_BookingLot_InfoEachLot]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_BookingLot_InfoEachLot]
	@Month int, 
	@Year int, 
	@HostID varchar(20),
	@BookingID int
as
begin
	select bld.LotID,bld.UnitPrice, l.Name
	from BookingLot bl 
	inner join BookingLotDetail bld on bl.ID = bld.BookingLotID
	inner join LotHost lh on bld.LotID = lh.LoHID
	inner join Lot l on lh.LotID =l.ID
	where MONTH(EntryDateTime) = @Month 
	and YEAR(EntryDateTime) = @Year and bld.Status = '3' and bld.HostID = @HostID and bld.BookingLotID = @BookingID
end

GO
/****** Object:  StoredProcedure [dbo].[Sp_BookingLot_SumPrice]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_BookingLot_SumPrice] 
	@Month int, 
	@Year int, 
	@HostID varchar(20),
	@BookingID int
as
begin
	select sum(bld.UnitPrice) as total
from BookingLot bl 
inner join BookingLotDetail bld on bl.ID = bld.BookingLotID
where MONTH(EntryDateTime) = @Month 
and YEAR(EntryDateTime) = @Year and bld.Status = '3' and bld.HostID = @HostID and bld.BookingLotID = @BookingID
end


GO
/****** Object:  StoredProcedure [dbo].[Sp_Count_Parkinglot_unavailable]    Script Date: 3/24/2019 12:36:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_Count_Parkinglot_unavailable] 
	@ID varchar(20)
as
begin
	select count(HostID) as Number  from LotHost where  HostID = @ID and Available='false'
end


GO
/****** Object:  StoredProcedure [dbo].[Sp_Driver_Login]    Script Date: 3/24/2019 12:36:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create procedure [dbo].[Sp_Driver_Login] 
	@UserName varchar(20),
	@Password varchar(50)
as
begin
	select Fullname from Driver where Username = @UserName and Password =@Password and isEnable='true'
end

GO
/****** Object:  StoredProcedure [dbo].[Sp_DriverBooked_History]    Script Date: 3/24/2019 12:36:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_DriverBooked_History]
	@driverID varchar(20)
AS
BEGIN
    select bld.BLDId,dr.Username,bl.EntryDateTime,bl.ExitDateTime,bld.HostID
	,bs.Name as statusName,lh.LoHID,l.UnitPrice,l.Image as LotImage,bl.ID as BLid,
	bld.UnitPrice as TotalPrice
	from Driver dr,BookingLot bl,BookingLotDetail bld,BookingStatus bs,LotHost lh,Lot l 
	where dr.Username = bl.DriverID
	and dr.Username=@driverID and bld.BookingLotID = bl.ID and bld.status = bs.ID 
	and bld.LotID = lh.LoHID 
	and lh.LotID = l.ID
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_Host_ListLot]    Script Date: 3/24/2019 12:36:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_Host_ListLot] 
	@ID varchar(20)
as
begin
	select lh.LoHID,l.Name,l.UnitPrice,l.Image from Host h inner join LotHost lh on ID=HostID inner join Lot l on LotID=l.ID where h.ID = @ID
end


GO
/****** Object:  StoredProcedure [dbo].[Sp_Host_Login]    Script Date: 3/24/2019 12:36:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_Host_Login] 
	@ID varchar(20),
	@Password varchar(50)
as
begin
	select Fullname from Host where ID = @ID and Password =@Password
end


GO
/****** Object:  StoredProcedure [dbo].[Sp_Income_ByYearAndMonth]    Script Date: 3/24/2019 12:36:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[Sp_Income_ByYearAndMonth]
	@Month int, 
	@Year int,
	@HostID varchar(20)

as
begin
	select   SUM(bld.UnitPrice) as Income from BookingLot bl 
	inner join BookingLotDetail bld on bl.ID = bld.BookingLotID
	where MONTH(EntryDateTime) = @Month and YEAR(EntryDateTime) = @Year and bld.Status='3' and bld.HostID = @HostID
end

GO
/****** Object:  StoredProcedure [dbo].[Sp_Infomation_Detail]    Script Date: 3/24/2019 12:36:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_Infomation_Detail](@LoHID varchar(10))
	
as
begin
	select d.Username,d.PhoneNumber,bl.ID,bl.EntryDateTime,l.Image,l.UnitPrice,l.Name
	from Driver d inner join BookingLot bl on d.Username=bl.DriverID
				  inner join BookingLotDetail bld on bl.ID=bld.BookingLotID
				  inner join LotHost lh on bld.LotID=lh.LoHID
				  inner join Lot l on lh.LotID=l.ID
				  where bld.LotID = @LoHID and bld.Status = '1'
end

GO
/****** Object:  StoredProcedure [dbo].[Sp_Lot_All]    Script Date: 3/24/2019 12:36:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_Lot_All] 
as
begin
	select ID,Name,UnitPrice,Image from Lot 
end


GO
/****** Object:  StoredProcedure [dbo].[Sp_Lot_ByLoHID]    Script Date: 3/24/2019 12:36:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_Lot_ByLoHID] 
	@LoHID varchar(10)
as
begin
	select l.ID,l.Description,l.Name,l.UnitPrice,l.Image from LotHost lh  inner join Lot l on LotID=l.ID where lh.LoHID = @LoHID
end


GO
/****** Object:  StoredProcedure [dbo].[Sp_LotHost_Available]    Script Date: 3/24/2019 12:36:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Sp_LotHost_Available] 
	@LoHID varchar(10)
as
begin
	update LotHost set Available='true' where LoHID = @LoHID 
end


GO
/****** Object:  StoredProcedure [dbo].[Sp_LotHost_Insert]    Script Date: 3/24/2019 12:36:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_LotHost_Insert] 
	@LoHID varchar(10),
	@HostID varchar(20),
	@LotID varchar(10)
as
begin
	insert into LotHost(LoHID,HostID,LotID,Available,isEnable) values (@LoHID,@HostID,@LotID,'True','False')
end


GO
/****** Object:  StoredProcedure [dbo].[Sp_LotHost_Lot]    Script Date: 3/24/2019 12:36:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_LotHost_Lot] 
	@HostID varchar(20)
as
begin
	select lh.LoHID,l.ID,lh.Available,l.Name,l.UnitPrice,l.Image from LotHost lh  inner join Lot l on LotID=l.ID where lh.HostID = @HostID and lh.isEnable ='True'
end



GO
/****** Object:  StoredProcedure [dbo].[Sp_LotHost_Lot_Driver]    Script Date: 3/24/2019 12:36:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_LotHost_Lot_Driver]
	@hostId varchar(20),
	@lotId varchar(10)
	AS
BEGIN
select lh.LoHID,lh.Available,l.Name,l.UnitPrice,l.Image 
from LotHost lh  inner join Lot l on LotID=l.ID 
where lh.HostID = @hostId and lh.isEnable ='True'
and lh.LotID = @lotId and lh.Available = 'true'
END


GO
/****** Object:  StoredProcedure [dbo].[Sp_LotHost_Lot_Driver_All]    Script Date: 3/24/2019 12:36:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_LotHost_Lot_Driver_All]
	@HostID varchar(20)
AS
BEGIN
	select lh.LoHID,lh.Available,l.Name,l.UnitPrice,l.Image 
from LotHost lh  inner join Lot l on LotID=l.ID 
where lh.HostID = @HostID and lh.isEnable ='True' and lh.Available='true'
END



GO
/****** Object:  StoredProcedure [dbo].[Sp_LotHot_Count]    Script Date: 3/24/2019 12:36:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_LotHot_Count] 
	@HostID varchar(20)
as
begin
	select COUNT(LoHID) as count from LotHost where HostID = @HostID
end

GO
USE [master]
GO
ALTER DATABASE [ParkingLotOnline] SET  READ_WRITE 
GO
