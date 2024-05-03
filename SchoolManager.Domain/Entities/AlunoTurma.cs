using System.ComponentModel.DataAnnotations;

namespace SchoolManager.Domain.Entities
{
    public class AlunoTurma
    {
        [Display(Name = "Id aluno")]
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        [Display(Name = "Id turma")]
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
        public int TurmaAntigaId { get; set; }
        public bool Inativo { get; set; }
        public void Activate()
        {
            Inativo = false;
        }

        public void Inactivate()
        {
            Inativo = true;
        }
    }
}
