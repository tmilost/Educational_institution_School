USE [Skola]
GO
/****** Object:  StoredProcedure [dbo].[usp_Add_Table]    Script Date: 12/21/2018 22:53:49 ******/
DROP PROCEDURE [dbo].[usp_Add_Table]
GO
/****** Object:  StoredProcedure [dbo].[usp_Add_PK]    Script Date: 12/21/2018 22:53:49 ******/
DROP PROCEDURE [dbo].[usp_Add_PK]
GO
/****** Object:  StoredProcedure [dbo].[usp_Add_FK]    Script Date: 12/21/2018 22:53:49 ******/
DROP PROCEDURE [dbo].[usp_Add_FK]
GO
/****** Object:  StoredProcedure [dbo].[usp_Add_Field]    Script Date: 12/21/2018 22:53:49 ******/
DROP PROCEDURE [dbo].[usp_Add_Field]
GO
ALTER TABLE [dbo].[Osoba] DROP CONSTRAINT [FK_Osoba_Skola]
GO
ALTER TABLE [dbo].[MailListe] DROP CONSTRAINT [FK_MailListe_TipMaila]
GO
ALTER TABLE [dbo].[MailListe] DROP CONSTRAINT [FK_MailListe_Osoba]
GO
ALTER TABLE [dbo].[KontaktTelefon] DROP CONSTRAINT [FK_KontaktTelefon_TipTelefona]
GO
ALTER TABLE [dbo].[KontaktTelefon] DROP CONSTRAINT [FK_KontaktTelefon_Osoba]
GO
/****** Object:  Table [dbo].[TipTelefona]    Script Date: 12/21/2018 22:53:49 ******/
DROP TABLE [dbo].[TipTelefona]
GO
/****** Object:  Table [dbo].[TipMaila]    Script Date: 12/21/2018 22:53:49 ******/
DROP TABLE [dbo].[TipMaila]
GO
/****** Object:  Table [dbo].[Skola]    Script Date: 12/21/2018 22:53:49 ******/
DROP TABLE [dbo].[Skola]
GO
/****** Object:  Table [dbo].[Osoba]    Script Date: 12/21/2018 22:53:49 ******/
DROP TABLE [dbo].[Osoba]
GO
/****** Object:  Table [dbo].[MailListe]    Script Date: 12/21/2018 22:53:49 ******/
DROP TABLE [dbo].[MailListe]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 12/21/2018 22:53:49 ******/
DROP TABLE [dbo].[Korisnik]
GO
/****** Object:  Table [dbo].[KontaktTelefon]    Script Date: 12/21/2018 22:53:49 ******/
DROP TABLE [dbo].[KontaktTelefon]
GO
/****** Object:  Table [dbo].[KontaktTelefon]    Script Date: 12/21/2018 22:53:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KontaktTelefon](
	[IdTelefona] [bigint] IDENTITY(1,1) NOT NULL,
	[BrojTelefona] [nvarchar](20) NOT NULL,
	[Lokal] [int] NOT NULL,
	[IdTipaTelefona] [bigint] NOT NULL,
	[IdOsobe] [bigint] NOT NULL,
 CONSTRAINT [PK_IdTelefona] PRIMARY KEY CLUSTERED 
(
	[IdTelefona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 12/21/2018 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnik](
	[IdKorisnika] [bigint] IDENTITY(1,1) NOT NULL,
	[KorisnickoIme] [nvarchar](30) NOT NULL,
	[Lozinka] [nvarchar](20) NOT NULL,
	[PravoPristupa] [int] NOT NULL,
 CONSTRAINT [PK_IdKorisnika] PRIMARY KEY CLUSTERED 
(
	[IdKorisnika] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MailListe]    Script Date: 12/21/2018 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MailListe](
	[IdMaila] [bigint] IDENTITY(1,1) NOT NULL,
	[Adresa] [nvarchar](50) NOT NULL,
	[IdTipaMaila] [bigint] NOT NULL,
	[IdOsobe] [bigint] NOT NULL,
 CONSTRAINT [PK_IdMaila] PRIMARY KEY CLUSTERED 
(
	[IdMaila] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Osoba]    Script Date: 12/21/2018 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Osoba](
	[IdOsobe] [bigint] IDENTITY(1,1) NOT NULL,
	[Ime] [nvarchar](30) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[RadnoMesto] [nvarchar](50) NOT NULL,
	[IdSkole] [bigint] NOT NULL,
 CONSTRAINT [PK_IdOsobe] PRIMARY KEY CLUSTERED 
(
	[IdOsobe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skola]    Script Date: 12/21/2018 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skola](
	[IdSkole] [bigint] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](max) NOT NULL,
	[Adresa] [nvarchar](max) NOT NULL,
	[Opstina] [nvarchar](max) NOT NULL,
	[PostanskiBroj] [nvarchar](max) NOT NULL,
	[MaticniBroj] [nvarchar](max) NOT NULL,
	[PIB] [nvarchar](max) NOT NULL,
	[BrojRacuna] [nvarchar](max) NOT NULL,
	[WebStranica] [nvarchar](max) NOT NULL,
	[Pecat] [varchar](max) NOT NULL,
	[Beleska] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_IdSkole] PRIMARY KEY CLUSTERED 
(
	[IdSkole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipMaila]    Script Date: 12/21/2018 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipMaila](
	[IdTipaMaila] [bigint] IDENTITY(1,1) NOT NULL,
	[Tip] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_IdTipaMaila] PRIMARY KEY CLUSTERED 
(
	[IdTipaMaila] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipTelefona]    Script Date: 12/21/2018 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipTelefona](
	[IdTipaTelefona] [bigint] IDENTITY(1,1) NOT NULL,
	[Tip] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_IdTipaTelefona] PRIMARY KEY CLUSTERED 
(
	[IdTipaTelefona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[KontaktTelefon] ON 

INSERT [dbo].[KontaktTelefon] ([IdTelefona], [BrojTelefona], [Lokal], [IdTipaTelefona], [IdOsobe]) VALUES (10, N'065252362', 2, 1, 4)
INSERT [dbo].[KontaktTelefon] ([IdTelefona], [BrojTelefona], [Lokal], [IdTipaTelefona], [IdOsobe]) VALUES (11, N'0112536241', 3, 2, 5)
SET IDENTITY_INSERT [dbo].[KontaktTelefon] OFF
SET IDENTITY_INSERT [dbo].[Korisnik] ON 

INSERT [dbo].[Korisnik] ([IdKorisnika], [KorisnickoIme], [Lozinka], [PravoPristupa]) VALUES (1, N'Admin', N'12345', 3)
INSERT [dbo].[Korisnik] ([IdKorisnika], [KorisnickoIme], [Lozinka], [PravoPristupa]) VALUES (2, N'Pregled', N'12345', 1)
INSERT [dbo].[Korisnik] ([IdKorisnika], [KorisnickoIme], [Lozinka], [PravoPristupa]) VALUES (3, N'Unos', N'12345', 2)
SET IDENTITY_INSERT [dbo].[Korisnik] OFF
SET IDENTITY_INSERT [dbo].[MailListe] ON 

INSERT [dbo].[MailListe] ([IdMaila], [Adresa], [IdTipaMaila], [IdOsobe]) VALUES (8, N'jovan@yahoo.com', 1, 4)
SET IDENTITY_INSERT [dbo].[MailListe] OFF
SET IDENTITY_INSERT [dbo].[Osoba] ON 

INSERT [dbo].[Osoba] ([IdOsobe], [Ime], [Prezime], [RadnoMesto], [IdSkole]) VALUES (4, N'Jovan', N'Jankovic', N'product owner', 7)
INSERT [dbo].[Osoba] ([IdOsobe], [Ime], [Prezime], [RadnoMesto], [IdSkole]) VALUES (5, N'Milos', N'Terzic', N'Scrum master', 7)
SET IDENTITY_INSERT [dbo].[Osoba] OFF
SET IDENTITY_INSERT [dbo].[Skola] ON 

INSERT [dbo].[Skola] ([IdSkole], [Naziv], [Adresa], [Opstina], [PostanskiBroj], [MaticniBroj], [PIB], [BrojRacuna], [WebStranica], [Pecat], [Beleska]) VALUES (7, N'ITS', N'Savski nasip 7', N'Novi Beograd', N'11000', N'26351254', N'524896325', N'25015000007404', N'https://www.its.edu.rs', N'~/Slike\ITS-logo-opremljen.png', N'Fakultet')
SET IDENTITY_INSERT [dbo].[Skola] OFF
SET IDENTITY_INSERT [dbo].[TipMaila] ON 

INSERT [dbo].[TipMaila] ([IdTipaMaila], [Tip]) VALUES (1, N'Privatni')
INSERT [dbo].[TipMaila] ([IdTipaMaila], [Tip]) VALUES (2, N'Sluzbeni')
SET IDENTITY_INSERT [dbo].[TipMaila] OFF
SET IDENTITY_INSERT [dbo].[TipTelefona] ON 

INSERT [dbo].[TipTelefona] ([IdTipaTelefona], [Tip]) VALUES (1, N'Privatni')
INSERT [dbo].[TipTelefona] ([IdTipaTelefona], [Tip]) VALUES (2, N'Sluzbeni')
SET IDENTITY_INSERT [dbo].[TipTelefona] OFF
ALTER TABLE [dbo].[KontaktTelefon]  WITH CHECK ADD  CONSTRAINT [FK_KontaktTelefon_Osoba] FOREIGN KEY([IdOsobe])
REFERENCES [dbo].[Osoba] ([IdOsobe])
GO
ALTER TABLE [dbo].[KontaktTelefon] CHECK CONSTRAINT [FK_KontaktTelefon_Osoba]
GO
ALTER TABLE [dbo].[KontaktTelefon]  WITH CHECK ADD  CONSTRAINT [FK_KontaktTelefon_TipTelefona] FOREIGN KEY([IdTipaTelefona])
REFERENCES [dbo].[TipTelefona] ([IdTipaTelefona])
GO
ALTER TABLE [dbo].[KontaktTelefon] CHECK CONSTRAINT [FK_KontaktTelefon_TipTelefona]
GO
ALTER TABLE [dbo].[MailListe]  WITH CHECK ADD  CONSTRAINT [FK_MailListe_Osoba] FOREIGN KEY([IdOsobe])
REFERENCES [dbo].[Osoba] ([IdOsobe])
GO
ALTER TABLE [dbo].[MailListe] CHECK CONSTRAINT [FK_MailListe_Osoba]
GO
ALTER TABLE [dbo].[MailListe]  WITH CHECK ADD  CONSTRAINT [FK_MailListe_TipMaila] FOREIGN KEY([IdTipaMaila])
REFERENCES [dbo].[TipMaila] ([IdTipaMaila])
GO
ALTER TABLE [dbo].[MailListe] CHECK CONSTRAINT [FK_MailListe_TipMaila]
GO
ALTER TABLE [dbo].[Osoba]  WITH CHECK ADD  CONSTRAINT [FK_Osoba_Skola] FOREIGN KEY([IdSkole])
REFERENCES [dbo].[Skola] ([IdSkole])
GO
ALTER TABLE [dbo].[Osoba] CHECK CONSTRAINT [FK_Osoba_Skola]
GO
/****** Object:  StoredProcedure [dbo].[usp_Add_Field]    Script Date: 12/21/2018 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Add_Field]
	@TableName varchar(MAX),
	@FieldName varchar(MAX),
	@FieldTypeAndDescription varchar(MAX)

AS
BEGIN

	DECLARE @DisplayText varchar(MAX)
	DECLARE @FieldAdditionString varchar(MAX)
	DECLARE @IsError bit  = 0

		IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName)
		BEGIN
		IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = @TableName AND column_name = @FieldName)
			BEGIN				
				SET @FieldAdditionString = 'ALTER TABLE ' + @TableName + ' ' + 'ADD ' +   
											@FieldName + ' ' + @FieldTypeAndDescription + ' '
				BEGIN TRY
					EXEC(@FieldAdditionString)
					SET @DisplayText = 'Column ' + @FieldName + ' created!'
					PRINT @DisplayText
					SET @IsError = 0
				END TRY
				BEGIN CATCH
					SET @IsError = 1
					SELECT Error_Line = ERROR_LINE(), 
					Error_Proc = ERROR_PROCEDURE() 
				END CATCH
			END
		ELSE
			BEGIN
				SET @DisplayText = 'Column ' + @FieldName + ' already exists!'
				PRINT @DisplayText
			END
		END
	ELSE
		BEGIN
			SET @DisplayText = 'Table ' + @TableName + ' does not exist!'
			PRINT @DisplayText	
		END
		END
GO
/****** Object:  StoredProcedure [dbo].[usp_Add_FK]    Script Date: 12/21/2018 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[usp_Add_FK]
	@TargetTableName varchar(MAX),
	@ForeignKeyFieldName varchar(MAX), 
	@SourceTableName varchar(MAX),
	@SourceFieldName varchar(MAX),
	@ConstraintName varchar(MAX) = NULL

AS
BEGIN


	DECLARE @DisplayText varchar(MAX)
	DECLARE @ForeignKeyString varchar(MAX)
	DECLARE @IsError bit  = 0
	DECLARE @ForeignKeyName varchar(MAX)


	IF (@ConstraintName IS NOT NULL)
		BEGIN
			SET @ForeignKeyName = @ConstraintName
		END
	ELSE
		BEGIN
			SET @ForeignKeyName = 'FK_' + @TargetTableName + '_' + @SourceTableName
		END

	

	IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TargetTableName)
		BEGIN
			IF	NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE TABLE_NAME = @TargetTableName
									AND CONSTRAINT_TYPE = 'FOREIGN KEY' AND CONSTRAINT_NAME = @ForeignKeyName)
				BEGIN		
					SET @ForeignKeyString = 'ALTER TABLE ' + @TargetTableName + ' ' + ' ADD CONSTRAINT ' +  
											@ForeignKeyName + ' FOREIGN KEY (' + @ForeignKeyFieldName + ') ' +
											' REFERENCES ' + @SourceTableName + ' (' + @SourceFieldName + ') '

					BEGIN TRY
						EXEC(@ForeignKeyString)
						SET @DisplayText = 'Foreign key ' + @ForeignKeyName + ' created!'
						PRINT @DisplayText
						SET @IsError = 0
					END TRY
					BEGIN CATCH
						SET @IsError = 1
						SELECT Error_Line = ERROR_LINE(), 
						Error_Proc = ERROR_PROCEDURE() 
					END CATCH
				END
			ELSE
				BEGIN
					SET @DisplayText = 'Foreign key ' + @ForeignKeyName + ' already exists!'
					PRINT @DisplayText
				END
		END
	ELSE
		BEGIN
			SET @DisplayText = 'Table ' + @TargetTableName + ' does not exist!'
			PRINT @DisplayText
		END

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Add_PK]    Script Date: 12/21/2018 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Add_PK]
	@TableName varchar(MAX),
	@FieldName varchar(MAX)
AS
BEGIN

	DECLARE @DisplayText varchar(MAX)
	DECLARE @PrimaryKeyString varchar(MAX)
	DECLARE @IsError bit  = 0
	DECLARE @PrimaryKeyName varchar(MAX)

	SET @PrimaryKeyName = 'PK_' + @FieldName

	IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName)
		BEGIN
			IF	NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE TABLE_NAME = @TableName
									AND CONSTRAINT_TYPE = 'PRIMARY KEY' AND CONSTRAINT_NAME = @PrimaryKeyName)
				BEGIN		
					SET @PrimaryKeyString = 'ALTER TABLE ' + @TableName + ' ' + 'ADD CONSTRAINT ' + @PrimaryKeyName + 
							' PRIMARY KEY (' +  
												@FieldName + ') '
					BEGIN TRY
						EXEC(@PrimaryKeyString)
						SET @DisplayText = 'Primary key ' + @FieldName + ' created!'
						PRINT @DisplayText
						SET @IsError = 0
					END TRY
					BEGIN CATCH
						SET @IsError = 1
						SELECT Error_Line = ERROR_LINE(), 
						Error_Proc = ERROR_PROCEDURE() 
					END CATCH
				END
			ELSE
				BEGIN
					SET @DisplayText = 'Primary key ' + @FieldName + ' already exists!'
					PRINT @DisplayText
				END
		END
	ELSE
		BEGIN
			SET @DisplayText = 'Table ' + @TableName + ' does not exist!'
			PRINT @DisplayText
		END

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Add_Table]    Script Date: 12/21/2018 22:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Add_Table]
    @TableName varchar(max),
	@FieldName varchar(max),
	@FieldTypeAndDescription varchar(max)

AS 
BEGIN
	DECLARE @DisplayText varchar(max)
	DECLARE @TableAdditionString varchar(max)
	DECLARE @FieldAdditionString varchar(max)
	DECLARE @IsError bit  = 0

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName)
		BEGIN
			SET @TableAdditionString = 'CREATE TABLE ' + @TableName + ' ' + '( ' +  
											@FieldName + ' ' + @FieldTypeAndDescription + ') '
			BEGIN TRY
				EXEC(@TableAdditionString)
				SET @DisplayText = 'Table ' + @TableName + 'and field ' + @FieldName + ' created!'
				PRINT @DisplayText
				SET @IsError = 0
			END TRY
			BEGIN CATCH
				SET @IsError = 1
				SELECT Error_Line = ERROR_LINE(), 
				Error_Proc = ERROR_PROCEDURE() 
			END CATCH
		END
	ELSE
		BEGIN
			SET @DisplayText = 'Table ' + @TableName + ' already exists!'
			PRINT @DisplayText
		END


    IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = @TableName AND column_name = @FieldName)
			BEGIN				
				SET @FieldAdditionString = 'ALTER TABLE ' + @TableName + ' ' + 'ADD ' +  
											@FieldName + ' ' + @FieldTypeAndDescription + ' '
				BEGIN TRY
					EXEC(@FieldAdditionString)
					SET @DisplayText = 'Column ' + @FieldName + ' created!'
					PRINT @DisplayText
					SET @IsError = 0
				END TRY
				BEGIN CATCH
					SET @IsError = 1
					SELECT Error_Line = ERROR_LINE(), 
					Error_Proc = ERROR_PROCEDURE() 
				END CATCH
			END
		ELSE
			BEGIN
				SET @DisplayText = 'Column ' + @FieldName + ' already exists!'
				PRINT @DisplayText
			END

			END
GO
