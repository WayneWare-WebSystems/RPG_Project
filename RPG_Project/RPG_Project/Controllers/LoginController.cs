using Microsoft.AspNetCore.Mvc;
using RPG_Project.Context;
using RPG_Project.Repositories.Interfaces;

namespace RPG_Project.Controllers
{
    public class LoginController : Controller
    {
        public readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnviaHome(string nome, string senha)
        {
            var usuario = _userRepository.GetUsuarioLogado(nome, senha);

            if (usuario == null)
                throw new Exception("Usuario não encontrado");

            try
            {
                if (usuario.IsAdm)
                    return Json("/Login/AdmHome");
                else
                    return Json("/Login/Home");
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao encontrar usuario: " + e.Message);
            }
        }

        [HttpGet]
        public IActionResult AdmHome()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }
    }
}
