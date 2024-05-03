
using Moq;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Entities.Exception;
using SchoolManager.Domain.Interface.Repository;
using SchoolManager.Service.Services;

namespace SchoolManager.UnitTests
{
    public class AlunoTurmaTest
    {
        private readonly Mock<IAlunoTurmaRepository> _mockAlunoTurmaRepository;
        private readonly Mock<IAlunoRepository> _mockAlunoRepository;
        private readonly Mock<ITurmaRepository> _mockTurmaRepository;

        private readonly AlunoTurmaService _alunoTurmaService;

        public AlunoTurmaTest()
        {
            _mockAlunoTurmaRepository = new Mock<IAlunoTurmaRepository>();
            _mockAlunoRepository = new Mock<IAlunoRepository>();
            _mockTurmaRepository = new Mock<ITurmaRepository>();

            Aluno aluno1 = new Aluno()
            {
                Id = 1,
                Nome = "Aluno 1",
                Usuario = "Aluno 1",
                Senha = "kiozCMaFazWrTsGq08pEJA==:VYh1lteIGKGWu/qAN2L3Mqb6ys1lfVUjLnawrtfsf88=",
                Inativo = false
            };
            Aluno aluno2 = new Aluno()
            {
                Id = 2,
                Nome = "Aluno 2",
                Usuario = "Aluno 2",
                Senha = "kiozCMaFazWrTsGq08pEJA==:VYh1lteIGKGWu/qAN2L3Mqb6ys1lfVUjLnawrtfsf88=",
                Inativo = false
            };
            _mockAlunoRepository.Setup(repo => repo.GetByIdAluno(It.Is<int>(x => x == 1))).ReturnsAsync(aluno1);
            _mockAlunoRepository.Setup(repo => repo.GetByIdAluno(It.Is<int>(x => x == 2))).ReturnsAsync(aluno2);


            Turma turma1 = new Turma()
            {
                Id = 1,
                CursoId = 1,
                TurmaNome = "Turma 1",
                Ano = 2024,
                Inativo = false
            };
            Turma turma2 = new Turma()
            {
                Id = 2,
                CursoId = 2,
                TurmaNome = "Turma 2",
                Ano = 2025,
                Inativo = false
            };
            _mockTurmaRepository.Setup(repo => repo.GetByIdTurma(It.Is<int>(x => x == 1))).ReturnsAsync(turma2);
            _mockTurmaRepository.Setup(repo => repo.GetByIdTurma(It.Is<int>(x => x == 2))).ReturnsAsync(turma2);


            AlunoTurma alunoTurma1 = new AlunoTurma()
            {
                AlunoId = 1,
                TurmaId = 1,
                Inativo = false
            };
            AlunoTurma alunoTurma2 = new AlunoTurma()
            {
                AlunoId = 1,
                TurmaId = 3,
                Inativo = false
            };
            _mockAlunoTurmaRepository.Setup(repo => repo.GetByIdTurmaAndIdAluno(It.Is<int>(x => x == 1), It.Is<int>(x => x == 1))).ReturnsAsync(alunoTurma1);
            _mockAlunoTurmaRepository.Setup(repo => repo.GetByIdTurmaAndIdAluno(It.Is<int>(x => x == 3), It.Is<int>(x => x == 1))).ReturnsAsync(alunoTurma2);

            _alunoTurmaService = new AlunoTurmaService(_mockAlunoTurmaRepository.Object, _mockAlunoRepository.Object, _mockTurmaRepository.Object);
        }

        #region Insert
        [Fact]
        public async void InsertAlunoTurmaSuccess()
        {
            AlunoTurma newAlunoTurma = new AlunoTurma()
            {
                AlunoId = 2,
                TurmaId = 1,
                Inativo = false
            };

            await _alunoTurmaService.CreateAlunoTurma(newAlunoTurma);
        }

        [Fact]
        public async void InsertAlunoTurmaAlunoNotFoundError()
        {
            AlunoTurma newAlunoTurma = new AlunoTurma()
            {
                AlunoId = 5,
                TurmaId = 1,
                Inativo = false
            };

            CustomException? curtomException = await Assert.ThrowsAsync<CustomException>(async () => await _alunoTurmaService.CreateAlunoTurma(newAlunoTurma));

            Assert.NotNull(curtomException);
            Assert.Equal("Aluno não encontrado", curtomException.Message);
        }

        [Fact]
        public async void InsertAlunoTurmaTurmaNotFoundError()
        {
            AlunoTurma newAlunoTurma = new AlunoTurma()
            {
                AlunoId = 1,
                TurmaId = 5,
                Inativo = false
            };

            CustomException? curtomException = await Assert.ThrowsAsync<CustomException>(async () => await _alunoTurmaService.CreateAlunoTurma(newAlunoTurma));

            Assert.NotNull(curtomException);
            Assert.Equal("Turma não encontrada", curtomException.Message);
        }

        [Fact]
        public async void InsertAlunoTurmaSameTurmaError()
        {
            AlunoTurma newAlunoTurma = new AlunoTurma()
            {
                AlunoId = 1,
                TurmaId = 1,
                Inativo = false
            };

            CustomException? curtomException = await Assert.ThrowsAsync<CustomException>(async () => await _alunoTurmaService.CreateAlunoTurma(newAlunoTurma));

            Assert.NotNull(curtomException);
            Assert.Equal("Aluno já cadastrado na turma", curtomException.Message);
        }
        #endregion

        #region Update
        [Fact]
        public async void UpdateAlunoSuccess()
        {
            AlunoTurma updateAlunoTurma = new AlunoTurma()
            {
                TurmaId = 2,
                AlunoId = 1,
                Inativo = false,
                TurmaAntigaId = 1
            };

            await _alunoTurmaService.UpdateAlunoTurma(updateAlunoTurma);
        }

        [Fact]
        public async void UpdateAlunoTurmaNotFoundError()
        {
            AlunoTurma updateAlunoTurma = new AlunoTurma()
            {
                TurmaId = 2,
                AlunoId = 1,
                Inativo = false,
                TurmaAntigaId = 2
            };

            CustomException? curtomException = await Assert.ThrowsAsync<CustomException>(async () => await _alunoTurmaService.UpdateAlunoTurma(updateAlunoTurma));

            Assert.NotNull(curtomException);
            Assert.Equal("Aluno não encontrado na turma", curtomException.Message);
        }

        [Fact]
        public async void UpdateAlunoTurmaAlreadyRegisteredError()
        {
            AlunoTurma updateAlunoTurma = new AlunoTurma()
            {
                TurmaId = 3,
                AlunoId = 1,
                Inativo = false,
                TurmaAntigaId = 1
            };

            CustomException? curtomException = await Assert.ThrowsAsync<CustomException>(async () => await _alunoTurmaService.UpdateAlunoTurma(updateAlunoTurma));

            Assert.NotNull(curtomException);
            Assert.Equal("Aluno já cadastrado na turma", curtomException.Message);
        }
        #endregion
    }
}
