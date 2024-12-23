USE [academia]
GO
/****** Object:  Table [dbo].[administrativos]    Script Date: 12/11/2024 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[administrativos](
	[cuit] [varchar](50) NOT NULL,
	[id_usuario] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comisiones]    Script Date: 12/11/2024 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comisiones](
	[id_comision] [int] IDENTITY(1,1) NOT NULL,
	[desc_comision] [varchar](50) NOT NULL,
	[id_plan] [int] NOT NULL,
	[nivel] [int] NOT NULL,
 CONSTRAINT [PK_comisiones] PRIMARY KEY CLUSTERED 
(
	[id_comision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[correlatividades]    Script Date: 12/11/2024 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[correlatividades](
	[id_materia] [int] NOT NULL,
	[id_correlativa] [int] NOT NULL,
	[para] [varchar](255) NULL,
	[estado_correlativa] [varchar](255) NULL,
 CONSTRAINT [PK_correlatividades] PRIMARY KEY CLUSTERED 
(
	[id_materia] ASC,
	[id_correlativa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cursos]    Script Date: 12/11/2024 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cursos](
	[id_curso] [int] IDENTITY(1,1) NOT NULL,
	[id_materia] [int] NOT NULL,
	[id_comision] [int] NOT NULL,
	[anio_calendario] [varchar](65) NOT NULL,
	[cupo] [int] NOT NULL,
	[fecha_inicio] [datetime] NULL,
	[fecha_fin] [datetime] NULL,
 CONSTRAINT [PK_cursos] PRIMARY KEY CLUSTERED 
(
	[id_curso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[docentes]    Script Date: 12/11/2024 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[docentes](
	[cuit] [varchar](50) NULL,
	[id_usuario] [int] NOT NULL,
	[legajo] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[docentes_cursos]    Script Date: 12/11/2024 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[docentes_cursos](
	[id_curso] [int] NOT NULL,
	[id_docente] [int] NOT NULL,
 CONSTRAINT [PK_docentes_cursos_1] PRIMARY KEY CLUSTERED 
(
	[id_docente] ASC,
	[id_curso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[especialidades]    Script Date: 12/11/2024 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[especialidades](
	[id_especialidad] [int] IDENTITY(1,1) NOT NULL,
	[desc_especialidad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_especialidades] PRIMARY KEY CLUSTERED 
(
	[id_especialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estudiantes]    Script Date: 12/11/2024 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estudiantes](
	[legajo] [varchar](50) NULL,
	[id_usuario] [int] NOT NULL,
	[id_plan] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inscripciones]    Script Date: 12/11/2024 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[inscripciones](
	[id_inscripcion] [int] IDENTITY(1,1) NOT NULL,
	[id_alumno] [int] NOT NULL,
	[id_curso] [int] NOT NULL,
	[condicion] [varchar](50) NOT NULL,
	[nota] [decimal](9, 2) NULL,
 CONSTRAINT [PK_alumnos_inscripciones] PRIMARY KEY CLUSTERED 
(
	[id_inscripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[materias]    Script Date: 12/11/2024 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[materias](
	[id_materia] [int] IDENTITY(1,1) NOT NULL,
	[desc_materia] [varchar](50) NOT NULL,
	[hs_semanales] [int] NOT NULL,
	[hs_totales] [int] NOT NULL,
	[id_plan] [int] NOT NULL,
	[nivel] [int] NOT NULL,
 CONSTRAINT [PK_materias] PRIMARY KEY CLUSTERED 
(
	[id_materia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[planes]    Script Date: 12/11/2024 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[planes](
	[id_plan] [int] IDENTITY(1,1) NOT NULL,
	[desc_plan] [varchar](50) NOT NULL,
	[id_especialidad] [int] NOT NULL,
	[anio] [int] NULL,
	[resolucion] [varchar](50) NULL,
 CONSTRAINT [PK_planes] PRIMARY KEY CLUSTERED 
(
	[id_plan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 12/11/2024 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre_usuario] [varchar](255) NOT NULL,
	[clave] [varchar](255) NULL,
	[habilitado] [bit] NULL,
	[nombre] [varchar](255) NOT NULL,
	[apellido] [varchar](255) NOT NULL,
	[email] [varchar](255) NULL,
	[telefono] [varchar](255) NULL,
	[legajo] [varchar](255) NULL,
	[id_plan] [int] NULL,
	[direccion] [varchar](255) NULL,
	[fecha_nacimiento] [datetime] NULL,
	[cuit] [varchar](255) NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[administrativos] ([cuit], [id_usuario]) VALUES (N'20267438913', 1)
INSERT [dbo].[administrativos] ([cuit], [id_usuario]) VALUES (N'20002400783', 12)
INSERT [dbo].[administrativos] ([cuit], [id_usuario]) VALUES (N'20563849043', 16)
INSERT [dbo].[administrativos] ([cuit], [id_usuario]) VALUES (N'20267438913', 35)
INSERT [dbo].[administrativos] ([cuit], [id_usuario]) VALUES (N'20464728231', 50)
INSERT [dbo].[administrativos] ([cuit], [id_usuario]) VALUES (N'65748909764', 55)
INSERT [dbo].[administrativos] ([cuit], [id_usuario]) VALUES (N'20456747523', 64)
INSERT [dbo].[administrativos] ([cuit], [id_usuario]) VALUES (N'20267438913', 79)
INSERT [dbo].[administrativos] ([cuit], [id_usuario]) VALUES (N'67596786955', 85)
INSERT [dbo].[administrativos] ([cuit], [id_usuario]) VALUES (N'45637487584', 88)
INSERT [dbo].[administrativos] ([cuit], [id_usuario]) VALUES (N'65759384343', 95)
INSERT [dbo].[administrativos] ([cuit], [id_usuario]) VALUES (N'58939849344', 98)
INSERT [dbo].[administrativos] ([cuit], [id_usuario]) VALUES (N'32543578962', 83)
GO
SET IDENTITY_INSERT [dbo].[comisiones] ON 

INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [id_plan], [nivel]) VALUES (36, N'asd', 52, 1)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [id_plan], [nivel]) VALUES (1, N'ISI-101', 12, 4)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [id_plan], [nivel]) VALUES (2, N'ISI-102', 12, 6)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [id_plan], [nivel]) VALUES (3, N'ISI-103', 12, 1)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [id_plan], [nivel]) VALUES (4, N'ISI-104', 12, 1)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [id_plan], [nivel]) VALUES (5, N'ISI-105', 12, 1)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [id_plan], [nivel]) VALUES (12, N'ISI-202', 12, 2)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [id_plan], [nivel]) VALUES (18, N'ISI-303', 12, 3)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [id_plan], [nivel]) VALUES (25, N'ISI-304', 12, 3)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [id_plan], [nivel]) VALUES (16, N'ISI-403', 12, 4)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [id_plan], [nivel]) VALUES (19, N'QUI-101', 13, 1)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [id_plan], [nivel]) VALUES (24, N'QUI-101 asdasdasd', 13, 2)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [id_plan], [nivel]) VALUES (13, N'QUI-204', 13, 2)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [id_plan], [nivel]) VALUES (11, N'QUIMICA-101', 13, 1)
SET IDENTITY_INSERT [dbo].[comisiones] OFF
GO
INSERT [dbo].[correlatividades] ([id_materia], [id_correlativa], [para], [estado_correlativa]) VALUES (3, 4, N'cursar', N'regular')
INSERT [dbo].[correlatividades] ([id_materia], [id_correlativa], [para], [estado_correlativa]) VALUES (3, 5, N'cursar', N'regular')
INSERT [dbo].[correlatividades] ([id_materia], [id_correlativa], [para], [estado_correlativa]) VALUES (3, 9, N'cursar', N'regular')
INSERT [dbo].[correlatividades] ([id_materia], [id_correlativa], [para], [estado_correlativa]) VALUES (3, 11, N'cursar', N'regular')
INSERT [dbo].[correlatividades] ([id_materia], [id_correlativa], [para], [estado_correlativa]) VALUES (3, 12, N'cursar', N'regular')
INSERT [dbo].[correlatividades] ([id_materia], [id_correlativa], [para], [estado_correlativa]) VALUES (20, 12, N'cursar', N'regular')
INSERT [dbo].[correlatividades] ([id_materia], [id_correlativa], [para], [estado_correlativa]) VALUES (23, 3, N'cursar', N'regular')
INSERT [dbo].[correlatividades] ([id_materia], [id_correlativa], [para], [estado_correlativa]) VALUES (23, 12, N'cursar', N'regular')
INSERT [dbo].[correlatividades] ([id_materia], [id_correlativa], [para], [estado_correlativa]) VALUES (27, 18, N'cursar', N'regular')
INSERT [dbo].[correlatividades] ([id_materia], [id_correlativa], [para], [estado_correlativa]) VALUES (27, 20, N'cursar', N'regular')
INSERT [dbo].[correlatividades] ([id_materia], [id_correlativa], [para], [estado_correlativa]) VALUES (29, 3, N'cursar', N'regular')
GO
SET IDENTITY_INSERT [dbo].[cursos] ON 

INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo], [fecha_inicio], [fecha_fin]) VALUES (1, 4, 1, N'2024-2025', 99, CAST(N'2024-03-18T00:00:00.000' AS DateTime), CAST(N'2024-03-16T23:59:59.000' AS DateTime))
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo], [fecha_inicio], [fecha_fin]) VALUES (3, 4, 3, N'2024-2025', 90, CAST(N'2024-03-18T00:00:00.000' AS DateTime), CAST(N'2024-03-16T23:59:59.000' AS DateTime))
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo], [fecha_inicio], [fecha_fin]) VALUES (5, 5, 1, N'2024-2025', 78, CAST(N'2024-03-18T00:00:00.000' AS DateTime), CAST(N'2024-03-16T23:59:59.000' AS DateTime))
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo], [fecha_inicio], [fecha_fin]) VALUES (9, 5, 2, N'2024-2025', 12, CAST(N'2024-03-18T00:00:00.000' AS DateTime), CAST(N'2024-03-16T23:59:59.000' AS DateTime))
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo], [fecha_inicio], [fecha_fin]) VALUES (15, 32, 16, N'2024-2025', 25, NULL, NULL)
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo], [fecha_inicio], [fecha_fin]) VALUES (16, 30, 16, N'2024-2025', 42, NULL, NULL)
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo], [fecha_inicio], [fecha_fin]) VALUES (26, 23, 18, N'2024-2025', 56, NULL, NULL)
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo], [fecha_inicio], [fecha_fin]) VALUES (27, 26, 18, N'2024-2025', 46, NULL, NULL)
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo], [fecha_inicio], [fecha_fin]) VALUES (28, 9, 4, N'2024-2025', 45, NULL, NULL)
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo], [fecha_inicio], [fecha_fin]) VALUES (30, 103, 18, N'2025-2026', 25, NULL, NULL)
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo], [fecha_inicio], [fecha_fin]) VALUES (34, 20, 12, N'2024-2025', 62, NULL, NULL)
SET IDENTITY_INSERT [dbo].[cursos] OFF
GO
SET IDENTITY_INSERT [dbo].[docentes] ON 

INSERT [dbo].[docentes] ([cuit], [id_usuario], [legajo]) VALUES (N'20002400783', 10, 1)
INSERT [dbo].[docentes] ([cuit], [id_usuario], [legajo]) VALUES (N'82738723223', 34, 2)
INSERT [dbo].[docentes] ([cuit], [id_usuario], [legajo]) VALUES (N'20267438913', 48, 3)
INSERT [dbo].[docentes] ([cuit], [id_usuario], [legajo]) VALUES (N'28763452312', 52, 4)
INSERT [dbo].[docentes] ([cuit], [id_usuario], [legajo]) VALUES (N'34567895463', 53, 5)
INSERT [dbo].[docentes] ([cuit], [id_usuario], [legajo]) VALUES (N'20256473453', 57, 6)
INSERT [dbo].[docentes] ([cuit], [id_usuario], [legajo]) VALUES (N'20253457849', 63, 7)
INSERT [dbo].[docentes] ([cuit], [id_usuario], [legajo]) VALUES (N'12354678901', 70, 8)
INSERT [dbo].[docentes] ([cuit], [id_usuario], [legajo]) VALUES (N'65748594845', 93, 11)
INSERT [dbo].[docentes] ([cuit], [id_usuario], [legajo]) VALUES (N'56748945745', 96, 12)
INSERT [dbo].[docentes] ([cuit], [id_usuario], [legajo]) VALUES (N'1174567653', 82, 10)
SET IDENTITY_INSERT [dbo].[docentes] OFF
GO
INSERT [dbo].[docentes_cursos] ([id_curso], [id_docente]) VALUES (28, 10)
INSERT [dbo].[docentes_cursos] ([id_curso], [id_docente]) VALUES (30, 34)
INSERT [dbo].[docentes_cursos] ([id_curso], [id_docente]) VALUES (16, 48)
INSERT [dbo].[docentes_cursos] ([id_curso], [id_docente]) VALUES (1, 52)
INSERT [dbo].[docentes_cursos] ([id_curso], [id_docente]) VALUES (15, 52)
INSERT [dbo].[docentes_cursos] ([id_curso], [id_docente]) VALUES (30, 57)
INSERT [dbo].[docentes_cursos] ([id_curso], [id_docente]) VALUES (16, 63)
INSERT [dbo].[docentes_cursos] ([id_curso], [id_docente]) VALUES (3, 70)
INSERT [dbo].[docentes_cursos] ([id_curso], [id_docente]) VALUES (16, 82)
GO
SET IDENTITY_INSERT [dbo].[especialidades] ON 

INSERT [dbo].[especialidades] ([id_especialidad], [desc_especialidad]) VALUES (73, N'descripcion modificadaa')
INSERT [dbo].[especialidades] ([id_especialidad], [desc_especialidad]) VALUES (7, N'INDUSTRIAL')
INSERT [dbo].[especialidades] ([id_especialidad], [desc_especialidad]) VALUES (9, N'ING AMBIENTAL')
INSERT [dbo].[especialidades] ([id_especialidad], [desc_especialidad]) VALUES (4, N'ING QUÍMICA')
INSERT [dbo].[especialidades] ([id_especialidad], [desc_especialidad]) VALUES (1, N'INGENIERÍA EN SISTEMAS DE INFORMACIÓN')
INSERT [dbo].[especialidades] ([id_especialidad], [desc_especialidad]) VALUES (71, N'NUEVA ESPECIALIDAD')
INSERT [dbo].[especialidades] ([id_especialidad], [desc_especialidad]) VALUES (101, N'PSICOLOGIA')
SET IDENTITY_INSERT [dbo].[especialidades] OFF
GO
INSERT [dbo].[estudiantes] ([legajo], [id_usuario], [id_plan]) VALUES (N'123123123', 2, 13)
INSERT [dbo].[estudiantes] ([legajo], [id_usuario], [id_plan]) VALUES (N'123123123', 4, 14)
INSERT [dbo].[estudiantes] ([legajo], [id_usuario], [id_plan]) VALUES (N'123123123', 7, 17)
INSERT [dbo].[estudiantes] ([legajo], [id_usuario], [id_plan]) VALUES (N'123123123', 9, 12)
INSERT [dbo].[estudiantes] ([legajo], [id_usuario], [id_plan]) VALUES (N'123123123', 11, 12)
INSERT [dbo].[estudiantes] ([legajo], [id_usuario], [id_plan]) VALUES (N'51338', 13, 12)
INSERT [dbo].[estudiantes] ([legajo], [id_usuario], [id_plan]) VALUES (N'123123123', 15, 12)
INSERT [dbo].[estudiantes] ([legajo], [id_usuario], [id_plan]) VALUES (N'1234456', 56, 12)
INSERT [dbo].[estudiantes] ([legajo], [id_usuario], [id_plan]) VALUES (N'12343', 99, 12)
INSERT [dbo].[estudiantes] ([legajo], [id_usuario], [id_plan]) VALUES (N'1231283123', 78, 13)
INSERT [dbo].[estudiantes] ([legajo], [id_usuario], [id_plan]) VALUES (N'98323', 89, 12)
INSERT [dbo].[estudiantes] ([legajo], [id_usuario], [id_plan]) VALUES (N'09782', 97, 12)
INSERT [dbo].[estudiantes] ([legajo], [id_usuario], [id_plan]) VALUES (N'34536', 84, 13)
GO
SET IDENTITY_INSERT [dbo].[inscripciones] ON 

INSERT [dbo].[inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [condicion], [nota]) VALUES (5, 9, 1, N'aprobado', CAST(6.20 AS Decimal(9, 2)))
INSERT [dbo].[inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [condicion], [nota]) VALUES (6, 13, 5, N'aprobado', CAST(6.00 AS Decimal(9, 2)))
INSERT [dbo].[inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [condicion], [nota]) VALUES (7, 15, 1, N'aprobado', CAST(10.00 AS Decimal(9, 2)))
INSERT [dbo].[inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [condicion], [nota]) VALUES (9, 13, 26, N'aprobado', CAST(9.00 AS Decimal(9, 2)))
INSERT [dbo].[inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [condicion], [nota]) VALUES (10, 13, 1, N'inscripto', NULL)
INSERT [dbo].[inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [condicion], [nota]) VALUES (11, 13, 30, N'aprobado', CAST(10.00 AS Decimal(9, 2)))
INSERT [dbo].[inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [condicion], [nota]) VALUES (15, 13, 16, N'inscripto', NULL)
INSERT [dbo].[inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [condicion], [nota]) VALUES (22, 13, 34, N'inscripto', NULL)
INSERT [dbo].[inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [condicion], [nota]) VALUES (23, 13, 27, N'inscripto', NULL)
INSERT [dbo].[inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [condicion], [nota]) VALUES (25, 99, 1, N'aprobado', CAST(10.00 AS Decimal(9, 2)))
INSERT [dbo].[inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [condicion], [nota]) VALUES (26, 99, 5, N'inscripto', NULL)
SET IDENTITY_INSERT [dbo].[inscripciones] OFF
GO
SET IDENTITY_INSERT [dbo].[materias] ON 

INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (3, N'Sintaxis y Semantica de Los Lenguajes', 4, 4, 12, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (4, N'Algoritmos y Estructuras de Datos', 6, 6, 12, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (5, N'Logicas y Estructuras Discretas', 3, 3, 12, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (7, N'Análisis Matemático I', 5, 5, 12, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (8, N'Álgebra y Geometría Analítica', 5, 5, 12, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (9, N'Física I', 5, 5, 12, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (10, N'Inglés I', 2, 2, 12, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (11, N'Arquitectura de Computadoras', 4, 4, 12, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (12, N'Sistemas y Procesos de Negocio', 3, 3, 12, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (14, N'Análisis Matemático II', 5, 5, 12, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (15, N'Física II', 5, 5, 12, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (16, N'Ingeniería y Sociedad', 2, 2, 12, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (17, N'Inglés II', 2, 2, 12, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (18, N'Paradigmas de Programación', 4, 4, 12, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (19, N'Sistemas Operativos', 4, 4, 12, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (20, N'Análisis de Sistemas de Información (Int.)', 6, 6, 12, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (21, N'Probabilidad y Estadística', 3, 3, 12, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (22, N'Economía', 3, 3, 12, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (23, N'Base de Datos', 4, 4, 12, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (24, N'Desarrollo de Software', 4, 4, 12, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (25, N'Comunicación de Datos', 4, 4, 12, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (26, N'Análisis Numérico', 3, 3, 12, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (27, N'Diseño de Sistemas de Información (Int.)', 4, 4, 12, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (28, N'Legislación', 2, 2, 12, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (29, N'Ingeniería y Calidad de Software', 3, 3, 12, 4)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (30, N'Redes de Datos', 4, 4, 12, 4)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (31, N'Investigación Operativa', 4, 4, 12, 4)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (32, N'Simulación', 3, 3, 12, 4)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (33, N'Tecnologías para la Automatización', 3, 3, 12, 4)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (34, N'Administración de Sistemas de Información (Int.)', 6, 6, 12, 4)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (35, N'Inteligencia Artificial', 3, 3, 12, 5)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (36, N'Ciencia de Datos', 3, 3, 12, 5)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (37, N'Sistemas de Gestión', 4, 4, 12, 5)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (38, N'Gestión Gerencial', 3, 3, 12, 5)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (39, N'Seguridad en los Sistemas de Información', 3, 3, 12, 5)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (40, N'Proyecto Final', 6, 6, 12, 5)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (41, N'Análisis Matemático I', 5, 5, 13, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (42, N'Química General', 5, 5, 13, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (43, N'Álgebra y Geometría Analítica', 5, 5, 13, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (44, N'Física I', 5, 5, 13, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (45, N'Ingeniería y Sociedad', 2, 2, 13, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (46, N'Ingeniería Mecánica I (int.)', 2, 2, 13, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (47, N'Sistemas de Representación', 3, 3, 13, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (48, N'Fundamentos de Informática', 2, 2, 13, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (49, N'Materiales No Metálicos', 3, 3, 13, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (50, N'Estabilidad I', 4, 4, 13, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (51, N'Materiales Metálicos', 5, 5, 13, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (52, N'Análisis Matemático II', 5, 5, 13, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (53, N'Física II', 5, 5, 13, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (54, N'Ingeniería Mecánica II (int.)', 2, 2, 13, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (55, N'Inglés I', 2, 2, 13, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (56, N'Termodinámica', 5, 5, 13, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (57, N'Mecánica Racional', 5, 5, 13, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (58, N'Estabilidad II', 4, 4, 13, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (59, N'Mediciones y Ensayos', 4, 4, 13, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (60, N'Diseño Mecánico', 3, 3, 13, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (61, N'Cálculo Avanzado', 3, 3, 13, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (62, N'Ingeniería Mecánica III (int.)', 2, 2, 13, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (63, N'Probabilidad y Estadística', 3, 3, 13, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (64, N'Inglés II', 2, 2, 13, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (65, N'Economía', 3, 3, 13, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (66, N'Ingeniería Ambiental y Seguridad Industrial', 3, 3, 13, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (67, N'Elementos de Máquinas (int.)', 5, 5, 13, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (68, N'Tecnología del Calor', 3, 3, 13, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (69, N'Metrología e Ingeniería de la Calidad', 4, 4, 13, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (70, N'Mecánica de los Fluidos', 4, 4, 13, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (71, N'Electrotecnia y Máquinas Eléctricas', 5, 5, 13, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (72, N'Electrónica y Sistemas de Control', 4, 4, 13, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (73, N'Estabilidad III', 3, 3, 13, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (74, N'Tecnología de la Fabricación', 5, 5, 13, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (75, N'Máquinas Alternativas y Turbomáquinas', 4, 4, 13, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (76, N'Instalaciones Industriales', 5, 5, 13, 4)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (77, N'Organización Industrial', 3, 3, 13, 4)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (78, N'Legislación', 2, 2, 13, 4)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (79, N'Mantenimiento', 2, 2, 13, 4)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (80, N'Proyecto Final (int.)', 5, 5, 13, 5)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (81, N'Metalografía y Tratamientos Térmicos', 4, 4, 13, 5)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (82, N'Máquinas de Elevación y Transporte', 3, 3, 13, 5)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (83, N'Materiales de Ingeniería', 4, 4, 13, 5)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (84, N'Sistemas de Control en Instalaciones Térmicas', 3, 3, 13, 5)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (85, N'Tecnología del Frío', 4, 4, 13, 5)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (86, N'Transmisión del Calor', 3, 3, 13, 5)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (87, N'Diseño de Instalaciones Térmicas', 2, 2, 13, 5)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (88, N'Maquinaria Agrícola', 4, 4, 13, 5)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (103, N'punto net', 12, 12, 12, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (126, N'otra mat nueva2 actualizada', 5, 5, 13, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (127, N'gestion de datos', 24, 24, 17, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan], [nivel]) VALUES (129, N'nombreEE', 12, 12, 52, 1)
SET IDENTITY_INSERT [dbo].[materias] OFF
GO
SET IDENTITY_INSERT [dbo].[planes] ON 

INSERT [dbo].[planes] ([id_plan], [desc_plan], [id_especialidad], [anio], [resolucion]) VALUES (12, N'ISI-23', 1, 2023, N'702023')
INSERT [dbo].[planes] ([id_plan], [desc_plan], [id_especialidad], [anio], [resolucion]) VALUES (13, N'QUIMICA-2024', 4, 2024, N'60202')
INSERT [dbo].[planes] ([id_plan], [desc_plan], [id_especialidad], [anio], [resolucion]) VALUES (14, N'AMBIENTAL', 71, 2025, N'res-amb-20')
INSERT [dbo].[planes] ([id_plan], [desc_plan], [id_especialidad], [anio], [resolucion]) VALUES (17, N'ISI-2008', 1, 2008, N'RESOLUCION 19875')
INSERT [dbo].[planes] ([id_plan], [desc_plan], [id_especialidad], [anio], [resolucion]) VALUES (52, N'NUEVO PLAN', 1, 2025, N'702023')
INSERT [dbo].[planes] ([id_plan], [desc_plan], [id_especialidad], [anio], [resolucion]) VALUES (53, N'industrial_plan_estudios', 9, 2035, N'')
INSERT [dbo].[planes] ([id_plan], [desc_plan], [id_especialidad], [anio], [resolucion]) VALUES (54, N'asdasd', 7, 123, N'asd')
SET IDENTITY_INSERT [dbo].[planes] OFF
GO
SET IDENTITY_INSERT [dbo].[usuarios] ON 

INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (1, N'fabiadmin', N'B565CB079ABB7C7B38E3D9D52DEF7437405105A631716B3210A4927BCE00D48D', 0, N'FabianWaldman', N'alumnado', N'fabian@alumnado.frro.com', N'3417474546', NULL, NULL, N'Moreno 17653', CAST(N'1976-08-09T14:43:20.807' AS DateTime), N'20267438913')
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (2, N'mrodri', N'4E0C5B9336394FE1D43917BFE62DFC9A791C3560A5F3BFBC8FC85E80A3C1361B', 0, N'Mariano', N'Rodriguez', N'rodriguezmariano@gmail.com', N'987654321', N'123123123', 13, N'Part Avenue 0', CAST(N'2024-08-09T14:43:20.807' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (4, N'juanchit', N'DC790FE798C58D67D0E73CEEDE472E4547695D7FAAB8DC48AAA2DAD833E6D750', 0, N'Martin', N'Talarga', N'juanta@yahoo.com', N'11113333', N'123123123', 14, N'Dorrego 108 bis', CAST(N'2004-09-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (7, N'mbpperez', N'3BC0316436F3368B1A9D5582D0009D6EBB2C37369D9089D748118CB15B67972A', 0, N'Mariano', N'Perez', N'marianbp@hotmail.com', N'44869856859685', N'123123123', 17, N'Palestina 4500', CAST(N'2003-08-09T14:43:20.807' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (9, N'astringa', N'astringaA1', 0, N'Agustin', N'Stringa', N'agustinstringa@outlook.com', N'3467980765', N'123123123', 12, N'San martin 1763', CAST(N'2024-08-09T14:43:20.807' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (10, N'cubatas', N'4C45C836B5747C57833978A03CCB429ACE8105B64424E6E314F905FEEB786B09', 0, N'Miguel Cubatas', N'Oliveros', N'miguelolivero@gmail.com', N'3467546689', NULL, NULL, N'Sarmiento 1169', CAST(N'1954-08-09T14:43:20.807' AS DateTime), N'20002400783')
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (11, N'xArron', N'FF9331140E024D019F9BEEC66B5385A961006A4D6218AD169B99DF2C0C8D6F20', 0, N'Aaron', N'De Bernardo', N'xaaron@gmail.com', N'3467542748', N'123123123', 12, N'corrientes y cordoba', CAST(N'2002-07-29T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (12, N'bedel1', N'C86FF130FE0F6667020363965952D3F46050C1A2C13BC1CAE6BD6D67CB4C3338', 0, N'Fabian', N'Rodríguez', N'bedel1@gmail.com', N'3415647489', NULL, 0, N'1ero de mayo y cordoba', CAST(N'1982-08-03T13:35:31.677' AS DateTime), N'20002400783')
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (13, N'stri', N'83701221E23873688094872E3464D6172AE557FB823C84AF704F2FF39AFA2B17', 0, N'Agustín', N'Stringa', N'stringaagustin@gmail.com', N'3467415522', N'51338', 12, N'Pte roca 1675', CAST(N'2003-02-24T15:10:47.137' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (15, N'elisito', N'08FD50833709EEA0A0E292A26D625A469927066E9A366468253964C27FA42334', 0, N'Elías Tomás', N'Danteo', N'elisito@danteo.com.ar', N'341265748', N'123123123', 12, N'Presidente Roca 600', CAST(N'2002-10-16T15:17:34.407' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (16, N'bedel', N'A597931ECB8EEE7C638346C300C9B7F9FDBC814C7BCF776A3C872A5603BB922A', 0, N'Bedel', N'Bedel', N'bedel@correo.com', N'3416473672', NULL, NULL, N'Zeballos 1341', CAST(N'1965-05-06T10:53:50.540' AS DateTime), N'20563849043')
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (34, N'aadmin', N'FC3F89CBADFB2F3CAF610D99BB9DC92F107BDFF59EF770D2BBCDE88E1A80A9B3', 0, N'aadmin', N'aadmin', N'aadminaadmin@cor.com', N'3462349445', NULL, NULL, N'Sgo Estero 2183', CAST(N'1996-08-19T22:18:39.803' AS DateTime), N'82738723223')
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (35, N'axel', N'0E43A4C6BEF048DA5F58AE417755101C92F45CDD6B1CA9D2BE6015D3882A1338', 0, N'AXELITO', N'Yustyovich', N'axel@alumnadoupdated.com', N'341547586', NULL, NULL, N'ALemania 1944', CAST(N'1981-08-09T14:43:20.807' AS DateTime), N'20267438913')
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (48, N'axelteacher', N'FCBC297857A9E973F3C2E1BB9E5383457BB87E16A31D585894DDEC346B7EDFB6', 0, N'axelteacher', N'axel', N'axelteacher@alumnado.com', N'341547586', NULL, NULL, N'bs as 1947', CAST(N'2024-08-09T14:43:20.807' AS DateTime), N'20267438913')
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (50, N'admin', N'8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918', 0, N'SUPERADMIN', N'admin', N'admin@admin.com', N'34153624728', NULL, NULL, N'España 1900', CAST(N'1987-09-09T15:37:17.387' AS DateTime), N'20464728231')
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (52, N'piro', N'7135F2009D53C58452D53610DB6B072B8451AA81C96A8EBF013290615061EF64', 0, N'Mariano', N'Pirovano', N'piroabrazo@gmail.com', N'34154742832', NULL, NULL, N'Recoleta 1635', CAST(N'2005-09-09T21:44:27.747' AS DateTime), N'28763452312')
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (53, N'claudia', N'35F85825B9016FCC7818ACA22298DC88A92BA6E4F029366FF8ACBB3F823152D4', 0, N'Claudia', N'Reynares', N'claurey@bd.com', N'341675748374', NULL, NULL, N'centenario 1320', CAST(N'1967-09-23T12:27:33.633' AS DateTime), N'34567895463')
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (55, N'nuevoadmin', N'F61FD1F9E356C0CADE5AAAF7863102470F64D877E157958FCFC407A5CA2C212B', 0, N'nuevoadmin', N'nuevoadmin', N'nuevoadmin@admin.com', N'3413474387', NULL, NULL, N'santa fe 1989', CAST(N'1982-09-23T12:34:43.390' AS DateTime), N'65748909764')
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (56, N'javier', N'ECD7D11ED707FABB81B6800B2D677CEA5B33FB1FA6C219D1E4FF488537B2D4B4', NULL, N'JAVIER', N'GAGANDRI', N'javiergagandri@lhda.com', N'911345684574', N'1234456', 12, N'Ramos 4352', CAST(N'1990-09-23T23:40:42.767' AS DateTime), N'')
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (57, N'eporta', N'274F993676CF6D97CD8B73BAE5CB95966182B062919C2E68BE724310A13730B4', NULL, N'Ezequiel', N'Porta', N'eporta@utn.com', N'34155674847', NULL, NULL, N'Maria Susana 123', CAST(N'1978-09-27T10:00:50.753' AS DateTime), N'20256473453')
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (63, N'srocco', N'FAA95EEA6A604044118D5E60CDF5DF8296FCEB33C705FAC86568283E621AF128', NULL, N'Sebastián', N'Rocco', N'srocco@utn.com', N'3417376343', NULL, NULL, N'Roca 1543', CAST(N'1979-09-30T18:26:34.367' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (64, N'colorado', N'B82E723B461323374C1EEC211E066DC7A1C2130FE36C906E4BEC5CC45109C248', NULL, N'colorado', N'colorado', N'colorado@hot.com', N'3415464759', NULL, NULL, N'Suipache 2400', CAST(N'1983-02-12T18:29:50.420' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (70, N'tabaco', N'33BB8A33AE422F4973F5218823C551CBAA73E3638618D32AA5553B8BAB3A9708', NULL, N'Ricardo', N'Tabacman', N'tabaco@jw.com', N'3467546689', NULL, NULL, N'Zavalla 4364', CAST(N'1965-08-09T14:43:20.807' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (78, N'ricardito', N'E6AF24BB3A6E5FB809E0F08816CD177ED4AB8FD56AE2A902ADDA623F65187F10', NULL, N'Rich Alumno', N'Tabenman', N'rich1@jw.com', N'333444111', NULL, NULL, N'Zavalla 43648', CAST(N'1981-08-09T14:43:20.807' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (79, N'mariadmin', N'B565CB079ABB7C7B38E3D9D52DEF7437405105A631716B3210A4927BCE00D48D', NULL, N'Maria', N'alumnado', N'mari@alumnado.frro.com', N'3417474546', NULL, NULL, N'Moreno 17653', CAST(N'1976-08-09T14:43:20.807' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (82, N'mecasado', N'B0759A88E148A440C740338FA77B86D77CA9A45A23B560029DB5C79036EAC0D8', NULL, N'Adrian', N'Meca', N'mecasado@db.com', N'3467546689', NULL, NULL, N'Arroyo Seco 4364', CAST(N'2024-08-09T14:43:20.807' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (83, N'maxi', N'AB3691D8E45C1F50684B2762FC640AFBE61266BF49C34E0A5319044DA23AF364', NULL, N'max', N'max', N'maxsteel@gmail.com', N'34156446364', NULL, NULL, N'Medrano 1876', CAST(N'1986-10-02T12:44:22.547' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (84, N'valentino', N'3FEC2131852B5DB5B78E5FBBFE7F0230959FAECFDBB821B511171DDF740630BB', NULL, N'Valentino', N'Marini', N'valentinom@hotmail.com', N'34154683748', NULL, NULL, N'Montevideo 2243', CAST(N'1996-10-02T12:45:41.157' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (85, N'tipito', N'64001074DA6614C67AA85327581226A90EE12BAC6FA016581E189C93C290ECE1', NULL, N'tipito', N'galvez', N'tipitoenojado@gmail.com', N'3437865875', NULL, NULL, N'Santa fe 1982', CAST(N'1986-10-29T22:19:26.167' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (88, N'gordopablo', N'751200A198A162A88B55579CC8CC6335DF78751AE7D42B16F50AAEFBDAF1DBF9', NULL, N'gordopablo', N'gordopablo', N'gordopablo@gordopablo.com', N'234234234', NULL, NULL, N'Palermo 1264', CAST(N'1985-10-30T22:30:05.697' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (89, N'matrix', N'6E00CD562CC2D88E238DFB81D9439DE7EC843EE9D0C9879D549CB1436786F975', NULL, N'matrix', N'matrix', N'matrix@matrix.com', N'75673445', NULL, NULL, N'Belgrano 1762', CAST(N'1980-10-29T22:30:52.540' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (93, N'vpezzeti', N'B796B35248810B61649A11305D903971C41E66A34B02E2B3F12D739405066B66', NULL, N'vpezzeti', N'vpezzeti', N'vpezzeti@gmail.com', N'334513242', NULL, NULL, N'Arroyo 5643', CAST(N'1964-07-23T22:39:09.347' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (95, N'coloradoo', N'B82E723B461323374C1EEC211E066DC7A1C2130FE36C906E4BEC5CC45109C248', NULL, N'colorado', N'colorado', N'colorado@yahoo.com', N'34534534', NULL, NULL, N'san martin 1762', CAST(N'1988-10-29T22:43:57.817' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (96, N'mugarte', N'35E5B21E47FB31EE2D9925E45F8726B8D949E6C708869C8DC5F78FE783FE5AAD', NULL, N'mariel', N'ugarte', N'mugarte@hotmail.com', N'4512342454', NULL, NULL, N'ayacucho 5647', CAST(N'1984-10-29T22:45:38.243' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (97, N'html', N'E5E239560BC125A20FF2AC1FEA50915BC198DD4F5B5256EC447A8A71E00132B3', NULL, N'html', N'html', N'html@html.com', N'6749807655', NULL, NULL, N'san nicolas 1221', CAST(N'2002-10-29T22:46:30.130' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (98, N'superadmin', N'186CF774C97B60A1C106EF718D10970A6A06E06BEF89553D9AE65D938A886EAE', NULL, N'adminsuper', N'adminsuper', N'superadmin@gmail.com', N'345938453', NULL, NULL, N'Mendoza 1762', CAST(N'1978-10-30T14:25:33.847' AS DateTime), NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [telefono], [legajo], [id_plan], [direccion], [fecha_nacimiento], [cuit]) VALUES (99, N'taylor', N'8E924025A26C584AD4AC6365116E09B852AE6B7016DA4C0851E269348D93C228', NULL, N'taylor', N'hawkings', N'tayaty@hotmail.com', N'3415548374', NULL, NULL, N'Ocean Avenue 1523', CAST(N'2004-11-10T20:55:11.380' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[usuarios] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_comision]    Script Date: 12/11/2024 09:37:38 ******/
ALTER TABLE [dbo].[comisiones] ADD  CONSTRAINT [IX_comision] UNIQUE NONCLUSTERED 
(
	[desc_comision] ASC,
	[id_plan] ASC,
	[nivel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UN_desc_especialidades]    Script Date: 12/11/2024 09:37:38 ******/
ALTER TABLE [dbo].[especialidades] ADD  CONSTRAINT [UN_desc_especialidades] UNIQUE NONCLUSTERED 
(
	[desc_especialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UN_materias_desc]    Script Date: 12/11/2024 09:37:38 ******/
ALTER TABLE [dbo].[materias] ADD  CONSTRAINT [UN_materias_desc] UNIQUE NONCLUSTERED 
(
	[desc_materia] ASC,
	[id_plan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_planes]    Script Date: 12/11/2024 09:37:38 ******/
ALTER TABLE [dbo].[planes] ADD  CONSTRAINT [IX_planes] UNIQUE NONCLUSTERED 
(
	[desc_plan] ASC,
	[id_especialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UN_usuarios_email]    Script Date: 12/11/2024 09:37:38 ******/
ALTER TABLE [dbo].[usuarios] ADD  CONSTRAINT [UN_usuarios_email] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UN_usuarios_username]    Script Date: 12/11/2024 09:37:38 ******/
ALTER TABLE [dbo].[usuarios] ADD  CONSTRAINT [UN_usuarios_username] UNIQUE NONCLUSTERED 
(
	[nombre_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[administrativos]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_administrativos_id_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[administrativos] CHECK CONSTRAINT [FK_usuarios_administrativos_id_usuario]
GO
ALTER TABLE [dbo].[comisiones]  WITH CHECK ADD  CONSTRAINT [FK_comisiones_planes] FOREIGN KEY([id_plan])
REFERENCES [dbo].[planes] ([id_plan])
GO
ALTER TABLE [dbo].[comisiones] CHECK CONSTRAINT [FK_comisiones_planes]
GO
ALTER TABLE [dbo].[cursos]  WITH CHECK ADD  CONSTRAINT [FK_cursos_comisiones] FOREIGN KEY([id_comision])
REFERENCES [dbo].[comisiones] ([id_comision])
GO
ALTER TABLE [dbo].[cursos] CHECK CONSTRAINT [FK_cursos_comisiones]
GO
ALTER TABLE [dbo].[cursos]  WITH CHECK ADD  CONSTRAINT [FK_cursos_materias] FOREIGN KEY([id_materia])
REFERENCES [dbo].[materias] ([id_materia])
GO
ALTER TABLE [dbo].[cursos] CHECK CONSTRAINT [FK_cursos_materias]
GO
ALTER TABLE [dbo].[docentes]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_docentes_id_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[docentes] CHECK CONSTRAINT [FK_usuarios_docentes_id_usuario]
GO
ALTER TABLE [dbo].[docentes_cursos]  WITH CHECK ADD  CONSTRAINT [FK_docentes_cursos_cursos] FOREIGN KEY([id_curso])
REFERENCES [dbo].[cursos] ([id_curso])
GO
ALTER TABLE [dbo].[docentes_cursos] CHECK CONSTRAINT [FK_docentes_cursos_cursos]
GO
ALTER TABLE [dbo].[docentes_cursos]  WITH CHECK ADD  CONSTRAINT [FK_docentes_cursos_docentes] FOREIGN KEY([id_docente])
REFERENCES [dbo].[docentes] ([id_usuario])
GO
ALTER TABLE [dbo].[docentes_cursos] CHECK CONSTRAINT [FK_docentes_cursos_docentes]
GO
ALTER TABLE [dbo].[estudiantes]  WITH CHECK ADD  CONSTRAINT [FK_estudiantes_planes_id_plan] FOREIGN KEY([id_plan])
REFERENCES [dbo].[planes] ([id_plan])
GO
ALTER TABLE [dbo].[estudiantes] CHECK CONSTRAINT [FK_estudiantes_planes_id_plan]
GO
ALTER TABLE [dbo].[estudiantes]  WITH CHECK ADD  CONSTRAINT [FK_estudiantes_usuarios_id_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[estudiantes] CHECK CONSTRAINT [FK_estudiantes_usuarios_id_usuario]
GO
ALTER TABLE [dbo].[inscripciones]  WITH CHECK ADD  CONSTRAINT [FK_inscripciones_cursos_id_curso] FOREIGN KEY([id_curso])
REFERENCES [dbo].[cursos] ([id_curso])
GO
ALTER TABLE [dbo].[inscripciones] CHECK CONSTRAINT [FK_inscripciones_cursos_id_curso]
GO
ALTER TABLE [dbo].[inscripciones]  WITH CHECK ADD  CONSTRAINT [FK_inscripciones_estudiantes_id_usuario] FOREIGN KEY([id_alumno])
REFERENCES [dbo].[estudiantes] ([id_usuario])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[inscripciones] CHECK CONSTRAINT [FK_inscripciones_estudiantes_id_usuario]
GO
ALTER TABLE [dbo].[materias]  WITH CHECK ADD  CONSTRAINT [FK_materias_planes] FOREIGN KEY([id_plan])
REFERENCES [dbo].[planes] ([id_plan])
GO
ALTER TABLE [dbo].[materias] CHECK CONSTRAINT [FK_materias_planes]
GO
ALTER TABLE [dbo].[planes]  WITH CHECK ADD  CONSTRAINT [FK_especialidades_planes_id_plan] FOREIGN KEY([id_especialidad])
REFERENCES [dbo].[especialidades] ([id_especialidad])
GO
ALTER TABLE [dbo].[planes] CHECK CONSTRAINT [FK_especialidades_planes_id_plan]
GO
/****** Object:  StoredProcedure [dbo].[GetAvailableCourses]    Script Date: 12/11/2024 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetAvailableCourses] @id_alumno int AS 
BEGIN

/*
validar que se cumplan las correlatividades
*/

	DECLARE @id_plan int = (select id_plan from estudiantes where id_usuario= @id_alumno);
		--validar además que haya cupos;
	create table #inscripcionesCursos (
	   inscripciones INT,
    id_curso INT
	)

	INSERT INTO #inscripcionesCursos (inscripciones,id_curso)
	select count(id_inscripcion) as inscripciones, cursos.id_curso FROM cursos
	LEFT JOIN inscripciones  ON inscripciones.id_curso = cursos.id_curso
	GROUP BY cursos.id_curso;


		--validar que el anio calendario del curso sea el ultimo, sea igual al actual
	SELECT distinct cursos.* FROM cursos 
	INNER JOIN materias ON (cursos.id_materia = materias.id_materia)
	INNER JOIN #inscripcionesCursos ON (#inscripcionesCursos.id_curso = cursos.id_curso)
	--LEFT JOIN correlatividades ON correlatividades.id_correlativa = materias.id_materia
	WHERE materias.id_plan = @id_plan 
	AND (cursos.cupo - #inscripcionesCursos.inscripciones) >= 1
	AND not exists (
		select 1 FROM inscripciones INNER JOIN 
		cursos ON (inscripciones.id_curso = cursos.id_curso AND inscripciones.id_alumno = @id_alumno)
		WHERE (cursos.id_materia = materias.id_materia)
	)
	;

	drop table #inscripcionesCursos;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAvailableCoursesWithCorrelatives]    Script Date: 12/11/2024 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAvailableCoursesWithCorrelatives] @id_alumno int AS 
BEGIN

/*
validar que se cumplan las correlatividades
*/

	DECLARE @id_plan int = (select id_plan from usuarios where id_usuario= @id_alumno);
		--validar además que haya cupos;
	create table #inscripcionesCursos (
	   inscripciones INT,
    id_curso INT
	)

	INSERT INTO #inscripcionesCursos (inscripciones,id_curso)
	select count(id_inscripcion) as inscripciones, cursos.id_curso FROM cursos
	LEFT JOIN alumnos_inscripciones  ON alumnos_inscripciones.id_curso = cursos.id_curso
	GROUP BY cursos.id_curso;


		--validar que el anio calendario del curso sea el ultimo, sea igual al actual
	SELECT cursos.* FROM cursos 
	INNER JOIN materias ON (cursos.id_materia = materias.id_materia)
	INNER JOIN #inscripcionesCursos ON (#inscripcionesCursos.id_curso = cursos.id_curso)
	LEFT JOIN correlatividades ON correlatividades.id_correlativa = materias.id_materia
	WHERE materias.id_plan = @id_plan AND cursos.anio_calendario='2024-2025' 
	AND (cursos.cupo - #inscripcionesCursos.inscripciones) >= 1
	AND not exists (
		select 1 FROM alumnos_inscripciones INNER JOIN 
		cursos ON (alumnos_inscripciones.id_curso = cursos.id_curso AND alumnos_inscripciones.id_alumno = @id_alumno)
		WHERE (cursos.id_materia = materias.id_materia)
	)
	AND not exists (
		select 1 from alumnos_inscripciones INNER JOIN
		cursos as cursosSub ON cursos.id_curso = alumnos_inscripciones.id_curso 
		WHERE 
		cursosSub.id_materia = materias.id_materia
		AND 
		NOT (
			(correlatividades.estado_correlativa='regular' AND (alumnos_inscripciones.condicion = 'regular' OR alumnos_inscripciones.condicion = 'aprobado')) 
			OR 
			(correlatividades.estado_correlativa='aprobado' AND correlatividades.estado_correlativa='aprobado')
			)
		AND alumnos_inscripciones.id_alumno = @id_alumno
	)
	;

	drop table #inscripcionesCursos;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetCupos]    Script Date: 12/11/2024 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetCupos] 
@idCurso int,
@cupos int OUTPUT
AS
BEGIN
	DECLARE @inscriptos INT = (select COUNT(*) from alumnos_inscripciones where id_curso = @idCurso);
	select @cupos = ( select (cupo-@inscriptos) as cupos_restantes from cursos where id_curso = @idCurso);
END
;
 
GO
/****** Object:  StoredProcedure [dbo].[getEstadoAcademico]    Script Date: 12/11/2024 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getEstadoAcademico] @id_estudiante int AS 
	select mat.desc_materia, ins.condicion, ins.nota, cur.anio_calendario, mat.nivel as nivel_materia from inscripciones ins 
	inner join cursos cur on cur.id_curso = ins.id_curso
	inner join materias mat on mat.id_materia = cur.id_materia
	inner join comisiones com on com.id_comision = cur.id_comision
	where id_alumno = @id_estudiante and nota is not null
	order by mat.nivel
GO
/****** Object:  StoredProcedure [dbo].[GetPossibleChildrenCorrelatives]    Script Date: 12/11/2024 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetPossibleChildrenCorrelatives] @id_materia int AS 
BEGIN

	WITH correlativas_hijas_actuales AS (
	select materias.* from correlatividades 
INNER JOIN materias ON (correlatividades.id_correlativa = materias.id_materia)
where correlatividades.id_materia = @id_materia
	),
	materia_especifica AS (
		SELECT	* from materias where id_materia = @id_materia
	)
	select materias.* from materias 
INNER JOIN materia_especifica ON (
materias.nivel < materia_especifica.nivel AND materias.id_plan = materia_especifica.id_plan
) 
where materias.id_materia not in (select id_materia from correlativas_hijas_actuales) 

END;
GO
/****** Object:  StoredProcedure [dbo].[GetPossibleParentCorrelatives]    Script Date: 12/11/2024 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetPossibleParentCorrelatives] @id_materia int AS 
BEGIN

	WITH correlativas_padres_actuales AS (
	SELECT materias.* from correlatividades 
INNER JOIN materias ON (correlatividades.id_materia = materias.id_materia)
where correlatividades.id_correlativa = @id_materia
	),
	materia_especifica AS (
		SELECT	* from materias where id_materia = @id_materia
	)
	select materias.* from materias 
INNER JOIN materia_especifica ON (
materias.nivel > materia_especifica.nivel AND materias.id_plan = materia_especifica.id_plan
) 
where materias.id_materia not in (select id_materia from correlativas_padres_actuales) 

END;
GO
