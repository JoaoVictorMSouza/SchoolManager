using SchoolManager.Domain.Entities;

namespace SchoolManager.Domain.Interface.Repository
{
    public interface ITurmaService
    {
        Task<int> CreateTurma(Turma entity);
        Task<bool> UpdateTurma(Turma entity);
        Task<List<Aluno>> GetAllTurma();
        Task<bool> InactivateTurmaById(int id);
    }
}
