USE [master]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 07/12/2020 18:01:13 ******/
CREATE DATABASE [GameStore]
GO

USE [GameStore]
GO


CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Amigos]    Script Date: 07/12/2020 18:01:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amigos](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Apelido] [varchar](50) NOT NULL,
	[Email] [varchar](250) NULL,
 CONSTRAINT [PK_Amigos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 07/12/2020 18:01:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 07/12/2020 18:01:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 07/12/2020 18:01:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 07/12/2020 18:01:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 07/12/2020 18:01:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 07/12/2020 18:01:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 07/12/2020 18:01:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Emprestimos]    Script Date: 07/12/2020 18:01:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emprestimos](
	[Id] [uniqueidentifier] NOT NULL,
	[AmigoId] [uniqueidentifier] NOT NULL,
	[JogoId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Emprestimos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jogos]    Script Date: 07/12/2020 18:01:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jogos](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[Genero] [varchar](100) NOT NULL,
	[Emprestado] [bit] NOT NULL,
 CONSTRAINT [PK_Jogos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
INSERT [dbo].[Amigos] ([Id], [Nome], [Apelido], [Email]) VALUES (N'a22d7a31-8a05-439d-7201-08d89b653cb5', N'Rodrigo Martins', N'Crispin', N'rodrigo.martins@gmail.com')
INSERT [dbo].[Amigos] ([Id], [Nome], [Apelido], [Email]) VALUES (N'39a7be57-e067-4ec8-7202-08d89b653cb5', N'Felipe Soares', N'Pequeno', N'felipe.soares@gmail.com')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'f3acbf6e-7c3f-489f-a8a1-beb12fa2c9c1', N'admin@test.com.br', N'ADMIN@TEST.COM.BR', N'admin@test.com.br', N'ADMIN@TEST.COM.BR', 1, N'AQAAAAEAACcQAAAAEJO1EtI3A2m1UxaYmAIK8vcpdjABvOgnzn2kVLyf8sayggeZ6P8nx6RCczKs8wYhaw==', N'W4ZRJ7X7QRPAFRE4IOK2ZCAJ4KLWIXSL', N'9739a80a-9ec4-444b-8bb8-89bd91983c92', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[Emprestimos] ([Id], [AmigoId], [JogoId]) VALUES (N'47622442-2aa6-47c8-2511-08d89b653cbc', N'a22d7a31-8a05-439d-7201-08d89b653cb5', N'1d657050-f3cf-45e9-6ac1-08d89b6421d4')
INSERT [dbo].[Emprestimos] ([Id], [AmigoId], [JogoId]) VALUES (N'00d5f2e1-53e1-4890-2512-08d89b653cbc', N'39a7be57-e067-4ec8-7202-08d89b653cb5', N'75d0648b-3b6d-4e83-6ac3-08d89b6421d4')
GO
INSERT [dbo].[Jogos] ([Id], [Nome], [Genero], [Emprestado]) VALUES (N'1d657050-f3cf-45e9-6ac1-08d89b6421d4', N'Final Fantasy VII Remake', N'JRPG', 1)
INSERT [dbo].[Jogos] ([Id], [Nome], [Genero], [Emprestado]) VALUES (N'4b12cb5e-bc3c-48ba-6ac2-08d89b6421d4', N'Red Dead Redemption 2', N'Mundo aberto', 0)
INSERT [dbo].[Jogos] ([Id], [Nome], [Genero], [Emprestado]) VALUES (N'75d0648b-3b6d-4e83-6ac3-08d89b6421d4', N'God of War', N'Terceira pessoa', 1)
INSERT [dbo].[Jogos] ([Id], [Nome], [Genero], [Emprestado]) VALUES (N'1182ce6e-bad8-471e-6ac4-08d89b6421d4', N'Homem-Aranha da Marvel', N'Super-heróis', 0)
INSERT [dbo].[Jogos] ([Id], [Nome], [Genero], [Emprestado]) VALUES (N'09137eed-7575-4802-6ac5-08d89b6421d4', N'Tony Hawk’s Pro Skater 1+2', N'remake ', 0)
INSERT [dbo].[Jogos] ([Id], [Nome], [Genero], [Emprestado]) VALUES (N'474f2123-380c-4312-6ac6-08d89b6421d4', N'The Last of Us Parte II', N'Ação-aventura', 0)
GO
ALTER TABLE [dbo].[Emprestimos] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [AmigoId]
GO
ALTER TABLE [dbo].[Emprestimos] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [JogoId]
GO
ALTER TABLE [dbo].[Jogos] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Emprestado]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Emprestimos]  WITH CHECK ADD  CONSTRAINT [FK_Emprestimos_Amigos_AmigoId] FOREIGN KEY([AmigoId])
REFERENCES [dbo].[Amigos] ([Id])
GO
ALTER TABLE [dbo].[Emprestimos] CHECK CONSTRAINT [FK_Emprestimos_Amigos_AmigoId]
GO
ALTER TABLE [dbo].[Emprestimos]  WITH CHECK ADD  CONSTRAINT [FK_Emprestimos_Jogos_JogoId] FOREIGN KEY([JogoId])
REFERENCES [dbo].[Jogos] ([Id])
GO
ALTER TABLE [dbo].[Emprestimos] CHECK CONSTRAINT [FK_Emprestimos_Jogos_JogoId]
GO
