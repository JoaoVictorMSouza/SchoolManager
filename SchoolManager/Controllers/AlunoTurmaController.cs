using Microsoft.AspNetCore.Mvc;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Interface.Repository;

namespace SchoolManager.Application.Controllers
{
    public class AlunoTurmaController : Controller
    {
        private readonly IAlunoTurmaService _alunoTurmaService;
        private readonly ITurmaService _turmaService;

        public AlunoTurmaController(IAlunoTurmaService alunoAlunoTurmaService, ITurmaService turmaService)
        {
            this._alunoTurmaService = alunoAlunoTurmaService;
            this._turmaService = turmaService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAlunoTurma()
        {
            List<AlunoTurma> alunoTurma = await _alunoTurmaService.GetAllAlunoTurma();

            return View("ListAlunoTurma", alunoTurma);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAlunoTurmaView()
        {
            List<Turma> turmas = await _turmaService.GetAllTurma();
            List<AlunoTurma> alunoTurmas = await _alunoTurmaService.GetAllAlunoTurma();

            return View("CreateAlunoTurma", Tuple.Create(alunoTurmas, turmas));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlunoTurma(AlunoTurma alunoTurma)
        {
            if (!ModelState.IsValid)
            {
                List<Turma> turmas = await _turmaService.GetAllTurma();
                List<AlunoTurma> alunoTurmas = await _alunoTurmaService.GetAllAlunoTurma();

                return View("CreateAlunoTurma", Tuple.Create(alunoTurmas, turmas));
            }

            await _alunoTurmaService.CreateAlunoTurma(alunoTurma);
            return RedirectToAction("ListAlunoTurma");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAlunoTurmaView(int idTurma, int idAluno)
        {
            AlunoTurma alunoTurma = await _alunoTurmaService.GetByIdTurmaAndIdAluno(idTurma, idAluno);
            List<Turma> turmas = await _turmaService.GetAllTurma();

            turmas.RemoveAll(t => t.Id == alunoTurma.TurmaId);

            return View("UpdateAlunoTurma", Tuple.Create(alunoTurma, turmas));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAlunoTurma(AlunoTurma alunoTurma)
        {
            if (!ModelState.IsValid)
            {
                List<Turma> turmas = await _turmaService.GetAllTurma();

                return View("UpdateAlunoTurma", Tuple.Create(alunoTurma, turmas));
            }

            await _alunoTurmaService.UpdateAlunoTurma(alunoTurma);
            return RedirectToAction("ListAlunoTurma");
        }

        [HttpGet]
        public async Task<IActionResult> InactivateAlunoTurmaView(int idTurma, int idAluno)
        {
            AlunoTurma alunoTurma = await _alunoTurmaService.GetByIdTurmaAndIdAluno(idTurma, idAluno);

            return View("InativarAlunoTurma", alunoTurma);
        }

        [HttpPost]
        public async Task<IActionResult> InactivateAlunoTurma(int idTurma, int idAluno)
        {
            await _alunoTurmaService.InactivateAlunoTurmaByIdTurmaAndIdAluno(idTurma, idAluno);
            return RedirectToAction("ListAlunoTurma");
        }

        [HttpPost]
        public async Task<IActionResult> ActivateAlunoTurma(int idTurma, int idAluno)
        {
            await _alunoTurmaService.ActivateAlunoTurmaByIdTurmaAndIdAluno(idTurma, idAluno);
            return RedirectToAction("ListAlunoTurma");
        }

        [HttpGet]
        public async Task<IActionResult> GetAlunosByTurma(int turmaId)
        {
            List<Aluno> alunos = await _alunoTurmaService.GetAlunosByTurma(turmaId);
            return Json(alunos.Select(a => new { Id = a.Id, Nome = a.Nome }));
        }
    }
}
