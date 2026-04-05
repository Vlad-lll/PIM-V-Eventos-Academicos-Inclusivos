CREATE DATABASE EventosInclusivos;
GO

USE EventosInclusivos;
GO

CREATE TABLE Participantes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Senha VARCHAR(255) NOT NULL,
    DataCadastro DATETIME DEFAULT GETDATE()
);
GO