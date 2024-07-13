drop database CursoTeste
create database CursoTeste
go

use CursoTeste
go

create table EncryptionResults (
	Id int primary key identity(1,1),
	EncryptedText varchar(max) not null,
	DecryptedText varchar(max) not null,
	[Key] varchar(max) not null,
	Created datetime not null
)
go

select * from EncryptionResults