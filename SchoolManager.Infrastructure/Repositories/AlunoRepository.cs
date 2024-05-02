using Dapper;
using Microsoft.Extensions.Configuration;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Interface.Repository;
using System.Data.SqlClient;

namespace SchoolManager.Infrastructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly string _connectionString;

        public AlunoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Connection")!;
        }

        public async Task<IEnumerable<Aluno>> GetAll()
        {
            IEnumerable<Aluno> alunos;

            using (var con = new SqlConnection(_connectionString))
            {
                var query = @" 
                    SELECT
                        *
                    FROM ALUNO;
                ";

                var result = await con.QueryAsync<dynamic>(query);

                alunos = result.Select(item => new Aluno
                {
                    Id = item.id,
                    Nome = item.nome,
                    Usuario = item.usuario,
                    Senha = "",
                    Inativo = item.inativo != 0
                });
            };

            return alunos;
        }

        public async Task<Aluno> GetById(int id)
        {
            Aluno aluno;

            var prm = new DynamicParameters();
            prm.Add("@id", id);

            using (var con = new SqlConnection(_connectionString))
            {
                var query = @"
                    SELECT
                        *
                    FROM ALUNO
                    WHERE
                        id = @id;
                ";

                var result = await con.QueryAsync<dynamic>(query, prm);

                aluno = result.Select(item => new Aluno
                {
                    Id = item.id,
                    Nome = item.nome,
                    Usuario = item.usuario,
                    Senha = "",
                    Inativo = item.inativo != 0
                }).FirstOrDefault()!;
            };

            return aluno;
        }

        public async Task<Aluno> GetByIdWithPassword(int id)
        {
            Aluno aluno;

            var prm = new DynamicParameters();
            prm.Add("@id", id);

            using (var con = new SqlConnection(_connectionString))
            {
                var query = @"
                    SELECT
                        *
                    FROM ALUNO
                    WHERE
                        id = @id;
                ";

                var result = await con.QueryAsync<dynamic>(query, prm);

                aluno = result.Select(item => new Aluno
                {
                    Id = item.id,
                    Nome = item.nome,
                    Usuario = item.usuario,
                    Senha = item.senha,
                    Inativo = item.inativo != 0
                }).FirstOrDefault()!;
            };

            return aluno;
        }

        public async Task<int> Insert(Aluno entity)
        {
            int result = 0;

            var prm = new DynamicParameters();
            prm.Add("@nome", entity.Nome);
            prm.Add("@usuario", entity.Usuario);
            prm.Add("@senha", entity.Senha);
            prm.Add("@inativo", entity.Inativo);

            using (var con = new SqlConnection(_connectionString))
            {
                var query = @"
                    INSERT INTO ALUNO (nome, usuario, senha, inativo)
                    VALUES (
                        @nome,
                        @usuario,
                        @senha,
                        @inativo
                    );

                    SELECT CAST(SCOPE_IDENTITY() as int);
                ";

                result = await con.ExecuteScalarAsync<int>(query, prm);
            };

            return result;
        }

        public async Task<bool> Update(Aluno entity)
        {
            bool result = false;

            var prm = new DynamicParameters();
            prm.Add("@id", entity.Id);
            prm.Add("@nome", entity.Nome);
            prm.Add("@usuario", entity.Usuario);
            prm.Add("@inativo", entity.Inativo);

            using (var con = new SqlConnection(_connectionString))
            {
                var query = @"
                    UPDATE ALUNO
                    SET
                        nome = @nome,
                        usuario = @usuario,
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
