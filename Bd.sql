USE [master]
GO
/****** Object:  Database [BlueDB]    Script Date: 27/12/2022 08:15:22 ******/
CREATE DATABASE [BlueDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BlueDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BlueDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BlueDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BlueDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BlueDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BlueDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BlueDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlueDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlueDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlueDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlueDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlueDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BlueDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlueDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlueDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlueDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BlueDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlueDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlueDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlueDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlueDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BlueDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlueDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BlueDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BlueDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BlueDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlueDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BlueDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BlueDB] SET RECOVERY FULL 
GO
ALTER DATABASE [BlueDB] SET  MULTI_USER 
GO
ALTER DATABASE [BlueDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BlueDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BlueDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BlueDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BlueDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BlueDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BlueDB', N'ON'
GO
ALTER DATABASE [BlueDB] SET QUERY_STORE = OFF
GO
USE [BlueDB]
GO
/****** Object:  Table [dbo].[Agenda]    Script Date: 27/12/2022 08:15:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agenda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](256) NULL,
	[Email] [nvarchar](128) NULL,
	[Telefone] [nvarchar](17) NULL,
 CONSTRAINT [PK_Agenda] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [BlueDB] SET  READ_WRITE 
GO
