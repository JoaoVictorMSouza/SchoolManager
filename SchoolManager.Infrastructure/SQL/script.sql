IF NOT EXISTS (
    SELECT [name] FROM sys.databases WHERE [name] = 'SCHOOL_MANAGER'
)
BEGIN
    CREATE DATABASE SCHOOL_MANAGER;
END
GO

USE SCHOOL_MANAGER;
GO

CREATE TABLE ALUNO(
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    usuario VARCHAR(45) NOT NULL,
    senha CHAR(60) NOT NULL,
    inativo TINYINT NOT NULL
);

CREATE TABLE TURMA(
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    curso_id INT NOT NULL,
    turma VARCHAR(45) NOT NULL,
    ano INT NOT NULL,
    inativo TINYINT NOT NULL
);

CREATE TABLE ALUNO_TURMA(
    aluno_id INT NOT NULL,
    turma_id INT NOT NULL,
    inativo TINYINT NOT NULL,
    CONSTRAINT aluno_turma_aluno_id_primary PRIMARY KEY(aluno_id),
    CONSTRAINT aluno_turma_turma_id_foreign FOREIGN KEY(turma_id) REFERENCES TURMA(id),
    CONSTRAINT aluno_turma_aluno_id_foreign FOREIGN KEY(aluno_id) REFERENCES ALUNO(id)
);