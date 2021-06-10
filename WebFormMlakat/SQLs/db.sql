USE [MlakatDB]
GO
/****** Object:  Table [dbo].[DersBilgisis]    Script Date: 10.06.2021 10:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DersBilgisis](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DersAdi] [varchar](50) NOT NULL,
	[DersKodu] [int] NOT NULL,
 CONSTRAINT [PK_DersBilgisi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OgrenciDersBilgisis]    Script Date: 10.06.2021 10:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OgrenciDersBilgisis](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Yil] [varchar](4) NOT NULL,
	[Dönem] [varchar](50) NOT NULL,
	[Notu] [int] NOT NULL,
	[OgrenciId] [int] NOT NULL,
	[DersBilgisiId] [int] NOT NULL,
 CONSTRAINT [PK_OgrenciDersAraTablo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OgrenciDersChanges]    Script Date: 10.06.2021 10:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OgrenciDersChanges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OgrenciId] [int] NULL,
	[BeforeDersAdi] [varchar](50) NULL,
	[AfterDersAdi] [varchar](50) NULL,
 CONSTRAINT [PK_OgrenciDersChanges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ogrencis]    Script Date: 10.06.2021 10:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ogrencis](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TCKimlik] [varchar](11) NOT NULL,
	[Adi] [varchar](50) NOT NULL,
	[Soyadi] [varchar](50) NOT NULL,
	[OgrenciNo] [int] NOT NULL,
 CONSTRAINT [PK_Ogrenci] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DersBilgisis] ON 
GO
INSERT [dbo].[DersBilgisis] ([Id], [DersAdi], [DersKodu]) VALUES (1, N'', 101)
GO
INSERT [dbo].[DersBilgisis] ([Id], [DersAdi], [DersKodu]) VALUES (2, N'İngilizce', 102)
GO
INSERT [dbo].[DersBilgisis] ([Id], [DersAdi], [DersKodu]) VALUES (3, N'Türk Dİli', 103)
GO
INSERT [dbo].[DersBilgisis] ([Id], [DersAdi], [DersKodu]) VALUES (4, N'Matematik', 104)
GO
INSERT [dbo].[DersBilgisis] ([Id], [DersAdi], [DersKodu]) VALUES (5, N'Coğrafya', 105)
GO
SET IDENTITY_INSERT [dbo].[DersBilgisis] OFF
GO
SET IDENTITY_INSERT [dbo].[OgrenciDersBilgisis] ON 
GO
INSERT [dbo].[OgrenciDersBilgisis] ([Id], [Yil], [Dönem], [Notu], [OgrenciId], [DersBilgisiId]) VALUES (2, N'2005', N'2.Dönem', 70, 1, 2)
GO
INSERT [dbo].[OgrenciDersBilgisis] ([Id], [Yil], [Dönem], [Notu], [OgrenciId], [DersBilgisiId]) VALUES (3, N'2006', N'1.Dönem', 65, 2, 3)
GO
INSERT [dbo].[OgrenciDersBilgisis] ([Id], [Yil], [Dönem], [Notu], [OgrenciId], [DersBilgisiId]) VALUES (4, N'2006', N'1.Dönem', 65, 2, 4)
GO
INSERT [dbo].[OgrenciDersBilgisis] ([Id], [Yil], [Dönem], [Notu], [OgrenciId], [DersBilgisiId]) VALUES (5, N'2002', N'1.Dönem', 100, 3, 1)
GO
INSERT [dbo].[OgrenciDersBilgisis] ([Id], [Yil], [Dönem], [Notu], [OgrenciId], [DersBilgisiId]) VALUES (6, N'2005', N'2.Dönem', 85, 4, 5)
GO
INSERT [dbo].[OgrenciDersBilgisis] ([Id], [Yil], [Dönem], [Notu], [OgrenciId], [DersBilgisiId]) VALUES (7, N'2004', N'1.Dönem', 65, 5, 1)
GO
SET IDENTITY_INSERT [dbo].[OgrenciDersBilgisis] OFF
GO
SET IDENTITY_INSERT [dbo].[Ogrencis] ON 
GO
INSERT [dbo].[Ogrencis] ([Id], [TCKimlik], [Adi], [Soyadi], [OgrenciNo]) VALUES (1, N'10310396103', N'Oğuzcan', N'Akyol', 206)
GO
INSERT [dbo].[Ogrencis] ([Id], [TCKimlik], [Adi], [Soyadi], [OgrenciNo]) VALUES (2, N'94941051306', N'Fatma', N'Çiçek', 207)
GO
INSERT [dbo].[Ogrencis] ([Id], [TCKimlik], [Adi], [Soyadi], [OgrenciNo]) VALUES (3, N'10510410396', N'Karahan', N'Çilek', 208)
GO
INSERT [dbo].[Ogrencis] ([Id], [TCKimlik], [Adi], [Soyadi], [OgrenciNo]) VALUES (4, N'10610710890', N'Ayşe', N'Kara', 209)
GO
INSERT [dbo].[Ogrencis] ([Id], [TCKimlik], [Adi], [Soyadi], [OgrenciNo]) VALUES (5, N'10810595106', N'Mert', N'Darı', 205)
GO
SET IDENTITY_INSERT [dbo].[Ogrencis] OFF
GO
ALTER TABLE [dbo].[OgrenciDersBilgisis]  WITH CHECK ADD  CONSTRAINT [FK_OgrenciDersBilgisis_DersBilgisis] FOREIGN KEY([DersBilgisiId])
REFERENCES [dbo].[DersBilgisis] ([Id])
GO
ALTER TABLE [dbo].[OgrenciDersBilgisis] CHECK CONSTRAINT [FK_OgrenciDersBilgisis_DersBilgisis]
GO
ALTER TABLE [dbo].[OgrenciDersBilgisis]  WITH CHECK ADD  CONSTRAINT [FK_OgrenciDersBilgisis_Ogrencis] FOREIGN KEY([OgrenciId])
REFERENCES [dbo].[Ogrencis] ([Id])
GO
ALTER TABLE [dbo].[OgrenciDersBilgisis] CHECK CONSTRAINT [FK_OgrenciDersBilgisis_Ogrencis]
GO
