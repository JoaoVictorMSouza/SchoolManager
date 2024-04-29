using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Interface.Repository;

namespace SchoolManager.Service.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;
        public TurmaService(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }
        public Task<int> CreateTurma(Turma entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Aluno>> GetAllTurma()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InactivateTurmaById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTurma(Turma entity)
        {
            throw new NotImplementedException();
        }
    }
}
