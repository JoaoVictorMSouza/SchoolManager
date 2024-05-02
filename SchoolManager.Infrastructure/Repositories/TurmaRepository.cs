using Dapper;
using Microsoft.Extensions.Configuration;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Interface.Repository;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace SchoolManager.Infrastructure.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly string _connectionString;

        public TurmaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Connection")!;
        }

        public async Task<IEnumerable<Turma>> GetAll()
        {
            IEnumerable<Turma> turmas;

            using (var con = new SqlConnection(_connectionString))
            {
                var query = @" 
                    SELECT
                        *
                    FROM TURMA;
                ";

                var result = await con.QueryAsync<dynamic>(query);

                turmas = result.Select(item => new Turma
                {
                    Id = item.id,
                    CursoId = item.curso_id,
                    TurmaNome = item.turma,
                    Ano = item.ano,
                    Inativo = item.inativo != 0
                });
            };

            return turmas;
        }

        public async Task<Turma> GetById(int id)
        {
            Turma turma;

            var prm = new DynamicParameters();
            prm.Add("@id", id);

            using (var con = new SqlConnection(_connectionString))
            {
                var query = @"
                    SELECT
                        *
                    FROM TURMA
                    WHERE
                        id = @id;
                ";

                var result = await con.QueryAsync<dynamic>(query, prm);

                turma = result.Select(item => new Turma
                {
                    Id = item.id,
                    CursoId = item.curso_id,
                    TurmaNome = item.turma,
                    Ano = item.ano,
                    Inativo = item.inativo != 0
                }).FirstOrDefault()!;
            };

            return turma;
        }

        public async Task<int> Insert(Turma entity)
        {
            int result = 0;

            var prm = new DynamicParameters();
            prm.Add("@cursoId", entity.CursoId);
            prm.Add("@turma", entity.TurmaNome);
            prm.Add("@ano", entity.Ano);
            prm.Add("@inativo", entity.Inativo);

            using (var con = new SqlConnection(_connectionString))
            {
                var query = @"
                    INSERT INTO TURMA (curso_id, turma, ano, inativo)
                    VALUES (
                        @cursoId,
                        @turma,
                        @ano,
                        @inativo
                    );

                    SELECT CAST(SCOPE_IDENTITY() as int);
                ";

                result = await con.ExecuteScalarAsync<int>(query, prm);
            };

            return result;
        }

        public async Task<bool> Update(Turma entity)
        {
            bool result = false;

            var prm = new DynamicParameters();
            prm.Add("@id", entity.Id);
            prm.Add("@cursoId", entity.CursoId);
            prm.Add("@turma", entity.TurmaNome);
            prm.Add("@ano", entity.Ano);
            prm.Add("@inativo", entity.Inativo);

            using (var con = new SqlConnection(_connectionString))
            {
                var query = @"
                    UPDATE TURMA
                    SET
                        curso_id = @cursoId,
                        turma = @turma,
                        ano = @ano,
                        inativo = @inativo
                    WHERE
                        id = @id;
                ";

                var exec = await con.ExecuteAsync(query, prm);

                result = (exec > 0);
            }

            return result;
        }
    }
}
