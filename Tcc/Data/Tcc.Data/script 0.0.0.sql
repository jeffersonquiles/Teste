/*********************************** COUNTRY *************************************/

CREATE TABLE [dbo].[Country](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[COI] [varchar](3) NULL,
	[FIFA] [varchar](3) NULL,
	[ISO3] [varchar](3) NOT NULL,
	[ISO2] [varchar](2) NOT NULL,
    [UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Country_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/*********************************** STATE PROVINCE *************************************/

CREATE TABLE [dbo].[StateProvince](
	[Id] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Abbreviation] [varchar](2) NOT NULL,
	[PrincipalCity] [varchar](30) NULL,
	[Latitude] [decimal](12, 8) NULL,
	[Longitude] [decimal](12, 8) NULL,
	[Region] [varchar](100) NULL,
    [UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StateProvince]  WITH CHECK ADD  CONSTRAINT [FK_StateProvince_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO

ALTER TABLE [dbo].[StateProvince] CHECK CONSTRAINT [FK_StateProvince_Country]
GO

/*********************************** CITY *************************************/

CREATE TABLE [dbo].[City](
	[Id] [int] NOT NULL,
	[StateProvinceId] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Latitude] [decimal](12, 8) NULL,
	[Longitude] [decimal](12, 8) NULL,
	[UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_StateProvince] FOREIGN KEY([StateProvinceId])
REFERENCES [dbo].[StateProvince] ([Id])
GO

ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_StateProvince]
GO


/*********************************** LOCATION TYPE *************************************/

CREATE TABLE [dbo].[LocationType](
	[Id] [int] NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_AddressType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/*********************************** GYN *************************************/

CREATE TABLE [dbo].[Gyn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [int] NOT NULL,
	[UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_ProviderPhone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/*********************************** LOCATION *************************************/

CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LocationTypeId] [int] NOT NULL,
	[StateProvinceId] [int] NULL,
	[CityId] [int] NULL,
	[CountryId] [int] NULL,
	[ZipCode] [varchar](30) NULL,
	[AddressName] [varchar](200) NULL,
	[Neighborhood] [varchar](200) NULL,
	[Number] [varchar](50) NULL,
	[Complement] [varchar](50) NULL,
	[ReferencePoint] [varchar](200) NULL,
	[AdditionalInformation] [varchar](200) NULL,
	[Latitude] [numeric](21, 18) NULL,
	[Longitude] [numeric](21, 18) NULL,
	[UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,

 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO

ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_City]
GO

ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_LocationType] FOREIGN KEY([LocationTypeId])
REFERENCES [dbo].[LocationType] ([Id])
GO

ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_LocationType]
GO

ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_StateProvince] FOREIGN KEY([StateProvinceId])
REFERENCES [dbo].[StateProvince] ([Id])
GO

ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_StateProvince]
GO

ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO

ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_StateProvince]
GO


/*********************************** PERSON  *************************************/

CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Facebook] [varchar](30) NOT NULL,
	[Gender] bit NOT NULL,
	[BirtyDay] datetime NOT NULL,
	[UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Gyn] FOREIGN KEY([GynId])
REFERENCES [dbo].[Gyn] ([Id])
GO

/*********************************** PERSON  *************************************/

CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Facebook] [varchar](30) NOT NULL,
	[Gender] bit NOT NULL,
	[BirtyDay] datetime NOT NULL,
	[UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Gyn] FOREIGN KEY([GynId])
REFERENCES [dbo].[Gyn] ([Id])
GO

/*********************************** CLASSIFICATION TYPE  *************************************/

CREATE TABLE [dbo].[Classification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*********************************** PERSON CLASSIFICATION  *************************************/

CREATE TABLE [dbo].[PersonClassification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int]  NOT NULL,
	[ClassificationId] [int]  NOT NULL,
	[UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PersonClassification]  WITH CHECK ADD  CONSTRAINT [FK_PersonClassification_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
GO

ALTER TABLE [dbo].[PersonClassification]  WITH CHECK ADD  CONSTRAINT [FK_PersonClassification_Classification] FOREIGN KEY([ClassificationId])
REFERENCES [dbo].[Classification] ([Id])
GO

/*********************************** PERSON LOCATION *************************************/

GO

/****** Object:  Table [dbo].[PersonLocation]    Script Date: 10/07/2017 11:56:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PersonLocation](
	[PersonId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_PersonToLocation] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC,
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PersonLocation]  WITH CHECK ADD  CONSTRAINT [FK_PersonToLocation_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO

ALTER TABLE [dbo].[PersonLocation] CHECK CONSTRAINT [FK_PersonToLocation_Location]
GO

/*********************************** PERSON PHONE NUMBER *************************************/

GO

/****** Object:  Table [dbo].[PersonPhoneNumber]    Script Date: 10/07/2017 11:54:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PersonPhoneNumber](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[PhoneNumberTypeId] [int] NOT NULL,
	[PhoneProviderId] [int] NULL,
	[LocationId] [int] NULL,
	[Number] [varchar](15) NOT NULL,
	[Description] [varchar](50) NULL,
	[IsMain] [bit] NULL,
	[UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_PersonPhoneNumber] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PersonPhoneNumber]  WITH CHECK ADD  CONSTRAINT [FK_PersonPhoneNumber_PhoneNumberType] FOREIGN KEY([PhoneNumberTypeId])
REFERENCES [dbo].[PhoneNumberType] ([Id])
GO

ALTER TABLE [dbo].[PersonPhoneNumber] CHECK CONSTRAINT [FK_PersonPhoneNumber_PhoneNumberType]
GO

ALTER TABLE [dbo].[PersonPhoneNumber]  WITH CHECK ADD  CONSTRAINT [FK_PersonPhoneNumber_PhoneProvider] FOREIGN KEY([PhoneProviderId])
REFERENCES [dbo].[PhoneProvider] ([Id])
GO

ALTER TABLE [dbo].[PersonPhoneNumber] CHECK CONSTRAINT [FK_PersonPhoneNumber_PhoneProvider]
GO

ALTER TABLE [dbo].[PersonPhoneNumber]  WITH CHECK ADD  CONSTRAINT [FK_PersonToPhoneNumber_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
GO

ALTER TABLE [dbo].[PersonPhoneNumber] CHECK CONSTRAINT [FK_PersonToPhoneNumber_Person]
GO


/*********************************** PHONE NUMBER TYPE *************************************/

CREATE TABLE [dbo].[PhoneNumberType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_NumberPhoneType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/*********************************** PHONE PROVIDER *************************************/

CREATE TABLE [dbo].[PhoneProvider](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_ProviderPhone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*********************************** USER INFO *************************************/

CREATE TABLE [dbo].[UserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_ProviderPhone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_UserInfo_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
GO

/*********************************** BODY PARTY *************************************/

CREATE TABLE [dbo].[BodyPart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_BodyParty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*********************************** LEVEL *************************************/

CREATE TABLE [dbo].[Level](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Level] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*********************************** CATEGORY *************************************/

CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[TY] [int]  NOT NULL,
	[UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*********************************** EXERCISE LIST *************************************/

CREATE TABLE [dbo].[ExerciseList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[GynId] [int] NOT NULL,
	[CoachId] [int] NOT NULL,
	[UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_ExerciseList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*********************************** EXERCISE  *************************************/

CREATE TABLE [dbo].[Exercise](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[LevelId] [int] NOT NULL,
	[ExerciseListId] [int] NOT NULL,
	[VideoUrl] [varhcar] NULL,
	[BodyPartyId] [int] NOT NULL,
	[Series] [int] NOT NULL,
	[Repeats] [int] NOT NULL,
	[RestTime] [time] NOT NULL,
	[UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Exercise] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Exercise]  WITH CHECK ADD  CONSTRAINT [FK_Exercise_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])

GO

ALTER TABLE [dbo].[Exercise]  WITH CHECK ADD  CONSTRAINT [FK_Exercise_Level] FOREIGN KEY([LevelId])
REFERENCES [dbo].[Level] ([Id])

GO

ALTER TABLE [dbo].[Exercise]  WITH CHECK ADD  CONSTRAINT [FK_Exercise_BodyParty] FOREIGN KEY([BodyPartyId])
REFERENCES [dbo].[BodyParty] ([Id])

GO

ALTER TABLE [dbo].[Exercise]  WITH CHECK ADD  CONSTRAINT [FK_Exercise_ExerciseList] FOREIGN KEY([ExerciseListId])
REFERENCES [dbo].[ExerciseList] ([Id])


/*********************************** GYN PERSON *************************************/

CREATE TABLE [dbo].[GynPerson](
	[GynId] [int]  NOT NULL,
	[PersonId] [int]  NOT NULL,
 CONSTRAINT [PK_[GynPerson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[GynPerson]  WITH CHECK ADD  CONSTRAINT [FK_GynPerson_GynId] FOREIGN KEY([GynId])
REFERENCES [dbo].[Gyn] ([Id])

GO

ALTER TABLE [dbo].[GynPerson]  WITH CHECK ADD  CONSTRAINT [FK_GynPerson_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
