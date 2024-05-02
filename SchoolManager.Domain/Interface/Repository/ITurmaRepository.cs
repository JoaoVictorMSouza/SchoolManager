using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Interface.Base;

namespace SchoolManager.Domain.Interface.Repository
{
    public interface ITurmaRepository : IRepository<Turma>
    {
        Task<Turma?> GetByName(string turmaNome);
    }
}
