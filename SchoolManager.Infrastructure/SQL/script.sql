CREATE DATABASE SCHOOL_MANAGER;

GO

USE SCHOOL_MANAGER;

GO

CREATE TABLE "ALUNO"(
    "id" INT NOT NULL,
    "nome" VARCHAR(255) NOT NULL,
    "usuario" VARCHAR(45) NOT NULL,
    "senha" CHAR(60) NOT NULL
);
ALTER TABLE
    "ALUNO" ADD CONSTRAINT "aluno_id_primary" PRIMARY KEY("id");


CREATE TABLE "TURMA"(
    "id" INT NOT NULL,
    "curso_id" INT NOT NULL,
    "turma" VARCHAR(45) NOT NULL,
    "ano" INT NOT NULL
);
ALTER TABLE
    "TURMA" ADD CONSTRAINT "turma_id_primary" PRIMARY KEY("id");


CREATE TABLE "ALUNO_TURMA"(
    "aluno_id" INT NOT NULL,
    "turma_id" INT NOT NULL
);
ALTER TABLE
    "ALUNO_TURMA" ADD CONSTRAINT "aluno_turma_aluno_id_primary" PRIMARY KEY("aluno_id");
ALTER TABLE
    "ALUNO_TURMA" ADD CONSTRAINT "aluno_turma_turma_id_foreign" FOREIGN KEY("turma_id") REFERENCES "TURMA"("id");
ALTER TABLE
    "ALUNO_TURMA" ADD CONSTRAINT "aluno_turma_aluno_id_foreign" FOREIGN KEY("aluno_id") REFERENCES "ALUNO"("id");