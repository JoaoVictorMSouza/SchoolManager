using SchoolManager.Domain.Entities;

namespace SchoolManager.Domain.Interface.Repository
{
    public interface IAlunoTurmaService
    {
        Task<int> CreateAlunoTurma(AlunoTurma entity);
        Task<bool> UpdateAlunoTurma(AlunoTurma entity);
        Task<List<AlunoTurma>> GetAllAlunoTurma();
        Task<bool> InactivateAlunoTurmaByIdTurmaAndIdAluno(int idTurma, int idAluno);
        Task<bool> ActivateAlunoTurmaByIdTurmaAndIdAluno(int idTurma, int idAluno);
        Task<AlunoTurma> GetByIdTurmaAndIdAluno(int idTurma, int idAluno);
        Task<List<Aluno>> GetAlunosByTurma(int turmaId);
    }
}
