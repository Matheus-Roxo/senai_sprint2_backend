CREATE DATABASE	M_Peoples;

USE M_Peoples;

CREATE TABLE Funcionarios
(
	IdFuncionario INT PRIMARY KEY IDENTITY
	,Nome VARCHAR(50) NOT NULL
	,Sobrenome VARCHAR(50) NOT NULL
	,DataNascimento DATE NOT NULL
);

CREATE TABLE TiposUsuarios
(
	IdTipoUsuario INT PRIMARY KEY IDENTITY
	,Descricao VARCHAR(50) NOT NULL
);

CREATE TABLE Usuarios
(
	IdUsuario INT PRIMARY KEY IDENTITY
	,IdTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuarios(IdTipoUsuario)
	,Email VARCHAR(100) NOT NULL UNIQUE
	,Senha VARCHAR(100) NOT NULL
);