using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Interface.Base;

namespace SchoolManager.Domain.Interface.Repository
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<Aluno> GetByIdWithPassword(int id);
    }
}
