using SchoolManager.Domain.Entities;

namespace SchoolManager.Domain.Interface.Repository
{
    public interface IAlunoTurmaService
    {
        Task<int> CreateAlunoTurma(AlunoTurma entity);
        Task<bool> UpdateAlunoTurma(AlunoTurma entity);
        Task<List<Aluno>> GetAllAlunoTurma();
        Task<bool> InactivateAlunoTurmaById(int id);
    }
}
