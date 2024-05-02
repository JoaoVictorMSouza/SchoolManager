using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Entities.Exception;
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

        public async Task<bool> ActivateAlunoById(int id)
        {
            Aluno aluno = await _alunoRepository.GetById(id);

            if (aluno == null)
            {
                throw new CustomException("Aluno não encontrado");
            }

            aluno.Activate();

            return await _alunoRepository.Update(aluno);
        }

        public async Task<int> CreateAluno(Aluno entity)
        {
            return await _alunoRepository.Insert(entity);
        }

        public async Task<List<Aluno>> GetAllAluno()
        {
            IEnumerable<Aluno> alunos = await _alunoRepository.GetAll();
            return alunos.ToList();
        }

        public async Task<Aluno> GetById(int id)
        {
            return await _alunoRepository.GetById(id);
        }

        public async Task<bool> InactivateAlunoById(int id)
        {
            Aluno aluno = await _alunoRepository.GetById(id);

            if (aluno == null)
            {
                throw new CustomException("Aluno não encontrado");
            }
            aluno.Inactivate();

            return await _alunoRepository.Update(aluno);
        }

        public async Task<bool> UpdateAluno(Aluno entity)
        {
            Aluno aluno = await _alunoRepository.GetById(entity.Id);

            if (aluno == null)
            {
                throw new CustomException("Aluno não encontrado");
            }

            entity.Id = aluno.Id;
            entity.Inativo = entity.Inativo;

            return await _alunoRepository.Update(entity);
        }
    }
}
