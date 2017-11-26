select * from Person

insert into person values ('Jefferson', 'email@teste.com.br', 'facebook@teste.com.br', 1 , GETDATE(), NEWID(), GETDATE(), GETDATE(), 0)
insert into person values ('Laurent', 'email@teste.com.br', 'facebook@teste.com.br', 0 , GETDATE(), NEWID(), GETDATE(), GETDATE(), 0)
alter table person add CreateByPersonId int 
go
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_CreatedPerson] FOREIGN KEY([CreateByPersonId])
REFERENCES [dbo].[Person] ([Id])

alter table person add UpdateByPersonId int 
go
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_UpdatePerson] FOREIGN KEY([UpdateByPersonId])
REFERENCES [dbo].[Person] ([Id])



EXEC sp_RENAME 'table_name.old_name', 'new_name', 'COLUMN'

alter table Person drop column birtyday
alter table Person add BirthDay datetime

select * from Person

ALTER TABLE person ALTER COLUMN gender int NULL

select * from ClassificationType

create table ClassificationType (
	Id int identity (1,1) primary key,
	Name varchar(50),
	CreateDate datetime 
)

insert into ClassificationType values ('Aluno', GETDATE()),( 'Professor', GETDATE())

select * from PhoneNumberType

insert into PhoneNumberType values ('Residêncial', NEWID(), GETDATE(),GETDATE(), 0), ('Comercial', NEWID(), GETDATE(),GETDATE(), 0), ('Outros', NEWID(), GETDATE(),GETDATE(), 0)

insert into PhoneProvider values ('Vivo', GETDATE()), 'Oi', GETDATE()),'Claro', GETDATE()),'Nextel', GETDATE()),'Tim', GETDATE()),'Outros', GETDATE())
