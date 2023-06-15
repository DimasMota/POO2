use GESTAO


CREATE TABLE Cliente
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(150),
	CPF VARCHAR(15),
	RG VARCHAR(15),
	Email VARCHAR(200),
	Fone VARCHAR(15)
)
GO

CREATE TABLE Fornecedor
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(150),
	Fone VARCHAR(15),
	Email VARCHAR(200),
	Site VARCHAR(250)
)
GO