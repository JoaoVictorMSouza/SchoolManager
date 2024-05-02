using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Entities.Exception;
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
        public async Task<int> CreateTurma(Turma entity)
        {
            entity.ValidateYear();

            Turma? turma = await _turmaRepository.GetByName(entity.TurmaNome);

            if (turma != null)
            {
                entity.ValidateName(turma.TurmaNome);
            }

            return await _turmaRepository.Insert(entity);
        }

        public async Task<List<Turma>> GetAllTurma()
        {
            IEnumerable<Turma> turmas = await _turmaRepository.GetAll();
            return turmas.ToList();
        }

        public async Task<Turma> GetById(int id)
        {
            return await _turmaRepository.GetById(id);
        }

        public async Task<bool> InactivateTurmaById(int id)
        {
            Turma turma = await _turmaRepository.GetById(id);

            if (turma == null)
            {
                throw new CustomException("Turma não encontrada");
            }

            turma.Inactivate();

            return await _turmaRepository.Update(turma);
        }

        public async Task<bool> ActivateTurmaById(int id)
        {
            Turma turma = await _turmaRepository.GetById(id);

            if (turma == null)
            {
                throw new CustomException("Turma não encontrada");
            }

            turma.Activate();

            return await _turmaRepository.Update(turma);
        }

        public async Task<bool> UpdateTurma(Turma entity)
        {
            Turma turma = await _turmaRepository.GetById(entity.Id);

            if (turma == null)
            {
                throw new CustomException("Turma não encontrada");
            }

            entity.Id = turma.Id;
            entity.Inativo = entity.Inativo;

            entity.ValidateYear();

            Turma? turmaFind = await _turmaRepository.GetByName(entity.TurmaNome);

            if (turmaFind != null && turmaFind.Id != entity.Id)
            {
                entity.ValidateName(turmaFind.TurmaNome);
            }

            return await _turmaRepository.Update(entity);
        }
    }
}
