using SchoolManager.Domain.Entities.Base;
using SchoolManager.Domain.Entities.Exception;

namespace SchoolManager.Domain.Entities
{
    public class Turma : BaseEntity
    {
        public int CursoId { get; set; }
        public string TurmaNome { get; set; }
        public int Ano { get; set; }
        public bool Inativo { get; set; }

        public void Inactivate()
        {
            Inativo = true;
        }
        public void Activate()
        {
            Inativo = false;
        }

        public void ValidateName(string name)
        {
            if (name == this.TurmaNome)
            {
                throw new CustomException("Já existe uma turma com este nome");
            }
        }

        public void ValidateYear()
        {
            if (this.Ano < DateTime.Now.Year)
            {
                throw new CustomException("Não é possível incluír turmas para datas anteriores à data atual");
            }
        }
    }
}
