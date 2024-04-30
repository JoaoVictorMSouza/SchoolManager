using Microsoft.AspNetCore.Mvc;

namespace SchoolManager.Application.Controllers
{
    public class AlunoTurmaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
