USE [master]
GO
/****** Object:  Database [Online_photo]    Script Date: 11-Sep-18 12:26:16 AM ******/
CREATE DATABASE [Online_photo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Online_photo', FILENAME = N'D:\Online_photo.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Online_photo_log', FILENAME = N'D:\Online_photo_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Online_photo] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Online_photo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Online_photo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Online_photo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Online_photo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Online_photo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Online_photo] SET ARITHABORT OFF 
GO
ALTER DATABASE [Online_photo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Online_photo] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Online_photo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Online_photo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Online_photo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Online_photo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Online_photo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Online_photo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Online_photo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Online_photo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Online_photo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Online_photo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Online_photo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Online_photo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Online_photo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Online_photo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Online_photo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Online_photo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Online_photo] SET RECOVERY FULL 
GO
ALTER DATABASE [Online_photo] SET  MULTI_USER 
GO
ALTER DATABASE [Online_photo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Online_photo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Online_photo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Online_photo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Online_photo', N'ON'
GO
USE [Online_photo]
GO
/****** Object:  Table [dbo].[ContactUs]    Script Date: 11-Sep-18 12:26:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactUs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Message] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customers]    Script Date: 11-Sep-18 12:26:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[custid] [int] IDENTITY(1,1) NOT NULL,
	[Fname] [nvarchar](50) NULL,
	[Lname] [nvarchar](50) NULL,
	[DOB] [date] NULL,
	[Gender] [nchar](10) NULL,
	[Phone] [numeric](18, 0) NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[custid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Images]    Script Date: 11-Sep-18 12:26:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Pr_size] [nchar](10) NULL,
	[Pr_price] [numeric](18, 0) NULL,
	[Quantity] [numeric](18, 0) NULL,
	[T_price] [numeric](18, 0) NULL,
	[Email] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11-Sep-18 12:26:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[Email_id] [nvarchar](50) NULL,
	[No_print] [int] NULL,
	[credit_cardNo] [numeric](18, 0) NULL,
	[Total_Payment] [int] NULL,
	[Delievery_status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 11-Sep-18 12:26:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Size] [nvarchar](50) NULL,
	[Prize] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [Online_photo] SET  READ_WRITE 
GO
