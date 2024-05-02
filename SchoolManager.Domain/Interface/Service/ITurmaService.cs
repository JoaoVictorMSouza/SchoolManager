using SchoolManager.Domain.Entities;

namespace SchoolManager.Domain.Interface.Repository
{
    public interface ITurmaService
    {
        Task<int> CreateTurma(Turma entity);
        Task<bool> UpdateTurma(Turma entity);
        Task<List<Turma>> GetAllTurma();
        Task<bool> InactivateTurmaById(int id);
        Task<bool> ActivateTurmaById(int id);
        Task<Turma> GetById(int id);
    }
}
