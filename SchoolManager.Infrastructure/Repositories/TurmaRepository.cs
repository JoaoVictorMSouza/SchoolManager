using Microsoft.Extensions.Configuration;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Interface.Repository;

namespace SchoolManager.Infrastructure.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly string _connectionString;

        public TurmaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Connection")!;
        }

        public Task<List<Turma>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(Turma entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Turma entity)
        {
            throw new NotImplementedException();
        }
    }
}
