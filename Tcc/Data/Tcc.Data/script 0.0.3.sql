create table FreeTrainingType (
	Id int IDENTITY(1,1) primary key,
	Name varchar (100),
	Description varchar (100)
)
go
insert into FreeTrainingType values ('ABC', 'Treino Iniciante') 
go
insert into FreeTrainingType values ('ABCD', 'Treino Hipertrofia') 
go
insert into FreeTrainingType values ('ABCDE', 'Treino Exaustão(Perda de Peso)') 

create table FreeTraining (
	Id int identity (1,1) primary key,
	Name varchar (50),
	Description varchar (200),
	TrainingSessions varchar (100),
	FreeTrainingTypeId int,
	Foreign key (FreeTrainingTypeId) References FreeTrainingType(Id)
)

go

insert into FreeTraining values ('A', 'Treino Peito/Biceps', '3 Séries x 10 Repetições', 1)
go
insert into FreeTraining values ('B', 'Treino Costa/Biceps/Abdominal', '3 Séries x 10 Repetições', 1)
go
insert into FreeTraining values ('C', 'Treino Perna/Lombar', '3 Séries x 10 Repetições', 1)
go
insert into FreeTraining values ('A', 'Treino Peito/Biceps', '4 Séries x 12 Repetições', 2)
go
insert into FreeTraining values ('B', 'Treino Ombro/Posterior', '4 Séries x 12 Repetições', 2)
go
insert into FreeTraining values ('C', 'Treino Costa/Triceps', '4 Séries x 12 Repetições', 2)
go
insert into FreeTraining values ('C', 'Treino Anterior/Abdominal', '4 Séries x 12 Repetições', 2)
go
insert into FreeTraining values ('A', 'Treino Peito', '3 Séries x 15 Repetições', 3)
go
insert into FreeTraining values ('B', 'Treino Perna', '4 Séries x 12 Repetições', 3)
go
insert into FreeTraining values ('C', 'Treino Ombro/Trapezio', '3 Séries x 15 Repetições', 3)
go
insert into FreeTraining values ('D', 'Treino Biceps/Triceps', '3 Séries x 15 Repetições', 3)
go
insert into FreeTraining values ('E', 'Treino Aeróbico', 'Uma hora (tempo total)', 3)
go

create table ExerciseFreeTraining (
	Id int identity (1,1) primary key,
	Name varchar (100),
	FreeTrainingId int,
	Foreign Key (FreeTrainingId) References FreeTraining(Id)
)
/* Treino A do ABC */
go
insert into ExerciseFreeTraining values ('Supino Reto Máquina', 1) 
go
insert into ExerciseFreeTraining values ('Supino Inclinado Máquina', 1) 
go
insert into ExerciseFreeTraining values ('Crucifixo PeckDeck', 1) 
go
insert into ExerciseFreeTraining values ('Triceps Máquina Testa', 1) 
go
insert into ExerciseFreeTraining values ('Triceps Pulley Barra Reta', 1) 
go
insert into ExerciseFreeTraining values ('Elevação Lateral C/ Halter', 1) 
go
insert into ExerciseFreeTraining values ('Desenvolvimento Máquina', 1) 
/* Treino B do ABC */
go
insert into ExerciseFreeTraining values ('Remada Aberta Máquina', 2) 
go
insert into ExerciseFreeTraining values ('Remada Baixa Supinada Máquina', 2) 
go
insert into ExerciseFreeTraining values ('Pulley Frente', 2) 
go
insert into ExerciseFreeTraining values ('Rosca Direta Crossover Barra Reta', 2) 
go
insert into ExerciseFreeTraining values ('Rosca Alternada C/ Halter', 2) 
go
insert into ExerciseFreeTraining values ('Abdominal Máquina', 2) 
go
insert into ExerciseFreeTraining values ('Abdominal Canivete S/ Caneleira Solo', 2)
/* Treino C do ABC */
go
insert into ExerciseFreeTraining values ('Leg Press 90º', 3) 
go
insert into ExerciseFreeTraining values ('Cadeira Extensora', 3) 
go
insert into ExerciseFreeTraining values ('Cadeira Flexora', 3) 
go
insert into ExerciseFreeTraining values ('Cadeira Abdutora', 3) 
go
insert into ExerciseFreeTraining values ('Cadeira Adutora', 3) 
go
insert into ExerciseFreeTraining values ('Gêmeos Banco', 3) 
go
insert into ExerciseFreeTraining values ('Gêmeos Leg Press 90º', 3) 
go
insert into ExerciseFreeTraining values ('Hiperextensão Tronco Remada', 3)
go
insert into ExerciseFreeTraining values ('Abdominal Canivete S/ Caneleira Solo', 3)
/* Treino A do ABCD */
go 
insert into ExerciseFreeTraining values ('Fly Reto', 4)
go 
insert into ExerciseFreeTraining values ('Fly Inclinado', 4)
go 
insert into ExerciseFreeTraining values ('Pullover', 4)
go 
insert into ExerciseFreeTraining values ('Crossover Pulley', 4)
go 
insert into ExerciseFreeTraining values ('Rosca Direta Pirâmide', 4)
go 
insert into ExerciseFreeTraining values ('Martelo Pulley', 4)
go
insert into ExerciseFreeTraining values ('Rosca Invertida', 4)
go
insert into ExerciseFreeTraining values ('Antebraço Rosca Banco Apoiado', 4)
/* Treino B do ABCD */
go
insert into ExerciseFreeTraining values ('Desenvolvimento com Halter', 5)
go 
insert into ExerciseFreeTraining values ('Elevação Lateral Pulley', 5)
go 
insert into ExerciseFreeTraining values ('Elevação Frontal', 5)
go 
insert into ExerciseFreeTraining values ('PeckDeck Invertido', 5)
go 
insert into ExerciseFreeTraining values ('Mesa Flexora', 5)
go 
insert into ExerciseFreeTraining values ('Levantamento Terra', 5)
go
insert into ExerciseFreeTraining values ('Avanço com Halter', 5)
go
insert into ExerciseFreeTraining values ('Gêmeos Máquina', 5)
/* Treino C do ABCD */
go
insert into ExerciseFreeTraining values ('Pulley Nuca', 6)
go 
insert into ExerciseFreeTraining values ('Remada Alta Máquina', 6)
go 
insert into ExerciseFreeTraining values ('Barra Fixa', 6)
go 
insert into ExerciseFreeTraining values ('Remada Barra T', 6)
go 
insert into ExerciseFreeTraining values ('Pronado Pulley', 6)
go 
insert into ExerciseFreeTraining values ('Francês', 6)
go
insert into ExerciseFreeTraining values ('Corda', 6)
go
insert into ExerciseFreeTraining values ('Paralelas', 6)
/* Treino D do ABCD */
go
insert into ExerciseFreeTraining values ('Leg 90º', 7)
go 
insert into ExerciseFreeTraining values ('Leg 45º', 7)
go 
insert into ExerciseFreeTraining values ('Cadeira Extensora', 7)
go 
insert into ExerciseFreeTraining values ('Cadeira Adutora', 7)
go 
insert into ExerciseFreeTraining values ('Cadeira Abdutora', 7)
go 
insert into ExerciseFreeTraining values ('Agachamento Livre', 7)
go
insert into ExerciseFreeTraining values ('Levantamento Terra', 7)
go
insert into ExerciseFreeTraining values ('Abdominal Prancha', 7)
go
insert into ExerciseFreeTraining values ('Abdominal Barra', 7)
/* Treino A Do ABCDE */
go
insert into ExerciseFreeTraining values ('Supino Fly Reto', 8) 
go
insert into ExerciseFreeTraining values ('Supino Supino Máquina', 8) 
go
insert into ExerciseFreeTraining values ('Crucifixo PeckDeck', 8) 
go
insert into ExerciseFreeTraining values ('Triceps Crossover', 8) 
go
insert into ExerciseFreeTraining values ('Triceps Supino Declinado', 8) 
/* Treino B Do ABCDE */
go
insert into ExerciseFreeTraining values ('Leg 90º', 9) 
go
insert into ExerciseFreeTraining values ('Leg 45º', 9) 
go
insert into ExerciseFreeTraining values ('Cadeira Adutora', 9) 
go
insert into ExerciseFreeTraining values ('Cadeira Abdutora', 9) 
go
insert into ExerciseFreeTraining values ('Mesa Flexora', 9) 
go
insert into ExerciseFreeTraining values ('Cadeira Extensora', 9)
go
insert into ExerciseFreeTraining values ('Agachamento Smith', 9)  
go
insert into ExerciseFreeTraining values ('Agachamento Barra', 9) 
/* Treino C Do ABCDE */
go
insert into ExerciseFreeTraining values ('Elevação Lateral C/ Halter', 10) 
go
insert into ExerciseFreeTraining values ('Elevação Frontal C/ Halter', 10) 
go
insert into ExerciseFreeTraining values ('Elevação C/Halter Inclinação Frente', 10) 
go
insert into ExerciseFreeTraining values ('Desenvolvimento Sentado C/Halter', 10) 
go
insert into ExerciseFreeTraining values ('Remada Alta Em Pé C/ Halter', 10) 
go
insert into ExerciseFreeTraining values ('Encolhimento C/ Barra', 10)
/* Treino D Do ABCDE */
go
insert into ExerciseFreeTraining values ('Pronado', 11) 
go
insert into ExerciseFreeTraining values ('Corda', 11) 
go
insert into ExerciseFreeTraining values ('Coice C/ Corda', 11) 
go
insert into ExerciseFreeTraining values ('Supininho Teste C/ Barra', 11) 
go
insert into ExerciseFreeTraining values ('Rosca Direta Pulley', 11) 
go
insert into ExerciseFreeTraining values ('Martelo C/ Corda', 11)
go
insert into ExerciseFreeTraining values ('Antebraço Rosca Banco Apoiado', 11)
go
/* Treino E Do ABCDE */
go
insert into ExerciseFreeTraining values ('Esteira (20 min)', 12) 
go
insert into ExerciseFreeTraining values ('Bicicleta (20 min)', 12) 
go
insert into ExerciseFreeTraining values ('Infra Solo', 12) 
go
insert into ExerciseFreeTraining values ('Abdominal Cruzado', 12) 


