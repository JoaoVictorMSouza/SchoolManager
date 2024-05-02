using Moq;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Entities.Exception;
using SchoolManager.Domain.Interface.Repository;
using SchoolManager.Service.Services;

namespace SchoolManager.UnitTests
{
    public class AlunoTest
    {
        private readonly Mock<IAlunoRepository> _mockAlunoRepository;
        private readonly AlunoService _alunoService;

        public AlunoTest()
        {
            _mockAlunoRepository = new Mock<IAlunoRepository>();

            Aluno aluno1 = new Aluno()
            {
                Id = 1,
                Nome = "Aluno 1",
                Usuario = "Aluno 1",
                Senha = "kiozCMaFazWrTsGq08pEJA==:VYh1lteIGKGWu/qAN2L3Mqb6ys1lfVUjLnawrtfsf88=",
                Inativo = false
            };

            _mockAlunoRepository.Setup(repo => repo.GetById(It.Is<int>(x => x == 1))).ReturnsAsync(aluno1);

            _alunoService = new AlunoService(_mockAlunoRepository.Object);
        }

        #region Insert
        [Fact]
        public async void InsertAlunoSuccess()
        {
            Aluno newAluno = new Aluno()
            {
                Nome = "Aluno 3",
                Usuario = "Aluno 3",
                Senha = "123456Aa#@",
                Inativo = false
            };

            await _alunoService.CreateAluno(newAluno);
        }

        [Fact]
        public async void InsertAlunoWeakPasswordError()
        {
            Aluno newAluno = new Aluno()
            {
                Nome = "Aluno 3",
                Usuario = "Aluno 3",
                Senha = "123456",
                Inativo = false
            };

            CustomException? curtomException = await Assert.ThrowsAsync<CustomException>(async () => await _alunoService.CreateAluno(newAluno));

            Assert.NotNull(curtomException);
            Assert.Equal("Por favor, insira uma senha mais forte.", curtomException.Message);
        }
        #endregion

        #region Update
        [Fact]
        public async void UpdateAlunoSuccess()
        {
            Aluno updateAluno = new Aluno()
            {
                Id = 1,
                Nome = "Aluno 1",
                Usuario = "Aluno 1",
                Senha = "123456Aa#@",
                Inativo = false
            };

            await _alunoService.UpdateAluno(updateAluno);
        }

        [Fact]
        public async void UpdateAlunodifferentPasswordSuccess()
        {
            Aluno updateAluno = new Aluno()
            {
                Id = 1,
                Nome = "Aluno 1",
                Usuario = "Aluno 1",
                Senha = "123456Aa#@123",
                Inativo = false
            };

            await _alunoService.UpdateAluno(updateAluno);
        }

        [Fact]
        public async void UpdateAlunoWeakPasswordError()
        {
            Aluno updateAluno = new Aluno()
            {
                Id = 1,
                Nome = "Aluno 1",
                Usuario = "Aluno 1",
                Senha = "123456",
                Inativo = false
            };

            CustomException? curtomException = await Assert.ThrowsAsync<CustomException>(async () => await _alunoService.UpdateAluno(updateAluno));

            Assert.NotNull(curtomException);
            Assert.Equal("Por favor, insira uma senha mais forte.", curtomException.Message);
        }
        #endregion
    }
}
