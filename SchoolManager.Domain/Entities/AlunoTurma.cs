﻿namespace SchoolManager.Domain.Entities
{
    public class AlunoTurma
    {
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
        public bool Inativo { get; set; }
    }
}
