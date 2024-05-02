using Microsoft.Extensions.Configuration;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Interface.Repository;

namespace SchoolManager.Infrastructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly string _connectionString;

        public AlunoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Connection")!;
        }

        public Task<IEnumerable<Aluno>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Aluno> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(Aluno entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Aluno entity)
        {
            throw new NotImplementedException();
        }
    }
}
