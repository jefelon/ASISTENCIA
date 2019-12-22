USE [DBASISTENCIA]
GO
/****** Object:  Table [dbo].[tblAnio]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAnio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Anio] [int] NOT NULL,
 CONSTRAINT [PK_tblPeriodo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblAsistencia]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAsistencia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumeroEquipo] [int] NOT NULL,
	[CodigoEmpleado] [numeric](18, 0) NOT NULL,
	[ModoAcceso] [int] NOT NULL,
	[TipoRegistro] [int] NOT NULL,
	[FechaHora] [datetime] NULL,
	[Fecha] [date] NULL,
	[Hora] [time](7) NULL,
 CONSTRAINT [PK__tblAsist__3214EC07B9CB320A] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblDatoAnual]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDatoAnual](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AnioId] [int] NOT NULL,
	[AsigFam] [decimal](18, 4) NULL,
	[RemMin] [decimal](18, 4) NULL,
	[Essalud] [decimal](18, 4) NULL,
	[OnpDat] [decimal](18, 4) NULL,
	[AfpDat] [decimal](18, 4) NULL,
	[Uit] [decimal](18, 4) NULL,
 CONSTRAINT [PK_tblDatoAnual] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblDatoMesEmp]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDatoMesEmp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpleadoId] [int] NULL,
	[AfpCom] [decimal](18, 4) NULL,
	[AfpPrimCom] [decimal](18, 4) NULL,
	[Basico] [decimal](18, 4) NULL,
	[MesId] [int] NULL,
	[AnioId] [int] NULL,
 CONSTRAINT [PK_tblDatoMesEmp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblEmpleado]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEmpleado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NULL,
	[CodigoEmpleado] [numeric](18, 0) NULL,
	[NombreTexto] [text] NULL,
	[Apellidos] [text] NULL,
	[DepartamentoId] [int] NULL,
	[Cargo] [varchar](50) NULL,
	[AsigFam] [int] NULL,
	[Onp] [int] NULL,
	[Afp] [int] NULL,
	[RentaQta] [int] NULL,
	[Tipo] [varchar](50) NULL,
 CONSTRAINT [PK__tblEmple__3214EC07AAD3311B] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblMes]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblMes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Mes] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblMes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblAnio] ON 

INSERT [dbo].[tblAnio] ([Id], [Anio]) VALUES (1, 2019)
INSERT [dbo].[tblAnio] ([Id], [Anio]) VALUES (2, 2020)
INSERT [dbo].[tblAnio] ([Id], [Anio]) VALUES (3, 2021)
INSERT [dbo].[tblAnio] ([Id], [Anio]) VALUES (4, 2022)
INSERT [dbo].[tblAnio] ([Id], [Anio]) VALUES (5, 2023)
INSERT [dbo].[tblAnio] ([Id], [Anio]) VALUES (6, 2024)
INSERT [dbo].[tblAnio] ([Id], [Anio]) VALUES (7, 2025)
SET IDENTITY_INSERT [dbo].[tblAnio] OFF
SET IDENTITY_INSERT [dbo].[tblAsistencia] ON 

INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (1, 1, CAST(1 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-07 08:00:00.000' AS DateTime), CAST(N'2019-12-07' AS Date), CAST(N'08:00:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (2, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-07 08:05:00.000' AS DateTime), CAST(N'2019-12-07' AS Date), CAST(N'08:05:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (3, 1, CAST(1 AS Numeric(18, 0)), 1, 5, CAST(N'2019-12-07 12:00:00.000' AS DateTime), CAST(N'2019-12-07' AS Date), CAST(N'12:00:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (4, 1, CAST(2 AS Numeric(18, 0)), 1, 5, CAST(N'2019-12-07 12:07:00.000' AS DateTime), CAST(N'2019-12-07' AS Date), CAST(N'12:07:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (5, 1, CAST(1 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-07 13:00:00.000' AS DateTime), CAST(N'2019-12-07' AS Date), CAST(N'13:00:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (6, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-07 13:05:00.000' AS DateTime), CAST(N'2019-12-07' AS Date), CAST(N'13:05:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (7, 1, CAST(1 AS Numeric(18, 0)), 1, 5, CAST(N'2019-12-07 16:00:00.000' AS DateTime), CAST(N'2019-12-07' AS Date), CAST(N'16:00:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (8, 1, CAST(2 AS Numeric(18, 0)), 1, 5, CAST(N'2019-12-07 16:04:00.000' AS DateTime), CAST(N'2019-12-07' AS Date), CAST(N'16:04:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (9, 1, CAST(1 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-08 08:00:00.000' AS DateTime), CAST(N'2019-12-08' AS Date), CAST(N'08:00:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (10, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-08 08:05:00.000' AS DateTime), CAST(N'2019-12-08' AS Date), CAST(N'08:05:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (11, 1, CAST(1 AS Numeric(18, 0)), 1, 5, CAST(N'2019-12-08 12:30:00.000' AS DateTime), CAST(N'2019-12-08' AS Date), CAST(N'12:00:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (12, 1, CAST(2 AS Numeric(18, 0)), 1, 5, CAST(N'2019-12-08 12:07:00.000' AS DateTime), CAST(N'2019-12-08' AS Date), CAST(N'12:07:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (13, 1, CAST(1 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-08 13:00:00.000' AS DateTime), CAST(N'2019-12-08' AS Date), CAST(N'13:00:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (14, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-08 13:05:00.000' AS DateTime), CAST(N'2019-12-08' AS Date), CAST(N'13:05:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (15, 1, CAST(1 AS Numeric(18, 0)), 1, 5, CAST(N'2019-12-08 16:00:00.000' AS DateTime), CAST(N'2019-12-08' AS Date), CAST(N'16:00:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (16, 1, CAST(2 AS Numeric(18, 0)), 1, 5, CAST(N'2019-12-08 16:04:00.000' AS DateTime), CAST(N'2019-12-08' AS Date), CAST(N'16:04:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (17, 1, CAST(1 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-09 08:00:00.000' AS DateTime), CAST(N'2019-12-09' AS Date), CAST(N'08:00:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (18, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-09 08:05:00.000' AS DateTime), CAST(N'2019-12-09' AS Date), CAST(N'08:05:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (19, 1, CAST(1 AS Numeric(18, 0)), 1, 5, CAST(N'2019-12-09 12:00:00.000' AS DateTime), CAST(N'2019-12-09' AS Date), CAST(N'12:00:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (20, 1, CAST(2 AS Numeric(18, 0)), 1, 5, CAST(N'2019-12-09 12:07:00.000' AS DateTime), CAST(N'2019-12-09' AS Date), CAST(N'12:07:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (21, 1, CAST(1 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-09 13:00:00.000' AS DateTime), CAST(N'2019-12-09' AS Date), CAST(N'13:00:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (22, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-09 13:05:00.000' AS DateTime), CAST(N'2019-12-09' AS Date), CAST(N'13:05:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (23, 1, CAST(1 AS Numeric(18, 0)), 1, 5, CAST(N'2019-12-09 16:00:00.000' AS DateTime), CAST(N'2019-12-09' AS Date), CAST(N'16:00:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (24, 1, CAST(2 AS Numeric(18, 0)), 1, 5, CAST(N'2019-12-09 16:04:00.000' AS DateTime), CAST(N'2019-12-09' AS Date), CAST(N'16:04:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (25, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-11-30 09:56:18.000' AS DateTime), CAST(N'2019-11-30' AS Date), CAST(N'09:56:18' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (26, 1, CAST(1 AS Numeric(18, 0)), 1, 0, CAST(N'2019-11-30 09:56:25.000' AS DateTime), CAST(N'2019-11-30' AS Date), CAST(N'09:56:25' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (27, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-11-30 10:07:56.000' AS DateTime), CAST(N'2019-11-30' AS Date), CAST(N'10:07:56' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (28, 1, CAST(1 AS Numeric(18, 0)), 1, 0, CAST(N'2019-11-30 10:08:00.000' AS DateTime), CAST(N'2019-11-30' AS Date), CAST(N'10:08:00' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (29, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-11-30 10:25:29.000' AS DateTime), CAST(N'2019-11-30' AS Date), CAST(N'10:25:29' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (30, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-11-30 10:43:05.000' AS DateTime), CAST(N'2019-11-30' AS Date), CAST(N'10:43:05' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (31, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-01 01:01:06.000' AS DateTime), CAST(N'2019-12-01' AS Date), CAST(N'01:01:06' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (32, 1, CAST(1 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-01 01:01:10.000' AS DateTime), CAST(N'2019-12-01' AS Date), CAST(N'01:01:10' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (33, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-01 03:25:59.000' AS DateTime), CAST(N'2019-12-01' AS Date), CAST(N'03:25:59' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (34, 1, CAST(1 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-01 03:26:03.000' AS DateTime), CAST(N'2019-12-01' AS Date), CAST(N'03:26:03' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (35, 1, CAST(1 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-01 03:27:46.000' AS DateTime), CAST(N'2019-12-01' AS Date), CAST(N'03:27:46' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (36, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-01 03:27:51.000' AS DateTime), CAST(N'2019-12-01' AS Date), CAST(N'03:27:51' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (37, 1, CAST(1 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-01 07:59:59.000' AS DateTime), CAST(N'2019-12-01' AS Date), CAST(N'07:59:59' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (38, 1, CAST(1 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-01 08:03:50.000' AS DateTime), CAST(N'2019-12-01' AS Date), CAST(N'08:03:50' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (39, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-01 08:04:35.000' AS DateTime), CAST(N'2019-12-01' AS Date), CAST(N'08:04:35' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (40, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-01 08:05:58.000' AS DateTime), CAST(N'2019-12-01' AS Date), CAST(N'08:05:58' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (41, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-11-30 19:08:30.000' AS DateTime), CAST(N'2019-11-30' AS Date), CAST(N'19:08:30' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (42, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-11-30 19:23:18.000' AS DateTime), CAST(N'2019-11-30' AS Date), CAST(N'19:23:18' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (43, 1, CAST(1 AS Numeric(18, 0)), 1, 0, CAST(N'2019-11-30 19:23:23.000' AS DateTime), CAST(N'2019-11-30' AS Date), CAST(N'19:23:23' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (44, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-11-30 21:51:28.000' AS DateTime), CAST(N'2019-11-30' AS Date), CAST(N'21:51:28' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (45, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-11-30 21:51:49.000' AS DateTime), CAST(N'2019-11-30' AS Date), CAST(N'21:51:49' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (46, 1, CAST(1 AS Numeric(18, 0)), 1, 0, CAST(N'2019-11-30 21:52:04.000' AS DateTime), CAST(N'2019-11-30' AS Date), CAST(N'21:52:04' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (47, 1, CAST(2 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-01 09:28:27.000' AS DateTime), CAST(N'2019-12-01' AS Date), CAST(N'09:28:27' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (48, 1, CAST(1 AS Numeric(18, 0)), 1, 0, CAST(N'2019-12-01 09:28:43.000' AS DateTime), CAST(N'2019-12-01' AS Date), CAST(N'09:28:43' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (49, 1, CAST(1 AS Numeric(18, 0)), 1, 5, CAST(N'2019-12-01 09:32:15.000' AS DateTime), CAST(N'2019-12-01' AS Date), CAST(N'09:32:15' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (50, 1, CAST(2 AS Numeric(18, 0)), 1, 5, CAST(N'2019-12-01 09:32:19.000' AS DateTime), CAST(N'2019-12-01' AS Date), CAST(N'09:32:19' AS Time))
INSERT [dbo].[tblAsistencia] ([Id], [NumeroEquipo], [CodigoEmpleado], [ModoAcceso], [TipoRegistro], [FechaHora], [Fecha], [Hora]) VALUES (51, 1, CAST(3 AS Numeric(18, 0)), 1, 5, CAST(N'2019-12-01 09:32:42.000' AS DateTime), CAST(N'2019-12-01' AS Date), CAST(N'09:32:42' AS Time))
SET IDENTITY_INSERT [dbo].[tblAsistencia] OFF
SET IDENTITY_INSERT [dbo].[tblDatoAnual] ON 

INSERT [dbo].[tblDatoAnual] ([Id], [AnioId], [AsigFam], [RemMin], [Essalud], [OnpDat], [AfpDat], [Uit]) VALUES (1, 1, CAST(10.0000 AS Decimal(18, 4)), CAST(930.0000 AS Decimal(18, 4)), CAST(9.0000 AS Decimal(18, 4)), CAST(13.0000 AS Decimal(18, 4)), CAST(10.0000 AS Decimal(18, 4)), CAST(4200.0000 AS Decimal(18, 4)))
SET IDENTITY_INSERT [dbo].[tblDatoAnual] OFF
SET IDENTITY_INSERT [dbo].[tblDatoMesEmp] ON 

INSERT [dbo].[tblDatoMesEmp] ([Id], [EmpleadoId], [AfpCom], [AfpPrimCom], [Basico], [MesId], [AnioId]) VALUES (1, 1, CAST(0.3800 AS Decimal(18, 4)), CAST(1.3500 AS Decimal(18, 4)), CAST(930.0000 AS Decimal(18, 4)), 12, 1)
INSERT [dbo].[tblDatoMesEmp] ([Id], [EmpleadoId], [AfpCom], [AfpPrimCom], [Basico], [MesId], [AnioId]) VALUES (2, 2, CAST(1.6007 AS Decimal(18, 4)), CAST(1.3507 AS Decimal(18, 4)), CAST(2600.0007 AS Decimal(18, 4)), 1, 1)
SET IDENTITY_INSERT [dbo].[tblDatoMesEmp] OFF
SET IDENTITY_INSERT [dbo].[tblEmpleado] ON 

INSERT [dbo].[tblEmpleado] ([Id], [Codigo], [CodigoEmpleado], [NombreTexto], [Apellidos], [DepartamentoId], [Cargo], [AsigFam], [Onp], [Afp], [RentaQta], [Tipo]) VALUES (1, N'12345', CAST(1 AS Numeric(18, 0)), N'TINTAYA', N'PARI QUISPE', 1, N'CHOFER', 1, 0, 1, 0, N'TRABAJADOR')
INSERT [dbo].[tblEmpleado] ([Id], [Codigo], [CodigoEmpleado], [NombreTexto], [Apellidos], [DepartamentoId], [Cargo], [AsigFam], [Onp], [Afp], [RentaQta], [Tipo]) VALUES (2, N'222222', CAST(2 AS Numeric(18, 0)), N'DENNIS JUAN2', N'ARONI CASILLA2', 1, N'TORNERO2', 0, 0, 0, 0, N'EMPLEADO')
SET IDENTITY_INSERT [dbo].[tblEmpleado] OFF
SET IDENTITY_INSERT [dbo].[tblMes] ON 

INSERT [dbo].[tblMes] ([Id], [Mes]) VALUES (1, N'ENERO')
INSERT [dbo].[tblMes] ([Id], [Mes]) VALUES (2, N'FEBRERO')
INSERT [dbo].[tblMes] ([Id], [Mes]) VALUES (3, N'MARZO')
INSERT [dbo].[tblMes] ([Id], [Mes]) VALUES (4, N'ABRIL')
INSERT [dbo].[tblMes] ([Id], [Mes]) VALUES (5, N'MAYO')
INSERT [dbo].[tblMes] ([Id], [Mes]) VALUES (6, N'JUNIO')
INSERT [dbo].[tblMes] ([Id], [Mes]) VALUES (7, N'JULIO')
INSERT [dbo].[tblMes] ([Id], [Mes]) VALUES (8, N'AGOSTO')
INSERT [dbo].[tblMes] ([Id], [Mes]) VALUES (9, N'SEPTIEMBRE')
INSERT [dbo].[tblMes] ([Id], [Mes]) VALUES (10, N'OCTUBRE')
INSERT [dbo].[tblMes] ([Id], [Mes]) VALUES (11, N'NOVIEMBRE')
INSERT [dbo].[tblMes] ([Id], [Mes]) VALUES (12, N'DICIEMBRE')
SET IDENTITY_INSERT [dbo].[tblMes] OFF
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_EliminarTodo]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FAsistencia_EliminarTodo]

AS
BEGIN
	DELETE FROM tblAsistencia
	SELECT @@ROWCOUNT AS registros
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_GetAll]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FAsistencia_GetAll]

AS
BEGIN
	SELECT NumeroEquipo, e.Codigo,e.NombreTexto, e.Apellidos, e.Cargo, 
	CASE a.TipoRegistro 
		WHEN 0 THEN 'Ingreso'
		WHEN 5 THEN 'Salida'
		END AS Tipo, a.Fecha, a.Hora
	FROM tblAsistencia a
	INNER JOIN tblEmpleado e ON a.CodigoEmpleado=e.Id
	ORDER BY a.CodigoEmpleado, a.Fecha,a.Hora
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_GetAllDatos]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FAsistencia_GetAllDatos] 
	-- Add the parameters for the stored procedure here
	@Anio as int,
	@Mes as int,
	@EmpleadoId as int
AS
BEGIN
	SELECT e.Id as EmpleadoId,e.NombreTexto,e.Apellidos,e.Cargo,e.AsigFam,e.Onp,e.Afp, a.Anio, m.Mes, daa.AsigFam, daa.RemMin, daa.Essalud,daa.OnpDat,daa.AfpDat,daa.Uit,
	dae.Basico as Salario, dae.AfpCom,dae.AfpPrimCom,e.RentaQta

	FROM tblEmpleado e
	INNER JOIN tblDatoMesEmp dae ON dae.EmpleadoId=e.Id
	INNER JOIN tblMes m ON m.Id = dae.MesId
	INNER JOIN tblAnio a ON a.Id = dae.AnioId
	INNER JOIN tblDatoAnual daa ON dae.AnioId=a.Id

	WHERE a.Anio =@Anio AND m.Id=@Mes AND e.Id=@EmpleadoId
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_GetFechas]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FAsistencia_GetFechas]
	@Fecha as DateTime,
	@EmpleadoId as int,
	@Tipo varchar(20)
AS
BEGIN
	WITH temp AS
	(
		SELECT ROW_NUMBER() OVER(PARTITION BY a.CodigoEmpleado ORDER BY FechaHora) AS [rid], a.CodigoEmpleado, e.NombreTexto,FechaHora,e.Tipo
		FROM dbo.tblAsistencia a
		INNER JOIN tblEmpleado e ON e.CodigoEmpleado=a.CodigoEmpleado
		WHERE CONVERT(VARCHAR(8), FechaHora, 112)>=@Fecha
	)
	SELECT --* FROM temp WHERE EmpleadoID = 9987
			e.CodigoEmpleado,e.NombreTexto as Nombre,CONVERT(char(10), e.FechaHora, 103) AS Fecha,CONVERT(char(10), e.FechaHora, 108)  HoraEntrada, CONVERT(char(10), s.FechaHora, 108) HoraSalida
			,CONVERT(char(10), f.FechaHora, 108) HoraEntrada1,
			HoraSalida1=Case When CONVERT(char(10), g.FechaHora, 108)=CONVERT(char(10), f.FechaHora, 108) then NULL
							when CONVERT(char(10), g.FechaHora, 108)=CONVERT(char(10), s.FechaHora, 108) then NULL
							else CONVERT(char(10), g.FechaHora, 108)
							end,CAST(
			DATEDIFF(MI,CONVERT(char(10), e.FechaHora, 108),CONVERT(char(10), s.FechaHora, 108))+
			DATEDIFF(MI,CONVERT(char(10), f.FechaHora, 108),(
							Case When CONVERT(char(10), g.FechaHora, 108)=CONVERT(char(10), f.FechaHora, 108) then NULL
							when CONVERT(char(10), g.FechaHora, 108)=CONVERT(char(10), s.FechaHora, 108) then NULL
							else CONVERT(char(10), g.FechaHora, 108)
							end)) AS FLOAT)/60 AS HorasAc
	FROM temp e
	LEFT JOIN (SELECT CodigoEmpleado, MIN(FechaHora) FechaHora FROM temp WHERE rid > 1 GROUP BY CodigoEmpleado) AS s ON s.CodigoEmpleado = e.CodigoEmpleado
	LEFT JOIN (SELECT CodigoEmpleado, Min(FechaHora) FechaHora FROM temp WHERE rid > 2 GROUP BY CodigoEmpleado) AS f ON f.CodigoEmpleado = e.CodigoEmpleado
	LEFT JOIN (SELECT CodigoEmpleado, max(FechaHora) FechaHora FROM temp WHERE rid > 1 GROUP BY CodigoEmpleado) AS g ON g.CodigoEmpleado = e.CodigoEmpleado
	WHERE e.rid = 1
	AND e.CodigoEmpleado =@EmpleadoId
	AND e.Tipo=@Tipo
	ORDER BY e.CodigoEmpleado
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_GetFiltro]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FAsistencia_GetFiltro]
	@EmpleadoId int, 
	@Desde Date ,
	@Hasta Date ,
	@Tipo varchar(20)

AS
BEGIN
	SELECT NumeroEquipo, e.Codigo,e.NombreTexto, e.Apellidos, e.Cargo, 
	CASE a.TipoRegistro 
		WHEN 0 THEN 'Ingreso'
		WHEN 5 THEN 'Salida'
		END AS Tipo, a.Fecha, a.Hora
	FROM tblAsistencia a
	INNER JOIN tblEmpleado e ON a.CodigoEmpleado=e.Id
	WHERE a.Fecha >=@Desde AND a.Fecha<=@Hasta AND a.Id=@EmpleadoId AND e.Tipo=@Tipo
	ORDER BY a.CodigoEmpleado, a.Fecha,a.Hora
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_InsertarRegistro]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FAsistencia_InsertarRegistro]
	@NumeroEquipo int, 
	@CodigoEmpleado int ,
	@ModoAcceso int ,
	@TipoRegistro int ,
	@Fecha Datetime
AS
BEGIN
	insert into tblAsistencia(NumeroEquipo, CodigoEmpleado, ModoAcceso,TipoRegistro,FechaHora,Fecha,Hora)
					   values(@NumeroEquipo, @CodigoEmpleado, @ModoAcceso,@TipoRegistro,@Fecha,@Fecha,@Fecha)

	SELECT @@ROWCOUNT as Afectado
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosAnuales_Actualizar]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FDatosAnuales_Actualizar]
	@Id int, @AnioId int, @AsigFam decimal(18,4), @RemMin decimal(18,4), @Essalud decimal(18,4), @OnpDat decimal(18,4), @AfpDat decimal(18,4), @Uit decimal(18,4)
	
AS
BEGIN
	UPDATE tblDatoAnual SET AnioId=@AnioId, AsigFam=@AsigFam, RemMin=@RemMin, Essalud=@Essalud, OnpDat=@OnpDat, AfpDat=@AfpDat, Uit=@Uit
	WHERE tblDatoAnual.Id=@Id
	SELECT @@ROWCOUNT as Afectado

END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosAnuales_Eliminar]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FDatosAnuales_Eliminar]
	@Id int
	
AS
BEGIN
	DELETE FROM  tblDatoAnual 
	WHERE tblDatoAnual.Id=@Id
	SELECT @@ROWCOUNT as Afectado

END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosAnuales_GetAll]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FDatosAnuales_GetAll] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	
SELECT da.Id,a.Anio,da.AsigFam,da.RemMin,da.Essalud,da.OnpDat,da.AfpDat,da.Uit
FROM tblDatoAnual da
INNER JOIN tblAnio a ON a.Id=da.AnioId

END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosAnuales_GetAnio]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FDatosAnuales_GetAnio] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	
SELECT *
FROM tblAnio 

END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosAnuales_Insertar]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FDatosAnuales_Insertar]
	@AnioId int, @AsigFam decimal(18,4), @RemMin decimal(18,4), @Essalud decimal(18,4), @OnpDat decimal(18,4), @AfpDat decimal(18,4), @Uit decimal(18,4)
	
AS
BEGIN
	INSERT INTO tblDatoAnual(AnioId, AsigFam, RemMin, Essalud, OnpDat, AfpDat, Uit)
	values(@AnioId, @AsigFam, @RemMin, @Essalud, @OnpDat, @AfpDat, @Uit)

	SELECT @@ROWCOUNT as Afectado

END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_Actualizar]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FDatosMensuales_Actualizar]
	@Id int,@empleadoId int, @mesId int, @anioId int ,@afpCom decimal(18,4), @afpPrimCom decimal(18,4), @basico decimal(18,4)
	
AS
BEGIN
	UPDATE  tblDatoMesEmp SET EmpleadoId=@EmpleadoId, AfpCom=@AfpCom, AfpPrimCom=@AfpPrimCom, 
	Basico=@Basico, MesId=@MesId, AnioId=@AnioId
	WHERE tblDatoMesEmp.Id=@Id

	SELECT @@ROWCOUNT as Afectado

END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_Eliminar]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FDatosMensuales_Eliminar]
	@Id int
	
AS
BEGIN
	DELETE FROM  tblDatoMesEmp 
	WHERE tblDatoMesEmp.Id=@Id
	SELECT @@ROWCOUNT as Afectado

END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_GetAll]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FDatosMensuales_GetAll]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	
SELECT me.Id, me.EmpleadoId, e.NombreTexto,m.Mes, me.AfpCom, me.AfpPrimCom, me.Basico, a.Anio

FROM tblDatoMesEmp me
INNER JOIN tblAnio a ON a.Id=me.AnioId
INNER JOIN tblMes m ON m.Id=me.MesId
INNER JOIN tblEmpleado e ON e.Id=me.EmpleadoId

END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_GetFiltro]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FDatosMensuales_GetFiltro]
	@EmpleadoId int,
	@Anio varchar(4),
	@Mes varchar(50)
	
AS
BEGIN
	
SELECT me.Id,me.EmpleadoId, e.NombreTexto, m.Mes,me.AfpCom, me.AfpPrimCom, me.Basico, a.Anio

FROM tblDatoMesEmp me
INNER JOIN tblAnio a ON a.Id=me.AnioId
INNER JOIN tblMes m ON m.Id=me.MesId
INNER JOIN tblEmpleado e ON e.Id=me.EmpleadoId

WHERE e.Id=@EmpleadoId AND a.Anio=@Anio AND m.Mes=@Mes

END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_GetMes]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FDatosMensuales_GetMes]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	
SELECT * FROM tblMes

END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_Insertar]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FDatosMensuales_Insertar]
	@empleadoId int, @mesId int, @anioId int ,@afpCom decimal(18,4), @afpPrimCom decimal(18,4), @basico decimal(18,4)
	
AS
BEGIN
	INSERT INTO tblDatoMesEmp(EmpleadoId, AfpCom, AfpPrimCom, Basico, MesId, AnioId)
	values(@EmpleadoId, @AfpCom, @AfpPrimCom, @Basico, @MesId, @AnioId)

	SELECT @@ROWCOUNT as Afectado

END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FEmpleado_Actualizar]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FEmpleado_Actualizar]
	@Id int,@Codigo numeric(18,0), @CodigoEmpleado varchar(50), @NombreTexto varchar(50), @Apellidos varchar(150),
	 @DepartamentoId int, @Cargo varchar(50),@AsigFam int, @Onp int , @Afp int , @RentaQta int, @Tipo varchar(20)
	
AS
BEGIN
	UPDATE tblEmpleado SET Codigo=@Codigo, CodigoEmpleado=@CodigoEmpleado, NombreTexto=@NombreTexto, Apellidos=@Apellidos,
	 DepartamentoId =@DepartamentoId, Cargo=@Cargo, AsigFam=@AsigFam, Onp=@Onp, Afp=@Afp, RentaQta=@RentaQta, Tipo=@Tipo
	SELECT @@ROWCOUNT as Afectado

END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FEmpleado_Eliminar]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FEmpleado_Eliminar]
	@Id int
	
AS
BEGIN
	DELETE FROM  tblEmpleado 
	WHERE tblEmpleado.Id=@Id
	SELECT @@ROWCOUNT as Afectado

END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FEmpleado_GetAll]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_Datos_FEmpleado_GetAll]

AS
BEGIN
	SELECT *From tblEmpleado
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FEmpleado_Insertar]    Script Date: 21/12/2019 19:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FEmpleado_Insertar]
	@Codigo numeric(18,0), @CodigoEmpleado numeric(18,0), @NombreTexto varchar(50), @Apellidos varchar(150),
	 @DepartamentoId int, @Cargo varchar(50),@AsigFam int, @Onp int , @Afp int , @RentaQta int,@Tipo varchar(20)
	
AS
BEGIN
	INSERt INTO tblEmpleado(Codigo, CodigoEmpleado, NombreTexto, Apellidos, DepartamentoId, Cargo, AsigFam, Onp, Afp, RentaQta,Tipo)
				values(@Codigo, @CodigoEmpleado, @NombreTexto, @Apellidos, @DepartamentoId, @Cargo, @AsigFam, @Onp, @Afp, @RentaQta,@Tipo)
	SELECT @@ROWCOUNT as Afectado

END

GO
