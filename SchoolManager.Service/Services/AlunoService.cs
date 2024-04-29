using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Interface.Repository;

namespace SchoolManager.Service.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        public Task<int> CreateAluno(Aluno entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Aluno>> GetAllAluno()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InactivateAlunoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAluno(Aluno entity)
        {
            throw new NotImplementedException();
        }
    }
}
