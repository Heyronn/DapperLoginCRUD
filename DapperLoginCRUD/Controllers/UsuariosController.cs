using DapperLoginCRUD.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DapperLoginCRUD.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UserManager<Usuarios> userManager;
        private readonly SignInManager<Usuarios> signInManager;

        public UsuariosController(UserManager<Usuarios> userManager,
            SignInManager<Usuarios> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }



        [AllowAnonymous]
        public ActionResult Registro()
        {


            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registro(RegistroViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            var usuario = new Usuarios() { Email = modelo.Email };
            var resultado = await userManager.CreateAsync(usuario, password: modelo.Password);
            if (resultado.Succeeded)
            {
                await signInManager.SignInAsync(usuario, isPersistent: true); // Configuracion para que si el usuario ciera el navagador el usuario seguira autenticado en la aplicacion
                return RedirectToAction("Index", "Videojuegos");
            }
            else
            {
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(modelo);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {


            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var resultado = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.Recuerdame, lockoutOnFailure: false);

            if(resultado.Succeeded)
            {
                return RedirectToAction("Index", "Videojuegos");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Nombre de usuario o password incorrecto");
                return View(model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Index", "Videojuegos");
        }


    }
}
