using Dapper;
using Microsoft.Extensions.Configuration;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Interface.Repository;
using System.Data.SqlClient;

namespace SchoolManager.Infrastructure.Repositories
{
    public class AlunoTurmaRepository : IAlunoTurmaRepository
    {
        private readonly string _connectionString;

        public AlunoTurmaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Connection")!;
        }

        public async Task<IEnumerable<AlunoTurma>> GetAll()
        {
            IEnumerable<AlunoTurma> alunoTurmas;

            using (var con = new SqlConnection(_connectionString))
            {
                var query = @" 
                        SELECT  ALUNO_TURMA.*, 
                                TURMA.*, 
                                ALUNO.*, 
                                ALUNO.INATIVO AS ALUNO_INATIVO,
                                TURMA.INATIVO AS TURMA_INATIVO
                        FROM ALUNO_TURMA 
                            LEFT JOIN TURMA ON ALUNO_TURMA.TURMA_ID = TURMA.ID 
                            LEFT JOIN ALUNO ON ALUNO_TURMA.ALUNO_ID = ALUNO.ID;
                    ";

                var result = await con.QueryAsync<dynamic>(query);

                alunoTurmas = result.Select(item => new AlunoTurma
                {
                    AlunoId = item.aluno_id,
                    TurmaId = item.turma_id,
                    Inativo = item.inativo != 0,
                    Aluno = new Aluno
                    {
                        Id = item.aluno_id,
                        Nome = item.nome,
                        Usuario = item.usuario,
                        Senha = "",
                        Inativo = item.ALUNO_INATIVO != 0
                    },
                    Turma = new Turma
                    {
                        Id = item.turma_id,
                        CursoId = item.curso_id,
                        TurmaNome = item.turma,
                        Ano = item.ano,
                        Inativo = item.TURMA_INATIVO != 0
                    }
                });
            };

            return alunoTurmas;
        }

        public async Task<IEnumerable<Aluno>> GetAlunosByIdTurma(int idTurma)
        {
            IEnumerable<Aluno> alunos;

            var prm = new DynamicParameters();
            prm.Add("@idTurma", idTurma);

            using (var con = new SqlConnection(_connectionString))
            {
                var query = @" 
                        SELECT  ALUNO_TURMA.*, 
                                ALUNO.*, 
                                ALUNO.INATIVO AS ALUNO_INATIVO
                        FROM ALUNO_TURMA 
                            LEFT JOIN ALUNO ON ALUNO_TURMA.ALUNO_ID = ALUNO.ID
                        WHERE
                            ALUNO_TURMA.TURMA_ID = @idTurma 
                    ;";

                var result = await con.QueryAsync<dynamic>(query, prm);

                alunos = result.Select(item => new Aluno
                {
                    Id = item.aluno_id,
                    Nome = item.nome,
                    Usuario = item.usuario,
                    Senha = "",
                    Inativo = item.ALUNO_INATIVO != 0
                });
            };

            return alunos;
        }

        public async Task<AlunoTurma?> GetByIdTurmaAndIdAluno(int idTurma, int idAluno)
        {
            AlunoTurma alunoTurma;

            var prm = new DynamicParameters();
            prm.Add("@idTurma", idTurma);
            prm.Add("@idAluno", idAluno);

            using (var con = new SqlConnection(_connectionString))
            {
                var query = @"
                    SELECT
                        ALUNO_TURMA.*,
                        ALUNO.*,
                        ALUNO.INATIVO AS ALUNO_INATIVO,
                        TURMA.*,
                        TURMA.INATIVO AS TURMA_INATIVO
                    FROM ALUNO_TURMA
                            LEFT JOIN ALUNO ON ALUNO_TURMA.ALUNO_ID = ALUNO.ID
                            LEFT JOIN TURMA ON ALUNO_TURMA.TURMA_ID = TURMA.ID 
                    WHERE
                        turma_id = @idTurma
                            AND
                        aluno_id = @idAluno;
                ";

                var result = await con.QueryAsync<dynamic>(query, prm);

                alunoTurma = result.Select(item => new AlunoTurma
                {
                    TurmaId = item.turma_id,
                    AlunoId = item.aluno_id,
                    Inativo = item.inativo != 0,
                    Aluno = new Aluno
                    {
                        Id = item.aluno_id,
                        Nome = item.nome,
                        Usuario = item.usuario,
                        Senha = "",
                        Inativo = item.ALUNO_INATIVO != 0
                    },
                    Turma = new Turma
                    {
                        Id = item.turma_id,
                        CursoId = item.curso_id,
                        TurmaNome = item.turma,
                        Ano = item.ano,
                        Inativo = item.TURMA_INATIVO != 0
                    }
                }).FirstOrDefault()!;
            };

            return alunoTurma;
        }

        public async Task<int> Insert(AlunoTurma entity)
        {
            int result = 0;

            var prm = new DynamicParameters();
            prm.Add("@turmaId", entity.TurmaId);
            prm.Add("@alunoId", entity.AlunoId);
            prm.Add("@inativo", entity.Inativo);

            using (var con = new SqlConnection(_connectionString))
            {
                var query = @"
                    INSERT INTO ALUNO_TURMA (turma_id, aluno_id, inativo)
                    VALUES (
                        @turmaId,
                        @alunoId,
                        @inativo
                    );

                    SELECT CAST(SCOPE_IDENTITY() as int);
                ";

                result = await con.ExecuteScalarAsync<int>(query, prm);
            };

            return result;
        }

        public async Task<bool> Update(AlunoTurma entity)
        {
            bool result = false;

            var prm = new DynamicParameters();
            prm.Add("@idTurma", entity.TurmaId);
            prm.Add("@idAluno", entity.AlunoId);
            prm.Add("@turmaAntigaId", entity.TurmaAntigaId);
            prm.Add("@inativo", entity.Inativo);

            using (var con = new SqlConnection(_connectionString))
            {
                var query = @"
                    UPDATE ALUNO_TURMA
                    SET
                        aluno_id = @idAluno,
                        turma_id = @idTurma,
                        inativo = @inativo
                    WHERE
                        turma_id = @turmaAntigaId
                            AND
                        aluno_id = @idAluno;
                ";

                var exec = await con.ExecuteAsync(query, prm);

                result = (exec > 0);
            }

            return result;
        }
    }
}
