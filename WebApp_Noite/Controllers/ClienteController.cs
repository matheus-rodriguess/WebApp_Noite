using Microsoft.AspNetCore.Mvc;

namespace WebApp_Noite.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }
        public IActionResult Lista()
        {
            return View();
        }
    }
}
