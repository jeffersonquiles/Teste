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
