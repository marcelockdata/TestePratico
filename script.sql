



create database TestePratico
go
create table Predio
(
	PredioId UNIQUEIDENTIFIER  not null,
	Andar int not null,
	Elevador char(1) not null,
	Turno char(1) not null,

	constraint pkPredio primary key(PredioId)
)
go
