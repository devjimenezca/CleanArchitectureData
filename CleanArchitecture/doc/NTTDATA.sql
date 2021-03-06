USE [master]
GO
/****** Object:  Database [NTTDATA]    Script Date: 2022-07-10 16:53:31 ******/
CREATE DATABASE [NTTDATA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NTTDATA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\NTTDATA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NTTDATA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\NTTDATA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [NTTDATA] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NTTDATA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NTTDATA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NTTDATA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NTTDATA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NTTDATA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NTTDATA] SET ARITHABORT OFF 
GO
ALTER DATABASE [NTTDATA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NTTDATA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NTTDATA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NTTDATA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NTTDATA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NTTDATA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NTTDATA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NTTDATA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NTTDATA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NTTDATA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NTTDATA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NTTDATA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NTTDATA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NTTDATA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NTTDATA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NTTDATA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NTTDATA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NTTDATA] SET RECOVERY FULL 
GO
ALTER DATABASE [NTTDATA] SET  MULTI_USER 
GO
ALTER DATABASE [NTTDATA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NTTDATA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NTTDATA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NTTDATA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NTTDATA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NTTDATA] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'NTTDATA', N'ON'
GO
ALTER DATABASE [NTTDATA] SET QUERY_STORE = OFF
GO
USE [NTTDATA]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2022-07-10 16:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 2022-07-10 16:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Contrasenia] [nvarchar](max) NOT NULL,
	[Estado] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Genero] [nvarchar](max) NOT NULL,
	[Edad] [int] NOT NULL,
	[Identificacion] [nvarchar](max) NOT NULL,
	[Direccion] [nvarchar](max) NULL,
	[Telefono] [nvarchar](max) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 2022-07-10 16:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[CuentaId] [int] IDENTITY(1,1) NOT NULL,
	[NumeroCuenta] [nvarchar](15) NOT NULL,
	[SaldoInicial] [decimal](18, 2) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[TipoCuentaId] [int] NOT NULL,
	[Estado] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[CuentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimiento]    Script Date: 2022-07-10 16:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimiento](
	[MovimientoId] [int] IDENTITY(1,1) NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[Saldo] [decimal](18, 2) NOT NULL,
	[SaldoInicial] [decimal](18, 2) NOT NULL,
	[CuentaId] [int] NOT NULL,
	[TipoMovimientoId] [int] NOT NULL,
	[Estado] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Movimiento] PRIMARY KEY CLUSTERED 
(
	[MovimientoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCuenta]    Script Date: 2022-07-10 16:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCuenta](
	[TipoCuentaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Estado] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_TipoCuenta] PRIMARY KEY CLUSTERED 
(
	[TipoCuentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoMovimiento]    Script Date: 2022-07-10 16:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoMovimiento](
	[TipoMovimientoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Estado] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_TipoMovimiento] PRIMARY KEY CLUSTERED 
(
	[TipoMovimientoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220710204427_MigrationInicial', N'6.0.1')
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([ClienteId], [Contrasenia], [Estado], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (1, N'12446', 1, CAST(N'2022-07-10T15:45:55.5177252' AS DateTime2), N'system', NULL, NULL, N'Marianela Montalvo ', N'F', 31, N'01234567891', N'Amazonas y  NNUU ', N'097548965')
INSERT [dbo].[Cliente] ([ClienteId], [Contrasenia], [Estado], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (2, N'12456', 1, CAST(N'2022-07-10T15:46:58.0289452' AS DateTime2), N'system', NULL, NULL, N'Jose Lema ', N'F', 31, N'01234567892', N'Otavalo sn y principal  ', N'098254785 ')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Cuenta] ON 

INSERT [dbo].[Cuenta] ([CuentaId], [NumeroCuenta], [SaldoInicial], [ClienteId], [TipoCuentaId], [Estado], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (2, N'716985552', CAST(0.00 AS Decimal(18, 2)), 2, 1, 1, CAST(N'2022-07-10T15:50:05.7396060' AS DateTime2), N'system', CAST(N'2022-07-10T16:35:29.1086032' AS DateTime2), N'system')
INSERT [dbo].[Cuenta] ([CuentaId], [NumeroCuenta], [SaldoInicial], [ClienteId], [TipoCuentaId], [Estado], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (3, N'716985552', CAST(0.00 AS Decimal(18, 2)), 2, 1, 2, CAST(N'2022-07-10T15:53:01.9708844' AS DateTime2), N'system', CAST(N'2022-07-10T16:35:45.7810317' AS DateTime2), N'system')
SET IDENTITY_INSERT [dbo].[Cuenta] OFF
GO
SET IDENTITY_INSERT [dbo].[Movimiento] ON 

INSERT [dbo].[Movimiento] ([MovimientoId], [Valor], [Saldo], [SaldoInicial], [CuentaId], [TipoMovimientoId], [Estado], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (3, CAST(10.00 AS Decimal(18, 2)), CAST(610.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, 1, 0, CAST(N'2022-07-10T16:08:15.2661105' AS DateTime2), N'system', NULL, NULL)
INSERT [dbo].[Movimiento] ([MovimientoId], [Valor], [Saldo], [SaldoInicial], [CuentaId], [TipoMovimientoId], [Estado], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (4, CAST(7.00 AS Decimal(18, 2)), CAST(617.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, 1, 0, CAST(N'2022-07-10T16:14:29.6985316' AS DateTime2), N'system', NULL, NULL)
INSERT [dbo].[Movimiento] ([MovimientoId], [Valor], [Saldo], [SaldoInicial], [CuentaId], [TipoMovimientoId], [Estado], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (5, CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, 1, 0, CAST(N'2022-07-10T16:17:14.1279518' AS DateTime2), N'system', NULL, NULL)
INSERT [dbo].[Movimiento] ([MovimientoId], [Valor], [Saldo], [SaldoInicial], [CuentaId], [TipoMovimientoId], [Estado], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (6, CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, 1, 0, CAST(N'2022-07-10T16:18:43.0202827' AS DateTime2), N'system', NULL, NULL)
INSERT [dbo].[Movimiento] ([MovimientoId], [Valor], [Saldo], [SaldoInicial], [CuentaId], [TipoMovimientoId], [Estado], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (7, CAST(5.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), 2, 1, 0, CAST(N'2022-07-10T16:18:44.4845125' AS DateTime2), N'system', NULL, NULL)
INSERT [dbo].[Movimiento] ([MovimientoId], [Valor], [Saldo], [SaldoInicial], [CuentaId], [TipoMovimientoId], [Estado], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (8, CAST(7.00 AS Decimal(18, 2)), CAST(17.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), 2, 1, 0, CAST(N'2022-07-10T16:19:13.8862668' AS DateTime2), N'system', NULL, NULL)
INSERT [dbo].[Movimiento] ([MovimientoId], [Valor], [Saldo], [SaldoInicial], [CuentaId], [TipoMovimientoId], [Estado], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (9, CAST(7.00 AS Decimal(18, 2)), CAST(24.00 AS Decimal(18, 2)), CAST(17.00 AS Decimal(18, 2)), 2, 1, 0, CAST(N'2022-07-10T16:19:18.9009911' AS DateTime2), N'system', NULL, NULL)
INSERT [dbo].[Movimiento] ([MovimientoId], [Valor], [Saldo], [SaldoInicial], [CuentaId], [TipoMovimientoId], [Estado], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (10, CAST(7.00 AS Decimal(18, 2)), CAST(17.00 AS Decimal(18, 2)), CAST(24.00 AS Decimal(18, 2)), 2, 2, 0, CAST(N'2022-07-10T16:21:40.9237080' AS DateTime2), N'system', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Movimiento] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoCuenta] ON 

INSERT [dbo].[TipoCuenta] ([TipoCuentaId], [Nombre], [Estado], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (1, N'Ahorro', 1, CAST(N'2022-07-10T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-07-10T00:00:00.0000000' AS DateTime2), N'System')
INSERT [dbo].[TipoCuenta] ([TipoCuentaId], [Nombre], [Estado], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (2, N'Corriente', 1, CAST(N'2022-07-10T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-07-10T00:00:00.0000000' AS DateTime2), N'System')
SET IDENTITY_INSERT [dbo].[TipoCuenta] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoMovimiento] ON 

INSERT [dbo].[TipoMovimiento] ([TipoMovimientoId], [Nombre], [Estado], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (1, N'Deposito', 1, CAST(N'2022-07-10T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-07-10T00:00:00.0000000' AS DateTime2), N'System')
INSERT [dbo].[TipoMovimiento] ([TipoMovimientoId], [Nombre], [Estado], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]) VALUES (2, N'Retiro', 1, CAST(N'2022-07-10T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-07-10T00:00:00.0000000' AS DateTime2), N'System')
SET IDENTITY_INSERT [dbo].[TipoMovimiento] OFF
GO
/****** Object:  Index [IX_Cuenta_ClienteId]    Script Date: 2022-07-10 16:53:31 ******/
CREATE NONCLUSTERED INDEX [IX_Cuenta_ClienteId] ON [dbo].[Cuenta]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cuenta_TipoCuentaId]    Script Date: 2022-07-10 16:53:31 ******/
CREATE NONCLUSTERED INDEX [IX_Cuenta_TipoCuentaId] ON [dbo].[Cuenta]
(
	[TipoCuentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movimiento_CuentaId]    Script Date: 2022-07-10 16:53:31 ******/
CREATE NONCLUSTERED INDEX [IX_Movimiento_CuentaId] ON [dbo].[Movimiento]
(
	[CuentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movimiento_TipoMovimientoId]    Script Date: 2022-07-10 16:53:31 ******/
CREATE NONCLUSTERED INDEX [IX_Movimiento_TipoMovimientoId] ON [dbo].[Movimiento]
(
	[TipoMovimientoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Cliente_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_Cliente_ClienteId]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_TipoCuenta_TipoCuentaId] FOREIGN KEY([TipoCuentaId])
REFERENCES [dbo].[TipoCuenta] ([TipoCuentaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_TipoCuenta_TipoCuentaId]
GO
ALTER TABLE [dbo].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Movimiento_Cuenta_CuentaId] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[Cuenta] ([CuentaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movimiento] CHECK CONSTRAINT [FK_Movimiento_Cuenta_CuentaId]
GO
ALTER TABLE [dbo].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Movimiento_TipoMovimiento_TipoMovimientoId] FOREIGN KEY([TipoMovimientoId])
REFERENCES [dbo].[TipoMovimiento] ([TipoMovimientoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movimiento] CHECK CONSTRAINT [FK_Movimiento_TipoMovimiento_TipoMovimientoId]
GO
USE [master]
GO
ALTER DATABASE [NTTDATA] SET  READ_WRITE 
GO
