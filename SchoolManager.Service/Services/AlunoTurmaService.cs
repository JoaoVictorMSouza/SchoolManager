using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Interface.Repository;

namespace SchoolManager.Service.Services
{
    public class AlunoTurmaService : IAlunoTurmaService
    {
        private readonly IAlunoTurmaRepository _alunoTurmaRepository;

        public AlunoTurmaService(IAlunoTurmaRepository alunoTurmaRepository)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
        }

        public Task<int> CreateAlunoTurma(AlunoTurma entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Aluno>> GetAllAlunoTurma()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InactivateAlunoTurmaById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAlunoTurma(AlunoTurma entity)
        {
            throw new NotImplementedException();
        }
    }
}
