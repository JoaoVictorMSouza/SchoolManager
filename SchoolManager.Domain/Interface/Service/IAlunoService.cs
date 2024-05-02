using SchoolManager.Domain.Entities;

namespace SchoolManager.Domain.Interface.Repository
{
    public interface IAlunoService
    {
        Task<int> CreateAluno(Aluno entity);
        Task<bool> UpdateAluno(Aluno entity);
        Task<List<Aluno>> GetAllAluno();
        Task<bool> InactivateAlunoById(int id);
        Task<bool> ActivateAlunoById(int id);
        Task<Aluno> GetById(int id);
    }
}
