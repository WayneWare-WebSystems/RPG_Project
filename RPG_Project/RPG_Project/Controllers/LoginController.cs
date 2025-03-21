using Microsoft.AspNetCore.Mvc;
using RPG_Project.Context;
using RPG_Project.Repositories.Interfaces;
using System;

namespace RPG_Project.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;

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
            try
            {
                var usuario = _userRepository.GetUsuarioLogado(nome, senha);

                if (usuario == null)
                {
                    return Json(new { success = false, message = "Usuário não encontrado" });
                }

                // Armazena o ID do usuário na sessão
                HttpContext.Session.SetString("UserId", usuario.Id_Usuario.ToString());

                if (usuario.IsAdm)
                    return Json(new { success = true, redirectUrl = "/Login/AdmHome" });
                else
                    return Json(new { success = true, redirectUrl = "/Login/Home" });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Erro ao encontrar usuário: " + e.Message });
            }
        }

        private Guid? GetUserIdFromSession()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (userId != null && Guid.TryParse(userId, out var id))
            {
                return id;
            }
            return null;
        }

        private IActionResult CheckUserLoggedIn()
        {
            var userId = GetUserIdFromSession();
            if (userId == null)
            {
                return RedirectToAction("Login");
            }
            return null;
        }

        [HttpGet]
        public IActionResult AdmHome()
        {
            var checkResult = CheckUserLoggedIn();
            if (checkResult != null)
            {
                return checkResult;
            }

            var userId = GetUserIdFromSession();
            var usuario = _userRepository.GetUsuarioById(userId.Value);

            // Use o usuário conforme necessário
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Home()
        {
            var checkResult = CheckUserLoggedIn();
            if (checkResult != null)
            {
                return checkResult;
            }

            var userId = GetUserIdFromSession();
            var usuario = _userRepository.GetUsuarioById(userId.Value);

            // Use o usuário conforme necessário
            return View(usuario);
        }

        [HttpGet]
        public IActionResult CheckSession()
        {
            var userId = GetUserIdFromSession();
            return Json(new { isLoggedIn = userId != null });
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Login");
        }
    }
}