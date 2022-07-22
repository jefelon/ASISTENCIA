USE [DBASISTENCIA2]
GO
/****** Object:  Table [dbo].[tblAnio]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  Table [dbo].[tblAsistencia]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  Table [dbo].[tblDatoAnual]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  Table [dbo].[tblDatoMesEmp]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  Table [dbo].[tblEmpleado]    Script Date: 10/01/2020 13:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEmpleado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodigoEmpleado] [numeric](18, 0) NULL,
	[Dni] [numeric](8, 0) NULL,
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
/****** Object:  Table [dbo].[tblMes]    Script Date: 10/01/2020 13:57:57 ******/
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
SET IDENTITY_INSERT [dbo].[tblDatoAnual] ON 

INSERT [dbo].[tblDatoAnual] ([Id], [AnioId], [AsigFam], [RemMin], [Essalud], [OnpDat], [AfpDat], [Uit]) VALUES (1, 1, CAST(10.0000 AS Decimal(18, 4)), CAST(930.0000 AS Decimal(18, 4)), CAST(9.0000 AS Decimal(18, 4)), CAST(13.0000 AS Decimal(18, 4)), CAST(10.0000 AS Decimal(18, 4)), CAST(4200.0000 AS Decimal(18, 4)))
SET IDENTITY_INSERT [dbo].[tblDatoAnual] OFF
SET IDENTITY_INSERT [dbo].[tblDatoMesEmp] ON 

INSERT [dbo].[tblDatoMesEmp] ([Id], [EmpleadoId], [AfpCom], [AfpPrimCom], [Basico], [MesId], [AnioId]) VALUES (1, 1, CAST(0.3800 AS Decimal(18, 4)), CAST(1.3500 AS Decimal(18, 4)), CAST(930.0000 AS Decimal(18, 4)), 12, 1)
INSERT [dbo].[tblDatoMesEmp] ([Id], [EmpleadoId], [AfpCom], [AfpPrimCom], [Basico], [MesId], [AnioId]) VALUES (2, 2, CAST(1.6007 AS Decimal(18, 4)), CAST(1.3507 AS Decimal(18, 4)), CAST(2600.0007 AS Decimal(18, 4)), 1, 1)
SET IDENTITY_INSERT [dbo].[tblDatoMesEmp] OFF
SET IDENTITY_INSERT [dbo].[tblEmpleado] ON 

INSERT [dbo].[tblEmpleado] ([Id], [CodigoEmpleado], [Dni], [NombreTexto], [Apellidos], [DepartamentoId], [Cargo], [AsigFam], [Onp], [Afp], [RentaQta], [Tipo]) VALUES (1, CAST(1 AS Numeric(18, 0)), NULL, N'TINTAYA', N'PARI QUISPE', 1, N'CHOFER', 1, 0, 1, 0, N'TRABAJADOR')
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_Eliminar]    Script Date: 10/01/2020 13:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FAsistencia_Eliminar]
@Id as int
AS
BEGIN
	DELETE FROM tblAsistencia
	WHERE tblAsistencia.Id=@Id
	SELECT @@ROWCOUNT AS registros
END





GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_EliminarTodo]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_GetAll]    Script Date: 10/01/2020 13:57:57 ******/
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
	SELECT ROW_NUMBER() OVER (PARTITION BY e.Id,a.Fecha ORDER BY a.Fecha) AS [Marcación], a.Id,NumeroEquipo, a.CodigoEmpleado,e.NombreTexto, e.Apellidos, e.Cargo, 
	CASE a.TipoRegistro 
		WHEN 0 THEN 'Ingreso'
		WHEN 5 THEN 'Salida'
		END AS Tipo, a.Fecha, a.Hora
	FROM tblAsistencia a
	INNER JOIN tblEmpleado e ON a.CodigoEmpleado=e.CodigoEmpleado
	ORDER BY a.Fecha
END





GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_GetAllDatos]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_GetFechas]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_GetFiltro]    Script Date: 10/01/2020 13:57:57 ******/
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
	SELECT NumeroEquipo, e.CodigoEmpleado,e.NombreTexto, e.Apellidos, e.Cargo, 
	CASE a.TipoRegistro 
		WHEN 0 THEN 'Ingreso'
		WHEN 5 THEN 'Salida'
		END AS Tipo, a.Fecha, a.Hora
	FROM tblAsistencia a
	INNER JOIN tblEmpleado e ON a.CodigoEmpleado=e.CodigoEmpleado
	WHERE a.Fecha between @Desde AND @Hasta AND e.Id=@EmpleadoId AND e.Tipo=@Tipo
	ORDER BY a.CodigoEmpleado, a.Fecha,a.Hora
END





GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_GetHoraExtraFechas]    Script Date: 10/01/2020 13:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FAsistencia_GetHoraExtraFechas]
	@Desde as DateTime,
	@Hasta as Datetime
AS
BEGIN
	SELECT a.CodigoEmpleado,CAST(e.NombreTexto AS varchar(max)) as Nombre,CAST(e.Apellidos AS varchar(max)) as Apellidos,CAST(a.FechaHora AS DATE ) AS fechaDia
,MIN(a.FechaHora) as fechaHoraMinima
,MAX(a.FechaHora) as fechaHoraMaxima
,CAST((CAST(DATEDIFF(SECOND, MIN(a.FechaHora),MAX(a.FechaHora)) AS FLOAT) /3600 ) AS DECIMAL(18,2)) AS HorasExtras
,DATEDIFF(HOUR, MIN(a.FechaHora),MAX(a.FechaHora)) % 24 AS Horas
,DATEDIFF(MINUTE, MIN(a.FechaHora),MAX(a.FechaHora)) % 60 AS Minutos
FROM tblAsistencia a
INNER JOIN tblEmpleado e ON a.CodigoEmpleado=e.Id
WHERE a.FechaHora between @Desde AND @Hasta
GROUP BY a.CodigoEmpleado ,CAST(e.NombreTexto AS varchar(max)),CAST(e.Apellidos AS varchar(max)), CAST(a.FechaHora AS DATE )
ORDER BY a.CodigoEmpleado
END





GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_InsertarRegistro]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatos_FAsistencia_Comparar]    Script Date: 10/01/2020 13:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FDatos_FAsistencia_Comparar] 
	-- Add the parameters for the stored procedure here
	@NumeroEquipo as int, @CodigoEmpleado as int ,
	@Fecha as datetime
AS
BEGIN

SELECT Id
FROM tblAsistencia 
WHERE NumeroEquipo=@NumeroEquipo AND CodigoEmpleado=@CodigoEmpleado AND FORMAT(FechaHora,'YYYY-MM-DD hh:mm:ss')= FORMAT(@Fecha,'YYYY-MM-DD hh:mm:ss')

END





GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosAnuales_Actualizar]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosAnuales_Eliminar]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosAnuales_GetAll]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosAnuales_GetAnio]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosAnuales_Insertar]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_Actualizar]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_Eliminar]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_GetAll]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_GetFiltro]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_GetMes]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_Insertar]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FEmpleado_Actualizar]    Script Date: 10/01/2020 13:57:57 ******/
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
	@Id int, @CodigoEmpleado numeric(18),@Dni numeric(18), @NombreTexto varchar(50), @Apellidos varchar(150),
	 @DepartamentoId int, @Cargo varchar(50),@AsigFam int, @Onp int , @Afp int , @RentaQta int, @Tipo varchar(20)
	
AS
BEGIN
	UPDATE tblEmpleado SET  CodigoEmpleado=@CodigoEmpleado, Dni=@Dni,NombreTexto=@NombreTexto, Apellidos=@Apellidos,
	 DepartamentoId =@DepartamentoId, Cargo=@Cargo, AsigFam=@AsigFam, Onp=@Onp, Afp=@Afp, RentaQta=@RentaQta, Tipo=@Tipo
	SELECT @@ROWCOUNT as Afectado

END





GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FEmpleado_Eliminar]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FEmpleado_Get]    Script Date: 10/01/2020 13:57:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_Datos_FEmpleado_Get]
@Id as int
AS
BEGIN
	SELECT *From tblEmpleado
	where Id=@Id
END





GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FEmpleado_GetAll]    Script Date: 10/01/2020 13:57:57 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FEmpleado_Insertar]    Script Date: 10/01/2020 13:57:57 ******/
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
	 @CodigoEmpleado numeric(18),@Dni numeric(18), @NombreTexto varchar(50), @Apellidos varchar(150),
	 @DepartamentoId int, @Cargo varchar(50),@AsigFam int, @Onp int , @Afp int , @RentaQta int,@Tipo varchar(20)
	
AS
BEGIN
	INSERt INTO tblEmpleado(CodigoEmpleado,Dni, NombreTexto, Apellidos, DepartamentoId, Cargo, AsigFam, Onp, Afp, RentaQta,Tipo)
				values(@CodigoEmpleado, @Dni,@NombreTexto, @Apellidos, @DepartamentoId, @Cargo, @AsigFam, @Onp, @Afp, @RentaQta,@Tipo)
	SELECT @@ROWCOUNT as Afectado

END





GO
