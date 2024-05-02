using Microsoft.AspNetCore.Mvc;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Interface.Repository;

namespace SchoolManager.Application.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ITurmaService _turmaService;
        public TurmaController(ITurmaService turmaService)
        {
            this._turmaService = turmaService;
        }

        [HttpGet]
        public async Task<IActionResult> ListTurma()
        {
            List<Turma> turma = await _turmaService.GetAllTurma();
            return View("ListTurma", turma);
        }

        [HttpGet]
        public IActionResult CreateTurmaView()
        {
            return View("CreateTurma", new Turma());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTurma(Turma turma)
        {
            await _turmaService.CreateTurma(turma);
            return RedirectToAction("ListTurma");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTurmaView([FromRoute] int id)
        {
            Turma turma = await _turmaService.GetById(id);
            return View("UpdateTurma", turma);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTurma(Turma turma)
        {
            await _turmaService.UpdateTurma(turma);
            return RedirectToAction("ListTurma");
        }

        [HttpGet]
        public async Task<IActionResult> InactivateTurmaView([FromRoute] int id)
        {
            Turma turma = await _turmaService.GetById(id);

            return View("InativarTurma", turma);
        }

        [HttpPost]
        public async Task<IActionResult> InactivateTurma(int id)
        {
            await _turmaService.InactivateTurmaById(id);
            return RedirectToAction("ListTurma");
        }

        [HttpPost]
        public async Task<IActionResult> ActivateTurma(int id)
        {
            await _turmaService.ActivateTurmaById(id);
            return RedirectToAction("ListTurma");
        }
    }
}
