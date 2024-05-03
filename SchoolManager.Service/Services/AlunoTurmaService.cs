using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Entities.Exception;
using SchoolManager.Domain.Interface.Repository;
using SchoolManager.Domain.Utils;

namespace SchoolManager.Service.Services
{
    public class AlunoTurmaService : IAlunoTurmaService
    {
        private readonly IAlunoTurmaRepository _alunoTurmaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly ITurmaRepository _turmaRepository;


        public AlunoTurmaService(IAlunoTurmaRepository alunoTurmaRepository, IAlunoRepository alunoRepository, ITurmaRepository turmaRepository)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
            _alunoRepository = alunoRepository;
            _turmaRepository = turmaRepository;
        }

        public async Task<bool> ActivateAlunoTurmaByIdTurmaAndIdAluno(int idTurma, int idAluno)
        {
            AlunoTurma? alunoTurma = await _alunoTurmaRepository.GetByIdTurmaAndIdAluno(idTurma, idAluno);

            if (alunoTurma == null)
            {
                throw new CustomException("Aluno não encontrado na turma");

            }

            alunoTurma.Activate();

            alunoTurma.TurmaAntigaId = idTurma;

            return await _alunoTurmaRepository.Update(alunoTurma);
        }

        public async Task<int> CreateAlunoTurma(AlunoTurma entity)
        {
            Aluno anulo = await _alunoRepository.GetByIdAluno(entity.AlunoId);

            if (anulo == null)
            {
                throw new CustomException("Aluno não encontrado");
            }

            Turma turma = await _turmaRepository.GetByIdTurma(entity.TurmaId);

            if (turma == null)
            {
                throw new CustomException("Turma não encontrada");
            }

            AlunoTurma? alunoTurmaValidation = await _alunoTurmaRepository.GetByIdTurmaAndIdAluno(entity.TurmaId, entity.AlunoId);

            if (alunoTurmaValidation != null)
            {
                throw new CustomException("Aluno já cadastrado na turma");
            }

            return await _alunoTurmaRepository.Insert(entity);
        }

        public async Task<List<AlunoTurma>> GetAllAlunoTurma()
        {
            IEnumerable<AlunoTurma> alunosTurma = await _alunoTurmaRepository.GetAll();

            List<AlunoTurma> alunosTurmaList = alunosTurma.ToList();

            alunosTurmaList.ForEach(x => x.Aluno.Senha = x.Aluno.Senha.MaskString());

            return alunosTurmaList;
        }

        public async Task<List<Aluno>> GetAlunosByTurma(int turmaId)
        {
            IEnumerable<Aluno> alunosDaTurma = await _alunoTurmaRepository.GetAlunosByIdTurma(turmaId);
            IEnumerable<Aluno> alunos = await _alunoRepository.GetAll();

            List<Aluno> alunosList = new List<Aluno>();

            foreach (Aluno alunoItem in alunos)
            {
                if(!alunosDaTurma.Any(x => x.Id == alunoItem.Id))
                {
                    alunosList.Add(alunoItem);
                }
            }
            return alunosList;
        }

        public async Task<AlunoTurma> GetByIdTurmaAndIdAluno(int idTurma, int idAluno)
        {
            AlunoTurma? alunoTurma = await _alunoTurmaRepository.GetByIdTurmaAndIdAluno(idTurma, idAluno);

            if (alunoTurma == null)
            {
                throw new CustomException("Aluno não encontrado na turma");
            }

            alunoTurma.Aluno.Senha = alunoTurma.Aluno.Senha.MaskString();

            return alunoTurma;
        }

        public async Task<bool> InactivateAlunoTurmaByIdTurmaAndIdAluno(int idTurma, int idAluno)
        {
            AlunoTurma? alunoTurma = await _alunoTurmaRepository.GetByIdTurmaAndIdAluno(idTurma, idAluno);

            if (alunoTurma == null)
            {
                throw new CustomException("Aluno não encontrado na turma");

            }

            alunoTurma.Inactivate();

            alunoTurma.TurmaAntigaId = idTurma;

            return await _alunoTurmaRepository.Update(alunoTurma);
        }

        public async Task<bool> UpdateAlunoTurma(AlunoTurma entity)
        {
            AlunoTurma? alunoTurma = await _alunoTurmaRepository.GetByIdTurmaAndIdAluno(entity.TurmaAntigaId, entity.AlunoId);

            if (alunoTurma == null)
            {
                throw new CustomException("Aluno não encontrado na turma");
            }

            AlunoTurma? newAlunoTurma = await _alunoTurmaRepository.GetByIdTurmaAndIdAluno(entity.TurmaId, entity.AlunoId);

            if (newAlunoTurma != null)
            {
                throw new CustomException("Aluno já cadastrado na turma");
            }

            return await _alunoTurmaRepository.Update(entity);
        }
    }
}
