CREATE DATABASE Vet;

USE Vet ; 

-- Criar primeiro as que possuem somente Primary Keys

CREATE TABLE Clinica(
   IDClinica INT PRIMARY KEY IDENTITY NOT NULL ,
   Nome VARCHAR(50) NOT NULL,
   Rua VARCHAR(20),
   Numero VARCHAR(6),
   CEP VARCHAR(15),
);

--ALTER TABLE Clinica DROP COLUMN Nome;
--ALTER TABLE Clinica ADD Nome VARCHAR(50);
--DROP TABLE Clinica;


CREATE TABLE Dono(
IdDono INT PRIMARY KEY IDENTITY NOT NULL,
Nome VARCHAR(50) NOT NULL,
);

Create TABLE Raca(
IdRaca INT PRIMARY KEY IDENTITY NOT NULL,
Raca VARCHAR(20) NOT NULL,
);

CREATE TABLE TipoDePet(
IdTipoPet INT PRIMARY KEY IDENTITY NOT NULL,
TipoPet VARCHAR(20),
);

-- Tables com Foreign Keys

CREATE TABLE Veterinario (
	IdVeterinario INT PRIMARY KEY IDENTITY NOT NULL,
	IdClinica INT FOREIGN KEY REFERENCES Clinica(IDClinica), --FK
	Nome VARCHAR (50) NOT NULL,
	CRV VARCHAR (20) NOT NULL,
);

CREATE TABLE Pet (
	IdPet  INT PRIMARY KEY IDENTITY NOT NULL,
	Nome VARCHAR (20) NOT NULL,
	IdDono INT FOREIGN KEY REFERENCES Dono(IdDono), --FK
	IdRaca INT FOREIGN KEY REFERENCES Raca(IdRaca), --FK
);

--ALTER TABLE PET ADD IdTipoPet INT FOREIGN KEY REFERENCES TipoDePet(IdTipoPet);--F


CREATE TABLE Atendimento (
	IdAtendimento INT PRIMARY KEY IDENTITY NOT NULL,
	Descricao VARCHAR (100),
	IdVeterinario INT FOREIGN KEY REFERENCES Veterinario(IdVeterinario),
	IdDono INT FOREIGN KEY REFERENCES Dono(IdDono),
);