using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Entities.Exception;
using SchoolManager.Domain.Interface.Repository;
using SchoolManager.Domain.Utils;

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
            Aluno aluno = await _alunoRepository.GetByIdAluno(id);

            if (aluno == null)
            {
                throw new CustomException("Aluno não encontrado");
            }

            aluno.Activate();

            return await _alunoRepository.Update(aluno);
        }

        public async Task<int> CreateAluno(Aluno entity)
        {
            entity.IsPasswordStrong();
            entity.SetPassword(new PasswordHasher());
            return await _alunoRepository.Insert(entity);
        }

        public async Task<List<Aluno>> GetAllAluno()
        {
            IEnumerable<Aluno> alunos = await _alunoRepository.GetAll();

            List<Aluno> alunosList = alunos.ToList();

            alunosList.ForEach(x => x.Senha = x.Senha.MaskString());

            return alunosList;
        }

        public async Task<Aluno> GetById(int id)
        {
            Aluno aluno = await _alunoRepository.GetByIdAluno(id);
            aluno.Senha = aluno.Senha.MaskString();
            return aluno;
        }

        public async Task<bool> InactivateAlunoById(int id)
        {
            Aluno aluno = await _alunoRepository.GetByIdAluno(id);

            if (aluno == null)
            {
                throw new CustomException("Aluno não encontrado");
            }
            aluno.Inactivate();

            return await _alunoRepository.Update(aluno);
        }

        public async Task<bool> UpdateAluno(Aluno entity)
        {
            Aluno aluno = await _alunoRepository.GetByIdWithPassword(entity.Id);

            if (aluno == null)
            {
                throw new CustomException("Aluno não encontrado");
            }

            entity.IsPasswordStrong();

            aluno.CheckPassword(entity.Senha, new PasswordHasher());

            entity.Id = aluno.Id;
            entity.Inativo = entity.Inativo;

            return await _alunoRepository.Update(entity);
        }
    }
}
