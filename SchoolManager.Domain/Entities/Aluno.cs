using SchoolManager.Domain.Entities.Base;

namespace SchoolManager.Domain.Entities
{
    public class Aluno : BaseEntity
    {
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
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
