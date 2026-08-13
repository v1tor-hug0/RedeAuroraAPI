CREATE DATABASE RedeAurora;
go
USE RedeAurora;
go

CREATE TABLE Unidade(
    id_unidade INT IDENTITY PRIMARY KEY,
    nome VARCHAR(100) NOT NULL UNIQUE,
)
go

CREATE TABLE Setor (
    id_setor INT IDENTITY PRIMARY KEY,
    nome VARCHAR(100) NOT NULL UNIQUE,
    id_unidade INT NOT NULL,

    CONSTRAINT FK_Setor_unidade
        FOREIGN KEY (id_unidade)
        REFERENCES Unidade(id_unidade)
);
go

CREATE TABLE Usuario (
    id_usuario UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
    senha VARBINARY(32) NOT NULL,
)
GO

ALTER TABLE Usuario
ADD email varchar(50);
GO

CREATE TABLE ItemInventario (
    id_item INT IDENTITY PRIMARY KEY,
    codigo_patrimonio VARCHAR(50) NOT NULL UNIQUE,
    descricao VARCHAR(255) NOT NULL,
    id_setor INT NOT NULL,
    condicao VARCHAR(20) NOT NULL,
    data_hora DATETIME NOT NULL,
    id_usuario UNIQUEIDENTIFIER,
    CONSTRAINT fk_iteminventario_setor
        FOREIGN KEY (id_setor)
        REFERENCES Setor(id_setor),

    CONSTRAINT chk_condicao
        CHECK (condicao IN ('Bom', 'Danificado')),

    CONSTRAINT fk_item_Usuario
        FOREIGN KEY (id_usuario)
        REFERENCES Usuario(id_usuario)
);
go

ALTER TABLE ItemInventario 
ADD nome VARCHAR(50);
GO

INSERT INTO Unidade(nome) VALUES
('Escritorio'),
('Laboratório'),
('Depósito');
go

INSERT INTO Setor (nome, id_unidade) VALUES
('Administração', 1),
('Financeiro', 2);
go

SELECT * FROM Setor;
go

SELECT * FROM ItemInventario;
go