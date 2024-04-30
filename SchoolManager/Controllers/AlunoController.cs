using Microsoft.AspNetCore.Mvc;
using SchoolManager.Domain.Entities;

namespace SchoolManager.Application.Controllers
{
    public class AlunoController : Controller
    {
        [HttpGet]
        public IActionResult ListAluno()
        {
            List<Aluno> alunos = new List<Aluno>();
            return View("ListAluno", alunos);
        }

        [HttpGet]
        public IActionResult CreateAlunoView()
        {
            return View("CreateAluno");
        }

        [HttpPost]
        public IActionResult CreateAluno()
        {
            List<Aluno> alunos = new List<Aluno>();
            return View("ListAluno", alunos);
        }
    }
}
