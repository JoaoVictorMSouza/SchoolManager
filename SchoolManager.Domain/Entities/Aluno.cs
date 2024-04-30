using SchoolManager.Domain.Entities.Base;

namespace SchoolManager.Domain.Entities
{
    public class Aluno : BaseEntity
    {
        public string nome { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public bool inativo { get; set; }
    }
}
