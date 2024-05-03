using Moq;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Entities.Exception;
using SchoolManager.Domain.Interface.Repository;
using SchoolManager.Service.Services;

namespace SchoolManager.UnitTests
{
    public class TurmaTest
    {
        private readonly Mock<ITurmaRepository> _mockTurmaRepository;
        private readonly TurmaService _turmaService;

        public TurmaTest()
        {
            _mockTurmaRepository = new Mock<ITurmaRepository>();

            Turma turma1 = new Turma()
            {
                Id = 1,
                CursoId = 1,
                TurmaNome = "Turma 1",
                Ano = 2025,
                Inativo = false
            };

            Turma turma2 = new Turma()
            {
                Id = 2,
                CursoId = 2,
                TurmaNome = "Turma 2",
                Ano = 2024,
                Inativo = false
            };

            _mockTurmaRepository.Setup(repo => repo.GetByName(It.Is<string>(x => x == "Turma 1"))).ReturnsAsync(turma1);
            _mockTurmaRepository.Setup(repo => repo.GetByIdTurma(It.Is<int>(x => x == 2))).ReturnsAsync(turma2);

            _turmaService = new TurmaService(_mockTurmaRepository.Object);
        }

        #region Insert
        [Fact]
        public async void InsertTurmaSuccess()
        {
            Turma newTurma = new Turma()
            {
                TurmaNome = "Turma 3",
                Ano = 2027,
                Inativo = false,
                CursoId = 3
            };

            await _turmaService.CreateTurma(newTurma);
        }

        [Fact]
        public async void InsertTurmaDuplicateNameError()
        {
            Turma newTurma = new Turma()
            {
                TurmaNome = "Turma 1",
                Ano = 2027,
                Inativo = false,
                CursoId = 1
            };

            CustomException? curtomException = await Assert.ThrowsAsync<CustomException>(async () => await _turmaService.CreateTurma(newTurma));

            Assert.NotNull(curtomException);
            Assert.Equal("Já existe uma turma com este nome", curtomException.Message);
        }

        [Fact]
        public async void InsertTurmaYearLessThanCurrentError()
        {
            Turma newTurma = new Turma()
            {
                TurmaNome = "Turma 3",
                Ano = 2022,
                Inativo = false,
                CursoId = 3
            };

            CustomException? curtomException = await Assert.ThrowsAsync<CustomException>(async () => await _turmaService.CreateTurma(newTurma));

            Assert.NotNull(curtomException);
            Assert.Equal("Não é possível incluír turmas para datas anteriores à data atual", curtomException.Message);
        }
        #endregion

        #region Update
        [Fact]
        public async void UpdateTurmaSuccess()
        {
            Turma updateTurma = new Turma()
            {
                Id = 2,
                TurmaNome = "Turma 2",
                Ano = 2029,
                Inativo = false,
                CursoId = 2
            };

            await _turmaService.UpdateTurma(updateTurma);
        }

        [Fact]
        public async void UpdateTurmaNotFoundError()
        {
            Turma updateTurma = new Turma()
            {
                Id = 3,
                TurmaNome = "Turma 2",
                Ano = 2029,
                Inativo = false,
                CursoId = 3
            };

            CustomException? curtomException = await Assert.ThrowsAsync<CustomException>(async () => await _turmaService.UpdateTurma(updateTurma));

            Assert.NotNull(curtomException);
            Assert.Equal("Turma não encontrada", curtomException.Message);
        }

        [Fact]
        public async void UpdateTurmaDuplicateNameError()
        {
            Turma updateTurma = new Turma()
            {
                Id = 2,
                TurmaNome = "Turma 1",
                Ano = 2029,
                Inativo = false,
                CursoId = 3
            };

            CustomException? curtomException = await Assert.ThrowsAsync<CustomException>(async () => await _turmaService.UpdateTurma(updateTurma));

            Assert.NotNull(curtomException);
            Assert.Equal("Já existe uma turma com este nome", curtomException.Message);
        }

        [Fact]
        public async void UpdateTurmaYearLessThanCurrentError()
        {
            Turma updateTurma = new Turma()
            {
                Id = 2,
                TurmaNome = "Turma 2",
                Ano = 2021,
                Inativo = false,
                CursoId = 2
            };

            CustomException? curtomException = await Assert.ThrowsAsync<CustomException>(async () => await _turmaService.UpdateTurma(updateTurma));

            Assert.NotNull(curtomException);
            Assert.Equal("Não é possível incluír turmas para datas anteriores à data atual", curtomException.Message);
        }
        #endregion
    }
}
