using SchoolManager.Domain.Entities.Base;

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
    }
}
