USE [DBGIANINI]
GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_Eliminar]    Script Date: 18/02/2020 16:29:16 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_EliminarTodo]    Script Date: 18/02/2020 16:29:16 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_GetAll]    Script Date: 18/02/2020 16:29:16 ******/
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
	SELECT ROW_NUMBER() OVER (PARTITION BY e.CodigoEmpleado,a.Fecha ORDER BY a.Fecha) AS [Marcación], a.Id,NumeroEquipo, a.CodigoEmpleado,e.NombreTexto, e.Apellidos, e.Cargo, 
	CASE a.TipoRegistro 
		WHEN 0 THEN 'Ingreso'
		WHEN 5 THEN 'Salida'
		END AS Tipo, a.Fecha, a.Hora
	FROM tblAsistencia a
	INNER JOIN tblEmpleado e ON a.CodigoEmpleado=e.CodigoEmpleado
	ORDER BY a.Fecha
END






GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_GetAllDatos]    Script Date: 18/02/2020 16:29:16 ******/
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
	@CodigoEmpleado as int
AS
BEGIN
	SELECT e.CodigoEmpleado,e.NombreTexto,e.Apellidos,e.Cargo,e.AsigFam,e.Onp,e.Afp, a.Anio, m.Mes, daa.AsigFam, daa.RemMin, daa.Essalud,daa.OnpDat,daa.AfpDat,daa.Uit,
	dae.Basico as Salario, dae.AfpCom,dae.AfpPrimCom,e.RentaQta

	FROM tblEmpleado e
	INNER JOIN tblDatoMesEmp dae ON dae.CodigoEmpleado=e.CodigoEmpleado
	INNER JOIN tblMes m ON m.Id = dae.MesId
	INNER JOIN tblAnio a ON a.Id = dae.AnioId
	INNER JOIN tblDatoAnual daa ON dae.AnioId=a.Id

	WHERE a.Anio =@Anio AND m.Id=@Mes AND e.CodigoEmpleado=@CodigoEmpleado
END






GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_GetFechas]    Script Date: 18/02/2020 16:29:16 ******/
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
	@CodigoEmpleado as int,
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
	AND e.CodigoEmpleado =@CodigoEmpleado
	AND e.Tipo=@Tipo
	ORDER BY e.CodigoEmpleado
END






GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_GetFiltro]    Script Date: 18/02/2020 16:29:16 ******/
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
	@CodigoEmpleado int, 
	@Desde Date ,
	@Hasta Date ,
	@Tipo varchar(20)

AS
BEGIN
	SELECT a.Id,NumeroEquipo, e.CodigoEmpleado,e.NombreTexto, e.Apellidos, e.Cargo, 
	CASE a.TipoRegistro 
		WHEN 0 THEN 'Ingreso'
		WHEN 5 THEN 'Salida'
		END AS Tipo, a.Fecha, a.Hora
	FROM tblAsistencia a
	INNER JOIN tblEmpleado e ON a.CodigoEmpleado=e.CodigoEmpleado
	WHERE a.Fecha between @Desde AND @Hasta AND e.CodigoEmpleado=@CodigoEmpleado AND e.Tipo=@Tipo
	ORDER BY a.CodigoEmpleado, a.Fecha,a.Hora
END




GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_GetHoraExtraFechas]    Script Date: 18/02/2020 16:29:16 ******/
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
INNER JOIN tblEmpleado e ON a.CodigoEmpleado=e.CodigoEmpleado
WHERE a.FechaHora between @Desde AND @Hasta
GROUP BY a.CodigoEmpleado ,CAST(e.NombreTexto AS varchar(max)),CAST(e.Apellidos AS varchar(max)), CAST(a.FechaHora AS DATE )
ORDER BY a.CodigoEmpleado
END






GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FAsistencia_InsertarRegistro]    Script Date: 18/02/2020 16:29:16 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatos_FAsistencia_Comparar]    Script Date: 18/02/2020 16:29:16 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosAnuales_Actualizar]    Script Date: 18/02/2020 16:29:16 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosAnuales_Eliminar]    Script Date: 18/02/2020 16:29:16 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosAnuales_GetAll]    Script Date: 18/02/2020 16:29:16 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosAnuales_GetAnio]    Script Date: 18/02/2020 16:29:16 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosAnuales_Insertar]    Script Date: 18/02/2020 16:29:16 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_Actualizar]    Script Date: 18/02/2020 16:29:16 ******/
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
	@Id int,@CodigoEmpleado int, @mesId int, @anioId int ,@afpCom decimal(18,4), @afpPrimCom decimal(18,4), @basico decimal(18,4)
	
AS
BEGIN
	UPDATE  tblDatoMesEmp SET CodigoEmpleado=@CodigoEmpleado, AfpCom=@AfpCom, AfpPrimCom=@AfpPrimCom, 
	Basico=@Basico, MesId=@MesId, AnioId=@AnioId
	WHERE tblDatoMesEmp.Id=@Id

	SELECT @@ROWCOUNT as Afectado

END






GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_Eliminar]    Script Date: 18/02/2020 16:29:16 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_GetAll]    Script Date: 18/02/2020 16:29:16 ******/
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
	
SELECT me.Id, me.CodigoEmpleado, e.NombreTexto,m.Mes, me.AfpCom, me.AfpPrimCom, me.Basico, a.Anio

FROM tblDatoMesEmp me
INNER JOIN tblAnio a ON a.Id=me.AnioId
INNER JOIN tblMes m ON m.Id=me.MesId
INNER JOIN tblEmpleado e ON e.CodigoEmpleado=me.CodigoEmpleado

END






GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_GetFiltro]    Script Date: 18/02/2020 16:29:16 ******/
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
	@CodigoEmpleado int,
	@Anio varchar(4),
	@Mes varchar(50)
	
AS
BEGIN
	
SELECT me.Id,me.CodigoEmpleado, e.NombreTexto, m.Mes,me.AfpCom, me.AfpPrimCom, me.Basico, a.Anio

FROM tblDatoMesEmp me
INNER JOIN tblAnio a ON a.Id=me.AnioId
INNER JOIN tblMes m ON m.Id=me.MesId
INNER JOIN tblEmpleado e ON e.CodigoEmpleado=me.CodigoEmpleado

WHERE e.CodigoEmpleado=@CodigoEmpleado AND a.Anio=@Anio AND m.Mes=@Mes

END






GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_GetMes]    Script Date: 18/02/2020 16:29:16 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_GetUltimoRegistro]    Script Date: 18/02/2020 16:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Datos_FDatosMensuales_GetUltimoRegistro]
	@CodigoEmpleado int,
	@Anio varchar(4),
	@Mes int
	
AS
BEGIN
	
SELECT me.Id,me.CodigoEmpleado, m.Mes,me.AfpCom, me.AfpPrimCom, me.Basico, a.Anio

FROM tblDatoMesEmp me
INNER JOIN tblAnio a ON a.Id=me.AnioId
INNER JOIN tblMes m ON m.Id=me.MesId
INNER JOIN tblEmpleado e ON e.CodigoEmpleado=me.CodigoEmpleado

WHERE e.CodigoEmpleado=@CodigoEmpleado AND a.Anio=@Anio AND m.Id=@Mes-1

END






GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FDatosMensuales_Insertar]    Script Date: 18/02/2020 16:29:16 ******/
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
	@CodigoEmpleado int, @mesId int, @anioId int ,@afpCom decimal(18,4), @afpPrimCom decimal(18,4), @basico decimal(18,4)
	
AS
BEGIN
	INSERT INTO tblDatoMesEmp(CodigoEmpleado, AfpCom, AfpPrimCom, Basico, MesId, AnioId)
	values(@CodigoEmpleado, @AfpCom, @AfpPrimCom, @Basico, @MesId, @AnioId)

	SELECT @@ROWCOUNT as Afectado

END






GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FEmpleado_Actualizar]    Script Date: 18/02/2020 16:29:16 ******/
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
	 WHERE Id=@Id
	SELECT @@ROWCOUNT as Afectado

END






GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FEmpleado_Eliminar]    Script Date: 18/02/2020 16:29:16 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FEmpleado_Get]    Script Date: 18/02/2020 16:29:16 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FEmpleado_GetAll]    Script Date: 18/02/2020 16:29:16 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Datos_FEmpleado_GetTipo]    Script Date: 18/02/2020 16:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[usp_Datos_FEmpleado_GetTipo]
@Tipo as varchar(50)
AS
BEGIN
	SELECT *From tblEmpleado
	where Tipo=@Tipo
END






GO
/****** Object:  StoredProcedure [dbo].[usp_Datos_FEmpleado_Insertar]    Script Date: 18/02/2020 16:29:16 ******/
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
