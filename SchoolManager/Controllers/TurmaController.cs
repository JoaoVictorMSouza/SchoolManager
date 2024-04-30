using Microsoft.AspNetCore.Mvc;

namespace SchoolManager.Application.Controllers
{
    public class TurmaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
