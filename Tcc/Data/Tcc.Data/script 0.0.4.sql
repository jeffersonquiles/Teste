


CREATE TABLE [dbo].[PersonClassification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int]  NOT NULL,
	[ClassificationTypeId] [int]  NOT NULL,
	[UniqueId] [uniqueidentifier] NULL,
    [CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_PersonClassification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PersonClassification]  WITH CHECK ADD  CONSTRAINT [FK_PersonClassification_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
GO

ALTER TABLE [dbo].[PersonClassification]  WITH CHECK ADD  CONSTRAINT [FK_PersonClassification_ClassificationType] FOREIGN KEY([ClassificationTypeId])
REFERENCES [dbo].[ClassificationType] ([Id])
GO


insert into PersonClassification values (37,2,NEWID(), GETDATE(), GETDATE(), 0)

create table Class (
	Id int identity(1,1) primary key,
	Name varchar(100),
	TeacharId int

)

ALTER TABLE Class ADD FOREIGN KEY (TeacharId ) REFERENCES Person(Id);

create table WeekDay (
	Id int not null primary key,
	Name varchar(50)
)

insert into WeekDay values (1, 'Domingo'), (2, 'Segunda-Feira'), (3, 'Terça-Feira'),(4, 'Quarta-Feira'),(5, 'Quinta-Feira'),(6, 'Sexta-Feira'),(7, 'Sábado')



create table ClassPeriod (
	Id int identity(1,1) primary key,
	ClassId int,
	WeekDayId int,
	StartTime Datetime,
	EndTime Datetime
)

ALTER TABLE ClassPeriod ADD FOREIGN KEY (ClassId) REFERENCES Class(Id)
go
ALTER TABLE ClassPeriod ADD FOREIGN KEY (WeekDayId) REFERENCES WeekDay(Id)

alter table Class add UpdateDate Datetime
go
alter table Class add CreateDate Datetime
go
Alter table Class add CreateByPersonId int
go
Alter table Class add UpdateByPersonId int
go
Alter table Class add IsDeleted bit
go
Alter table Class add UniqueId uniqueidentifier

alter table ClassPeriod add UpdateDate Datetime
go
alter table ClassPeriod add CreateDate Datetime
go
Alter table ClassPeriod add CreateByPersonId int
go
Alter table ClassPeriod add UpdateByPersonId int
go
Alter table ClassPeriod add IsDeleted bit
go
Alter table ClassPeriod add UniqueId uniqueidentifier

create table TeacherDetail (
	Id int identity(1,1) primary key,
	TeacherId int,
	Resume varchar(2000),
	FOREIGN KEY (TeacherId) REFERENCES Person(Id)
)

create table Qualifications (
	Id int identity(1,1) primary key,
	TeacherDetailId int,
	Name varchar(50),
	FOREIGN KEY (TeacherDetailId) REFERENCES TeacherDetail(Id)
)
