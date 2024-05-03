using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Interface.Base;

namespace SchoolManager.Domain.Interface.Repository
{
    public interface IAlunoTurmaRepository : IRepository<AlunoTurma>
    {
        Task<AlunoTurma?> GetByIdTurmaAndIdAluno(int idTurma, int idAluno);
        Task<IEnumerable<Aluno>> GetAlunosByIdTurma(int idTurma);
    }
}
