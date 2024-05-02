using Microsoft.AspNetCore.Mvc;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Interface.Repository;

namespace SchoolManager.Application.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoService _alunoService;
        public AlunoController(IAlunoService alunoService)
        {
            this._alunoService = alunoService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAluno()
        {
            List<Aluno> alunos = await _alunoService.GetAllAluno();
            return View("ListAluno", alunos);
        }

        [HttpGet]
        public IActionResult CreateAlunoView()
        {
            return View("CreateAluno", new Aluno());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAluno(Aluno aluno)
        {
            await _alunoService.CreateAluno(aluno);
            return RedirectToAction("ListAluno");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAlunoView([FromRoute] int id)
        {
            Aluno aluno = await _alunoService.GetById(id);
            return View("UpdateAluno", aluno);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAluno(Aluno aluno)
        {
            await _alunoService.UpdateAluno(aluno);
            return RedirectToAction("ListAluno");
        }

        [HttpGet]
        public async Task<IActionResult> InactivateAlunoView([FromRoute] int id)
        {
            Aluno aluno = await _alunoService.GetById(id);

            return View("InativarAluno", aluno);
        }

        [HttpPost]
        public async Task<IActionResult> InactivateAluno(int id)
        {
            await _alunoService.InactivateAlunoById(id);
            return RedirectToAction("ListAluno");
        }

        [HttpPost]
        public async Task<IActionResult> ActivateAluno(int id)
        {
            await _alunoService.ActivateAlunoById(id);
            return RedirectToAction("ListAluno");
        }
    }
}
