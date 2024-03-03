using DapperLoginCRUD.Models;
using DapperLoginCRUD.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DapperLoginCRUD.Controllers
{
    //[Authorize]
    public class VideoJuegosController : Controller
    {
        private readonly IServicioUsuario servicioUsuario;
        private readonly IRepositorioVideoJuegos repositorioVideoJuegos;

        public VideoJuegosController(IServicioUsuario servicioUsuario, IRepositorioVideoJuegos repositorioVideoJuegos) {
            this.servicioUsuario = servicioUsuario;
            this.repositorioVideoJuegos = repositorioVideoJuegos;
        }

        // GET: VideoJuegosController
        //[Authorize]
        public async Task<ActionResult> Index()
        {
            var idUsuario = servicioUsuario.ObtenerUsuarioId();
            var conjuntoVideojuegos = await repositorioVideoJuegos.Obtener(idUsuario);

            return View(conjuntoVideojuegos);
        }

        // GET: VideoJuegosController/Create
        public ActionResult RegistrarVideojuego()
        {
            return View();
        }

        // POST: VideoJuegosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegistrarVideojuego(VideoJuegos videojuego)
        {
            var idUsuario = servicioUsuario.ObtenerUsuarioId();

            try
            {
                videojuego.IdUsuario = idUsuario;
                await repositorioVideoJuegos.CrearVideojuego(videojuego);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
            finally
            {
                Console.WriteLine("Esto siempre se ejecuta SELECT");
            }
        }

        // GET: VideoJuegosController/Edit/5
        public async Task<ActionResult> EditarVideojuego(int id)
        {
            var idUsuario = servicioUsuario.ObtenerUsuarioId();
            var registroVideojuego = await repositorioVideoJuegos.ObtenerPorId(id, idUsuario);
            return View(registroVideojuego);
        }

        // POST: VideoJuegosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditarVideoJuego(VideoJuegos videojuego)
        {
            try
            {
                await repositorioVideoJuegos.Actualizar(videojuego);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
            finally
            {
                Console.WriteLine("Esto siempre se ejecuta EDIT");
            }
        }

        // GET: VideoJuegosController/Delete/5
        public async Task<ActionResult> BorrarVideojuego(int id)
        {
            var idUsuario = servicioUsuario.ObtenerUsuarioId();
            var registroVideojuego = await repositorioVideoJuegos.ObtenerPorId(id, idUsuario);
            return View(registroVideojuego);
            
        }

        // POST: VideoJuegosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BorrarRegistroVideojuego(int id)
        {
            try
            {
                await repositorioVideoJuegos.Borrar(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
            finally
            {
                Console.WriteLine("Esto siempre se ejecuta DELETE");
            }
        }
    }
}
