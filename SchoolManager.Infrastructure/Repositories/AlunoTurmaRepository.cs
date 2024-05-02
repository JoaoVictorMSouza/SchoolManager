using Microsoft.Extensions.Configuration;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Interface.Repository;

namespace SchoolManager.Infrastructure.Repositories
{
    public class AlunoTurmaRepository : IAlunoTurmaRepository
    {
        private readonly string _connectionString;

        public AlunoTurmaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Connection")!;
        }

        public Task<IEnumerable<AlunoTurma>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AlunoTurma> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(AlunoTurma entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(AlunoTurma entity)
        {
            throw new NotImplementedException();
        }
    }
}
