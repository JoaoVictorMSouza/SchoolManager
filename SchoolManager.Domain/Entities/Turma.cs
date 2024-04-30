using SchoolManager.Domain.Entities.Base;

namespace SchoolManager.Domain.Entities
{
    public class Turma : BaseEntity
    {
        public string cursoId { get; set; }
        public string turma { get; set; }
        public int ano { get; set; }
    }
}
